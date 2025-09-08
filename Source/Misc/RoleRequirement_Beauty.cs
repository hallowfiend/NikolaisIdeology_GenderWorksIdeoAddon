using RimWorld;
using Verse;

namespace NikolaisIdeology.GenderWorks;

public class RoleRequirement_Beauty : RoleRequirement
{
    public static readonly RoleRequirement_Beauty Requirement = new RoleRequirement_Beauty();

    public override string GetLabel(Precept_Role role)
    {
        return (string)"RoleRequirementBeauty".Translate();
    }

    public override bool Met(Pawn p, Precept_Role role) => (p.GetStatValue(StatDefOf.PawnBeauty) >= 1.0);
}

