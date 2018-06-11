using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using MySql.Data.MySqlClient;
public class LoginScript : MonoBehaviour {

    // Use this for initialization
    public Text id;
    public Text pwd;
    void Start () {
        

    }
    public void submit()
    {
        print("login clicked");
    }
	/* public void loginClick(){
        print("Username is : "+id.text + " Password is : "+pwd.text);
        string conn = "datasource=127.0.0.1;port=3306;database=game;username=root;password=;SslMode=none";
        MySqlConnection mydbcon = new MySqlConnection(conn);
        MySqlDataReader myreader = null;
        mydbcon.Open();
        string query = "select * from user where user_id='" + id + "' AND password='" + pwd + "' ;";
        MySqlCommand cmd = new MySqlCommand(query, mydbcon);
        myreader = cmd.ExecuteReader();
        while (myreader.Read())
        {
            print(myreader.GetValue(0) + " - " + myreader.GetValue(1) + " - " + myreader.GetValue(2));
        }
        if (myreader.HasRows)
            print("login Successfull");
        else
            print("Incorrect Login ID or Password");
    }
	// Update is called once per frame
	void Update () {
		
	}*/
}
