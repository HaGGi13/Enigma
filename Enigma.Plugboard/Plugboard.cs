using System;
using System.Linq;

namespace Enigma.Plugboard
{
    public class Plugboard
    {
        public Plugboard(string wiredPairs)
        {
            if (wiredPairs == null)
                throw new ArgumentNullException(nameof(wiredPairs));

            if (string.IsNullOrWhiteSpace(wiredPairs))
                throw new ArgumentException("Wired pairs string cannot be empty or white spaces.");

            if (wiredPairs.Length < 2 || wiredPairs.Length > 10)
                throw new ArgumentException("A wired pair string must be greater or equal 2 and less or equal 10.");

            if (wiredPairs.Length % 2 != 0)
                throw new ArgumentException("Wired pairs must be pairs. Every letter must have another one.");

            if (wiredPairs.Any(c => !char.IsLetter(c)))
                throw new ArgumentException("Wired pairs must consist of letters only.");
        }
    }
}
