using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System.IO;
using UnityEditor;

public class dbinitscript : MonoBehaviour {
    public Text resource1;
	// Use this for initialization
	void Start () {
        string path = "Assets/sample.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("fluxi");
        writer.Close();
        StreamReader reader = new StreamReader(path);
        print(reader.ReadToEnd());
        reader.Close();

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
                int b=1;
                string s;

                while (a.GetEnumerator().MoveNext())
                {
                    s=a.GetEnumerator().Current.GetRawJsonValue();
                    //print("s->" + s);
                    //print("Key->"+a.GetEnumerator().Current.Key+"Value->"+ a.GetEnumerator().Current.Value);
                }
                //print("b->"+b);
                
       
          }
     });

        print("text is from"+resource1.text);
        //resource1.text = "123m";

    }

	// Update is called once per frame
	void Update () {
		
	}
}
