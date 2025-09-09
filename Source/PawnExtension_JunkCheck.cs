using LoveyDoveySexWithRosaline;
using Verse;
using RimWorld;

namespace NikolaisIdeology_GenderWorks
{

    public static class GenderUtil_IsAphrodor
    {
        public static bool IsAphrodor(this Pawn pawn)
        {
            return GenderUtilities.HasMaleReproductiveOrgan(pawn) && GenderUtilities.HasFemaleReproductiveOrgan(pawn);

        }
    }
    public static class GenderUtil_IsNeutor
    {
        public static bool IsNeutor(this Pawn pawn)
        {
            return !GenderUtilities.HasAnyReproductiveOrgan(pawn);
        }
    }
}
