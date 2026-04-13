using UnityEngine;

public class Health_Pickup : MonoBehaviour
{
    public int healAmount = 25;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player_Script ph = other.GetComponent<Player_Script>();

            if (ph != null)
            {
                ph.addHealth(healAmount);
            }

            Destroy(gameObject);
        }
    }
}