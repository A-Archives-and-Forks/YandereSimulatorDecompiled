using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HNS
{
	public class PlayerCombo : MonoBehaviour
	{
		public static PlayerCombo instance;

		public UITexture[] DPad;

		public UILabel[] DPadLabels;

		public List<Enemy> Hits;

		public LayerMask Filter;

		public bool hasHit;

		public float Velocity;

		private bool attackQueued;

		private bool movementQueued;

		private float upperBodyLayerWeight;

		private Coroutine activeColorSwitchCoroutine;

		private Coroutine activeFadeOutCoroutine;

		[Header("Hit Effects")]
		public Transform Hand;

		public ParticleSystem HitParticle;

		private Dictionary<Enemy, float> enemyHitTimes = new Dictionary<Enemy, float>();

		private void OnEnable()
		{
			instance = this;
		}

		private void OnDisable()
		{
			instance = null;
		}

		private void Start()
		{
			for (int i = 0; i < DPad.Length; i++)
			{
				DPad[i].alpha = ((i == Player.instance.Combo) ? 1f : 0.5f);
			}
			for (int j = 0; j < DPadLabels.Length; j++)
			{
				DPadLabels[j].alpha = (InputQuery.IsUsingKeyboardMouse ? ((j == Player.instance.Combo) ? 1f : 0.5f) : 0f);
			}
		}

		private void Update()
		{
			if (Player.instance.State != PlayerState.Cutscene && Player.instance.Stance != PlayerStance.Ultimate)
			{
				Combo[] combos = Player.instance.Profile.Combos;
				UpdateLayerWeight();
				if (Velocity > 0f)
				{
					Vector3 vector = ((!Player.instance.AbsoluteMovement) ? Player.instance.MyCamera.transform.forward : Player.instance.transform.forward);
					vector.y = 0f;
					Player.instance.MyController.Move(vector * Velocity * Time.deltaTime);
					Velocity -= Time.deltaTime * Player.instance.Profile.VelocityDecayRate;
				}
				UpdateCombo(combos);
				UpdateUI();
				if (Player.instance.Stance != PlayerStance.Dodge)
				{
					UpdateAttack(combos);
				}
			}
		}

		private void UpdateUI()
		{
			for (int i = 0; i < DPad.Length; i++)
			{
				DPad[i].alpha = Mathf.Lerp(DPad[i].alpha, (i == Player.instance.Combo) ? 1f : 0.5f, Time.deltaTime * 10f);
			}
			for (int j = 0; j < DPadLabels.Length; j++)
			{
				DPadLabels[j].alpha = (InputQuery.IsUsingKeyboardMouse ? Mathf.Lerp(DPadLabels[j].alpha, (j == Player.instance.Combo) ? 1f : 0.5f, Time.deltaTime * 10f) : Mathf.Lerp(DPadLabels[j].alpha, 0f, Time.deltaTime * 10f));
			}
		}

		private void UpdateCombo(Combo[] combos)
		{
			if (Player.instance.Stance == PlayerStance.Attack || Player.instance.Stance == PlayerStance.Ultimate || Player.instance.Stance == PlayerStance.Dodge || Player.instance.Stance == PlayerStance.Switch || Player.instance.Stance == PlayerStance.Hit)
			{
				return;
			}
			int num = -1;
			if (InputQuery.IsUsingKeyboardMouse)
			{
				if (InputQuery.ButtonDown(ButtonInput.Number1))
				{
					num = 0;
				}
				else if (InputQuery.ButtonDown(ButtonInput.Number2))
				{
					num = 1;
				}
				else if (InputQuery.ButtonDown(ButtonInput.Number3))
				{
					num = 2;
				}
				else if (InputQuery.ButtonDown(ButtonInput.Number4))
				{
					num = 3;
				}
			}
			else if (InputQuery.DirectionDown(Direction.Up, StickType.DPad))
			{
				num = 0;
			}
			else if (InputQuery.DirectionDown(Direction.Right, StickType.DPad))
			{
				num = 1;
			}
			else if (InputQuery.DirectionDown(Direction.Down, StickType.DPad))
			{
				num = 2;
			}
			else if (InputQuery.DirectionDown(Direction.Left, StickType.DPad))
			{
				num = 3;
			}
			if (num >= combos.Length)
			{
				return;
			}
			if (num >= 0 && Player.instance.Combo != num)
			{
				if (Player.instance.Stance == PlayerStance.Default)
				{
					if (activeColorSwitchCoroutine != null)
					{
						if (PlayerAnimator.NormalizedTime(1) < Player.instance.Profile.ColorSwitchInterruptTime)
						{
							return;
						}
						StopCoroutine(activeColorSwitchCoroutine);
					}
					activeColorSwitchCoroutine = StartCoroutine(QuickSwitchCombo(combos, num));
				}
				else
				{
					if (activeColorSwitchCoroutine != null)
					{
						StopCoroutine(activeColorSwitchCoroutine);
					}
					activeColorSwitchCoroutine = StartCoroutine(SwitchCombo(combos, num));
				}
			}
			else
			{
				if (!InputQuery.ButtonDown(ButtonInput.Y))
				{
					return;
				}
				num = (Player.instance.Combo + 1) % combos.Length;
				if (Player.instance.Stance == PlayerStance.Default)
				{
					if (activeColorSwitchCoroutine != null)
					{
						if (PlayerAnimator.NormalizedTime(1) < Player.instance.Profile.ColorSwitchInterruptTime)
						{
							return;
						}
						StopCoroutine(activeColorSwitchCoroutine);
					}
					activeColorSwitchCoroutine = StartCoroutine(QuickSwitchCombo(combos, num));
				}
				else
				{
					if (activeColorSwitchCoroutine != null)
					{
						StopCoroutine(activeColorSwitchCoroutine);
					}
					activeColorSwitchCoroutine = StartCoroutine(SwitchCombo(combos, num));
				}
			}
		}

		private IEnumerator QuickSwitchCombo(Combo[] combos, int targetCombo)
		{
			PlayerProfile profile = Player.instance.Profile;
			Player.instance.Combo = targetCombo;
			Rumble.Instance.Play(0.2f, 0.2f, 0.15f);
			Weapon.UpdateColor(combos[Player.instance.Combo].Color);
			PlayerAnimator.Play(AnimationHashes.Equip, 0f, 1, 0f);
			float elapsed = 0f;
			float startWeight = upperBodyLayerWeight;
			while (elapsed < profile.QuickSwitchFadeInTime)
			{
				elapsed += Time.deltaTime;
				upperBodyLayerWeight = Mathf.Lerp(startWeight, 1f, elapsed / profile.QuickSwitchFadeInTime);
				yield return null;
			}
			upperBodyLayerWeight = 1f;
			while (!PlayerAnimator.Finished(0f, 1))
			{
				if (Player.instance.State == PlayerState.Cutscene)
				{
					upperBodyLayerWeight = 0f;
					activeColorSwitchCoroutine = null;
					yield break;
				}
				if (InputQuery.Movement.magnitude > 0.1f && PlayerAnimator.NormalizedTime(1) >= profile.ColorSwitchMovementInterruptTime)
				{
					break;
				}
				yield return null;
			}
			elapsed = 0f;
			startWeight = upperBodyLayerWeight;
			while (elapsed < profile.QuickSwitchFadeOutTime)
			{
				elapsed += Time.deltaTime;
				upperBodyLayerWeight = Mathf.Lerp(startWeight, 0f, elapsed / profile.QuickSwitchFadeOutTime);
				yield return null;
			}
			upperBodyLayerWeight = 0f;
			activeColorSwitchCoroutine = null;
		}

		private IEnumerator SwitchCombo(Combo[] combos, int targetCombo)
		{
			Player.instance.Stance = PlayerStance.Switch;
			Player.instance.Combo = targetCombo;
			PlayerAnimator.Play(AnimationHashes.Equip);
			Rumble.Instance.Play(0.3f, 0.3f, 0.2f);
			Weapon.UpdateColor(combos[Player.instance.Combo].Color);
			yield return new WaitForEndOfFrame();
			while (!PlayerAnimator.Finished())
			{
				if (Player.instance.State == PlayerState.Cutscene || Player.instance.Stance != PlayerStance.Switch)
				{
					activeColorSwitchCoroutine = null;
					yield break;
				}
				yield return null;
			}
			PlayerAnimator.Play(AnimationHashes.Movement);
			Player.instance.Stance = PlayerStance.Default;
			activeColorSwitchCoroutine = null;
		}

		private IEnumerator FadeOutLayerWeight(float duration)
		{
			float elapsed = 0f;
			float startWeight = upperBodyLayerWeight;
			while (elapsed < duration)
			{
				elapsed += Time.deltaTime;
				upperBodyLayerWeight = Mathf.Lerp(startWeight, 0f, elapsed / duration);
				yield return null;
			}
			upperBodyLayerWeight = 0f;
			activeFadeOutCoroutine = null;
		}

		private void UpdateRotation()
		{
			Vector2 movement = InputQuery.Movement;
			Camera myCamera = Player.instance.MyCamera;
			float num = Player.instance.Profile.RotationSpeed;
			if (Player.instance.Stance == PlayerStance.Attack)
			{
				num *= Player.instance.Profile.ComboRotationControl;
			}
			if (Player.instance.AbsoluteMovement)
			{
				Vector3 vector = myCamera.transform.TransformDirection(Vector3.forward);
				vector.y = 0f;
				vector = vector.normalized;
				Vector3 vector2 = new Vector3(vector.z, 0f, 0f - vector.x);
				Vector3 forward = movement.x * vector2 + movement.y * vector;
				if (forward.magnitude > 0.1f)
				{
					Quaternion b = Quaternion.LookRotation(forward);
					Player.instance.transform.rotation = Quaternion.Lerp(Player.instance.transform.rotation, b, Time.deltaTime * num);
				}
			}
			else
			{
				Quaternion b2 = Quaternion.Euler(0f, myCamera.transform.eulerAngles.y, 0f);
				if (movement.magnitude > 0.1f)
				{
					Player.instance.transform.rotation = Quaternion.Lerp(Player.instance.transform.rotation, b2, Time.deltaTime * num);
				}
			}
		}

		private void UpdateAttack(Combo[] combos)
		{
			Vector2 movement = InputQuery.Movement;
			float interruptTime = Player.instance.Profile.InterruptTime;
			if (InputQuery.ButtonDown(ButtonInput.B))
			{
				if (Player.instance.Stance == PlayerStance.Attack)
				{
					attackQueued = true;
					movementQueued = false;
					return;
				}
				attackQueued = false;
				movementQueued = false;
				ClearHitTimes();
				if (activeColorSwitchCoroutine != null)
				{
					StopCoroutine(activeColorSwitchCoroutine);
					activeColorSwitchCoroutine = null;
				}
				if (activeFadeOutCoroutine != null)
				{
					StopCoroutine(activeFadeOutCoroutine);
				}
				activeFadeOutCoroutine = StartCoroutine(FadeOutLayerWeight(0.1f));
				Player.instance.Stance = PlayerStance.Attack;
			}
			else
			{
				if (Player.instance.Stance != PlayerStance.Attack)
				{
					return;
				}
				if (!(PlayerAnimator.NormalizedTime() > interruptTime) || !attackQueued || Player.instance.Step >= combos[Player.instance.Combo].Steps)
				{
					if (movement.magnitude > 0.1f && !movementQueued)
					{
						movementQueued = true;
					}
					if (PlayerAnimator.Finished(0.05f) || (movementQueued && PlayerAnimator.NormalizedTime() > interruptTime))
					{
						attackQueued = false;
						movementQueued = false;
						ClearHitTimes();
						Player.instance.Stance = PlayerStance.Default;
					}
					UpdateRotation();
					{
						foreach (HitInfo item in Weapon.Instance.UpdateHit())
						{
							Enemy enemy = item.enemy;
							bool flag = false;
							if (!enemyHitTimes.ContainsKey(enemy))
							{
								flag = true;
							}
							else if (Time.time - enemyHitTimes[enemy] >= Player.instance.Profile.HitCooldown)
							{
								flag = true;
							}
							if (flag)
							{
								if (!item.valid)
								{
									enemy.PhaseEffect();
									break;
								}
								enemyHitTimes[enemy] = Time.time;
								if (!Hits.Contains(enemy))
								{
									Hits.Add(enemy);
								}
								Player.instance.Ultimate += 2f;
								enemy.Health--;
								bool flag2 = enemy.Health == 0;
								if ((bool)HitStopManager.Instance)
								{
									HitStopManager.Instance.TriggerHitStop(Player.instance.MyAnimator, enemy.MyAnimator, Player.instance.transform, enemy.transform, flag2);
								}
								SpawnHitParticle(item.hitPosition);
								if (flag2)
								{
									Rumble.Instance.PlayFade(0.5f, 0.5f, 0.35f);
								}
								else
								{
									Rumble.Instance.Play(0.3f, 0.3f, 0.2f);
								}
							}
						}
						return;
					}
				}
				ClearHitTimes();
				if (activeColorSwitchCoroutine != null)
				{
					StopCoroutine(activeColorSwitchCoroutine);
					activeColorSwitchCoroutine = null;
				}
				if (activeFadeOutCoroutine != null)
				{
					StopCoroutine(activeFadeOutCoroutine);
				}
				activeFadeOutCoroutine = StartCoroutine(FadeOutLayerWeight(0.1f));
				Player.instance.Stance = PlayerStance.Attack;
				attackQueued = false;
				movementQueued = false;
			}
		}

		private void SpawnHitParticle(Vector3 position)
		{
			if (!(HitParticle == null))
			{
				Quaternion rotation = Quaternion.LookRotation(position - Player.instance.transform.position);
				rotation.x = 0f;
				rotation.z = 0f;
				ParticleSystem particleSystem = Object.Instantiate(HitParticle, position, rotation);
				particleSystem.Play();
				Object.Destroy(particleSystem.gameObject, particleSystem.main.duration + particleSystem.main.startLifetime.constantMax);
			}
		}

		private void UpdateLayerWeight()
		{
			Player.instance.MyAnimator.SetLayerWeight(1, upperBodyLayerWeight);
		}

		public void ClearHitTimes()
		{
			enemyHitTimes.Clear();
		}
	}
}
