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

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;

namespace DrownedMod
{
	public class DrownedMod : Mod
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
		}
	}
	
	public class startup: ModWorld
	{
		private int i = 0; //x
		private int k = 998; //y
		private int z = 0; //x(bubbles after flood)
		
		private string wS = "Small";
		
		private bool Broad = false;
		private bool done = false;
		private bool rowComplete = false;
		
		private int left = 0;
		private int right = 0;
		private int top = 0;
		private int bubble = 0;
		
		private int rightL = 8398;
		private int bubbleL = 2199;
		
		private int rightM = 6398;
		private int bubbleM = 1594;
		
		private int rightS = 4198;
		private int bubbleS = 998;
		
		public override TagCompound Save()
		{
			bool drowned = done;
			//bool downed = false;
			
			return new TagCompound
			{
				{"Drowned",drowned}
			};
		}
		
		public override void Load(TagCompound tag)
		{
			//done = tag.GetBool("Drowned");
		}
		
		public override void PostUpdate()
		{
			//Drowned_Config.Load();
			if (!done)
			{
				if (Drowned_Config.Initail_Flood == "yes")
				{
					if (!Broad)
					{
						if ((Main.maxTilesX-2) == rightL)
						{
							wS = "Large";
						} else if ((Main.maxTilesX-2) == rightM)
						{
							wS = "Medium";
						} else if ((Main.maxTilesX-2) == rightS)
						{
							wS = "Small";
						}
						
						if (wS == "Large")
						{
							k = bubbleL;
							bubble = bubbleL;
							right = rightL;
						} else if (wS == "Medium")
						{
							k = bubbleM;
							bubble = bubbleM;
							right = rightM;
						} else if (wS == "Small")
						{
							k = bubbleS;
							bubble = bubbleS;
							right = rightS;
						} else {
							//done = true;
							Main.NewText("Invalid world.");
							Main.NewText("Rightmost tile is at" + (Main.maxTilesX-2));
							Main.NewText("Large is" + rightL);
							Main.NewText("Medium is" + rightM);
							Main.NewText("Small is" + rightS);
							Main.NewText("Please use one of these three world sizes");
						}
						/*bubble = Main.maxTilesY-204;
						right = Main.maxTilesY-2;
						
						k = bubble - 1;*/
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
			if (!done || rowComplete)
			{
				fillATile(fluidID);
			}
			if (!done || rowComplete)
			{
				fillATile(fluidID);
			}
			if (!done || rowComplete)
			{
				fillATile(fluidID);
			}
			if (!done || rowComplete)
			{
				fillATile(fluidID);
			}
			if (!done || rowComplete)
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
				
				Main.tile[i, bubble].active(true);
				Main.tile[i, bubble].type = 379;
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
				} else if(!Main.tile[i, k].active() || Main.tile[i, k].inActive() || /*!Main.tile[i, k].nactive ||*/ Main.tile[i, k].collisionType != 1) {
					Main.tile[i, k].liquidType(fluidID);
					Main.tile[i, k].liquid = 255;
					WorldGen.SquareTileFrame(i, k, true);
					NetMessage.SendTileSquare(-1, i, k, 1);
				}
				
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
			}
			i += 1;
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
		//private int bubbleS = 998;

		public override void SetControls()
		{
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
			//Main.NewText("Right:" + (Main.maxTilesX - 2));
			
			
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
			
		}
	}
}