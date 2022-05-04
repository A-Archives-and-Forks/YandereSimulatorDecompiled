﻿using System;
using UnityEngine;

// Token: 0x020004D1 RID: 1233
public class YandereKunScript : MonoBehaviour
{
	// Token: 0x0600203E RID: 8254 RVA: 0x001CD848 File Offset: 0x001CBA48
	private void Start()
	{
		if (!this.Kizuna)
		{
			if (this.KunHips != null)
			{
				this.KunHips.parent = this.ChanHips;
			}
			if (this.KunSpine != null)
			{
				this.KunSpine.parent = this.ChanSpine;
			}
			if (this.KunSpine1 != null)
			{
				this.KunSpine1.parent = this.ChanSpine1;
			}
			if (this.KunSpine2 != null)
			{
				this.KunSpine2.parent = this.ChanSpine2;
			}
			if (this.KunSpine3 != null)
			{
				this.KunSpine3.parent = this.ChanSpine3;
			}
			if (this.KunNeck != null)
			{
				this.KunNeck.parent = this.ChanNeck;
			}
			if (this.KunHead != null)
			{
				this.KunHead.parent = this.ChanHead;
			}
			this.KunRightUpLeg.parent = this.ChanRightUpLeg;
			this.KunRightLeg.parent = this.ChanRightLeg;
			this.KunRightFoot.parent = this.ChanRightFoot;
			this.KunRightToes.parent = this.ChanRightToes;
			this.KunLeftUpLeg.parent = this.ChanLeftUpLeg;
			this.KunLeftLeg.parent = this.ChanLeftLeg;
			this.KunLeftFoot.parent = this.ChanLeftFoot;
			this.KunLeftToes.parent = this.ChanLeftToes;
			this.KunRightShoulder.parent = this.ChanRightShoulder;
			this.KunRightArm.parent = this.ChanRightArm;
			if (this.KunRightArmRoll != null)
			{
				this.KunRightArmRoll.parent = this.ChanRightArmRoll;
			}
			this.KunRightForeArm.parent = this.ChanRightForeArm;
			if (this.KunRightForeArmRoll != null)
			{
				this.KunRightForeArmRoll.parent = this.ChanRightForeArmRoll;
			}
			this.KunRightHand.parent = this.ChanRightHand;
			this.KunLeftShoulder.parent = this.ChanLeftShoulder;
			this.KunLeftArm.parent = this.ChanLeftArm;
			if (this.KunLeftArmRoll != null)
			{
				this.KunLeftArmRoll.parent = this.ChanLeftArmRoll;
			}
			this.KunLeftForeArm.parent = this.ChanLeftForeArm;
			if (this.KunLeftForeArmRoll != null)
			{
				this.KunLeftForeArmRoll.parent = this.ChanLeftForeArmRoll;
			}
			this.KunLeftHand.parent = this.ChanLeftHand;
			if (!this.Man)
			{
				this.KunLeftHandPinky1.parent = this.ChanLeftHandPinky1;
				this.KunLeftHandPinky2.parent = this.ChanLeftHandPinky2;
				this.KunLeftHandPinky3.parent = this.ChanLeftHandPinky3;
				this.KunLeftHandRing1.parent = this.ChanLeftHandRing1;
				this.KunLeftHandRing2.parent = this.ChanLeftHandRing2;
				this.KunLeftHandRing3.parent = this.ChanLeftHandRing3;
				this.KunLeftHandMiddle1.parent = this.ChanLeftHandMiddle1;
				this.KunLeftHandMiddle2.parent = this.ChanLeftHandMiddle2;
				this.KunLeftHandMiddle3.parent = this.ChanLeftHandMiddle3;
				this.KunLeftHandIndex1.parent = this.ChanLeftHandIndex1;
				this.KunLeftHandIndex2.parent = this.ChanLeftHandIndex2;
				this.KunLeftHandIndex3.parent = this.ChanLeftHandIndex3;
				this.KunLeftHandThumb1.parent = this.ChanLeftHandThumb1;
				this.KunLeftHandThumb2.parent = this.ChanLeftHandThumb2;
				this.KunLeftHandThumb3.parent = this.ChanLeftHandThumb3;
				this.KunRightHandPinky1.parent = this.ChanRightHandPinky1;
				this.KunRightHandPinky2.parent = this.ChanRightHandPinky2;
				this.KunRightHandPinky3.parent = this.ChanRightHandPinky3;
				this.KunRightHandRing1.parent = this.ChanRightHandRing1;
				this.KunRightHandRing2.parent = this.ChanRightHandRing2;
				this.KunRightHandRing3.parent = this.ChanRightHandRing3;
				this.KunRightHandMiddle1.parent = this.ChanRightHandMiddle1;
				this.KunRightHandMiddle2.parent = this.ChanRightHandMiddle2;
				this.KunRightHandMiddle3.parent = this.ChanRightHandMiddle3;
				this.KunRightHandIndex1.parent = this.ChanRightHandIndex1;
				this.KunRightHandIndex2.parent = this.ChanRightHandIndex2;
				this.KunRightHandIndex3.parent = this.ChanRightHandIndex3;
				this.KunRightHandThumb1.parent = this.ChanRightHandThumb1;
				this.KunRightHandThumb2.parent = this.ChanRightHandThumb2;
				this.KunRightHandThumb3.parent = this.ChanRightHandThumb3;
			}
		}
		if (this.MyRenderer != null)
		{
			this.MyRenderer.enabled = true;
		}
		if (this.SecondRenderer != null)
		{
			this.SecondRenderer.enabled = true;
		}
		if (this.ThirdRenderer != null)
		{
			this.ThirdRenderer.enabled = true;
		}
		base.gameObject.SetActive(false);
	}

	// Token: 0x0600203F RID: 8255 RVA: 0x001CDD28 File Offset: 0x001CBF28
	private void LateUpdate()
	{
		if (this.Man)
		{
			this.ChanItemParent.position = this.KunItemParent.position;
			if (!this.Adjusted)
			{
				this.KunRightShoulder.position += new Vector3(0f, 0.1f, 0f);
				this.KunRightArm.position += new Vector3(0f, 0.1f, 0f);
				this.KunRightForeArm.position += new Vector3(0f, 0.1f, 0f);
				this.KunRightHand.position += new Vector3(0f, 0.1f, 0f);
				this.KunLeftShoulder.position += new Vector3(0f, 0.1f, 0f);
				this.KunLeftArm.position += new Vector3(0f, 0.1f, 0f);
				this.KunLeftForeArm.position += new Vector3(0f, 0.1f, 0f);
				this.KunLeftHand.position += new Vector3(0f, 0.1f, 0f);
				this.Adjusted = true;
			}
		}
		if (this.Kizuna)
		{
			this.KunItemParent.localPosition = new Vector3(0.066666f, -0.033333f, 0.02f);
			this.ChanItemParent.position = this.KunItemParent.position;
			this.KunHips.localPosition = this.ChanHips.localPosition;
			if (this.KunHips != null)
			{
				this.KunHips.eulerAngles = this.ChanHips.eulerAngles;
			}
			if (this.KunSpine != null)
			{
				this.KunSpine.eulerAngles = this.ChanSpine.eulerAngles;
			}
			if (this.KunSpine1 != null)
			{
				this.KunSpine1.eulerAngles = this.ChanSpine1.eulerAngles;
			}
			if (this.KunSpine2 != null)
			{
				this.KunSpine2.eulerAngles = this.ChanSpine2.eulerAngles;
			}
			if (this.KunSpine3 != null)
			{
				this.KunSpine3.eulerAngles = this.ChanSpine3.eulerAngles;
			}
			if (this.KunNeck != null)
			{
				this.KunNeck.eulerAngles = this.ChanNeck.eulerAngles;
			}
			if (this.KunHead != null)
			{
				this.KunHead.eulerAngles = this.ChanHead.eulerAngles;
			}
			this.KunRightUpLeg.eulerAngles = this.ChanRightUpLeg.eulerAngles;
			this.KunRightLeg.eulerAngles = this.ChanRightLeg.eulerAngles;
			this.KunRightFoot.eulerAngles = this.ChanRightFoot.eulerAngles;
			this.KunRightToes.eulerAngles = this.ChanRightToes.eulerAngles;
			this.KunLeftUpLeg.eulerAngles = this.ChanLeftUpLeg.eulerAngles;
			this.KunLeftLeg.eulerAngles = this.ChanLeftLeg.eulerAngles;
			this.KunLeftFoot.eulerAngles = this.ChanLeftFoot.eulerAngles;
			this.KunLeftToes.eulerAngles = this.ChanLeftToes.eulerAngles;
			this.KunRightShoulder.eulerAngles = this.ChanRightShoulder.eulerAngles;
			this.KunRightArm.eulerAngles = this.ChanRightArm.eulerAngles;
			if (this.KunLeftArmRoll != null)
			{
				this.KunRightArmRoll.eulerAngles = this.ChanRightArmRoll.eulerAngles;
			}
			this.KunRightForeArm.eulerAngles = this.ChanRightForeArm.eulerAngles;
			if (this.KunLeftArmRoll != null)
			{
				this.KunRightForeArmRoll.eulerAngles = this.ChanRightForeArmRoll.eulerAngles;
			}
			this.KunRightHand.eulerAngles = this.ChanRightHand.eulerAngles;
			this.KunLeftShoulder.eulerAngles = this.ChanLeftShoulder.eulerAngles;
			this.KunLeftArm.eulerAngles = this.ChanLeftArm.eulerAngles;
			if (this.KunLeftArmRoll != null)
			{
				this.KunLeftArmRoll.eulerAngles = this.ChanLeftArmRoll.eulerAngles;
			}
			this.KunLeftForeArm.eulerAngles = this.ChanLeftForeArm.eulerAngles;
			if (this.KunLeftForeArmRoll != null)
			{
				this.KunLeftForeArmRoll.eulerAngles = this.ChanLeftForeArmRoll.eulerAngles;
			}
			this.KunLeftHand.eulerAngles = this.ChanLeftHand.eulerAngles;
			this.KunLeftHandPinky1.eulerAngles = this.ChanLeftHandPinky1.eulerAngles;
			this.KunLeftHandPinky2.eulerAngles = this.ChanLeftHandPinky2.eulerAngles;
			this.KunLeftHandPinky3.eulerAngles = this.ChanLeftHandPinky3.eulerAngles;
			this.KunLeftHandRing1.eulerAngles = this.ChanLeftHandRing1.eulerAngles;
			this.KunLeftHandRing2.eulerAngles = this.ChanLeftHandRing2.eulerAngles;
			this.KunLeftHandRing3.eulerAngles = this.ChanLeftHandRing3.eulerAngles;
			this.KunLeftHandMiddle1.eulerAngles = this.ChanLeftHandMiddle1.eulerAngles;
			this.KunLeftHandMiddle2.eulerAngles = this.ChanLeftHandMiddle2.eulerAngles;
			this.KunLeftHandMiddle3.eulerAngles = this.ChanLeftHandMiddle3.eulerAngles;
			this.KunLeftHandIndex1.eulerAngles = this.ChanLeftHandIndex1.eulerAngles;
			this.KunLeftHandIndex2.eulerAngles = this.ChanLeftHandIndex2.eulerAngles;
			this.KunLeftHandIndex3.eulerAngles = this.ChanLeftHandIndex3.eulerAngles;
			this.KunLeftHandThumb1.eulerAngles = this.ChanLeftHandThumb1.eulerAngles;
			this.KunLeftHandThumb2.eulerAngles = this.ChanLeftHandThumb2.eulerAngles;
			this.KunLeftHandThumb3.eulerAngles = this.ChanLeftHandThumb3.eulerAngles;
			this.KunRightHandPinky1.eulerAngles = this.ChanRightHandPinky1.eulerAngles;
			this.KunRightHandPinky2.eulerAngles = this.ChanRightHandPinky2.eulerAngles;
			this.KunRightHandPinky3.eulerAngles = this.ChanRightHandPinky3.eulerAngles;
			this.KunRightHandRing1.eulerAngles = this.ChanRightHandRing1.eulerAngles;
			this.KunRightHandRing2.eulerAngles = this.ChanRightHandRing2.eulerAngles;
			this.KunRightHandRing3.eulerAngles = this.ChanRightHandRing3.eulerAngles;
			this.KunRightHandMiddle1.eulerAngles = this.ChanRightHandMiddle1.eulerAngles;
			this.KunRightHandMiddle2.eulerAngles = this.ChanRightHandMiddle2.eulerAngles;
			this.KunRightHandMiddle3.eulerAngles = this.ChanRightHandMiddle3.eulerAngles;
			this.KunRightHandIndex1.eulerAngles = this.ChanRightHandIndex1.eulerAngles;
			this.KunRightHandIndex2.eulerAngles = this.ChanRightHandIndex2.eulerAngles;
			this.KunRightHandIndex3.eulerAngles = this.ChanRightHandIndex3.eulerAngles;
			this.KunRightHandThumb1.eulerAngles = this.ChanRightHandThumb1.eulerAngles;
			this.KunRightHandThumb2.eulerAngles = this.ChanRightHandThumb2.eulerAngles;
			this.KunRightHandThumb3.eulerAngles = this.ChanRightHandThumb3.eulerAngles;
			if (Input.GetKeyDown(KeyCode.Space))
			{
				if (this.ID > -1)
				{
					for (int i = 0; i < 32; i++)
					{
						this.SecondRenderer.SetBlendShapeWeight(i, 0f);
					}
					if (this.ID > 32)
					{
						this.ID = 0;
					}
					this.SecondRenderer.SetBlendShapeWeight(this.ID, 100f);
				}
				this.ID++;
			}
		}
	}

	// Token: 0x04004424 RID: 17444
	public Transform ChanItemParent;

	// Token: 0x04004425 RID: 17445
	public Transform KunItemParent;

	// Token: 0x04004426 RID: 17446
	public Transform ChanHips;

	// Token: 0x04004427 RID: 17447
	public Transform ChanSpine;

	// Token: 0x04004428 RID: 17448
	public Transform ChanSpine1;

	// Token: 0x04004429 RID: 17449
	public Transform ChanSpine2;

	// Token: 0x0400442A RID: 17450
	public Transform ChanSpine3;

	// Token: 0x0400442B RID: 17451
	public Transform ChanNeck;

	// Token: 0x0400442C RID: 17452
	public Transform ChanHead;

	// Token: 0x0400442D RID: 17453
	public Transform ChanRightUpLeg;

	// Token: 0x0400442E RID: 17454
	public Transform ChanRightLeg;

	// Token: 0x0400442F RID: 17455
	public Transform ChanRightFoot;

	// Token: 0x04004430 RID: 17456
	public Transform ChanRightToes;

	// Token: 0x04004431 RID: 17457
	public Transform ChanLeftUpLeg;

	// Token: 0x04004432 RID: 17458
	public Transform ChanLeftLeg;

	// Token: 0x04004433 RID: 17459
	public Transform ChanLeftFoot;

	// Token: 0x04004434 RID: 17460
	public Transform ChanLeftToes;

	// Token: 0x04004435 RID: 17461
	public Transform ChanRightShoulder;

	// Token: 0x04004436 RID: 17462
	public Transform ChanRightArm;

	// Token: 0x04004437 RID: 17463
	public Transform ChanRightArmRoll;

	// Token: 0x04004438 RID: 17464
	public Transform ChanRightForeArm;

	// Token: 0x04004439 RID: 17465
	public Transform ChanRightForeArmRoll;

	// Token: 0x0400443A RID: 17466
	public Transform ChanRightHand;

	// Token: 0x0400443B RID: 17467
	public Transform ChanLeftShoulder;

	// Token: 0x0400443C RID: 17468
	public Transform ChanLeftArm;

	// Token: 0x0400443D RID: 17469
	public Transform ChanLeftArmRoll;

	// Token: 0x0400443E RID: 17470
	public Transform ChanLeftForeArm;

	// Token: 0x0400443F RID: 17471
	public Transform ChanLeftForeArmRoll;

	// Token: 0x04004440 RID: 17472
	public Transform ChanLeftHand;

	// Token: 0x04004441 RID: 17473
	public Transform ChanLeftHandPinky1;

	// Token: 0x04004442 RID: 17474
	public Transform ChanLeftHandPinky2;

	// Token: 0x04004443 RID: 17475
	public Transform ChanLeftHandPinky3;

	// Token: 0x04004444 RID: 17476
	public Transform ChanLeftHandRing1;

	// Token: 0x04004445 RID: 17477
	public Transform ChanLeftHandRing2;

	// Token: 0x04004446 RID: 17478
	public Transform ChanLeftHandRing3;

	// Token: 0x04004447 RID: 17479
	public Transform ChanLeftHandMiddle1;

	// Token: 0x04004448 RID: 17480
	public Transform ChanLeftHandMiddle2;

	// Token: 0x04004449 RID: 17481
	public Transform ChanLeftHandMiddle3;

	// Token: 0x0400444A RID: 17482
	public Transform ChanLeftHandIndex1;

	// Token: 0x0400444B RID: 17483
	public Transform ChanLeftHandIndex2;

	// Token: 0x0400444C RID: 17484
	public Transform ChanLeftHandIndex3;

	// Token: 0x0400444D RID: 17485
	public Transform ChanLeftHandThumb1;

	// Token: 0x0400444E RID: 17486
	public Transform ChanLeftHandThumb2;

	// Token: 0x0400444F RID: 17487
	public Transform ChanLeftHandThumb3;

	// Token: 0x04004450 RID: 17488
	public Transform ChanRightHandPinky1;

	// Token: 0x04004451 RID: 17489
	public Transform ChanRightHandPinky2;

	// Token: 0x04004452 RID: 17490
	public Transform ChanRightHandPinky3;

	// Token: 0x04004453 RID: 17491
	public Transform ChanRightHandRing1;

	// Token: 0x04004454 RID: 17492
	public Transform ChanRightHandRing2;

	// Token: 0x04004455 RID: 17493
	public Transform ChanRightHandRing3;

	// Token: 0x04004456 RID: 17494
	public Transform ChanRightHandMiddle1;

	// Token: 0x04004457 RID: 17495
	public Transform ChanRightHandMiddle2;

	// Token: 0x04004458 RID: 17496
	public Transform ChanRightHandMiddle3;

	// Token: 0x04004459 RID: 17497
	public Transform ChanRightHandIndex1;

	// Token: 0x0400445A RID: 17498
	public Transform ChanRightHandIndex2;

	// Token: 0x0400445B RID: 17499
	public Transform ChanRightHandIndex3;

	// Token: 0x0400445C RID: 17500
	public Transform ChanRightHandThumb1;

	// Token: 0x0400445D RID: 17501
	public Transform ChanRightHandThumb2;

	// Token: 0x0400445E RID: 17502
	public Transform ChanRightHandThumb3;

	// Token: 0x0400445F RID: 17503
	public Transform KunHips;

	// Token: 0x04004460 RID: 17504
	public Transform KunSpine;

	// Token: 0x04004461 RID: 17505
	public Transform KunSpine1;

	// Token: 0x04004462 RID: 17506
	public Transform KunSpine2;

	// Token: 0x04004463 RID: 17507
	public Transform KunSpine3;

	// Token: 0x04004464 RID: 17508
	public Transform KunNeck;

	// Token: 0x04004465 RID: 17509
	public Transform KunHead;

	// Token: 0x04004466 RID: 17510
	public Transform KunRightUpLeg;

	// Token: 0x04004467 RID: 17511
	public Transform KunRightLeg;

	// Token: 0x04004468 RID: 17512
	public Transform KunRightFoot;

	// Token: 0x04004469 RID: 17513
	public Transform KunRightToes;

	// Token: 0x0400446A RID: 17514
	public Transform KunLeftUpLeg;

	// Token: 0x0400446B RID: 17515
	public Transform KunLeftLeg;

	// Token: 0x0400446C RID: 17516
	public Transform KunLeftFoot;

	// Token: 0x0400446D RID: 17517
	public Transform KunLeftToes;

	// Token: 0x0400446E RID: 17518
	public Transform KunRightShoulder;

	// Token: 0x0400446F RID: 17519
	public Transform KunRightArm;

	// Token: 0x04004470 RID: 17520
	public Transform KunRightArmRoll;

	// Token: 0x04004471 RID: 17521
	public Transform KunRightForeArm;

	// Token: 0x04004472 RID: 17522
	public Transform KunRightForeArmRoll;

	// Token: 0x04004473 RID: 17523
	public Transform KunRightHand;

	// Token: 0x04004474 RID: 17524
	public Transform KunLeftShoulder;

	// Token: 0x04004475 RID: 17525
	public Transform KunLeftArm;

	// Token: 0x04004476 RID: 17526
	public Transform KunLeftArmRoll;

	// Token: 0x04004477 RID: 17527
	public Transform KunLeftForeArm;

	// Token: 0x04004478 RID: 17528
	public Transform KunLeftForeArmRoll;

	// Token: 0x04004479 RID: 17529
	public Transform KunLeftHand;

	// Token: 0x0400447A RID: 17530
	public Transform KunLeftHandPinky1;

	// Token: 0x0400447B RID: 17531
	public Transform KunLeftHandPinky2;

	// Token: 0x0400447C RID: 17532
	public Transform KunLeftHandPinky3;

	// Token: 0x0400447D RID: 17533
	public Transform KunLeftHandRing1;

	// Token: 0x0400447E RID: 17534
	public Transform KunLeftHandRing2;

	// Token: 0x0400447F RID: 17535
	public Transform KunLeftHandRing3;

	// Token: 0x04004480 RID: 17536
	public Transform KunLeftHandMiddle1;

	// Token: 0x04004481 RID: 17537
	public Transform KunLeftHandMiddle2;

	// Token: 0x04004482 RID: 17538
	public Transform KunLeftHandMiddle3;

	// Token: 0x04004483 RID: 17539
	public Transform KunLeftHandIndex1;

	// Token: 0x04004484 RID: 17540
	public Transform KunLeftHandIndex2;

	// Token: 0x04004485 RID: 17541
	public Transform KunLeftHandIndex3;

	// Token: 0x04004486 RID: 17542
	public Transform KunLeftHandThumb1;

	// Token: 0x04004487 RID: 17543
	public Transform KunLeftHandThumb2;

	// Token: 0x04004488 RID: 17544
	public Transform KunLeftHandThumb3;

	// Token: 0x04004489 RID: 17545
	public Transform KunRightHandPinky1;

	// Token: 0x0400448A RID: 17546
	public Transform KunRightHandPinky2;

	// Token: 0x0400448B RID: 17547
	public Transform KunRightHandPinky3;

	// Token: 0x0400448C RID: 17548
	public Transform KunRightHandRing1;

	// Token: 0x0400448D RID: 17549
	public Transform KunRightHandRing2;

	// Token: 0x0400448E RID: 17550
	public Transform KunRightHandRing3;

	// Token: 0x0400448F RID: 17551
	public Transform KunRightHandMiddle1;

	// Token: 0x04004490 RID: 17552
	public Transform KunRightHandMiddle2;

	// Token: 0x04004491 RID: 17553
	public Transform KunRightHandMiddle3;

	// Token: 0x04004492 RID: 17554
	public Transform KunRightHandIndex1;

	// Token: 0x04004493 RID: 17555
	public Transform KunRightHandIndex2;

	// Token: 0x04004494 RID: 17556
	public Transform KunRightHandIndex3;

	// Token: 0x04004495 RID: 17557
	public Transform KunRightHandThumb1;

	// Token: 0x04004496 RID: 17558
	public Transform KunRightHandThumb2;

	// Token: 0x04004497 RID: 17559
	public Transform KunRightHandThumb3;

	// Token: 0x04004498 RID: 17560
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04004499 RID: 17561
	public SkinnedMeshRenderer SecondRenderer;

	// Token: 0x0400449A RID: 17562
	public SkinnedMeshRenderer ThirdRenderer;

	// Token: 0x0400449B RID: 17563
	public bool Kizuna;

	// Token: 0x0400449C RID: 17564
	public bool Man;

	// Token: 0x0400449D RID: 17565
	public int ID;

	// Token: 0x0400449E RID: 17566
	private bool Adjusted;
}
