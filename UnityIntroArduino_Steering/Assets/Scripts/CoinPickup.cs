using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    float maxX = 10;
    float maxZ = 10;
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
        if(other.gameObject.name == "FPSController" )
        {
            Debug.Log("Ching Ching!!!  10 points");
            transform.position = new Vector3(
                Random.Range(-maxX, maxX),
                transform.position.y,
                Random.Range(-maxZ, maxZ));
            GameManager.Instance.points += 10;
        }
    }
}
