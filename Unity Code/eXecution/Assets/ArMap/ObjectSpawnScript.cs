using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectSpawnScript : MonoBehaviour {
    public TileManager TileManager;
    public GameObject cube;
    public GameObject cube2;
    private float lat = 0f, lon = 0f;

    //1.408598 pixels = 0.0001lat  z axis
    //1z pixel = 0.00007099257lat
    //3.23192 pixels = 0.0001lon x axis
    //1x pixel = 0.00003094135lon
    void Start()
    {
        
    }
    public void tempfunc() {
        float newLat = TileManager.getLat;//+ UnityEngine.Random.Range (-0.0002f, 0.0002f);//0.00073f
        float newLon = TileManager.getLon;//+ UnityEngine.Random.Range (-0.0002f, 0.0002f);//-0.000315f
        print("initial lat: " + newLat + " lon: " + newLon);
        SpawnObject(newLat, newLon);

    }
    public void SpawnObject(float _lat, float _lon)
    {
        lat = _lat;
        lon = _lon;
        UpdatePosition();
    }
    public void UpdatePosition()
    {
        float x, y;
        Vector3 position = Vector3.zero;

       geodeticOffsetInv(TileManager.getLat * Mathf.Deg2Rad, TileManager.getLon * Mathf.Deg2Rad, lat * Mathf.Deg2Rad, lon * Mathf.Deg2Rad, out x, out y);

        if ((lat - TileManager.getLat) < 0 && (lon - TileManager.getLon) > 0 || (lat - TileManager.getLat) > 0 && (lon - TileManager.getLon) < 0)
        {
            position = new Vector3(Mathf.Round(x), 0, Mathf.Round(y));
        }
        else
        {
            position = new Vector3(-Mathf.Round(x), 0, -Mathf.Round(y));
        }
        print("x"+x+"y"+y);
        position.x *= 0.300122f;
        position.z *= 0.123043f;
        print("cube position"+ cube.transform.position);
        cube.transform.position = position;
    }
    // Use this for initialization
   
	// Update is called once per frame
	void Update () {
		
	}













    //SOURCE: http://stackoverflow.com/questions/4953150/convert-lat-longs-to-x-y-co-ordinates

    float GD_semiMajorAxis = 6378137.000000f;
    float GD_TranMercB = 6356752.314245f;
    float GD_geocentF = 0.003352810664f;

    public void geodeticOffsetInv(float refLat, float refLon,
        float lat, float lon,
        out float xOffset, out float yOffset)
    {
        float a = GD_semiMajorAxis;
        float b = GD_TranMercB;
        float f = GD_geocentF;

        float L = lon - refLon;
        float U1 = Mathf.Atan((1 - f) * Mathf.Tan(refLat));
        float U2 = Mathf.Atan((1 - f) * Mathf.Tan(lat));
        float sinU1 = Mathf.Sin(U1);
        float cosU1 = Mathf.Cos(U1);
        float sinU2 = Mathf.Sin(U2);
        float cosU2 = Mathf.Cos(U2);

        float lambda = L;
        float lambdaP;
        float sinSigma;
        float sigma;
        float cosSigma;
        float cosSqAlpha;
        float cos2SigmaM;
        float sinLambda;
        float cosLambda;
        float sinAlpha;
        int iterLimit = 100;
        do
        {
            sinLambda = Mathf.Sin(lambda);
            cosLambda = Mathf.Cos(lambda);
            sinSigma = Mathf.Sqrt((cosU2 * sinLambda) * (cosU2 * sinLambda) +
                (cosU1 * sinU2 - sinU1 * cosU2 * cosLambda) *
                (cosU1 * sinU2 - sinU1 * cosU2 * cosLambda));
            if (sinSigma == 0)
            {
                xOffset = 0.0f;
                yOffset = 0.0f;
                return;  // co-incident points
            }
            cosSigma = sinU1 * sinU2 + cosU1 * cosU2 * cosLambda;
            sigma = Mathf.Atan2(sinSigma, cosSigma);
            sinAlpha = cosU1 * cosU2 * sinLambda / sinSigma;
            cosSqAlpha = 1 - sinAlpha * sinAlpha;
            cos2SigmaM = cosSigma - 2 * sinU1 * sinU2 / cosSqAlpha;
            if (cos2SigmaM != cos2SigmaM) //isNaN
            {
                cos2SigmaM = 0;  // equatorial line: cosSqAlpha=0 (§6)
            }
            float C = f / 16 * cosSqAlpha * (4 + f * (4 - 3 * cosSqAlpha));
            lambdaP = lambda;
            lambda = L + (1 - C) * f * sinAlpha *
                (sigma + C * sinSigma * (cos2SigmaM + C * cosSigma * (-1 + 2 * cos2SigmaM * cos2SigmaM)));
        } while (Mathf.Abs(lambda - lambdaP) > 1e-12 && --iterLimit > 0);

        if (iterLimit == 0)
        {
            xOffset = 0.0f;
            yOffset = 0.0f;
            return;  // formula failed to converge
        }

        float uSq = cosSqAlpha * (a * a - b * b) / (b * b);
        float A = 1 + uSq / 16384 * (4096 + uSq * (-768 + uSq * (320 - 175 * uSq)));
        float B = uSq / 1024 * (256 + uSq * (-128 + uSq * (74 - 47 * uSq)));
        float deltaSigma = B * sinSigma * (cos2SigmaM + B / 4 * (cosSigma * (-1 + 2 * cos2SigmaM * cos2SigmaM) -
            B / 6 * cos2SigmaM * (-3 + 4 * sinSigma * sinSigma) * (-3 + 4 * cos2SigmaM * cos2SigmaM)));
        float s = b * A * (sigma - deltaSigma);

        float bearing = Mathf.Atan2(cosU2 * sinLambda, cosU1 * sinU2 - sinU1 * cosU2 * cosLambda);
        xOffset = Mathf.Sin(bearing) * s;
        yOffset = Mathf.Cos(bearing) * s;
    }
}
