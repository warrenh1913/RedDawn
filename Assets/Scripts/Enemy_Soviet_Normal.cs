using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Soviet_Normal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject camera;

    public GameObject player;
     
    void Start()
    {
        if(camera == null){
            print("Enemy_SovietNormal Script is missing camera object reference ");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // transform.Rotate(new Vector3(camera.transform.rotation.y * 360,0f,0f));
        //transform.LookAt(camera.transform,Vector3.left);
        transform.localEulerAngles = new Vector3(0f,camera.transform.eulerAngles.y - 90,90f);
        //transform.Rotate(new Vector3(Time.deltaTime * 10,0f,0f));
        // can see player
        
        
    }

    // public bool seePlayer(){
    //     
    // }

    // void OnTriggerEnter(Collider other){
    //     print("hit");
    //     Destroy(gameObject);
    // }
}
