using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace DrownedMod
{
	class Testplayer : ModPlayer
	{
		public override void OnEnterWorld(Player someone)
		{
			string wName = Main.worldName;
			bool expert = Main.expertMode;
//			bool Hard = Main.hardMode;
			string wDiff = (expert) ? "Expert" : "Normal";
			//string wTime = (Hard) ? "(Post WoF)" : "(Pre WoF)";
			string name = Main.ActivePlayerFileData.Name;
			
			RPControl.presence.details = string.Format("Playing World: {0} Difficulty: {1}, Name: {2}", wName, wDiff, name);
			MainMod.UpdaterLoad();
			RPUtility.dead = false;
		}

		public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
		{
			RPUtility.dead = true;
			RPUtility.Update();
		}

		public override void OnRespawn(Player player)
		{
			RPUtility.dead = false;
		}
	}
}