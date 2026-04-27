using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalin_Script : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject door;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy(){
        Destroy(door);
    }
}
