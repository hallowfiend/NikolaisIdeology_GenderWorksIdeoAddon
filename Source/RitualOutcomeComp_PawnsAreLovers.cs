using RimWorld;
using System;
using Verse;

namespace NikolaisIdeology_GenderWorks
{

    public class RitualOutcomeComp_PawnsAreLovers : RitualOutcomeComp_QualitySingleOffset
    {
        protected override string LabelForDesc => this.label;

        public override bool DataRequired => false;

        public override bool Applies(LordJob_Ritual ritual) => ritual is LordJob_Ritual_ArrangedMarriage lordJobRitualArrangedMarriage && (PawnRelationUtility.GetRelations(lordJobRitualArrangedMarriage.pawn1, lordJobRitualArrangedMarriage.pawn2) = PawnRelationDefOf.Lover);

        public override QualityFactor GetQualityFactor(
          Precept_Ritual ritual,
          TargetInfo ritualTarget,
          RitualObligation obligation,
          RitualRoleAssignments assignments,
          RitualOutcomeComp_Data data)
        {
            return new QualityFactor()
            {
                label = this.LabelForDesc.CapitalizeFirst(),
                present = false,
                uncertainOutcome = true,
                qualityChange = this.ExpectedOffsetDesc(true, -0.5f),
                quality = this.qualityOffset,
                positive = true
            };
        }
    }
}