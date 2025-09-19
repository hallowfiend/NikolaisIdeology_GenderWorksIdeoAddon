using RimWorld;

namespace NikolaisIdeology_GenderWorks
{
    public class RoleEffect_Unromanceable : RoleEffect
    {
        public override bool IsBad => true;

        public RoleEffect_Unromanceable() => this.labelKey = "RoleEffectUnromanceable";
    }
}
