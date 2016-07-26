namespace UI.Detail
{

    public class UITextSetterByUserName : UITextSetter, IUserInfoSetter
    {
        public void SetUserData(UserData data)
        {
            UpdateText(data.username);
        }
    }
}