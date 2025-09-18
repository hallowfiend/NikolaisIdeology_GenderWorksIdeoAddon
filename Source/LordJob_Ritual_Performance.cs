using RimWorld;
using System.Collections.Generic;
using Verse;
using Verse.AI.Group;


namespace NikolaisIdeology_GenderWorks
{
    public class LordJob_Ritual_Performance : LordJob_Ritual
    {
        public List<Pawn> performer = new List<Pawn>();
        protected override int MinTicksToFinish => this.DurationTicks / 2;

        public override bool AllowStartNewGatherings => false;

        public override bool OrganizerIsStartingPawn => true;

        public LordJob_Ritual_Performance()
        {
        }

        public LordJob_Ritual_Performance(
          TargetInfo selectedTarget,
          Precept_Ritual ritual,
          RitualObligation obligation,
          List<RitualStage> allStages,
          RitualRoleAssignments assignments,
          Pawn organizer = null)
          : base(selectedTarget, ritual, obligation, allStages, assignments, organizer)
        { }
    }
}
