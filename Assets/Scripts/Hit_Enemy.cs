using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Enemy : MonoBehaviour
{
    // Start is called before the first frame update


    
    public int health = 100;

    public GameObject deadSprite;
    
    void Start()
    {
        if(deadSprite == null){
            print("Hit_Enemy script is missing enemyDead prefab");
        }

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hitEnemy(int damage){
        health -= damage;
        print("hit enemy for " + damage + " damage");
        if(health <= 0){
            

            GameObject temp = Instantiate(deadSprite,transform.position,Quaternion.LookRotation(transform.forward));
            temp.GetComponent<Look_At_Player>().setPlayer(transform.parent.GetComponent<Move_To_Player>().player);

            transform.parent.gameObject.GetComponent<Move_To_Player>().enemyDied();
            Destroy(gameObject);
        }
    }
}
