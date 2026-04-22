using System.Collections;
using System.Collections.Generic;
//using System.Numerics;

using UnityEngine;

public class Move_To_Player : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;

    

    public int movementSpeed = 3;
    private float realSpeed;
    private Transform playerTransform;

    public int moveToRange = 50;

    
    

    private Enemy_Soviet_Normal panelScript;

    private RaycastHit checkLeft;
    private RaycastHit checkRight;
    private bool objectLeft = false;
    private bool objectRight = false;

    public GameObject panel;

    private float width;
    void Start(){
        if(player == null){
            print("Move_To_Player Script is missing player reference");
        }
        
        realSpeed = movementSpeed ;
        playerTransform = player.GetComponent<Transform>();

        

        if(panel == null){
            print("Move_To_Player Script is missing panel reference");
        }

        panelScript = panel.GetComponent<Enemy_Soviet_Normal>();

        width = panel.GetComponent<MeshFilter>().sharedMesh.bounds.size.z;
        width *= panel.transform.localScale.z;
        
        if(width == null){
            print("width is null");
        }
        
        
    }

    // Update is called once per frame
    void Update(){

        LayerMask mask = LayerMask.GetMask("Wall");
        //right
        Physics.Raycast(panel.transform.position + panel.transform.forward * width/2,panel.transform.forward,out checkRight,1f,mask);
        Debug.DrawRay(panel.transform.position + panel.transform.forward * width/2,panel.transform.forward * 1, Color.green, 25);

        //left
        Physics.Raycast(panel.transform.position - panel.transform.forward * width/2,-panel.transform.forward,out checkLeft,1f,mask);
        Debug.DrawRay(panel.transform.position - panel.transform.forward * width/2,panel.transform.forward * -1, Color.green, 25);

        if(checkLeft.collider != null){
            objectLeft = true;
            print("object left");
        }else{
            objectLeft = false;
        }


        if(checkRight.collider != null){
            objectRight = true;
            print("object right");
        }else{
            objectRight = false;
        }
        
        if(seePlayer()){
        //print("can see players");
        playerTransform = player.GetComponent<Transform>();
        float moveX; float moveZ;

        float comp = playerTransform.position.x - transform.position.x;

        



        //print("Player X: " + playerTransform.position.x + " Enemy X: " + transform.position.x);

        float xDist = Mathf.Abs(transform.position.x) - Mathf.Abs(playerTransform.position.x);
        float zDist = transform.position.z - playerTransform.position.z;



        //float xPercent = 
        
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

            //print(panel.transform.up);

            
            if(objectLeft && objectRight){
                print("both objects hit");
                transform.Translate(panel.transform.up * Time.fixedDeltaTime * realSpeed,Space.Self);
            }else if(objectLeft){
                print("left object hit");
                transform.Translate(((panel.transform.up + new Vector3(-panel.transform.up.x,0,0)) + (panel.transform.forward * .2f)) * Time.fixedDeltaTime * realSpeed,Space.Self);
            }else if(objectRight){
                print("right object hit");
                transform.Translate(((panel.transform.up + new Vector3(-panel.transform.up.x,0,0)) + (-panel.transform.forward * .2f)) * Time.fixedDeltaTime * realSpeed,Space.Self);
            }else{
                print("no objects hit");
                transform.Translate(panel.transform.up * Time.fixedDeltaTime * realSpeed,Space.Self);
            }
            
            
            }else{
                //print("cannot see player");
            }

            

        
        //print(moveX);
            
    
    }

//     void OnDrawGizmos(){
//         Gizmos.color = Color.red;
// 
//         Gizmos.matrix = panel.transform.localToWorldMatrix;
// 
//         //print(panel.transform.localToWorldMatrix);
//         //print(panel.GetComponent<MeshFilter>().sharedMesh.bounds.size);
//         if(Application.isPlaying){
//             Gizmos.DrawWireCube(Vector3.zero, new Vector3(10,.1f,10));
//         }
//     }

    ArrayList futurePosition(){


        

        return null;
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

        
        if(hit.collider == null || hit.distance < moveToRange){
            return false;
        }else{
            return hit.collider.tag == "Player";
        }
    }

    
}
