using RimWorld;
using Verse;
namespace NikolaisIdeology_GenderWorks
{
    public class RitualPosition_Spouse2 : RitualPosition_VerticalThingCenter
    {
        protected override CellRect GetRect(CellRect thingRect)
        {
            IntVec3 intVec3 = IntVec3.SouthEast + this.offset;
            return new CellRect(thingRect.minX + intVec3.x, thingRect.minZ + intVec3.z, thingRect.Width, 1);
        }
    }

}