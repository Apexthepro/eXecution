using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginScript : MonoBehaviour {
    public Firebase.Auth.FirebaseAuth auth;
    Firebase.Auth.FirebaseUser user;
    // Use this for initialization
    public InputField id, pwd;
    public Text console;
    public GameObject consolePanel;
    string sid = "", spwd = "";
    
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
                //Debug.Log("Setting up Firebase Auth");
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
        //print("Username is : " + sid + " Password is : " + spwd);
        auth.SignInWithEmailAndPasswordAsync("furqan@gmail.com", "furqan").ContinueWith(task => {
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
            user = auth.CurrentUser;
            if (user != null)
            {
                string name = user.DisplayName;
                string email = user.Email;
                System.Uri photo_url = user.PhotoUrl;
                // The user's Id, unique to the Firebase project.
                // Do NOT use this value to authenticate with your backend server, if you
                // have one; use User.TokenAsync() instead.
                string uid = user.UserId;
                print("email->" + email + "uid-->" + uid);
            }
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
            //SceneManager.LoadScene("CastleScene");
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
