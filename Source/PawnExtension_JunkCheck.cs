using LoveyDoveySexWithRosaline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VEF;
using Verse;

namespace NikolaisIdeology.GenderWorks
{

    public static class GenderUtil_IsAphrodor
    {
        public static bool IsAphrodor(this Pawn pawn)
        {
            return (GenderUtilities.HasMaleReproductiveOrgan(pawn) && GenderUtilities.HasFemaleReproductiveOrgan(pawn));

        }
    }
    public static class GenderUtil_IsNeutor
    {
        public static bool IsNeutor(this Pawn pawn)
        {
            return (!GenderUtilities.HasAnyReproductiveOrgan(pawn));
        }
    }
}
