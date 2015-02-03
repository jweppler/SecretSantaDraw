using SecretSantaDraw.AcceptanceTests.Profiles;

namespace SecretSantaDraw.AcceptanceTests
{
    public static class Pages
    {
        private static ProfilePage profilePage;

        public static ProfilePage Profile
        {
            get { return profilePage ?? (profilePage = new ProfilePage(SetUpClass.BrowserSession)); }
        }
    }
}