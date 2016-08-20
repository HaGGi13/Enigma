using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enigma.Plugboard.Tests
{
    [TestClass]
    public class ValidationTests
    {
        #region IsNull

        [TestMethod]
        public void Check_IsNull_true()
        {
            Validation.IsNull(null).Should().BeTrue();
        }

        [TestMethod]
        public void Check_IsNull_false()
        {
            Validation.IsNull(string.Empty).Should().BeFalse();

            Validation.IsNull("Hello World.").Should().BeFalse();
        }

        #endregion

        #region IsToLong

        [TestMethod]
        public void Check_IsToLong_with_null_argument()
        {
            Action action = () => Validation.IsToLong(null);

            action.ShouldThrowExactly<ArgumentNullException>();
        }

        [TestMethod]
        public void Check_IsToLong_true()
        {
            Validation.IsToLong("ABCDEFGHIJKLMNOPQRSTUVWXYZ").Should().BeTrue();
        }

        [TestMethod]
        public void Check_IsToLong_false()
        {
            Validation.IsToLong(string.Empty).Should().BeFalse();

            Validation.IsToLong("ABCDEFGHIJ").Should().BeFalse();

            Validation.IsToLong("ABCDEFGHIJKLMNOPQRST").Should().BeFalse();
        }

        #endregion

        #region IsPairPartMissing

        [TestMethod]
        public void Check_IsPairPartMissing_with_null_argument()
        {
            Action action = () => Validation.IsPairPartMissing(null);

            action.ShouldThrowExactly<ArgumentNullException>();
        }

        [TestMethod]
        public void Check_IsPairPartMissing_true()
        {
            Validation.IsPairPartMissing("A").Should().BeTrue();

            Validation.IsPairPartMissing("ABC").Should().BeTrue();

            Validation.IsPairPartMissing("ABCDEFGHIJKLMNOPQRS").Should().BeTrue();
            
            Validation.IsPairPartMissing("ABCDEFGHIJKLMNOPQRSTU").Should().BeTrue();
        }

        [TestMethod]
        public void Check_IsPairPartMissing_false()
        {
            Validation.IsPairPartMissing(string.Empty).Should().BeFalse();

            Validation.IsPairPartMissing("AB").Should().BeFalse();

            Validation.IsPairPartMissing("ABCD").Should().BeFalse();

            Validation.IsPairPartMissing("ABCDEFGHIJ").Should().BeFalse();

            Validation.IsPairPartMissing("ABCDEFGHIJKLMNOPQRST").Should().BeFalse();

            Validation.IsPairPartMissing("ABCDEFGHIJKLMNOPQRSTUV").Should().BeFalse();
        }

        #endregion

        #region ContainsNonLetter

        [TestMethod]
        public void Check_ContainsNonLetter_with_null_argument()
        {
            Action action = () => Validation.ContainsNonLetter(null);

            action.ShouldThrowExactly<ArgumentNullException>();
        }

        [TestMethod]
        public void Check_ContainsNonLetter_true()
        {
            Validation.ContainsNonLetter("1").Should().BeTrue();

            Validation.ContainsNonLetter("A1").Should().BeTrue();

            Validation.ContainsNonLetter("1A").Should().BeTrue();

            Validation.ContainsNonLetter("AB1").Should().BeTrue();
        }

        [TestMethod]
        public void Check_ContainsNonLetter_false()
        {
            Validation.ContainsNonLetter(string.Empty).Should().BeFalse();

            Validation.ContainsNonLetter("AB").Should().BeFalse();

            Validation.ContainsNonLetter("ABCD").Should().BeFalse();

            Validation.ContainsNonLetter("ABCDEFGHIJ").Should().BeFalse();

            Validation.ContainsNonLetter("ABCDEFGHIJKLMNOPQRST").Should().BeFalse();

            Validation.ContainsNonLetter("ABCDEFGHIJKLMNOPQRSTUV").Should().BeFalse();
        }

        #endregion
    }
}
