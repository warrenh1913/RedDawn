using UnityEngine;

public class Key_Script : MonoBehaviour
{
    public GameObject LockedDoor1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player_Script>() != null)
        {
            if (LockedDoor1 != null)
            {
                Destroy(LockedDoor1);
            }

            Destroy(gameObject);
        }
    }
}