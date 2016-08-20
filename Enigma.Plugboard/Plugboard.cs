using System;

namespace Enigma.Plugboard
{
    public class Plugboard
    {
        public Plugboard(string wiredPairs = "")
        {
            if (Validation.IsNull(wiredPairs))
                throw new ArgumentNullException(nameof(wiredPairs));

            if (Validation.IsEmptyOrWhitespace(wiredPairs))
                throw new ArgumentException("Wired pairs string cannot be empty or white spaces.");

            if (Validation.IsToShort(wiredPairs) || Validation.IsToLong(wiredPairs))
                throw new ArgumentException("A wired pair string must be greater or equal 2 and less or equal 10.");

            if (Validation.IsPairPartMissing(wiredPairs))
                throw new ArgumentException("Wired pairs must be pairs. Every letter must have another one.");

            if (Validation.ContainsNonLetter(wiredPairs))
                throw new ArgumentException("Wired pairs must consist of letters only.");
        }
    }
}
