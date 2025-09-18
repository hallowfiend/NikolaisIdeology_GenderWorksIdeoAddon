using RimWorld;
using System.Collections.Generic;
using Verse;
using Verse.AI.Group;


namespace NikolaisIdeology_GenderWorks
{
    public class LordJob_Ritual_ArrangedMarriage : LordJob_Ritual
    {
        public List<Pawn> spouses = new List<Pawn>();
        public Pawn pawn1;
        public Pawn pawn2;
        public bool pawnsAreLovers;
        public bool pawnsAreSpouses;
        protected override int MinTicksToFinish => this.DurationTicks / 2;

        public override bool AllowStartNewGatherings => false;

        public override bool OrganizerIsStartingPawn => true;

        public LordJob_Ritual_ArrangedMarriage()
        {
        }
        protected override bool ShouldCallOffBecausePawnNoLongerOwned(Pawn p)
        {
            return base.ShouldCallOffBecausePawnNoLongerOwned(p) && !this.spouses.Contains(p);
        }

        public override bool ShouldRemovePawn(Pawn p, PawnLostCondition reason)
        {
            return reason != PawnLostCondition.Incapped && base.ShouldRemovePawn(p, reason);
        }

        public override bool NeverInRestraints => true;
        public override bool BlocksSocialInteraction(Pawn pawn) => this.spouses.Contains(pawn);

        public LordJob_Ritual_ArrangedMarriage(
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
