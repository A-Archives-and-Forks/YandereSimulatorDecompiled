using System;
using System.Collections.Generic;
using UnityEngine;

namespace HNS
{
	[CreateAssetMenu(fileName = "WaveProfile", menuName = "HNS/Wave Profile")]
	public class WaveProfile : ScriptableObject
	{
		[Serializable]
		public class WaveComposition
		{
			[Tooltip("Enemy profile")]
			public EnemyProfile profile;

			[Tooltip("Enemy color")]
			public EnemyColor color;

			[Tooltip("Number of enemies")]
			public int amount = 1;

			[Tooltip("Apply bonus enemies from endless mode")]
			public bool addBonusEnemies = true;
		}

		[Serializable]
		public class SpawnEntry
		{
			public EnemyProfile profile;

			public EnemyColor color;

			public int spawnIndex;

			public int waveNumber;
		}

		[Header("Wave Composition")]
		[Tooltip("Groups of enemy types and colors")]
		public List<WaveComposition> composition = new List<WaveComposition>();

		[Header("Spawn Timing")]
		[Tooltip("Delay between each enemy spawn")]
		public float spawnInterval = 1f;

		[Tooltip("Delay before this wave starts")]
		public float waveStartDelay = 2f;

		public List<SpawnEntry> GenerateSpawnList(int currentWave, int bonusEnemies = 0)
		{
			List<SpawnEntry> list = new List<SpawnEntry>();
			foreach (WaveComposition item in composition)
			{
				int num = item.amount + (item.addBonusEnemies ? bonusEnemies : 0);
				for (int i = 0; i < num; i++)
				{
					list.Add(new SpawnEntry
					{
						profile = item.profile,
						color = item.color,
						waveNumber = currentWave
					});
				}
			}
			return list;
		}
	}
}
