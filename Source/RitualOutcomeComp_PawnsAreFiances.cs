using RimWorld;
using System.Collections.Generic;
using Verse;

namespace NikolaisIdeology_GenderWorks
{

    public class RitualOutcomeComp_PawnsAreFiances : RitualOutcomeComp_QualitySingleOffset
    {
        protected override string LabelForDesc => this.label;

        public override bool DataRequired => false;

        private bool flag = false;

        public override bool Applies(LordJob_Ritual ritual)
        {

            Pawn pawn1 = ritual.assignments.FirstAssignedPawn("pawn1");
            Pawn pawn2 = ritual.assignments.FirstAssignedPawn("pawn2");
            if (pawn1.relations.DirectRelationExists(PawnRelationDefOf.Fiance, pawn2) == true && ritual is LordJob_Ritual_ArrangedMarriage)
                flag = true;
                return true;
        }

        public override QualityFactor GetQualityFactor(Precept_Ritual ritual, TargetInfo ritualTarget, RitualObligation obligation, RitualRoleAssignments assignments, RitualOutcomeComp_Data data)
        {
            float quality = this.qualityOffset;
            return new QualityFactor
            {
                label = label.CapitalizeFirst(),
                qualityChange = this.ExpectedOffsetDesc(flag, quality),
                quality = qualityOffset,
                positive = true,
                present = flag,
                uncertainOutcome = true,
                priority = 0f
            };
        }
    }
}