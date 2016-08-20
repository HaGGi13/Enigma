using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enigma.Plugboard.Tests
{
    [TestClass]
    public class PlugboardCreateWiresPairLookupDictionaryTests
    {
        private Plugboard _plugboard;



        #region set up

        [TestInitialize]
        public void Initialize()
        {
            _plugboard = new Plugboard();
        }

        #endregion

        

        #region unsuccessful

        [TestMethod]
        public void Argument_is_null()
        {
            Action action = () => _plugboard.CreateWiresPairLookupDictionary(null);

            action.ShouldThrowExactly<ArgumentNullException>();
        }

        [TestMethod]
        public void Argument_with_one_less_than_allowed_wired_pair_string()
        {
            string oneLetterWiredPairString = "A";

            oneLetterWiredPairString.Should().HaveLength(1);

            Action action = () => _plugboard.CreateWiresPairLookupDictionary(oneLetterWiredPairString);

            action.ShouldThrowExactly<ArgumentException>()
                .WithMessage(ExceptionMessage.WiredPairsMustBePairsExceptionMessage);
        }

        [TestMethod]
        public void Argument_with_three_letters_pair_string()
        {
            string wiredPairStringWithMissingPairPart = "ABC";

            wiredPairStringWithMissingPairPart.Should().HaveLength(3);

            Action action = () => _plugboard.CreateWiresPairLookupDictionary(wiredPairStringWithMissingPairPart);

            action.ShouldThrowExactly<ArgumentException>()
                .WithMessage(ExceptionMessage.WiredPairsMustBePairsExceptionMessage);
        }

        [TestMethod]
        public void Argument_with_one_over_max_allowed_wired_pairs_string_length()
        {
            string oneToLongWiredPairString = "ABCDEFGHIJKLMNOPQRSTU";

            oneToLongWiredPairString.Should().HaveLength(21);

            Action action = () => _plugboard.CreateWiresPairLookupDictionary(oneToLongWiredPairString);

            action.ShouldThrowExactly<ArgumentException>()
                .WithMessage(ExceptionMessage.WrongLengthExceptionMessage);
        }

        [TestMethod]
        public void Argument_with_to_long_wired_pair_string()
        {
            string onePairToMuchWiredPairString = "ABCDEFGHIJKLMNOPQRSTUV";

            onePairToMuchWiredPairString.Should().HaveLength(22);

            Action action = () => _plugboard.CreateWiresPairLookupDictionary(onePairToMuchWiredPairString);

            action.ShouldThrowExactly<ArgumentException>()
                .WithMessage(ExceptionMessage.WrongLengthExceptionMessage);
        }

        [TestMethod]
        public void Argument_contains_one_non_letter()
        {
            string wiredPairWithInvalidChar = "ABCDEF8G";

            wiredPairWithInvalidChar.Should().HaveLength(8);

            Action action = () => _plugboard.CreateWiresPairLookupDictionary(wiredPairWithInvalidChar);

            action.ShouldThrowExactly<ArgumentException>()
                .WithMessage(ExceptionMessage.ContainsNonLetterExceptionMessage);
        }

        [TestMethod]
        public void Argument_contains_two_non_letter()
        {
            string wiredPairWithInvalidChars = "AB.DEF8G";

            wiredPairWithInvalidChars.Should().HaveLength(8);

            Action action = () => _plugboard.CreateWiresPairLookupDictionary(wiredPairWithInvalidChars);

            action.ShouldThrowExactly<ArgumentException>()
                .WithMessage(ExceptionMessage.ContainsNonLetterExceptionMessage);
        }

        [TestMethod]
        public void Argument_contains_two_non_letter_behind_eachother()
        {
            string wiredPairWithInvalidCharsBehindEachother = "ABCD.8FG";

            wiredPairWithInvalidCharsBehindEachother.Should().HaveLength(8);

            Action action = () => _plugboard.CreateWiresPairLookupDictionary(wiredPairWithInvalidCharsBehindEachother);

            action.ShouldThrowExactly<ArgumentException>()
                .WithMessage(ExceptionMessage.ContainsNonLetterExceptionMessage);
        }

        #endregion

        #region successful

        [TestMethod]
        public void Create_min_possible_lookup()
        {
            string wiredPairs = "AB";

            wiredPairs.Should().HaveLength(2);

            var lookup = _plugboard.CreateWiresPairLookupDictionary(wiredPairs);

            lookup.Should().HaveCount(2);

            foreach (var key in wiredPairs.Select(c => c))
            {
                WiredPairCrossCheck(lookup, key);
            }
        }

        [TestMethod]
        public void Create_lookup_successfully()
        {
            string wiredPairs = "AZBYCXDWEV";

            wiredPairs.Should().HaveLength(10);

            var lookup = _plugboard.CreateWiresPairLookupDictionary(wiredPairs);

            lookup.Should().HaveCount(10);

            foreach (var key in wiredPairs.Select(c => c))
            {
                WiredPairCrossCheck(lookup, key);
            }
        }

        [TestMethod]
        public void Create_max_possible_lookup()
        {
            string wiredPairs = "ABCDEFGHIJKLMNOPQRST";

            wiredPairs.Should().HaveLength(20);

            var lookup = _plugboard.CreateWiresPairLookupDictionary(wiredPairs);

            lookup.Should().HaveCount(20);

            foreach (var key in wiredPairs.Select(c => c))
            {
                WiredPairCrossCheck(lookup, key);
            }
        }

        #endregion


        #region helper methods

        private static void WiredPairCrossCheck(IDictionary<char, char> lookup, char key)
        {
            lookup.ContainsKey(key).Should().BeTrue();

            var lookupValue = lookup[key];

            lookup[lookupValue].Should().Be(key);
        }

        #endregion
    }
}
