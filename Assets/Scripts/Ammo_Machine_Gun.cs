using UnityEngine;

public class Ammo_Machine_Gun : MonoBehaviour
{
    public int machinegunAmount = 25;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Gun_Pistol gun = other.GetComponentInChildren<Gun_Pistol>();

            if (gun != null)
            {
                gun.AddMachinegunAmmo(machinegunAmount);
                Destroy(gameObject);
            }
        }
    }
}