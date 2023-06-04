using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Look : MonoBehaviour
{
    public enum RotationAxes {MouseXAndY=0,MouseX=1,MouseY=2}
    public RotationAxes axes =RotationAxes.MouseXAndY;
    public float sensitivityX =15f;
    public float sensitivityY =15f;
    public float minimumX =-180f;
    public float maximumX =180f;
    public float minimumY =-60f;
    public float maximumY =60f;
           float rotationY=0f;
   


    // Update is called once per frame
    void Update()
    {
        if(axes==RotationAxes.MouseXAndY) {
            float rotationX=transform.localEulerAngles.x+Input.GetAxis("Mouse X")*sensitivityX;
            rotationY+=Input.GetAxis("Mouse Y")*sensitivityY;
            rotationY=Mathf.Clamp(rotationY,minimumY,maximumY);
            transform.localEulerAngles =new Vector3 (-rotationY,0,0);
            
        }
        else if(axes==RotationAxes.MouseX)
        {
            transform.Rotate(0,Input.GetAxis("Mouse X")*sensitivityX,0);
        }
        else{
            rotationY+=Input.GetAxis("Mouse Y")*sensitivityY;
            rotationY=Mathf.Clamp(rotationY,minimumY,maximumY);
            transform.localEulerAngles =new Vector3 (-rotationY,transform.localEulerAngles.y,0);
        }
    }
        // Start is called before the first frame update
    void Start()
    {
       /* if(rigidbody)
        rigidbody.freezeRotation=true;*/
    }
}
