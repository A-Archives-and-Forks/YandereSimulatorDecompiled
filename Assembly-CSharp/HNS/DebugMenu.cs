using UnityEngine;

namespace HNS
{
	public class DebugMenu : MonoBehaviour
	{
		public static DebugMenu instance;

		private const int TITLE = 0;

		public UIPanel Panel;

		public UILabel[] Labels;

		public Transform Selector;

		public bool Debug;

		public string[] Properties;

		public string[] Values;

		public int Selection = 1;

		public bool Hidden = true;

		public bool showCollisionRadius;

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
			Values[1] = ((Time.timeScale == 1f) ? "Off" : "On");
			Values[2] = Player.instance.Health.ToString("F2");
			Values[3] = Player.instance.Profile.HealthRegenRate.ToString("F2");
			Values[4] = Player.instance.Profile.StaminaPauseDuration.ToString("F2");
			Values[5] = Player.instance.Profile.StaminaRegenRate.ToString("F2");
			Values[6] = Player.instance.MyAnimator.GetFloat("AttackSpeed").ToString("F2");
			Values[7] = Player.instance.Profile.InterruptTime.ToString("F2");
			Values[8] = Player.instance.Profile.CollisionRadius.ToString("F2");
			Values[9] = Player.instance.Profile.HitCooldown.ToString("F2");
			Values[10] = (showCollisionRadius ? "On" : "Off");
			Selector.gameObject.SetActive(value: false);
			Selector.gameObject.SetActive(value: true);
			UpdateText();
		}

		private void Update()
		{
			if (Debug)
			{
				if (Input.GetKeyDown(KeyCode.F1))
				{
					Time.timeScale = ((Time.timeScale == 1f) ? 0.1f : 1f);
				}
				if (Input.GetKeyDown(KeyCode.F2))
				{
					WaveManager.Instance.DebugKillAllEnemies();
				}
				if (Input.GetKeyDown(KeyCode.F3))
				{
					Player.instance.Health = 0f;
				}
				if (Input.GetKeyDown(KeyCode.F12))
				{
					Hidden = !Hidden;
				}
				Panel.alpha = ((!Hidden) ? 1 : 0);
				if (!Hidden)
				{
					UpdateInput();
				}
			}
		}

		private void UpdateInput()
		{
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				Selection++;
			}
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				Selection--;
			}
			Selection = Mathf.Clamp(Selection, 1, maximumLabels());
			Selector.position = new Vector3(Selector.position.x, Labels[Selection].transform.position.y, Selector.position.z);
			if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
			{
				bool keyDown = Input.GetKeyDown(KeyCode.RightArrow);
				UpdateValues(keyDown);
			}
		}

		private int maximumLabels()
		{
			int num = 1;
			for (int i = 1; i < Properties.Length; i++)
			{
				if (Properties[i].Length > 0)
				{
					num++;
				}
			}
			return num;
		}

		private void UpdateText()
		{
			for (int i = 1; i < Labels.Length; i++)
			{
				if (i >= maximumLabels())
				{
					Labels[i].text = "";
				}
				else
				{
					Labels[i].text = Properties[i] + " : " + Values[i];
				}
			}
		}

		private void UpdateValues(bool increment)
		{
			switch (Selection)
			{
			case 1:
				Time.timeScale = ((Time.timeScale == 1f) ? 0.1f : 1f);
				Values[1] = ((Time.timeScale == 1f) ? "Off" : "On");
				break;
			case 2:
				if (increment)
				{
					Player.instance.Health += 10f;
				}
				else
				{
					Player.instance.Health -= 10f;
				}
				Values[2] = Player.instance.Health.ToString("F2");
				break;
			case 3:
				if (increment)
				{
					Player.instance.Profile.HealthRegenRate += 0.05f;
				}
				else
				{
					Player.instance.Profile.HealthRegenRate -= 0.05f;
				}
				Values[3] = Player.instance.Profile.HealthRegenRate.ToString("F2");
				break;
			case 4:
				if (increment)
				{
					Player.instance.Profile.StaminaPauseDuration += 0.05f;
				}
				else
				{
					Player.instance.Profile.StaminaPauseDuration -= 0.05f;
				}
				Values[4] = Player.instance.Profile.StaminaPauseDuration.ToString("F2");
				break;
			case 5:
				if (increment)
				{
					Player.instance.Profile.StaminaRegenRate += 0.05f;
				}
				else
				{
					Player.instance.Profile.StaminaRegenRate -= 0.05f;
				}
				Values[5] = Player.instance.Profile.StaminaRegenRate.ToString("F2");
				break;
			case 6:
				if (increment)
				{
					Player.instance.MyAnimator.SetFloat("AttackSpeed", Player.instance.MyAnimator.GetFloat("AttackSpeed") + 0.05f);
				}
				else
				{
					Player.instance.MyAnimator.SetFloat("AttackSpeed", Player.instance.MyAnimator.GetFloat("AttackSpeed") - 0.05f);
				}
				Values[6] = Player.instance.MyAnimator.GetFloat("AttackSpeed").ToString("F2");
				break;
			case 7:
				Player.instance.Profile.InterruptTime += (increment ? 0.05f : (-0.05f));
				Player.instance.Profile.InterruptTime = Mathf.Clamp(Player.instance.Profile.InterruptTime, 0f, 1f);
				Values[7] = Player.instance.Profile.InterruptTime.ToString("F2");
				break;
			case 8:
				Player.instance.Profile.CollisionRadius += (increment ? 0.01f : (-0.01f));
				Values[8] = Player.instance.Profile.CollisionRadius.ToString("F2");
				break;
			case 9:
				Player.instance.Profile.HitCooldown += (increment ? 0.05f : (-0.05f));
				Values[9] = Player.instance.Profile.HitCooldown.ToString("F2");
				break;
			case 10:
				showCollisionRadius = !showCollisionRadius;
				Values[10] = (showCollisionRadius ? "On" : "Off");
				break;
			}
			UpdateText();
		}
	}
}
