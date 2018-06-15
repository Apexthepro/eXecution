using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System.IO;
using UnityEditor;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

    public class dbinitscript : MonoBehaviour {
        public Text resource1;
        data read = new data();
        string path = "Assets/sam.txt";
        public Firebase.Auth.FirebaseAuth auth;
        // Use this for initialization
        void Start() {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        using (StreamReader file = new StreamReader(path))
            {
                read = JsonConvert.DeserializeObject<data>(file.ReadLine());
            if (read.email == null)
                SceneManager.LoadScene("LoginScene");
                    //DisplayEmail.text = read.email;
                    file.Close();

            }
        auth.SignInWithEmailAndPasswordAsync(read.email, read.pass).ContinueWith(task1 =>
        {
            FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://game-205318.firebaseio.com/");
                // Get the root reference location of the database.
                

            if (task1.IsFaulted)
            {
                    // Handle the error...
                    print("Faulted");
            }
            else if (task1.IsCompleted)
            {
                print("user logged in while initialzing");
                DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
                FirebaseDatabase.DefaultInstance.GetReference(read.uid).GetValueAsync().ContinueWith(task2 =>
                {
                    DataSnapshot snapshot = task2.Result;
                        // Do something with snapshot...
                        var a = snapshot.Children;
                    string s;
                    if (task2.IsCompleted)
                    {
                        while (a.GetEnumerator().MoveNext())
                        {
                            s = a.GetEnumerator().Current.GetRawJsonValue();
                            print("s->" + s);
                            print("Key->" + a.GetEnumerator().Current.Key + "Value->" + a.GetEnumerator().Current.Value);
                        }
                    }

                });
            }
        });
            //print("text is from" + resource1.text);
            //resource1.text = "123m";

        }

  
    }
public class data
{
    public string email { get; set; }
    public string pass { get; set; }
    public string uid { get; set; }
    public bool set { get; set; }

}