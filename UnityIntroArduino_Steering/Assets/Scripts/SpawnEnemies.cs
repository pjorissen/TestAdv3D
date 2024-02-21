using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float timeToSpawn = 5;
    float timeSinceSpawn = 0;
    // Start is called before the first frame update
    void Start()
    {
        timeToSpawn = Random.Range(1, 6);    
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        if(timeSinceSpawn > timeToSpawn)
        {
            GameObject.Instantiate(enemyPrefab, this.transform.position, this.transform.rotation);
            timeSinceSpawn = 0;
            timeToSpawn = Random.Range(1, 6);
        }
    }
}
