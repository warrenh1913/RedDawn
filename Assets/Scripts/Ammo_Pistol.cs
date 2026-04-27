using UnityEngine;

public class Ammo_Pistol : MonoBehaviour
{
    public int pistolAmount = 15;

    private bool pickedUp = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && pickedUp != true)
        {
            Gun_Pistol gun = other.GetComponentInChildren<Gun_Pistol>();

            if (gun != null)
            {
                pickedUp = true;
                transform.GetComponent<SpriteRenderer>().enabled = false;
                gun.AddPistolAmmo(pistolAmount);
                AudioSource temp = GetComponent<AudioSource>();
                temp.PlayOneShot(temp.clip);
                Destroy(gameObject,temp.clip.length);
            }
        }
    }
}