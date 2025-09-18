using RimWorld;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine.UIElements;
using Verse;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

namespace NikolaisIdeology_GenderWorks
{

    public class RitualOutcomeComp_PawnsAreFiances : RitualOutcomeComp_QualitySingleOffset
    {
        protected override string LabelForDesc => this.label;

        public override bool DataRequired => false;

        public override bool Applies(LordJob_Ritual ritual)
        {
            Pawn pawn1 = ritual.assignments.FirstAssignedPawn("pawn1");
            Pawn pawn2 = ritual.assignments.FirstAssignedPawn("pawn2");
            List<DirectPawnRelation> directRelations = (List<DirectPawnRelation>)PawnRelationUtility.GetRelations(pawn1, pawn2);

            foreach (DirectPawnRelation directRelation in directRelations)
            {
                if (directRelation.def == PawnRelationDefOf.Fiance && directRelation.otherPawn == pawn2)
                    return true;
                else
                    return false;
            }
            return false;
        }

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
                qualityChange = this.ExpectedOffsetDesc(true, 1f),
                quality = this.qualityOffset,
                positive = true
            };
        }
    }
}