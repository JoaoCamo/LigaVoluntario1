using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrophyController : MonoBehaviour
{
    public GameObject[] objetivos;
    public bool[] spawnPointsTaken;
    private Vector3 pos;
    public Text currentTrophies;
    public GameObject[] spawnPoints;

    public void spawnTrophies()
    {
        for(int i=0;i<objetivos.Length;i++)
        {
            objetivos[i].gameObject.SetActive(true);
            int spawn = Random.Range(0, spawnPoints.Length);
            if(spawnPointsTaken[spawn])
            {
                do
                {
                    spawn = Random.Range(0, spawnPoints.Length);
                } while(spawnPointsTaken[spawn]);
                pos  = new Vector3(spawnPoints[spawn].transform.position.x,1,spawnPoints[spawn].transform.position.z);
                objetivos[i].transform.position = pos;
                spawnPointsTaken[spawn] = true;
            } else {
                pos  = new Vector3(spawnPoints[spawn].transform.position.x,1,spawnPoints[spawn].transform.position.z);
                objetivos[i].transform.position = pos;
                spawnPointsTaken[spawn] = true;
            }
        }
    }

    public void clearTakenSpawns()
    {
        for(int i=0;i<spawnPointsTaken.Length;i++)
        {
            spawnPointsTaken[i] = false;
        }
    }
}
