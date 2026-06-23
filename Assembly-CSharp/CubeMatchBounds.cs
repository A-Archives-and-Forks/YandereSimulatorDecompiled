using UnityEngine;

[ExecuteInEditMode]
public class CubeMatchBounds : MonoBehaviour
{
	[Tooltip("Drag any Renderer here (SkinnedMeshRenderer or MeshRenderer)")]
	public Renderer targetRenderer;

	[Tooltip("Extra padding around the bounds")]
	public Vector3 padding = Vector3.zero;

	[Tooltip("If true, the cube stays world-axis-aligned (recommended)")]
	public bool useWorldAlignedBounds = true;

	private void LateUpdate()
	{
		if (!(targetRenderer == null) && targetRenderer.enabled)
		{
			Bounds bounds = targetRenderer.bounds;
			bounds.Expand(padding);
			if (useWorldAlignedBounds)
			{
				base.transform.position = bounds.center;
				base.transform.rotation = Quaternion.identity;
				base.transform.localScale = bounds.size;
			}
			else
			{
				base.transform.position = targetRenderer.transform.position;
				base.transform.rotation = targetRenderer.transform.rotation;
				Vector3 lossyScale = targetRenderer.transform.lossyScale;
				Vector3 localScale = new Vector3(bounds.size.x / Mathf.Max(lossyScale.x, 0.0001f), bounds.size.y / Mathf.Max(lossyScale.y, 0.0001f), bounds.size.z / Mathf.Max(lossyScale.z, 0.0001f));
				base.transform.localScale = localScale;
			}
		}
	}

	private void OnDrawGizmosSelected()
	{
		if (!(targetRenderer == null))
		{
			Gizmos.color = new Color(1f, 0.5f, 0f, 0.4f);
			Bounds bounds = targetRenderer.bounds;
			bounds.Expand(padding);
			Gizmos.DrawWireCube(bounds.center, bounds.size);
		}
	}
}
