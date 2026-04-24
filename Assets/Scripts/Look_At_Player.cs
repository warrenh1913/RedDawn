using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look_At_Player : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null){
            print("enemy did not pass player object to dead enemy sprite");
        }else{
        Vector3 rotation = (player.transform.position - transform.position ).normalized;
        rotation.y = 0;
        
        Vector3 tempVec = Quaternion.LookRotation(rotation,Vector3.up).eulerAngles;

        

        transform.rotation = Quaternion.Euler(tempVec);
        }
    }

    public void setPlayer(GameObject p){
        player = p;
    }
}
