using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;
public class UpgradeMenuScript : MonoBehaviour {

    // Use this for initialization
    public string ugtime = "5",res="";
    public float[] resA;
    public float[] time;
    public float monsterbounty=1000,multlevel=5,ugfactor=1.5f,buildingImpactFactor, prevresourceA, prevresourceB, currcastlevalue;

    public int[] level;
    void Start()
    {
        float[] resA = new float[35];
        float[] time = new float[7] {0.01f,0.1f,1,2,3,4,5};
        float newtime;
       string[] bname = new string[7] { "Castledetails", "Walldetails", "Forgedetails", "Laboratorydetails", "Hero Grounddetails", "Storagedetails", "Trade Halldetails" };
    var watch = new System.Diagnostics.Stopwatch();
        watch.Start();
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://game-205318.firebaseio.com/");
        // Get the root reference location of the database.
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        prevresourceA = 5000;
        buildingImpactFactor = 1;
        for (int i = 0; i < 35; i++) {
            //reference.Child((i + 1).ToString()).Child(bname[0]).Child("resourceA").SetValueAsync(Math.Round(prevresourceA, 3));
            //reference.Child((i + 1).ToString()).Child(bname[0]).Child("resourceB").SetValueAsync(Math.Round(prevresourceA, 3));
            resA[i] = prevresourceA;
            prevresourceA = (prevresourceA / buildingImpactFactor) * ugfactor;
            prevresourceB = prevresourceA;
        }
        for (int i = 0; i < 35; i++)
        {
            for (int j = 1; j < 7; j++)
            {
                if (j == 1)
                    buildingImpactFactor = 2;
                if (j == 2)
                    buildingImpactFactor = 2.8f;
                if (j == 3)
                    buildingImpactFactor = 4;
                if (j == 4)
                    buildingImpactFactor = 2.5f;
                if (j == 5)
                    buildingImpactFactor = 3;
                if (j == 6)
                    buildingImpactFactor = 3.2f;
                prevresourceA=(resA[i]/ buildingImpactFactor)*ugfactor;

                //    reference.Child((i + 1).ToString()).Child(bname[j]).Child("resourceA").SetValueAsync(Math.Round(prevresourceA, 3));
                //   reference.Child((i + 1).ToString()).Child(bname[j]).Child("resourceB").SetValueAsync(Math.Round(prevresourceA, 3));

                /**********************************Done*************************************/
            }

        }
        for (int i = 0; i < 7; i++)
        {
            reference.Child((i + 1).ToString()).Child(bname[0]).Child("ugtime").SetValueAsync(Math.Round(time[i], 3));

            reference.Child("BuildingsInfo").Child(bname[i]).Child("Details").SetValueAsync("This is Forge.It can be used to Forge new Crystals to Help in Upgrades");
            for (int k = 1; k <=35; k++)
            {
                
                reference.Child("BuildingsInfo").Child(bname[i]).Child("levels").Child(k.ToString()).Child("buff1").SetValueAsync("0.2");
                reference.Child("BuildingsInfo").Child(bname[i]).Child("levels").Child(k.ToString()).Child("buff2").SetValueAsync("0.5");
                reference.Child("BuildingsInfo").Child(bname[i]).Child("levels").Child(k.ToString()).Child("prestige").SetValueAsync("500");
            }
            reference.Child("BuildingsInfo").Child(bname[i]).Child("buff1desc").SetValueAsync("buff1 description");
            reference.Child("BuildingsInfo").Child(bname[i]).Child("lev").SetValueAsync("1");
            reference.Child("BuildingsInfo").Child(bname[i]).Child("buff2desc").SetValueAsync("buff2 description");


        }
        for (int j = 1; j <7; j++)
        {
            if (j == 1)
                buildingImpactFactor = 2;
            if (j == 2)
                buildingImpactFactor = 2.8f;
            if (j == 3)
                buildingImpactFactor = 4;
            if (j == 4)
                buildingImpactFactor = 2.5f;
            if (j == 5)
                buildingImpactFactor = 3;
            if (j == 6)
                buildingImpactFactor = 3.2f;

            for (int k = 0; k<7; k++)
            {
                newtime = time[k] / buildingImpactFactor;
                //reference.Child((k + 1).ToString()).Child(bname[j]).Child("ugtime").SetValueAsync(Math.Round(newtime, 3));
                //print(newtime + "=" + time[k] + "/" + buildingImpactFactor);
                //print("newtime ->" + newtime);
            }
        }
                /*  for (int i = 0; i < 35; i++)
                   {
                       if (i==0) {
                           prevresourceA = 5000;
                           prevresourceB= 5000;
                       }
                       for (int j = 0; j <2; j++)
                       {

                            if (j == 0)
                               buildingImpactFactor = 1;
                           if (j == 1)
                               buildingImpactFactor = 2;
                           if (j == 2)
                               buildingImpactFactor = 2.8f;
                           if (j == 3)
                               buildingImpactFactor = 4;
                           if (j == 4)
                               buildingImpactFactor = 2.5f;
                           if (j == 5)
                               buildingImpactFactor = 3;
                           if (j == 6)
                               buildingImpactFactor = 3.2f;
                       if (j == 0)
                       {
                               prevresourceA = (currcastlevalue / buildingImpactFactor) * ugfactor;
                               prevresourceB = (currcastlevalue / buildingImpactFactor) * ugfactor;
                           }
                       else{
                           prevresourceA = ((multlevel * monsterbounty) / buildingImpactFactor)*ugfactor;
                           prevresourceB = ((multlevel * monsterbounty) / buildingImpactFactor)*ugfactor;
                       }

                           if (j == 0)
                           {
                               currcastlevalue = prevresourceA;

                           }
                           print("Current BUilding is --> "+bname[j]);
                           reference.Child((i + 1).ToString()).Child(bname[j]).Child("resourceA").SetValueAsync(Math.Round(prevresourceA, 3));
                           reference.Child((i + 1).ToString()).Child(bname[j]).Child("resourceB").SetValueAsync(Math.Round(prevresourceB, 3));
                           reference.Child((i + 1).ToString()).Child(bname[j]).Child("ugtime").SetValueAsync(i + 10);

                           print("currentcastlevalue" + currcastlevalue + "prevresource:" + prevresourceA + "buildingImpactFactor:" + buildingImpactFactor + "ugfactor:" + ugfactor);
                           print("prevresourceA = (currcastlevalue/ buildingImpactFactor) * ugfactor;" + (currcastlevalue / buildingImpactFactor) * ugfactor);
                           prevresourceA = (currcastlevalue / buildingImpactFactor) * ugfactor;
                           prevresourceB = (currcastlevalue / buildingImpactFactor) * ugfactor;
                           reference.Child((i + 1).ToString()).Child(bname[j]).Child("prevresourceA").SetValueAsync(prevresourceA);



                       }

                   }
                 */
                watch.Stop();        
        //print($"Execution Time: {watch.ElapsedMilliseconds} ms");
    }
}
