using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Pistol : MonoBehaviour
{
    // Start is called before the first frame update
    // public GameObject player;

    private Transform gunPos;

    float timePassed = 0f;
    private int repeatFire = 0;

    int pistolAmmo = 15;
    int shotgunAmmo = 5;
    int machinegunAmmo = 25;

    private float pistolCooldown = 0.5f;
    private float shotgunCooldown = 0.7f;
    private float machinegunCooldown = .2f;
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
        timePassed += Time.deltaTime;
        
    }

    public bool checkAmmo(char gunType){
        if(gunType == 'p'){
            return pistolAmmo > 1;
        }else if(gunType == 's'){
            return shotgunAmmo > 1;
        }else if(gunType == 'm'){
            return machinegunAmmo > 1;
        }else{ 
            return false;
        }
    }

    public void shootPistol(){
//         Transform playerPos = player.GetComponent<Transform>();
// 
//         playerPos.Translate(playerPos.position.x / 2,playerPos.position.y,playerPos.position.z);
            
            //Vector3 gunRot = new Vector3(gunPos.rotation.x,gunPos.rotation.y,gunPos.rotation.z);
            //print("x position is " + gunPos.position.x + " y position is " + gunPos.position.y + " z position is " + gunPos.position.z);

            if(pistolCooldown > timePassed){
            return;
            }

            RaycastHit hit;
            
            bool hitEnemy =  Physics.Raycast(transform.position, transform.forward * 50,out hit, 50f);
            Debug.DrawRay(transform.position, transform.forward * 50, Color.green, 10f);
            if(hitEnemy){
                print("hitEnemy");
            }
            if(hit.collider != null && hit.collider.tag == "enemy"){
                Destroy(hit.collider.gameObject);
            }
            timePassed = 0f;



    }

    public void shootShotgun(){
//         Transform playerPos = player.GetComponent<Transform>();
// 
//         playerPos.Translate(playerPos.position.x / 2,playerPos.position.y,playerPos.position.z);
            
            //Vector3 gunRot = new Vector3(gunPos.rotation.x,gunPos.rotation.y,gunPos.rotation.z);
            //print("x position is " + gunPos.position.x + " y position is " + gunPos.position.y + " z position is " + gunPos.position.z);

            if(shotgunCooldown > timePassed){
            return;
            }

            ArrayList raycasts = new ArrayList();
            float problemX = 0;
            



            //print("transform forward is: " + transform.forward * 10);
                // if(realX > 1){
                //     realX -= 1;
                // }else if(realX < -1){
                //     realX += 1;
                // }
                // 
                // float realX = (transform.forward.x * 10);
                // float realY = (transform.forward.y * 10) + Random.Range(-2f,2f);
                // float realZ = (transform.forward.z * 10) + tempZ;
            
            for(int i = 0; i < 9; i++){
                RaycastHit hit;

                
                
                float tempX = Random.Range(-.2f,.2f);
                

                Vector3 vecX = transform.forward + transform.right * Random.Range(-.25f,.25f);
                //Vector3 vecY = 
                Vector3 findRot = vecX.normalized;
                

                Physics.Raycast(transform.position, findRot ,out hit,10f);
                Debug.DrawRay(transform.position, findRot * 10f , Color.green, 10f);
                
                // Physics.Raycast(transform.position, new Vector3(realX,realY,realZ).normalized ,out hit, 10f);
                // Debug.DrawRay(transform.position, new Vector3(realX,realY,realZ) , Color.green, 10f);

                if(hit.collider != null && hit.collider.tag == "enemy"){
                    Destroy(hit.collider.gameObject);
                }
                timePassed = 0f;

            }
            //print("average x for random = " + problemX / 9);
            
            

            
            



    }

    public void shootMachinegun(bool repeat){

        if(machinegunCooldown > timePassed){
            return;
        }
        
        if(repeat){
            repeatFire++;
            
        }else{
            repeatFire = 0;
        }

        RaycastHit hit;
        if(repeatFire > 4){
            float temp1 = Mathf.Max(-.15f,-repeatFire/100f); float temp2 = Mathf.Min(.15f,repeatFire/100f);
            Vector3 recoil = transform.right * Random.Range(temp1,temp2);

            
            Vector3 vecX = transform.forward + (recoil);

            bool hitEnemy =  Physics.Raycast(transform.position, vecX.normalized ,out hit, 40f);
            Debug.DrawRay(transform.position, vecX * 40, Color.green, 10f);
        }else{
            bool hitEnemy =  Physics.Raycast(transform.position, (transform.forward),out hit, 50f);
            Debug.DrawRay(transform.position, transform.forward * 50, Color.green, 10f);
        }

        if(hit.collider != null && hit.collider.tag == "enemy"){
                Destroy(hit.collider.gameObject);
            }
            timePassed = 0f;
        

    }
}
