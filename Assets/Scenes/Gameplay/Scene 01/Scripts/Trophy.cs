using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if(GameManager.instance.points < 3)
        {
            gameObject.SetActive(false);
            GameManager.instance.points++;

        } else if(GameManager.instance.points == 3) {
            trophyFive();
            GameManager.instance.points++;

        } else {
            gameObject.SetActive(false);
            GameManager.instance.mc.winAni.SetTrigger("show");
            GameManager.instance.points = 0;
            GameManager.instance.tic.timerOn = false;
            GameManager.instance.tic.checkForBestTime();
            GameManager.instance.tic.currentTime = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        GameManager.instance.thc.currentTrophies.text = GameManager.instance.points.ToString() + "/5";
    }

    
    public void trophyFive()
    {
        int spawn = Random.Range(0, GameManager.instance.thc.spawnPoints.Length);
        Vector3 pos  = new Vector3(GameManager.instance.thc.spawnPoints[spawn].transform.position.x,1,GameManager.instance.thc.spawnPoints[spawn].transform.position.z);
        gameObject.transform.position = pos;
    }
}
