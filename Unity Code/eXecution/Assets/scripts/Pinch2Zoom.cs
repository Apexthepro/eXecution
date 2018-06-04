
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
    float zoomModifierSpeed = 0.001f;

    [SerializeField]
    Text text;//pan script end

    //swipe script start
    public float minSwipeDistY;
    public float panSpeed = 0.1f;
    public float minSwipeDistX;
    public float xpos;
    public float ypos;
    public float zpos;
    private Vector2 startPos;//swipe script end
    Vector3 pos;
    public UiCanvasScript UiCanvasScript;
    // Use this for initialization



    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered
    void Start()
    {
        //xpos = transform.position.x;
        //ypos = transform.position.y;
        //zpos = transform.position.z;
        mainCamera = GetComponent<Camera>();
        dragDistance = Screen.height * 5 / 100; //dragDistance is 15% height of the screen
        //transform.position = new Vector3(xpos,ypos , zpos);
    }

    // Update is called once per frame
    void Update()
    {
        
        //swipe script start
        if (UiCanvasScript.activeMenus == null)
        {
            /* if (Input.touchCount == 1 || Input.GetMouseButtonDown(0))
             {
                 print("MouseX" + Input.GetAxis("Mouse X"));

                 if (Input.GetAxis("Mouse X") < 0)//-1
                 {
                     pos.x += panSpeed * (Time.deltaTime / 3);
                     print("Mouse moved left" + pos.x);
                 }
                 if (Input.GetAxis("Mouse X") > 0)//1
                 {
                     pos.x -= panSpeed * (Time.deltaTime / 3);
                     print("Mouse moved left" + pos.x);
                 }
                 if (Input.GetAxis("Mouse Y") < 0)//-1
                 {
                     pos.y += panSpeed * (Time.deltaTime / 3);
                     print("Mouse moved down" + pos.y);
                 }
                 if (Input.GetAxis("Mouse Y") > 0)//1
                 {
                     pos.y -= panSpeed * (Time.deltaTime / 3);
                     print("Mouse moved up" + pos.y);
                 }

                 pos.x = Mathf.Clamp(pos.x, -3f, +3f);
                 pos.y = Mathf.Clamp(pos.y, -3f, +3f);
                 transform.position = pos;
             }

             */
            if (Input.touchCount == 1) // user is touching the screen with a single touch
            {
                Touch touch = Input.GetTouch(0); // get the touch
                if (touch.phase == TouchPhase.Began) //check for the first touch
                {
                    fp = touch.position;
                    lp = touch.position;
                }
                else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
                {
                    pos = transform.position;
                    lp = touch.position;
                    //Check if drag distance is greater than 20% of the screen height
                    error("posx"+pos.x);
                    if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                    {//It's a drag
                     //check if the drag is vertical or horizontal
                        if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                        {   //If the horizontal movement is greater than the vertical movement...
                            if ((lp.x > fp.x))  //If the movement was to the right)
                            {   //Right swipe
                                pos.x -= panSpeed * (Time.deltaTime / 3);
                                error("Right Swipe");
                            }
                            else
                            {   //Left swipe
                                pos.x += panSpeed * (Time.deltaTime / 3);
                                error("Left Swipe");
                            }
                        }
                        else
                        {   //the vertical movement is greater than the horizontal movement
                            if (lp.y > fp.y)  //If the movement was up
                            {   //Up swipe
                                pos.y -= panSpeed * (Time.deltaTime / 3);
                                error("Up Swipe");
                            }
                            else
                            {   //Down swipe
                                pos.y += panSpeed * (Time.deltaTime / 3);
                                error("Down Swipe");
                            }
                        }
                        pos.x = Mathf.Clamp(pos.x, -30f, +30f);
                        pos.y = Mathf.Clamp(pos.y, -30f, +30f);
                        transform.position = pos;
                    }
                    else
                    {   //It's a tap as the drag distance is less than 20% of the screen height
                        error("Tap");
                    }
                }
                else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
                {
                    lp = touch.position;  //last touch position. Ommitted if you use list

                   
                }
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
