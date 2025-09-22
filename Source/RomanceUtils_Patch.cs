using HarmonyLib;
using RimWorld;
using Verse;

namespace NikolaisIdeology_GenderWorks
{
    [HarmonyPatch(typeof(RelationsUtility), "AttractedToGender")]
    public static class NikolaisIdeology_RelationsUtil_Patch
    {
        [HarmonyPostfix]
        public static void UnromanceableRole(Pawn pawn, ref bool __result)
        {
            if (pawn != null && pawn.Ideo != null)
            {
                Precept_Role role = pawn.Ideo.GetRole(pawn);
                if (role != null && role.def.roleEffects != null)
                {
                    foreach (RoleEffect roleEffect in role.def.roleEffects)
                    {
                        if (roleEffect is NikolaisIdeology_GenderWorks.RoleEffect_Unromanceable)
                        {
                            __result = false;
                        }
                    }
                }
            }
        }
    }
}
