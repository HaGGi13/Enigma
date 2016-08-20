using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enigma.Plugboard.Tests
{
    [TestClass]
    [SuppressMessage("ReSharper", "ObjectCreationAsStatement")]
    public class PlugboardConstructorTests
    {
        private const string CannotBeNullEmpryOrWithespacesExceptionMessage = "Wired pairs string cannot be empty or white spaces.";
        private const string WiredPairsMustBePairsExceptionMessage = "Wired pairs must be pairs. Every letter must have another one.";
        private const string WrongLengthExceptionMessage = "A wired pair string must be greater or equal 2 and less or equal 10.";
        private const string ContainsNonLetterExceptionMessage = "Wired pairs must consist of letters only.";



        #region unsuccessful

        [TestMethod]
        public void Argument_is_null()
        {
            Action action = () => new Plugboard(null);

            ConstructorActionShouldThrowArgumentException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Argument_with_empty_string()
        {
            Action action = () => new Plugboard(string.Empty);

            ConstructorActionShouldThrowArgumentException<ArgumentException>(action, CannotBeNullEmpryOrWithespacesExceptionMessage);
        }

        [TestMethod]
        public void Argument_with_whitespace_string()
        {
            Action action = () => new Plugboard("   ");

            ConstructorActionShouldThrowArgumentException<ArgumentException>(action, CannotBeNullEmpryOrWithespacesExceptionMessage);
        }

        [TestMethod]
        public void Argument_with_one_less_than_allowed_wired_pair_string()
        {
            string oneLetterWiredPairString = "A";

            oneLetterWiredPairString.Should().HaveLength(1);

            Action action = () => new Plugboard(oneLetterWiredPairString);

            ConstructorActionShouldThrowArgumentException<ArgumentException>(action, WrongLengthExceptionMessage);
        }

        [TestMethod]
        public void Argument_with_three_letters_pair_string()
        {
            string wiredPairStringWithMissingPairPart = "ABC";

            wiredPairStringWithMissingPairPart.Should().HaveLength(3);

            Action action = () => new Plugboard(wiredPairStringWithMissingPairPart);

            ConstructorActionShouldThrowArgumentException<ArgumentException>(action, WiredPairsMustBePairsExceptionMessage);
        }

        [TestMethod]
        public void Argument_with_one_over_max_allowed_wired_pairs_string_length()
        {
            string oneToLongWiredPairString = "ABCDEFGHIJK";

            oneToLongWiredPairString.Should().HaveLength(11);

            Action action = () => new Plugboard(oneToLongWiredPairString);

            ConstructorActionShouldThrowArgumentException<ArgumentException>(action, WrongLengthExceptionMessage);
        }

        [TestMethod]
        public void Argument_with_to_long_wired_pair_string()
        {
            string onePairToMuchWiredPairString = "ABCDEFGHIJKL";

            onePairToMuchWiredPairString.Should().HaveLength(12);

            Action action = () => new Plugboard(onePairToMuchWiredPairString);

            ConstructorActionShouldThrowArgumentException<ArgumentException>(action, WrongLengthExceptionMessage);
        }

        [TestMethod]
        public void Argument_contains_one_non_letter()
        {
            string onePairToMuchWiredPairString = "ABCDEF8G";

            onePairToMuchWiredPairString.Should().HaveLength(8);

            Action action = () => new Plugboard(onePairToMuchWiredPairString);

            ConstructorActionShouldThrowArgumentException<ArgumentException>(action, ContainsNonLetterExceptionMessage);
        }

        [TestMethod]
        public void Argument_contains_two_non_letter()
        {
            string onePairToMuchWiredPairString = "AB.DEF8G";

            onePairToMuchWiredPairString.Should().HaveLength(8);

            Action action = () => new Plugboard(onePairToMuchWiredPairString);

            ConstructorActionShouldThrowArgumentException<ArgumentException>(action, ContainsNonLetterExceptionMessage);
        }

        [TestMethod]
        public void Argument_contains_two_non_letter_behind_eachother()
        {
            string onePairToMuchWiredPairString = "ABCD.8FG";

            onePairToMuchWiredPairString.Should().HaveLength(8);

            Action action = () => new Plugboard(onePairToMuchWiredPairString);

            ConstructorActionShouldThrowArgumentException<ArgumentException>(action, ContainsNonLetterExceptionMessage);
        }

        #endregion

        #region successful

        [TestMethod]
        public void Argument_with_min_allowed_wired_pairs_string_length()
        {
            string minWiredPairString = "AB";

            minWiredPairString.Should().HaveLength(2);

            Action action = () => new Plugboard(minWiredPairString);

            action.ShouldNotThrow<ArgumentException>();
        }

        [TestMethod]
        public void Argument_with_max_allowed_wired_pairs_string_length()
        {
            string maxWiredPairString = "ABCDEFGHIJ";

            maxWiredPairString.Should().HaveLength(10);

            Action action = () => new Plugboard(maxWiredPairString);

            action.ShouldNotThrow<ArgumentException>();
        }

        #endregion


        #region helper methods

        private static void ConstructorActionShouldThrowArgumentException<T>(Action action, string message = null) where T : Exception
        {
            var exceptionAssertions = action.ShouldThrow<T>();

            if (message != null)
                exceptionAssertions.WithMessage(message);
        }

        #endregion
    }
}
