using System.Collections;
using UnityEngine;

public class RotateOnTouch_oven : MonoBehaviour {

    public Camera mainCamera;
    float rotSpeed = 500f;
    public GameObject platform; // script rotate is attached to the platform
    public GameObject tool;
    public Animator anim;
    Transform start_transform;
    Vector3 start_position;
    rotateScript rotateflag;

    void Start()
    {
        rotateflag = platform.GetComponent<rotateScript>();
        anim.SetBool("animflag", true);
        start_transform = tool.transform;
       // anim = tool.GetComponent<Animator>();
        //anim.enabled = false;
    }

    public void reset()
    {
        platform.GetComponent<rotateScript>().enabled = true;
        if (rotateflag.enabled)
            rotateflag.enabled = true;
        mainCamera.fieldOfView = 60;
        //anim.SetBool("trigger_anim", false);
        float rot = rotSpeed * Mathf.Deg2Rad;
        //Debug.Log("rot: " + rot);
        //start_transform.ro
        //start_transform.position = Quaternion.Euler(90, 0, 0);
        tool.transform.localRotation = Quaternion.Euler(-90, 0, 0);
       // tool.transform.eulerAngles = new Vector3(-90, 0, 0);
        //tool.transform.rotation = Quaternion.Euler(-90, 0, 0);
        //start_transform.rotation = Quaternion.Euler(-90, 0, 0);// (90, 0, 0);// = new Vector3(90, 0, 0);
        //start_transform.Rotate(new Vector3(0, 0, 1), rot); //-- zrotation
        anim.SetBool("animflag", true);
    }

    public void clickleft()
    {
        if (rotateflag.enabled)
            rotateflag.enabled = false;
        //anim.SetBool("trigger_anim", false);
        float rot = rotSpeed * Mathf.Deg2Rad;
        Debug.Log("rot: " + rot);
        //start_transform.ro
        start_transform.Rotate(new Vector3(0,1,0), rot); //-- zrotation
        anim.SetBool("animflag", false);
    }

    public void clickright()
    {
        if (rotateflag.enabled)
            rotateflag.enabled = false;
        //anim.SetBool("animflag", false);
        float rot = rotSpeed * Mathf.Deg2Rad;
        start_transform.Rotate(new Vector3(0, 1, 0), -rot);
        anim.SetBool("animflag", false);
    }

    public void clickup()
    {
        if (rotateflag.enabled)
            rotateflag.enabled = false;
        anim.SetBool("animflag", false);
        //anim.SetBool("animflag", false);
        float rot = rotSpeed * Mathf.Deg2Rad;
        start_transform.Rotate(new Vector3(1, 0, 0), rot);
    }

    public void clickdown()
    {
        if (rotateflag.enabled)
            rotateflag.enabled = false;
        anim.SetBool("animflag", false);
        float rot = rotSpeed * Mathf.Deg2Rad;
        start_transform.Rotate(new Vector3(1, 0, 0), -rot);
    }
    /*void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;
       transform.RotateAround(transform.position, Vector3.up, -rotX);
        transform.RotateAround(transform.position, Vector3.right, -rotY);
        
    }*/
}
