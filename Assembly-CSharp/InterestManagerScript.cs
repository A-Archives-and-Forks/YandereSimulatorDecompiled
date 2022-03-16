﻿using System;
using UnityEngine;

// Token: 0x02000339 RID: 825
public class InterestManagerScript : MonoBehaviour
{
	// Token: 0x060018EB RID: 6379 RVA: 0x000F6626 File Offset: 0x000F4826
	private void Start()
	{
		if (GameGlobals.Eighties)
		{
			this.TopicNames[14] = "Jokes";
		}
	}

	// Token: 0x060018EC RID: 6380 RVA: 0x000F6640 File Offset: 0x000F4840
	private void Update()
	{
		if (this.Yandere.Follower != null)
		{
			for (int i = 1; i < 11; i++)
			{
				if (!this.Ignore[i] && Vector3.Distance(this.Yandere.Follower.transform.position, this.Clubs[i].position) < 4f && !ConversationGlobals.GetTopicLearnedByStudent(i, this.FollowerID))
				{
					this.Yandere.NotificationManager.TopicName = this.TopicNames[i];
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
					ConversationGlobals.SetTopicLearnedByStudent(i, this.FollowerID, true);
					this.Ignore[i] = true;
				}
			}
			if (!this.Ignore[11] && Vector3.Distance(this.Yandere.Follower.transform.position, this.Clubs[11].position) < 4f && !ConversationGlobals.GetTopicLearnedByStudent(11, this.FollowerID))
			{
				if (!ConversationGlobals.GetTopicDiscovered(11))
				{
					this.Yandere.NotificationManager.TopicName = "Video Games";
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
					this.Yandere.NotificationManager.TopicName = "Anime";
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
					this.Yandere.NotificationManager.TopicName = "Cosplay";
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
					this.Yandere.NotificationManager.TopicName = "Memes";
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
					ConversationGlobals.SetTopicDiscovered(11, true);
					ConversationGlobals.SetTopicDiscovered(12, true);
					ConversationGlobals.SetTopicDiscovered(13, true);
					ConversationGlobals.SetTopicDiscovered(14, true);
				}
				this.Yandere.NotificationManager.TopicName = "Video Games";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				this.Yandere.NotificationManager.TopicName = "Anime";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				this.Yandere.NotificationManager.TopicName = "Cosplay";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				this.Yandere.NotificationManager.TopicName = "Memes";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				ConversationGlobals.SetTopicLearnedByStudent(11, this.FollowerID, true);
				ConversationGlobals.SetTopicLearnedByStudent(12, this.FollowerID, true);
				ConversationGlobals.SetTopicLearnedByStudent(13, this.FollowerID, true);
				ConversationGlobals.SetTopicLearnedByStudent(14, this.FollowerID, true);
				this.Ignore[11] = true;
			}
			if (!this.Ignore[15] && Vector3.Distance(this.Yandere.Follower.transform.position, this.Kitten.position) < 2.5f && !ConversationGlobals.GetTopicLearnedByStudent(15, this.FollowerID))
			{
				this.Yandere.NotificationManager.TopicName = "Cats";
				if (!ConversationGlobals.GetTopicDiscovered(15))
				{
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
					ConversationGlobals.SetTopicDiscovered(15, true);
				}
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				ConversationGlobals.SetTopicLearnedByStudent(15, this.FollowerID, true);
				this.Ignore[15] = true;
			}
			if (!this.Ignore[16] && Vector3.Distance(this.Yandere.Follower.transform.position, this.Clubs[6].position) < 4f && !ConversationGlobals.GetTopicLearnedByStudent(16, this.FollowerID))
			{
				this.Yandere.NotificationManager.TopicName = "Justice";
				if (!ConversationGlobals.GetTopicDiscovered(16))
				{
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
					ConversationGlobals.SetTopicDiscovered(16, true);
				}
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				ConversationGlobals.SetTopicLearnedByStudent(16, this.FollowerID, true);
				this.Ignore[16] = true;
			}
			if (!this.Ignore[17] && Vector3.Distance(this.Yandere.Follower.transform.position, this.DelinquentZone.position) < 4f && !ConversationGlobals.GetTopicLearnedByStudent(17, this.FollowerID))
			{
				this.Yandere.NotificationManager.TopicName = "Violence";
				if (!ConversationGlobals.GetTopicDiscovered(17))
				{
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
					ConversationGlobals.SetTopicDiscovered(17, true);
				}
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				ConversationGlobals.SetTopicLearnedByStudent(17, this.FollowerID, true);
				this.Ignore[17] = true;
			}
			if (!this.Ignore[18] && Vector3.Distance(this.Yandere.Follower.transform.position, this.Library.position) < 4f && !ConversationGlobals.GetTopicLearnedByStudent(18, this.FollowerID))
			{
				this.Yandere.NotificationManager.TopicName = "Reading";
				if (!ConversationGlobals.GetTopicDiscovered(18))
				{
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
					ConversationGlobals.SetTopicDiscovered(18, true);
				}
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				ConversationGlobals.SetTopicLearnedByStudent(18, this.FollowerID, true);
				this.Ignore[18] = true;
			}
		}
	}

	// Token: 0x060018ED RID: 6381 RVA: 0x000F6B9C File Offset: 0x000F4D9C
	public void UpdateIgnore()
	{
		for (int i = 1; i < 26; i++)
		{
			this.Ignore[i] = false;
		}
		int studentID = this.Yandere.Follower.StudentID;
		for (int i = 1; i < 26; i++)
		{
			if (ConversationGlobals.GetTopicLearnedByStudent(i, studentID))
			{
				this.Ignore[i] = true;
			}
		}
	}

	// Token: 0x04002668 RID: 9832
	public StudentManagerScript StudentManager;

	// Token: 0x04002669 RID: 9833
	public YandereScript Yandere;

	// Token: 0x0400266A RID: 9834
	public Transform[] Clubs;

	// Token: 0x0400266B RID: 9835
	public Transform DelinquentZone;

	// Token: 0x0400266C RID: 9836
	public Transform Library;

	// Token: 0x0400266D RID: 9837
	public Transform Kitten;

	// Token: 0x0400266E RID: 9838
	public string[] TopicNames;

	// Token: 0x0400266F RID: 9839
	public bool[] Ignore;

	// Token: 0x04002670 RID: 9840
	public int FollowerID;
}
