using System;
using System.Collections.Generic;
using UnityEngine;

namespace HNS
{
	[Serializable]
	public class SpawnLayer
	{
		public string name = "New Layer";

		public bool enabled = true;

		public SpawnPatternType patternType;

		public Vector3 offset = Vector3.zero;

		public float rotationOffset;

		[Header("Circle Settings")]
		public int circleCount = 8;

		public float circleRadius = 10f;

		public float circleStartAngle;

		public float circleArcAngle = 360f;

		[Header("Line Settings")]
		public int lineCount = 5;

		public float lineSpacing = 3f;

		public Vector3 lineDirection = Vector3.right;

		[Header("Grid Settings")]
		public int gridRows = 3;

		public int gridColumns = 3;

		public float gridSpacing = 3f;

		[Header("Arc Settings")]
		public int arcCount = 8;

		public float arcRadius = 10f;

		public float arcStartAngle = -90f;

		public float arcEndAngle = 90f;

		[Header("Spiral Settings")]
		public int spiralCount = 20;

		public float spiralStartRadius = 5f;

		public float spiralEndRadius = 15f;

		public float spiralRotations = 2f;

		[Header("Ring Settings")]
		public int ringCount = 3;

		public int pointsPerRing = 8;

		public float ringStartRadius = 5f;

		public float ringRadiusStep = 5f;

		[Header("Random Settings")]
		public int randomCount = 10;

		public float randomRadius = 10f;

		public int randomSeed;

		[Header("Noise Settings")]
		public bool applyNoise;

		public float noiseStrength = 1f;

		public float noiseScale = 1f;

		public int noiseSeed;

		[Header("Direction Settings")]
		public DirectionMode directionMode;

		public Vector3 customDirection = Vector3.forward;

		public List<Vector3> GeneratePositions()
		{
			if (!enabled)
			{
				return new List<Vector3>();
			}
			List<Vector3> list = patternType switch
			{
				SpawnPatternType.Circle => GenerateCircle(), 
				SpawnPatternType.Line => GenerateLine(), 
				SpawnPatternType.Grid => GenerateGrid(), 
				SpawnPatternType.Arc => GenerateArc(), 
				SpawnPatternType.Spiral => GenerateSpiral(), 
				SpawnPatternType.Ring => GenerateRing(), 
				SpawnPatternType.Random => GenerateRandom(), 
				_ => new List<Vector3>(), 
			};
			if (applyNoise)
			{
				ApplyNoiseToPositions(list);
			}
			for (int i = 0; i < list.Count; i++)
			{
				list[i] += offset;
			}
			return list;
		}

		public List<Quaternion> GenerateRotations(List<Vector3> positions)
		{
			List<Quaternion> list = new List<Quaternion>();
			foreach (Vector3 position in positions)
			{
				Quaternion item = directionMode switch
				{
					DirectionMode.FaceCenter => Quaternion.LookRotation(-(position - offset).normalized, Vector3.up), 
					DirectionMode.FaceAway => Quaternion.LookRotation((position - offset).normalized, Vector3.up), 
					DirectionMode.FaceForward => Quaternion.LookRotation(Vector3.forward, Vector3.up), 
					DirectionMode.Custom => Quaternion.LookRotation(customDirection, Vector3.up), 
					_ => Quaternion.identity, 
				};
				item *= Quaternion.Euler(0f, rotationOffset, 0f);
				list.Add(item);
			}
			return list;
		}

		private List<Vector3> GenerateCircle()
		{
			List<Vector3> list = new List<Vector3>();
			for (int i = 0; i < circleCount; i++)
			{
				float num = (float)i / (float)circleCount;
				float f = (circleStartAngle + num * circleArcAngle) * (MathF.PI / 180f);
				Vector3 item = new Vector3(Mathf.Cos(f) * circleRadius, 0f, Mathf.Sin(f) * circleRadius);
				list.Add(item);
			}
			return list;
		}

		private List<Vector3> GenerateLine()
		{
			List<Vector3> list = new List<Vector3>();
			float num = (float)(-(lineCount - 1)) * lineSpacing * 0.5f;
			for (int i = 0; i < lineCount; i++)
			{
				Vector3 item = lineDirection.normalized * (num + (float)i * lineSpacing);
				list.Add(item);
			}
			return list;
		}

		private List<Vector3> GenerateGrid()
		{
			List<Vector3> list = new List<Vector3>();
			float num = (float)(-(gridColumns - 1)) * gridSpacing * 0.5f;
			float num2 = (float)(-(gridRows - 1)) * gridSpacing * 0.5f;
			for (int i = 0; i < gridRows; i++)
			{
				for (int j = 0; j < gridColumns; j++)
				{
					Vector3 item = new Vector3(num + (float)j * gridSpacing, 0f, num2 + (float)i * gridSpacing);
					list.Add(item);
				}
			}
			return list;
		}

		private List<Vector3> GenerateArc()
		{
			List<Vector3> list = new List<Vector3>();
			for (int i = 0; i < arcCount; i++)
			{
				float t = (float)i / (float)(arcCount - 1);
				float f = Mathf.Lerp(arcStartAngle, arcEndAngle, t) * (MathF.PI / 180f);
				Vector3 item = new Vector3(Mathf.Cos(f) * arcRadius, 0f, Mathf.Sin(f) * arcRadius);
				list.Add(item);
			}
			return list;
		}

		private List<Vector3> GenerateSpiral()
		{
			List<Vector3> list = new List<Vector3>();
			for (int i = 0; i < spiralCount; i++)
			{
				float num = (float)i / (float)(spiralCount - 1);
				float num2 = Mathf.Lerp(spiralStartRadius, spiralEndRadius, num);
				float f = num * spiralRotations * 360f * (MathF.PI / 180f);
				Vector3 item = new Vector3(Mathf.Cos(f) * num2, 0f, Mathf.Sin(f) * num2);
				list.Add(item);
			}
			return list;
		}

		private List<Vector3> GenerateRing()
		{
			List<Vector3> list = new List<Vector3>();
			for (int i = 0; i < ringCount; i++)
			{
				float num = ringStartRadius + (float)i * ringRadiusStep;
				for (int j = 0; j < pointsPerRing; j++)
				{
					float f = 360f / (float)pointsPerRing * (float)j * (MathF.PI / 180f);
					Vector3 item = new Vector3(Mathf.Cos(f) * num, 0f, Mathf.Sin(f) * num);
					list.Add(item);
				}
			}
			return list;
		}

		private List<Vector3> GenerateRandom()
		{
			List<Vector3> list = new List<Vector3>();
			UnityEngine.Random.State state = UnityEngine.Random.state;
			UnityEngine.Random.InitState(randomSeed);
			for (int i = 0; i < randomCount; i++)
			{
				Vector2 vector = UnityEngine.Random.insideUnitCircle * randomRadius;
				Vector3 item = new Vector3(vector.x, 0f, vector.y);
				list.Add(item);
			}
			UnityEngine.Random.state = state;
			return list;
		}

		private void ApplyNoiseToPositions(List<Vector3> positions)
		{
			for (int i = 0; i < positions.Count; i++)
			{
				Vector3 value = positions[i];
				float num = Mathf.PerlinNoise((value.x + (float)noiseSeed) * noiseScale, (value.z + (float)noiseSeed) * noiseScale);
				float num2 = Mathf.PerlinNoise((value.z + (float)noiseSeed + 100f) * noiseScale, (value.x + (float)noiseSeed + 100f) * noiseScale);
				value.x += (num - 0.5f) * 2f * noiseStrength;
				value.z += (num2 - 0.5f) * 2f * noiseStrength;
				positions[i] = value;
			}
		}
	}
}
