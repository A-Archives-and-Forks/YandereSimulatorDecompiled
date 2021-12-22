﻿using System;
using UnityEngine;

// Token: 0x020004C1 RID: 1217
public class YandereKunScript : MonoBehaviour
{
	// Token: 0x06001FD5 RID: 8149 RVA: 0x001C3FE8 File Offset: 0x001C21E8
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

	// Token: 0x06001FD6 RID: 8150 RVA: 0x001C44C8 File Offset: 0x001C26C8
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

	// Token: 0x04004302 RID: 17154
	public Transform ChanItemParent;

	// Token: 0x04004303 RID: 17155
	public Transform KunItemParent;

	// Token: 0x04004304 RID: 17156
	public Transform ChanHips;

	// Token: 0x04004305 RID: 17157
	public Transform ChanSpine;

	// Token: 0x04004306 RID: 17158
	public Transform ChanSpine1;

	// Token: 0x04004307 RID: 17159
	public Transform ChanSpine2;

	// Token: 0x04004308 RID: 17160
	public Transform ChanSpine3;

	// Token: 0x04004309 RID: 17161
	public Transform ChanNeck;

	// Token: 0x0400430A RID: 17162
	public Transform ChanHead;

	// Token: 0x0400430B RID: 17163
	public Transform ChanRightUpLeg;

	// Token: 0x0400430C RID: 17164
	public Transform ChanRightLeg;

	// Token: 0x0400430D RID: 17165
	public Transform ChanRightFoot;

	// Token: 0x0400430E RID: 17166
	public Transform ChanRightToes;

	// Token: 0x0400430F RID: 17167
	public Transform ChanLeftUpLeg;

	// Token: 0x04004310 RID: 17168
	public Transform ChanLeftLeg;

	// Token: 0x04004311 RID: 17169
	public Transform ChanLeftFoot;

	// Token: 0x04004312 RID: 17170
	public Transform ChanLeftToes;

	// Token: 0x04004313 RID: 17171
	public Transform ChanRightShoulder;

	// Token: 0x04004314 RID: 17172
	public Transform ChanRightArm;

	// Token: 0x04004315 RID: 17173
	public Transform ChanRightArmRoll;

	// Token: 0x04004316 RID: 17174
	public Transform ChanRightForeArm;

	// Token: 0x04004317 RID: 17175
	public Transform ChanRightForeArmRoll;

	// Token: 0x04004318 RID: 17176
	public Transform ChanRightHand;

	// Token: 0x04004319 RID: 17177
	public Transform ChanLeftShoulder;

	// Token: 0x0400431A RID: 17178
	public Transform ChanLeftArm;

	// Token: 0x0400431B RID: 17179
	public Transform ChanLeftArmRoll;

	// Token: 0x0400431C RID: 17180
	public Transform ChanLeftForeArm;

	// Token: 0x0400431D RID: 17181
	public Transform ChanLeftForeArmRoll;

	// Token: 0x0400431E RID: 17182
	public Transform ChanLeftHand;

	// Token: 0x0400431F RID: 17183
	public Transform ChanLeftHandPinky1;

	// Token: 0x04004320 RID: 17184
	public Transform ChanLeftHandPinky2;

	// Token: 0x04004321 RID: 17185
	public Transform ChanLeftHandPinky3;

	// Token: 0x04004322 RID: 17186
	public Transform ChanLeftHandRing1;

	// Token: 0x04004323 RID: 17187
	public Transform ChanLeftHandRing2;

	// Token: 0x04004324 RID: 17188
	public Transform ChanLeftHandRing3;

	// Token: 0x04004325 RID: 17189
	public Transform ChanLeftHandMiddle1;

	// Token: 0x04004326 RID: 17190
	public Transform ChanLeftHandMiddle2;

	// Token: 0x04004327 RID: 17191
	public Transform ChanLeftHandMiddle3;

	// Token: 0x04004328 RID: 17192
	public Transform ChanLeftHandIndex1;

	// Token: 0x04004329 RID: 17193
	public Transform ChanLeftHandIndex2;

	// Token: 0x0400432A RID: 17194
	public Transform ChanLeftHandIndex3;

	// Token: 0x0400432B RID: 17195
	public Transform ChanLeftHandThumb1;

	// Token: 0x0400432C RID: 17196
	public Transform ChanLeftHandThumb2;

	// Token: 0x0400432D RID: 17197
	public Transform ChanLeftHandThumb3;

	// Token: 0x0400432E RID: 17198
	public Transform ChanRightHandPinky1;

	// Token: 0x0400432F RID: 17199
	public Transform ChanRightHandPinky2;

	// Token: 0x04004330 RID: 17200
	public Transform ChanRightHandPinky3;

	// Token: 0x04004331 RID: 17201
	public Transform ChanRightHandRing1;

	// Token: 0x04004332 RID: 17202
	public Transform ChanRightHandRing2;

	// Token: 0x04004333 RID: 17203
	public Transform ChanRightHandRing3;

	// Token: 0x04004334 RID: 17204
	public Transform ChanRightHandMiddle1;

	// Token: 0x04004335 RID: 17205
	public Transform ChanRightHandMiddle2;

	// Token: 0x04004336 RID: 17206
	public Transform ChanRightHandMiddle3;

	// Token: 0x04004337 RID: 17207
	public Transform ChanRightHandIndex1;

	// Token: 0x04004338 RID: 17208
	public Transform ChanRightHandIndex2;

	// Token: 0x04004339 RID: 17209
	public Transform ChanRightHandIndex3;

	// Token: 0x0400433A RID: 17210
	public Transform ChanRightHandThumb1;

	// Token: 0x0400433B RID: 17211
	public Transform ChanRightHandThumb2;

	// Token: 0x0400433C RID: 17212
	public Transform ChanRightHandThumb3;

	// Token: 0x0400433D RID: 17213
	public Transform KunHips;

	// Token: 0x0400433E RID: 17214
	public Transform KunSpine;

	// Token: 0x0400433F RID: 17215
	public Transform KunSpine1;

	// Token: 0x04004340 RID: 17216
	public Transform KunSpine2;

	// Token: 0x04004341 RID: 17217
	public Transform KunSpine3;

	// Token: 0x04004342 RID: 17218
	public Transform KunNeck;

	// Token: 0x04004343 RID: 17219
	public Transform KunHead;

	// Token: 0x04004344 RID: 17220
	public Transform KunRightUpLeg;

	// Token: 0x04004345 RID: 17221
	public Transform KunRightLeg;

	// Token: 0x04004346 RID: 17222
	public Transform KunRightFoot;

	// Token: 0x04004347 RID: 17223
	public Transform KunRightToes;

	// Token: 0x04004348 RID: 17224
	public Transform KunLeftUpLeg;

	// Token: 0x04004349 RID: 17225
	public Transform KunLeftLeg;

	// Token: 0x0400434A RID: 17226
	public Transform KunLeftFoot;

	// Token: 0x0400434B RID: 17227
	public Transform KunLeftToes;

	// Token: 0x0400434C RID: 17228
	public Transform KunRightShoulder;

	// Token: 0x0400434D RID: 17229
	public Transform KunRightArm;

	// Token: 0x0400434E RID: 17230
	public Transform KunRightArmRoll;

	// Token: 0x0400434F RID: 17231
	public Transform KunRightForeArm;

	// Token: 0x04004350 RID: 17232
	public Transform KunRightForeArmRoll;

	// Token: 0x04004351 RID: 17233
	public Transform KunRightHand;

	// Token: 0x04004352 RID: 17234
	public Transform KunLeftShoulder;

	// Token: 0x04004353 RID: 17235
	public Transform KunLeftArm;

	// Token: 0x04004354 RID: 17236
	public Transform KunLeftArmRoll;

	// Token: 0x04004355 RID: 17237
	public Transform KunLeftForeArm;

	// Token: 0x04004356 RID: 17238
	public Transform KunLeftForeArmRoll;

	// Token: 0x04004357 RID: 17239
	public Transform KunLeftHand;

	// Token: 0x04004358 RID: 17240
	public Transform KunLeftHandPinky1;

	// Token: 0x04004359 RID: 17241
	public Transform KunLeftHandPinky2;

	// Token: 0x0400435A RID: 17242
	public Transform KunLeftHandPinky3;

	// Token: 0x0400435B RID: 17243
	public Transform KunLeftHandRing1;

	// Token: 0x0400435C RID: 17244
	public Transform KunLeftHandRing2;

	// Token: 0x0400435D RID: 17245
	public Transform KunLeftHandRing3;

	// Token: 0x0400435E RID: 17246
	public Transform KunLeftHandMiddle1;

	// Token: 0x0400435F RID: 17247
	public Transform KunLeftHandMiddle2;

	// Token: 0x04004360 RID: 17248
	public Transform KunLeftHandMiddle3;

	// Token: 0x04004361 RID: 17249
	public Transform KunLeftHandIndex1;

	// Token: 0x04004362 RID: 17250
	public Transform KunLeftHandIndex2;

	// Token: 0x04004363 RID: 17251
	public Transform KunLeftHandIndex3;

	// Token: 0x04004364 RID: 17252
	public Transform KunLeftHandThumb1;

	// Token: 0x04004365 RID: 17253
	public Transform KunLeftHandThumb2;

	// Token: 0x04004366 RID: 17254
	public Transform KunLeftHandThumb3;

	// Token: 0x04004367 RID: 17255
	public Transform KunRightHandPinky1;

	// Token: 0x04004368 RID: 17256
	public Transform KunRightHandPinky2;

	// Token: 0x04004369 RID: 17257
	public Transform KunRightHandPinky3;

	// Token: 0x0400436A RID: 17258
	public Transform KunRightHandRing1;

	// Token: 0x0400436B RID: 17259
	public Transform KunRightHandRing2;

	// Token: 0x0400436C RID: 17260
	public Transform KunRightHandRing3;

	// Token: 0x0400436D RID: 17261
	public Transform KunRightHandMiddle1;

	// Token: 0x0400436E RID: 17262
	public Transform KunRightHandMiddle2;

	// Token: 0x0400436F RID: 17263
	public Transform KunRightHandMiddle3;

	// Token: 0x04004370 RID: 17264
	public Transform KunRightHandIndex1;

	// Token: 0x04004371 RID: 17265
	public Transform KunRightHandIndex2;

	// Token: 0x04004372 RID: 17266
	public Transform KunRightHandIndex3;

	// Token: 0x04004373 RID: 17267
	public Transform KunRightHandThumb1;

	// Token: 0x04004374 RID: 17268
	public Transform KunRightHandThumb2;

	// Token: 0x04004375 RID: 17269
	public Transform KunRightHandThumb3;

	// Token: 0x04004376 RID: 17270
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04004377 RID: 17271
	public SkinnedMeshRenderer SecondRenderer;

	// Token: 0x04004378 RID: 17272
	public SkinnedMeshRenderer ThirdRenderer;

	// Token: 0x04004379 RID: 17273
	public bool Kizuna;

	// Token: 0x0400437A RID: 17274
	public bool Man;

	// Token: 0x0400437B RID: 17275
	public int ID;

	// Token: 0x0400437C RID: 17276
	private bool Adjusted;
}
