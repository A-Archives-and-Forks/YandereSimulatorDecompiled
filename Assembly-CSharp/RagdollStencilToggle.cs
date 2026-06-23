using System.Collections.Generic;
using UnityEngine;

public class RagdollStencilToggle : MonoBehaviour
{
	public Material stencilMaterial;

	private List<Renderer> renderers = new List<Renderer>();

	private bool stencilEnabled;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.J))
		{
			if (stencilEnabled)
			{
				DisableStencil();
				Debug.Log("Censor Disabled!");
			}
			else
			{
				EnableStencil();
				Debug.Log("Censor Enabled!");
			}
			stencilEnabled = !stencilEnabled;
		}
	}

	public void EnableStencil()
	{
		renderers.Clear();
		Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>();
		foreach (Renderer renderer in componentsInChildren)
		{
			if (!renderer.gameObject.CompareTag("CensorQuad"))
			{
				Debug.Log("Something has gone wrong here, there doesn't seem to be a censor quad... I think? Double check the tag on the intended censor billboard.");
				renderers.Add(renderer);
			}
		}
		foreach (Renderer renderer2 in renderers)
		{
			List<Material> list = new List<Material>(renderer2.materials);
			if (!list.Contains(stencilMaterial))
			{
				list.Add(stencilMaterial);
				renderer2.materials = list.ToArray();
			}
		}
	}

	public void DisableStencil()
	{
		foreach (Renderer renderer in renderers)
		{
			List<Material> list = new List<Material>(renderer.materials);
			list.Remove(stencilMaterial);
			renderer.materials = list.ToArray();
		}
	}
}
