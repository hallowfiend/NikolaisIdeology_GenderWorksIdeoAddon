using RimWorld;
using System.Collections.Generic;
using Verse;

namespace NikolaisIdeology_GenderWorks
{
    public class RitualOutcomeEffectWorker_ArrangedMarriage : RitualOutcomeEffectWorker_FromQuality
    {
        public const float RecreationGainGood = 0.25f;
        public const float RecreationGainBest = 0.5f;
        public const float SocialXPGainParticipantGood = 2500f;
        public const float SocialXPGainParticipantBest = 5000f;
        public const float IntimacyGainGood = 0.5f;
        public const float IntimacyGainBest = 1.0f;

        public RitualOutcomeEffectWorker_ArrangedMarriage()
        {
        }

        public RitualOutcomeEffectWorker_ArrangedMarriage(RitualOutcomeEffectDef def)
          : base(def)
        {
        }

        protected override void ApplyExtraOutcome(
          Dictionary<Pawn, int> totalPresence,
          LordJob_Ritual jobRitual,
          RitualOutcomePossibility outcome,
          out string extraOutcomeDesc,
          ref LookTargets letterLookTargets)
        {
            extraOutcomeDesc = (string)null;
            LordJob_Ritual_ArrangedMarriage lordJobArrangedMarriage = (LordJob_Ritual_ArrangedMarriage)jobRitual;
            Pawn pawn2 = lordJobArrangedMarriage.PawnWithRole("pawn2");
            if (outcome.positivityIndex < -1)
                return;
            foreach (Pawn key in totalPresence.Keys)
            {
                if (lordJobArrangedMarriage.assignments.RoleForPawn(key).id == "pawn1")
                {
                    MarriageCeremonyUtility.Married(key, pawn2);
                }
            }
            if (!outcome.Positive)
                return;
            float xp = outcome.BestPositiveOutcome(jobRitual) ? 5000f : 2500f;
            foreach (Pawn key in totalPresence.Keys)
            {
                if (lordJobArrangedMarriage.assignments.RoleForPawn(key).id == "officiator")
                {
                    key.skills.Learn(SkillDefOf.Social, xp);
                }
                else if (lordJobArrangedMarriage.spouses.Contains(key))
                {
                    key.health.AddHediff(InternalDefOf.NikolaisIdeology_BeFruitful);
                }
            }
        }
    }
}
