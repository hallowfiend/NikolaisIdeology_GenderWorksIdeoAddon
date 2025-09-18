using RimWorld;
using Verse;
using Verse.AI.Group;


namespace NikolaisIdeology_GenderWorks
{

    public class RitualBehaviorWorker_ArrangedMarriage : RitualBehaviorWorker
    {
        public RitualBehaviorWorker_ArrangedMarriage()
        {
        }

        public RitualBehaviorWorker_ArrangedMarriage(RitualBehaviorDef def)
          : base(def)
        {
        }
        protected override LordJob CreateLordJob(
        TargetInfo target,
        Pawn organizer,
        Precept_Ritual ritual,
        RitualObligation obligation,
        RitualRoleAssignments assignments)
        {
            return (LordJob)new LordJob_Ritual_ArrangedMarriage(target, ritual, obligation, this.def.stages, assignments, organizer);
        }
    }
}