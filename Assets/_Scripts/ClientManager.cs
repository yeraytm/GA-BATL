using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientManager : MonoBehaviour
{
    uint m_UserID;
    uint m_SessionID;

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

    private string dbInstalls = "https://citmalumnes.upc.es/~yeraytm/users_info.php";
    private string dbSessions = "https://citmalumnes.upc.es/~yeraytm/sessions.php";
    private string dbSessionsEnd = "https://citmalumnes.upc.es/~yeraytm/sessions_end.php";
    private string dbTransactions = "https://citmalumnes.upc.es/~yeraytm/transactions.php";

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
            Debug.Log("WWW SUCCESS | User ID: " + www.text);
            m_UserID = Convert.ToUInt32(www.text);
            CallbackEvents.OnAddPlayerCallback?.Invoke(m_UserID);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }

    IEnumerator SendSessionStart(DateTime obj)
    {
        WWWForm form = new WWWForm();
        form.AddField("userID", m_UserID.ToString());
        form.AddField("sessionStart", obj.ToString("yyyy-MM-dd HH:mm:ss"));

        WWW www = new WWW(dbSessions, form);

        yield return www;

        // Check for errors
        if (www.error == null)
        {
            Debug.Log("WWW SUCCESS | Session ID: " + www.text);
            m_SessionID = Convert.ToUInt32(www.text);
            CallbackEvents.OnNewSessionCallback?.Invoke(m_SessionID);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }

    IEnumerator SendSessionEnd(DateTime obj)
    {
        WWWForm form = new WWWForm();
        form.AddField("sessionID", m_SessionID.ToString());
        form.AddField("sessionEnd", obj.ToString("yyyy-MM-dd HH:mm:ss"));

        WWW www = new WWW(dbSessionsEnd, form);

        yield return www;

        // Check for errors
        if (www.error == null)
        {
            CallbackEvents.OnEndSessionCallback?.Invoke(m_SessionID);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }

    IEnumerator SendTransaction(int arg1, DateTime obj)
    {
        WWWForm form = new WWWForm();
        form.AddField("userID", m_UserID.ToString());
        form.AddField("itemID", arg1.ToString());
        form.AddField("transactionDate", obj.ToString("yyyy-MM-dd HH:mm:ss"));
        
        WWW www = new WWW(dbTransactions, form);

        yield return www;

        // Check for errors
        if (www.error == null)
        {
            CallbackEvents.OnItemBuyCallback?.Invoke();
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
}
