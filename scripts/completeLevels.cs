using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class completeLevels : MonoBehaviour
{
    public List<bool> levelComplete;
    public List<GameObject> checks;
    public List<GameObject> crosses;
    public List<int> levelsCompletedTotal; //total levels, beginner levels
    public List<Text> lockedLevelCounters;
    public List<GameObject> levelsLockedBlocker;
    public GameObject[] menuButtons;
    public bool fileExists;


    private void Awake()
    {
        LoadPlayer();
        changemarks();
    }
    private void Start()
    {
        int levelCount = 5;
        for (int i = 0; i < lockedLevelCounters.Count; i++)
        {
            lockedLevelCounters[i].text = levelsCompletedTotal[0].ToString() + " / " + levelCount.ToString();
            levelCount += 5;
            //Debug.Log(levelsCompletedTotal[i + 1]);
        }
    }

    public void SavePlayer()
    {
        fileExists = true;
        saveData.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        try
        {
            PlayerData data = saveData.LoadPlayer();
            fileExists = data.fileExists;

            levelComplete = new List<bool>(data.levelComplete);
        }
        catch
        {

        }
        /*for(int i =0; i < data.levelComplete.Count; i++)
        {
            levelComplete[i] = data.levelComplete[i];
        }*/
    }
    public void changemarks()  //at game start when save data loaded
    {
        for(int i =0; i < levelComplete.Count; i++) //this entire void needs updated when game finished
        {
            if(levelComplete[i])
            {
                checks[i].SetActive(true);
                crosses[i].SetActive(false);
                levelsCompletedTotal[0]++;
                if(i >= 0 && i <= 4)
                {
                    levelsCompletedTotal[1]++;
                    menuButtons[0].GetComponent<menuButtonsNumberCounter>().currentButton++;
                }
                else if (i >= 5 && i <= 9)
                {
                    levelsCompletedTotal[2]++;
                    menuButtons[1].GetComponent<menuButtonsNumberCounter>().currentButton++;
                }
                else if (i >= 10 && i <= 14)
                {
                    levelsCompletedTotal[3]++;
                    menuButtons[2].GetComponent<menuButtonsNumberCounter>().currentButton++;
                }
                else if (i >= 15 && i <= 19)
                {
                    levelsCompletedTotal[4]++;
                    menuButtons[3].GetComponent<menuButtonsNumberCounter>().currentButton++;
                }
                else if (i >= 20 && i <= 24)
                {
                    levelsCompletedTotal[5]++;
                    menuButtons[4].GetComponent<menuButtonsNumberCounter>().currentButton++;
                }
                else if (i >= 25 && i <= 29)
                {
                    levelsCompletedTotal[6]++;
                    menuButtons[5].GetComponent<menuButtonsNumberCounter>().currentButton++;
                }
                else if (i >= 30 && i <= 34)
                {
                    levelsCompletedTotal[7]++;
                    menuButtons[6].GetComponent<menuButtonsNumberCounter>().currentButton++;
                }
                else if (i >= 35 && i <= 39)
                {
                    levelsCompletedTotal[8]++;
                    menuButtons[7].GetComponent<menuButtonsNumberCounter>().currentButton++;
                }
                else if (i >= 40 && i <= 44)
                {
                    levelsCompletedTotal[9]++;
                    menuButtons[8].GetComponent<menuButtonsNumberCounter>().currentButton++;
                }
                else if (i >= 45 && i <= 49)
                {
                    levelsCompletedTotal[10]++;
                    menuButtons[19].GetComponent<menuButtonsNumberCounter>().currentButton++;
                }
                UnlockButton();
            }
        }
    }

    public void updateMarks(int listPos, int difficulty)
    {
        if (!levelComplete[listPos])
        {
            levelComplete[listPos] = true;
            checks[listPos].SetActive(true);
            crosses[listPos].SetActive(false);
            levelsCompletedTotal[0]++;
            levelsCompletedTotal[difficulty + 1]++;
            menuButtons[difficulty].GetComponent<menuButtonsNumberCounter>().currentButton++;
            menuButtons[difficulty].GetComponent<menuButtonsNumberCounter>().changeButton();
            UnlockButton();
            int levelCount = 5;
            for (int i = 0; i < lockedLevelCounters.Count; i++)
            {
                lockedLevelCounters[i].text = levelsCompletedTotal[0].ToString() + " / " + levelCount.ToString();
                levelCount += 5;
                //Debug.Log(levelsCompletedTotal[i + 1]);
            }
        }
    }

    void UnlockButton()
    {
        if (levelsCompletedTotal[0] == 5)
        {
            unlockButtons(0, 2);
        }
        else if (levelsCompletedTotal[0] == 10)
        {
            unlockButtons(1, 3);
        }
        else if (levelsCompletedTotal[0] == 15)
        {
            unlockButtons(2, 4);
        }
        else if (levelsCompletedTotal[0] == 20)
        {
            unlockButtons(3, 5);
        }
        else if (levelsCompletedTotal[0] == 25)
        {
            unlockButtons(4, 6);
        }
        else if (levelsCompletedTotal[0] == 30)
        {
            unlockButtons(5, 7);
        }
        else if (levelsCompletedTotal[0] == 35)
        {
            unlockButtons(6, 8);
        }
        else if (levelsCompletedTotal[0] == 40)
        {
            unlockButtons(7, 9);
        }
    }

    void unlockButtons(int blocker, int menubutton)
    {
        levelsLockedBlocker[blocker].SetActive(false);
        menuButtons[menubutton].GetComponent<Button>().interactable = true;
    }
}
