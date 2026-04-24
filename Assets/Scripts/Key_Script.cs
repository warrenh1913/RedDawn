using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public GameObject lockedDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player_Script>() != null)
        {
            if (lockedDoor != null)
            {
                Destroy(lockedDoor);
            }

            Destroy(gameObject);
        }
    }
}