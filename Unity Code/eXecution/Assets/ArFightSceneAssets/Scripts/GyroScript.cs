using UnityEngine;
using System.Collections;

public class GyroScript : MonoBehaviour
{
    // STATE
    private float _initialYAngle = 0f;
    private float _appliedGyroYAngle = 0f;
    private float _calibrationYAngle = 0f;
    private Transform _rawGyroRotation;
    private float _tempSmoothing;

    // SETTINGS
    [SerializeField] private float _smoothing = 0.1f;

    private IEnumerator Start()
    {
        Input.gyro.enabled = true;
        Application.targetFrameRate = 60;
        _initialYAngle = transform.eulerAngles.y;

        _rawGyroRotation = new GameObject("GyroRaw").transform;
        _rawGyroRotation.parent = transform;
        _rawGyroRotation.position = transform.position;
        _rawGyroRotation.rotation = transform.rotation;

        // Wait until gyro is active, then calibrate to reset starting rotation.
        yield return new WaitForSeconds(1);

        StartCoroutine(CalibrateYAngle());
    }

    private void Update()
    {
        ApplyGyroRotation();
        ApplyCalibration();

        transform.rotation = Quaternion.Slerp(transform.rotation, _rawGyroRotation.rotation, _smoothing);
    }

    private IEnumerator CalibrateYAngle()
    {
        _tempSmoothing = _smoothing;
        _smoothing = 1;
        _calibrationYAngle = _appliedGyroYAngle - _initialYAngle; // Offsets the y angle in case it wasn't 0 at edit time.
        yield return null;
        _smoothing = _tempSmoothing;
    }

    private void ApplyGyroRotation()
    {
        _rawGyroRotation.rotation = Input.gyro.attitude;
        _rawGyroRotation.Rotate(0f, 0f, 180f, Space.Self); // Swap "handedness" of quaternion from gyro.
        _rawGyroRotation.Rotate(90f, 180f, 0f, Space.World); // Rotate to make sense as a camera pointing out the back of your device.
        _appliedGyroYAngle = _rawGyroRotation.eulerAngles.y; // Save the angle around y axis for use in calibration.
    }

    private void ApplyCalibration()
    {
        _rawGyroRotation.Rotate(0f, -_calibrationYAngle, 0f, Space.World); // Rotates y angle back however much it deviated when calibrationYAngle was saved.
    }

    public void SetEnabled(bool value)
    {
        enabled = true;
        StartCoroutine(CalibrateYAngle());
    }
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroScript : MonoBehaviour {
    public GameObject webPlane;
    GameObject camParent;
	// Use this for initialization
	void Start () {
       // camParent = new GameObject("CamParent");
        //camParent.transform.position = this.transform.position;
        //this.transform.parent = camParent.transform;
        //camParent.transform.Rotate(Vector3.right,90);
        Input.gyro.enabled = true;
        bool camAvailable;
        WebCamTexture backCam = null;

        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0) {
            print("No WebCamera Detected");
            camAvailable = false;
            return;
        }
        print("Cameras found are "+ devices[0].name);
        for (int i = 0; i < devices.Length; i++)
        {
            if (!devices[i].isFrontFacing)
            {
                backCam = new WebCamTexture(devices[i].name);
            }
        }

        if (backCam==null) {
            print("No Back cam found");
            return;
        }
        backCam.Play();
        webPlane.GetComponent<MeshRenderer>().material.mainTexture = backCam;
        camAvailable = true;
        if (camAvailable == true)
        {
            print("Camera found");
        }
    }

    // Update is called once per frame
    void Update () {
        Quaternion rotfix = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
        this.transform.localRotation = rotfix;

	}
}
*/
