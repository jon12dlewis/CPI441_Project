using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using System;

public class DatabaseManager : MonoBehaviour
{
    private string userID;
    private DatabaseReference dbReference;

    public Transform Save;

    public Text SaveText;

    // Start is called before the first frame update
    void Start()
    {
        userID = SystemInfo.deviceUniqueIdentifier;
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    private void CreateUser()
    {
        User newUser = new User(Save);
        string json = JsonUtility.ToJson(newUser);

        dbReference.Child("users").Child(userID).SetRawJsonValueAsync(json);
    }

    // Load Save Data
    public IEnumerator GetSave(Action<Transform> onCallback)
    {
        var userSaveData = dbReference.Child("users").Child("save").GetValueAsync();

        yield return new WaitUntil(predicate: () => userSaveData.IsCompleted);

        if(userSaveData != null)
        {
            DataSnapshot snapshot = userSaveData.Result;

            onCallback.Invoke((Transform)snapshot.Value);

        }
    }

    public void UpdateSave()
    {
        dbReference.Child("users").Child(userID).Child("save").SetValueAsync(Save);

    }


    /*public void GetUserInfo()
    {
        StartCoroutine(GetSave((Transform save) =>
        {
            SaveText.text = save;
        }))
    }*/
}
