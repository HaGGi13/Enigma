using System;
using System.Collections.Generic;

namespace Enigma.Plugboard
{
    public class Plugboard
    {
        private Dictionary<char, char> _wiredPairLookup;


        public Plugboard(string wiredPairs = "")
        {
            Validate(wiredPairs);
            
            _wiredPairLookup = CreateWiresPairLookupDictionary(wiredPairs);
        }
        


        internal Dictionary<char, char> CreateWiresPairLookupDictionary(string wiredPairs)
        {
            Validate(wiredPairs);

            var cleandWiredPairs = CleanWiredPairs(wiredPairs);

            Dictionary<char, char> wiresLookupDictionary = new Dictionary<char, char>();

            for (int i = 0; i < cleandWiredPairs.Length; i += 2)
            {
                char firstChar = cleandWiredPairs[i];
                char secondChar = cleandWiredPairs[i + 1];

                wiresLookupDictionary.Add(firstChar, secondChar);
                wiresLookupDictionary.Add(secondChar, firstChar);
            }

            return wiresLookupDictionary;
        }

        private static string CleanWiredPairs(string wiredPairs)
        {
            return wiredPairs.Replace(" ", string.Empty);
        }

        private void Validate(string wiredPairs)
        {
            if (Validation.IsNull(wiredPairs))
                throw new ArgumentNullException(nameof(wiredPairs));

            var cleandWiredPairs = CleanWiredPairs(wiredPairs);
            
            if (Validation.IsToLong(cleandWiredPairs))
                throw new ArgumentException("A wired pair string must be less or equal 10.");

            if (Validation.IsPairPartMissing(cleandWiredPairs))
                throw new ArgumentException("Wired pairs must be pairs. Every letter must have another one.");

            if (Validation.ContainsNonLetter(cleandWiredPairs))
                throw new ArgumentException("Wired pairs must consist of letters only.");
        }
    }
}
