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
        #region unsuccessful

        [TestMethod]
        public void Argument_is_null()
        {
            Action action = () => new Plugboard(null);

            action.ShouldThrowExactly<ArgumentNullException>();
        }

        [TestMethod]
        public void Argument_with_one_less_than_allowed_wired_pair_string()
        {
            string oneLetterWiredPairString = "A";

            oneLetterWiredPairString.Should().HaveLength(1);

            Action action = () => new Plugboard(oneLetterWiredPairString);

            action.ShouldThrowExactly<ArgumentException>()
                .WithMessage(ExceptionMessage.WiredPairsMustBePairsExceptionMessage);
        }

        [TestMethod]
        public void Argument_with_three_letters_pair_string()
        {
            string wiredPairStringWithMissingPairPart = "ABC";

            wiredPairStringWithMissingPairPart.Should().HaveLength(3);

            Action action = () => new Plugboard(wiredPairStringWithMissingPairPart);

            action.ShouldThrowExactly<ArgumentException>()
                .WithMessage(ExceptionMessage.WiredPairsMustBePairsExceptionMessage);
        }

        [TestMethod]
        public void Argument_with_one_over_max_allowed_wired_pairs_string_length()
        {
            string oneToLongWiredPairString = "ABCDEFGHIJKLMNOPQRSTU";

            oneToLongWiredPairString.Should().HaveLength(21);

            Action action = () => new Plugboard(oneToLongWiredPairString);

            action.ShouldThrowExactly<ArgumentException>()
                .WithMessage(ExceptionMessage.WrongLengthExceptionMessage);
        }

        [TestMethod]
        public void Argument_with_to_long_wired_pair_string()
        {
            string onePairToMuchWiredPairString = "ABCDEFGHIJKLMNOPQRSTUV";

            onePairToMuchWiredPairString.Should().HaveLength(22);

            Action action = () => new Plugboard(onePairToMuchWiredPairString);

            action.ShouldThrowExactly<ArgumentException>()
                .WithMessage(ExceptionMessage.WrongLengthExceptionMessage);
        }

        [TestMethod]
        public void Argument_contains_one_non_letter()
        {
            string onePairToMuchWiredPairString = "ABCDEF8G";

            onePairToMuchWiredPairString.Should().HaveLength(8);

            Action action = () => new Plugboard(onePairToMuchWiredPairString);

            action.ShouldThrowExactly<ArgumentException>()
                .WithMessage(ExceptionMessage.ContainsNonLetterExceptionMessage);
        }

        [TestMethod]
        public void Argument_contains_two_non_letter()
        {
            string onePairToMuchWiredPairString = "AB.DEF8G";

            onePairToMuchWiredPairString.Should().HaveLength(8);

            Action action = () => new Plugboard(onePairToMuchWiredPairString);

            action.ShouldThrowExactly<ArgumentException>()
                .WithMessage(ExceptionMessage.ContainsNonLetterExceptionMessage);
        }

        [TestMethod]
        public void Argument_contains_two_non_letter_behind_eachother()
        {
            string onePairToMuchWiredPairString = "ABCD.8FG";

            onePairToMuchWiredPairString.Should().HaveLength(8);

            Action action = () => new Plugboard(onePairToMuchWiredPairString);

            action.ShouldThrowExactly<ArgumentException>()
                .WithMessage(ExceptionMessage.ContainsNonLetterExceptionMessage);
        }

        #endregion

        #region successful

        [TestMethod]
        public void Test_default_constructor()
        {
            Action action = () => new Plugboard();

            action.ShouldNotThrow();
        }

        [TestMethod]
        public void Argument_with_empty_string()
        {
            Action action = () => new Plugboard(string.Empty);

            action.ShouldNotThrow();
        }

        [TestMethod]
        public void Argument_with_whitespace_string()
        {
            Action action = () => new Plugboard("   ");
            
            action.ShouldNotThrow();
        }

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
            string maxWiredPairString = "ABCDEFGHIJKLMNOPQRST";

            maxWiredPairString.Should().HaveLength(20);

            Action action = () => new Plugboard(maxWiredPairString);

            action.ShouldNotThrow();
        }

        #endregion
    }
}
