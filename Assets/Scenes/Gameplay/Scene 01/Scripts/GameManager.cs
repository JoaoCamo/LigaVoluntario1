using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int points;
    public TrophyController thc;
    public TimerControl tic;
    public MenuController mc;
    public float bestTime;
    public Player player;


    void Awake()
    {
        instance = this;
        loadBestTime();
        PlayerPrefs.DeleteAll();
        tic.updateBestTimeText();
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void restart()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        player.resetPosition();
        thc.resetSpawnPoints();
        thc.spawnTrophies();
        closeAllDoors();
        points = 0;
        tic.timerOn = true;
        tic.timeLeft = 60;
    }

    public void startGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        thc.spawnTrophies();
        tic.timerOn = true;
    }

    public void saveBestTime()
    {
        string save = "";
        save += bestTime.ToString();

        PlayerPrefs.SetString("Save",save);
    }

    public void loadBestTime()
    {
        if(!PlayerPrefs.HasKey("Save"))
        {
            return;
        }

        bestTime = float.Parse(PlayerPrefs.GetString("Save"));
    }

    public void closeAllDoors()
    {
        foreach(GameObject door in GameObject.FindGameObjectsWithTag("Door"))
        {
            door.GetComponent<Door>().doorAni.ResetTrigger("open");
            door.GetComponent<Door>().doorAni.SetTrigger("close");
            door.GetComponent<Door>().opened = false;
        }
    }
}
