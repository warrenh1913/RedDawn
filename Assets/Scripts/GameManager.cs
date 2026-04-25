using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float timePassed = 0f;
    public GameObject userInterface;

    public int enemyCount = 0;
    private int killedEnemies = 0;

    public GameObject player;

    private Scene mainScene;

    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
      //  userInterface.transform.Find("TimerText").GetComponent<Text>().text = timePassed.ToString("F1");
      mainScene = SceneManager.GetActiveScene();
      isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        timePassed += Time.deltaTime;
        userInterface.transform.Find("TimerText").GetComponent<Text>().text = "Time " + ((int)timePassed).ToString() + "\n"
        + "Enemies Killed: " +  killedEnemies + "/" + enemyCount  +"\n";
        //screen.transform.Find("Health").transform.Find("HealthCounter").GetComponent<Text>().text = health.ToString();
        if(isGameOver && Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(mainScene.name);
            Time.timeScale = 1f;
            isGameOver = false;
        }
        
    }


    public void addEnemyDeath(){
        
        killedEnemies++;
    }

    public void gameOver(){
        userInterface.transform.Find("gameOver").gameObject.SetActive(true);
        player.GetComponent<Player_Script>().enabled = false;
        //player.GetComponent<FirstPersonController>().enabled = false;
        //player.SetActive(false);
        isGameOver = true;
        Time.timeScale = 0f;
        




        print("player died");
        //Destroy(player);


    }

    public void gameWin(){

        userInterface.transform.Find("GameWinText").GetComponent<Text>().text = "Time: " + ((int)timePassed).ToString() +"\n" 
        + "Enemies Killed: " +  killedEnemies + "/" + enemyCount  +"\n" 
        +  "Total Score: " + (int)(5000 + (timePassed * -5) + ((enemyCount - killedEnemies) * -25) ) +  "\n" 
        +  "Press R to Restart\n";
        userInterface.transform.Find("GameWinText").gameObject.SetActive(true);
        userInterface.transform.Find("gameWin").gameObject.SetActive(true);

        player.GetComponent<Player_Script>().enabled = false;
        isGameOver = true;
        Time.timeScale = 0f;

    }





}

