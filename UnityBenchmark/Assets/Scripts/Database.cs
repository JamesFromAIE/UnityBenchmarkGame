using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    public ReflexTest reflexTest;
    public ReactionScreen reactionScreen;

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
            Debug.Log("New Reflex score sent successfully!");
        }

        // Links updated score to local variable
        if (reactionScreen.reactionSent == true)
        {
            reactionScore = reactionScreen.averageReaction;
            reactionScreen.reactionSent = false;
            Debug.Log("New Reaction score sent successfully!");
        }
        ReflexDatabase();
        ReactionDatabase();
    }

    void ReactionDatabase()
    {
        ReactionCalculations();


        float[] reactionArray = new float[4];

        reactionArray[0] = reactionScore;
        reactionArray[1] = reactionHigh;
        reactionArray[2] = reactionRecent;
        reactionArray[3] = reactionAverage;

        

    }

    void ReflexDatabase()
    {
        ReflexCalculations();

        int[] reflexArray = new int[4];

        reflexArray[0] = reflexScore;
        reflexArray[1] = reflexHigh;
        reflexArray[2] = reflexRecent;
        reflexArray[3] = reflexAverage;
    }
   


  

    void ReactionCalculations()
    {
        reactionRecent = reactionScore;

        

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
        //Debug.Log("reflexScore was receieved");
        reflexRecent = reflexScore;

        reflexAverage = reflexScore;
        if (reflexAverage != reflexScore)
        {
            
        }

        if (reflexHigh < reflexScore)
        {
            reflexHigh = reflexScore;
        }
    }
}
