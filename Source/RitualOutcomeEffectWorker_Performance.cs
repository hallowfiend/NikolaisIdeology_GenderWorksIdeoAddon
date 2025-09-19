using LoveyDoveySexWithEuterpe;
using RimWorld;
using System.Collections.Generic;
using Verse;

namespace NikolaisIdeology_GenderWorks
{
	public class RitualOutcomeEffectWorker_Performance : RitualOutcomeEffectWorker_FromQuality
	{
		public const float RecreationGainGood = 0.25f;
		public const float RecreationGainBest = 0.5f;
		public const float SocialXPGainParticipantGood = 2500f;
		public const float SocialXPGainParticipantBest = 5000f;
		public const float IntimacyGainGood = 0.5f;
		public const float IntimacyGainBest = 1.0f;

		public RitualOutcomeEffectWorker_Performance()
		{
		}

		public RitualOutcomeEffectWorker_Performance(RitualOutcomeEffectDef def)
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
			if (!outcome.Positive)
				return;
			float recamount = outcome.BestPositiveOutcome(jobRitual) ? 0.5f : 0.25f;
			float intamount = outcome.BestPositiveOutcome(jobRitual) ? 1.0f : 0.5f;
			float xp = outcome.BestPositiveOutcome(jobRitual) ? 5000f : 2500f;
			LordJob_Ritual_Performance lordJobPerformance = (LordJob_Ritual_Performance)jobRitual;
			foreach (Pawn key in totalPresence.Keys)
			{
				if (lordJobPerformance.performer.Contains(key))
					{
					key.skills.Learn(SkillDefOf.Social, xp);
					key.needs?.TryGetNeed<Need_Intimacy>()?.GainIntimacy(intamount);
				}
				else
				{
					key.needs?.joy?.GainJoy(recamount, JoyKindDefOf.Social);
					key.needs?.TryGetNeed<Need_Intimacy>()?.GainIntimacy(0.25f);
				}
			}
		}
	}
}
