using System.Linq;

namespace Enigma.Plugboard
{
    internal static class Validation
    {
        private const int MinWiredPairLength = 2;
        private const int MaxWiredPairLength = 10;



        internal static bool IsNull(string wiredPairs)
        {
            return wiredPairs == null;
        }

        internal static bool IsEmptyOrWhitespace(string wiredPairs)
        {
            return string.IsNullOrWhiteSpace(wiredPairs);
        }

        internal static bool IsToShort(string wiredPairs)
        {
            if (IsNull(wiredPairs))
                return false;

            return wiredPairs.Length < MinWiredPairLength;
        }

        internal static bool IsToLong(string wiredPairs)
        {
            if (IsNull(wiredPairs))
                return false;

            return wiredPairs.Length > MaxWiredPairLength;
        }

        internal static bool IsPairPartMissing(string wiredPairs)
        {
            if (IsNull(wiredPairs))
                return false;

            return wiredPairs.Length%2 != 0;
        }

        internal static bool ContainsNonLetter(string wiredPairs)
        {
            if (IsNull(wiredPairs))
                return false;

            return wiredPairs.Any(c => !char.IsLetter(c));
        }
    }
}
