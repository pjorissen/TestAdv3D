using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemyWander : MonoBehaviour
{
    public float moveForce = 5;
    private Vector3 moveDirection;
    private Vector3 wanderTarget;
    public float wanderDistance = 1;
    public float circleDiameter = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //create a random position on a circle with radius 1 (around 0,0,0) 
        
        Vector2 circlePos = Random.insideUnitCircle;     
        circlePos *= circleDiameter;
        //calculate the location at wanderDistance in front of target
        Vector2 wanderForward = new Vector2(transform.forward.x * wanderDistance, transform.forward.z * wanderDistance);
        //now add circlePos to create the final targetposition
        moveDirection = new Vector3(wanderForward.x + circlePos.x, 0, wanderForward.y + circlePos.y);

      //  moveDirection.Normalize();
        Debug.Log(moveDirection);
      
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
