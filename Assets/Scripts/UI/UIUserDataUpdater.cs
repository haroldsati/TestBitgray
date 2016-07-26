using Gameplay;
using UnityEngine;
using User;

namespace UI.Detail
{
    public class UIUserDataUpdater : MonoBehaviour
    {
        private void Start()
        {
            if (UserLoaderAccess.Access.IsLoaded)
                OnUserLoaded();
            else
                UserLoaderAccess.Access.UserLoaded += OnUserLoaded;
        }

        private void OnUserLoaded()
        {
            UserInfoSetterUtils.SetUserData(gameObject, UserLoaderAccess.Access.Data);
        }
    }
}