using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using System.Text;
using Verse;
using LoveyDoveySexWithEuterpe;

namespace NikolaisIdeology_GenderWorks
{
    [HarmonyPatch(typeof(InteractionWorker_RomanceAttempt), "RomanceFactors")]
    [HarmonyPatch("PostAdd")]
    public class NikolaisIdeology_GenderWorks_RomanceFactorPostfix
    {
        [HarmonyPostfix]
        public static void BeautyImportantFactor(ref string __result, Pawn romancer, Pawn romanceTarget)
        {
            float beautyfloat = 1f;
            float statValue = romanceTarget.GetStatValue(StatDefOf.PawnBeauty);
            if (romancer.ideo != null && (romancer.story?.traits == null || !romancer.story.traits.HasTrait(TraitDefOf.Kind) || !romancer.story.traits.HasTrait(TraitDefOf.Ascetic)))
            {
                if (CommonChecks.HasIdeoPrecept(romancer, "NikolaisIdeology_Beauty_Central"))
                    {
                    if ((double)statValue >= 0.0)
                        beautyfloat = 1f;
                    else
                        beautyfloat = 0f;
                }
            }
            else
                return;
            StringBuilder stringBuilder = new StringBuilder(__result);
            stringBuilder.AppendLine((string)("NikolaisIdeology_Beauty_Central".Translate() + ": x" + beautyfloat.ToStringPercent()));
            __result = stringBuilder.ToString();
        }
    }
}
