using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


public class Targets : MonoBehaviour
{
    public Rigidbody rb;
    private float minspeed = 5;
    private float maxspeed = 10;
    private float xRange = 4;
    private float maxTorque = 10;
    private float ySpawnPos = 7;

    public bool isBanked;

    private GameManager gameManager;
    private PlayerManager playerManager;

    public AudioClip soundTrack;

    

  

    







    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce( RandomForce(), ForceMode.Impulse);
        rb.AddTorque (RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerManager = GameObject.FindObjectOfType<PlayerManager>();

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

        if (!isBanked)
        {
            Vector3 currentRotation = transform.eulerAngles;
            float xRot = currentRotation.x;
            float zRot = currentRotation.z;
            transform.rotation = Quaternion.Euler(xRot, 0, zRot);
            transform.position = playerManager.diceHolders[playerManager.diceBanked].transform.position + Vector3.up;

            //       transform.Rotate(transform.rotation.x, 0, transform.rotation.z); 
            playerManager.diceBanked++;
            rb.isKinematic = true;
            isBanked = true;
            gameObject.tag = "Banked";
        }

        


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Die"))
        {
            rb.AddForce (0,2,0, ForceMode.Impulse);
        }
    }




}

