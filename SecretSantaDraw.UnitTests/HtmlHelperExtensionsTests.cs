using SecretSantaDraw.HtmlHelperExtensions;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;

namespace SecretSantaDraw.UnitTests
{
    [TestFixture]
    class HtmlHelperExtensionsTests
    {
        [Test]
        public void GetEnumDisplayNamesAllWithDisplayNames()
        {
            Assert.AreEqual("1", AllDisplayNames.One.GetDisplayAttributeFrom());
            Assert.AreEqual("2", AllDisplayNames.Two.GetDisplayAttributeFrom());
            Assert.AreEqual("3", AllDisplayNames.Three.GetDisplayAttributeFrom());
        }

        [Test]
        public void GetEnumDisplayNamesNoneWithDisplayNames()
        {
            Assert.AreEqual("A", NoDisplayNames.A.GetDisplayAttributeFrom());
            Assert.AreEqual("B", NoDisplayNames.B.GetDisplayAttributeFrom());
            Assert.AreEqual("C", NoDisplayNames.C.GetDisplayAttributeFrom());
        }

        [Test]
        public void GetEnumDisplayNamesSomeWithDisplayNames()
        {
            Assert.AreEqual("Roman Numeral One", SomeDisplayNames.I.GetDisplayAttributeFrom());
            Assert.AreEqual("Roman Numeral Two", SomeDisplayNames.II.GetDisplayAttributeFrom());
            Assert.AreEqual("III", SomeDisplayNames.III.GetDisplayAttributeFrom());
            Assert.AreEqual("IV", SomeDisplayNames.IV.GetDisplayAttributeFrom());
        }


        private enum AllDisplayNames
        {
            [Display(Name = "1")]
            One,
            [Display(Name = "2")]
            Two,
            [Display(Name = "3")]
            Three
        }

        private enum NoDisplayNames
        {
            A, B, C
        }

        private enum SomeDisplayNames
        {
            [Display(Name = "Roman Numeral One")]
            I,
            [Display(Name = "Roman Numeral Two")]
            II,
            III,
            IV
        }
    }
}
