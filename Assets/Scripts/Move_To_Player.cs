using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_To_Player : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;

    public GameObject camera;

    public int movementSpeed = 3;
    private float realSpeed;
    private Transform playerTransform;
    

    private Enemy_Soviet_Normal panelScript;
    void Start(){
        if(player == null){
            print("Move_To_Player Script is missing player reference");
        } 
        realSpeed = movementSpeed * 0.4f;
        playerTransform = player.GetComponent<Transform>();
        panelScript = transform.Find("Panel").GetComponent<Enemy_Soviet_Normal>();
    }

    // Update is called once per frame
    void Update(){
        
        
        if(seePlayer()){
        print("can see players");
        playerTransform = player.GetComponent<Transform>();
        float moveX; float moveZ;

        float comp = playerTransform.position.x - transform.position.x;
        //print("Player X: " + playerTransform.position.x + " Enemy X: " + transform.position.x);
        if(playerTransform.position.x > transform.position.x){
                moveX = Time.fixedDeltaTime * realSpeed;
            }else{
                moveX = Time.fixedDeltaTime * -realSpeed;
            }

        
            if(playerTransform.position.z > transform.position.z){
            moveZ = Time.fixedDeltaTime * realSpeed;
            }else{
                moveZ = Time.fixedDeltaTime * -realSpeed;
            }
            transform.Translate(new Vector3(moveX,0,moveZ));
            
            
            
            }else{
                print("cannot see player");
            }

        
        //print(moveX);
            
    
    }



    bool seePlayer(){
        RaycastHit hit;
        //print(player.transform.eulerAngles);
        //print("player coords according to script ");
        // print(player.transform.position);
        
        print("actual cords " + camera.transform.eulerAngles.y + 90);

        Vector3 temp = new Vector3(transform.position.x - player.transform.position.x, transform.position.y - player.transform.position.y,transform.position.z - player.transform.position.z).normalized;

        Physics.Raycast(transform.position,temp * 50 * -1,out hit, 50);
        
        //Debug.DrawRay(transform.position, temp * 50 * -1, Color.green, 50);
        if(hit.collider == null){
            return false;
        }else{
            return hit.collider.tag == "Player";
        }
    }
}
