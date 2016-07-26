using UnityEngine;

namespace UI
{
    public interface IUserInfoSetter
    {
        void SetUserData(UserData data);
    }

    public static class UserInfoSetterUtils
    {
        public static void SetUserData(GameObject go, UserData data)
        {
            IUserInfoSetter[] setters = go.GetComponentsInChildren<IUserInfoSetter>(true);
            foreach (IUserInfoSetter setter in setters)
                setter.SetUserData(data);
        }
    }
}