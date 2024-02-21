using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CoinPickupByAll : MonoBehaviour
{
    float maxX = 31;
    float maxZ = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FPSController")
        {
            Debug.Log("Ching Ching!!!  10 points");
            GameManager.Instance.points += 10;
        }
        else
        {
            Debug.Log("Enemy Ching Ching!!!  -10 points");
            GameManager.Instance.points += 10;
        }
       
        //generate new coin spawn position 
        //that is also reacheable for Navmesh agents
        NavMeshHit hit;
        NavMesh.SamplePosition(new Vector3(
                                        Random.Range(-maxX, maxX),
                                        transform.position.y,
                                        Random.Range(-maxZ, maxZ)),
                                    out hit, 3.0f, NavMesh.AllAreas) ;

        transform.position = new Vector3(hit.position.x, transform.position.y, hit.position.z);
  
    }
}
