using UnityEngine;

namespace HNS
{
	public class FootstepEmitter : MonoBehaviour
	{
		public Transform Reference;

		public Camera MyCamera;

		public AudioClip[] Footsteps;

		private int lastFootstepIndex = -1;

		public float maxVolume = 0.5f;

		public float minCameraDistance = 5f;

		public float maxCameraDistance = 20f;

		public float Up = 0.2f;

		public float Down = 0.2f;

		public bool isUp;

		public void Update()
		{
			UpdatePosition();
		}

		private void Play(AudioClip clip)
		{
			float outMin = Mathematics.Remap(0f, 1f, 0f, maxVolume, InputQuery.Movement.magnitude);
			float value = Vector3.Distance(MyCamera.transform.position, Reference.transform.position);
			outMin = Mathematics.Remap(minCameraDistance, maxCameraDistance, outMin, 0f, value);
			GameObject obj = new GameObject(clip.name);
			obj.transform.parent = base.transform;
			obj.transform.position = base.transform.position;
			obj.transform.rotation = base.transform.rotation;
			AudioSource audioSource = obj.AddComponent<AudioSource>();
			audioSource.volume = Mathematics.Remap(0f, 1f, 0f, outMin, InputQuery.Movement.magnitude);
			audioSource.clip = clip;
			audioSource.loop = false;
			audioSource.playOnAwake = false;
			audioSource.Play();
			Object.Destroy(obj, clip.length + 0.1f);
		}

		private void UpdatePosition()
		{
			float num = Up + Reference.transform.position.y;
			float num2 = Down + Reference.transform.position.y;
			if (base.transform.position.y >= num && !isUp)
			{
				isUp = true;
			}
			if (base.transform.position.y <= num2 && isUp)
			{
				isUp = false;
				int num3 = Random.Range(0, Footsteps.Length);
				while (num3 == lastFootstepIndex && Footsteps.Length > 1)
				{
					num3 = Random.Range(0, Footsteps.Length);
				}
				lastFootstepIndex = num3;
				Play(Footsteps[num3]);
			}
		}
	}
}
