namespace UI.Detail
{
    public class UITextSetterByName : UITextSetter, IUserInfoSetter
    {
        public void SetUserData(UserData data)
        {
            UpdateText(data.name);
        }
    }
}
