using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;

using ReLogic.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.UI;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using Terraria.Graphics.Shaders;
using Terraria.Graphics.Effects;
using Terraria.GameContent.Generation;
//using Terraria.ModLoader.Config;
//using Terraria.ModLoader.Config.UI;


namespace DrownedMod
{
	/*public class DrownedMod : Mod
	{
		public override void PostSetupContent()
		{
			Drowned_Config.CreateConfig();
		}
		
		public static string ConfigFileRelativePath 
		{
			get
			{
				return "Mod Configs/TFC's Mods/Drowned Mod.txt";
			}
		}

		public static void ReloadConfigFromFile() 
		{
			Drowned_Config.Load();
		}
		
		public override void AddRecipes()
		{
		}*/
		
		/*public override void Load()
		{
			Tele = RegisterHotKey("Tele", "Z");
		}
		
		public override void Unload()
		{
			Tele = null;
		}*/
		
		
		// discord implementation.
		/*public static uint? prevCount;
		public static bool pauseUpdate = false;
		public static void UpdaterLoad()
		{
			Main.OnTick += RPUpdate;
		}

		public static void UpdaterUnload()
		{
			Main.OnTick -= RPUpdate;
		}
		*/
		/*public MainMod()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}*/

		/*public override void Load()
		{
			RPControl.Enable();
			RPControl.presence.details = string.Format("Sitting Around");
			RPControl.presence.largeImageKey = string.Format("payload_test");
			RPControl.presence.largeImageText = string.Format("Terraria");

			DateTime date = DateTime.Now;
			DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			long timenow = Convert.ToInt64((date.ToUniversalTime() - epoch).TotalSeconds);

			RPControl.presence.startTimestamp = timenow;

			RPControl.Update();
		}


		public override void PreSaveAndQuit()
		{
			RPControl.presence.details = string.Format("Sitting Around");
			RPControl.presence.state = null;
			RPControl.presence.largeImageKey = string.Format("payload_test");
			RPControl.presence.largeImageText = string.Format("Terraria");
			RPControl.presence.smallImageKey = null;
			RPControl.presence.smallImageText = null;
			RPControl.Update();
			UpdaterUnload();
		}

		public override void Unload()
		{
			RPControl.Disable();
		}

		public static void RPUpdate()
		{
			if (!Main.dedServ && !Main.gameMenu)
			{
				Player RPlayer = Main.player[Main.myPlayer];
				if ((prevCount == null || prevCount + 180 <= Main.GameUpdateCount) || (Main.gamePaused && !pauseUpdate))
				{
					if (Main.gamePaused)
					{
						pauseUpdate = true;
					}
					prevCount = Main.GameUpdateCount;
					//Main.NewText(prevCount);
					RPUtility.player = RPlayer;
					RPUtility.Update();
				}
				else if (!Main.gamePaused)
				{
					pauseUpdate = false;
				}
				else return;
			}
			else return;
		}
		
	}*/
	
	public class startup: ModWorld
	{
		public int i = 0; //x
		public int k = 998; //y
		public int z = 0; //x(bubbles after flood)
		
		public string wS = "Unfound";
		
		public bool Broad = false;
		public static bool done = false;
		//public bool T_T = false;
		public bool rowComplete = false;
		
		public int left = -1;
		public int right = 0;
		public int top = 0;
		public int bubble = 0;
		
		public ushort SaveID = 56; //tile indicating that the world has been flooded.
		public Vector2 SavePos = new Vector2 (0,0); //tile pos to save to.
		
		public int rightL = 8398;
		public int bubbleL = 2197;
		
		public int rightM = 6398;
		public int bubbleM = 1597;
		
		public int rightS = 4198;
		public int bubbleS = 998;
		
		//private TagCompound tag;
		private int frame = 0;
		
		public override TagCompound Save()
		{
			//bool downed = false;
			
			return new TagCompound
			{
				{"Drowned",done}
			};
		}
		
		
		public override void Load(TagCompound tag)
		{
//			done = false;
//			Main.NewText(done);
			//frame = 0;
//			if (frame <= 5)
//			{
//				if (done = false)
//				{
					bool drowned = false;
					drowned = tag.GetBool("Drowned");
					wS = "Unfound";
//					Broad = false;
					done = drowned;
					//T_T = false;
//				} else {
//					T_T = true;
//					Main.NewText("Bug occured. Please relog. (Unless your world's already flooded.");
//					Main.NewText("If  it is, you can safely ignore this message.)");
//					done = false;
//				}
//			}
		}
		
		public virtual void save()
		{
			Main.tile[0,0].active(true);
			Main.tile[0,0].type = SaveID;
			Main.hardMode = false;
			if (Drowned_Config.ID == 1)
			{
				Main.spawnTileX -= 0;
				Main.spawnTileY += 4;
			}
		}
		
		public override void PostUpdate()
		{
			
			//Drowned_Config.Load();
			if (frame >= 10/* && T_T == false*/)
			{
				if (wS == "Unfound")
				{
								wS = "Error";
							if ((Main.maxTilesX) == 8400)
							{
								wS = "Large";
								Main.NewText("Large");
							} else if ((Main.maxTilesX) == 6400)
							{
								wS = "Medium";
								Main.NewText("Medium");
							} else if ((Main.maxTilesX) == 4200)
							{
								wS = "Small";
								Main.NewText("Small");
							} else 
							{
								wS = "Error";
								Main.NewText("Error");
							}
							//Main.NewText("wS");
								Main.NewText(wS != "Unfound");
								Main.NewText(done);
								Main.NewText(Broad);
				}
				
						
				if (wS != "Unfound")
				{
								if (Main.tile[0,0].type == 0)
								//if ()
								{
									if (Drowned_Config.Initail_Flood == "yes")
									{
										if (!Broad)
										{
											
											//old method
											/*if ((Main.maxTilesX) == 8400)
											{
												k = bubbleL;
												bubble = bubbleL;
												right = rightL;
											} else if ((Main.maxTilesX) == 6400)
											{
												k = bubbleM;
												bubble = bubbleM;
												right = rightM;
											} else if ((Main.maxTilesX) == 4200)
											{
												k = bubbleS;
												bubble = bubbleS;
												right = rightS;
											} else {
												//done = true;
												Main.NewText("Invalid world.");
												Main.NewText("Rightmost tile is at " + (Main.maxTilesX-2));
												Main.NewText("Large is " + rightL);
												Main.NewText("Medium is " + rightM);
												Main.NewText("Small is " + rightS);
												Main.NewText("Please use one of these three world sizes for improved stability.");
											}*/
											
											Main.NewText(k + "," + bubble + "," + right);
											Main.NewText((Main.maxTilesY - 204) + "," + (Main.maxTilesY - 203) + "," + (Main.maxTilesX - 2));
											
											
											//New Method
											bubble = Main.maxTilesY - 203;
											right = Main.maxTilesX - 1;
											
											k = bubble - 1;
											
											if (!done)
											{
												Main.NewText(" ");
												Main.NewText("Drowned Mod: Please wait while " + Drowned_Config.type + " is added");
												Main.NewText(" ");
												Main.NewText("World size:" + wS);
												Main.NewText("Drowned Mod: Also shoutouts to Hectique,");
												Main.NewText("both discord and Hectique are on the mod's site.");
												Main.NewText(" ");
											}
											
											Broad = true;
										}
										
												fillRow(Drowned_Config.ID);
												fillRow(Drowned_Config.ID);
												fillRow(Drowned_Config.ID);
												fillRow(Drowned_Config.ID);
												fillRow(Drowned_Config.ID);
												fillRow(Drowned_Config.ID);
												fillRow(Drowned_Config.ID);
												fillRow(Drowned_Config.ID);
												fillRow(Drowned_Config.ID);
												fillRow(Drowned_Config.ID);
												fillRow(Drowned_Config.ID);
												fillRow(Drowned_Config.ID);
										
										
									} else {
										Main.NewText("Drowned Mod: Initail Flood has been turned off in the config file.");
										/*Main.NewText("Init Flood:" + Drowned_Config.Initail_Flood);
										Main.NewText("Top Flood:" + Drowned_Config.FFT);
										Main.NewText("Left Flood:" + Drowned_Config.FFL);
										Main.NewText("Right Flood:" + Drowned_Config.FFR);
										Main.NewText("Top Left Flood:" + Drowned_Config.FFTL);
										Main.NewText("Top Right Flood:" + Drowned_Config.FFTR);
										Main.NewText("Flood ID:" + Drowned_Config.ID);*/
										done = true;
									}
								} else {
									if (Drowned_Config.FFT == "yes")
									{
										fillARoofTile();
										fillARoofTile();
										fillARoofTile();
										fillARoofTile();
										fillARoofTile();
										
										fillABubble();fillABubble();fillABubble();fillABubble();fillABubble();
										
										//Main.NewText("Top Flood:" + Drowned_Config.FFT);
									}
									
									if (Drowned_Config.FFTL == "yes")
									{
										Main.NewText(fillTile(0,0, Drowned_Config.ID));
										//Main.NewText("Top Left Flood:" + Drowned_Config.FFTL);
									}
									
									if (Drowned_Config.FFTR == "yes")
									{
										Main.NewText(fillTile(8398,0, Drowned_Config.ID));
										//Main.NewText("Top Right Flood:" + Drowned_Config.FFTR);
									}
								}
				} else {
						Main.NewText(wS);
				}
			} else {
			//	Main.NewText("Bug occured. Please relog." + done + "HELP" + T_T);
				frame += 1;
			}
		}
		
		public virtual void fillRow(int fluidID)
		{
			rowComplete = false;
			
			fill390625Tile(fluidID);
			fill390625Tile(fluidID);
			fill390625Tile(fluidID);
			fill390625Tile(fluidID);
			fill390625Tile(fluidID);
		}
		
		public virtual void fill390625Tile(int fluidID)
		{
			fill625Tile(fluidID);
			fill625Tile(fluidID);
			fill625Tile(fluidID);
			fill625Tile(fluidID);
			fill625Tile(fluidID);
		}
		
		public virtual void fill625Tile(int fluidID)
		{
			fillTwentyFiveTile(fluidID);
			fillTwentyFiveTile(fluidID);
			fillTwentyFiveTile(fluidID);
			fillTwentyFiveTile(fluidID);
			fillTwentyFiveTile(fluidID);
		}
		
		public virtual void fillTwentyFiveTile(int fluidID)
		{
			fillFiveTile(fluidID);
			fillFiveTile(fluidID);
			fillFiveTile(fluidID);
			fillFiveTile(fluidID);
			fillFiveTile(fluidID);
		}
		
		public virtual void fillFiveTile(int fluidID)
		{
			if (done)
			{
				rowComplete = true;
			}
			if (!done && !rowComplete)
			{
				fillATile(fluidID);
			}
			if (!done && !rowComplete)
			{
				fillATile(fluidID);
			}
			if (!done && !rowComplete)
			{
				fillATile(fluidID);
			}
			if (!done && !rowComplete)
			{
				fillATile(fluidID);
			}
			if (!done && !rowComplete)
			{
				fillATile(fluidID);
			}
		}
		
		public virtual void fillARoofTile()
		{
			
			/*if (i > right)
			{
				i = left;
				k -= 1;
			}
			
			if (k == 0)
			{
				k = top + 40;
			}
			
			if(Main.tile[i, k].liquid > 0)
			{
				if(Main.tile[i, k].liquidType() == 0)
				{
					Main.tile[i, k].liquidType(0);
					Main.tile[i, k].liquid = 255;
					WorldGen.SquareTileFrame(i, k, true);
					NetMessage.SendTileSquare(-1, i, k, 1);
				}
			} else if(!Main.tile[i, k].active() || Main.tile[i, k].inActive() || *//*!Main.tile[i, k].nactive ||*/ /*Main.tile[i, k].collisionType == 1) {
				Main.tile[i, k].liquidType(0);
				Main.tile[i, k].liquid = 255;
				WorldGen.SquareTileFrame(i, k, true);
				NetMessage.SendTileSquare(-1, i, k, 1);
			}
			
			i += 1;*/
		}
		
		public virtual void fillABubble()
		{
				
				Main.tile[i, bubble].active(true);
				Main.tile[i, bubble].type = 379;
				if (z == right)
				{
					z = left;
					//k -= 1;
					//Main.NewText(k);
					//Main.NewText(top);
				}
				z += 1;
		}
		
		public virtual void fillATile(int fluidID)
		{
				
				//if (Main.tile[i, k].active())
				//{
				//	Main.tile[i, k].collisionType == 0;
				//} else {
					Main.tile[i, bubble].active(true);
					Main.tile[i, bubble].type = 379;
				//}
				//Main.NewText(i);
				if(Main.tile[i, k].liquid > 0)
				{
					if(Main.tile[i, k].liquidType() == fluidID)
					{
						Main.tile[i, k].liquidType(fluidID);
						Main.tile[i, k].liquid = 255;
						WorldGen.SquareTileFrame(i, k, true);
						NetMessage.SendTileSquare(-1, i, k, 1);
					}
					
					if(fluidID == 0)
					{
						replaceFluid(2,229);
						replaceFluid(1,56);
					}
					if(fluidID == 1)
					{
						replaceFluid(2,230);
						replaceFluid(0,56);
					}
					if(fluidID == 2)
					{
						replaceFluid(1,230);
						replaceFluid(0,229);
					}
					
				} else if(
				//!Main.tile[i, k].active() || Main.tile[i, k].inActive() || /*!Main.tile[i, k].nactive ||*/ Main.tile[i, k].collisionType != 1
				//!Main.tileSolid[(int)Main.tile[i, k].type] &&
				(
					(
						Main.tile[i, k].active() &&
						!(
							Main.tile[i, k].topSlope() ||
							Main.tile[i, k].bottomSlope() ||
							Main.tile[i, k].leftSlope() ||
							Main.tile[i, k].rightSlope() ||
							Main.tile[i, k].halfBrick() ||
							Main.tileSolid[(int)Main.tile[i, k].type]
						)
					) ||
					!Main.tile[i, k].active()
				)
				/* ||
				(
					Main.tile[i, k].collisionType != 1 &&
					Main.tile[i, k].collisionType != 2 &&
					Main.tile[i, k].collisionType != 3 &&
					Main.tile[i, k].collisionType != 4 &&
					Main.tile[i, k].collisionType != 5 &&
					Main.tile[i, k].collisionType != 6 &&
					Main.tile[i, k].collisionType != 7 &&
					Main.tile[i, k].collisionType != 8 &&
					Main.tile[i, k].collisionType != 9 &&
					Main.tile[i, k].collisionType != 10
				)*/
				) {
					Main.tile[i, k].liquidType(fluidID);
					Main.tile[i, k].liquid = 255;
					WorldGen.SquareTileFrame(i, k, true);
					NetMessage.SendTileSquare(-1, i, k, 1);
				}
				
				/*if(Main.tile[i, k + 1].liquid == 0 && ((Main.tile[i, k + 1].collisionType != 1 || !Main.tile[i, k + 1].active()) ) && Main.tile[i, k].liquidType() == 1)
				{
					Main.tile[i, k].active(true);
					Main.tile[i, k].type = 230;
					Main.tile[i, k].liquid = 0;
				}*/
				
			if (i == right)
			{
				i = left;
				k -= 1;
				//Main.NewText(k);
				//Main.NewText(top);
				rowComplete = true;
			}
			if (k < top)
			{
				i = left;
				k = bubble - 1;
				Main.NewText("Done! You may now begin playing!");
				done = true;
				save();
			}
			i += 1;
		}
		
		public virtual void replaceFluid(int ID, ushort tileID)
		{
						if
						(
							Main.tile[i, k].type == 26 ||
							Main.tile[i, k].type == 231
						)
						{
							Main.tile[i, k].liquidType(Drowned_Config.ID);
						}
						
						if
						(
							(
								(
									Main.tile[i, k].liquidType() == ID &&
									(Main.tile[i, k-1].liquidType() != ID ||
									Main.tile[i, k-1].liquid == 0) &&
									(
										!Main.tile[i, k].active() ||
										(
											Main.tile[i, k].active() &&
											Main.tile[i, k].collisionType != 1
										)
										
										//Main.tile[i, k].collisionType != 1
									) &&
									(
										/*!Main.tile[i, k-1].active() ||
										(
											Main.tile[i, k-1].active() &&
											Main.tile[i, k-1].collisionType != 1
										)*/
	//sssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss
										(
											Main.tile[i, k-1].active() &&
											!(
												Main.tile[i, k-1].topSlope() ||
												Main.tile[i, k-1].bottomSlope() ||
												Main.tile[i, k-1].leftSlope() ||
												Main.tile[i, k-1].rightSlope() ||
												Main.tile[i, k-1].halfBrick() ||
												Main.tileSolid[(int)Main.tile[i, k-1].type]
											)
										) ||
										!Main.tile[i, k-1].active()// ||
	//sssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss
										//Main.tile[i, k-1].liquidType() == Drowned_Config.ID
									)
								) || 
								ID == 0 &&
								Main.tile[i, k].liquidType() == ID &&
								(
									!Main.tile[i, k].active() ||
									(
										Main.tile[i, k].active() &&
										Main.tile[i, k].collisionType != 1
									)
									
									//Main.tile[i, k].collisionType != 1
								) &&
								(
									!Main.tile[i, k-1].active() ||
									(
										Main.tile[i, k-1].active() &&
										Main.tile[i, k-1].collisionType != 1
									) 
								) &&
								Main.tile[i, k-1].liquidType() != ID
							) && 
							Main.tile[i, k].type != 26 &&
							Main.tile[i, k].type != 231
						)
						{
							Main.tile[i, k].liquid = 0;
							Main.tile[i, k].active(true);
							Main.tile[i, k].type = tileID;
						}
		}
		
		public virtual string fillTile(int tileX, int tileY, int fluidID)
		{
			i = tileX;
			k = tileY;
			string result = "false";
				//Main.tile[i, bubble].active(true);
				//Main.tile[i, bubble].type = 379;
				//Main.NewText(i);
				if(Main.tile[i, k].liquid > 0)
				{
					if(Main.tile[i, k].liquidType() == fluidID)
					{
						Main.tile[i, k].liquidType(fluidID);
						result = ("Already " + fluidID + ". Refilling fromm water value " + Main.tile[i, k].liquid + " to water value 255");
						Main.tile[i, k].liquid = 255;
						WorldGen.SquareTileFrame(i, k, true);
						NetMessage.SendTileSquare(-1, i, k, 1);
					}
				} else if(!Main.tile[i, k].active() || Main.tile[i, k].inActive() || /*!Main.tile[i, k].nactive ||*/ Main.tile[i, k].collisionType == 3) {
					
					result = ("Empty. Filling with " + fluidID + " to water value 255");
					Main.tile[i, k].liquidType(fluidID);
					Main.tile[i, k].liquid = 255;
					WorldGen.SquareTileFrame(i, k, true);
					NetMessage.SendTileSquare(-1, i, k, 1);
				}
			
			return result;
		}
		
		//Bubble:379
		//35187 (bubble)
		//133708 (Right side of world)
		//656 (Left side of world)
		//656 (Top of world)
			
		/*public override void Initialize()
		{
			//float posX = player.position.X;
			int i = 0;
			
			for (i = 656; i <= 133708; i++);
			{
				//Tile.X = (float)(((int)((player.position.X)/16)));
				//Tile.Y = (float)(((int)(656/16)));
				
				//Main.NewText(player.position.X);
				//Main.NewText(">");
				//Main.NewText(posX - 160);
				//Main.NewText(player.position.X > posX - 160);
				
					Main.tile[(int)i / 16, (int)656 / 16].liquid = 255;
					
				//offsetX+=1;
			}
		}*/
	}
	
	public class Text : ModPlayer
	{
		//private int bubbleL = 2197;
		private int bubble = Main.maxTilesY - 200;
		private string wS;
		//private bool Tele = false;
		//private int bubbleS = 998;

		public override void SetControls()
		{
			
						/*
						if ((Main.maxTilesX) == 8400)
						{
							wS = "Large";
						} else if ((Main.maxTilesX) == 6400)
						{
							wS = "Medium";
						} else if ((Main.maxTilesX) == 4200)
						{
							wS = "Small";
						}
						*/
						
			/*Main.NewText("");
			Main.NewText("");
			Main.NewText("");
			Main.NewText("");
			Main.NewText("tX:" + (int)(player.position.X/16));
			Main.NewText("tY:" + (int)(player.position.Y/16));
			Main.NewText("C:" + Main.rockLayer);
			Main.NewText("mTX:" + Main.maxTilesX);
			Main.NewText("mTY:" + Main.maxTilesY);
			//Main.NewText("dFBTBL:" + (Main.maxTilesY - bubbleL));
			//Main.NewText("dFBTBS:" + (Main.maxTilesY - bubbleS));
			Main.NewText("Right:" + (Main.maxTilesX - 2));
			Main.NewText("Bottom:" + (Main.maxTilesY));
			Main.NewText("Heck:" + (Main.maxTilesY - 204));*/
			
			//Main.NewText("tX:" + (int)(player.position.X/16));
			//Main.NewText("tY:" + (int)(player.position.Y/16));
			//Main.NewText("Bottom:" + (Main.maxTilesY));
			//Main.NewText("Heck?:" + (Main.maxTilesY - 203));
			//Main.NewText("Right:" + (Main.maxTilesX));
			//Main.NewText("Done?:" + (startup.done));
			//Main.NewText("Ply.World Size?:" + (wS));
			//Main.NewText("MaxY/Bubble Ratio:" + ((float)Main.maxTilesY/996f));
			
			
			//Drowned_Config.Load();
			if (player.position.Y < 2197)
			{
				if (Drowned_Config.FFL == "yes")
				{
					int k = (int)player.position.Y/16;
					int i = 0;
					if(Main.tile[i, k].liquid > 0)
					{
						if(Main.tile[i, k].liquidType() == Drowned_Config.ID)
						{
							Main.tile[i, k].liquidType(Drowned_Config.ID);
							Main.tile[i, k].liquid = 255;
							WorldGen.SquareTileFrame(i, k, true);
							NetMessage.SendTileSquare(-1, i, k, 1);
						}
					} else if(!Main.tile[i, k].active() || Main.tile[i, k].inActive() || Main.tile[i, k].collisionType == 3) {
						Main.tile[i, k].liquidType(Drowned_Config.ID);
						Main.tile[i, k].liquid = 255;
						WorldGen.SquareTileFrame(i, k, true);
						NetMessage.SendTileSquare(-1, i, k, 1);
					}
				}
				
				if (Drowned_Config.FFR == "yes")
				{
					int k = (int)player.position.Y;
					int i = 8398;
					if(Main.tile[i, k].liquid > 0)
					{
						if(Main.tile[i, k].liquidType() == Drowned_Config.ID)
						{
							Main.tile[i, k].liquidType(Drowned_Config.ID);
							Main.tile[i, k].liquid = 255;
							WorldGen.SquareTileFrame(i, k, true);
							NetMessage.SendTileSquare(-1, i, k, 1);
						}
					} else if(!Main.tile[i, k].active() || Main.tile[i, k].inActive() || Main.tile[i, k].collisionType == 3) {
						Main.tile[i, k].liquidType(Drowned_Config.ID);
						Main.tile[i, k].liquid = 255;
						WorldGen.SquareTileFrame(i, k, true);
						NetMessage.SendTileSquare(-1, i, k, 1);
					}
				}
			}
			
			//	tele = PlayerInput.Triggers.Current.KeyStatus[Tele];
				
			//if (tele)
			//{
			//	player.position = Main.MouseWorld;
			//}
			
		}
		
		//public override void ProcessTriggers(TriggersSet triggersSet)
		//{
		//}
	}
	//[GlobalMod]
	public class MNPC : GlobalNPC
	{
		public override void NPCLoot(NPC npc)
		{
			if (npc.type == 63)
			{
				
				Item.NewItem
				(
					(int)npc.position.X, //spawnpos
					(int)npc.position.Y, //spawnpos
					npc.width /2, //spawn offset
					npc.height /2, //spawn offset
					23, //ID
					Main.rand.Next(3,5), //count?
					false, //idk
					0 //idk
				);
				
			} else if (npc.type == 64 || npc.type == 242 || npc.type == 103)
			{
				
				Item.NewItem
				(
					(int)npc.position.X, //spawnpos
					(int)npc.position.Y, //spawnpos
					npc.width /2, //spawn offset
					npc.height /2, //spawn offset
					23, //ID
					Main.rand.Next(1,3), //count?
					false, //idk
					0 //idk
				);
				
			}
		}
	}
}