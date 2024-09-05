using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    private Button rollButton;

    public GameObject[] DicePrefab;
    public GameObject[] diceHolders;

    public int diceBanked;



    // Start is called before the first frame update
    void Start()
    {
        rollButton = GetComponent<Button>();
        rollButton.onClick.AddListener(RollDice);

        diceBanked = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RollDice()
    {
        Debug.Log("Rollin'");

        for (int i = 0; i < DicePrefab.Length; i++)
        {
            Instantiate(DicePrefab[i]);

        }

    }

    private void StupidMode()
    {
        Debug.Log("Stupid");

        for (int i = 0; i < DicePrefab.Length*5; i++)
        {
             Instantiate(DicePrefab[i]);

        }


    }

}
