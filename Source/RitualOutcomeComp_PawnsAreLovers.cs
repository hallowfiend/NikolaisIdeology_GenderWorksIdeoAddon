using RimWorld;
using System.Collections.Generic;
using Verse;

namespace NikolaisIdeology_GenderWorks
{

    public class RitualOutcomeComp_PawnsAreLovers : RitualOutcomeComp_QualitySingleOffset
    {
        protected override string LabelForDesc => this.label;

        public override bool DataRequired => false;

        public override bool Applies(LordJob_Ritual ritual) {
            return true;
        }

        public override float Count(LordJob_Ritual ritual, RitualOutcomeComp_Data data)
        {
            Pawn pawn1 = ritual.assignments.FirstAssignedPawn("pawn1");
            Pawn pawn2 = ritual.assignments.FirstAssignedPawn("pawn2");
            List<DirectPawnRelation> directRelations = (List<DirectPawnRelation>)PawnRelationUtility.GetRelations(pawn1, pawn2);

            foreach (DirectPawnRelation directRelation in directRelations)
            {
                if (directRelation.def == PawnRelationDefOf.Lover && directRelation.otherPawn == pawn2)
                    return 1;
                else
                    return 0f;
            }
            return 0f;
        }

        public override QualityFactor GetQualityFactor(Precept_Ritual ritual, TargetInfo ritualTarget, RitualObligation obligation, RitualRoleAssignments assignments, RitualOutcomeComp_Data data)
        {
            float quality = 0f;
            bool flag = false;
            Pawn pawn1 = assignments.FirstAssignedPawn("pawn1");
            Pawn pawn2 = assignments.FirstAssignedPawn("pawn2");
            List<DirectPawnRelation> directRelations = (List<DirectPawnRelation>)PawnRelationUtility.GetRelations(pawn1, pawn2);
            foreach (DirectPawnRelation directRelation in directRelations)
            {
                if (directRelation.def == PawnRelationDefOf.Lover && directRelation.otherPawn == pawn2)
                    flag = true;
                    quality = (flag ? qualityOffset : 0f);
            }
            return new QualityFactor
            {
                label = label.CapitalizeFirst(),
                qualityChange = ExpectedOffsetDesc(positive: true, quality),
                quality = quality,
                present = flag,
                positive = true,
                priority = 0f
            };
        }
    }
}