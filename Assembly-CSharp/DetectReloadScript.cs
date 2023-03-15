using UnityEngine;
using UnityEngine.PostProcessing;

public class DetectReloadScript : MonoBehaviour
{
	public PostProcessingProfile Profile;

	public bool ResetSettings;

	private void Start()
	{
		Object.DontDestroyOnLoad(base.gameObject);
		ResetPostProcessingSettings();
	}

	private void OnBeforeAssemblyReload()
	{
	}

	private void OnAfterAssemblyReload()
	{
		ResetSettings = true;
	}

	private void ResetPostProcessingSettings()
	{
		Debug.Log("Post processing settings were just reset from this place in the code.");
		Profile.fog.enabled = OptionGlobals.Fog;
		Profile.antialiasing.enabled = !OptionGlobals.DisablePostAliasing;
		Profile.ambientOcclusion.enabled = !OptionGlobals.DisableObscurance;
		Profile.depthOfField.enabled = OptionGlobals.DepthOfField;
		Profile.motionBlur.enabled = OptionGlobals.MotionBlur;
		Profile.bloom.enabled = !OptionGlobals.DisableBloom;
		Profile.chromaticAberration.enabled = !OptionGlobals.DisableAbberation;
		Profile.vignette.enabled = !OptionGlobals.DisableVignette;
	}

	private void Update()
	{
		if (ResetSettings)
		{
			ResetPostProcessingSettings();
			ResetSettings = false;
		}
	}
}
