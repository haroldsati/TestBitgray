using UnityEngine;
using System.Collections;
using LitJson;

public class UserLoader : MonoBehaviour
{
    public event System.Action<UserData> UserLoaded;

    public void LoadUser(System.Action<UserData> userLoaded)
    {
        Debug.Log("LoadUser");
        UserLoaded = userLoaded;
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
        if (UserLoaded != null)
            UserLoaded(data);

        UserLoaded = null;
    }
}