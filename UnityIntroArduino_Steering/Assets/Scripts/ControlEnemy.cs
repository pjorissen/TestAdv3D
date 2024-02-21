using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemy : MonoBehaviour
{
    public float moveForce = 5;
    public Vector3 moveDirection;
    public float timeToLive = 10;

    // Start is called before the first frame update
    void Start()
    {
        moveDirection = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
        moveDirection.Normalize();

        Destroy(this.gameObject, timeToLive);
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(moveDirection * moveForce);

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Floor")
        {
            moveDirection = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
            moveDirection.Normalize();
        }

       if(collision.gameObject.name == "FPSController")
        {
            
            if(GameManager.Instance.health > 0)
            {
                GameManager.Instance.health -= 10;
                Debug.Log("DIE DIE MOTHER******");
            }
            else
            {
                Debug.Log("GAME OVER");
            }
            
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name != "Floor")
        {
            moveDirection = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
            moveDirection.Normalize();
        }   
    }
}
