using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Pistol : MonoBehaviour
{
    // Start is called before the first frame update
    // public GameObject player;

    public Gun_Visuals gunVisuals;
    private Transform gunPos;

    float timePassed = 0f;
    

    int pistolAmmo = 15;
    int shotgunAmmo = 5;
    int machinegunAmmo = 25;

    private float pistolCooldown = 0.5f;
    private float shotgunCooldown = 0.7f;
    private float machinegunCooldown = 0.2f;

    //private LayerMask enemyMask();
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
       if(gunVisuals != null) gunVisuals.PlayPistolEffects();

        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward * 50, out hit, 50f);
        Debug.DrawRay(transform.position, transform.forward * 50, Color.green, 10f);
        
        if(hit.collider != null){
            if(hit.collider.tag == "enemy"){
            hit.collider.gameObject.GetComponent<Hit_Enemy>().hitEnemy(25);
            }else if(hit.collider.tag == "projectile"){
                Destroy(hit.collider.gameObject);
            }
        }
        
        //pistolAmmo--;
        timePassed = 0f;
    }

    public void shootShotgun(){
    if(shotgunCooldown > timePassed){
            return;
        }

    if(gunVisuals != null) gunVisuals.PlayShotgunEffects();

        for(int i = 0; i < 9; i++){
            RaycastHit hit;
            
            Vector3 vecX = transform.forward + transform.right * Random.Range(-.25f,.25f);
            Vector3 findRot = vecX.normalized;
            
            Physics.Raycast(transform.position, findRot, out hit, 10f);
            Debug.DrawRay(transform.position, findRot * 10f, Color.green, 10f);
            
            if(hit.collider != null){
                if(hit.collider.tag == "enemy"){
                hit.collider.gameObject.GetComponent<Hit_Enemy>().hitEnemy(7);
                }else if(hit.collider.tag == "projectile"){
                Destroy(hit.collider.gameObject);
            }
            }
        }
        
        //shotgunAmmo--;
        timePassed = 0f;
    }

   public void shootMachinegun(int repeat){
        if(machinegunCooldown > timePassed){
            return;
        }

        if(gunVisuals != null) gunVisuals.PlayMachinegunEffects();
        

        RaycastHit hit;
        
        if(repeat > 4){
            float temp1 = Mathf.Max(-.115f,-repeat/100f); float temp2 = Mathf.Min(.115f,repeat/100f);
            Vector3 recoil = transform.right * Random.Range(temp1,temp2);

            
            Vector3 vecX = transform.forward + (recoil);

            bool hitEnemy =  Physics.Raycast(transform.position, vecX.normalized ,out hit, 40f);
            Debug.DrawRay(transform.position, vecX * 40, Color.green, 10f);
        }else{
            Physics.Raycast(transform.position, transform.forward, out hit, 50f);
            Debug.DrawRay(transform.position, transform.forward * 50, Color.green, 10f);
        }

        if(hit.collider != null){
            if(hit.collider.tag == "enemy"){
            hit.collider.gameObject.GetComponent<Hit_Enemy>().hitEnemy(20);
            }else if(hit.collider.tag == "projectile"){
                Destroy(hit.collider.gameObject);
            }
        }
        
        //machinegunAmmo--;
        timePassed = 0f;
    }
}
