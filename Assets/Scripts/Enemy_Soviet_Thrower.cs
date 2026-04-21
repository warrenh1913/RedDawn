using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Soviet_Thrower : MonoBehaviour{


    public GameObject camera;

    public GameObject player;

    public GameObject shot;

    private int hitCooldown = 250;

    private Quaternion currentRotation;

    
    void Start()
    {
        if(GetComponent<Camera>() == null){
            print("Enemy_SovietNormal Script is missing camera object reference ");
        }
        
        transform.parent.gameObject.transform.rotation = new Quaternion(0f,0f,0f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = (player.transform.position - transform.position ).normalized;
        rotation.y = 0;
        
        Vector3 tempVec = Quaternion.LookRotation(rotation,Vector3.up).eulerAngles;

        tempVec.z = 90f;
        tempVec.y += 90f;

        currentRotation = Quaternion.Euler(tempVec);
        transform.rotation = Quaternion.Euler(tempVec);
        //print("rotation for panel: " + transform.rotation);
        
        hitPlayer();
    }



     bool hitPlayer(){

        // RaycastHit hit;
        //print("deltaTime: " + Time.deltaTime);
        print("fixedDeltaTime: " + Time.fixedDeltaTime);

               

        if(seePlayer()){
            hitCooldown--;
            //print(hitCooldown);
            
            
            if(hitCooldown <= 0){

                

                

                //Quaternion temp2 = new Quaternion(temp.x,temp.y,temp.z,0);
                // temp2.LookRotation(temp);
                //
                Vector3 temp = (player.transform.position - transform.position ).normalized;

                Instantiate(shot,transform.position,Quaternion.LookRotation(temp));

                

                Debug.DrawRay(transform.position, temp * 50, Color.green, 50);

                hitCooldown = 200;

                // print("rotation for ball: " + Quaternion.LookRotation(temp));
            }
        }else{
            hitCooldown = 200;
        }
        

        //Instantiate(shot,transform.position,(player.transform.position - transform.position).normalized);


        
        

        
        return false;
    }

    bool seePlayer(){
    RaycastHit hit;
        //print(player.transform.eulerAngles);
        //print("player coords according to script ");
        // print(player.transform.position);
        
        //print("Height: " + objectBound.size.height);
        
       

        Vector3 temp = player.transform.position - transform.position;

        Physics.Raycast(transform.position,temp * 50 ,out hit, 50);
        
        
        //Debug.DrawRay(transform.position, temp * 50 * -1, Color.green, 50);
        if(hit.collider == null){
            return false;
        }else{
            return hit.collider.tag == "Player";
        }
    }


}
