using UnityEngine;

public class Machine_Gun_Pickup : MonoBehaviour
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
            player.UnlockMachinegun();
            Destroy(gameObject);
        }
    }
}