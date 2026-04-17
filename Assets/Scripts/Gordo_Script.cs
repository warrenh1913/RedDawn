using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gordo_Script : MonoBehaviour
{
    public GameObject player;

    public int movementSpeed = 3;
    private float realSpeed;
    private Transform playerTransform;

    private Enemy_Soviet_Normal panelScript;

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Gordo_Script is missing player reference");
            return;
        }

        realSpeed = movementSpeed;
        playerTransform = player.transform;

        Transform panel = transform.Find("Panel");
        if (panel != null)
        {
            panelScript = panel.GetComponent<Enemy_Soviet_Normal>();
        }
    }

    void Update()
    {
        if (player == null || playerTransform == null)
            return;

        if (true) // seePlayer()
        {
            float moveX;
            float moveZ;

            if (playerTransform.position.x > transform.position.x)
            {
                moveX = Time.deltaTime * realSpeed;
            }
            else
            {
                moveX = Time.deltaTime * -realSpeed;
            }

            if (playerTransform.position.z > transform.position.z)
            {
                moveZ = Time.deltaTime * realSpeed;
            }
            else
            {
                moveZ = Time.deltaTime * -realSpeed;
            }

            transform.Translate(new Vector3(moveX, 0, moveZ));
        }
    }
}