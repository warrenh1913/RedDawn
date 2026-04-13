using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Pistol : MonoBehaviour
{
    // Start is called before the first frame update
    // public GameObject player;

    private Transform gunPos;


    void Start()
    {
        // if(player == null){
        //     print("Error: player object not attached to Gun_Pistol Script");
        // }
        gunPos = GetComponent<Transform>();
        if(gunPos == null){
            print("fail");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shoot(){
//         Transform playerPos = player.GetComponent<Transform>();
// 
//         playerPos.Translate(playerPos.position.x / 2,playerPos.position.y,playerPos.position.z);
            
            //Vector3 gunRot = new Vector3(gunPos.rotation.x,gunPos.rotation.y,gunPos.rotation.z);
            //print("x position is " + gunPos.position.x + " y position is " + gunPos.position.y + " z position is " + gunPos.position.z);

            RaycastHit hit;
            print("Gun Fired");
            bool hitEnemy =  Physics.Raycast(transform.position, transform.forward * 50,out hit, 50f);
            Debug.DrawRay(transform.position, transform.forward * 50, Color.green, 10f);
            if(hitEnemy){
                print("hitEnemy");
            }
            if(hit.collider != null && hit.collider.tag == "enemy"){
                Destroy(hit.collider.gameObject);
            }



    }
}
