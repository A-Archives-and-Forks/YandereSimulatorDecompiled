﻿using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020003FE RID: 1022
[Serializable]
public class PlayerSaveData
{
	// Token: 0x06001C06 RID: 7174 RVA: 0x00146360 File Offset: 0x00144560
	public static PlayerSaveData ReadFromGlobals()
	{
		PlayerSaveData playerSaveData = new PlayerSaveData();
		playerSaveData.alerts = PlayerGlobals.Alerts;
		playerSaveData.enlightenment = PlayerGlobals.Enlightenment;
		playerSaveData.enlightenmentBonus = PlayerGlobals.EnlightenmentBonus;
		playerSaveData.headset = PlayerGlobals.Headset;
		playerSaveData.kills = PlayerGlobals.Kills;
		playerSaveData.numbness = PlayerGlobals.Numbness;
		playerSaveData.numbnessBonus = PlayerGlobals.NumbnessBonus;
		playerSaveData.pantiesEquipped = PlayerGlobals.PantiesEquipped;
		playerSaveData.pantyShots = PlayerGlobals.PantyShots;
		foreach (int num in PlayerGlobals.KeysOfPhoto())
		{
			if (PlayerGlobals.GetPhoto(num))
			{
				playerSaveData.photo.Add(num);
			}
		}
		foreach (int num2 in PlayerGlobals.KeysOfPhotoOnCorkboard())
		{
			if (PlayerGlobals.GetPhotoOnCorkboard(num2))
			{
				playerSaveData.photoOnCorkboard.Add(num2);
			}
		}
		foreach (int num3 in PlayerGlobals.KeysOfPhotoPosition())
		{
			playerSaveData.photoPosition.Add(num3, PlayerGlobals.GetPhotoPosition(num3));
		}
		foreach (int num4 in PlayerGlobals.KeysOfPhotoRotation())
		{
			playerSaveData.photoRotation.Add(num4, PlayerGlobals.GetPhotoRotation(num4));
		}
		playerSaveData.reputation = PlayerGlobals.Reputation;
		playerSaveData.seduction = PlayerGlobals.Seduction;
		playerSaveData.seductionBonus = PlayerGlobals.SeductionBonus;
		foreach (int num5 in PlayerGlobals.KeysOfSenpaiPhoto())
		{
			if (PlayerGlobals.GetSenpaiPhoto(num5))
			{
				playerSaveData.senpaiPhoto.Add(num5);
			}
		}
		playerSaveData.senpaiShots = PlayerGlobals.SenpaiShots;
		playerSaveData.socialBonus = PlayerGlobals.SocialBonus;
		playerSaveData.speedBonus = PlayerGlobals.SpeedBonus;
		playerSaveData.stealthBonus = PlayerGlobals.StealthBonus;
		foreach (int num6 in PlayerGlobals.KeysOfStudentFriend())
		{
			if (PlayerGlobals.GetStudentFriend(num6))
			{
				playerSaveData.studentFriend.Add(num6);
			}
		}
		foreach (int num7 in PlayerGlobals.KeysOfStudentPantyShot())
		{
			if (PlayerGlobals.GetStudentPantyShot(num7))
			{
				playerSaveData.studentPantyShot.Add(num7);
			}
		}
		return playerSaveData;
	}

	// Token: 0x06001C07 RID: 7175 RVA: 0x0014656C File Offset: 0x0014476C
	public static void WriteToGlobals(PlayerSaveData data)
	{
		PlayerGlobals.Alerts = data.alerts;
		PlayerGlobals.Enlightenment = data.enlightenment;
		PlayerGlobals.EnlightenmentBonus = data.enlightenmentBonus;
		PlayerGlobals.Headset = data.headset;
		PlayerGlobals.Kills = data.kills;
		PlayerGlobals.Numbness = data.numbness;
		PlayerGlobals.NumbnessBonus = data.numbnessBonus;
		PlayerGlobals.PantiesEquipped = data.pantiesEquipped;
		PlayerGlobals.PantyShots = data.pantyShots;
		Debug.Log("Is this being called anywhere?");
		foreach (int photoID in data.photo)
		{
			PlayerGlobals.SetPhoto(photoID, true);
		}
		foreach (int photoID2 in data.photoOnCorkboard)
		{
			PlayerGlobals.SetPhotoOnCorkboard(photoID2, true);
		}
		foreach (KeyValuePair<int, Vector2> keyValuePair in data.photoPosition)
		{
			PlayerGlobals.SetPhotoPosition(keyValuePair.Key, keyValuePair.Value);
		}
		foreach (KeyValuePair<int, float> keyValuePair2 in data.photoRotation)
		{
			PlayerGlobals.SetPhotoRotation(keyValuePair2.Key, keyValuePair2.Value);
		}
		PlayerGlobals.Reputation = data.reputation;
		PlayerGlobals.Seduction = data.seduction;
		PlayerGlobals.SeductionBonus = data.seductionBonus;
		foreach (int photoID3 in data.senpaiPhoto)
		{
			PlayerGlobals.SetSenpaiPhoto(photoID3, true);
		}
		PlayerGlobals.SenpaiShots = data.senpaiShots;
		PlayerGlobals.SocialBonus = data.socialBonus;
		PlayerGlobals.SpeedBonus = data.speedBonus;
		PlayerGlobals.StealthBonus = data.stealthBonus;
		foreach (int studentID in data.studentFriend)
		{
			PlayerGlobals.SetStudentFriend(studentID, true);
		}
		foreach (int studentID2 in data.studentPantyShot)
		{
			PlayerGlobals.SetStudentPantyShot(studentID2, true);
		}
	}

	// Token: 0x0400312F RID: 12591
	public int alerts;

	// Token: 0x04003130 RID: 12592
	public int enlightenment;

	// Token: 0x04003131 RID: 12593
	public int enlightenmentBonus;

	// Token: 0x04003132 RID: 12594
	public bool headset;

	// Token: 0x04003133 RID: 12595
	public int kills;

	// Token: 0x04003134 RID: 12596
	public int numbness;

	// Token: 0x04003135 RID: 12597
	public int numbnessBonus;

	// Token: 0x04003136 RID: 12598
	public int pantiesEquipped;

	// Token: 0x04003137 RID: 12599
	public int pantyShots;

	// Token: 0x04003138 RID: 12600
	public IntHashSet photo = new IntHashSet();

	// Token: 0x04003139 RID: 12601
	public IntHashSet photoOnCorkboard = new IntHashSet();

	// Token: 0x0400313A RID: 12602
	public IntAndVector2Dictionary photoPosition = new IntAndVector2Dictionary();

	// Token: 0x0400313B RID: 12603
	public IntAndFloatDictionary photoRotation = new IntAndFloatDictionary();

	// Token: 0x0400313C RID: 12604
	public float reputation;

	// Token: 0x0400313D RID: 12605
	public int seduction;

	// Token: 0x0400313E RID: 12606
	public int seductionBonus;

	// Token: 0x0400313F RID: 12607
	public IntHashSet senpaiPhoto = new IntHashSet();

	// Token: 0x04003140 RID: 12608
	public int senpaiShots;

	// Token: 0x04003141 RID: 12609
	public int socialBonus;

	// Token: 0x04003142 RID: 12610
	public int speedBonus;

	// Token: 0x04003143 RID: 12611
	public int stealthBonus;

	// Token: 0x04003144 RID: 12612
	public IntHashSet studentFriend = new IntHashSet();

	// Token: 0x04003145 RID: 12613
	public IntHashSet studentPantyShot = new IntHashSet();
}
