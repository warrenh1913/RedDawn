using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;

    public GameObject shot;

    private int hitCooldown = 250;

    private Quaternion currentRotation;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hitPlayer();
    }

    bool hitPlayer(){

        // RaycastHit hit;

               

        if(seePlayer()){
            hitCooldown--;
            //
            if(hitCooldown <= 0){

                Vector3 temp = (player.transform.position - transform.position ).normalized;

                print("V rotation: " + temp);

                Debug.DrawRay(transform.position, temp * 50, Color.green, 50);

                // Quaternion temp2 = new Quaternion(0,0,0,0);
                // temp2.LookRotation(temp);

                Instantiate(shot,transform.position,Quaternion.LookRotation(temp));

                print("Q rotation: " + Quaternion.LookRotation(temp));
                hitCooldown = 200;
                //print("rotation for ball: " + Quaternion.LookRotation(temp));
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
