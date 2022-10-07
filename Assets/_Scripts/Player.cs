using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnEnable()
    {
        Simulator.OnNewPlayer += PlayerInstall;
        Simulator.OnNewSession += PlayerStartSession;
        Simulator.OnEndSession += PlayerEndSession;
        Simulator.OnBuyItem += PlayerTransaction;
    }

    private void PlayerInstall(string arg1, string arg2, DateTime arg3)
    {
        StartCoroutine(SendUserInstall(arg1, arg2, arg3));
    }

    private void PlayerStartSession(DateTime obj)
    {
        StartCoroutine(SendSessionStart(obj));
    }

    private void PlayerEndSession(DateTime obj)
    {
        StartCoroutine(SendSessionEnd(obj));
    }
    
    private void PlayerTransaction(int arg1, DateTime arg2)
    {
        StartCoroutine(SendTransaction(arg1, arg2));
    }


    public string dbInstalls = "https://citmalumnes.upc.es/~yeraytm/hello.php";
    IEnumerator SendUserInstall(string arg1, string arg2, DateTime arg3)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", arg1);
        form.AddField("country", arg2);
        form.AddField("installDate", arg3.ToString("yyyy-MM-dd HH:mm:ss"));

        WWW www = new WWW(dbInstalls, form);
        
        yield return www;

        // Check for errors
        if (www.error == null)
        {
            Debug.Log("WWW SUCCESS: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }

    IEnumerator SendSessionStart(DateTime obj)
    {
        WWWForm form = new WWWForm();
        form.AddField("sessionStart", obj.ToString());

        WWW www = new WWW(dbInstalls, form);

        yield return www;

        // Check for errors
        if (www.error == null)
        {
            Debug.Log("WWW SUCCESS: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }

    IEnumerator SendSessionEnd(DateTime obj)
    {
        WWWForm form = new WWWForm();
        form.AddField("sessionEnd", obj.ToString());

        WWW www = new WWW(dbInstalls, form);

        yield return www;

        // Check for errors
        if (www.error == null)
        {
            Debug.Log("WWW SUCCESS: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }

    IEnumerator SendTransaction(int arg1, DateTime obj)
    {
        WWWForm form = new WWWForm();
        form.AddField("itemID", arg1);
        form.AddField("transactionDate", obj.ToString());
        
        WWW www = new WWW(dbInstalls, form);

        yield return www;

        // Check for errors
        if (www.error == null)
        {
            Debug.Log("WWW SUCCESS: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
}
