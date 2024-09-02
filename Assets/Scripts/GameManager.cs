using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] targetprefabs;
    private int spawnRate = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomiser());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRandomiser()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int targetIndex = Random.Range(0, targetprefabs.Length);
            Instantiate(targetprefabs[targetIndex]);
        }

    }

   
}
