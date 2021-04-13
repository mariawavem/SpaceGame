using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public float tilt;
    public float xMin, xMax, zMin, zMax;
    public GameObject LazerGun;
    public GameObject LazerShot;
    public float ShotDelay;

    Rigidbody ship;

    private float nextShot;
    // Start is called before the first frame update
    void Start()
    {
        ship = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameControll.getInstance().getIsStarted())
        {
            return;
        }
        float moveHorizontal=Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        ship.velocity = new Vector3(moveHorizontal, 0, moveVertical)*speed;

        ship.rotation = Quaternion.Euler(ship.velocity.z*tilt, 0, -ship.velocity.x*tilt);

        float xPosition = Mathf.Clamp(ship.position.x, xMin, xMax);
        float zPosition = Mathf.Clamp(ship.position.z, zMin, zMax);
        ship.position= new Vector3 (xPosition,0,zPosition);

        if (Input.GetButton("Fire1") && Time.time>nextShot)
        {
            Instantiate(LazerShot, LazerGun.transform.position, Quaternion.identity);
            nextShot = Time.time + ShotDelay;
        }

        if (Input.GetButton("Fire2"))
        {
            GameObject[] asteroids=GameObject.FindGameObjectsWithTag("Asteroid");
            foreach(GameObject asteroid in asteroids)
            {
                asteroid.GetComponent<AsteroidScript>().explode();
            }


        }
            
     }

   
}
