using UnityEngine;

public class Shotgun_Pickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Player_Script player = other.GetComponent<Player_Script>();

        if (player == null)
        {
            player = other.GetComponentInParent<Player_Script>();
        }

        if (player != null)
        {
            player.UnlockShotgun();
            Destroy(gameObject);
        }
    }
}