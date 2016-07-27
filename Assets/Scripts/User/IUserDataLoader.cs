namespace User
{
    public interface IUserDataLoader
    {
        event System.Action UserLoaded;
        bool IsLoaded { get; }
        UserDataWrapper Data { get; }
    }
}