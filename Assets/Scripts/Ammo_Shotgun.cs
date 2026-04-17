using UnityEngine;

public class Ammo_Shotgun : MonoBehaviour
{
    public int shotgunAmount = 4;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player_Script ph = other.GetComponent<Player_Script>();

            if (ph != null)
            {
                ph.addsammo(shotgunAmount);
            }

            Destroy(gameObject);
        }
    }
}