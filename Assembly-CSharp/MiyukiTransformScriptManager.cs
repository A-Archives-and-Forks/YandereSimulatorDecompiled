using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiyukiTransformScriptManager : MonoBehaviour
{
	[Serializable]
	public class MiyukiMaterialChange
	{
		public GameObject SelectedMesh;

		public Material SelectedNewMaterial;
	}

	[Serializable]
	public class MiyukiResetGroup
	{
		[Header("DefaultMat")]
		public Material MiyukiDefaultMaterials;

		[Header("MeshToReset")]
		public GameObject[] MiyukiSelectResetMeshes;
	}

	[Header("GameObjectSelecions")]
	public Camera MiyukiCameraTransform;

	public GameObject MiyukiPhraseAudio;

	public GameObject MiyukiTranformHairAcc;

	public GameObject MiyukiTranformDress;

	public GameObject MiyukiTranformGloves;

	public GameObject MiyukiTranformShoes;

	public GameObject MiyukiTranformChoker;

	public GameObject MiyukiTranformChokerGem;

	public GameObject MiyukiTranformArmsDecoration;

	public GameObject MiyukiFeetMesh;

	public GameObject MiyukiHandMesh;

	public GameObject MiyukiFingerNails;

	public Material MiyukiSkinMaterialBlend;

	public Material SkinMatDefault;

	public GameObject MiyukiArmGloves;

	public GameObject MiyukiSocks;

	public Material MiyukiNailPolish;

	public GameObject MiyukiChestRibbons;

	[Header("HeartSplashHighlights")]
	public Transform HeartSplash;

	public float rotationThreshold = 45f;

	public float smoothRotationDuration = 2f;

	public float smoothRotationSpeed = 10f;

	private float baseRotationX = 90f;

	private float currentRotationX;

	private float targetRotationX;

	private float rotationDirection;

	private float smoothTimeRemaining;

	[Header("BackgroundControllers")]
	public Transform RotatingBackground;

	public float BGRotationSpeed = 30f;

	[Header("RandomShit")]
	public Transform wand;

	public Transform handBone;

	public Transform DefaultParent;

	private Vector3 initialPosition;

	private Quaternion initialRotation;

	public Text frameText;

	private float timer;

	private int currentFrame;

	private const float frameRate = 30f;

	public List<Light> AmbientLights;

	public float fadeSpeed = 1f;

	private bool isFadedOut;

	public bool MiyukiDebugOn;

	public float MiyukiMaterialblendDuration = 5f;

	public MiyukiMaterialChange[] Change;

	[Header("Miyuki Reset Shader & Meshes")]
	public MiyukiResetGroup miyukiResetGroup;

	public ParticleSystem MiyukiHeartsBurstparticle;

	public ParticleSystem MiyukiHairHeartsBurstparticleRight;

	public ParticleSystem MiyukiHairHeartsBurstparticleLeft;

	public ParticleSystem MiyukiBottomHeartsBurstparticle;

	public ParticleSystem WandHighlightParticles;

	public Material THEGREATMATERIALOFBLINDNESS;

	private float fadeDuration = 0.6f;

	private Coroutine activeFade;

	[Header("Particle Systems dos Dedos")]
	[Tooltip("Ordem: Polegar, Indicador, Médio, Anelar, Mínimo")]
	[SerializeField]
	private ParticleSystem thumbParticle;

	[SerializeField]
	private ParticleSystem indexParticle;

	[SerializeField]
	private ParticleSystem middleParticle;

	[SerializeField]
	private ParticleSystem ringParticle;

	[SerializeField]
	private ParticleSystem pinkyParticle;

	public int ParticlesSpawned;

	private void Start()
	{
		currentRotationX = HeartSplash.localEulerAngles.x;
		initialPosition = wand.position;
		initialRotation = wand.rotation;
		RestartMiyukiTransform();
	}

	public void AttachWand()
	{
		wand.SetParent(handBone);
	}

	public void DetachWand()
	{
		wand.SetParent(DefaultParent);
		wand.position = initialPosition;
		wand.rotation = initialRotation;
	}

	private void OnEnable()
	{
		RestartMiyukiTransform();
	}

	public void RotateTo(float offset)
	{
		offset = Mathf.Clamp(offset, 0f - rotationThreshold, rotationThreshold);
		targetRotationX = baseRotationX + offset;
		HeartSplash.localEulerAngles = new Vector3(targetRotationX, 90f, -90f);
		rotationDirection = Mathf.Sign(offset - (currentRotationX - baseRotationX));
		smoothTimeRemaining = smoothRotationDuration;
		currentRotationX = targetRotationX;
	}

	public void RotateToRandom()
	{
		float num = 20f;
		int num2 = 0;
		float num3;
		do
		{
			num3 = UnityEngine.Random.Range(0f - rotationThreshold, rotationThreshold);
			num2++;
		}
		while (Mathf.Abs(num3 - (currentRotationX - baseRotationX)) < num && num2 < 10);
		RotateTo(num3);
	}

	private void Update()
	{
		if (smoothTimeRemaining > 0f)
		{
			float num = rotationDirection * smoothRotationSpeed * Time.deltaTime;
			currentRotationX += num;
			HeartSplash.localEulerAngles = new Vector3(currentRotationX, 90f, -90f);
			smoothTimeRemaining -= Time.deltaTime;
		}
		if (RotatingBackground != null)
		{
			RotatingBackground.Rotate(Vector3.up * BGRotationSpeed * Time.deltaTime);
		}
		if (MiyukiDebugOn)
		{
			if (Input.GetKeyDown(KeyCode.P))
			{
				Time.timeScale = Mathf.Min(Time.timeScale + 0.5f, 5f);
				Debug.Log("TimeScale aumentado: " + Time.timeScale);
			}
			if (Input.GetKeyDown(KeyCode.O))
			{
				Time.timeScale = Mathf.Max(Time.timeScale - 0.5f, 0.1f);
				Debug.Log("TimeScale diminuído: " + Time.timeScale);
			}
			if (Input.GetKeyDown(KeyCode.O))
			{
				Time.timeScale = Mathf.Max(Time.timeScale - 0.5f, 0.1f);
				Debug.Log("TimeScale diminuído: " + Time.timeScale);
			}
			if (Input.GetKeyDown(KeyCode.R))
			{
				Time.timeScale = 1f;
				Debug.Log("TimeScale resetado: " + Time.timeScale);
			}
			timer += Time.deltaTime;
			currentFrame = Mathf.FloorToInt(timer * 30f);
			float num2 = (float)currentFrame / 30f;
			frameText.text = "30fps-Frame: " + currentFrame + "\nTime: " + num2.ToString("F3") + "s";
		}
	}

	private void RestartMiyukiTransform()
	{
		MiyukiPhraseAudio.SetActive(value: false);
		MiyukiTranformHairAcc.SetActive(value: false);
		MiyukiTranformDress.SetActive(value: false);
		MiyukiTranformGloves.SetActive(value: false);
		MiyukiTranformShoes.SetActive(value: false);
		MiyukiTranformChoker.SetActive(value: false);
		MiyukiTranformArmsDecoration.SetActive(value: false);
		MiyukiCameraTransform.orthographic = true;
		MiyukiSkinMaterialBlend.SetFloat("_Blend", 0f);
		MiyukiHandMesh.SetActive(value: true);
		MiyukiFingerNails.SetActive(value: true);
		MiyukiFeetMesh.SetActive(value: true);
		MiyukiNailPolish.SetFloat("_Threshold", 1f);
		MiyukiChestRibbons.SetActive(value: false);
		foreach (Light ambientLight in AmbientLights)
		{
			if (ambientLight != null)
			{
				ambientLight.intensity = 0.42f;
			}
		}
		if (miyukiResetGroup.MiyukiDefaultMaterials == null)
		{
			Debug.LogWarning("No materials were found");
			return;
		}
		GameObject[] miyukiSelectResetMeshes = miyukiResetGroup.MiyukiSelectResetMeshes;
		foreach (GameObject gameObject in miyukiSelectResetMeshes)
		{
			if (gameObject == null)
			{
				Debug.LogWarning("EmptyList/null List");
				continue;
			}
			Renderer component = gameObject.GetComponent<MeshRenderer>();
			if (component == null)
			{
				component = gameObject.GetComponent<SkinnedMeshRenderer>();
			}
			if (component != null)
			{
				component.material = miyukiResetGroup.MiyukiDefaultMaterials;
			}
			else
			{
				Debug.LogWarning("No renderer foun on: " + gameObject.name);
			}
		}
	}

	public void MiyukiChangeCameraType()
	{
		MiyukiCameraTransform.orthographic = false;
	}

	public void MiyukiCatchPhrase()
	{
		MiyukiPhraseAudio.SetActive(value: true);
	}

	public void TriggerMaterialBlend()
	{
		StartCoroutine(BlendOverTime());
	}

	private IEnumerator BlendOverTime()
	{
		float elapsed = 0f;
		while (elapsed < MiyukiMaterialblendDuration)
		{
			elapsed += Time.deltaTime;
			float value = Mathf.Clamp01(elapsed / MiyukiMaterialblendDuration);
			MiyukiSkinMaterialBlend.SetFloat("_Blend", value);
			yield return null;
		}
		MiyukiSkinMaterialBlend.SetFloat("_Blend", 1f);
	}

	public void EnableDress()
	{
		MiyukiTranformDress.SetActive(value: true);
	}

	public void EnalbeGloves()
	{
		MiyukiTranformGloves.SetActive(value: true);
		MiyukiTranformArmsDecoration.SetActive(value: true);
		MiyukiHandMesh.SetActive(value: false);
		MiyukiFingerNails.SetActive(value: false);
		if (MiyukiArmGloves == null || SkinMatDefault == null)
		{
			Debug.LogWarning("MiyukiArmGloves ou material não foram atribuídos.");
			return;
		}
		SkinnedMeshRenderer component = MiyukiArmGloves.GetComponent<SkinnedMeshRenderer>();
		if (component != null)
		{
			component.material = SkinMatDefault;
		}
		else
		{
			Debug.LogWarning("O GameObject não possui um SkinnedMeshRenderer.");
		}
	}

	public void enableChokerGem()
	{
	}

	public void enablechoker()
	{
		MiyukiTranformChoker.SetActive(value: true);
	}

	public void EnableShoes()
	{
		MiyukiFeetMesh.SetActive(value: false);
		MiyukiTranformShoes.SetActive(value: true);
		if (MiyukiSocks == null || SkinMatDefault == null)
		{
			Debug.LogWarning("MiyukiArmGloves ou material não foram atribuídos.");
			return;
		}
		SkinnedMeshRenderer component = MiyukiSocks.GetComponent<SkinnedMeshRenderer>();
		if (component != null)
		{
			component.material = SkinMatDefault;
		}
		else
		{
			Debug.LogWarning("O GameObject não possui um SkinnedMeshRenderer.");
		}
	}

	public void EnableHairAcc()
	{
		MiyukiTranformHairAcc.SetActive(value: true);
	}

	public void ParticleHeartsBust()
	{
		if (MiyukiHeartsBurstparticle != null)
		{
			MiyukiHeartsBurstparticle.Emit(100);
		}
	}

	public void BottomParticleHeartsBust()
	{
		if (MiyukiBottomHeartsBurstparticle != null)
		{
			MiyukiBottomHeartsBurstparticle.Emit(100);
		}
	}

	public void ParticleHairBobblesHeartsBust()
	{
		MiyukiHairHeartsBurstparticleRight.Emit(100);
		MiyukiHairHeartsBurstparticleLeft.Emit(100);
	}

	public void WandHighlightParticle()
	{
		WandHighlightParticles.Play();
	}

	public void ChangeMiyukisMaterials()
	{
		MiyukiMaterialChange[] change = Change;
		foreach (MiyukiMaterialChange miyukiMaterialChange in change)
		{
			Renderer component = miyukiMaterialChange.SelectedMesh.GetComponent<Renderer>();
			if (component != null)
			{
				component.material = miyukiMaterialChange.SelectedNewMaterial;
			}
		}
	}

	public void EnableChestRibbons()
	{
		MiyukiChestRibbons.SetActive(value: true);
	}

	public void ToggleAmbientLight()
	{
		Debug.Log("Animation Event: Toggling ambient lights");
		StopAllCoroutines();
		float target = (isFadedOut ? 0.42f : 0f);
		StartCoroutine(FadeLights(target));
		isFadedOut = !isFadedOut;
	}

	private IEnumerator FadeLights(float target)
	{
		float[] startIntensities = new float[AmbientLights.Count];
		for (int i = 0; i < AmbientLights.Count; i++)
		{
			startIntensities[i] = AmbientLights[i].intensity;
		}
		float t = 0f;
		while (t < 1f)
		{
			t += Time.deltaTime * fadeSpeed;
			for (int j = 0; j < AmbientLights.Count; j++)
			{
				if (AmbientLights[j] != null)
				{
					AmbientLights[j].intensity = Mathf.Lerp(startIntensities[j], target, t);
				}
			}
			yield return null;
		}
		for (int k = 0; k < AmbientLights.Count; k++)
		{
			if (AmbientLights[k] != null)
			{
				AmbientLights[k].intensity = target;
			}
		}
	}

	public void FlashOut()
	{
		if (activeFade != null)
		{
			StopCoroutine(activeFade);
		}
		activeFade = StartCoroutine(FadeShader("_Alpha", 1f, 0f, fadeDuration));
	}

	public void FlashInHoldOut()
	{
		if (activeFade != null)
		{
			StopCoroutine(activeFade);
		}
		activeFade = StartCoroutine(SequenceFade());
	}

	public void OnlyFadeIn()
	{
		if (activeFade != null)
		{
			StopCoroutine(activeFade);
		}
		activeFade = StartCoroutine(FadeShader("_Alpha", 0f, 1f, fadeDuration));
	}

	public void OnlyFadeOut()
	{
		if (activeFade != null)
		{
			StopCoroutine(activeFade);
		}
		activeFade = StartCoroutine(FadeShader("_Alpha", 1f, 0f, fadeDuration));
	}

	private IEnumerator SequenceFade()
	{
		yield return StartCoroutine(FadeShader("_Alpha", 0f, 1f, fadeDuration));
		yield return new WaitForSeconds(0f);
		yield return StartCoroutine(FadeShader("_Alpha", 1f, 0f, fadeDuration));
	}

	private IEnumerator FadeShader(string property, float from, float to, float duration)
	{
		float elapsed = 0f;
		while (elapsed < duration)
		{
			float value = Mathf.Lerp(from, to, elapsed / duration);
			THEGREATMATERIALOFBLINDNESS.SetFloat(property, value);
			elapsed += Time.deltaTime;
			yield return null;
		}
		THEGREATMATERIALOFBLINDNESS.SetFloat(property, to);
	}

	public void TransformOneNailMiyuki()
	{
		if (MiyukiNailPolish == null)
		{
			Debug.LogWarning("Material não atribuído.");
			return;
		}
		float num = MiyukiNailPolish.GetFloat("_Threshold");
		MiyukiNailPolish.SetFloat("_Threshold", num - 0.2f);
	}

	public void SpawnParticleByFinger(int fingerIndex)
	{
		if (ParticlesSpawned < 5)
		{
			ParticlesSpawned++;
			ParticleSystem particleSystemByIndex = GetParticleSystemByIndex(fingerIndex);
			if (particleSystemByIndex == null)
			{
				Debug.LogWarning("Sistema de partículas não encontrado para o dedo de índice: " + fingerIndex);
				return;
			}
			ParticleSystem particleSystem = UnityEngine.Object.Instantiate(particleSystemByIndex, particleSystemByIndex.transform.position, particleSystemByIndex.transform.rotation, particleSystemByIndex.transform.parent);
			particleSystem.gameObject.SetActive(value: true);
			particleSystem.Clear(withChildren: true);
			particleSystem.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
			particleSystem.Emit(1);
			float constant = particleSystem.main.startDelay.constant;
			float constantMax = particleSystem.main.startLifetime.constantMax;
			float duration = particleSystem.main.duration;
			float num = constant + constantMax + duration;
			UnityEngine.Object.Destroy(particleSystem.gameObject, num + 0.2f);
		}
	}

	private ParticleSystem GetParticleSystemByIndex(int index)
	{
		return index switch
		{
			0 => thumbParticle, 
			1 => indexParticle, 
			2 => middleParticle, 
			3 => ringParticle, 
			4 => pinkyParticle, 
			_ => null, 
		};
	}
}
