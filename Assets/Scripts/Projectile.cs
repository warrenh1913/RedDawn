using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update

    
    void Start()
    {
        //transform.Rotate();
    }

    // Update is called once per frame
    void Update()
    {
        

        
        
        //transform.Translate(transform.forward * .05f,Space.Self);
        

        transform.position += transform.forward * Time.fixedDeltaTime;
        //transform.Translate(transform.localRotation * Vector3.forward * Time.fixedDeltaTime);


        Debug.DrawRay(transform.position, transform.forward * 20, Color.red, 50);
    }
}
