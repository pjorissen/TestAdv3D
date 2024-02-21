using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatInSky : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float distance;
    float angle = 0;

    protected Vector3 startPos;
    // Start is called before the first frame update
   
    void Start()
    {
        startPos = transform.position;
        angle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        angle += speed * Time.deltaTime;
        Debug.Log(angle);

        float yChange = Mathf.Sin(angle *Mathf.Deg2Rad);
        yChange *= distance;

        transform.position = startPos + new Vector3(0,yChange,0);

    }
}
