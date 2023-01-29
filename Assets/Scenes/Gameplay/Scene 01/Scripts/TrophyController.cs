using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrophyController : MonoBehaviour
{
    public GameObject[] objetivos;
    public List<bool> spawnPointsTaken = new List<bool>();
    private Vector3 pos;
    public Text currentTrophies;
    public List<GameObject> spawnPoints = new List<GameObject>();

    private void Start()
    {
        findSpawnPoints();
    }

    public void spawnTrophies()
    {
        for(int i=0;i<objetivos.Length;i++)
        {
            objetivos[i].gameObject.SetActive(true);
            int spawn = Random.Range(0, spawnPoints.Count);
            if(spawnPointsTaken[spawn])
            {
                do
                {
                    spawn = Random.Range(0, spawnPoints.Count);
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
        for(int i=0;i<spawnPointsTaken.Count;i++)
        {
            spawnPointsTaken[i] = false;
        }
    }

    public void findSpawnPoints()
    {
        bool spawn = false;
        foreach(GameObject spawnPoint in GameObject.FindGameObjectsWithTag("SpawnPoint"))
        {
            spawnPoints.Add(spawnPoint);
            spawnPointsTaken.Add(spawn);
        }
    }
}
