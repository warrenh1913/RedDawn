using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Soviet_Normal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject camera;

    public GameObject player;

    private int hitCooldown = 100;

    private int health = 125;
     
    void Start()
    {
        if(camera == null){
            print("Enemy_SovietNormal Script is missing camera object reference ");
        }
        
        transform.parent.gameObject.transform.rotation = new Quaternion(0f,0f,0f,0f);

    }

    // Update is called once per frame
    void Update()
    {
        
        // transform.Rotate(new Vector3(camera.transform.rotation.y * 360,0f,0f));
        //transform.LookAt(camera.transform,Vector3.left);
        
        //print(transform.rotation);
        // print("player coords : " + player.transform.position);
         
        //  rotation = new Vector3(0f,rotation.y,0f);

        //Debug.DrawRay(transform.position,rotation * 20,Color.red,50);

        Vector3 rotation = (player.transform.position - transform.position ).normalized;
        rotation.y = 0;
        
        Vector3 tempVec = Quaternion.LookRotation(rotation,Vector3.up).eulerAngles;

        tempVec.z = 90f;
        tempVec.y += 90f;

        transform.rotation = Quaternion.Euler(tempVec);

        hitPlayer();
        //playNoise();
        //print(transform.rotation);
        //transform.localEulerAngles = new Vector3(0f,0f,90f);
        
        //transform.localEulerAngles = new Vector3(0f,rotation.z * 360 - 90,90f);
        
        //transform.localEulerAngles = new Vector3(0f,camera.transform.eulerAngles.y,0f);
        //transform.Rotate(new Vector3(Time.deltaTime * 10,0f,0f));
        // can see player
        
        
    }

    bool hitPlayer(){

        RaycastHit hit;
        Physics.Raycast(transform.position, (player.transform.position - transform.position).normalized,out hit,2.5f);


        if(hit.collider != null && hit.collider.tag == "Player"){
            hitCooldown--;
            if(hitCooldown <= 0){
                hit.collider.gameObject.GetComponent<Player_Script>().hitPlayer(10);
                print("hit player");
                hitCooldown = 800;
            }
        }else{
            hitCooldown = 100;
        }
        Debug.DrawRay(transform.position, (player.transform.position - transform.position).normalized * 2.5f, Color.black, 50);
        return false;

    }

    // public bool seePlayer(){
    //     
    // }

    // void OnTriggerEnter(Collider other){
    //     print("hit");
    //     Destroy(gameObject);
    // }
    //private float timePassed = 0f;
    // void playNoise()
    // {
    //     timePassed += Time.deltaTime;
    //     if(timePassed >= 1f)
    //     {
    //         deathSound.Play();
    //         timePassed = 0f;
    //     }
    // }
}
