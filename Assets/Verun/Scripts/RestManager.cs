using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class RestManager : MonoBehaviour
{
    public WWW Results { get; private set; }

    public WWW Get(string url, System.Action onComplete)
    {
        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www, onComplete));
        return www;
    }

    public WWW Post(string url, Dictionary<string, string> post, System.Action onComplete)
    {
        WWWForm form = new WWWForm();

        foreach (KeyValuePair<string, string> postArg in post)
        {
            form.AddField(postArg.Key, postArg.Value);
        }

        WWW www = new WWW(url, form);

        StartCoroutine(WaitForRequest(www, onComplete));
        return www;
    }

    private IEnumerator WaitForRequest(WWW www, System.Action onComplete)
    {
        yield return www;
        // check for errors
        if (www.error == null)
        {
            Results = www;
            onComplete();
        }
        else
        {
            Debug.Log(www.error);
        }
    }
}
