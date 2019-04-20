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
//using Terraria.ModLoader.Config;
//using Terraria.ModLoader.Config.UI;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;

namespace DrownedMod
{
	public class Flowering_Bulb : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Summons a plant.\nReuseable! Has a cooldown.");
			DisplayName.SetDefault("Flowering Bulb");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 20;
			item.rare = 9;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.UseSound = SoundID.Item44;
			item.consumable = true;
		}

		// We use the CanUseItem hook to prevent a player from using this item while the boss is present in the world.
		public override bool CanUseItem(Player player)
		{
			// "player.ZoneUnderworldHeight" could also be written as "player.position.Y / 16f > Main.maxTilesY - 200"
			return (NPC.downedMechBossAny && !NPC.AnyNPCs(NPCID.Plantera));
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.Plantera);
			Main.PlaySound(SoundID.Roar, player.position, 0);
			item.stack = 2;
			return true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(TileID.DemonAltar);
			//recipe.needLava = false;
			recipe.needWater = true;
			//recipe.needHoney = false;
			recipe.AddIngredient(ItemID.GrassSeeds, 5);
			recipe.AddIngredient(ItemID.PurificationPowder, 1);
			recipe.AddIngredient(ItemID.JungleGrassSeeds, 6);
			recipe.AddIngredient(ItemID.Stinger, 1);
			recipe.AddIngredient(ItemID.Vine, 3);
			recipe.AddIngredient(ItemID.JungleSpores, 2);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
			
			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddTile(TileID.DemonAltar);
			//recipe.needLava = false;
			recipe2.needWater = true;
			//recipe.needHoney = false;
			recipe2.AddIngredient(ItemID.GrassSeeds, 5);
			recipe2.AddIngredient(ItemID.PurificationPowder, 1);
			recipe2.AddIngredient(ItemID.JungleGrassSeeds, 6);
			recipe2.AddIngredient(ItemID.Stinger, 1);
			recipe2.AddIngredient(ItemID.VineRope, 3);
			recipe2.AddIngredient(ItemID.JungleSpores, 2);
			recipe2.SetResult(this, 1);
			recipe2.AddRecipe();
		}
	}
}