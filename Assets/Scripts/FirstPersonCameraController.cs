using UnityEngine;

public class FirstPersonCameraController : MonoBehaviour
{
    public GameObject cam;
    private float xInput, yInput;

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Mouse X");
        yInput = -Input.GetAxis("Mouse Y");

        //Rotate Character
        transform.Rotate(transform.up, xInput);

        //Rotate Camera
        cam.transform.Rotate(new Vector3(yInput, 0, 0));
    }
}