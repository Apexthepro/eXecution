
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
    float zoomModifierSpeed = 0.1f;

    [SerializeField]
    Text text;//pan script end

    //swipe script start
    public float minSwipeDistY;
    public float panSpeed = 0.01f;
    public float minSwipeDistX;
    public float xpos;
    public float ypos;
    public float zpos;
    private Vector2 startPos;//swipe script end
    public UiCanvasScript UiCanvasScript;
    // Use this for initialization
    void Start()
    {
        //xpos = transform.position.x;
        //ypos = transform.position.y;
        //zpos = transform.position.z;
        mainCamera = GetComponent<Camera>();
        //transform.position = new Vector3(xpos,ypos , zpos);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pos = transform.position;
        //swipe script start
        if (UiCanvasScript.activeMenus == null)
        {
            if (Input.touchCount == 1)
            {
                print("MouseX" + Input.GetAxis("Mouse X"));

                if (Input.GetAxis("Mouse X") < -1)
                {
                    pos.x += panSpeed * (Time.deltaTime / 3);
                    print("Mouse moved left" + pos.x);
                }
                if (Input.GetAxis("Mouse X") > 1)
                {
                    pos.x -= panSpeed * (Time.deltaTime / 3);
                    print("Mouse moved left" + pos.x);
                }
                if (Input.GetAxis("Mouse Y") < -1)
                {
                    pos.y += panSpeed * (Time.deltaTime / 3);
                    print("Mouse moved down" + pos.y);
                }
                if (Input.GetAxis("Mouse Y") > 1)
                {
                    pos.y -= panSpeed * (Time.deltaTime / 3);
                    print("Mouse moved up" + pos.y);
                }

                pos.x = Mathf.Clamp(pos.x, -3f, +3f);
                pos.y = Mathf.Clamp(pos.y, -3f, +3f);
                transform.position = pos;
            }
            /*
            if (Input.GetMouseButtonDown(0))//enter if touch detected
            {
                Vector3 pos = transform.position;
                Touch touch = Input.touches[0];
                error("Touch detected");
                startPos = touch.position;

                if(Input.m)
                    case TouchPhase.Moved:
                        float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
                        error("pos.x "+ pos.x);
                        float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
                        if (swipeDistVertical > 1f)

                        {

                            if (swipeValue > 0)//up swipe
                                pos.y -= panSpeed * Time.deltaTime;
                            else if (swipeValue < 0)//down swipe
                                pos.y += panSpeed * Time.deltaTime;
                        }
                        float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
                        error("posx " + pos.x);
                        if (swipeDistHorizontal > minSwipeDistX)

                        {

                            swipeValue = Mathf.Sign(touch.position.x - startPos.x);
                            if (swipeValue > 0)//right swipe
                                pos.x += panSpeed * Time.deltaTime;
                            else if (swipeValue < 0)//left swipe
                                pos.x -= panSpeed * Time.deltaTime;
                        }
                        pos.x = Mathf.Clamp(pos.x, -3f, +3f);
                        pos.y = Mathf.Clamp(pos.y, -3f, +3f);
                        transform.position = pos;
                        break;
                }
            }
            */


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
                mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize, 2.5f, 8f);
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
