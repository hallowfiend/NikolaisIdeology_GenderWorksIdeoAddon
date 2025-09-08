using RimWorld;
using System.Collections;
using System.Collections.Generic;
using Verse;
using LoveyDoveySexWithRosaline;

namespace NikolaisIdeology_GenderWorks;

public class RoleRequirement_NoLoveRelations : RoleRequirement
{
    public static readonly RoleRequirement_NoLoveRelations Requirement = new RoleRequirement_NoLoveRelations();

    public override string GetLabel(Precept_Role role)
    {
        return (string)"RoleRequirementNoLoveRelations".Translate();
    }

    public override bool Met(Pawn p, Precept_Role role)
    {
        List<DirectPawnRelation> lovelist = SpouseRelationUtility.GetLoveRelations(p, false);
        if (lovelist.Count == 0)
            return true;
        else
            return false;
    }
}
