using UnityEngine;

public class HotAirBalloonCharacterScript : MonoBehaviour
{
	public Animation[] BalloonAnim;

	public YandereScript Yandere;

	public Transform YandereDev;

	public Transform RightBalloon;

	public Transform LeftBalloon;

	public Transform RightBanner;

	public Transform LeftBanner;

	public Transform DevHead;

	public Transform Head;

	public Vector3 RightBalloonOrigin;

	public Vector3 LeftBalloonOrigin;

	public Vector3 RightBannerOrigin;

	public Vector3 LeftBannerOrigin;

	public bool Flip;

	private void Start()
	{
		BalloonAnim[0]["HotAirBalloonAnim"].speed = 0.9f;
		BalloonAnim[1]["BalloonFloat"].speed = 0.9f;
		BalloonAnim[2]["BalloonFloat"].speed = 0.8f;
		BalloonAnim[3]["ZeppelinFly"].speed = 0.1f;
		BalloonAnim[4]["balloonWave_00"].speed = 0.9f;
		RightBalloonOrigin = RightBalloon.position;
		LeftBalloonOrigin = LeftBalloon.position;
		RightBannerOrigin = RightBanner.position;
		LeftBannerOrigin = LeftBanner.position;
	}

	private void LateUpdate()
	{
		if (Yandere.transform.position.z < base.transform.position.z)
		{
			if (Flip)
			{
				YandereDev.localScale = new Vector3(0.01f, 0.01f, 0.01f);
				base.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
				Flip = false;
			}
			DevHead.LookAt(Yandere.Head.position);
			Head.LookAt(Yandere.Head.position);
		}
		else
		{
			if (!Flip)
			{
				YandereDev.localScale = new Vector3(0.01f, 0.01f, -0.01f);
				base.transform.localScale = new Vector3(0.01f, 0.01f, -0.01f);
				Flip = true;
			}
			Vector3 vector = Head.position - Yandere.Head.position;
			Head.LookAt(Head.position + vector);
			vector = DevHead.position - Yandere.Head.position;
			DevHead.LookAt(DevHead.position + vector);
		}
		Vector3 vector2 = RightBalloon.position - RightBalloonOrigin;
		Vector3 vector3 = LeftBalloon.position - LeftBalloonOrigin;
		RightBanner.position = RightBannerOrigin + vector2;
		LeftBanner.position = LeftBannerOrigin + vector3;
	}
}
