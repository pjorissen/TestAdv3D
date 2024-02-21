using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpDownLeftRight : MonoBehaviour
{
    public float upX;
    public float downX;
    public float upZ;
    public float downZ;
    public float xSpeed;
    public float zSpeed;


    private float startPosX;
    private float startPosZ;
    private bool moveXUp;
    private bool moveZUp;

    // Start is called before the first frame update
    void Start()
    {
        startPosX = transform.position.x;
        startPosZ = transform.position.z;
        moveXUp = true;
        moveZUp = true;
    }

    // Update is called once per frame
    void Update()
    {
       
        if ( (moveZUp && transform.position.z > startPosZ + upZ) || (!moveZUp && transform.position.z < startPosZ  - downZ ))
        {
            moveZUp = !moveZUp;
            zSpeed = -zSpeed;
        }
        if ((moveXUp && transform.position.x > startPosX + upX) || (!moveXUp && transform.position.x < startPosX - downX))
        {
            moveXUp = !moveXUp;
            xSpeed = -xSpeed;
        }

        transform.position += new Vector3(xSpeed, 0, zSpeed)*Time.deltaTime;
    }
}
