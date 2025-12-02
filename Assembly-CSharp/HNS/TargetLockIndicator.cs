using System;
using UnityEngine;

namespace HNS
{
	public class TargetLockIndicator : MonoBehaviour
	{
		[Header("References")]
		public Transform head;

		public Enemy enemy;

		[Header("Indicator Settings")]
		public Transform verticalRef;

		public Transform indicator;

		public MeshRenderer indicatorRenderer;

		public MeshFilter indicatorFilter;

		[Tooltip("Vertical offset above head")]
		public float heightOffset = 0.35f;

		[Tooltip("Bounce animation amplitude")]
		public float bounceAmplitude = 0.03f;

		[Tooltip("Bounce animation speed")]
		public float bounceSpeed = 4f;

		[Tooltip("Rotation speed in degrees per second")]
		public float rotationSpeed = 100f;

		[Tooltip("Fade in/out speed")]
		public float fadeSpeed = 10f;

		private float opacity;

		private float bounceTimer;

		private MaterialPropertyBlock propertyBlock;

		private Color originalColor = Color.white;

		private bool isInitialized;

		private static readonly int HealthProperty = Shader.PropertyToID("_Health");

		private static readonly int ColorProperty = Shader.PropertyToID("_Color");

		private void Start()
		{
			Initialize();
		}

		private void Initialize()
		{
			if (!indicator || !indicatorRenderer)
			{
				isInitialized = false;
				return;
			}
			if (propertyBlock == null)
			{
				propertyBlock = new MaterialPropertyBlock();
			}
			if (indicatorRenderer.sharedMaterial != null && indicatorRenderer.sharedMaterial.HasProperty(ColorProperty))
			{
				originalColor = indicatorRenderer.sharedMaterial.GetColor(ColorProperty);
			}
			else
			{
				originalColor = Color.white;
			}
			isInitialized = true;
		}

		private void Update()
		{
			if (!isInitialized || propertyBlock == null)
			{
				Initialize();
			}
			else if (Player.instance.Stance == PlayerStance.Ultimate)
			{
				opacity = 0f;
				propertyBlock.SetColor(ColorProperty, new Color(originalColor.r, originalColor.g, originalColor.b, opacity));
				indicatorRenderer.SetPropertyBlock(propertyBlock);
			}
			else if ((bool)CameraStateMachine.Instance && (bool)indicatorRenderer)
			{
				bool isTargeted = IsCurrentTarget();
				UpdateBounce();
				UpdateOpacity(isTargeted);
				UpdatePosition();
				UpdateRotation();
				UpdateHealthDisplay();
			}
		}

		private bool IsCurrentTarget()
		{
			TargetLockCameraState state = CameraStateMachine.Instance.GetState<TargetLockCameraState>();
			if (state == null)
			{
				return false;
			}
			if (state.CurrentTarget == null)
			{
				return false;
			}
			return state.CurrentTarget.gameObject == base.gameObject;
		}

		private void UpdateBounce()
		{
			bounceTimer += Time.deltaTime * bounceSpeed;
			if (bounceTimer >= MathF.PI * 2f)
			{
				bounceTimer = 0f;
			}
		}

		private void UpdateOpacity(bool isTargeted)
		{
			if (propertyBlock != null)
			{
				opacity = Mathf.Lerp(opacity, isTargeted ? 1f : 0f, Time.deltaTime * fadeSpeed);
				propertyBlock.SetColor(ColorProperty, new Color(originalColor.r, originalColor.g, originalColor.b, opacity));
				indicatorRenderer.SetPropertyBlock(propertyBlock);
			}
		}

		private void UpdatePosition()
		{
			if ((bool)verticalRef)
			{
				base.transform.position = new Vector3(base.transform.position.x, verticalRef.position.y, base.transform.position.z);
			}
			if ((bool)head && (bool)indicator)
			{
				float num = Mathf.Sin(bounceTimer) * bounceAmplitude;
				indicator.position = head.position + Vector3.up * (heightOffset + num);
			}
		}

		private void UpdateRotation()
		{
			if ((bool)indicator)
			{
				indicator.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
			}
		}

		private void UpdateHealthDisplay()
		{
			if ((bool)enemy && (bool)indicatorRenderer && propertyBlock != null)
			{
				propertyBlock.SetFloat(HealthProperty, (float)enemy.Health / (float)enemy.maxHealth);
				indicatorRenderer.SetPropertyBlock(propertyBlock);
			}
		}

		public Vector3 GetLockPoint()
		{
			return base.transform.position;
		}
	}
}
