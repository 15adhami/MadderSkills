using HarmonyLib;
using Verse;

namespace MadderSkills
{
	public class MadderSkills : Mod
	{
		public MadderSkills(ModContentPack content) : base(content)
		{
			var harmony = new Harmony("com.github.15adhami.madderskills");
			harmony.PatchAll();
		}
	}
}
