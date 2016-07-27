using User;

namespace UI.Detail
{
    public class UITextSetterByUserName : UITextSetter, IUserInfoSetter
    {
        public void SetUserData(UserDataWrapper data)
        {
            UpdateText(data.Username);
        }
    }
}