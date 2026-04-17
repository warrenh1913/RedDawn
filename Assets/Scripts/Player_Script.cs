using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Script : MonoBehaviour
{
    float cooldown = 0.5f;
    

    int health = 100;
    int ammo = 100;
    

    private char gunEquipped = 'p';

    public GameObject screen;
    public GameObject playerGun;
    // Start is called before the first frame update
    void Start()
    {
        if(playerGun == null){
            print("Player Script missing gun object");
        }
        if(screen == null){
            print("Player Script missing UI");
        }  
    }

    

    // Update is called once per frame
    void Update()
    {
        
        
        
        
        if(Input.GetButton("Fire1") && playerGun.GetComponent<Gun_Pistol>().checkAmmo(gunEquipped)){


            if(gunEquipped == 'p'){
                playerGun.GetComponent<Gun_Pistol>().shootPistol();
            }else if(gunEquipped == 's'){
                playerGun.GetComponent<Gun_Pistol>().shootShotgun();
            }else if(gunEquipped == 'm'){
                playerGun.GetComponent<Gun_Pistol>().shootMachinegun(true);
            }else{ 
            
            }
            
            
            
            
            screen.transform.Find("Ammo").transform.Find("AmmoCounter").GetComponent<Text>().text = ammo.ToString();
            
            
        }
        //print("player X: " + transform.position.x + " Player Y: " + transform.position.y);

        //print(transform.Find("Main Camera").transform.rotation.y * 360);
    }

    public void addHealth(int num){
        health += num;
        screen.transform.Find("Health").transform.Find("HealthCounter").GetComponent<Text>().text = health.ToString();
    }

    

    
}
