using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float timePassed = 0f;
    public Canvas userInterface;

    // Start is called before the first frame update
    void Start()
    {
      //  userInterface.transform.Find("TimerText").GetComponent<Text>().text = timePassed.ToString("F1");
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
    }
}

