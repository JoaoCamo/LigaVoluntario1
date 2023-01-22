using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerControl : MonoBehaviour
{
    public Text timerText;
    public Text bestTimeText;
    
    public bool timerOn = false;
    public float timeLeft = 90;
    public float currentTime = 0;

    private void Update()
    {
        if(timerOn)
        {
            if(timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                currentTime += Time.deltaTime;
                updateText(timeLeft);
            } else {
                GameManager.instance.mc.loseAni.SetTrigger("show");
                timeLeft = 90;
                timerOn = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public void updateText(float time)
    {
        time += 1;

        float minutes = Mathf.FloorToInt(time/60);
        float seconds = Mathf.FloorToInt(time%60);

        timerText.text = string.Format("{0}:{1:00}", minutes, seconds);
    }

    public void checkForBestTime()
    {
        if(GameManager.instance.bestTime > currentTime)
        {
            GameManager.instance.bestTime = currentTime;
            float minutes = Mathf.FloorToInt(currentTime/60);
            float seconds = Mathf.FloorToInt(currentTime%60);
            bestTimeText.text = string.Format("{0}:{1:00}", minutes, seconds);
            GameManager.instance.saveBestTime();
        }
    }

    public void updateBestTimeText()
    {
        float bestTime = GameManager.instance.bestTime;
        float minutes = Mathf.FloorToInt(bestTime/60);
        float seconds = Mathf.FloorToInt(bestTime%60);
        bestTimeText.text = string.Format("{0}:{1:00}", minutes, seconds);
    }
}
