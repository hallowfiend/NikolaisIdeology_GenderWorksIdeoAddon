using RimWorld;
using System;
using System.Collections.Generic;
using UnityEngine.UIElements;
using Verse;

namespace NikolaisIdeology_GenderWorks
{

    public class RitualOutcomeComp_PawnsAreLovers : RitualOutcomeComp_QualitySingleOffset
    {
        protected override string LabelForDesc => this.label;

        public override bool DataRequired => false;

        private bool positive = false;

        public override bool Applies(LordJob_Ritual ritual)
        {
            
            Pawn pawn1 = ritual.assignments.FirstAssignedPawn("pawn1");
            Pawn pawn2 = ritual.assignments.FirstAssignedPawn("pawn2");
            List<DirectPawnRelation> directRelations = (List<DirectPawnRelation>)PawnRelationUtility.GetRelations(pawn1, pawn2);
            foreach (var rel in directRelations)
            {
                if (rel.def == PawnRelationDefOf.Lover && rel.otherPawn == pawn2)
                    positive = true;
                    return true;
            }
            return false;
        }

        public override QualityFactor GetQualityFactor(Precept_Ritual ritual, TargetInfo ritualTarget, RitualObligation obligation, RitualRoleAssignments assignments, RitualOutcomeComp_Data data)
        {
            float quality = this.qualityOffset;
            return new QualityFactor
            {
                label = label.CapitalizeFirst(),
                qualityChange = this.ExpectedOffsetDesc(positive, quality),
                quality = qualityOffset,
                positive = positive,
                present = positive,
                priority = 0f
            };
        }
    }
}