using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;

namespace DrownedMod
{
	public class DrownedMod : Mod
	{
	}
	
	public class startup: ModWorld
	{
		private int i = 0; //x
		private int k = 2196; //y
		
		private bool Broad = false;
		private bool done = false;
		
		private int left = 0;
		private int right = 8398;
		private int top = 0;
		private int bubble = 2197;
		
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
			done = tag.GetBool("Drowned");
			//downedDow = downed.Contains("downed");
		}
		
		public override void PostUpdate()
		{
			if (!done)
			{
				if (!Broad)
				{
					Main.NewText("Please wait while water is added");
					Broad = true;
				}
				fill152587890625Tile();
				fill152587890625Tile();
				fill152587890625Tile();
				fill152587890625Tile();
				fill152587890625Tile();
				fill152587890625Tile();
			} else {
				fillARoofTile();
				fillARoofTile();
				fillARoofTile();
				fillARoofTile();
				fillARoofTile();
			}
		}
		
		public virtual void fill152587890625Tile()
		{
			fill390625Tile();
			fill390625Tile();
			fill390625Tile();
			fill390625Tile();
			fill390625Tile();
		}
		
		public virtual void fill390625Tile()
		{
			fill625Tile();
			fill625Tile();
			fill625Tile();
			fill625Tile();
			fill625Tile();
		}
		
		public virtual void fill625Tile()
		{
			fillTwentyFiveTile();
			fillTwentyFiveTile();
			fillTwentyFiveTile();
			fillTwentyFiveTile();
			fillTwentyFiveTile();
		}
		
		public virtual void fillTwentyFiveTile()
		{
			fillFiveTile();
			fillFiveTile();
			fillFiveTile();
			fillFiveTile();
			fillFiveTile();
		}
		
		public virtual void fillFiveTile()
		{
			fillATile();
			fillATile();
			fillATile();
			fillATile();
			fillATile();
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
		
		public virtual void fillATile()
		{
				
				Main.tile[i, bubble].active(true);
				Main.tile[i, bubble].type = 379;
				//Main.NewText(i);
				if(Main.tile[i, k].liquid > 0)
				{
					if(Main.tile[i, k].liquidType() == 0)
					{
						Main.tile[i, k].liquidType(0);
						Main.tile[i, k].liquid = 255;
						WorldGen.SquareTileFrame(i, k, true);
						NetMessage.SendTileSquare(-1, i, k, 1);
					}
				} else if(!Main.tile[i, k].active() || Main.tile[i, k].inActive() || /*!Main.tile[i, k].nactive ||*/ Main.tile[i, k].collisionType == 3) {
					Main.tile[i, k].liquidType(0);
					Main.tile[i, k].liquid = 255;
					WorldGen.SquareTileFrame(i, k, true);
					NetMessage.SendTileSquare(-1, i, k, 1);
				}
				
			if (i > right)
			{
				i = left;
				k -= 1;
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
	
	//public class Text : ModPlayer
	//{
	//	public override void SetControls()
	//	{
	//		Main.NewText("tX:" + player.position.X/16);
	//	}
	//}
}