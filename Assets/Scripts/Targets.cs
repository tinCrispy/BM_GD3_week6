using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Targets : MonoBehaviour
{
    public Rigidbody rb;
    private float minspeed = 5;
    private float maxspeed = 10;
    private float xRange = 4;
    private float maxTorque = 10;
    private float ySpawnPos = 7;

    private GameManager gameManager;
    public AudioClip soundTrack;

   



    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce( RandomForce(), ForceMode.Impulse);
        rb.AddTorque (RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomForce()
    {
        return Vector3.forward * Random.Range(minspeed, maxspeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(xRange, -xRange), ySpawnPos, -3); 
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        gameManager.ScoreUpdate(1);
        gameManager.GameOver();
        


    }
}

