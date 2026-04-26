using System.Collections;


//using System.Numerics;

using UnityEngine;

public class Move_To_Player : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;

    

    public int movementSpeed = 3;
    private float realSpeed;
    private Transform playerTransform;

    public int moveToRange = 0;

    public int sides = 1;

    private Vector3 lastPlayerPosition;

    
    

    private Enemy_Soviet_Normal panelScript;

    private RaycastHit checkLeft;
    private RaycastHit checkRight;
    private bool objectLeft = false;
    private bool objectRight = false;

    private float distanceToPlayer = 0f;

    public GameObject panel;

    private float width;

    private LayerMask wallMask;

    private LayerMask viewPlayerMask;

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

        width = panel.GetComponent<BoxCollider>().bounds.size.z;
        //width *= panel.transform.localScale.x;


        //print(panel.GetComponent<BoxCollider>().bounds.size);
        //print(width);
        
        if(width == null){
            print("width is null");
        }

         
        wallMask = LayerMask.GetMask("Wall");
        viewPlayerMask = LayerMask.GetMask("Wall","Player");
        
        
    }

    // Update is called once per frame
    void Update(){

        
        //right
        Physics.Raycast(panel.transform.position + panel.transform.right * width/2,panel.transform.right * sides,out checkRight,1f,wallMask);
        Debug.DrawRay(panel.transform.position + panel.transform.right * width/2,panel.transform.right * sides, Color.green, 25);

        //left
        Physics.Raycast(panel.transform.position - panel.transform.right * width/2,-panel.transform.right * sides,out checkLeft,1f,wallMask);
        Debug.DrawRay(panel.transform.position - panel.transform.right * width/2,panel.transform.right * -sides, Color.green, 25);

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
        lastPlayerPosition = new Vector3(0,0,0);

        playerTransform = player.GetComponent<Transform>();
        

        float comp = playerTransform.position.x - transform.position.x;

        



        //print("Player X: " + playerTransform.position.x + " Enemy X: " + transform.position.x);

        



        //float xPercent = 
        
//         if(playerTransform.position.x > transform.position.x){
//                 moveX = Time.fixedDeltaTime * realSpeed;
//             }else{
//                 moveX = Time.fixedDeltaTime * -realSpeed;
//             }
// 
//         
//             if(playerTransform.position.z > transform.position.z){
//             moveZ = Time.fixedDeltaTime * realSpeed;
//             }else{
//                 moveZ = Time.fixedDeltaTime * -realSpeed;
//             }

            //print(panel.transform.up);

            
            if(objectLeft && objectRight){
                print("both objects hit");
                transform.Translate(panel.transform.forward * Time.deltaTime * realSpeed,Space.Self);
            }else if(objectLeft){
                print("left object hit");
                transform.Translate(((panel.transform.forward + new Vector3(-panel.transform.forward.x,0,0)) + (panel.transform.right * .4f)) * Time.deltaTime * realSpeed,Space.Self);
            }else if(objectRight){
                print("right object hit");
                transform.Translate(((panel.transform.forward + new Vector3(-panel.transform.forward.x,0,0)) + (-panel.transform.right * .4f)) * Time.deltaTime * realSpeed,Space.Self);
            }else{
                print("no objects hit");
                transform.Translate(panel.transform.forward * Time.deltaTime * realSpeed,Space.Self);
            }
            lastPlayerPosition = player.transform.position;
            
            
            }else{
                if(lastPlayerPosition != new Vector3(0,0,0) && distanceToPlayer > moveToRange){

                    Vector3 toPlayer = (lastPlayerPosition - transform.position).normalized;
                    toPlayer.y = 0;


                    if(objectLeft && objectRight){
                    print("both objects hit");
                    transform.Translate(toPlayer * Time.deltaTime * realSpeed,Space.Self);
                    }else if(objectLeft){
                    print("left object hit");
                    transform.Translate(((toPlayer + new Vector3(-toPlayer.x,0,0)) + (toPlayer * .2f)) * Time.deltaTime * realSpeed,Space.Self);
                    }else if(objectRight){
                    print("right object hit");
                    transform.Translate(((toPlayer + new Vector3(-toPlayer.x,0,0)) + (-toPlayer * .2f)) * Time.deltaTime * realSpeed,Space.Self);
                    }else{
                    print("no objects hit");
                    transform.Translate(toPlayer * Time.deltaTime * realSpeed,Space.Self);
                    }

                    if(Vector3.Distance(lastPlayerPosition,transform.position) < 2f){
                    lastPlayerPosition = new Vector3(0,0,0);
                    }
                }
            }

            

        
        //print(moveX);
            
    
    }



    



    bool seePlayer(){
        RaycastHit hit;
        //print(player.transform.eulerAngles);
        //print("player coords according to script ");
        // print(player.transform.position);
        
        //print("Height: " + objectBound.size.height);
        
       

        Vector3 temp = player.transform.position - transform.position;

        Physics.Raycast(transform.position,temp * 50 ,out hit, 50,viewPlayerMask);
        
        //Debug.DrawRay(transform.position, temp * 50, Color.green, 50);
        if(hit.collider != null){
            distanceToPlayer = hit.distance;
        }
        if(hit.collider == null || distanceToPlayer < moveToRange){
            return false;
        }else{
            return hit.collider.tag == "Player";
        }
    }

    public void enemyDied(){
        Destroy(gameObject);
    }

    
}
