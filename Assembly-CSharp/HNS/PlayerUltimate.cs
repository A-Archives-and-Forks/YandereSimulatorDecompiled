using System;
using UnityEngine;
using UnityEngine.Playables;

namespace HNS
{
	public class PlayerUltimate : MonoBehaviour
	{
		public static PlayerUltimate instance;

		public Color Default;

		public Color Highlight;

		public UITexture fill;

		public GameObject HUD;

		public GameObject[] ColorVFX;

		public CameraFilterPack_TV_WideScreenHorizontal bars;

		public PlayableDirector ultimateCutscene;

		private float timer;

		private Enemy target;

		private void OnEnable()
		{
			instance = this;
		}

		private void OnDisable()
		{
			instance = null;
		}

		private void Update()
		{
			UpdateUI();
			if (Player.instance.Stance != PlayerStance.Ultimate && Player.instance.Ultimate >= 100f && !Player.instance.AbsoluteMovement)
			{
				UpdateInput();
			}
		}

		private void UpdateInput()
		{
			if (!InputQuery.ButtonDown(ButtonInput.X))
			{
				return;
			}
			TargetLockCameraState state = CameraStateMachine.Instance.GetState<TargetLockCameraState>();
			if (!(state == null) && !(state.CurrentTarget == null))
			{
				TargetLockIndicator currentTarget = state.CurrentTarget;
				if (Vector3.Distance(base.transform.position, currentTarget.transform.position) <= Player.instance.Profile.UltimateActivationRange)
				{
					Player.instance.Stance = PlayerStance.Ultimate;
					bars.enabled = true;
					CameraStateMachine.Instance.IsEnabled = false;
					Player.instance.Combo = currentTarget.enemy.Combo;
					Weapon.UpdateColor(Player.instance.Profile.Combos[Player.instance.Combo].Color);
					target = currentTarget.enemy;
					target.Behaviour.ChangeState(new Ultimate(1.25f, target, Player.instance.transform));
					target.MyController.enabled = false;
					target.transform.position = Player.instance.transform.position + Player.instance.transform.forward * 1.2f;
					Vector3 forward = Player.instance.transform.position - target.transform.position;
					forward.y = 0f;
					Quaternion rotation = Quaternion.LookRotation(forward);
					target.transform.rotation = rotation;
					target.MyAnimator.SetFloat(AnimationHashes.Vertical, 0f);
					target.MyAnimator.SetFloat(AnimationHashes.Horizontal, 0f);
					ColorVFX[Player.instance.Combo].SetActive(value: true);
					target.MyAnimator.Play(AnimationHashes.Ultimate, 0, 0f);
					Player.instance.MyAnimator.SetLayerWeight(1, 0f);
					PlayerAnimator.Play(AnimationHashes.Ultimate, 0f, 0, 0f);
					ultimateCutscene.transform.position = base.transform.position;
					ultimateCutscene.transform.rotation = base.transform.rotation;
					ultimateCutscene.gameObject.SetActive(value: true);
					ultimateCutscene.Play();
					ultimateCutscene.stopped += OnCutsceneComplete;
				}
			}
		}

		private void OnCutsceneComplete(PlayableDirector director)
		{
			if ((bool)target)
			{
				if ((bool)EnemyCoordinator.Instance)
				{
					EnemyCoordinator.Instance.OnEnemyDied(target);
				}
				UnityEngine.Object.Destroy(target.gameObject);
			}
			ColorVFX[Player.instance.Combo].SetActive(value: false);
			director.stopped -= OnCutsceneComplete;
			ultimateCutscene.gameObject.SetActive(value: false);
			Player.instance.Ultimate = 0f;
			CameraStateMachine.Instance.IsEnabled = true;
			bars.enabled = false;
			Player.instance.Stance = PlayerStance.Default;
			Player.instance.MyAnimator.SetLayerWeight(1, 1f);
		}

		private void UpdateUI()
		{
			PlayerProfile profile = Player.instance.Profile;
			fill.fillAmount = Player.instance.Ultimate / 100f;
			if (Player.instance.Ultimate >= 100f)
			{
				timer += Time.deltaTime * MathF.PI * profile.UltimateFlashSpeed;
				if (timer >= MathF.PI * 2f)
				{
					timer -= MathF.PI * 2f;
				}
				fill.color = Color.Lerp(Default, Highlight, 0.5f * Mathf.Sin(timer) + 0.5f);
			}
			else
			{
				timer = 0f;
				fill.color = Color.Lerp(fill.color, Default, Time.deltaTime * profile.UltimateFlashSpeed);
			}
			if (Player.instance.Stance == PlayerStance.Ultimate && HUD.activeInHierarchy)
			{
				HUD.SetActive(value: false);
			}
			else if (Player.instance.Stance != PlayerStance.Ultimate && !HUD.activeInHierarchy)
			{
				HUD.SetActive(value: true);
			}
		}
	}
}
