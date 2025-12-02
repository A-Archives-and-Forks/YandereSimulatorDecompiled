using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HNS
{
	public class WaveManager : MonoBehaviour
	{
		public enum LoopMode
		{
			[Tooltip("Loop back to first wave")]
			Repeat = 0,
			[Tooltip("Play waves forward then backward")]
			PingPong = 1,
			[Tooltip("Pick random wave each time")]
			Random = 2,
			[Tooltip("Endless mode - plays all waves then repeats last with scaling difficulty")]
			Endless = 3
		}

		[Header("References")]
		[Tooltip("Optional spawn effect prefab")]
		public GameObject spawnEffectPrefab;

		[Header("Spawn Layers")]
		[Tooltip("Layers defining spawn point patterns")]
		public List<SpawnLayer> spawnLayers = new List<SpawnLayer>();

		[HideInInspector]
		public Transform[] spawnPoints;

		[Header("Spawn Effect Settings")]
		[Tooltip("Use enemy color for spawn effect")]
		public bool matchEffectColor = true;

		[Tooltip("HDR intensity multiplier for emissive colors")]
		public float hdrIntensity = 1f;

		[Header("Wave Configuration")]
		[Tooltip("Ordered list of waves")]
		public List<WaveProfile> waves = new List<WaveProfile>();

		[Tooltip("Behavior when all waves are complete")]
		public LoopMode loopMode = LoopMode.Endless;

		[Header("Endless Mode")]
		[Tooltip("Bonus enemies added per endless wave")]
		public int endlessBonusEnemies = 1;

		[Header("Enemy Limits")]
		[Tooltip("Maximum number of each color variant of Succubus allowed alive at once")]
		public int maxSuccubusPerColor = 1;

		[Header("Runtime Info")]
		[SerializeField]
		private int currentWaveIndex = -1;

		[SerializeField]
		private int enemiesAlive;

		[SerializeField]
		private bool waveInProgress;

		public UILabel Label;

		private List<Enemy> activeEnemies = new List<Enemy>();

		private Coroutine waveCoroutine;

		private int direction = 1;

		private int totalWavesCompleted;

		private List<Vector3> cachedSpawnPositions = new List<Vector3>();

		private List<Quaternion> cachedSpawnRotations = new List<Quaternion>();

		public static WaveManager Instance { get; private set; }

		public List<Enemy> ActiveEnemies => activeEnemies;

		public int CurrentWave => totalWavesCompleted + 1;

		private void OnEnable()
		{
			Instance = this;
		}

		private void OnDisable()
		{
			if (Instance == this)
			{
				Instance = null;
			}
		}

		private void Start()
		{
			RegenerateSpawnPoints();
			StartNextWave();
		}

		public void RegenerateSpawnPoints()
		{
			cachedSpawnPositions.Clear();
			cachedSpawnRotations.Clear();
			foreach (SpawnLayer spawnLayer in spawnLayers)
			{
				if (spawnLayer.enabled)
				{
					List<Vector3> list = spawnLayer.GeneratePositions();
					List<Quaternion> collection = spawnLayer.GenerateRotations(list);
					cachedSpawnPositions.AddRange(list);
					cachedSpawnRotations.AddRange(collection);
				}
			}
		}

		private void Update()
		{
			if ((bool)Label)
			{
				Label.text = "Wave #" + CurrentWave;
			}
			activeEnemies.RemoveAll((Enemy e) => e == null);
			enemiesAlive = activeEnemies.Count;
			if (waveInProgress && enemiesAlive == 0 && waveCoroutine == null)
			{
				CompleteWave();
				StartNextWave();
			}
		}

		private void CompleteWave()
		{
			totalWavesCompleted++;
			if ((bool)PlayerHealth.instance)
			{
				PlayerHealth.instance.AddWaveComplete();
			}
		}

		public void StartNextWave()
		{
			if (waveCoroutine != null)
			{
				StopCoroutine(waveCoroutine);
			}
			waveCoroutine = StartCoroutine(SpawnWave());
		}

		private IEnumerator SpawnWave()
		{
			currentWaveIndex += direction;
			if (!Announcement.Active)
			{
				Announcement.Show("WAVE " + CurrentWave);
			}
			WaveProfile wave = GetWaveProfile();
			if (wave == null)
			{
				yield break;
			}
			yield return new WaitForSeconds(wave.waveStartDelay);
			int bonusEnemies = 0;
			if (totalWavesCompleted >= waves.Count)
			{
				bonusEnemies = (totalWavesCompleted - waves.Count + 1) * endlessBonusEnemies;
			}
			List<WaveProfile.SpawnEntry> list = wave.GenerateSpawnList(CurrentWave, bonusEnemies);
			DistributeEnemiesAcrossSpawnPoints(list);
			waveInProgress = true;
			foreach (WaveProfile.SpawnEntry item in list)
			{
				if (!IsSuccubus(item) || GetActiveSuccubusCountByColor((int)item.color) < maxSuccubusPerColor)
				{
					SpawnEnemy(item);
					yield return new WaitForSeconds(wave.spawnInterval);
				}
			}
			waveCoroutine = null;
		}

		private WaveProfile GetWaveProfile()
		{
			if (waves.Count == 0)
			{
				return null;
			}
			if (currentWaveIndex >= 0 && currentWaveIndex < waves.Count)
			{
				return waves[currentWaveIndex];
			}
			return loopMode switch
			{
				LoopMode.Repeat => HandleRepeat(), 
				LoopMode.PingPong => HandlePingPong(), 
				LoopMode.Random => HandleRandom(), 
				LoopMode.Endless => HandleEndless(), 
				_ => waves[waves.Count - 1], 
			};
		}

		private WaveProfile HandleRepeat()
		{
			currentWaveIndex = 0;
			direction = 1;
			return waves[0];
		}

		private WaveProfile HandlePingPong()
		{
			if (currentWaveIndex >= waves.Count)
			{
				currentWaveIndex = waves.Count - 2;
				direction = -1;
			}
			else if (currentWaveIndex < 0)
			{
				currentWaveIndex = 1;
				direction = 1;
			}
			currentWaveIndex = Mathf.Clamp(currentWaveIndex, 0, waves.Count - 1);
			return waves[currentWaveIndex];
		}

		private WaveProfile HandleRandom()
		{
			currentWaveIndex = Random.Range(0, waves.Count);
			return waves[currentWaveIndex];
		}

		private WaveProfile HandleEndless()
		{
			currentWaveIndex = waves.Count - 1;
			return waves[currentWaveIndex];
		}

		private void DistributeEnemiesAcrossSpawnPoints(List<WaveProfile.SpawnEntry> spawnList)
		{
			if (cachedSpawnPositions.Count != 0)
			{
				int num = cachedSpawnPositions.Count / 2;
				for (int i = 0; i < spawnList.Count; i++)
				{
					int spawnIndex = ((i % 2 != 0) ? ((i / 2 + num) % cachedSpawnPositions.Count) : (i / 2 % cachedSpawnPositions.Count));
					spawnList[i].spawnIndex = spawnIndex;
				}
			}
		}

		private bool IsSuccubus(WaveProfile.SpawnEntry entry)
		{
			return entry.profile.Type == EnemyType.Succubus;
		}

		private int GetActiveSuccubusCountByColor(int comboColor)
		{
			return activeEnemies.Count((Enemy e) => e != null && e.Profile.Type == EnemyType.Succubus && e.Combo == comboColor);
		}

		private void SpawnEnemy(WaveProfile.SpawnEntry entry)
		{
			Vector3 vector = cachedSpawnPositions[entry.spawnIndex];
			Quaternion rotation = cachedSpawnRotations[entry.spawnIndex];
			Vector3 position = vector;
			if (Player.instance != null && Player.instance.transform != null)
			{
				Vector3 position2 = Player.instance.transform.position;
				position = new Vector3(vector.x + position2.x, vector.y, vector.z + position2.z);
			}
			if ((bool)spawnEffectPrefab)
			{
				SpawnEffect(position, entry);
			}
			Enemy component = Object.Instantiate(entry.profile.Prefab, position, rotation, base.transform).GetComponent<Enemy>();
			component.Profile = entry.profile;
			component.Combo = (int)entry.color;
			int health = entry.profile.CalculateHealth(entry.waveNumber);
			float damageAmount = entry.profile.CalculateDamage(entry.waveNumber);
			component.DamageAmount = damageAmount;
			component.Initialize(health);
			if (IsSuccubus(entry))
			{
				int num = activeEnemies.Count((Enemy e) => e != null && e.Profile.Type == EnemyType.Succubus);
				Succubus component2 = component.GetComponent<Succubus>();
				if (component2 != null && num == 0)
				{
					component2.attackCycle = 0;
				}
				else if (component2 != null)
				{
					component2.attackCycle = 1;
				}
			}
			activeEnemies.Add(component);
		}

		private void SpawnEffect(Vector3 position, WaveProfile.SpawnEntry entry)
		{
			GameObject effect = Object.Instantiate(spawnEffectPrefab, position, spawnEffectPrefab.transform.rotation);
			if (matchEffectColor && (bool)Player.instance && (bool)Player.instance.Profile)
			{
				Color color = Player.instance.Profile.Combos[(int)entry.color].Color;
				ApplyColorToEffect(effect, color);
			}
		}

		private void ApplyColorToEffect(GameObject effect, Color color)
		{
			Color color2 = color * Mathf.Pow(2f, hdrIntensity);
			ParticleSystem[] componentsInChildren = effect.GetComponentsInChildren<ParticleSystem>();
			foreach (ParticleSystem particleSystem in componentsInChildren)
			{
				ParticleSystem.MainModule main = particleSystem.main;
				main.startColor = new ParticleSystem.MinMaxGradient(new Color(color2.r, color2.g, color2.b, particleSystem.main.startColor.color.a));
			}
		}

		public bool CanKillEnemy(Enemy enemy, int comboStreak)
		{
			if (comboStreak < 0 || comboStreak > 4)
			{
				return false;
			}
			return enemy.Combo == comboStreak;
		}

		[ContextMenu("Debug: Kill All Enemies")]
		public void DebugKillAllEnemies()
		{
			foreach (Enemy activeEnemy in activeEnemies)
			{
				if (activeEnemy != null)
				{
					activeEnemy.Health = 0;
				}
			}
		}
	}
}
