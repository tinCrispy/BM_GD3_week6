using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    public Rigidbody rb;
    private float minspeed = 12;
    private float maxspeed = 16;
    private float xRange = 4;
    private float maxTorque = 10;
    private float ySpawnPos = -0.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce( RandomForce(), ForceMode.Impulse);
        rb.AddTorque (RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minspeed, maxspeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(xRange, -xRange), ySpawnPos); 
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);

    }
}

