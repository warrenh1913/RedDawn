using UnityEngine;

public class Ammo_Pistol : MonoBehaviour
{
    public int pistolAmount = 15;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Gun_Pistol gun = other.GetComponentInChildren<Gun_Pistol>();

            if (gun != null)
            {
                gun.AddPistolAmmo(pistolAmount);
                Destroy(gameObject);
            }
        }
    }
}