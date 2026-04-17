using UnityEngine;

public class Ammo_Pistol : MonoBehaviour
{
    public int pistolAmount = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player_Script ph = other.GetComponent<Player_Script>();

            if (ph != null)
            {
                ph.addpammo(pistolAmount);
            }

            Destroy(gameObject);
        }
    }
}