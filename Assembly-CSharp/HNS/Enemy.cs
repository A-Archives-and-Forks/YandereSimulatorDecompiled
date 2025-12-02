using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HNS
{
	public class Enemy : MonoBehaviour
	{
		public EnemyProfile Profile;

		[Header("References")]
		public CharacterController MyController;

		public SkinnedMeshRenderer[] MyRenderer;

		public Animator MyAnimator;

		[Space]
		public EnemyAnimator Animator;

		public EnemyBehaviour Behaviour;

		[Space]
		public Transform EyeTarget;

		public GameObject[] RangeEffect;

		public GameObject EyeEffect;

		[Header("Spawn Settings")]
		public float dissolveSpeed = 2f;

		[Header("Runtime Stats")]
		public int maxHealth;

		[SerializeField]
		private int currentHealth;

		[SerializeField]
		private float currentDamage;

		[SerializeField]
		private int spawnedAtWave;

		private int m_combo = -1;

		private bool showHitOverlay;

		private bool showPhaseOverlay;

		[HideInInspector]
		public int AttackAnimation;

		[HideInInspector]
		public int AttackPrepAnimation;

		[HideInInspector]
		public float DamageAmount;

		[HideInInspector]
		public bool IsAttackLocked;

		[HideInInspector]
		public bool IsProvoked;

		public int Combo
		{
			get
			{
				return m_combo;
			}
			set
			{
				m_combo = value;
				SetColor(Player.instance.Profile.Combos[value].Color);
			}
		}

		public int Health
		{
			get
			{
				return currentHealth;
			}
			set
			{
				if (Behaviour.State == EnemyState.Die || Behaviour.State == EnemyState.Ultimate)
				{
					return;
				}
				if (value < currentHealth)
				{
					if ((bool)EnemyCoordinator.Instance)
					{
						EnemyCoordinator.Instance.OnEnemyDamaged(this);
					}
					if (!GetComponent<Succubus>() && !IsAttackLocked && Behaviour.State != EnemyState.Attack && value > 0)
					{
						Behaviour.ChangeState(new Damage(EnemyCoordinator.Instance ? EnemyCoordinator.Instance.attackDistance : 1.25f, this, Player.instance.transform));
					}
					StartCoroutine(ShowHitOverlay(Time.deltaTime));
				}
				currentHealth = value;
				if (value <= 0)
				{
					Behaviour.ChangeState(new Die(this));
				}
			}
		}

		public void Initialize(int health)
		{
			showHitOverlay = false;
			IsAttackLocked = false;
			IsProvoked = false;
			maxHealth = health;
			currentHealth = health;
			currentDamage = DamageAmount;
			if ((bool)WaveManager.Instance)
			{
				spawnedAtWave = WaveManager.Instance.CurrentWave;
			}
			if ((bool)Profile)
			{
				AttackAnimation = UnityEngine.Animator.StringToHash(Profile.Attack);
				AttackPrepAnimation = UnityEngine.Animator.StringToHash(Profile.AttackPreparation);
				StartCoroutine(ManifestEffect());
			}
		}

		private void OnAnimatorMove()
		{
			if ((bool)MyAnimator && (bool)MyController && MyAnimator.enabled)
			{
				if (!MyController.enabled)
				{
					base.transform.position += MyAnimator.deltaPosition;
					base.transform.rotation *= MyAnimator.deltaRotation;
				}
				else if (Profile.Type != EnemyType.Succubus && Behaviour.State != EnemyState.Approach)
				{
					MyController.Move(MyAnimator.deltaPosition);
				}
			}
		}

		public void PhaseEffect()
		{
			StartCoroutine(ShowPhase(Time.deltaTime));
		}

		private IEnumerator ManifestEffect()
		{
			SetDissolve(1f);
			if ((bool)EnemyCoordinator.Instance)
			{
				EnemyCoordinator.Instance.RegisterEnemy(this);
			}
			if (Player.instance.Stance != PlayerStance.Ultimate && Behaviour.State != EnemyState.Ultimate && Behaviour.State != EnemyState.Die && Health > 0)
			{
				Succubus component = GetComponent<Succubus>();
				if ((bool)component)
				{
					Behaviour.ChangeState(new TakeFlight(this, component, Player.instance.transform, Profile.rangedDistance));
				}
				else
				{
					Behaviour.ChangeState(new Pursue(this, Player.instance.transform));
				}
			}
			float dissolveAmount = 1f;
			while (dissolveAmount > 0f)
			{
				dissolveAmount -= Time.deltaTime * dissolveSpeed;
				SetDissolve(dissolveAmount);
				yield return null;
			}
			SetDissolve(0f);
		}

		private IEnumerator ShowHitOverlay(float deltaTime)
		{
			if (showHitOverlay)
			{
				yield break;
			}
			showHitOverlay = true;
			float hitAmount = 0f;
			float speed = 10f;
			SkinnedMeshRenderer[] myRenderer;
			while (hitAmount < 1f)
			{
				hitAmount += Time.deltaTime * speed;
				myRenderer = MyRenderer;
				for (int i = 0; i < myRenderer.Length; i++)
				{
					Material[] materials = myRenderer[i].materials;
					foreach (Material material in materials)
					{
						if ((bool)material)
						{
							material.SetFloat("_HitAmount", hitAmount);
						}
					}
				}
				yield return null;
			}
			hitAmount = 1f;
			myRenderer = MyRenderer;
			for (int i = 0; i < myRenderer.Length; i++)
			{
				Material[] materials = myRenderer[i].materials;
				foreach (Material material2 in materials)
				{
					if ((bool)material2)
					{
						material2.SetFloat("_HitAmount", hitAmount);
					}
				}
			}
			yield return null;
			while (hitAmount > 0f)
			{
				hitAmount -= Time.deltaTime * speed;
				myRenderer = MyRenderer;
				for (int i = 0; i < myRenderer.Length; i++)
				{
					Material[] materials = myRenderer[i].materials;
					foreach (Material material3 in materials)
					{
						if ((bool)material3)
						{
							material3.SetFloat("_HitAmount", hitAmount);
						}
					}
				}
				yield return null;
			}
			hitAmount = 0f;
			myRenderer = MyRenderer;
			for (int i = 0; i < myRenderer.Length; i++)
			{
				Material[] materials = myRenderer[i].materials;
				foreach (Material material4 in materials)
				{
					if ((bool)material4)
					{
						material4.SetFloat("_HitAmount", hitAmount);
					}
				}
			}
			showHitOverlay = false;
		}

		private IEnumerator ShowPhase(float deltaTime)
		{
			if (showPhaseOverlay)
			{
				yield break;
			}
			showPhaseOverlay = true;
			float hitAmount = 0f;
			float speed = 10f;
			SkinnedMeshRenderer[] myRenderer;
			while (hitAmount < 1f)
			{
				hitAmount += Time.deltaTime * speed;
				myRenderer = MyRenderer;
				for (int i = 0; i < myRenderer.Length; i++)
				{
					Material[] materials = myRenderer[i].materials;
					foreach (Material material in materials)
					{
						if ((bool)material)
						{
							material.SetFloat("_PhaseAmount", hitAmount);
						}
					}
				}
				yield return null;
			}
			while (hitAmount > 0f)
			{
				hitAmount -= Time.deltaTime * speed;
				myRenderer = MyRenderer;
				for (int i = 0; i < myRenderer.Length; i++)
				{
					Material[] materials = myRenderer[i].materials;
					foreach (Material material2 in materials)
					{
						if ((bool)material2)
						{
							material2.SetFloat("_PhaseAmount", hitAmount);
						}
					}
				}
				yield return null;
			}
			hitAmount = 0f;
			myRenderer = MyRenderer;
			for (int i = 0; i < myRenderer.Length; i++)
			{
				Material[] materials = myRenderer[i].materials;
				foreach (Material material3 in materials)
				{
					if ((bool)material3)
					{
						material3.SetFloat("_PhaseAmount", hitAmount);
					}
				}
			}
			showPhaseOverlay = false;
		}

		private void SetDissolve(float amount)
		{
			SkinnedMeshRenderer[] myRenderer = MyRenderer;
			for (int i = 0; i < myRenderer.Length; i++)
			{
				Material[] materials = myRenderer[i].materials;
				foreach (Material material in materials)
				{
					if ((bool)material)
					{
						material.SetFloat("_Dissolve_Amount", amount);
					}
				}
			}
		}

		private void SetColor(Color color)
		{
			for (int i = 0; i < MyRenderer.Length; i++)
			{
				Renderer renderer = MyRenderer[i];
				List<Material> list = new List<Material>();
				Material material = renderer.materials[0];
				material.color = color * Mathf.Pow(2f, 5.850773f);
				for (int j = 0; j < renderer.materials.Length; j++)
				{
					list.Add(material);
				}
				renderer.SetMaterials(list);
			}
		}
	}
}
