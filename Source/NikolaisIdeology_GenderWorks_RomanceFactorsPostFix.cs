using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using System.Text;
using Verse;

namespace NikolaisIdeology_GenderWorks;
[HarmonyPatch(typeof(InteractionWorker_RomanceAttempt), "RomanceFactors")]
[HarmonyPatch("PostAdd")]
public class NikolaisIdeology_GenderWorks_RomanceFactorPostfix
{
    [HarmonyPostfix]
    public void BeautyImportantFactor(ref string __result, Pawn romancer, Pawn romanceTarget)
    {
        float beautyfloat = 1f;
        float statValue = romanceTarget.GetStatValue(StatDefOf.PawnBeauty);
        if (ModsConfig.IdeologyActive && romancer.ideo != null && (romancer.story?.traits == null || !romancer.story.traits.HasTrait(TraitDefOf.Kind) || !romancer.story.traits.HasTrait(TraitDefOf.Ascetic)))
        {
            if (romancer.ideo.Ideo.HasPrecept(InternalDefOf.NikolaisIdeology_Beauty_Central))
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
        stringBuilder.AppendLine((string)("NikolaisIdeology_GenderWorks_BeautyCentral".Translate() + ": x" + beautyfloat.ToStringPercent()));
        __result = stringBuilder.ToString();
    }
}
