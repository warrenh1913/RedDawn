using UnityEngine;

public class Ammo_Machine_Gun : MonoBehaviour
{
    public int machinegunAmount = 25;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player_Script ph = other.GetComponent<Player_Script>();

            if (ph != null)
            {
                ph.addsammo(machinegunAmount);
            }

            Destroy(gameObject);
        }
    }
}