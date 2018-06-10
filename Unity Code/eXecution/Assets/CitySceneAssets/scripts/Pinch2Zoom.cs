
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pinch2Zoom : MonoBehaviour
{
    //pan script start
    Camera mainCamera;

    float touchesPrevPosDifference, touchesCurPosDifference, zoomModifier;

    Vector2 firstTouchPrevPos, secondTouchPrevPos;

    [SerializeField]
    public float zoomModifierSpeed = 0.005f;

    [SerializeField]
    Text text;//pan script end

    //swipe script start
    public float minSwipeDistY;
    public float panSpeed;
    public float minSwipeDistX;
    public float xpos;
    public float ypos;
    public float zpos;
    private Vector2 startPos;//swipe script end
    Vector3 pos;
    public UiCanvasScript UiCanvasScript;
    public BuildingsGlobalScript BuildingsGlobalScript;
    public bool mouseDown;

    void Start()
    {
        //xpos = transform.position.x;
        //ypos = transform.position.y;
        //zpos = transform.position.z;
        mainCamera = GetComponent<Camera>();
        //transform.position = new Vector3(xpos,ypos , zpos);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        if (Input.GetMouseButtonDown(0))
        {
            mouseDown = true;
            UiCanvasScript.DisplayBuildinNames(true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            UiCanvasScript.DisplayBuildinNames(false);
            mouseDown = false;
        }
        //swipe script start
        if (UiCanvasScript.activeMenus == null)
        {
             if (mouseDown)
             {
                pos = transform.position;
                //print("MouseX" + Input.GetAxis("Mouse X"));

                 if (Input.GetAxis("Mouse X") < -1.5)//-1
                 {
                    pos.x += panSpeed * Time.deltaTime * 65;//* (Time.deltaTime);
                   //  print("Mouse moved right " + pos.x );

                }
                 if (Input.GetAxis("Mouse X") > 1.5)//1
                 {
                     pos.x -= panSpeed * Time.deltaTime * 65;
                  //   print("Mouse moved left" + pos.x);

                }
                 if (Input.GetAxis("Mouse Y") < -1.5)//-1
                 {
                     pos.y += panSpeed * Time.deltaTime * 65;
                  //   print("Mouse moved down" + pos.y);

                }
                 if (Input.GetAxis("Mouse Y") > 1.5)//1
                 {
                     pos.y -= panSpeed * Time.deltaTime * 65;
                    // print("Mouse moved up" + pos.y);
                    
                }

                 pos.x = Mathf.Clamp(pos.x, -2.1f, +2.55f);
                 pos.y = Mathf.Clamp(pos.y, -1.5f, +0.8f);
                transform.position = pos;
             }

             
            
            //Pinch script start
            if (Input.touchCount == 2)
            {

                Touch firstTouch = Input.GetTouch(0);
                Touch secondTouch = Input.GetTouch(1);

                firstTouchPrevPos = firstTouch.position - firstTouch.deltaPosition;
                secondTouchPrevPos = secondTouch.position - secondTouch.deltaPosition;

                touchesPrevPosDifference = (firstTouchPrevPos - secondTouchPrevPos).magnitude;
                touchesCurPosDifference = (firstTouch.position - secondTouch.position).magnitude;

                zoomModifier = (firstTouch.deltaPosition - secondTouch.deltaPosition).magnitude * zoomModifierSpeed;

                if (touchesPrevPosDifference > touchesCurPosDifference)
                    mainCamera.orthographicSize += zoomModifier;
                if (touchesPrevPosDifference < touchesCurPosDifference)
                    mainCamera.orthographicSize -= zoomModifier;
                mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize, 2.30f, 5.3f);
                //mainCamera.transform.position = new Vector3(10f,0f,0f);
                text.text = "Camera size " + mainCamera.orthographicSize;
            }


            //transform.position = new Vector3(xpos, ypos, zpos);

        }
    }
    private void error(string msg)//console error print function
    {
        text.text = "\n --> " + msg;
    }
}
