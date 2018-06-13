using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using MySql.Data.MySqlClient;
public class LoginScript : MonoBehaviour {

    // Use this for initialization
    public InputField id, pwd;
    public Text console;
    public GameObject consolePanel;
    string sid = "", spwd = "";
    public Firebase.Auth.FirebaseAuth auth;
    Firebase.DependencyStatus dependencyStatus = Firebase.DependencyStatus.UnavailableOther;
    public void Start()
    {
        consolePanel.SetActive(false);
        console.text = "";
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
                error("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                
                error("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            SceneManager.LoadScene("CastleScene");
        });
    }

    public void onRegister()
    {

        sid = id.text;
        spwd = pwd.text;
        auth.CreateUserWithEmailAndPasswordAsync(sid, spwd).ContinueWith(task => {
            if (task.IsCanceled)
            {
                error(" CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.Log(task.Exception);
                error("CreateUserWithEmailAndPasswordAsync encountered an error: ");
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User Registered successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            SceneManager.LoadScene("CastleScene");
        });
    }

    public void switchAccount() {
        SceneManager.LoadScene("LoginScene");
    }

    // Update is called once per frame
    private void error(string msg)
    {
        consolePanel.SetActive(true);
        console.text = msg;
    }
}
