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

        throw new NotImplementedException();
    }

    private void PlayerStartSession(DateTime obj)
    {
        throw new NotImplementedException();
    }

    private void PlayerEndSession(DateTime obj)
    {
        throw new NotImplementedException();
    }
    
    private void PlayerTransaction(int arg1, DateTime arg2)
    {
        throw new NotImplementedException();
    }


    public string url = "https://citmalumnes.upc.es/~yeraytm/hello.php";
    IEnumerator SendUserInstall(string arg1, string arg2, DateTime arg3)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", arg1);
        form.AddField("country", arg2);
        form.AddField("dateInstall", arg3.ToString());

        using (WWW www = new WWW(url))
        {
            yield return www;
        }
    }

    // Update is called once per frame
    //void Update()
    //{
    //}
}
