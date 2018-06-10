using UnityEngine;

public class PlayerExample1 : MonoBehaviour {

    public float moveSpeed;
    public Joystick joystick;
    public GameObject Hero;
    private float xAxis;
    private float yAxis;
    private float zAxis;
    private float wAxis;
    public GameObject arbackground;
    void Update()
    {
        Vector3 moveVector = (transform.right * joystick.Horizontal + transform.forward * joystick.Vertical).normalized;
        transform.Translate(moveVector * moveSpeed * Time.deltaTime);
        Hero.transform.position = transform.position + new Vector3(-0.28f, -6.9f, +1.11f);
        xAxis = transform.rotation.x;
        yAxis = transform.rotation.y;
        zAxis = transform.rotation.z;
        wAxis = transform.rotation.w;
        zAxis = Mathf.Clamp(zAxis, -0.1f, +0.1f);
       // print(new Quaternion(xAxis, yAxis, zAxis, wAxis));
        Hero.transform.rotation = new Quaternion(xAxis, yAxis, zAxis, wAxis);

    }
}