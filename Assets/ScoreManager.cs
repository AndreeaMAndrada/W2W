using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;//makes an istance of this Score Manager
    public Text enemycount;
    int score = 0;
   
    private void Awake()
    {
        instance = this; //intanciate the Score Manager
    }
    // Start is called before the first frame update
    void Start()
    {
        enemycount.text = score.ToString() + " Points"; // the text to display on the start of the game
    }

    // Update is called once per frame
    public void AddPoint()
    {
        
            score += 1;//adds one
            enemycount.text = score.ToString() + " Points";// add the points in the actual string  
        
    }
}
