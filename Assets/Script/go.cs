using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class go : MonoBehaviour
{

    // Update is called once per frame
    void Update(){
        if(Input.GetKey("q")){
			transform.Translate(-0.2f,0,0);
		}
		if(Input.GetKey("e")){
			transform.Translate(0.2f,0,0);
		}
    }
   
}
