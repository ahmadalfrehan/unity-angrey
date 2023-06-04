using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour {
      
    public Rigidbody B;
    public float power=200f;
    public float speed =4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        float h=Input.GetAxis("Horizontal")*Time.deltaTime*speed;
        float v=Input.GetAxis("Vertical")*Time.deltaTime*speed;
        transform.Translate(h,v,0);
        if(Input.GetButtonUp("Fire1")){
            Rigidbody x=(Rigidbody)Instantiate(B,transform.position,transform.rotation); 
            Vector3 fw=transform.TransformDirection(Vector3.forward);
            x.AddForce(fw*power);
        }
    }
}
