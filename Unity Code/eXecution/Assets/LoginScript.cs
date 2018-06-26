using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using Newtonsoft.Json;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
namespace loginscript
{
    public class LoginScript : MonoBehaviour
    {

        public Firebase.Auth.FirebaseAuth auth;
        Firebase.Auth.FirebaseUser user;
        // Use this for initialization
        public InputField id, pwd;
        public Text console;
        public GameObject consolePanel;
        string sid = "", spwd = "";
        string path = "Assets/sam.txt";
        public Text DisplayEmail;
        Firebase.DependencyStatus dependencyStatus = Firebase.DependencyStatus.UnavailableOther;
        public void Start()
        {
            FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://game-205318.firebaseio.com/");
            DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
            data read = new data();
            using (StreamReader file = new StreamReader(path))
            {
                read = JsonConvert.DeserializeObject<data>(file.ReadLine());
                if (read.email != null)
                    //DisplayEmail.text = read.email;
                    file.Close();

            }
            consolePanel.SetActive(false);
            console.text = "";
            Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
            {
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


        public void loginClick()
        {
            if (id.text == null && pwd.text == null)
                error("please enter credentials");
            else {
                sid = "fluxi@gmail.com";//id.text;
                spwd = "fluxii";// pwd.text;

                //print("Username is : " + sid + " Password is : " + spwd);

                auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
                auth.SignInWithEmailAndPasswordAsync(sid, spwd).ContinueWith(task =>
                {
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
                    Debug.LogFormat("User signed in successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);
                    user = auth.CurrentUser;
                    if (user != null)
                    {
                        string name = user.DisplayName;
                        string email = user.Email;
                        System.Uri photo_url = user.PhotoUrl;
                    // The user's Id, unique to the Firebase project.
                    // Do NOT use this value to authenticate with your backend server, if you
                    // have one; use User.TokenAsync() instead.
                  
                        print("email->" + email + "uid-->" + user.UserId);
                    }
                    data info = new data()
                    {
                        email = sid,//sid
                        pass = spwd,//spwd
                        uid = user.UserId,
                        set = true
                    };
                    using (StreamWriter myFile = new StreamWriter(path))
                    {
                        myFile.Write(JsonConvert.SerializeObject(info));
                    }
                SceneManager.LoadScene("CastleScene");

            });
            }
        }

        public void onRegister()
        {
            // Get the root reference location of the database.

            string userid="";
            sid = "avish@gmail.com";//id.text;
            spwd = "avish123";//pwd.text;
            auth.CreateUserWithEmailAndPasswordAsync(sid, spwd).ContinueWith(task1 =>
            {
                if (task1.IsCanceled)
                {
                    error(" CreateUserWithEmailAndPasswordAsync was canceled.");
                    return;
                }
                if (task1.IsFaulted)
                {
                    Debug.Log(task1.Exception);
                    error("CreateUserWithEmailAndPasswordAsync encountered an error: ");
                    return;
                }
                else
                {
                    Firebase.Auth.FirebaseUser newUser = task1.Result;
                    Debug.LogFormat("User Registered successfully: {0} ({1})",
                        newUser.DisplayName, newUser.UserId);
                    userid = newUser.UserId;
                    data info = new data()
                    {
                        email = sid,//sid
                        pass = spwd,//spwd
                        uid = newUser.UserId,
                        set = true
                    };
                    using (StreamWriter myFile = new StreamWriter(path))
                    {
                        myFile.Write(JsonConvert.SerializeObject(info));
                        myFile.Close();
                    }


                    //SceneManager.LoadScene("CastleScene");
                }
                if (task1.IsCompleted) { CreateUserData(userid); }
            });
            
            
            
        }
        public void CreateUserData(string userid)
        {
            DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
            string[] bname = new string[8] { "Castle", "Wall", "Forge", "Laboratory", "Hero Ground", "Storage", "Trade Hall", "Dragon Tomb" };
            print(sid + "---------------" + spwd);
            auth.SignInWithEmailAndPasswordAsync(sid, spwd).ContinueWith(task =>
                {
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
                    print("user id------------>" + newUser.UserId);


                    for (int i = 0; i < 8; i++)
                    {
                        reference.Child((newUser.UserId).ToString()).Child("Buildings").Child(bname[i]).Child("lev").SetValueAsync(1);
                    }
                    //Resources
                    reference.Child((newUser.UserId).ToString()).Child("Resources").Child("ResourceA").SetValueAsync(10000);
                    reference.Child((newUser.UserId).ToString()).Child("Resources").Child("ResourceB").SetValueAsync(10000);
                    //Reference
                    reference.Child((newUser.UserId).ToString()).Child("ReferenceCode").Child("PlayerCode").Child("code_of_the_Player").SetValueAsync(29930);
                    reference.Child((newUser.UserId).ToString()).Child("ReferenceCode").Child("PlayerCode").Child("Players_who_use_the_code").Child("users").SetValueAsync("avish@gmail.com");
                    //Social
                    reference.Child((newUser.UserId).ToString()).Child("Social").Child("Friends").SetValueAsync("fluxi@gmail.com");
                    reference.Child((newUser.UserId).ToString()).Child("Buffs").Child("UpgradeSpeed").SetValueAsync("0");
                    reference.Child((newUser.UserId).ToString()).Child("Buffs").Child("UpgradeResources").SetValueAsync("0.1");
                    reference.Child((newUser.UserId).ToString()).Child("Buffs").Child("ResearchSpeed").SetValueAsync("0.1");
                    reference.Child((newUser.UserId).ToString()).Child("Buffs").Child("ResearchResources").SetValueAsync("0.1");
                    //reference.Child((sid).ToString()).Child("Social").Child("mail").Child("avish@gmail.com").SetValueAsync(true);
                });
            
        }

        public void switchAccount()
        {
            SceneManager.LoadScene("LoginScene");
        }

        // Update is called once per frame
        private void error(string msg)
        {
            consolePanel.SetActive(true);
            console.text = msg;
        }
        public class data
        {
            public string email { get; set; }
            public string pass { get; set; }
            public string uid { get; set; }
            public bool set { get; set; }

        }
    }
}
