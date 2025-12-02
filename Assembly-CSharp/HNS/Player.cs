using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

namespace HNS
{
	public class Player : MonoBehaviour
	{
		public static Player instance;

		public PlayerProfile Profile;

		[Header("Settings")]
		public PlayerState State;

		private PlayerStance m_stance;

		public bool AbsoluteMovement = true;

		[Header("References")]
		public CharacterController MyController;

		public Animator MyAnimator;

		public Camera MyCamera;

		public CinemachineImpulseSource ImpulseSource;

		[Header("Runtime")]
		public bool Invincible;

		private int m_combo;

		private int m_step;

		private float m_stamina = 100f;

		private float m_health = 100f;

		private float m_ultimate;

		private bool ultimateNotification;

		public float StaminaPause;

		public float HealthPause;

		public PlayerStance stance;

		public int Combo
		{
			get
			{
				return m_combo;
			}
			set
			{
				m_combo = Mathf.Clamp(value, 0, Profile.Combos.Length - 1);
				m_step = 0;
			}
		}

		public PlayerStance Stance
		{
			get
			{
				return m_stance;
			}
			set
			{
				m_stance = value;
				if (m_stance != PlayerStance.Attack)
				{
					instance.Step = 0;
				}
				switch (m_stance)
				{
				case PlayerStance.Default:
					PlayerAnimator.Play(AnimationHashes.Movement);
					break;
				case PlayerStance.Attack:
				{
					Combo combo = instance.Profile.Combos[instance.Combo];
					int count = AnimationHashes.Combo[instance.Combo].Count;
					if (instance.Step >= count)
					{
						instance.Step = 0;
					}
					PlayerAnimator.Play(AnimationHashes.Combo[instance.Combo][instance.Step]);
					if (instance.Step < combo.Steps)
					{
						instance.Step++;
					}
					else
					{
						m_stance = PlayerStance.Default;
					}
					break;
				}
				case PlayerStance.Dodge:
					instance.Stamina -= Profile.StaminaCost;
					instance.StaminaPause = Profile.StaminaPauseDuration;
					PlayerAnimator.Play(AnimationHashes.Dodge);
					break;
				case PlayerStance.Hit:
					PlayerAnimator.Play(AnimationHashes.Damage, 0f, 0, 0.2f);
					break;
				}
			}
		}

		public int Step
		{
			get
			{
				return m_step;
			}
			set
			{
				if (value < 0)
				{
					m_step = 0;
				}
				else
				{
					int steps = Profile.Combos[m_combo].Steps;
					m_step = Mathf.Min(value, steps);
				}
				PlayerCombo.instance.hasHit = false;
				PlayerCombo.instance.Hits.Clear();
			}
		}

		public float Stamina
		{
			get
			{
				return m_stamina;
			}
			set
			{
				if (StaminaPause <= 0f || m_stamina > value)
				{
					m_stamina = Mathf.Clamp(value, 0f, 100f);
				}
			}
		}

		public float Health
		{
			get
			{
				return m_health;
			}
			set
			{
				if (Invincible)
				{
					return;
				}
				if (value < m_health)
				{
					if (Stance == PlayerStance.Dodge || Stance == PlayerStance.Ultimate || Stance == PlayerStance.Hit)
					{
						return;
					}
					ImpulseSource.GenerateImpulse(0.5f);
					PlayerHit.Instance.Trigger();
				}
				if (HealthPause <= 0f || m_health > value)
				{
					m_health = Mathf.Clamp(value, 0f, 100f);
				}
			}
		}

		public float Ultimate
		{
			get
			{
				return m_ultimate;
			}
			set
			{
				if (value >= 100f && !ultimateNotification)
				{
					Rumble.Instance.PlayPulse(1f, 1f, 0.1f, 0.1f, 0.5f);
					ultimateNotification = true;
				}
				else if (value < 100f && ultimateNotification)
				{
					ultimateNotification = false;
				}
				m_ultimate = Mathf.Clamp(value, 0f, 100f);
			}
		}

		private void OnEnable()
		{
			instance = this;
			ultimateNotification = false;
			MyAnimator.SetFloat(AnimationHashes.Horizontal, 0f);
			MyAnimator.SetFloat(AnimationHashes.Vertical, 0f);
			AnimationHashes.Combo.Clear();
			Combo[] combos = Profile.Combos;
			for (int i = 0; i < combos.Length; i++)
			{
				Combo combo = combos[i];
				List<int> list = new List<int>();
				for (int j = 0; j < combo.Steps; j++)
				{
					list.Add(Animator.StringToHash(combo.Name + (j + 1)));
				}
				AnimationHashes.Combo.Add(list);
			}
			m_combo = Mathf.Clamp(m_combo, 0, Profile.Combos.Length - 1);
			m_step = 0;
		}

		private void Update()
		{
			stance = Stance;
		}

		private void OnDisable()
		{
			instance = null;
		}
	}
}
