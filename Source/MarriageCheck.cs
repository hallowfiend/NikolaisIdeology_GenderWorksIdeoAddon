using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace NikolaisIdeology_GenderWorks
{
    public class RitualRole_NotMarriedAlready : RitualRole
    {

        public override bool AppliesToPawn(
            Pawn p,
            out string reason,
            TargetInfo selectedTarget,
            LordJob_Ritual ritual = null,
            RitualRoleAssignments assignments = null,
            Precept_Ritual precept = null,
            bool skipReason = false)
        {
            reason = (string)null;
            int num1;
            if (p == null)
            {
                num1 = 0;
            }
            else
            {
                int? marriageNumber = p.GetSpouseCount(false);
                int num2 = 0;
                num1 = marriageNumber.GetValueOrDefault() > num2 & marriageNumber.HasValue ? 1 : 0;
            }
            if (num1 != 0)
            {
                if (!skipReason)
                    reason = (string)"NikolaisIdeology_MustNotBeMarried".Translate();
                return false;
            }
            int? ageBiologicalYears = p.ageTracker?.AgeBiologicalYears;
            if (ageBiologicalYears < 18)
            {
                reason = (string)"NikolaisIdeology_NoAdultMarriage".Translate((NamedArgument)this.Label);
                return false;
            }
            if (p == null || p.Faction.IsPlayerSafe())
                return true;
            if (!skipReason)
            {
                reason = (string)"MessageRitualRoleMustBeColonist".Translate((NamedArgument)this.Label);
                return false;
            }
            return false;
        }
        public override bool AppliesToRole(
        Precept_Role role,
        out string reason,
        Precept_Ritual ritual = null,
        Pawn p = null,
        bool skipReason = false)
        {
            reason = (string)null;
            return false;
        }
    }
}