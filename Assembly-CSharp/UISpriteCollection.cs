﻿using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000AB RID: 171
[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Sprite Collection")]
public class UISpriteCollection : UIBasicSprite
{
	// Token: 0x170001C1 RID: 449
	// (get) Token: 0x06000883 RID: 2179 RVA: 0x00046140 File Offset: 0x00044340
	// (set) Token: 0x06000884 RID: 2180 RVA: 0x00046171 File Offset: 0x00044371
	public override Texture mainTexture
	{
		get
		{
			Material material = null;
			INGUIAtlas atlas = this.atlas;
			if (atlas != null)
			{
				material = atlas.spriteMaterial;
			}
			if (!(material != null))
			{
				return null;
			}
			return material.mainTexture;
		}
		set
		{
			base.mainTexture = value;
		}
	}

	// Token: 0x170001C2 RID: 450
	// (get) Token: 0x06000885 RID: 2181 RVA: 0x0004617C File Offset: 0x0004437C
	// (set) Token: 0x06000886 RID: 2182 RVA: 0x000461AD File Offset: 0x000443AD
	public override Material material
	{
		get
		{
			Material material = base.material;
			if (material != null)
			{
				return material;
			}
			INGUIAtlas atlas = this.atlas;
			if (atlas != null)
			{
				return atlas.spriteMaterial;
			}
			return null;
		}
		set
		{
			base.material = value;
		}
	}

	// Token: 0x170001C3 RID: 451
	// (get) Token: 0x06000887 RID: 2183 RVA: 0x000461B6 File Offset: 0x000443B6
	// (set) Token: 0x06000888 RID: 2184 RVA: 0x000461C3 File Offset: 0x000443C3
	public INGUIAtlas atlas
	{
		get
		{
			return this.mAtlas as INGUIAtlas;
		}
		set
		{
			if (this.mAtlas as INGUIAtlas != value)
			{
				base.RemoveFromPanel();
				this.mAtlas = (value as UnityEngine.Object);
				this.mSprites.Clear();
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x170001C4 RID: 452
	// (get) Token: 0x06000889 RID: 2185 RVA: 0x000461F8 File Offset: 0x000443F8
	public override float pixelSize
	{
		get
		{
			INGUIAtlas atlas = this.atlas;
			if (atlas != null)
			{
				return atlas.pixelSize;
			}
			return 1f;
		}
	}

	// Token: 0x170001C5 RID: 453
	// (get) Token: 0x0600088A RID: 2186 RVA: 0x0004621C File Offset: 0x0004441C
	public override bool premultipliedAlpha
	{
		get
		{
			INGUIAtlas atlas = this.atlas;
			return atlas != null && atlas.premultipliedAlpha;
		}
	}

	// Token: 0x170001C6 RID: 454
	// (get) Token: 0x0600088B RID: 2187 RVA: 0x0004623C File Offset: 0x0004443C
	public override Vector4 border
	{
		get
		{
			if (this.mSprite == null)
			{
				return base.border;
			}
			return new Vector4((float)this.mSprite.borderLeft, (float)this.mSprite.borderBottom, (float)this.mSprite.borderRight, (float)this.mSprite.borderTop);
		}
	}

	// Token: 0x170001C7 RID: 455
	// (get) Token: 0x0600088C RID: 2188 RVA: 0x00046290 File Offset: 0x00044490
	protected override Vector4 padding
	{
		get
		{
			Vector4 result = new Vector4(0f, 0f, 0f, 0f);
			if (this.mSprite != null)
			{
				result.x = (float)this.mSprite.paddingLeft;
				result.y = (float)this.mSprite.paddingBottom;
				result.z = (float)this.mSprite.paddingRight;
				result.w = (float)this.mSprite.paddingTop;
			}
			return result;
		}
	}

	// Token: 0x0600088D RID: 2189 RVA: 0x00046310 File Offset: 0x00044510
	public override void OnFill(List<Vector3> verts, List<Vector2> uvs, List<Color> cols)
	{
		Texture mainTexture = this.mainTexture;
		if (mainTexture == null)
		{
			return;
		}
		int count = verts.Count;
		Vector4 drawRegion = base.drawRegion;
		foreach (KeyValuePair<object, UISpriteCollection.Sprite> keyValuePair in this.mSprites)
		{
			UISpriteCollection.Sprite value = keyValuePair.Value;
			if (value.enabled)
			{
				this.mSprite = value.sprite;
				if (this.mSprite != null)
				{
					Color color = value.color;
					color.a = this.finalAlpha;
					if (color.a != 0f)
					{
						Rect rect = new Rect((float)this.mSprite.x, (float)this.mSprite.y, (float)this.mSprite.width, (float)this.mSprite.height);
						Rect rect2 = new Rect((float)(this.mSprite.x + this.mSprite.borderLeft), (float)(this.mSprite.y + this.mSprite.borderTop), (float)(this.mSprite.width - this.mSprite.borderLeft - this.mSprite.borderRight), (float)(this.mSprite.height - this.mSprite.borderBottom - this.mSprite.borderTop));
						this.mOuterUV = NGUIMath.ConvertToTexCoords(rect, mainTexture.width, mainTexture.height);
						this.mInnerUV = NGUIMath.ConvertToTexCoords(rect2, mainTexture.width, mainTexture.height);
						this.mFlip = value.flip;
						Vector4 drawingDimensions = value.GetDrawingDimensions(this.pixelSize);
						Vector4 drawingUVs = base.drawingUVs;
						if (this.premultipliedAlpha)
						{
							color = NGUITools.ApplyPMA(color);
						}
						int count2 = verts.Count;
						switch (value.type)
						{
						case UIBasicSprite.Type.Simple:
							base.SimpleFill(verts, uvs, cols, ref drawingDimensions, ref drawingUVs, ref color);
							break;
						case UIBasicSprite.Type.Sliced:
							base.SlicedFill(verts, uvs, cols, ref drawingDimensions, ref drawingUVs, ref color);
							break;
						case UIBasicSprite.Type.Tiled:
							base.TiledFill(verts, uvs, cols, ref drawingDimensions, ref color);
							break;
						case UIBasicSprite.Type.Filled:
							base.FilledFill(verts, uvs, cols, ref drawingDimensions, ref drawingUVs, ref color);
							break;
						case UIBasicSprite.Type.Advanced:
							base.AdvancedFill(verts, uvs, cols, ref drawingDimensions, ref drawingUVs, ref color);
							break;
						}
						if (value.rot != 0f)
						{
							float f = value.rot * 0.017453292f * 0.5f;
							float num = Mathf.Sin(f);
							float num2 = Mathf.Cos(f);
							float num3 = num * 2f;
							float num4 = num * num3;
							float num5 = num2 * num3;
							int i = count2;
							int count3 = verts.Count;
							while (i < count3)
							{
								Vector3 vector = verts[i];
								vector = new Vector3((1f - num4) * vector.x - num5 * vector.y, num5 * vector.x + (1f - num4) * vector.y, vector.z);
								vector.x += value.pos.x;
								vector.y += value.pos.y;
								verts[i] = vector;
								i++;
							}
						}
						else
						{
							int j = count2;
							int count4 = verts.Count;
							while (j < count4)
							{
								Vector3 value2 = verts[j];
								value2.x += value.pos.x;
								value2.y += value.pos.y;
								verts[j] = value2;
								j++;
							}
						}
					}
				}
			}
		}
		this.mSprite = null;
		if (this.onPostFill != null)
		{
			this.onPostFill(this, count, verts, uvs, cols);
		}
	}

	// Token: 0x0600088E RID: 2190 RVA: 0x000466EC File Offset: 0x000448EC
	public void Add(object obj, string spriteName, Vector2 pos, float width, float height)
	{
		this.AddSprite(obj, spriteName, pos, width, height, new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue), new Vector2(0.5f, 0.5f), 0f, UIBasicSprite.Type.Simple, UIBasicSprite.Flip.Nothing, true);
	}

	// Token: 0x0600088F RID: 2191 RVA: 0x00046738 File Offset: 0x00044938
	public void Add(object obj, string spriteName, Vector2 pos, float width, float height, Color32 color)
	{
		this.AddSprite(obj, spriteName, pos, width, height, color, new Vector2(0.5f, 0.5f), 0f, UIBasicSprite.Type.Simple, UIBasicSprite.Flip.Nothing, true);
	}

	// Token: 0x06000890 RID: 2192 RVA: 0x0004676C File Offset: 0x0004496C
	public void AddSprite(object id, string spriteName, Vector2 pos, float width, float height, Color32 color, Vector2 pivot, float rot = 0f, UIBasicSprite.Type type = UIBasicSprite.Type.Simple, UIBasicSprite.Flip flip = UIBasicSprite.Flip.Nothing, bool enabled = true)
	{
		if (this.mAtlas == null)
		{
			Debug.LogError("Atlas must be assigned first");
			return;
		}
		UISpriteCollection.Sprite sprite = default(UISpriteCollection.Sprite);
		INGUIAtlas atlas = this.atlas;
		if (atlas != null)
		{
			sprite.sprite = atlas.GetSprite(spriteName);
		}
		if (sprite.sprite == null)
		{
			return;
		}
		sprite.pos = pos;
		sprite.rot = rot;
		sprite.width = width;
		sprite.height = height;
		sprite.color = color;
		sprite.pivot = pivot;
		sprite.type = type;
		sprite.flip = flip;
		sprite.enabled = enabled;
		this.mSprites[id] = sprite;
		if (enabled && !this.mChanged)
		{
			this.MarkAsChanged();
		}
	}

	// Token: 0x06000891 RID: 2193 RVA: 0x0004682C File Offset: 0x00044A2C
	public UISpriteCollection.Sprite? GetSprite(object id)
	{
		UISpriteCollection.Sprite value;
		if (this.mSprites.TryGetValue(id, out value))
		{
			return new UISpriteCollection.Sprite?(value);
		}
		return null;
	}

	// Token: 0x06000892 RID: 2194 RVA: 0x00046859 File Offset: 0x00044A59
	public bool RemoveSprite(object id)
	{
		if (this.mSprites.Remove(id))
		{
			if (!this.mChanged)
			{
				this.MarkAsChanged();
			}
			return true;
		}
		return false;
	}

	// Token: 0x06000893 RID: 2195 RVA: 0x0004687A File Offset: 0x00044A7A
	public bool SetSprite(object id, UISpriteCollection.Sprite sp)
	{
		this.mSprites[id] = sp;
		if (!this.mChanged)
		{
			this.MarkAsChanged();
		}
		return true;
	}

	// Token: 0x06000894 RID: 2196 RVA: 0x00046898 File Offset: 0x00044A98
	[ContextMenu("Clear")]
	public void Clear()
	{
		if (this.mSprites.Count != 0)
		{
			this.mSprites.Clear();
			this.MarkAsChanged();
		}
	}

	// Token: 0x06000895 RID: 2197 RVA: 0x000468B8 File Offset: 0x00044AB8
	public bool IsActive(object id)
	{
		UISpriteCollection.Sprite sprite;
		return this.mSprites.TryGetValue(id, out sprite) && sprite.enabled;
	}

	// Token: 0x06000896 RID: 2198 RVA: 0x000468E0 File Offset: 0x00044AE0
	public bool SetActive(object id, bool visible)
	{
		UISpriteCollection.Sprite sprite;
		if (this.mSprites.TryGetValue(id, out sprite))
		{
			if (sprite.enabled != visible)
			{
				sprite.enabled = visible;
				this.mSprites[id] = sprite;
				if (!this.mChanged)
				{
					this.MarkAsChanged();
				}
			}
			return true;
		}
		return false;
	}

	// Token: 0x06000897 RID: 2199 RVA: 0x0004692C File Offset: 0x00044B2C
	public bool SetPosition(object id, Vector2 pos, bool visible = true)
	{
		UISpriteCollection.Sprite sprite;
		if (this.mSprites.TryGetValue(id, out sprite))
		{
			if (sprite.pos != pos)
			{
				sprite.pos = pos;
				sprite.enabled = visible;
				this.mSprites[id] = sprite;
				if (!this.mChanged)
				{
					this.MarkAsChanged();
				}
			}
			else if (sprite.enabled != visible)
			{
				sprite.enabled = visible;
				this.mSprites[id] = sprite;
				if (!this.mChanged)
				{
					this.MarkAsChanged();
				}
			}
			return true;
		}
		return false;
	}

	// Token: 0x06000898 RID: 2200 RVA: 0x000469B4 File Offset: 0x00044BB4
	private static Vector2 Rotate(Vector2 pos, float rot)
	{
		float f = rot * 0.017453292f * 0.5f;
		float num = Mathf.Sin(f);
		float num2 = Mathf.Cos(f);
		float num3 = num * 2f;
		float num4 = num * num3;
		float num5 = num2 * num3;
		return new Vector2((1f - num4) * pos.x - num5 * pos.y, num5 * pos.x + (1f - num4) * pos.y);
	}

	// Token: 0x06000899 RID: 2201 RVA: 0x00046A1C File Offset: 0x00044C1C
	public object GetCurrentSpriteID()
	{
		return this.GetCurrentSpriteID(UICamera.lastWorldPosition);
	}

	// Token: 0x0600089A RID: 2202 RVA: 0x00046A29 File Offset: 0x00044C29
	public UISpriteCollection.Sprite? GetCurrentSprite()
	{
		return this.GetCurrentSprite(UICamera.lastWorldPosition);
	}

	// Token: 0x0600089B RID: 2203 RVA: 0x00046A38 File Offset: 0x00044C38
	public object GetCurrentSpriteID(Vector3 worldPos)
	{
		Vector2 a = this.mTrans.InverseTransformPoint(worldPos);
		foreach (KeyValuePair<object, UISpriteCollection.Sprite> keyValuePair in this.mSprites)
		{
			UISpriteCollection.Sprite value = keyValuePair.Value;
			Vector2 vector = a - value.pos;
			if (value.rot != 0f)
			{
				vector = UISpriteCollection.Rotate(vector, -value.rot);
			}
			Vector4 drawingDimensions = value.GetDrawingDimensions(this.pixelSize);
			if (vector.x >= drawingDimensions.x && vector.y >= drawingDimensions.y && vector.x <= drawingDimensions.z && vector.y <= drawingDimensions.w)
			{
				return keyValuePair.Key;
			}
		}
		return null;
	}

	// Token: 0x0600089C RID: 2204 RVA: 0x00046B30 File Offset: 0x00044D30
	public UISpriteCollection.Sprite? GetCurrentSprite(Vector3 worldPos)
	{
		Vector2 a = this.mTrans.InverseTransformPoint(worldPos);
		foreach (KeyValuePair<object, UISpriteCollection.Sprite> keyValuePair in this.mSprites)
		{
			UISpriteCollection.Sprite value = keyValuePair.Value;
			Vector2 vector = a - value.pos;
			if (value.rot != 0f)
			{
				vector = UISpriteCollection.Rotate(vector, -value.rot);
			}
			Vector4 drawingDimensions = value.GetDrawingDimensions(this.pixelSize);
			if (vector.x >= drawingDimensions.x && vector.y >= drawingDimensions.y && vector.x <= drawingDimensions.z && vector.y <= drawingDimensions.w)
			{
				return new UISpriteCollection.Sprite?(keyValuePair.Value);
			}
		}
		return null;
	}

	// Token: 0x0600089D RID: 2205 RVA: 0x00046C34 File Offset: 0x00044E34
	protected void OnClick()
	{
		if (this.onClick != null)
		{
			object currentSpriteID = this.GetCurrentSpriteID();
			if (currentSpriteID != null)
			{
				this.onClick(currentSpriteID);
			}
		}
	}

	// Token: 0x0600089E RID: 2206 RVA: 0x00046C60 File Offset: 0x00044E60
	protected void OnPress(bool isPressed)
	{
		if (this.onPress != null)
		{
			if (isPressed && this.mLastPress != null)
			{
				return;
			}
			if (isPressed)
			{
				this.mLastPress = this.GetCurrentSpriteID();
				if (this.mLastPress != null)
				{
					this.onPress(this.mLastPress, true);
					return;
				}
			}
			else if (this.mLastPress != null)
			{
				this.onPress(this.mLastPress, false);
				this.mLastPress = null;
			}
		}
	}

	// Token: 0x0600089F RID: 2207 RVA: 0x00046CCC File Offset: 0x00044ECC
	protected void OnHover(bool isOver)
	{
		if (this.onHover != null)
		{
			if (isOver)
			{
				UICamera.onMouseMove = (UICamera.MoveDelegate)Delegate.Combine(UICamera.onMouseMove, new UICamera.MoveDelegate(this.OnMove));
				this.OnMove(Vector2.zero);
				return;
			}
			UICamera.onMouseMove = (UICamera.MoveDelegate)Delegate.Remove(UICamera.onMouseMove, new UICamera.MoveDelegate(this.OnMove));
		}
	}

	// Token: 0x060008A0 RID: 2208 RVA: 0x00046D30 File Offset: 0x00044F30
	protected void OnMove(Vector2 delta)
	{
		if (!this || this.onHover == null)
		{
			return;
		}
		object currentSpriteID = this.GetCurrentSpriteID();
		if (this.mLastHover != currentSpriteID)
		{
			if (this.mLastHover != null)
			{
				this.onHover(this.mLastHover, false);
			}
			this.mLastHover = currentSpriteID;
			if (this.mLastHover != null)
			{
				this.onHover(this.mLastHover, true);
			}
		}
	}

	// Token: 0x060008A1 RID: 2209 RVA: 0x00046D99 File Offset: 0x00044F99
	protected void OnDrag(Vector2 delta)
	{
		if (this.onDrag != null && this.mLastPress != null)
		{
			this.onDrag(this.mLastPress, delta);
		}
	}

	// Token: 0x060008A2 RID: 2210 RVA: 0x00046DC0 File Offset: 0x00044FC0
	protected void OnTooltip(bool show)
	{
		if (this.onTooltip != null)
		{
			if (show)
			{
				if (this.mLastTooltip != null)
				{
					this.onTooltip(this.mLastTooltip, false);
				}
				this.mLastTooltip = this.GetCurrentSpriteID();
				if (this.mLastTooltip != null)
				{
					this.onTooltip(this.mLastTooltip, true);
					return;
				}
			}
			else
			{
				this.onTooltip(this.mLastTooltip, false);
				this.mLastTooltip = null;
			}
		}
	}

	// Token: 0x0400076A RID: 1898
	[HideInInspector]
	[SerializeField]
	private UnityEngine.Object mAtlas;

	// Token: 0x0400076B RID: 1899
	[NonSerialized]
	private Dictionary<object, UISpriteCollection.Sprite> mSprites = new Dictionary<object, UISpriteCollection.Sprite>();

	// Token: 0x0400076C RID: 1900
	[NonSerialized]
	private UISpriteData mSprite;

	// Token: 0x0400076D RID: 1901
	public UISpriteCollection.OnHoverCB onHover;

	// Token: 0x0400076E RID: 1902
	public UISpriteCollection.OnPressCB onPress;

	// Token: 0x0400076F RID: 1903
	public UISpriteCollection.OnClickCB onClick;

	// Token: 0x04000770 RID: 1904
	public UISpriteCollection.OnDragCB onDrag;

	// Token: 0x04000771 RID: 1905
	public UISpriteCollection.OnTooltipCB onTooltip;

	// Token: 0x04000772 RID: 1906
	[NonSerialized]
	private object mLastHover;

	// Token: 0x04000773 RID: 1907
	[NonSerialized]
	private object mLastPress;

	// Token: 0x04000774 RID: 1908
	[NonSerialized]
	private object mLastTooltip;

	// Token: 0x02000647 RID: 1607
	public struct Sprite
	{
		// Token: 0x06002640 RID: 9792 RVA: 0x002022F4 File Offset: 0x002004F4
		public Vector4 GetDrawingDimensions(float pixelSize)
		{
			float num = -this.pivot.x * this.width;
			float num2 = -this.pivot.y * this.height;
			float num3 = num + this.width;
			float num4 = num2 + this.height;
			if (this.sprite != null && this.type != UIBasicSprite.Type.Tiled)
			{
				int num5 = this.sprite.paddingLeft;
				int num6 = this.sprite.paddingBottom;
				int num7 = this.sprite.paddingRight;
				int num8 = this.sprite.paddingTop;
				if (this.type != UIBasicSprite.Type.Simple && pixelSize != 1f)
				{
					num5 = Mathf.RoundToInt(pixelSize * (float)num5);
					num6 = Mathf.RoundToInt(pixelSize * (float)num6);
					num7 = Mathf.RoundToInt(pixelSize * (float)num7);
					num8 = Mathf.RoundToInt(pixelSize * (float)num8);
				}
				int num9 = this.sprite.width + num5 + num7;
				int num10 = this.sprite.height + num6 + num8;
				float num11 = 1f;
				float num12 = 1f;
				if (num9 > 0 && num10 > 0 && (this.type == UIBasicSprite.Type.Simple || this.type == UIBasicSprite.Type.Filled))
				{
					if ((num9 & 1) != 0)
					{
						num7++;
					}
					if ((num10 & 1) != 0)
					{
						num8++;
					}
					num11 = 1f / (float)num9 * this.width;
					num12 = 1f / (float)num10 * this.height;
				}
				if (this.flip == UIBasicSprite.Flip.Horizontally || this.flip == UIBasicSprite.Flip.Both)
				{
					num += (float)num7 * num11;
					num3 -= (float)num5 * num11;
				}
				else
				{
					num += (float)num5 * num11;
					num3 -= (float)num7 * num11;
				}
				if (this.flip == UIBasicSprite.Flip.Vertically || this.flip == UIBasicSprite.Flip.Both)
				{
					num2 += (float)num8 * num12;
					num4 -= (float)num6 * num12;
				}
				else
				{
					num2 += (float)num6 * num12;
					num4 -= (float)num8 * num12;
				}
			}
			return new Vector4(num, num2, num3, num4);
		}

		// Token: 0x04004F34 RID: 20276
		public UISpriteData sprite;

		// Token: 0x04004F35 RID: 20277
		public Vector2 pos;

		// Token: 0x04004F36 RID: 20278
		public float rot;

		// Token: 0x04004F37 RID: 20279
		public float width;

		// Token: 0x04004F38 RID: 20280
		public float height;

		// Token: 0x04004F39 RID: 20281
		public Color32 color;

		// Token: 0x04004F3A RID: 20282
		public Vector2 pivot;

		// Token: 0x04004F3B RID: 20283
		public UIBasicSprite.Type type;

		// Token: 0x04004F3C RID: 20284
		public UIBasicSprite.Flip flip;

		// Token: 0x04004F3D RID: 20285
		public bool enabled;
	}

	// Token: 0x02000648 RID: 1608
	// (Invoke) Token: 0x06002642 RID: 9794
	public delegate void OnHoverCB(object obj, bool isOver);

	// Token: 0x02000649 RID: 1609
	// (Invoke) Token: 0x06002646 RID: 9798
	public delegate void OnPressCB(object obj, bool isPressed);

	// Token: 0x0200064A RID: 1610
	// (Invoke) Token: 0x0600264A RID: 9802
	public delegate void OnClickCB(object obj);

	// Token: 0x0200064B RID: 1611
	// (Invoke) Token: 0x0600264E RID: 9806
	public delegate void OnDragCB(object obj, Vector2 delta);

	// Token: 0x0200064C RID: 1612
	// (Invoke) Token: 0x06002652 RID: 9810
	public delegate void OnTooltipCB(object obj, bool show);
}
