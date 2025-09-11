
using Verse;
using Rimworld;

#nullable disable
namespace NikolaisIdeology_GenderWorks
{

    public class ThoughtWorker_Precept_NeedBeauty : ThoughtWorker_Precept
    {
        protected override ThoughtState ShouldHaveThought(Pawn p)
        {
            return ThoughtWorker_NeedBeauty.CurrentThoughtState(p);
        }
    }
}