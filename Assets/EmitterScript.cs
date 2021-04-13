using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{
    public GameObject asteroid;
    public float minDelay, maxDelay;

    private float nextLaunch;
   
    // Update is called once per frame
    void Update()
    {
        if (!GameControll.getInstance().getIsStarted())
        {
            return;
        }
       if (Time.time > nextLaunch)
        {
            nextLaunch = Time.time + Random.Range(minDelay, maxDelay);

            float xSize = transform.localScale.x;
            float xPosition = Random.Range(-xSize / 2, xSize / 2);
            float zPosition = transform.position.z;

            Instantiate(asteroid, new Vector3(xPosition, 0, zPosition), Quaternion.identity);
        } 
    }
}
