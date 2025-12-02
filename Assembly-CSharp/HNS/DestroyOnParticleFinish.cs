using UnityEngine;

namespace HNS
{
	public class DestroyOnParticleFinish : MonoBehaviour
	{
		public ParticleSystem[] particles;

		public AudioSource audio;

		public bool ChangeColor;

		public bool Enemy;

		[ContextMenu("Find Refs")]
		private void FindRefs()
		{
			particles = GetComponentsInChildren<ParticleSystem>();
			audio = GetComponentInChildren<AudioSource>();
		}

		private void Start()
		{
			if (particles.Length == 0)
			{
				particles = GetComponentsInChildren<ParticleSystem>();
			}
			if (!audio)
			{
				audio = GetComponent<AudioSource>();
			}
			if (!ChangeColor)
			{
				return;
			}
			if (Enemy)
			{
				Enemy componentInParent = GetComponentInParent<Enemy>();
				if (componentInParent != null)
				{
					SetColors(Player.instance.Profile.Combos[componentInParent.Combo].Color);
					return;
				}
			}
			SetColors(Player.instance.Profile.Combos[Player.instance.Combo].Color);
		}

		public void SetColors(Color color)
		{
			ParticleSystem[] array = particles;
			foreach (ParticleSystem obj in array)
			{
				ParticleSystem.MainModule main = obj.main;
				color.a = 1f;
				main.startColor = color;
				obj.Play();
			}
			particles[0].Play();
		}

		private void Update()
		{
			bool flag = true;
			ParticleSystem[] array = particles;
			foreach (ParticleSystem particleSystem in array)
			{
				if (particleSystem != null && particleSystem.IsAlive())
				{
					flag = false;
					break;
				}
			}
			if ((bool)audio && audio.isPlaying)
			{
				flag = false;
			}
			if (flag)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}
}
