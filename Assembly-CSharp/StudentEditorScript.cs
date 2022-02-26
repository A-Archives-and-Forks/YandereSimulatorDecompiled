﻿using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x0200029C RID: 668
public class StudentEditorScript : MonoBehaviour
{
	// Token: 0x06001406 RID: 5126 RVA: 0x000BDDCC File Offset: 0x000BBFCC
	private void Awake()
	{
		Dictionary<string, object>[] array = EditorManagerScript.DeserializeJson("Students.json");
		this.students = new StudentEditorScript.StudentData[array.Length];
		for (int i = 0; i < this.students.Length; i++)
		{
			this.students[i] = StudentEditorScript.StudentData.Deserialize(array[i]);
		}
		Array.Sort<StudentEditorScript.StudentData>(this.students, (StudentEditorScript.StudentData a, StudentEditorScript.StudentData b) => a.id - b.id);
		for (int j = 0; j < this.students.Length; j++)
		{
			StudentEditorScript.StudentData studentData = this.students[j];
			UILabel uilabel = UnityEngine.Object.Instantiate<UILabel>(this.studentLabelTemplate, this.listLabelsOrigin);
			uilabel.text = "(" + studentData.id.ToString() + ") " + studentData.name;
			Transform transform = uilabel.transform;
			transform.localPosition = new Vector3(transform.localPosition.x + (float)(uilabel.width / 2), transform.localPosition.y - (float)(j * uilabel.height), transform.localPosition.z);
			uilabel.gameObject.SetActive(true);
		}
		this.studentIndex = 0;
		this.bodyLabel.text = StudentEditorScript.GetStudentText(this.students[this.studentIndex]);
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x06001407 RID: 5127 RVA: 0x000BDF26 File Offset: 0x000BC126
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x06001408 RID: 5128 RVA: 0x000BDF64 File Offset: 0x000BC164
	private static ScheduleBlock[] DeserializeScheduleBlocks(Dictionary<string, object> dict)
	{
		string[] array = TFUtils.LoadString(dict, "ScheduleTime").Split(new char[]
		{
			'_'
		});
		string[] array2 = TFUtils.LoadString(dict, "ScheduleDestination").Split(new char[]
		{
			'_'
		});
		string[] array3 = TFUtils.LoadString(dict, "ScheduleAction").Split(new char[]
		{
			'_'
		});
		ScheduleBlock[] array4 = new ScheduleBlock[array.Length];
		for (int i = 0; i < array4.Length; i++)
		{
			array4[i] = new ScheduleBlock(float.Parse(array[i]), array2[i], array3[i]);
		}
		return array4;
	}

	// Token: 0x06001409 RID: 5129 RVA: 0x000BDFFC File Offset: 0x000BC1FC
	private static string GetStudentText(StudentEditorScript.StudentData data)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(data.name + " (" + data.id.ToString() + "):\n");
		stringBuilder.Append("- Gender: " + (data.isMale ? "Male" : "Female") + "\n");
		stringBuilder.Append("- Class: " + data.attendanceInfo.classNumber.ToString() + "\n");
		stringBuilder.Append("- Seat: " + data.attendanceInfo.seatNumber.ToString() + "\n");
		stringBuilder.Append("- Club: " + data.attendanceInfo.club.ToString() + "\n");
		stringBuilder.Append("- Persona: " + data.personality.persona.ToString() + "\n");
		stringBuilder.Append("- Crush: " + data.personality.crush.ToString() + "\n");
		stringBuilder.Append("- Breast size: " + data.cosmetics.breastSize.ToString() + "\n");
		stringBuilder.Append("- Strength: " + data.stats.strength.ToString() + "\n");
		stringBuilder.Append("- Hairstyle: " + data.cosmetics.hairstyle + "\n");
		stringBuilder.Append("- Color: " + data.cosmetics.color + "\n");
		stringBuilder.Append("- Eyes: " + data.cosmetics.eyes + "\n");
		stringBuilder.Append("- Stockings: " + data.cosmetics.stockings + "\n");
		stringBuilder.Append("- Accessory: " + data.cosmetics.accessory + "\n");
		stringBuilder.Append("- Schedule blocks: ");
		foreach (ScheduleBlock scheduleBlock in data.scheduleBlocks)
		{
			stringBuilder.Append(string.Concat(new string[]
			{
				"[",
				scheduleBlock.time.ToString(),
				", ",
				scheduleBlock.destination,
				", ",
				scheduleBlock.action,
				"]"
			}));
		}
		stringBuilder.Append("\n");
		stringBuilder.Append("- Info: \"" + data.info + "\"\n");
		return stringBuilder.ToString();
	}

	// Token: 0x0600140A RID: 5130 RVA: 0x000BE2BC File Offset: 0x000BC4BC
	private void HandleInput()
	{
		if (Input.GetButtonDown("B"))
		{
			this.mainPanel.gameObject.SetActive(true);
			this.studentPanel.gameObject.SetActive(false);
		}
		int num = 0;
		int num2 = this.students.Length - 1;
		bool tappedUp = this.inputManager.TappedUp;
		bool tappedDown = this.inputManager.TappedDown;
		if (tappedUp)
		{
			this.studentIndex = ((this.studentIndex > num) ? (this.studentIndex - 1) : num2);
		}
		else if (tappedDown)
		{
			this.studentIndex = ((this.studentIndex < num2) ? (this.studentIndex + 1) : num);
		}
		if (tappedUp || tappedDown)
		{
			this.bodyLabel.text = StudentEditorScript.GetStudentText(this.students[this.studentIndex]);
		}
	}

	// Token: 0x0600140B RID: 5131 RVA: 0x000BE378 File Offset: 0x000BC578
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DCE RID: 7630
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DCF RID: 7631
	[SerializeField]
	private UIPanel studentPanel;

	// Token: 0x04001DD0 RID: 7632
	[SerializeField]
	private UILabel bodyLabel;

	// Token: 0x04001DD1 RID: 7633
	[SerializeField]
	private Transform listLabelsOrigin;

	// Token: 0x04001DD2 RID: 7634
	[SerializeField]
	private UILabel studentLabelTemplate;

	// Token: 0x04001DD3 RID: 7635
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DD4 RID: 7636
	private StudentEditorScript.StudentData[] students;

	// Token: 0x04001DD5 RID: 7637
	private int studentIndex;

	// Token: 0x04001DD6 RID: 7638
	private InputManagerScript inputManager;

	// Token: 0x02000659 RID: 1625
	private class StudentAttendanceInfo
	{
		// Token: 0x06002638 RID: 9784 RVA: 0x001FEC2D File Offset: 0x001FCE2D
		public static StudentEditorScript.StudentAttendanceInfo Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentAttendanceInfo
			{
				classNumber = TFUtils.LoadInt(dict, "Class"),
				seatNumber = TFUtils.LoadInt(dict, "Seat"),
				club = TFUtils.LoadInt(dict, "Club")
			};
		}

		// Token: 0x04004F32 RID: 20274
		public int classNumber;

		// Token: 0x04004F33 RID: 20275
		public int seatNumber;

		// Token: 0x04004F34 RID: 20276
		public int club;
	}

	// Token: 0x0200065A RID: 1626
	private class StudentPersonality
	{
		// Token: 0x0600263A RID: 9786 RVA: 0x001FEC6F File Offset: 0x001FCE6F
		public static StudentEditorScript.StudentPersonality Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentPersonality
			{
				persona = (PersonaType)TFUtils.LoadInt(dict, "Persona"),
				crush = TFUtils.LoadInt(dict, "Crush")
			};
		}

		// Token: 0x04004F35 RID: 20277
		public PersonaType persona;

		// Token: 0x04004F36 RID: 20278
		public int crush;
	}

	// Token: 0x0200065B RID: 1627
	private class StudentStats
	{
		// Token: 0x0600263C RID: 9788 RVA: 0x001FECA0 File Offset: 0x001FCEA0
		public static StudentEditorScript.StudentStats Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentStats
			{
				strength = TFUtils.LoadInt(dict, "Strength")
			};
		}

		// Token: 0x04004F37 RID: 20279
		public int strength;
	}

	// Token: 0x0200065C RID: 1628
	private class StudentCosmetics
	{
		// Token: 0x0600263E RID: 9790 RVA: 0x001FECC0 File Offset: 0x001FCEC0
		public static StudentEditorScript.StudentCosmetics Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentCosmetics
			{
				breastSize = TFUtils.LoadFloat(dict, "BreastSize"),
				hairstyle = TFUtils.LoadString(dict, "Hairstyle"),
				color = TFUtils.LoadString(dict, "Color"),
				eyes = TFUtils.LoadString(dict, "Eyes"),
				stockings = TFUtils.LoadString(dict, "Stockings"),
				accessory = TFUtils.LoadString(dict, "Accessory")
			};
		}

		// Token: 0x04004F38 RID: 20280
		public float breastSize;

		// Token: 0x04004F39 RID: 20281
		public string hairstyle;

		// Token: 0x04004F3A RID: 20282
		public string color;

		// Token: 0x04004F3B RID: 20283
		public string eyes;

		// Token: 0x04004F3C RID: 20284
		public string stockings;

		// Token: 0x04004F3D RID: 20285
		public string accessory;
	}

	// Token: 0x0200065D RID: 1629
	private class StudentData
	{
		// Token: 0x06002640 RID: 9792 RVA: 0x001FED40 File Offset: 0x001FCF40
		public static StudentEditorScript.StudentData Deserialize(Dictionary<string, object> dict)
		{
			return new StudentEditorScript.StudentData
			{
				id = TFUtils.LoadInt(dict, "ID"),
				name = TFUtils.LoadString(dict, "Name"),
				isMale = (TFUtils.LoadInt(dict, "Gender") == 1),
				attendanceInfo = StudentEditorScript.StudentAttendanceInfo.Deserialize(dict),
				personality = StudentEditorScript.StudentPersonality.Deserialize(dict),
				stats = StudentEditorScript.StudentStats.Deserialize(dict),
				cosmetics = StudentEditorScript.StudentCosmetics.Deserialize(dict),
				scheduleBlocks = StudentEditorScript.DeserializeScheduleBlocks(dict),
				info = TFUtils.LoadString(dict, "Info")
			};
		}

		// Token: 0x04004F3E RID: 20286
		public int id;

		// Token: 0x04004F3F RID: 20287
		public string name;

		// Token: 0x04004F40 RID: 20288
		public bool isMale;

		// Token: 0x04004F41 RID: 20289
		public StudentEditorScript.StudentAttendanceInfo attendanceInfo;

		// Token: 0x04004F42 RID: 20290
		public StudentEditorScript.StudentPersonality personality;

		// Token: 0x04004F43 RID: 20291
		public StudentEditorScript.StudentStats stats;

		// Token: 0x04004F44 RID: 20292
		public StudentEditorScript.StudentCosmetics cosmetics;

		// Token: 0x04004F45 RID: 20293
		public ScheduleBlock[] scheduleBlocks;

		// Token: 0x04004F46 RID: 20294
		public string info;
	}
}
