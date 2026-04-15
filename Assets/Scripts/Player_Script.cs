using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Script : MonoBehaviour
{
    float cooldown = 0.5f;
    float timePassed = 0f;

    int health = 100;
    int ammo = 10;

    public GameObject screen;
    public GameObject playerGun;
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
    }

    // Update is called once per frame
    void Update()
    {

        timePassed += Time.deltaTime;


        if (Input.GetButton("Fire1") && timePassed >= cooldown && ammo > 0)
        {

            playerGun.GetComponent<Gun_Pistol>().shoot();
            ammo--;

            timePassed = 0f;
            screen.transform.Find("Ammo").transform.Find("AmmoCounter").GetComponent<Text>().text = ammo.ToString();


        }
        //print("player X: " + transform.position.x + " Player Y: " + transform.position.y);

        //print(transform.Find("Main Camera").transform.rotation.y * 360);
    }

    public void addHealth(int num)
    {
        health += num;
        screen.transform.Find("Health").transform.Find("HealthCounter").GetComponent<Text>().text = health.ToString();
    }

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






}
