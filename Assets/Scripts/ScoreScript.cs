using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{ 

    public int CountFPS = 30; 
    public float Duration = 1f; 
    private Coroutine CountingCoroutine; 
    [SerializeField] private TMP_Text tmp;
    private static int prevScore = 0; 
    private static int currScore; 
    [SerializeField] private AudioSource cashierSound;

    // Start is called before the first frame update
    void Start()
    {
        currScore = prevScore;
        tmp.text = currScore.ToString(); 
    }

    public static void resetScore()
    {
        currScore = 0;
        prevScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void saveScore()
    {
        prevScore = currScore;
    }
    
    // increments the score and changes the scoreboard 
    public void IncrementScoreBy(int by) 
    {
        Debug.Log("incrementing by " + by);
        cashierSound.Play();
        UpdateText(currScore + by);
        currScore += by;
        Database db = GetComponent<Database>();
        db.addHearts(by);
        //Debug.Log("currScore is: " + currScore);
        // ScoreScript sc = scoreManager.GetComponent<ScoreScript>();
    }

    // number incrementing effect
    private void UpdateText(int newScore) 
    {
        if (CountingCoroutine != null) 
        {
            StopCoroutine(CountingCoroutine);
        }
        CountingCoroutine = StartCoroutine(CountText(newScore));
    }

    private IEnumerator CountText(int newScore) 
    {
        WaitForSecondsRealtime Wait = new WaitForSecondsRealtime(1f/CountFPS);
        int previousValue = currScore; 
        int stepAmount; 

        stepAmount = 1;

        if (previousValue < newScore)
        {
            
            while (previousValue < newScore)
            {
                previousValue += stepAmount; 
                if (previousValue > newScore)
                {
                    previousValue = newScore;
                }
                tmp.text = previousValue.ToString();
                yield return Wait; 
            }
            
            
        }
        else 
        {
            while (previousValue > newScore)
            {
                previousValue += stepAmount; 
                if (previousValue < newScore)
                {
                    previousValue = newScore;
                }
                tmp.text = previousValue.ToString();
                yield return Wait; 
            }
            
            
        }
    }
}
