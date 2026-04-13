using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_To_Player : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;

    public int movementSpeed = 3;
    private float realSpeed;
    private Transform playerTransform;

    private Enemy_SovietNormal panelScript;
    void Start(){
        if(player == null){
            print("Move_To_Player Script is missing player reference");
        } 
        realSpeed = movementSpeed; //* 0.1f;
        playerTransform = player.GetComponent<Transform>();
        panelScript = transform.Find("Panel").GetComponent<Enemy_SovietNormal>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(true){//seePlayer()){

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

        
        //print(moveX);
        transform.Translate(new Vector3(moveX,0,moveZ));
        }
    }

    // bool seePlayer(){
    //     RaycastHit hit;
    //     print(player.transform.position);
    //     Physics.Raycast(transform.position,transform.InverseRotation,out hit, 50);
    //     
    //     Debug.DrawRay(transform.position, player.transform.position, Color.green, 50);
    //     if(hit.collider == null){
    //         return false;
    //     }else{
    //         return hit.collider.tag == "Player";
    //     }
    // }
}
