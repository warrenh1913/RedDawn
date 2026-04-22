using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update

    private float speed = 10f;
    void Start()
    {
        //transform.Rotate();
    }

    // Update is called once per frame
    void Update()
    {
        

        
        
        //transform.Translate(transform.forward * .05f,Space.Self);
        

        transform.position += transform.forward * speed * Time.deltaTime;
        
        //print(transform.forward * Time.fixedDeltaTime * 5);
        //transform.Translate(transform.localRotation * Vector3.forward * Time.fixedDeltaTime);


        //Debug.DrawRay(transform.position, transform.forward * 20, Color.red, 50);
    }

    void OnCollisionEnter(Collision c){
        print("collided");
        if(c.gameObject.tag == "Player"){
            c.gameObject.GetComponent<Player_Script>().hitPlayer(10);
            Destroy(gameObject);
        }else{
            Destroy(gameObject);
        }
    }
}
