using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float AngularSpeed;
    public float minSpeed, maxSpeed;

    public GameObject asteroidExplode;
    public GameObject shipExplode;

    public void explode()
    {
        Instantiate(asteroidExplode, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere*AngularSpeed;
        asteroid.velocity = Vector3.back * Random.Range(minSpeed, maxSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameBoundary")
        {
            return;
        }
        if (other.tag == "Player")
        {
            Instantiate(shipExplode, other.transform.position, Quaternion.identity);
            GameControll.getInstance().decreaseScore(100);

        }
        else
        {
            GameControll.getInstance().increaseScore(10);
            Destroy(other.gameObject);
        }
        explode();
        
        

    }
}
