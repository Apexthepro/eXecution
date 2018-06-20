using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
public class GoogleMapScript : MonoBehaviour
{

    string url = ""; //will hold the completed  url request we make to the google maps api

    public float lat = 0f; //Insert your desired latitude
    public float lon = 0f; //Insert your desired longitude
    public int zoom = 1;
    public int mapWidth = 1920;
    public int mapHeight = 1080;
    public MapUtils MapUtils;
    public enum mapType { roadmap, satellite, hybrid, terrain }; //choose map type to display
    public mapType mapSelected;
    public int scale;
    public int R = 6371;//Radius of earth
    public Image sampleImage;
    public float x,y,z;
    //Vector2 uv = new Vector2((float)myMarker.pixelCoords.x / (float)renderer.material.mainTexture.width, 1f - (float)myMarker.pixelCoords.y / (float)renderer.material.mainTexture.height);
    Vector2 uv;

    private bool loadingMap = false; //keeps track of whether we're waiting for a texture to load in case we want to display some sort of loading message while user waits for the map to load
    private string customIcon = /*"https://tinyurl.com/ydgu22os";*/"https://tinyurl.com/yblwsgof";
    private IEnumerator mapCoroutine;


    IEnumerator GetGoogleMap(float lat, float lon)
    {
        url = "https://maps.googleapis.com/maps/api/staticmap?center=" + lat + "," + lon +
            "&zoom=" + zoom + "&size=" + 1920 + "x" + 1080 + "&scale=" + scale
            + "&maptype=" + mapSelected +
            "&markers=color:blue%7Clabel:S%7C1,0&key=AIzaSyAG_VbAh7y2sSRfTRCRlL_ge4EThjjqoRk";
        //url = "https://maps.googleapis.com/maps/api/staticmap?&size=1280x720&style=visibility:on&style=feature:water%7Celement:geometr%7Cvisibility:on&style=feature:landscape%7Celement:geometry%7Cvisibility:on&markers=icon:"+customIcon+"%7CCanberra+ACT&markers=icon:http://tinyurl.com/jrhlvu6%7CMelbourne+VIC+&markers=icon:https://goo.gl/1oTJ9Y%7CSydney+NSW&key=AIzaSyAG_VbAh7y2sSRfTRCRlL_ge4EThjjqoRk";
       // url = "https://maps.googleapis.com/maps/api/staticmap?&size=1280x720&style=visibility:on&style=feature:water%7Celement:geometr%7Cvisibility:on&style=feature:landscape%7Celement:geometry%7Cvisibility:on&markers=icon:"+customIcon+"%7CCanberra+ACT&markers=icon:http://tinyurl.com/jrhlvu6%7CMelbourne+VIC+&markers=icon:https://goo.gl/1oTJ9Y%7CSydney+NSWAIz&key=aSyAG_VbAh7y2sSRfTRCRlL_ge4EThjjqoRk";
       // url = "https://maps.googleapis.com/maps/api/staticmap?size=512x512&zoom=15&center=Brooklyn&style=feature:road.local%7Celement:geometry%7Ccolor:0x00ff00&style=feature:landscape%7Celement:geometry.fill%7Ccolor:0x000000&style=element:labels%7Cinvert_lightness:true&style=feature:road.arterial%7Celement:labels%7Cinvert_lightness:false&key=AIzaSyAG_VbAh7y2sSRfTRCRlL_ge4EThjjqoRk";


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
        uv = new Vector2((float)608 / (float)MapUtils.LonToX(lon), 1f - (float)350 / (float)MapUtils.LatToY(lat));
        print("Lat = " + lat + "lon = " + lon);
        
        x = ((float)(R * Math.Cos(lat) * Math.Cos(lon))/ 6.636458333333333f);

        y = ((float)(R * Math.Cos(lat) * Math.Sin(lon)) / 11.79814814814815f);
        print("x =" +x);
        print("y =" +y);
      //  print("z =" + R * Math.Sin(lat));
        sampleImage.transform.position = new Vector3(x,y,0);

    }

    void Update()
    {
        //  print("uv" + uv);
        // print("UvTo3D" + UvTo3D(uv));
        //print("MapUtils lon to x" + MapUtils.LonToX(lon));
        //print("MapUtils lat to y" + MapUtils.LatToY(lat));

        

        //lat = 1;
        //lon = 2;
        print("Lat = "+ lat +"lon = "+lon);
        print("x ="+ R * Math.Cos(lat) * Math.Cos(lon));
        print("y =" + R * Math.Cos(lat) * Math.Sin(lon));
        print("z =" + R * Math.Sin(lat));
     //   print("long =" + R * Math.Cos(lat) * Math.Cos(lon));
   //     print("lat =" + R * Math.Cos(lat) * Math.Cos(lon));

        if (Input.GetKeyDown(KeyCode.M))
        { //Example of how to update the map with a new set of coordinates

            mapCoroutine = GetGoogleMap(lat, lon); //redefine the coroutine with the new map coordinates (might be a better way to do this...let me know!)
            StartCoroutine(mapCoroutine); //restart the coroutine
        }
        if (Input.GetKeyDown(KeyCode.R))
        { //Example of how to update the map with a new set of coordinates
            mapCoroutine = GetGoogleMap(lat, lon); //redefine the coroutine with the new map coordinates (might be a better way to do this...let me know!)
            StartCoroutine(mapCoroutine); //restart the coroutine
        }
    }

    public Vector3 UvTo3D(Vector2 uv)
    {

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        int[] tris = mesh.triangles;
        Vector2[] uvs = mesh.uv;
        Vector3[] verts = mesh.vertices;

        for (int i = 0; i < tris.Length; i += 3)
        {
            Vector2 u1 = uvs[tris[i]]; // get the triangle UVs
            Vector2 u2 = uvs[tris[i + 1]];
            Vector2 u3 = uvs[tris[i + 2]];

            // calculate triangle area - if zero, skip it
            float a = Area(u1, u2, u3); if (a == 0) continue;

            // calculate barycentric coordinates of u1, u2 and u3
            // if anyone is negative, point is outside the triangle: skip it
            float a1 = Area(u2, u3, uv) / a; if (a1 < 0) continue;
            float a2 = Area(u3, u1, uv) / a; if (a2 < 0) continue;
            float a3 = Area(u1, u2, uv) / a; if (a3 < 0) continue;

            // point inside the triangle - find mesh position by interpolation...
            Vector3 p3D = a1 * verts[tris[i]] + a2 * verts[tris[i + 1]] + a3 * verts[tris[i + 2]];

            // and return it in world coordinates:
            return transform.TransformPoint(p3D);
        }

        // point outside any uv triangle: return Vector3.zero
        return Vector3.zero;
    }

    // calculate signed triangle area using a kind of "2D cross product":
    public float Area(Vector2 p1, Vector2 p2, Vector2 p3)
    {

        Vector2 v1 = p1 - p3;
        Vector2 v2 = p2 - p3;

        return (v1.x * v2.y - v1.y * v2.x) / 2f;
    }
}
