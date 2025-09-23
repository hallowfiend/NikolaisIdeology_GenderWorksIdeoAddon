using RimWorld;
using System.Collections.Generic;
using Verse;
using Verse.Sound;

namespace NikolaisIdeology_GenderWorks
{
    public class RitualOutcomeEffectWorker_ArrangedMarriage : RitualOutcomeEffectWorker_FromQuality
    {

        public RitualOutcomeEffectWorker_ArrangedMarriage()
        {
        }

        public RitualOutcomeEffectWorker_ArrangedMarriage(RitualOutcomeEffectDef def)
          : base(def)
        {
        }


        public override void Apply(
        float progress,
        Dictionary<Pawn, int> totalPresence,
        LordJob_Ritual jobRitual)
        {
            RitualOutcomePossibility outcome = this.GetOutcome(this.GetQuality(jobRitual, progress), jobRitual);
            LookTargets selectedTarget = (LookTargets)jobRitual.selectedTarget;
            string extraLetterText = (string)null;
            float quality = this.GetQuality(jobRitual, progress);
            Pawn pawn1 = jobRitual.PawnWithRole("pawn1");
            Pawn pawn2 = jobRitual.PawnWithRole("pawn2");
            if (jobRitual.Ritual != null)
                this.ApplyAttachableOutcome(totalPresence, jobRitual, outcome, out extraLetterText, ref selectedTarget);
            bool flag = false;
            foreach (Pawn key in totalPresence.Keys)
                this.GiveMemoryToPawn(key, outcome.memory, jobRitual);
            if (outcome.positivityIndex < -1)
                return;
            pawn1.relations.RemoveDirectRelation(PawnRelationDefOf.Lover, pawn2);
            MarriageCeremonyUtility.Married(pawn1, pawn2);
            if (outcome.Positive)
            {
                float xp = outcome.BestPositiveOutcome(jobRitual) ? 5000f : 2500f;
                foreach (Pawn key in totalPresence.Keys)
                {
                    if (jobRitual.assignments.RoleForPawn(key).id == "officiator")
                    {
                        key.skills.Learn(SkillDefOf.Social, xp);
                    }
                    else if ((jobRitual.assignments.RoleForPawn(key).id == "pawn1") || (jobRitual.assignments.RoleForPawn(key).id == "pawn2"))
                    {
                        key.health.AddHediff(InternalDefOf.NikolaisIdeology_BeFruitful);
                    }
                }
            }
            string text = (string)(outcome.description.Formatted((NamedArgument)jobRitual.Ritual.Label).CapitalizeFirst() + "\n\n" + this.OutcomeQualityBreakdownDesc(quality, progress, jobRitual));
            string str = this.def.OutcomeMoodBreakdown(outcome);
            if (!str.NullOrEmpty())
                text = $"{text}\n\n{str}";
            if (flag)
                text = (string)(text + ("\n\n" + "RitualOutcomeExtraDesc_Execution".Translate()));
            if (extraLetterText != null)
                text = $"{text}\n\n{extraLetterText}";
            string extraOutcomeDesc;
            this.ApplyDevelopmentPoints(jobRitual.Ritual, outcome, out extraOutcomeDesc);
            if (extraOutcomeDesc != null)
                text = $"{text}\n\n{extraOutcomeDesc}";
            Find.LetterStack.ReceiveLetter("OutcomeLetterLabel".Translate(outcome.label.Named("OUTCOMELABEL"), jobRitual.Ritual.Label.Named("RITUALLABEL")), (TaggedString)text, outcome.Positive ? LetterDefOf.RitualOutcomePositive : LetterDefOf.RitualOutcomeNegative, selectedTarget);
            InternalDefOf.Relic_Installed.PlayOneShot((SoundInfo)new TargetInfo(jobRitual.selectedTarget.Cell, jobRitual.Map));
        }
    }
}
