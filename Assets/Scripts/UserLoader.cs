using UnityEngine;
using System.Collections;
using LitJson;

namespace User.Detail
{
    public class UserLoader : MonoBehaviour, IUserLoader
    {
        public event System.Action UserLoaded;

        public static UserLoader Instance
        {
            get;
            private set;
        }

        public bool IsLoaded
        {
            get;
            private set;
        }

        public UserData Data
        {
            get;
            private set;
        }

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            IsLoaded = false;
            StartCoroutine(MakeRequest());
        }

        private IEnumerator MakeRequest()
        {
            WWW request;
            yield return request = new WWW("http://jsonplaceholder.typicode.com/users");

            if (request != null)
                LoadUser(request.text);
            else
                RaiseUserLoaded(null);
        }

        private void LoadUser(string json)
        {
            JsonData data = JsonMapper.ToObject(json);
            int index = Random.Range(0, data.Count);
            UserData user = JsonMapper.ToObject<UserData>(data[index].ToJson());
            RaiseUserLoaded(user);
        }

        private void RaiseUserLoaded(UserData data)
        {
            Data = data;

            if (UserLoaded != null)
                UserLoaded();

            IsLoaded = true;
            UserLoaded = null;
        }
    }
}