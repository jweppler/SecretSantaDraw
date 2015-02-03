
using Coypu;

namespace SecretSantaDraw.AcceptanceTests.Profiles
{
    public class ProfilePage
    {
        private readonly BrowserSession browserSession;

        public ProfilePage(BrowserSession browserSession)
        {
            this.browserSession = browserSession;
        }

        public void GoTo()
        {
            browserSession.Visit("/");
            browserSession.ClickLink("Profiles");
        }
         
    }
}