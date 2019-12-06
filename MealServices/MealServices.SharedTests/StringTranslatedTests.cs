using Microsoft.VisualStudio.TestTools.UnitTesting;
using MealServices.Shared;
using MealServices.Shared.Enumerations;
using System;
using OnlineServices.Shared;

namespace MealServices.SharedTests
{
    [TestClass]
    public class StringTranslatedTests
    {
        [TestMethod]
        public void CTOR_ShouldInitTranslatedFields_WhenValidTranslationIsProvided()
        {
            //Arrange & Act
            var sut = new MultiLanguageString("English", "French", "Dutch");

            //Assert
            Assert.AreEqual("English", sut.English);
            Assert.AreEqual("French", sut.French);
            Assert.AreEqual("Dutch", sut.Dutch);
        }

        [TestMethod]
        public void ToString_ShouldReturnTranslatedFields_WhenValidLanguageIsProvided()
        {
            //Arrange & Act
            var sut = new MultiLanguageString("English", "French", "Dutch");

            //Assert
            Assert.AreEqual("English", sut.ToString(Language.English));
            Assert.AreEqual("French", sut.ToString(Language.French));
            Assert.AreEqual("Dutch", sut.ToString(Language.Dutch));
        }

        [TestMethod]
        public void ToString_ShouldThrowException_WhenUnknownLanguageIsProvided()
        {
            //Arrange & Act
            var sut = new MultiLanguageString("English", "French", "Dutch");

            //Assert
            Assert.ThrowsException<Exception>(() => sut.ToString((Language)50));
        }
    }
}
