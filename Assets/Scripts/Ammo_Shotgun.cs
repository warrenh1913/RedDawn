using UnityEngine;

public class Ammo_Shotgun : MonoBehaviour
{
    public int shotgunAmount = 5;
    private bool pickedUp = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && pickedUp != true)
        {
            Gun_Pistol gun = other.GetComponentInChildren<Gun_Pistol>();

            if (gun != null)
            {
                pickedUp = true;
                if(transform.GetComponent<SpriteRenderer>() != null){
                    transform.GetComponent<SpriteRenderer>().enabled = false;
                }
                gun.AddShotgunAmmo(shotgunAmount);
                AudioSource temp = GetComponent<AudioSource>();
                temp.PlayOneShot(temp.clip);
                Destroy(gameObject,temp.clip.length);
            }
        }
    }
}