using LoveyDoveySexWithEuterpe;
using RimWorld;
using Verse;
using HarmonyLib;

namespace NikolaisIdeology_GenderWorks
{
    [HarmonyPatch(typeof(SexUtilities), "CanEverDoLovin")]
    public static class NikolaisIdeology_GenderWorks_Lovin_Patch
    {
        [HarmonyPostfix]
        public static void Postfix(Pawn pawn, ref bool __result)
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
