namespace UI.Detail
{

    public class UITextSetterByEmail : UITextSetter, IUserInfoSetter
    {
        public void SetUserData(UserData data)
        {
            UpdateText(data.email);
        }
    }
}