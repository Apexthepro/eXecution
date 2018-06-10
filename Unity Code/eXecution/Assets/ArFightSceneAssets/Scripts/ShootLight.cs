using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
public class ShootLight : MonoBehaviour {

    public bool alreadyCasting = false;
    public float damage;
    public float range;
    public GameObject fireballprefab;
    public GameObject SpellSpwanPoint;
    public Camera PlayerCamera;
    public GameObject MonsterPrefab;
    public int Monsternumber = 0;
    public GameObject fireballColider;
    public RawImage rawimage;
    public Vector3 camerastart;

    // Use this for initialization
    public void Start()
    {
        camerastart = PlayerCamera.transform.position;
        Instantiate(MonsterPrefab, new Vector3(1.79f, 0.34f, 26f), Quaternion.identity);

        WebCamDevice[] devices = WebCamTexture.devices;
        WebCamTexture webcamTexture = new WebCamTexture();

        foreach (WebCamDevice cam in devices)
        {

            if (!cam.isFrontFacing)
            {
                webcamTexture.deviceName = cam.name;
            }
        }
        Debug.Log(webcamTexture.deviceName);

        webcamTexture.Play();
        rawimage.texture = webcamTexture;
        rawimage.material.mainTexture = webcamTexture;
    }
    // Update is called once per frame
    public void Update()
    {
       

    }
    
}
