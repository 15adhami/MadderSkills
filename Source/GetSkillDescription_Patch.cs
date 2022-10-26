using HarmonyLib;
using RimWorld;
using System;
using System.Text.RegularExpressions;
using XmlExtensions;

namespace MadderSkills
{
	[HarmonyPatch(typeof(SkillUI))]
	[HarmonyPatch("GetLearningFactor")]
	static class Patch_GetLearningFactor
	{
		public static void Postfix(Passion passion, ref float __result)
		{
			switch (passion)
			{
				case Passion.None:
					__result = float.Parse(SettingsManager.GetSetting("imranfish.madderskills", "multiplierNoPassion")) / 100f;
					break;
				case Passion.Minor:
					__result = float.Parse(SettingsManager.GetSetting("imranfish.madderskills", "multiplierMinorPassion")) / 100f;
					break;
				case Passion.Major:
					__result = float.Parse(SettingsManager.GetSetting("imranfish.madderskills", "multiplierMajorPassion")) / 100f;
					break;
				default:
					throw new NotImplementedException("Passion level " + passion);
			}
		}
	}
}
