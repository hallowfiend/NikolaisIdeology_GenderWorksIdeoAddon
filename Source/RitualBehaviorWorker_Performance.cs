using RimWorld;
using Verse;
using Verse.AI.Group;

namespace NikolaisIdeology_GenderWorks
{

    public class RitualBehaviorWorker_Performance : RitualBehaviorWorker
    {
        public RitualBehaviorWorker_Performance()
        {
        }

        public RitualBehaviorWorker_Performance(RitualBehaviorDef def)
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
            return (LordJob)new LordJob_Ritual_Performance(target, ritual, obligation, this.def.stages, assignments, organizer);
        }
    }
}
