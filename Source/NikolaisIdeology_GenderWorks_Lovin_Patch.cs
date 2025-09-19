using HarmonyLib;
using LoveyDoveySexWithEuterpe;
using RimWorld;
using Verse;

namespace NikolaisIdeology_GenderWorks
{
    [HarmonyPatch(typeof(SexUtilities), "CanDoLovinAtAll")]
    public static class NikolaisIdeology_GenderWorks_Lovin_Patch
    {
        [HarmonyPrefix]
        public static void Prefix(Pawn pawn, ref bool __result)
        {
            if (pawn != null && pawn.Ideo != null)
            {
                Precept_Role role = pawn.Ideo.GetRole(pawn);
                if (role != null && role.def.roleEffects != null)
                {
                    foreach (RoleEffect roleEffect in role.def.roleEffects)
                    {
                        if (roleEffect is RoleEffect_Unromanceable)
                        {
                            __result = false;
                        }
                    }
                }
            }
        }
    }
}
