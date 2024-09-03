using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.PlayerLoop.EarlyUpdate;


public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score;

    public GameObject[] targetprefabs;
    private int spawnRate = 1;

    public Slider musicVolume;
    public AudioSource soundTrack;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomiser());
        score = 0;
        ScoreUpdate(0);
        scoreText.text = ("nah bruv");

        soundTrack = GameObject.Find("Main Camera").GetComponent<AudioSource>();

  
    }

    // Update is called once per frame
    void Update()
    {
        ChangeVolume(); 
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


    public void ScoreUpdate(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = ("Score: " + score);

    }

    public void ChangeVolume()
    {
        soundTrack.volume = musicVolume.value;
    }
   
}
