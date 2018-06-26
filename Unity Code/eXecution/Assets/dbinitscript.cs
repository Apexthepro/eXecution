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
using Newtonsoft.Json.Linq;

public class dbinitscript : MonoBehaviour
{
    public Text resource1;
    data read = new data();
    public jsondetailsdata jddata = new jsondetailsdata();
    public jsondatac data = new jsondatac();
    string path = "Assets/sam.txt";
    public Firebase.Auth.FirebaseAuth auth;
    // Use this for initialization
    void Start()
    {
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
                //print("user logged in while initialzing");
                DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
                FirebaseDatabase.DefaultInstance.GetReference(read.uid).GetValueAsync().ContinueWith(task2 =>
                {
                    DataSnapshot snapshot = task2.Result;
                    // Do something with snapshot...
                    var a = snapshot.Children;
                    data = JsonConvert.DeserializeObject<jsondatac>(snapshot.GetRawJsonValue());
                    print("outside func values--->" + data.Buildings.Castle.lev.ToString());
                    string s;
                    if (task2.IsCompleted)
                    {
                        while (a.GetEnumerator().MoveNext())
                        {
                            s = a.GetEnumerator().Current.GetRawJsonValue();
                            //print("s->" + s);
                            //print("Key->" + a.GetEnumerator().Current.Key + "Value->" + a.GetEnumerator().Current.Value);
                        }
                    }

                });
            }
        });
        //print("text is from" + resource1.text);
        //resource1.text = "123m";
        db_read("BuildingsInfo");
    }
    public void db_read(string read)
    {

        DataSnapshot snapshot = null;
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseDatabase.DefaultInstance.GetReference(read).GetValueAsync().ContinueWith(task2 =>
        {
            snapshot = task2.Result;
            // Do something with snapshot...
            var a = snapshot.Children;
            jddata = JsonConvert.DeserializeObject<jsondetailsdata>(snapshot.GetRawJsonValue());
            print("inside func values--->" + jddata.Forgedetails.Details.ToString());
            string s;
            if (task2.IsCompleted)
            {

            }

        });
    }
}

public class data
{
    public string email { get; set; }
    public string pass { get; set; }
    public string uid { get; set; }
    public bool set { get; set; }

}
public class jsondatac
{
    public Buildings Buildings { get; set; }
    public ReferenceCode ReferenceCode { get; set; }
    public Resources Resources { get; set; }
    public Social Social { get; set; }
}

public class Buildings
{
    public Castle Castle { get; set; }
    public DragonTomb DragonTomb { get; set; }
    public Forge Forge { get; set; }
    public HeroGround HeroGround { get; set; }
    public Laboratory Laboratory { get; set; }
    public Storage Storage { get; set; }
    public TradeHall TradeHall { get; set; }
    public Wall Wall { get; set; }
}

public class Castle
{
    public int lev { get; set; }
}

public class DragonTomb
{
    public int lev { get; set; }
}

public class Forge
{
    public int lev { get; set; }
}

public class HeroGround
{
    public int lev { get; set; }
}

public class Laboratory
{
    public int lev { get; set; }
}

public class Storage
{
    public int lev { get; set; }
}

public class TradeHall
{
    public int lev { get; set; }
}

public class Wall
{
    public int lev { get; set; }
}

public class ReferenceCode
{
    public PlayerCode PlayerCode { get; set; }
}

public class PlayerCode
{
    public PlayersWhoUseTheCode Playerswhousethecode { get; set; }
    public int codeofthePlayer { get; set; }
}

public class PlayersWhoUseTheCode
{
    public string users { get; set; }
}

public class Resources
{
    public int ResourceA { get; set; }
    public int ResourceB { get; set; }
}

public class Social
{
    public string Friends { get; set; }
}


public class jsondetailsdata
{
    public Castledetails Castledetails { get; set; }
    public Forgedetails Forgedetails { get; set; }
    public HeroGrounddetails HeroGrounddetails { get; set; }
    public Laboratorydetails Laboratorydetails { get; set; }
    public Storagedetails Storagedetails { get; set; }
    public TradeHalldetails TradeHalldetails { get; set; }
    public Walldetails Walldetailsdetails { get; set; }
}

public class Castledetails
{
    public string buff1 { get; set; }
    public string Details { get; set; }
    public string buff2 { get; set; }
    public string Prestige { get; set; }
    public string lev { get; set; }
    public string buff1desc { get; set; }
    public string buff2desc { get; set; }
}

public class Forgedetails
{
    public string buff1 { get; set; }
    public string Details { get; set; }
    public string buff2 { get; set; }
    public string Prestige { get; set; }
    public string lev { get; set; }
    public string buff1desc { get; set; }
    public string buff2desc { get; set; }
}

public class HeroGrounddetails
{
    public string buff1 { get; set; }
    public string Details { get; set; }
    public string buff2 { get; set; }
    public string Prestige { get; set; }
    public string lev { get; set; }
    public string buff1desc { get; set; }
    public string buff2desc { get; set; }
}

public class Laboratorydetails
{
    public string buff1 { get; set; }
    public string Details { get; set; }
    public string buff2 { get; set; }
    public string Prestige { get; set; }
    public string lev { get; set; }
    public string buff1desc { get; set; }
    public string buff2desc { get; set; }
}

public class Storagedetails
{
    public string buff1 { get; set; }
    public string Details { get; set; }
    public string buff2 { get; set; }
    public string Prestige { get; set; }
    public string lev { get; set; }
    public string buff1desc { get; set; }
    public string buff2desc { get; set; }
}

public class TradeHalldetails
{
    public string BonusSpeed { get; set; }
    public string Details { get; set; }
    public string buff2 { get; set; }
    public string Prestige { get; set; }
    public string lev { get; set; }
    public string buff1desc { get; set; }
    public string buff2desc { get; set; }
}

public class Walldetails
{
    public string BonusSpeed { get; set; }
    public string Details { get; set; }
    public string buff2 { get; set; }
    public string Prestige { get; set; }
    public string lev { get; set; }
    public string buff1desc { get; set; }
    public string buff2desc { get; set; }
}
