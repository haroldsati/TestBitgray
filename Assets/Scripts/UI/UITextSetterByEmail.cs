using User;

namespace UI.Detail
{
    public class UITextSetterByEmail : UITextSetter, IUserInfoSetter
    {
        public void SetUserData(UserDataWrapper data)
        {
            UpdateText(data.Email);
        }
    }
}