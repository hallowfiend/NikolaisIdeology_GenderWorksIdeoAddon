using RimWorld;
using System;
using Verse;
namespace NikolaisIdeology_GenderWorks
{
    public class RitualPosition_Spouse2 : RitualPosition_VerticalThingCenter
    {
        public override PawnStagePosition GetCell(IntVec3 spot, Pawn p, LordJob_Ritual ritual)
        {
            Thing thing = spot.GetThingList(p.Map).FirstOrDefault<Thing>((Predicate<Thing>)(t => t == ritual.selectedTarget.Thing));
            CellRect cellRect = thing != null ? thing.OccupiedRect() : CellRect.SingleCell(spot);
            Map mapHeld = p.MapHeld;
            CellRect rect = this.GetRect(cellRect);
            Func<IntVec3, bool> Validator = CommonRitualCellPredicates.DefaultValidator(spot, mapHeld, p, cellRect);
            if (Validator(rect.CenterCell))
                return new PawnStagePosition(rect.CenterCell, thing, Rot4.West, this.highlight);
            IntVec3 cell = IntVec3.Invalid;
            for (int index = 0; index < 16 /*0x10*/ && index < rect.Width; ++index)
            {
                IntVec3 randomCell = rect.RandomCell;
                if (Validator(randomCell))
                {
                    cell = randomCell;
                    break;
                }
            }
            if (!cell.IsValid)
                cell = this.GetFallbackSpot(cellRect, spot, p, ritual, Validator);
            return new PawnStagePosition(cell, thing, Rot4.West, this.highlight);
        }
        protected override CellRect GetRect(CellRect thingRect)
        {
            IntVec3 intVec3 = IntVec3.SouthEast + this.offset;
            return new CellRect(thingRect.minX + intVec3.x, thingRect.minZ + intVec3.z, thingRect.Width, 1);
        }
    }

}