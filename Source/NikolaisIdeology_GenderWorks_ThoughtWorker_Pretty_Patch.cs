using RimWorld;
using Verse;
using HarmonyLib;

namespace NikolaisIdeology.GenderWorks;

[HarmonyPatch(typeof(ThoughtWorker_Pretty))]
[HarmonyPatch("PostAdd")]
public static class NikolaisIdeology_GenderWorks_ThoughtWorker_Pretty_Patch
{
    [HarmonyPostfix]
    private static void DontShowIfBeautyPrecept(Pawn p, ref ThoughtState __result)
    {
        Pawn_IdeoTracker ideo1 = p.ideo;
        bool? nullable1;
        int num1;
        if (ideo1 == null)
        {
            num1 = 0;
        }
        else
        {
            nullable1 = ideo1.Ideo?.HasPrecept(InternalDefOf.NikolaisIdeology_Beauty_Central);
            num1 = nullable1.GetValueOrDefault() ? 1 : 0;
        }
        int num2;
        if (num1 == 0)
        {
            Pawn_IdeoTracker ideo2 = p.ideo;
            if (ideo2 == null)
            {
                num2 = 0;
            }
            else
            {
                Ideo ideo3 = ideo2.Ideo;
                bool? nullable2;
                if (ideo3 == null)
                {
                    nullable1 = new bool?();
                    nullable2 = nullable1;
                }
                else
                    nullable2 = new bool?(ideo3.HasPrecept(InternalDefOf.NikolaisIdeology_Beauty_Unimportant));
                nullable1 = nullable2;
                num2 = nullable1.GetValueOrDefault() ? 1 : 0;
            }
        }
        else
            num2 = 1;
        if (num2 == 0)
            return;
        __result = (ThoughtState)false;
    }
}
