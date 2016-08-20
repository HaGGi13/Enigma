using System;
using System.Linq;

namespace Enigma.Plugboard
{
    internal static class Validation
    {
        private const int MaxWiredPairLength = 20;



        internal static bool IsNull(string wiredPairs)
        {
            return wiredPairs == null;
        }
        
        internal static bool IsToLong(string wiredPairs)
        {
            if (IsNull(wiredPairs))
                throw new ArgumentNullException(nameof(wiredPairs));

            return wiredPairs.Length > MaxWiredPairLength;
        }

        internal static bool IsPairPartMissing(string wiredPairs)
        {
            if (IsNull(wiredPairs))
                throw new ArgumentNullException(nameof(wiredPairs));

            return wiredPairs.Length%2 != 0;
        }

        internal static bool ContainsNonLetter(string wiredPairs)
        {
            if (IsNull(wiredPairs))
                throw new ArgumentNullException(nameof(wiredPairs));

            return wiredPairs.Any(c => !char.IsLetter(c));
        }
    }
}
