using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slingShot : MonoBehaviour
{
    public Transform Projecitle;
    public Transform DrawFrom;
    public Transform DrawTo;
    public sling slingShotString;
    public int NrDrawIcrements=10;
    private Transform currentProjectile;
    private bool draw;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            DrawSlingShot(1);
        }
        if(Input.GetMouseButtonUp(0)){
            ReleaseAndShot(30);
        }
    }
    public void ReleaseAndShot(float shotForce){
        draw=false;
        currentProjectile.transform.parent=null;
        Rigidbody projecitleRigidBody =currentProjectile.GetComponent<Rigidbody>();
        projecitleRigidBody.AddForce(transform.forward*shotForce,ForceMode.Impulse);
        slingShotString.CenterPoint=DrawFrom;
    }
    public void DrawSlingShot(float speed){
        draw=true;
        currentProjectile=Instantiate(Projecitle,DrawFrom.position,Quaternion.identity,transform);
        slingShotString.CenterPoint=currentProjectile.transform;
        float waitTimeBetweenDraws=speed/NrDrawIcrements;
        StartCoroutine(DrawSlingShotWithIncrements(waitTimeBetweenDraws));
    }
    private IEnumerator DrawSlingShotWithIncrements(float waitTimeBetweenDraws){
        for(int i = 0; i < NrDrawIcrements; i++) {
            if(draw){
            currentProjectile.transform.position=Vector3.Lerp(DrawFrom.position,DrawTo.position,(float)i/NrDrawIcrements);
            yield return new WaitForSeconds(waitTimeBetweenDraws);}
            else{
                i=NrDrawIcrements;
            }
        }
    }
}
