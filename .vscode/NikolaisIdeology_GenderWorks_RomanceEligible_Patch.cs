using HarmonyLib;
using LoveyDoveySexWithEuterpe;
using LoveyDoveySexWithRosaline;
using RimWorld;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Verse;

namespace NikolaisIdeology_GenderWorks
{
    [HarmonyPatch(typeof(RelationsUtility), "RomanceEligible")]
    public static class NikolaisIdeology_GenderWorks_RomanceEligible_Patch
    {
        [HarmonyPrefix]
        public static void UnromanceableRole(Pawn pawn, ref bool __result)
        {
            if (ModsConfig.IdeologyActive && pawn != null && pawn.Ideo != null)
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