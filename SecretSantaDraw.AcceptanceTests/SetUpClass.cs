using Coypu;
using NUnit.Framework;
using Coypu.Drivers.Selenium;
using Coypu.Drivers;

namespace SecretSantaDraw.AcceptanceTests
{
    [SetUpFixture]
    public class SetUpClass
    {
        public static BrowserSession BrowserSession;

        [SetUp]
        public void RunBeforeAnyTests()
        {
            BrowserSession = new BrowserSession(new SessionConfiguration
            {
                AppHost = "localhost",
                Port = 1032,
                SSL = false,
                Driver = typeof(SeleniumWebDriver),
                Browser = Browser.Chrome
            });
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            BrowserSession.Dispose();
        }
    }
}
