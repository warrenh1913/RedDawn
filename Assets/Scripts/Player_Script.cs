using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Script : MonoBehaviour
{
    
    
    int health = 100;
    
    
    private char gunEquipped = 'p';

    public GameObject screen;
    public GameObject playerGun;
    public Gun_Model gunModel;


    public AudioSource playerHit;

    public Gun_Visuals gunVisuals;
    
    public Text weaponText;

    private bool playPlayerHit = false;

    private int machinegunCount = 0;

    private Animator canvasAnimator;

    public GameManager gameManager;

     private int currentWeapon = 1;
    // Start is called before the first frame update
    void Start()
    {
        if (playerGun == null)
        {
            print("Player Script missing gun object");
        }
        if (screen == null)
        {
            print("Player Script missing UI");
        }

        canvasAnimator = screen.GetComponent<Animator>();
//        print("canvas anim is " + canvasAnimator == null);
        //playerHit.clip.preloadAudioData = true;

        UpdateWeapon();

      
    }


    // Update is called once per frame

    /* Switch weapons */
    void Update(){

        if(playPlayerHit){
            playerHit.PlayOneShot(playerHit.clip);
            
            playPlayerHit = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 1;
            UpdateWeapon();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 2;
            UpdateWeapon();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 3;
            UpdateWeapon();
        }
        UpdateAmmoUI();

        /* Pistol & Shotgun*/
        if (Input.GetButtonDown("Fire1") && playerGun.GetComponent<Gun_Pistol>().checkAmmo(gunEquipped)) {
      if(gunEquipped == 'p'){
        playerGun.GetComponent<Gun_Pistol>().shootPistol();
    }
    else if(gunEquipped == 's'){
        playerGun.GetComponent<Gun_Pistol>().shootShotgun();
    }
    
    //screen.transform.Find("Ammo").transform.Find("AmmoCounter").GetComponent<Text>().text = ammo.ToString();
}


    if(!Input.GetButton("Fire1")){
        machinegunCount = 0;
    } 
    /* Machine Gun */
    if(Input.GetButton("Fire1") && gunEquipped == 'm' && playerGun.GetComponent<Gun_Pistol>().checkAmmo(gunEquipped)) {

        
        
        playerGun.GetComponent<Gun_Pistol>().shootMachinegun(machinegunCount);
        
        machinegunCount++;

    
        //screen.transform.Find("Ammo").transform.Find("AmmoCounter").GetComponent<Text>().text = ammo.ToString();
    }
        //print("player X: " + transform.position.x + " Player Y: " + transform.position.y);

        //print(transform.Find("Main Camera").transform.rotation.y * 360);
    }
    void UpdateWeapon() {
       switch(currentWeapon){
            case 1:
                gunEquipped = 'p';
                if (gunModel != null) gunModel.SwitchToPistol();
                break;
            case 2:
                gunEquipped = 's';
                if (gunModel != null) gunModel.SwitchToShotgun();
                break;
            case 3:
                gunEquipped = 'm';
                if (gunModel != null) gunModel.SwitchToMachinegun();
                break;
        }
        UpdateWeaponUI();
        
    }

    void UpdateWeaponUI()
    {
        string weaponName = "";
        Color weaponColor = Color.white;

        switch (currentWeapon)
        {
            case 1:
                weaponName = "PISTOL";
                weaponColor = Color.green;
                break;
            case 2:
                weaponName = "SHOTGUN";
                weaponColor = new Color(1f, 0.5f, 0f);
                break;
            case 3:
                weaponName = "MACHINEGUN";
                weaponColor = Color.red;
                break;
        }

        if (weaponText != null)
        {
            weaponText.text = weaponName;
            weaponText.color = weaponColor;
        }
    }

    public bool HasFullHealth()
    {
        return health >= 100;
    }


    public void addHealth(int num)
    {
        health += num;
        screen.transform.Find("Health").transform.Find("HealthCounter").GetComponent<Text>().text = health.ToString();
        canvasAnimator.SetBool("PlayerHeals",true);
        if (health > 100)
        {
            health = 100;
        }
        //screen.transform.Find("Health").transform.Find("HealthCounter").GetComponent<Text>().text = health.ToString();
    }
    /**
    public void addpammo(int num)
    {
        ammo += num;
        screen.transform.Find("Ammo").transform.Find("AmmoCounter").GetComponent<Text>().text = ammo.ToString();
    }

    public void addsammo(int num)
    {
        ammo += num;
        screen.transform.Find("Ammo").transform.Find("AmmoCounter").GetComponent<Text>().text = ammo.ToString();
    }

    public void addmammo(int num)
    {
        ammo += num;
        screen.transform.Find("Ammo").transform.Find("AmmoCounter").GetComponent<Text>().text = ammo.ToString();
    }

    */
    public void hitPlayer(int damage){
        playPlayerHit = true;
        if(!canvasAnimator.GetBool("PlayingHit")){
            canvasAnimator.SetBool("EnemyHits",true);
        }

        health -= damage;
        UpdateAmmoUI();
        if(health <= 0){
            gameManager.gameOver();
            //Destroy(gameObject);
        }
    }

    //ADDED UIAMMO
    void UpdateAmmoUI()
    {
        Gun_Pistol gunScript = playerGun.GetComponent<Gun_Pistol>();

        if (gunScript == null)
        {
            return;
        }
        

        if (gunEquipped == 'p')
        {
            screen.transform.Find("Ammo").transform.Find("AmmoCounter").GetComponent<Text>().text = gunScript.GetPistolAmmo().ToString();
        }
        else if (gunEquipped == 's')
        {
            screen.transform.Find("Ammo").transform.Find("AmmoCounter").GetComponent<Text>().text = gunScript.GetShotgunAmmo().ToString();
        }
        else if (gunEquipped == 'm')
        {
            screen.transform.Find("Ammo").transform.Find("AmmoCounter").GetComponent<Text>().text = gunScript.GetMachinegunAmmo().ToString();
        }
        screen.transform.Find("Health").transform.Find("HealthCounter").GetComponent<Text>().text = health.ToString();
    }
    


}