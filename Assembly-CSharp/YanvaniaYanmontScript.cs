﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004F0 RID: 1264
[RequireComponent(typeof(CharacterController))]
public class YanvaniaYanmontScript : MonoBehaviour
{
	// Token: 0x060020F1 RID: 8433 RVA: 0x001E5F5C File Offset: 0x001E415C
	private void Awake()
	{
		this.MyAnimation = this.Character.GetComponent<Animation>();
		this.MyAnimation[this.DeathAnim].speed = 0.25f;
		this.MyAnimation[this.AttackAnim].speed = 2f;
		this.MyAnimation[this.CrouchAttackAnim].speed = 2f;
		this.MyAnimation[this.WalkAnim].speed = 2.5f;
		this.MyAnimation[this.WhipNeutralAnim].speed = 0f;
		this.MyAnimation[this.WhipUpAnim].speed = 0f;
		this.MyAnimation[this.WhipRightAnim].speed = 0f;
		this.MyAnimation[this.WhipDownAnim].speed = 0f;
		this.MyAnimation[this.WhipLeftAnim].speed = 0f;
		this.MyAnimation[this.CrouchPoseAnim].layer = 1;
		this.MyAnimation.Play(this.CrouchPoseAnim);
		this.MyAnimation[this.CrouchPoseAnim].weight = 0f;
		Physics.IgnoreLayerCollision(19, 13, true);
		Physics.IgnoreLayerCollision(19, 19, true);
	}

	// Token: 0x060020F2 RID: 8434 RVA: 0x001E60C8 File Offset: 0x001E42C8
	private void Start()
	{
		this.WhipChain[0].transform.localScale = Vector3.zero;
		this.MyAnimation.Play(this.IdleAnim);
		this.controller = base.GetComponent<CharacterController>();
		this.myTransform = base.transform;
		this.speed = this.walkSpeed;
		this.rayDistance = this.controller.height * 0.5f + this.controller.radius;
		this.slideLimit = this.controller.slopeLimit - 0.1f;
		this.jumpTimer = this.antiBunnyHopFactor;
		this.originalThreshold = this.fallingDamageThreshold;
	}

	// Token: 0x060020F3 RID: 8435 RVA: 0x001E6174 File Offset: 0x001E4374
	private void FixedUpdate()
	{
		if (this.CanMove)
		{
			if (!this.Injured)
			{
				if (!this.Cutscene)
				{
					if (this.grounded)
					{
						if (!this.Attacking)
						{
							if (!this.Crouching)
							{
								if (Input.GetAxis("VaniaHorizontal") > 0f)
								{
									this.inputX = 1f;
								}
								else if (Input.GetAxis("VaniaHorizontal") < 0f)
								{
									this.inputX = -1f;
								}
								else
								{
									this.inputX = 0f;
								}
							}
						}
						else if (this.grounded)
						{
							this.fallingDamageThreshold = 100f;
							this.moveDirection.x = 0f;
							this.inputX = 0f;
							this.speed = 0f;
						}
					}
					else if (Input.GetAxis("VaniaHorizontal") != 0f)
					{
						if (Input.GetAxis("VaniaHorizontal") > 0f)
						{
							this.inputX = 1f;
						}
						else if (Input.GetAxis("VaniaHorizontal") < 0f)
						{
							this.inputX = -1f;
						}
						else
						{
							this.inputX = 0f;
						}
					}
					else
					{
						this.inputX = Mathf.MoveTowards(this.inputX, 0f, Time.deltaTime * 10f);
					}
					float num = 0f;
					float num2 = (this.inputX != 0f && num != 0f && this.limitDiagonalSpeed) ? 0.70710677f : 1f;
					if (!this.Attacking)
					{
						if (Input.GetAxis("VaniaHorizontal") < 0f)
						{
							this.Character.transform.localEulerAngles = new Vector3(this.Character.transform.localEulerAngles.x, -90f, this.Character.transform.localEulerAngles.z);
							this.Character.transform.localScale = new Vector3(-1f, this.Character.transform.localScale.y, this.Character.transform.localScale.z);
						}
						else if (Input.GetAxis("VaniaHorizontal") > 0f)
						{
							this.Character.transform.localEulerAngles = new Vector3(this.Character.transform.localEulerAngles.x, 90f, this.Character.transform.localEulerAngles.z);
							this.Character.transform.localScale = new Vector3(1f, this.Character.transform.localScale.y, this.Character.transform.localScale.z);
						}
					}
					if (this.grounded)
					{
						if (!this.Attacking && !this.Dangling)
						{
							if (Input.GetAxis("VaniaVertical") < -0.5f)
							{
								this.MyController.center = new Vector3(this.MyController.center.x, 0.5f, this.MyController.center.z);
								this.MyController.height = 1f;
								this.Crouching = true;
								this.IdleTimer = 10f;
								this.inputX = 0f;
							}
							if (this.Crouching)
							{
								this.MyAnimation.CrossFade(this.CrouchAnim, 0.1f);
								if (!this.Attacking)
								{
									if (!this.Dangling)
									{
										if (Input.GetAxis("VaniaVertical") > -0.5f)
										{
											this.MyAnimation[this.CrouchPoseAnim].weight = 0f;
											this.MyController.center = new Vector3(this.MyController.center.x, 0.75f, this.MyController.center.z);
											this.MyController.height = 1.5f;
											this.Crouching = false;
										}
									}
									else if (Input.GetAxis("VaniaVertical") > -0.5f && Input.GetButton("X"))
									{
										this.MyAnimation[this.CrouchPoseAnim].weight = 0f;
										this.MyController.center = new Vector3(this.MyController.center.x, 0.75f, this.MyController.center.z);
										this.MyController.height = 1.5f;
										this.Crouching = false;
									}
								}
							}
							else if (this.inputX == 0f)
							{
								if (this.IdleTimer > 0f)
								{
									this.MyAnimation.CrossFade(this.IdleAnim, 0.1f);
									this.MyAnimation[this.IdleAnim].speed = this.IdleTimer / 10f;
								}
								else
								{
									this.MyAnimation.CrossFade(this.DramaticIdleAnim, 1f);
								}
								this.IdleTimer -= Time.deltaTime;
							}
							else
							{
								this.IdleTimer = 10f;
								this.MyAnimation.CrossFade((this.speed == this.walkSpeed) ? this.WalkAnim : this.RunAnim, 0.1f);
							}
						}
						bool flag = false;
						if (Physics.Raycast(this.myTransform.position, -Vector3.up, out this.hit, this.rayDistance))
						{
							if (Vector3.Angle(this.hit.normal, Vector3.up) > this.slideLimit)
							{
								flag = true;
							}
						}
						else
						{
							Physics.Raycast(this.contactPoint + Vector3.up, -Vector3.up, out this.hit);
							if (Vector3.Angle(this.hit.normal, Vector3.up) > this.slideLimit)
							{
								flag = true;
							}
						}
						if (this.falling)
						{
							this.falling = false;
							if (this.myTransform.position.y < this.fallStartLevel - this.fallingDamageThreshold)
							{
								this.FallingDamageAlert(this.fallStartLevel - this.myTransform.position.y);
							}
							this.fallingDamageThreshold = this.originalThreshold;
						}
						if (!this.toggleRun)
						{
							this.speed = (Input.GetKey(KeyCode.LeftShift) ? this.runSpeed : this.walkSpeed);
						}
						if ((flag && this.slideWhenOverSlopeLimit) || (this.slideOnTaggedObjects && this.hit.collider.tag == "Slide"))
						{
							Vector3 normal = this.hit.normal;
							this.moveDirection = new Vector3(normal.x, -normal.y, normal.z);
							Vector3.OrthoNormalize(ref normal, ref this.moveDirection);
							this.moveDirection *= this.slideSpeed;
							this.playerControl = false;
						}
						else
						{
							this.moveDirection = new Vector3(this.inputX * num2, -this.antiBumpFactor, num * num2);
							this.moveDirection = this.myTransform.TransformDirection(this.moveDirection) * this.speed;
							this.playerControl = true;
						}
						if (!Input.GetButton("VaniaJump"))
						{
							this.jumpTimer++;
						}
						else if (this.jumpTimer >= this.antiBunnyHopFactor && !this.Attacking)
						{
							this.Crouching = false;
							this.fallingDamageThreshold = 0f;
							this.moveDirection.y = this.jumpSpeed;
							this.IdleTimer = 10f;
							this.jumpTimer = 0;
							AudioSource component = base.GetComponent<AudioSource>();
							component.clip = this.Voices[UnityEngine.Random.Range(0, this.Voices.Length)];
							component.Play();
						}
					}
					else
					{
						if (!this.Attacking)
						{
							this.MyAnimation.CrossFade((base.transform.position.y > this.PreviousY) ? this.JumpAnim : this.FallAnim, 0.4f);
						}
						this.PreviousY = base.transform.position.y;
						if (!this.falling)
						{
							this.falling = true;
							this.fallStartLevel = this.myTransform.position.y;
						}
						if (this.airControl && this.playerControl)
						{
							this.moveDirection.x = this.inputX * this.speed * num2;
							this.moveDirection.z = num * this.speed * num2;
							this.moveDirection = this.myTransform.TransformDirection(this.moveDirection);
						}
					}
				}
				else
				{
					this.moveDirection.x = 0f;
					if (this.grounded)
					{
						if (base.transform.position.x > -34f)
						{
							this.Character.transform.localEulerAngles = new Vector3(this.Character.transform.localEulerAngles.x, -90f, this.Character.transform.localEulerAngles.z);
							this.Character.transform.localScale = new Vector3(1f, this.Character.transform.localScale.y, this.Character.transform.localScale.z);
							base.transform.position = new Vector3(Mathf.MoveTowards(base.transform.position.x, -34f, Time.deltaTime * this.walkSpeed), base.transform.position.y, base.transform.position.z);
							this.MyAnimation.CrossFade(this.WalkAnim);
						}
						else if (base.transform.position.x < -34f)
						{
							this.Character.transform.localEulerAngles = new Vector3(this.Character.transform.localEulerAngles.x, 90f, this.Character.transform.localEulerAngles.z);
							this.Character.transform.localScale = new Vector3(-1f, this.Character.transform.localScale.y, this.Character.transform.localScale.z);
							base.transform.position = new Vector3(Mathf.MoveTowards(base.transform.position.x, -34f, Time.deltaTime * this.walkSpeed), base.transform.position.y, base.transform.position.z);
							this.MyAnimation.CrossFade(this.WalkAnim);
						}
						else
						{
							this.MyAnimation.CrossFade(this.DramaticIdleAnim, 1f);
							this.Character.transform.localEulerAngles = new Vector3(this.Character.transform.localEulerAngles.x, -90f, this.Character.transform.localEulerAngles.z);
							this.Character.transform.localScale = new Vector3(1f, this.Character.transform.localScale.y, this.Character.transform.localScale.z);
							this.WhipChain[0].transform.localScale = Vector3.zero;
							this.fallingDamageThreshold = 100f;
							this.TextBox.SetActive(true);
							this.Attacking = false;
							base.enabled = false;
						}
					}
					Physics.SyncTransforms();
				}
			}
			else
			{
				this.MyAnimation.CrossFade("f02_damage_25");
				this.RecoveryTimer += Time.deltaTime;
				if (this.RecoveryTimer > 1f)
				{
					this.RecoveryTimer = 0f;
					this.Injured = false;
				}
			}
			this.moveDirection.y = this.moveDirection.y - this.gravity * Time.deltaTime;
			this.grounded = ((this.controller.Move(this.moveDirection * Time.deltaTime) & CollisionFlags.Below) > CollisionFlags.None);
			if (this.grounded && this.EnterCutscene)
			{
				this.YanvaniaCamera.Cutscene = true;
				this.Cutscene = true;
			}
			if ((this.controller.collisionFlags & CollisionFlags.Above) != CollisionFlags.None && this.moveDirection.y > 0f)
			{
				this.moveDirection.y = 0f;
				return;
			}
		}
		else if (this.Health == 0f)
		{
			this.DeathTimer += Time.deltaTime;
			if (this.DeathTimer > 5f)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime * 0.2f);
				if (this.Darkness.color.a >= 1f)
				{
					if (this.Darkness.gameObject.activeInHierarchy)
					{
						this.HealthBar.parent.gameObject.SetActive(false);
						this.EXPBar.parent.gameObject.SetActive(false);
						this.Darkness.gameObject.SetActive(false);
						this.BossHealthBar.SetActive(false);
						this.BlackBG.SetActive(true);
					}
					this.TryAgainWindow.transform.localScale = Vector3.Lerp(this.TryAgainWindow.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				}
			}
		}
	}

	// Token: 0x060020F4 RID: 8436 RVA: 0x001E6F6C File Offset: 0x001E516C
	private void Update()
	{
		Animation component = this.Character.GetComponent<Animation>();
		if (!this.Injured && this.CanMove && !this.Cutscene)
		{
			if (this.grounded)
			{
				if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
				{
					this.TapTimer = 0.25f;
					this.Taps++;
				}
				if (this.Taps > 1)
				{
					this.speed = this.runSpeed;
				}
			}
			if (this.inputX == 0f)
			{
				this.speed = this.walkSpeed;
			}
			this.TapTimer -= Time.deltaTime;
			if (this.TapTimer < 0f)
			{
				this.Taps = 0;
			}
			if (Input.GetButtonDown("VaniaAttack") && !this.Attacking)
			{
				AudioSource.PlayClipAtPoint(this.WhipSound, base.transform.position);
				AudioSource component2 = base.GetComponent<AudioSource>();
				component2.clip = this.Voices[UnityEngine.Random.Range(0, this.Voices.Length)];
				component2.Play();
				this.WhipChain[0].transform.localScale = Vector3.zero;
				this.Attacking = true;
				this.IdleTimer = 10f;
				if (this.Crouching)
				{
					component[this.CrouchAttackAnim].time = 0f;
					component.Play(this.CrouchAttackAnim);
				}
				else
				{
					component[this.AttackAnim].time = 0f;
					component.Play(this.AttackAnim);
				}
				if (this.grounded)
				{
					this.moveDirection.x = 0f;
					this.inputX = 0f;
					this.speed = 0f;
				}
			}
			if (this.Attacking)
			{
				if (!this.Dangling)
				{
					this.WhipChain[0].transform.localScale = Vector3.MoveTowards(this.WhipChain[0].transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 5f);
					this.StraightenWhip();
				}
				else
				{
					this.LoosenWhip();
					if (Input.GetAxis("VaniaHorizontal") > -0.5f && Input.GetAxis("VaniaHorizontal") < 0.5f && Input.GetAxis("VaniaVertical") > -0.5f && Input.GetAxis("VaniaVertical") < 0.5f)
					{
						component.CrossFade(this.WhipNeutralAnim);
						if (this.Crouching)
						{
							component[this.CrouchPoseAnim].weight = 1f;
						}
						this.SpunUp = false;
						this.SpunDown = false;
						this.SpunRight = false;
						this.SpunLeft = false;
					}
					else
					{
						if (Input.GetAxis("VaniaVertical") > 0.5f)
						{
							if (!this.SpunUp)
							{
								AudioClipPlayer.Play2D(this.WhipSound, base.transform.position, UnityEngine.Random.Range(0.9f, 1.1f));
								this.StraightenWhip();
								this.TargetRotation = -360f;
								this.Rotation = 0f;
								this.SpunUp = true;
							}
							component.CrossFade(this.WhipUpAnim, 0.1f);
						}
						else
						{
							this.SpunUp = false;
						}
						if (Input.GetAxis("VaniaVertical") < -0.5f)
						{
							if (!this.SpunDown)
							{
								AudioClipPlayer.Play2D(this.WhipSound, base.transform.position, UnityEngine.Random.Range(0.9f, 1.1f));
								this.StraightenWhip();
								this.TargetRotation = 360f;
								this.Rotation = 0f;
								this.SpunDown = true;
							}
							component.CrossFade(this.WhipDownAnim, 0.1f);
						}
						else
						{
							this.SpunDown = false;
						}
						if (Input.GetAxis("VaniaHorizontal") > 0.5f)
						{
							if (this.Character.transform.localScale.x == 1f)
							{
								this.SpinLeft();
							}
							else
							{
								this.SpinRight();
							}
						}
						else if (this.Character.transform.localScale.x == 1f)
						{
							this.SpunLeft = false;
						}
						else
						{
							this.SpunRight = false;
						}
						if (Input.GetAxis("VaniaHorizontal") < -0.5f)
						{
							if (this.Character.transform.localScale.x == 1f)
							{
								this.SpinRight();
							}
							else
							{
								this.SpinLeft();
							}
						}
						else if (this.Character.transform.localScale.x == 1f)
						{
							this.SpunRight = false;
						}
						else
						{
							this.SpunLeft = false;
						}
					}
					this.Rotation = Mathf.MoveTowards(this.Rotation, this.TargetRotation, Time.deltaTime * 3600f * 0.5f);
					this.WhipChain[1].transform.localEulerAngles = new Vector3(0f, 0f, this.Rotation);
					if (!Input.GetButton("VaniaAttack"))
					{
						this.StopAttacking();
					}
				}
			}
			else
			{
				if (this.WhipCollider[1].enabled)
				{
					for (int i = 1; i < this.WhipChain.Length; i++)
					{
						this.SphereCollider[i].enabled = false;
						this.WhipCollider[i].enabled = false;
					}
				}
				this.WhipChain[0].transform.localScale = Vector3.MoveTowards(this.WhipChain[0].transform.localScale, Vector3.zero, Time.deltaTime * 10f);
			}
			if ((!this.Crouching && component[this.AttackAnim].time >= component[this.AttackAnim].length) || (this.Crouching && component[this.CrouchAttackAnim].time >= component[this.CrouchAttackAnim].length))
			{
				if (Input.GetButton("VaniaAttack"))
				{
					if (this.Crouching)
					{
						component[this.CrouchPoseAnim].weight = 1f;
					}
					this.Dangling = true;
				}
				else
				{
					this.StopAttacking();
				}
			}
		}
		if (this.FlashTimer > 0f)
		{
			this.FlashTimer -= Time.deltaTime;
			if (!this.Red)
			{
				Material[] materials = this.MyRenderer.materials;
				for (int j = 0; j < materials.Length; j++)
				{
					materials[j].color = new Color(1f, 0f, 0f, 1f);
				}
				this.Frames++;
				if (this.Frames == 5)
				{
					this.Frames = 0;
					this.Red = true;
				}
			}
			else
			{
				Material[] materials = this.MyRenderer.materials;
				for (int j = 0; j < materials.Length; j++)
				{
					materials[j].color = new Color(1f, 1f, 1f, 1f);
				}
				this.Frames++;
				if (this.Frames == 5)
				{
					this.Frames = 0;
					this.Red = false;
				}
			}
		}
		else
		{
			this.FlashTimer = 0f;
			if (this.MyRenderer.materials[0].color != new Color(1f, 1f, 1f, 1f))
			{
				Material[] materials = this.MyRenderer.materials;
				for (int j = 0; j < materials.Length; j++)
				{
					materials[j].color = new Color(1f, 1f, 1f, 1f);
				}
			}
		}
		this.HealthBar.localScale = new Vector3(this.HealthBar.localScale.x, Mathf.Lerp(this.HealthBar.localScale.y, this.Health / this.MaxHealth, Time.deltaTime * 10f), this.HealthBar.localScale.z);
		if (this.Health > 0f)
		{
			if (this.EXP >= 100f)
			{
				this.Level++;
				if (this.Level >= 99)
				{
					this.Level = 99;
				}
				else
				{
					UnityEngine.Object.Instantiate<GameObject>(this.LevelUpEffect, this.LevelLabel.transform.position, Quaternion.identity).transform.parent = this.LevelLabel.transform;
					this.MaxHealth += 20f;
					this.Health = this.MaxHealth;
					this.EXP -= 100f;
				}
				this.LevelLabel.text = this.Level.ToString();
			}
			this.EXPBar.localScale = new Vector3(this.EXPBar.localScale.x, Mathf.Lerp(this.EXPBar.localScale.y, this.EXP / 100f, Time.deltaTime * 10f), this.EXPBar.localScale.z);
		}
		base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, 0f);
		if (Input.GetKeyDown(KeyCode.BackQuote))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			base.transform.position = new Vector3(-31.75f, 6.51f, 0f);
			Physics.SyncTransforms();
		}
		if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			this.Level = 5;
			this.LevelLabel.text = this.Level.ToString();
		}
		if (Input.GetKeyDown(KeyCode.Equals))
		{
			Time.timeScale += 10f;
		}
		if (Input.GetKeyDown(KeyCode.Minus))
		{
			Time.timeScale -= 10f;
			if (Time.timeScale < 0f)
			{
				Time.timeScale = 1f;
			}
		}
	}

	// Token: 0x060020F5 RID: 8437 RVA: 0x001E7931 File Offset: 0x001E5B31
	private void LateUpdate()
	{
	}

	// Token: 0x060020F6 RID: 8438 RVA: 0x001E7933 File Offset: 0x001E5B33
	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		this.contactPoint = this.hit.point;
	}

	// Token: 0x060020F7 RID: 8439 RVA: 0x001E7948 File Offset: 0x001E5B48
	private void FallingDamageAlert(float fallDistance)
	{
		AudioClipPlayer.Play2D(this.LandSound, base.transform.position, UnityEngine.Random.Range(0.9f, 1.1f));
		this.Character.GetComponent<Animation>().Play(this.CrouchAnim);
		this.fallingDamageThreshold = this.originalThreshold;
	}

	// Token: 0x060020F8 RID: 8440 RVA: 0x001E79A0 File Offset: 0x001E5BA0
	private void SpinRight()
	{
		if (!this.SpunRight)
		{
			AudioClipPlayer.Play2D(this.WhipSound, base.transform.position, UnityEngine.Random.Range(0.9f, 1.1f));
			this.StraightenWhip();
			this.TargetRotation = 360f;
			this.Rotation = 0f;
			this.SpunRight = true;
		}
		this.Character.GetComponent<Animation>().CrossFade(this.WhipRightAnim, 0.1f);
	}

	// Token: 0x060020F9 RID: 8441 RVA: 0x001E7A18 File Offset: 0x001E5C18
	private void SpinLeft()
	{
		if (!this.SpunLeft)
		{
			AudioClipPlayer.Play2D(this.WhipSound, base.transform.position, UnityEngine.Random.Range(0.9f, 1.1f));
			this.StraightenWhip();
			this.TargetRotation = -360f;
			this.Rotation = 0f;
			this.SpunLeft = true;
		}
		this.Character.GetComponent<Animation>().CrossFade(this.WhipLeftAnim, 0.1f);
	}

	// Token: 0x060020FA RID: 8442 RVA: 0x001E7A90 File Offset: 0x001E5C90
	private void StraightenWhip()
	{
		for (int i = 1; i < this.WhipChain.Length; i++)
		{
			this.WhipCollider[i].enabled = true;
			this.WhipChain[i].gameObject.GetComponent<Rigidbody>().isKinematic = true;
			Transform transform = this.WhipChain[i].transform;
			transform.localPosition = new Vector3(0f, -0.03f, 0f);
			transform.localEulerAngles = Vector3.zero;
		}
		this.WhipChain[1].transform.localPosition = new Vector3(0f, -0.1f, 0f);
		this.WhipTimer = 0f;
		this.Loose = false;
	}

	// Token: 0x060020FB RID: 8443 RVA: 0x001E7B40 File Offset: 0x001E5D40
	private void LoosenWhip()
	{
		if (!this.Loose)
		{
			this.WhipTimer += Time.deltaTime;
			if (this.WhipTimer > 0.25f)
			{
				for (int i = 1; i < this.WhipChain.Length; i++)
				{
					this.WhipChain[i].gameObject.GetComponent<Rigidbody>().isKinematic = false;
					this.SphereCollider[i].enabled = true;
				}
				this.Loose = true;
			}
		}
	}

	// Token: 0x060020FC RID: 8444 RVA: 0x001E7BB4 File Offset: 0x001E5DB4
	private void StopAttacking()
	{
		this.Character.GetComponent<Animation>()[this.CrouchPoseAnim].weight = 0f;
		this.TargetRotation = 0f;
		this.Rotation = 0f;
		this.Attacking = false;
		this.Dangling = false;
		this.SpunUp = false;
		this.SpunDown = false;
		this.SpunRight = false;
		this.SpunLeft = false;
	}

	// Token: 0x060020FD RID: 8445 RVA: 0x001E7C24 File Offset: 0x001E5E24
	public void TakeDamage(int Damage)
	{
		if (this.WhipCollider[1].enabled)
		{
			for (int i = 1; i < this.WhipChain.Length; i++)
			{
				this.SphereCollider[i].enabled = false;
				this.WhipCollider[i].enabled = false;
			}
		}
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.Injuries[UnityEngine.Random.Range(0, this.Injuries.Length)];
		component.Play();
		this.WhipChain[0].transform.localScale = Vector3.zero;
		Animation component2 = this.Character.GetComponent<Animation>();
		component2["f02_damage_25"].time = 0f;
		this.fallingDamageThreshold = 100f;
		this.moveDirection.x = 0f;
		this.RecoveryTimer = 0f;
		this.FlashTimer = 2f;
		this.Injured = true;
		this.StopAttacking();
		this.Health -= (float)Damage;
		if (this.Dracula.Health <= 0f)
		{
			this.Health = 1f;
		}
		if (this.Dracula.Health > 0f && this.Health <= 0f)
		{
			if (this.NewBlood == null)
			{
				this.MyController.enabled = false;
				this.YanvaniaCamera.StopMusic = true;
				component.clip = this.DeathSound;
				component.Play();
				this.NewBlood = UnityEngine.Object.Instantiate<GameObject>(this.DeathBlood, base.transform.position, Quaternion.identity);
				this.NewBlood.transform.parent = this.Hips;
				this.NewBlood.transform.localPosition = Vector3.zero;
				component2.CrossFade(this.DeathAnim);
				this.CanMove = false;
			}
			this.Health = 0f;
		}
	}

	// Token: 0x04004877 RID: 18551
	private GameObject NewBlood;

	// Token: 0x04004878 RID: 18552
	public YanvaniaCameraScript YanvaniaCamera;

	// Token: 0x04004879 RID: 18553
	public InputManagerScript InputManager;

	// Token: 0x0400487A RID: 18554
	public YanvaniaDraculaScript Dracula;

	// Token: 0x0400487B RID: 18555
	public Animation MyAnimation;

	// Token: 0x0400487C RID: 18556
	public CharacterController MyController;

	// Token: 0x0400487D RID: 18557
	public GameObject BossHealthBar;

	// Token: 0x0400487E RID: 18558
	public GameObject LevelUpEffect;

	// Token: 0x0400487F RID: 18559
	public GameObject DeathBlood;

	// Token: 0x04004880 RID: 18560
	public GameObject Character;

	// Token: 0x04004881 RID: 18561
	public GameObject BlackBG;

	// Token: 0x04004882 RID: 18562
	public GameObject TextBox;

	// Token: 0x04004883 RID: 18563
	public Renderer MyRenderer;

	// Token: 0x04004884 RID: 18564
	public Transform TryAgainWindow;

	// Token: 0x04004885 RID: 18565
	public Transform HealthBar;

	// Token: 0x04004886 RID: 18566
	public Transform EXPBar;

	// Token: 0x04004887 RID: 18567
	public Transform Hips;

	// Token: 0x04004888 RID: 18568
	public Transform TrailStart;

	// Token: 0x04004889 RID: 18569
	public Transform TrailEnd;

	// Token: 0x0400488A RID: 18570
	public UITexture Photograph;

	// Token: 0x0400488B RID: 18571
	public UILabel LevelLabel;

	// Token: 0x0400488C RID: 18572
	public UISprite Darkness;

	// Token: 0x0400488D RID: 18573
	public Collider[] SphereCollider;

	// Token: 0x0400488E RID: 18574
	public Collider[] WhipCollider;

	// Token: 0x0400488F RID: 18575
	public Transform[] WhipChain;

	// Token: 0x04004890 RID: 18576
	public AudioClip[] Voices;

	// Token: 0x04004891 RID: 18577
	public AudioClip[] Injuries;

	// Token: 0x04004892 RID: 18578
	public AudioClip DeathSound;

	// Token: 0x04004893 RID: 18579
	public AudioClip LandSound;

	// Token: 0x04004894 RID: 18580
	public AudioClip WhipSound;

	// Token: 0x04004895 RID: 18581
	public bool Attacking;

	// Token: 0x04004896 RID: 18582
	public bool Crouching;

	// Token: 0x04004897 RID: 18583
	public bool Dangling;

	// Token: 0x04004898 RID: 18584
	public bool EnterCutscene;

	// Token: 0x04004899 RID: 18585
	public bool Cutscene;

	// Token: 0x0400489A RID: 18586
	public bool CanMove;

	// Token: 0x0400489B RID: 18587
	public bool Injured;

	// Token: 0x0400489C RID: 18588
	public bool Loose;

	// Token: 0x0400489D RID: 18589
	public bool Red;

	// Token: 0x0400489E RID: 18590
	public bool SpunUp;

	// Token: 0x0400489F RID: 18591
	public bool SpunDown;

	// Token: 0x040048A0 RID: 18592
	public bool SpunRight;

	// Token: 0x040048A1 RID: 18593
	public bool SpunLeft;

	// Token: 0x040048A2 RID: 18594
	public float TargetRotation;

	// Token: 0x040048A3 RID: 18595
	public float Rotation;

	// Token: 0x040048A4 RID: 18596
	public float RecoveryTimer;

	// Token: 0x040048A5 RID: 18597
	public float DeathTimer;

	// Token: 0x040048A6 RID: 18598
	public float FlashTimer;

	// Token: 0x040048A7 RID: 18599
	public float IdleTimer;

	// Token: 0x040048A8 RID: 18600
	public float WhipTimer;

	// Token: 0x040048A9 RID: 18601
	public float TapTimer;

	// Token: 0x040048AA RID: 18602
	public float PreviousY;

	// Token: 0x040048AB RID: 18603
	public float MaxHealth = 100f;

	// Token: 0x040048AC RID: 18604
	public float Health = 100f;

	// Token: 0x040048AD RID: 18605
	public float EXP;

	// Token: 0x040048AE RID: 18606
	public int Frames;

	// Token: 0x040048AF RID: 18607
	public int Level;

	// Token: 0x040048B0 RID: 18608
	public int Taps;

	// Token: 0x040048B1 RID: 18609
	public float walkSpeed = 6f;

	// Token: 0x040048B2 RID: 18610
	public float runSpeed = 11f;

	// Token: 0x040048B3 RID: 18611
	public bool limitDiagonalSpeed = true;

	// Token: 0x040048B4 RID: 18612
	public bool toggleRun;

	// Token: 0x040048B5 RID: 18613
	public float jumpSpeed = 8f;

	// Token: 0x040048B6 RID: 18614
	public float gravity = 20f;

	// Token: 0x040048B7 RID: 18615
	public float fallingDamageThreshold = 10f;

	// Token: 0x040048B8 RID: 18616
	public bool slideWhenOverSlopeLimit;

	// Token: 0x040048B9 RID: 18617
	public bool slideOnTaggedObjects;

	// Token: 0x040048BA RID: 18618
	public float slideSpeed = 12f;

	// Token: 0x040048BB RID: 18619
	public bool airControl;

	// Token: 0x040048BC RID: 18620
	public float antiBumpFactor = 0.75f;

	// Token: 0x040048BD RID: 18621
	public int antiBunnyHopFactor = 1;

	// Token: 0x040048BE RID: 18622
	private Vector3 moveDirection = Vector3.zero;

	// Token: 0x040048BF RID: 18623
	public bool grounded;

	// Token: 0x040048C0 RID: 18624
	private CharacterController controller;

	// Token: 0x040048C1 RID: 18625
	private Transform myTransform;

	// Token: 0x040048C2 RID: 18626
	private float speed;

	// Token: 0x040048C3 RID: 18627
	private RaycastHit hit;

	// Token: 0x040048C4 RID: 18628
	private float fallStartLevel;

	// Token: 0x040048C5 RID: 18629
	private bool falling;

	// Token: 0x040048C6 RID: 18630
	private float slideLimit;

	// Token: 0x040048C7 RID: 18631
	private float rayDistance;

	// Token: 0x040048C8 RID: 18632
	private Vector3 contactPoint;

	// Token: 0x040048C9 RID: 18633
	private bool playerControl;

	// Token: 0x040048CA RID: 18634
	private int jumpTimer;

	// Token: 0x040048CB RID: 18635
	private float originalThreshold;

	// Token: 0x040048CC RID: 18636
	public float inputX;

	// Token: 0x040048CD RID: 18637
	public string DeathAnim = "f02_yanvaniaDeath_00";

	// Token: 0x040048CE RID: 18638
	public string AttackAnim = "f02_yanvaniaAttack_00";

	// Token: 0x040048CF RID: 18639
	public string CrouchAttackAnim = "f02_yanvaniaCrouchAttack_00";

	// Token: 0x040048D0 RID: 18640
	public string IdleAnim = "f02_yanvaniaIdle_00";

	// Token: 0x040048D1 RID: 18641
	public string DramaticIdleAnim = "f02_yanvaniaDramaticIdle_00";

	// Token: 0x040048D2 RID: 18642
	public string JumpAnim = "f02_yanvaniaJump_00";

	// Token: 0x040048D3 RID: 18643
	public string FallAnim = "f02_yanvaniaFall_00";

	// Token: 0x040048D4 RID: 18644
	public string CrouchAnim = "f02_yanvaniaCrouch_00";

	// Token: 0x040048D5 RID: 18645
	public string CrouchPoseAnim = "f02_yanvaniaCrouchPose_00";

	// Token: 0x040048D6 RID: 18646
	public string WalkAnim = "f02_yanvaniaWalk_00";

	// Token: 0x040048D7 RID: 18647
	public string RunAnim = "f02_yanvaniaRun_00";

	// Token: 0x040048D8 RID: 18648
	public string WhipNeutralAnim = "f02_yanvaniaWhip_Neutral";

	// Token: 0x040048D9 RID: 18649
	public string WhipUpAnim = "f02_yanvaniaWhip_Up";

	// Token: 0x040048DA RID: 18650
	public string WhipRightAnim = "f02_yanvaniaWhip_Right";

	// Token: 0x040048DB RID: 18651
	public string WhipDownAnim = "f02_yanvaniaWhip_Down";

	// Token: 0x040048DC RID: 18652
	public string WhipLeftAnim = "f02_yanvaniaWhip_Left";
}
