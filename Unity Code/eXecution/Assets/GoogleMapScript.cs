﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GoogleMapScript : MonoBehaviour
{

    string url = ""; //will hold the completed  url request we make to the google maps api

    public float lat = 24.917828f; //Insert your desired latitude
    public float lon = 67.097096f; //Insert your desired longitude
    public int zoom = 14;
    public int mapWidth = 640;
    public int mapHeight = 640;
    public enum mapType { roadmap, satellite, hybrid, terrain }; //choose map type to display
    public mapType mapSelected;
    public int scale;
<<<<<<< HEAD
    public int R = 6371;//Radius of earth
    public Image sampleImage;
    public float x, y, z;
    //Vector2 uv = new Vector2((float)myMarker.pixelCoords.x / (float)renderer.material.mainTexture.width, 1f - (float)myMarker.pixelCoords.y / (float)renderer.material.mainTexture.height);
    Vector2 uv;

=======
    public int R = 6371;
>>>>>>> d35ac9ff4ed7a0f104b81bba48905ed98b6f54ea
    private bool loadingMap = false; //keeps track of whether we're waiting for a texture to load in case we want to display some sort of loading message while user waits for the map to load
    public Sprite customIcon;
    private IEnumerator mapCoroutine;


    IEnumerator GetGoogleMap(float lat, float lon)
    {
        url = "https://maps.googleapis.com/maps/api/staticmap?center=" + lat + "," + lon +
            "&zoom=" + zoom + "&size=" + mapWidth + "x" + mapHeight + "&scale=" + scale
            + "&maptype=" + mapSelected +
            "&markers=color:blue%7Clabel:S%7C1,0&key=AIzaSyAG_VbAh7y2sSRfTRCRlL_ge4EThjjqoRk";
        //url = "https://maps.googleapis.com/maps/api/staticmap?&size=1280x720&style=visibility:on&style=feature:water%7Celement:geometr%7Cvisibility:on&style=feature:landscape%7Celement:geometry%7Cvisibility:on&markers=icon:"+customIcon+"%7CCanberra+ACT&markers=icon:http://tinyurl.com/jrhlvu6%7CMelbourne+VIC+&markers=icon:https://goo.gl/1oTJ9Y%7CSydney+NSW&key=AIzaSyAG_VbAh7y2sSRfTRCRlL_ge4EThjjqoRk";
<<<<<<< HEAD
        // url = "https://maps.googleapis.com/maps/api/staticmap?&size=1280x720&style=visibility:on&style=feature:water%7Celement:geometr%7Cvisibility:on&style=feature:landscape%7Celement:geometry%7Cvisibility:on&markers=icon:"+customIcon+"%7CCanberra+ACT&markers=icon:http://tinyurl.com/jrhlvu6%7CMelbourne+VIC+&markers=icon:https://goo.gl/1oTJ9Y%7CSydney+NSWAIz&key=aSyAG_VbAh7y2sSRfTRCRlL_ge4EThjjqoRk";
        // url = "https://maps.googleapis.com/maps/api/staticmap?size=512x512&zoom=15&center=Brooklyn&style=feature:road.local%7Celement:geometry%7Ccolor:0x00ff00&style=feature:landscape%7Celement:geometry.fill%7Ccolor:0x000000&style=element:labels%7Cinvert_lightness:true&style=feature:road.arterial%7Celement:labels%7Cinvert_lightness:false&key=AIzaSyAG_VbAh7y2sSRfTRCRlL_ge4EThjjqoRk";
=======
       // url = "https://maps.googleapis.com/maps/api/staticmap?&size=1280x720&style=visibility:on&style=feature:water%7Celement:geometr%7Cvisibility:on&style=feature:landscape%7Celement:geometry%7Cvisibility:on&markers=icon:"+customIcon+"%7CCanberra+ACT&markers=icon:http://tinyurl.com/jrhlvu6%7CMelbourne+VIC+&markers=icon:https://goo.gl/1oTJ9Y%7CSydney+NSWAIz&key=aSyAG_VbAh7y2sSRfTRCRlL_ge4EThjjqoRk";
        url = "https://maps.googleapis.com/maps/api/staticmap?&size=1280x720&style=visibility:on&style=feature:water%7Celement:geometr%7Cvisibility:on&style=feature:landscape%7Celement:geometry%7Cvisibility:on&markers=icon:"+customIcon+"%7CCanberra+ACT&markers=icon:http://tinyurl.com/jrhlvu6%7CMelbourne+VIC+&markers=icon:https://goo.gl/1oTJ9Y%7CSydney+NSW&key=AIzaSyAG_VbAh7y2sSRfTRCRlL_ge4EThjjqoRk";
       // url = "https://maps.googleapis.com/maps/api/staticmap?size=512x512&zoom=15&center=Brooklyn&style=feature:road.local%7Celement:geometry%7Ccolor:0x00ff00&style=feature:landscape%7Celement:geometry.fill%7Ccolor:0x000000&style=element:labels%7Cinvert_lightness:true&style=feature:road.arterial%7Celement:labels%7Cinvert_lightness:false&key=AIzaSyAG_VbAh7y2sSRfTRCRlL_ge4EThjjqoRk";
>>>>>>> d35ac9ff4ed7a0f104b81bba48905ed98b6f54ea


        loadingMap = true;
        WWW www = new WWW(url); //make the new request
        yield return www; //happens once we receive a response from the google maps api
        loadingMap = false;
        gameObject.GetComponent<RawImage>().texture = www.texture; //assign downloaded map texture to Canvas Image
        StopCoroutine(mapCoroutine); //stop the coroutine once we have the texture

    }
    void Start()
    {
        mapCoroutine = GetGoogleMap(lat, lon);
        StartCoroutine(mapCoroutine);
<<<<<<< HEAD
        uv = new Vector2((float)608 / (float)MapUtils.LonToX(lon), 1f - (float)350 / (float)MapUtils.LatToY(lat));
        print("Lat = " + lat + "lon = " + lon);

        x = ((float)(R * Math.Cos(lat) * Math.Cos(lon)) / 6.636458333333333f);

        y = ((float)(R * Math.Cos(lat) * Math.Sin(lon)) / 11.79814814814815f);
        print("x =" + x);
        print("y =" + y);
        //  print("z =" + R * Math.Sin(lat));
        sampleImage.transform.position = new Vector3(x, y, 0);

=======
>>>>>>> d35ac9ff4ed7a0f104b81bba48905ed98b6f54ea
    }

    void Update()
    {
        //  print("uv" + uv);
        // print("UvTo3D" + UvTo3D(uv));
        //print("MapUtils lon to x" + MapUtils.LonToX(lon));
        //print("MapUtils lat to y" + MapUtils.LatToY(lat));

<<<<<<< HEAD


        //lat = 1;
        //lon = 2;
        print("Lat = " + lat + "lon = " + lon);
        print("x =" + R * Math.Cos(lat) * Math.Cos(lon));
        print("y =" + R * Math.Cos(lat) * Math.Sin(lon));
        print("z =" + R * Math.Sin(lat));
        //   print("long =" + R * Math.Cos(lat) * Math.Cos(lon));
        //     print("lat =" + R * Math.Cos(lat) * Math.Cos(lon));
=======
        

        //lat = 1;
        //lon = 2;
        lat = 1;
        lon = 0;
        print("Lat = "+ lat +"lon = "+lon);
        print("x ="+ R * Math.Cos(lat) * Math.Cos(lon));
        print("y =" + R * Math.Cos(lat) * Math.Sin(lon));
        print("z =" + R * Math.Sin(lat));
     //   print("long =" + R * Math.Cos(lat) * Math.Cos(lon));
   //     print("lat =" + R * Math.Cos(lat) * Math.Cos(lon));
>>>>>>> d35ac9ff4ed7a0f104b81bba48905ed98b6f54ea


        if (Input.GetKeyDown(KeyCode.M))
        { //Example of how to update the map with a new set of coordinates
            lat = 40.6786806f;
            lon = -073.8644250f;
            mapCoroutine = GetGoogleMap(lat, lon); //redefine the coroutine with the new map coordinates (might be a better way to do this...let me know!)
            StartCoroutine(mapCoroutine); //restart the coroutine
        }
        if (Input.GetKeyDown(KeyCode.R))
        { //Example of how to update the map with a new set of coordinates
            mapCoroutine = GetGoogleMap(lat, lon); //redefine the coroutine with the new map coordinates (might be a better way to do this...let me know!)
            StartCoroutine(mapCoroutine); //restart the coroutine
        }
    }
}
