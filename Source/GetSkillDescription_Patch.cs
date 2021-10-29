using HarmonyLib;
using RimWorld;
using System.Text.RegularExpressions;
using XmlExtensions;

namespace MadderSkills
{
	[HarmonyPatch(typeof(SkillUI))]
	[HarmonyPatch("GetSkillDescription")]
	static class Patch_LearningSaturationUI
	{
		private static void Postfix(ref string __result, SkillRecord sk)
		{
			switch (sk.passion)
			{
				case Passion.None:
					__result = Regex.Replace(__result, "[^:] 35%", new MatchEvaluator(delegate (Match m) { return m.Value[0] + " " + SettingsManager.GetSetting("imranfish.madderskills", "multiplierNoPassion") + "%"; }));
					break;
				case Passion.Minor:
					__result = Regex.Replace(__result, "[^:] 100%", new MatchEvaluator(delegate (Match m) { return m.Value[0] + " " + SettingsManager.GetSetting("imranfish.madderskills", "multiplierMinorPassion") + "%"; }));
					break;
				case Passion.Major:
					__result = Regex.Replace(__result, "[^:] 150%", new MatchEvaluator(delegate (Match m) { return m.Value[0] + " " + SettingsManager.GetSetting("imranfish.madderskills", "multiplierMajorPassion") + "%"; }));
					break;
			}
		}
	}
}
