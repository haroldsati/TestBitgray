using UnityEngine;
using User;

namespace UI
{
    public interface IUserInfoSetter
    {
        void SetUserData(UserDataWrapper data);
    }

    public static class UserInfoSetterUtils
    {
        public static void SetUserData(GameObject go, UserDataWrapper data)
        {
            IUserInfoSetter[] setters = go.GetComponentsInChildren<IUserInfoSetter>(true);
            foreach (IUserInfoSetter setter in setters)
                setter.SetUserData(data);
        }
    }
}