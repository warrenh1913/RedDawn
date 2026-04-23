using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Enemy : MonoBehaviour
{
    // Start is called before the first frame update


    
    public int health = 100;
    void Start()
    {
        

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hitEnemy(int damage){
        health -= damage;
        print("hit enemy for " + damage + " damage");
        if(health <= 0){
            transform.parent.gameObject.GetComponent<Move_To_Player>().enemyDied();
            Destroy(gameObject);
        }
    }
}
