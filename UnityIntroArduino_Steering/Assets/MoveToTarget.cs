using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveToTarget : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 direction = target.transform.position - this.transform.position ;
        //calculate 
        Debug.Log(direction);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.transform.position - this.transform.position;
        //remove length by normalizing => make length 1
        direction = direction.normalized;

      //  transform.position += direction * 3 * Time.deltaTime; 
        //calculate 
      //  Debug.Log(direction);

        float dotProduct = Vector3.Dot(new Vector3(1,1,0), target.transform.position);
        float help = dotProduct / ((new Vector3(1, 1, 0).magnitude) * target.transform.position.magnitude);
        float angle = Mathf.Acos(help) * Mathf.Rad2Deg;

        Debug.Log(angle);

    }
}
