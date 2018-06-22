using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragCube : MonoBehaviour {
    public RotateBySwipe RotateBySwipe;
    public TileManager TileManager;
    public GameObject Capsule;
    public GameObject CastlePrefab;
    public GameObject AddCastleButtonPanel;
    private GameObject tempGameObject;
    Vector3 dist;
    Vector3 startPos;
    Vector3 capsulePos;
    float posX;
    float posZ;
    float posY;
    private float newz, newx,newlat,newlon;
    void OnMouseDown()
    {
        startPos = transform.position;
        dist = Camera.main.WorldToScreenPoint(transform.position);
        posX = Input.mousePosition.x - dist.x;
        posY = Input.mousePosition.y - dist.y;
        posZ = Input.mousePosition.z - dist.z;
    }

    void OnMouseDrag()
    {
        float disX = Input.mousePosition.x - posX;
        float disY = Input.mousePosition.y - posY;
        float disZ = Input.mousePosition.z - posZ;
        Vector3 lastPos = Camera.main.ScreenToWorldPoint(new Vector3(disX, disY, disZ));
        transform.position = new Vector3(lastPos.x, startPos.y, lastPos.z);
        RotateBySwipe.rotate = false;
        startPos = transform.position;
        capsulePos = Capsule.transform.position;
        newlat = ((startPos.z - capsulePos.z )* 0.00007099257f)+TileManager.getLat;
        newlon = ((startPos.x - capsulePos.x) * 0.00003094135f) + TileManager.getLon;
        print("Current Lat: "+ newlat);

        print("Current Lon: "+newlon);
    }

    public void AddCastle() {
        //add funtion to check if user can add a castle
        AddCastleButtonPanel.SetActive(false);

        CastlePrefab.SetActive(true);
        print("Adding Castle");
    }
}
