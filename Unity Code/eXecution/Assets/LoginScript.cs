using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using MySql.Data.MySqlClient;
public class LoginScript : MonoBehaviour {

    // Use this for initialization
    public Text id,pwd,error;
    string sid = "", spwd = "";
    public Firebase.Auth.FirebaseAuth auth;
    Firebase.DependencyStatus dependencyStatus = Firebase.DependencyStatus.UnavailableOther;
    public void Start()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Handle initialization of the necessary firebase modules:
                Debug.Log("Setting up Firebase Auth");
                auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
            }
            else {
                Debug.LogError(
                  "Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }


	    public void loginClick(){
        sid = id.text;
        spwd = pwd.text;
        print("Username is : " + sid + " Password is : " + spwd);
        auth.SignInWithEmailAndPasswordAsync(sid, spwd).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            SceneManager.LoadSceneAsync("CastleScene");
        });
    }
	// Update is called once per frame
	void Update () {
		
	}
}
