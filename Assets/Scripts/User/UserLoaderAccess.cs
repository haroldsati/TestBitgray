using User.Detail;

namespace User
{
    public static class UserLoaderAccess
    {
        public static IUserDataLoader Access
        {
            get { return UserDataLoader.Instance; }
        }
    }
}