using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    private Button rollButton;
    public TMP_Text rollButtonText;

    public GameObject[] DicePrefab;
    public GameObject[] diceHolders;


    public int diceBanked;

    public int rollNum;
    


    // Start is called before the first frame update
    void Start()
    {
        rollButton = GetComponent<Button>();
        rollButton.onClick.AddListener(RollDice);
        

        diceBanked = 0;
        rollNum = 0;

        updateRollNumber();

        
     

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RollDice()
    {
        

        if (rollNum == 0)
        {
            Debug.Log("Roll 1");

            rollNum = 1;

            updateRollNumber();

            for (int i = 0; i < DicePrefab.Length; i++)
            {
                Instantiate(DicePrefab[i]);
                
            }
        }


        else if (rollNum > 0 && rollNum < 3)
        {
            rollNum += 1;
            Debug.Log("roll" + rollNum);

            updateRollNumber();

            GameObject[] dieList2 = GameObject.FindGameObjectsWithTag("Die");
            int diceCount = 0;

            foreach (GameObject die in dieList2)
            {
                diceCount += 1;
                Destroy(die);
                Instantiate(DicePrefab[diceCount]);
            }
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

    private void updateRollNumber()
    {
        if (rollNum < 3)
        {
            rollButtonText.text = "ROLL " + (rollNum + 1);
        }
        else 
        {
            rollButtonText.text = "No More ROLLS"; 
 //           rollButtonText.outlineColor = Color.white;
        }
    }

    private void OnMouseDown()
    {
        var buttonColor = gameObject.GetComponent<Button>().colors.normalColor;
        buttonColor = Color.green;
    }

    private void OnMouseUp()
    {
        var buttonColor = gameObject.GetComponent<Button>().colors.normalColor;
        buttonColor = Color.white;
    }
}
