using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Soviet_Thrower : MonoBehaviour{

    public AudioSource hitSound;
    public AudioSource deathSound;

    public GameObject player;

    public GameObject shot;

    private float hitCooldown = 1.75f;

    private Quaternion currentRotation;

    private float timePassed = 0f;

    private int health = 100;

    
    void Start()
    {
    
        
        transform.parent.gameObject.transform.rotation = new Quaternion(0f,0f,0f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        Vector3 rotation = (player.transform.position - transform.position ).normalized;
        rotation.y = 0;
        
        Vector3 tempVec = Quaternion.LookRotation(rotation,Vector3.up).eulerAngles;

        

        currentRotation = Quaternion.Euler(tempVec);
        transform.rotation = Quaternion.Euler(tempVec);
        //print("rotation for panel: " + transform.rotation);
        
        hitPlayer();
    }



     bool hitPlayer(){

        // RaycastHit hit;
        //print("deltaTime: " + Time.deltaTime);

               

        if(seePlayer()){
            
            //print(hitCooldown);
            
            
            if(timePassed >= hitCooldown){

                

                

                //Quaternion temp2 = new Quaternion(temp.x,temp.y,temp.z,0);
                // temp2.LookRotation(temp);
                //
                
                Vector3 temp = (player.transform.position - transform.position ).normalized;

                Instantiate(shot,transform.position,Quaternion.LookRotation(temp));

                

                Debug.DrawRay(transform.position, temp * 50, Color.green, 50);

                timePassed = 0;

                // print("rotation for ball: " + Quaternion.LookRotation(temp));
            }
        }else{
            timePassed = 0;
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

    void takeDamage(int damage){
        health -= damage;
    }

    int getHealth(){
        return health;
    }

}
