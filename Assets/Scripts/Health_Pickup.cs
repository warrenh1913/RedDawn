using UnityEngine;

public class Health_Pickup : MonoBehaviour
{
    public int healAmount = 25;

    private bool pickedUp = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && pickedUp != true)
        {
            Player_Script ph = other.GetComponent<Player_Script>();

            if (ph != null && !ph.HasFullHealth())
            {
                pickedUp = true;
                if(transform.GetComponent<SpriteRenderer>() != null){
                    transform.GetComponent<SpriteRenderer>().enabled = false;
                }
                ph.addHealth(healAmount);

                AudioSource temp = GetComponent<AudioSource>();
                temp.PlayOneShot(temp.clip);
                Destroy(gameObject,temp.clip.length);
            }
        }
    }
}