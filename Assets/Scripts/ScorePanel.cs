using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
    [SerializeField]
    private Sprite[] digits;

    [SerializeField]
    private Image[] characters;

    private int scoreAmount;

    private int numberOfDigitsInScoreAmount;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= 4; i++)
        {
            characters[i].sprite = digits[0];
        }

        scoreAmount = 0;

        Rat.RatChewed += AddScoreAndDisplayIt;
    } 

    public void AddScoreAndDisplayIt(int randomScoreValue)
    {
        scoreAmount += randomScoreValue;

        //Debug.Log("+ " + randomScoreValue);

        if (scoreAmount >= 100000)
        {
            scoreAmount -= 100000;
        }

        int[] scoreAmountByDigitsArray = GetDigitsArrayFromScoreAmount(scoreAmount);

        switch (scoreAmountByDigitsArray.Length)
        {
            case 1:
                characters[0].sprite = digits[0];
                characters[1].sprite = digits[0];
                characters[2].sprite = digits[0];
                characters[3].sprite = digits[0];
                characters[4].sprite = digits[scoreAmountByDigitsArray[0]];
                break;
            case 2:
                characters[0].sprite = digits[0];
                characters[1].sprite = digits[0];
                characters[2].sprite = digits[0];
                characters[3].sprite = digits[scoreAmountByDigitsArray[0]];
                characters[4].sprite = digits[scoreAmountByDigitsArray[1]];
                break;
            case 3:
                characters[0].sprite = digits[0];
                characters[1].sprite = digits[0];
                characters[2].sprite = digits[scoreAmountByDigitsArray[0]];
                characters[3].sprite = digits[scoreAmountByDigitsArray[1]];
                characters[4].sprite = digits[scoreAmountByDigitsArray[2]];
                break;
            case 4:
                characters[0].sprite = digits[0];
                characters[1].sprite = digits[scoreAmountByDigitsArray[0]];
                characters[2].sprite = digits[scoreAmountByDigitsArray[1]];
                characters[3].sprite = digits[scoreAmountByDigitsArray[2]];
                characters[4].sprite = digits[scoreAmountByDigitsArray[3]];
                break;
            case 5:
                characters[0].sprite = digits[scoreAmountByDigitsArray[0]];
                characters[1].sprite = digits[scoreAmountByDigitsArray[1]];
                characters[2].sprite = digits[scoreAmountByDigitsArray[2]];
                characters[3].sprite = digits[scoreAmountByDigitsArray[3]];
                characters[4].sprite = digits[scoreAmountByDigitsArray[4]];
                break;

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int[] GetDigitsArrayFromScoreAmount(int scoreAmount)
    {
        List<int> listOfInts = new List<int>();
        while (scoreAmount > 0)
        {
            listOfInts.Add(scoreAmount % 10);
            scoreAmount = scoreAmount / 10;
        }

        listOfInts.Reverse();
        return listOfInts.ToArray();
    }

    private void OnDestroy()
    {
        Rat.RatChewed -= AddScoreAndDisplayIt;
    }

}
