using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class testscript : MonoBehaviour {

    public TileManager Tilemanager;
    public float lat, lon,rx,ry,X,Y;

	// Use this for initialization
	void Start () {
        rx = 0.00073f;
        ry = 0.000315f;


    }
	
	// Update is called once per frame
	void Update () {
        
        lat = Tilemanager.getLat;
        lon = Tilemanager.getLon;
        X = lat + rx;
        var y = (Math.Pow((X - lat),2))/Math.Pow(rx,2);
        var z=Math.Pow((Y- lon),2) / Math.Pow(ry, 2);
        print("result----------------------->" + y+z);

    }
}
