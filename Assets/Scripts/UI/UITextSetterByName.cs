using User;

namespace UI.Detail
{
    public class UITextSetterByName : UITextSetter, IUserInfoSetter
    {
        public void SetUserData(UserDataWrapper data)
        {
            UpdateText(data.Name);
        }
    }
}
