using UnityEngine;

public class Enemy_Drops : MonoBehaviour
{
    public GameObject[] possibleDrops;
    [Range(0f, 1f)] public float dropChance = 1f;



    public void dropItem(){

        
        if (!Application.isPlaying)
            return;

        if (possibleDrops == null || possibleDrops.Length == 0)
            return;

        if (Random.value > dropChance)
            return;

        int randomIndex = Random.Range(0, possibleDrops.Length);

        if (possibleDrops[randomIndex] != null)
        {
            Instantiate(possibleDrops[randomIndex], transform.position, Quaternion.identity);
        }

        
    }
}