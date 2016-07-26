using User.Detail;

namespace User
{
    public static class UserLoaderAccess
    {
        public static IUserLoader Access
        {
            get { return UserLoader.Instance; }
        }
    }
}