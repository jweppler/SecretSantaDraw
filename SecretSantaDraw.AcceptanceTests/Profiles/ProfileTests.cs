using System;
using System.ComponentModel;
using System.Linq;
using Coypu;
using Coypu.Drivers;
using Coypu.Drivers.Selenium;
using Coypu.NUnit.Matchers;
using NUnit.Framework;
using SecretSantaDraw.DAL;
using SecretSantaDraw.Models;

namespace SecretSantaDraw.AcceptanceTests.Profiles
{

    [TestFixture]
    public class ProfileTests
    {
        private readonly SecretSantaDrawContext db = new SecretSantaDrawContext();
        private static readonly BrowserSession BrowserSession = SetUpClass.BrowserSession;

        [Test]
        public void CreateProfile()
        {
            BrowserSession.Visit("/");
            BrowserSession.ClickLink("Profiles");
            BrowserSession.ClickLink("Create New");
            BrowserSession.FillIn("DisplayName").With("Wustin Jeppler");
            BrowserSession.FillIn("EmailAddress").With("WustinJeppler@gmail.com");
            BrowserSession.FillIn("DOB").With("001980-01-01");
            BrowserSession.Select("Male").From("GenderType");
            BrowserSession.Select("M").From("ShirtSize");
            BrowserSession.Select("7 1/4").From("HatSize");
            BrowserSession.Select("10").From("ShoeSize");
            BrowserSession.ClickButton("Create");
            Assert.AreEqual("Profiles - Secret Santa Draw", BrowserSession.Title);
            Assert.That(BrowserSession, Shows.Content("Wustin Jeppler"));
            Assert.That(BrowserSession, Shows.Content("WustinJeppler@gmail.com"));
            Profile profile = db.Profile.FirstOrDefault(p => p.DisplayName == "Wustin Jeppler");
            db.Profile.Remove(profile);
            db.SaveChanges();
        }

        [Test]
        public void CheckDetailValues()
        {
            Profile profile = new Profile
            {
                DisplayName = "JDubs",
                DOB = new DateTime(1982,02,27),
                EmailAddress = "JDubs@gmail.com",
                Gender = GenderType.Male,
                HatSize = HatSize.SevenAndOneEighth,
                ShirtSize = ShirtSize.L,
                ShoeSize = ShoeSize.NineAndAHalf
            };
            db.Profile.Add(profile);
            db.SaveChanges();
            BrowserSession.Visit("/");
            BrowserSession.ClickLink("Profiles");
            Assert.That(BrowserSession, Shows.Content("JDubs@gmail.com"));
            BrowserSession.ClickLink("JDubs");
            Assert.That(BrowserSession, Shows.Content("JDubs"));
            Assert.That(BrowserSession, Shows.Content("1982-02-27"));
            Assert.That(BrowserSession, Shows.Content("Male"));
            Assert.That(BrowserSession, Shows.Content("L"));
            Assert.That(BrowserSession, Shows.Content("7 1/8"));
            Assert.That(BrowserSession, Shows.Content("9.5"));
            db.Profile.Remove(profile);
            db.SaveChanges();
        }

        [Test]
        public void CheckEditProfileValues()
        {
            Profile profile = new Profile
            {
                DisplayName = "JW",
                DOB = new DateTime(1980, 03, 28),
                EmailAddress = "JW@gmail.com",
                Gender = GenderType.Male,
                HatSize = HatSize.Seven,
                ShirtSize = ShirtSize.XL,
                ShoeSize = ShoeSize.TenAndAHalf
            };
            db.Profile.Add(profile);
            db.SaveChanges();

            BrowserSession.Visit("/Profile/Edit/"+profile.ProfileId);

//            BrowserSession.Visit("/");
//            BrowserSession.ClickLink("Profiles");
//            BrowserSession.FindXPath("//tr/td[a=\"JW\"]/..", Options.First).ClickLink("Edit");

            Assert.IsTrue(BrowserSession.FindField("DisplayName").HasValue("JW"));
            Assert.IsTrue(BrowserSession.FindField("EmailAddress").HasValue("JW@gmail.com"));
            Assert.IsTrue(BrowserSession.FindField("DOB").HasValue("1980-03-28"));
            Assert.IsTrue(BrowserSession.FindField("Gender").HasValue("Male"));
            Assert.IsTrue(BrowserSession.FindField("ShirtSize").HasValue("XL"));
            Assert.IsTrue(BrowserSession.FindField("HatSize").HasValue("Seven"));
            Assert.IsTrue(BrowserSession.FindField("ShoeSize").HasValue("TenAndAHalf"));

            db.Profile.Remove(profile);
            db.SaveChanges();
        }

        [Test]
        public void EditProfile()
        {
        //Just checking for editting of email for now because it's easy
            Profile profile = new Profile
            {
                DisplayName = "JW",
                DOB = new DateTime(1980, 03, 28),
                EmailAddress = "JW@gmail.com",
                Gender = GenderType.Male,
                HatSize = HatSize.Seven,
                ShirtSize = ShirtSize.XL,
                ShoeSize = ShoeSize.TenAndAHalf
            };
            db.Profile.Add(profile);
            db.SaveChanges();

            BrowserSession.Visit("/");
            BrowserSession.ClickLink("Profiles");
            BrowserSession.FindXPath("//tr/td[a=\"JW\"]/..", Options.First).ClickLink("Edit");

            BrowserSession.FillIn("EmailAddress").With("JW2@hotmail.com");
            BrowserSession.ClickButton("Save");

            Assert.That(BrowserSession, Shows.Content("JW2@hotmail.com"));

            db.Profile.Remove(profile);
            db.SaveChanges();
        }

        [Test]
        public void DeleteProfile()
        {
            Profile profile = new Profile
            {
                DisplayName = "Jastin Wappler",
                DOB = new DateTime(1979, 01, 02),
                EmailAddress = "JastWapp@gmail.com",
                Gender = GenderType.Female,
                HatSize = HatSize.SevenAndAHalf,
                ShirtSize = ShirtSize.NotSpecified,
                ShoeSize = ShoeSize.NotSpecified
            };
            db.Profile.Add(profile);
            db.SaveChanges();

            BrowserSession.Visit("/");
            BrowserSession.ClickLink("Profiles");

            Assert.That(BrowserSession, Shows.Content("Jastin Wappler"));

            BrowserSession.FindXPath("//tr/td[a=\"Jastin Wappler\"]/..", Options.First).ClickLink("Delete");
            BrowserSession.ClickButton("Delete");
            
            Assert.That(BrowserSession, Shows.No.Content("Jastin Wappler"));

        }

    }
}