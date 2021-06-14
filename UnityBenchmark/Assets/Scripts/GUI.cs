using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    public Database database;

    private bool viewingScreen = false;
    public bool resultsSent = false;

    private int state;
    
    public Text reflexesRecentText;
    public Text reflexesHighText;
    public Text reflexesAverageText;
 
    public Text reactionsRecentText;
    public Text reactionsHighText;
    public Text reactionsAverageText;

    public GameObject reflexesText;
    public GameObject reactionsText;
    public GameObject mask;
    public GameObject esc;

    // Start is called before the first frame update
    void Start()
    {
        state = 0;
    }

    // Update is called once per frame
    void Update()
    {           
        EscButton();
        UpdateValues();
        StateOfUI();  
    }


    void EscButton()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && viewingScreen == false)
        {
            state = 0;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && viewingScreen == false)
        {
            state = 1;
        }

        if (Input.GetKeyUp(KeyCode.Escape) && viewingScreen == true)
        {
            state = 2;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && viewingScreen == true)
        {
            state = 3;
        }
    }

    void UpdateValues()
    {
        reflexesRecentText.text = "Recent Score: " + database.reflexRecent;
        reflexesHighText.text = "High Score: " + database.reflexHigh;
        reflexesAverageText.text = "Average Score: " + database.reflexAverage;

        reactionsRecentText.text = "Recent Score: " + database.reactionRecent;
        reactionsHighText.text = "High Score: " + database.reactionHigh;
        reactionsAverageText.text = "Average Score: " + database.reactionAverage;

    }

    void StateOfUI()
    {
        switch (state)
        {
            case 0:
                Offcase1();
                break;
            case 1:

                OnCase1();
                break;

            case 2:

                OnCase2();
                break;

            case 3:
                Offcase2();
                break;
        }
    }

    void Offcase1()
    {
        reflexesRecentText.enabled = false;
        reflexesHighText.enabled = false;
        reflexesAverageText.enabled = false;

        reactionsRecentText.enabled = false;
        reactionsHighText.enabled = false;
        reactionsAverageText.enabled = false;

        reflexesText.SetActive(false);
        reactionsText.SetActive(false);
        mask.SetActive(false);
        esc.SetActive(true);
        viewingScreen = false;
    }

    void Offcase2()
    {
        reflexesRecentText.enabled = false;
        reflexesHighText.enabled = false;
        reflexesAverageText.enabled = false;

        reactionsRecentText.enabled = false;
        reactionsHighText.enabled = false;
        reactionsAverageText.enabled = false;

        reflexesText.SetActive(false);
        reactionsText.SetActive(false);
        mask.SetActive(false);
        esc.SetActive(true);
        viewingScreen = false;
    }

    void OnCase1()
    {
        reflexesRecentText.enabled = true;
        reflexesHighText.enabled = true;
        reflexesAverageText.enabled = true;

        reactionsRecentText.enabled = true;
        reactionsHighText.enabled = true;
        reactionsAverageText.enabled = true;

        reflexesText.SetActive(true);
        reactionsText.SetActive(true);
        mask.SetActive(true);
        esc.SetActive(true);
        viewingScreen = true;
    }

    void OnCase2()
    {
        reflexesRecentText.enabled = true;
        reflexesHighText.enabled = true;
        reflexesAverageText.enabled = true;

        reactionsRecentText.enabled = true;
        reactionsHighText.enabled = true;
        reactionsAverageText.enabled = true;

        reflexesText.SetActive(true);
        reactionsText.SetActive(true);
        mask.SetActive(true);
        esc.SetActive(true);
        viewingScreen = true;
    }

}
