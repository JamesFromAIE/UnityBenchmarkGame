using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    public ReflexTest reflexTest;
    public ReactionScreen reactionScreen;
    public ClearSave clearSave;


    public float reactionScore;
    public float reactionHigh;
    public float reactionRecent;
    public float reactionAverage;
    public float totalReactionTime;
    public int reactionAvCount;

    public int reflexScore;
    public int reflexHigh;
    public int reflexRecent;
    public int reflexAverage;

    private bool reactionCalced = false;
    private bool reflexCalced = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Links updated score to local variable
        if (reflexTest.reflexSent == true)
        {
            reflexScore = reflexTest.score;
            reflexTest.reflexSent = false;
            reflexCalced = false;
        }

        // Links updated score to local variable
        if (reactionScreen.reactionSent == true)
        {
            reactionScore = reactionScreen.averageReaction;
            reactionScreen.reactionSent = false;
            reactionCalced = false;
        }
        ReflexDatabase();
        ReactionDatabase();
    }

    public void ReactionDatabase()
    {
        // If its not 0 AND hasn't been used yet
        if (reactionScore > 0 && reactionCalced == false)
        {
            ReactionCalculations();
            reactionCalced = true;
        }

        float[] reactionArray = new float[4];

        // Update Array
        reactionArray[0] = reactionScore;
        reactionArray[1] = reactionHigh;
        reactionArray[2] = reactionRecent;
        reactionArray[3] = reactionAverage;

        if (clearSave.clearData == true)
        {
            Array.Clear(reactionArray, 0, reactionArray.Length);
            //clearSave.clearData = false;
            Debug.Log("reaction results cleared");
        }
    }

    public void ReflexDatabase()
    {
        // If its not 0 AND hasn't been used yet
        if (reflexScore > 0 && reflexCalced == false)
        {
            ReflexCalculations();
            reflexCalced = true;
        }

        int[] reflexArray = new int[4];

        // Update Array
        reflexArray[0] = reflexScore;
        reflexArray[1] = reflexRecent;
        reflexArray[2] = reflexAverage;
        reflexArray[3] = reflexHigh;

        if (clearSave.clearData == true)
        {
            Array.Clear(reflexArray, 0, reflexArray.Length);
            clearSave.clearData = false;
            Debug.Log("reaction results cleared");
        }
    }
   
    void ReactionCalculations()
    {
        Debug.Log("reactionScore was receieved");

        //Finding Recent Score
        reactionRecent = reactionScore;

        // Finding Average Score
        if (reactionAverage == 0)
        {
            reactionAverage = reactionScore;
        }
        else
        {
            reactionAverage = (reactionAverage + reactionRecent) / 2;
        }

        // Finding High Score
        if (reactionHigh > reactionScore)
        {
            reactionHigh = reactionScore;
        }
        else if (reactionHigh == 0)
        {
            reactionHigh = reactionScore;
        }
    }

    void ReflexCalculations()
    {
        //Finding Recent Score
        reflexRecent = reflexScore;

        // Finding Average Score
        if (reflexAverage == 0)
        {
            reflexAverage = reflexScore;
        }
        else
        {
            reflexAverage = (reflexAverage + reflexRecent) / 2;
        }

        // Finding High Score
        if (reflexHigh < reflexScore)
        {
            reflexHigh = reflexScore;
        }
    }
}
