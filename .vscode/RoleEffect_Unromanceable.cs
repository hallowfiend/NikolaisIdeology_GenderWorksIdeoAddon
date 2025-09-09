using LoveyDoveySexWithEuterpe;
using RimWorld;
using Verse;

namespace NikolaisIdeology_GenderWorks
{
    public class RoleEffect_Unromanceable : RoleEffect
    {
        public override bool IsBad => true;

        public RoleEffect_Unromanceable() => this.labelKey = "RoleEffectUnromanceable";

        public override bool SexUtilities.CanDoLovinAtAll(Pawn pawn) => false;
    }
}
