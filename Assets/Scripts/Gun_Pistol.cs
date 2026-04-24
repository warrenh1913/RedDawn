/**
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Pistol : MonoBehaviour
{
    // Start is called before the first frame update
    // public GameObject player;

    public Gun_Visuals gunVisuals;
    private Transform gunPos;

    public GameObject bloodSplat;

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
            Vector3 temp = (transform.position - hit.collider.transform.position).normalized;

            Instantiate(bloodSplat,hit.point,Quaternion.LookRotation(temp));
            }else if(hit.collider.tag == "projectile"){
                Destroy(hit.collider.gameObject);
            }
        }
        
        pistolAmmo--;
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
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Pistol : MonoBehaviour
{
    public Gun_Visuals gunVisuals;
    private Transform gunPos;

    float timePassed = 0f;
    private int repeatFire = 0;

    int pistolAmmo = 15;
    int shotgunAmmo = 5;
    int machinegunAmmo = 25;

    public GameObject bloodSplat;

    private float pistolCooldown = 0.5f;
    private float shotgunCooldown = 0.7f;
    private float machinegunCooldown = 0.2f;

    void Start()
    {
        gunPos = GetComponent<Transform>();
        if (gunPos == null)
        {
            print("fail");
        }
    }

    void Update()
    {
        timePassed += Time.deltaTime;
    }

    public bool checkAmmo(char gunType)
    {
        if (gunType == 'p')
        {
            return pistolAmmo > 0; // CHANGED: was > 1
        }
        else if (gunType == 's')
        {
            return shotgunAmmo > 0; // CHANGED: was > 1
        }
        else if (gunType == 'm')
        {
            return machinegunAmmo > 0; // CHANGED: was > 1
        }
        else
        {
            return false;
        }
    }

    // CHANGED: added pistol ammo pickup support
    public void AddPistolAmmo(int amount)
    {
        pistolAmmo += amount;
    }

    // CHANGED: added shotgun ammo pickup support
    public void AddShotgunAmmo(int amount)
    {
        shotgunAmmo += amount;
    }

    // CHANGED: added machine gun ammo pickup support
    public void AddMachinegunAmmo(int amount)
    {
        machinegunAmmo += amount;
    }

    // CHANGED: added getters so UI or other scripts can read ammo
    public int GetPistolAmmo()
    {
        return pistolAmmo;
    }

    public int GetShotgunAmmo()
    {
        return shotgunAmmo;
    }

    public int GetMachinegunAmmo()
    {
        return machinegunAmmo;
    }

    public void shootPistol()
    {
        if (pistolCooldown > timePassed)
        {
            return;
        }

        // CHANGED: stop shooting if no pistol ammo
        if (!checkAmmo('p'))
        {
            return;
        }

        if (gunVisuals != null) gunVisuals.PlayPistolEffects();

        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward * 50, out hit, 50f);
        Debug.DrawRay(transform.position, transform.forward * 50, Color.green, 10f);

        if(hit.collider != null){
            if(hit.collider.tag == "enemy"){
            hit.collider.gameObject.GetComponent<Hit_Enemy>().hitEnemy(25);
            Vector3 temp = (transform.position - hit.collider.transform.position).normalized;

            Instantiate(bloodSplat,hit.point,Quaternion.LookRotation(temp));
            }else if(hit.collider.tag == "projectile"){
                Destroy(hit.collider.gameObject);
            }
        }

        pistolAmmo--; // CHANGED: this was commented out before
        timePassed = 0f;
    }

    public void shootShotgun()
    {
        if (shotgunCooldown > timePassed)
        {
            return;
        }

        // CHANGED: stop shooting if no shotgun ammo
        if (!checkAmmo('s'))
        {
            return;
        }

        if (gunVisuals != null) gunVisuals.PlayShotgunEffects();

        for (int i = 0; i < 9; i++)
        {
            RaycastHit hit;

            Vector3 vecX = transform.forward + transform.right * Random.Range(-.25f, .25f);
            Vector3 findRot = vecX.normalized;

            Physics.Raycast(transform.position, findRot, out hit, 10f);
            Debug.DrawRay(transform.position, findRot * 10f, Color.green, 10f);

            if(hit.collider != null){
            if(hit.collider.tag == "enemy"){
            hit.collider.gameObject.GetComponent<Hit_Enemy>().hitEnemy(10);
            Vector3 temp = (transform.position - hit.collider.transform.position).normalized;

            Instantiate(bloodSplat,hit.point,Quaternion.LookRotation(temp));
            }else if(hit.collider.tag == "projectile"){
                Destroy(hit.collider.gameObject);
            }
        }
        }

        shotgunAmmo--; // CHANGED: this was commented out before
        timePassed = 0f;
    }

    public void shootMachinegun(int repeatFire)
    {
        if (machinegunCooldown > timePassed)
        {
            return;
        }

        // CHANGED: stop shooting if no machine gun ammo
        if (!checkAmmo('m'))
        {
            return;
        }

        if (gunVisuals != null) gunVisuals.PlayMachinegunEffects();

        

        RaycastHit hit;

        if (repeatFire > 4)
        {
            float temp1 = Mathf.Max(-.10f, -repeatFire / 100f);
            float temp2 = Mathf.Min(.10f, repeatFire / 100f);
            Vector3 recoil = transform.right * Random.Range(temp1, temp2);

            Vector3 vecX = transform.forward + recoil;

            Physics.Raycast(transform.position, vecX.normalized, out hit, 40f);
            Debug.DrawRay(transform.position, vecX * 40, Color.green, 10f);
        }
        else
        {
            Physics.Raycast(transform.position, transform.forward, out hit, 50f);
            Debug.DrawRay(transform.position, transform.forward * 50, Color.green, 10f);
        }

        if(hit.collider != null){
            if(hit.collider.tag == "enemy"){
            hit.collider.gameObject.GetComponent<Hit_Enemy>().hitEnemy(15);
            Vector3 temp = (transform.position - hit.collider.transform.position).normalized;

            Instantiate(bloodSplat,hit.point,Quaternion.LookRotation(temp));
            }else if(hit.collider.tag == "projectile"){
                Destroy(hit.collider.gameObject);
            }
        }

        machinegunAmmo--; // CHANGED: this was commented out before
        timePassed = 0f;
    }
}
