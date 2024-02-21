using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDistance : MonoBehaviour
{
    [SerializeField]
    GameObject target;

    [SerializeField]
    bool faceTarget;
    [SerializeField]
    bool moveToTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // pythagoras in 3D 
        float distance = Mathf.Sqrt(
            Mathf.Pow(target.transform.position.x - transform.position.x, 2)  +
            Mathf.Pow(target.transform.position.y - transform.position.y, 2) +
            Mathf.Pow(target.transform.position.z - transform.position.z, 2) );

        //show calculations
       // Debug.Log(distance.ToString() + "  - from unity: "  + Vector3.Distance(target.transform.position, transform.position));

        //set direction
        Vector3 speed3D = new Vector3(target.transform.position.x - transform.position.x,
            target.transform.position.y - transform.position.y,
            target.transform.position.z - transform.position.z);

        if(moveToTarget ) {
            //normalize
            speed3D = speed3D.normalized;

            //take framerate into account (go 1m per second instead of per frame)
            speed3D *= Time.deltaTime; //this is actually dividing by the frames per second
                                       //  Debug.Log(Time.deltaTime);

            transform.position += speed3D;
        }
      


        if(faceTarget )
        {
            transform.LookAt(target.transform.position);

            //calculate lookat angle ourselves (take the forward as the basis
            float cosYAngle = Vector3.Dot(new Vector3(0,0,1), target.transform.position) 
                / (1 *target.transform.position.magnitude) ;
            float angle = Mathf.Acos(cosYAngle);
            Debug.Log(angle * Mathf.Rad2Deg);


        }

    }
}
