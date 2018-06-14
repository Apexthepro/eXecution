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

public class dbinitscript : MonoBehaviour {
    public Text resource1;
    string path = "Assets/sam.txt";
    // Use this for initialization
    void Start () {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://game-205318.firebaseio.com/");
        // Get the root reference location of the database.
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseDatabase.DefaultInstance.GetReference("1").GetValueAsync().ContinueWith(task => {
            print("task entered");
         if (task.IsFaulted)
         {
                // Handle the error...
                print("Faulted");
          }
         else if (task.IsCompleted)
         {
             DataSnapshot snapshot = task.Result;
                // Do something with snapshot...
                var a = snapshot.Children;
                string s;

                while (a.GetEnumerator().MoveNext())
                {
                    s=a.GetEnumerator().Current.GetRawJsonValue();
                    //print("s->" + s);
                    //print("Key->"+a.GetEnumerator().Current.Key+"Value->"+ a.GetEnumerator().Current.Value);
                }
         
                
       
          }
     });

        print("text is from"+resource1.text);
        //resource1.text = "123m";

    }

	// Update is called once per frame
	void Update () {
		
	}
}
