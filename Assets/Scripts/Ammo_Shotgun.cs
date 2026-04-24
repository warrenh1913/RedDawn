using UnityEngine;

public class Ammo_Shotgun : MonoBehaviour
{
    public int shotgunAmount = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Gun_Pistol gun = other.GetComponentInChildren<Gun_Pistol>();

            if (gun != null)
            {
                gun.AddShotgunAmmo(shotgunAmount);
                Destroy(gameObject);
            }
        }
    }
}