﻿using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000597 RID: 1431
	[RequireComponent(typeof(Animator))]
	public class Chef : MonoBehaviour
	{
		// Token: 0x17000525 RID: 1317
		// (get) Token: 0x06002449 RID: 9289 RVA: 0x001FFB04 File Offset: 0x001FDD04
		public static Chef Instance
		{
			get
			{
				if (Chef.instance == null)
				{
					Chef.instance = UnityEngine.Object.FindObjectOfType<Chef>();
				}
				return Chef.instance;
			}
		}

		// Token: 0x0600244A RID: 9290 RVA: 0x001FFB22 File Offset: 0x001FDD22
		private void Awake()
		{
			this.cookQueue = new Foods();
			this.animator = base.GetComponent<Animator>();
			this.cookMeter.gameObject.SetActive(false);
			this.isPaused = true;
		}

		// Token: 0x0600244B RID: 9291 RVA: 0x001FFB53 File Offset: 0x001FDD53
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x0600244C RID: 9292 RVA: 0x001FFB75 File Offset: 0x001FDD75
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x0600244D RID: 9293 RVA: 0x001FFB97 File Offset: 0x001FDD97
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
			this.animator.speed = (float)(this.isPaused ? 0 : 1);
		}

		// Token: 0x0600244E RID: 9294 RVA: 0x001FFBB8 File Offset: 0x001FDDB8
		public static void AddToQueue(Food foodItem)
		{
			Chef.Instance.cookQueue.Add(foodItem);
		}

		// Token: 0x0600244F RID: 9295 RVA: 0x001FFBCA File Offset: 0x001FDDCA
		public static Food GrabFromQueue()
		{
			Food result = Chef.Instance.cookQueue[0];
			Chef.Instance.cookQueue.RemoveAt(0);
			return result;
		}

		// Token: 0x06002450 RID: 9296 RVA: 0x001FFBEC File Offset: 0x001FDDEC
		private void Update()
		{
			if (this.isPaused)
			{
				return;
			}
			Chef.ChefState chefState = this.state;
			if (chefState != Chef.ChefState.Queueing)
			{
				if (chefState != Chef.ChefState.Cooking)
				{
					return;
				}
				if (this.timeToFinishDish <= 0f)
				{
					this.state = Chef.ChefState.Delivering;
					this.animator.SetTrigger("PlateCooked");
					this.cookMeter.gameObject.SetActive(false);
					return;
				}
				this.timeToFinishDish -= Time.deltaTime;
				this.cookMeter.SetFill(1f - this.timeToFinishDish / (this.currentPlate.cookTimeMultiplier * this.cookTime));
			}
			else if (this.cookQueue.Count > 0)
			{
				this.currentPlate = Chef.GrabFromQueue();
				this.timeToFinishDish = this.currentPlate.cookTimeMultiplier * this.cookTime;
				this.state = Chef.ChefState.Cooking;
				this.cookMeter.gameObject.SetActive(true);
				return;
			}
		}

		// Token: 0x06002451 RID: 9297 RVA: 0x001FFCD0 File Offset: 0x001FDED0
		public void Deliver()
		{
			UnityEngine.Object.FindObjectOfType<ServingCounter>().AddPlate(this.currentPlate);
		}

		// Token: 0x06002452 RID: 9298 RVA: 0x001FFCE2 File Offset: 0x001FDEE2
		public void Queue()
		{
			this.state = Chef.ChefState.Queueing;
		}

		// Token: 0x04004CB5 RID: 19637
		private static Chef instance;

		// Token: 0x04004CB6 RID: 19638
		[Reorderable]
		public Foods cookQueue;

		// Token: 0x04004CB7 RID: 19639
		public FoodMenu foodMenu;

		// Token: 0x04004CB8 RID: 19640
		public Meter cookMeter;

		// Token: 0x04004CB9 RID: 19641
		public float cookTime = 3f;

		// Token: 0x04004CBA RID: 19642
		private Chef.ChefState state;

		// Token: 0x04004CBB RID: 19643
		private Food currentPlate;

		// Token: 0x04004CBC RID: 19644
		private Animator animator;

		// Token: 0x04004CBD RID: 19645
		private float timeToFinishDish;

		// Token: 0x04004CBE RID: 19646
		private bool isPaused;

		// Token: 0x020006E3 RID: 1763
		public enum ChefState
		{
			// Token: 0x04005286 RID: 21126
			Queueing,
			// Token: 0x04005287 RID: 21127
			Cooking,
			// Token: 0x04005288 RID: 21128
			Delivering
		}
	}
}
