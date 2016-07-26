namespace User
{
    public interface IUserLoader
    {
        event System.Action UserLoaded;
        bool IsLoaded { get; }
        UserData Data { get; }
    }
}