using UnityEngine;

namespace RadiantGI
{
	public class ToggleEffect : MonoBehaviour
	{
		public GameObject lamp;

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				lamp.SetActive(!lamp.activeSelf);
			}
		}
	}
}
