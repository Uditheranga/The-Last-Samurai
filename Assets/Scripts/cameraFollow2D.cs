using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow2D : MonoBehaviour
{
    //use Transform to follow it along the player 
    public Transform target; // target is what the camera is following 
    public float smoothing; //dampeing effect

    Vector3 offset; //differance between character and the camera 

    float lowY; //lowest point that camera can go 

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;

        lowY = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //maintain target position & where the camera wants to be located
        Vector3 targetCamPos = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);

        if(transform.position.y < lowY)
        {
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);  
        }
    }
}
