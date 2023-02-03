using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrophyController : MonoBehaviour
{
    public GameObject[] objetivos;
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
            pos  = new Vector3(spawnPoints[spawn].transform.position.x,1,spawnPoints[spawn].transform.position.z);
            objetivos[i].transform.position = pos;
            spawnPoints.Remove(spawnPoints[spawn]);
        }
    }

    public void findSpawnPoints()
    {
        foreach(GameObject spawnPoint in GameObject.FindGameObjectsWithTag("SpawnPoint"))
        {
            spawnPoints.Add(spawnPoint);
        }
    }

    public void resetSpawnPoints()
    {
        spawnPoints.Clear();
        findSpawnPoints();
    }
}
