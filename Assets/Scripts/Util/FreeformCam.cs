using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeformCam : MonoBehaviour
{

    public float sensitivity, moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Look();
    }

    void Move()
    {
        transform.Translate(InputVector() * moveSpeed * Time.fixedDeltaTime);
    }

    Vector3 InputVector()
    {
        Vector3 vec = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        vec += Vector3.up * (Input.GetKey(KeyCode.Space) ? 1 : 0);
        vec += Vector3.up * (Input.GetKey(KeyCode.LeftControl) ? -1 : 0);
        return vec;

    }

    float desiredX, xRotation, desiredZ;
    private void Look() {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.fixedDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.fixedDeltaTime;

        //Find current look rotation
        Vector3 rot = transform.localRotation.eulerAngles;
        desiredX = rot.y + mouseX;


        
        //Rotate, and also make sure we dont over- or under-rotate.
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Perform the rotations
        transform.localRotation = Quaternion.Euler(xRotation, desiredX, desiredZ);
    }
}
