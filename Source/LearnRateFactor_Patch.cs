using HarmonyLib;
using RimWorld;
using System;
using XmlExtensions;

namespace MadderSkills
{

	[HarmonyPatch(typeof(SkillRecord))]
	[HarmonyPatch("LearnRateFactor")]
	static class Patch_LearningSaturation
	{
		static void Postfix(Passion ___passion, ref float __result, SkillDef ___def, bool direct = false)
		{
			// Stat multiplier
			__result *= float.Parse(SettingsManager.GetSetting("imranfish.madderskills",  ___def.defName + "StatMultiplier")) / 100f;

			switch (___passion)
			{
				case Passion.None:
					__result *= float.Parse(SettingsManager.GetSetting("imranfish.madderskills", "multiplierNoPassion")) / 0.35f / 100f;
					break;
				case Passion.Minor:
					__result *= float.Parse(SettingsManager.GetSetting("imranfish.madderskills", "multiplierMinorPassion")) / 100f;
					break;
				case Passion.Major:
					__result *= float.Parse(SettingsManager.GetSetting("imranfish.madderskills", "multiplierMajorPassion")) / 1.5f / 100f;
					break;
				default:
					throw new NotImplementedException("Passion level " + ___passion);
			}
		}
	}
}
