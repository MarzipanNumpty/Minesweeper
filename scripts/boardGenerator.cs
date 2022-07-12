using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class boardGenerator : MonoBehaviour
{
    public List<GameObject> buttons;
    public List<int> boardValues;
    public List<int> playerBoardValues;
    public GameObject blankButton;
    public int sizeOfBoardHorizontal;
    public int sizeOfBoardVertical;
    public Vector3 startPos; //0,0 is bottom left corner can be changed once size of tiles has been chosen
    public Vector3 currentPos; 
    public float horizontalAdditive; 
    public float verticalAdditive;
    public Transform canvasParent;
    public int buttonNum;
    public GameObject num0;
    public GameObject num1;
    public GameObject num2;
    public GameObject num3;
    public GameObject num4;
    public GameObject num5;
    public GameObject num6;
    public GameObject num7;
    public GameObject num8;
    public GameObject bomb;
    public Text totalBombs;
    public Text bombsLeft;
    public int bombCount;
    public int playerBombCount;
    public bool bombRemoved;
    public GameObject winButton;
    public int currentLevel;
    public GameObject levelCompleteGameObject;
    completeLevels levelCompleteScript;
    public List<bool> whichDifficulty; //beginner, ...
    public GameObject[] numberButtons;
    public List<bool> activeButtons;
    bool listNotIdentical;
    int currentListPlace;
    public GameObject loseButton;
    public GameObject rewardButton;


    private void Start()
    {
        levelCompleteScript = levelCompleteGameObject.GetComponent<completeLevels>();
    }
    public void makeGrid()
    {
        for(int i = 0; i < activeButtons.Count; i++)
        {
            if(!activeButtons[i])
            {
                numberButtons[i].GetComponent<Button>().interactable = false;
            }
            else
            {
                numberButtons[i].GetComponent<Button>().interactable = true;
            }
        }
        playerBombCount = bombCount;
        totalBombs.text = "Total Bombs: " + bombCount.ToString();
        bombsLeft.text = "Bombs Left: " + playerBombCount.ToString();
        if(sizeOfBoardHorizontal == 2)
        {
            startPos.x = -50;
        }
        else if(sizeOfBoardHorizontal == 3)
        {
            startPos.x = -100;
        }
        else if(sizeOfBoardHorizontal == 4)
        {
            startPos.x = -150;
        }
        else if(sizeOfBoardHorizontal == 5)
        {
            startPos.x = -200;
        }
        else if(sizeOfBoardHorizontal == 6)
        {
            startPos.x = -250;
        }
        else if (sizeOfBoardHorizontal == 7)
        {
            startPos.x = -300;
        }

        if(sizeOfBoardVertical == 2 || sizeOfBoardVertical == 3)
        {
            startPos.y = -150;
        }
        else if (sizeOfBoardVertical == 4)
        {
            startPos.y = -200;
        }
        else if(sizeOfBoardVertical == 5)
        {
            startPos.y = -250;
        }
        else if(sizeOfBoardVertical == 6)
        {
            startPos.y = -320;
        }
        else if (sizeOfBoardVertical == 7)
        {
            startPos.y = -370;
        }
        currentPos = startPos;
        /*Debug.Log(buttons[0]);
        Debug.Log(buttons[1]);
        Debug.Log(buttons[2]);
        Debug.Log(buttons[3]);*/
        //Vector3 currentPos = startPos;
        GameObject currentGameobject = null;
        for(int i=0; i < sizeOfBoardHorizontal*sizeOfBoardVertical; i++)
        {
            playerBoardValues.Add(0);
            if(i != 0)
            {
                if (i % sizeOfBoardHorizontal == 0)
                {
                    currentPos = new Vector3(startPos.x, currentPos.y + verticalAdditive);
                }
                else
                {
                    currentPos = new Vector3(currentPos.x + horizontalAdditive, currentPos.y);
                }
            }
            //Debug.Log(currentPos);
            currentGameobject = Instantiate(blankButton,currentPos, transform.rotation);
            currentGameobject.transform.position = currentPos;
            currentGameobject.transform.SetParent(canvasParent, false);
            currentGameobject.GetComponent<buttonValueHolder>().value = i;
           /* if(i == 0)
            {
                currentGameobject.SetActive(false);
                continue;
            }*/
            if(boardValues[i] == 0)
            {
                currentGameobject.GetComponent<Button>().interactable = false;
                //GameObject numPlacement = Instantiate(num0, currentGameobject.transform.position, currentGameobject.transform.rotation);
                //numPlacement.transform.SetParent(currentGameobject.transform.parent, false);
            }
            else
            {
                currentGameobject.GetComponent<Button>().onClick.AddListener(markNumber);
            }
            //currentGameobject.GetComponent<Button>().onClick.AddListener(markNumber);
            buttons.Add(currentGameobject);
           //Debug.Log(i % sizeOfBoardHorizontal);
        }
    }

    public void checkNumbers(bool autoComplete)
    {
        //var listsHaveBeenChecked = checkLists();
        if(autoComplete)
        {
            int num = 0;
            for (int i = 0; i < whichDifficulty.Count; i++)
            {
                if (whichDifficulty[i])
                {
                    num = i;
                    break;
                }
            }
            winButton.SetActive(true);
            loseButton.SetActive(false);
            rewardButton.SetActive(false);
            levelCompleteScript.updateMarks(currentLevel, num);
        }
        else
        {
            if (checkLists())
            {
                int num = 0;
                Debug.Log("lists are identical");
                for (int i = 0; i < whichDifficulty.Count; i++)
                {
                    if (whichDifficulty[i])
                    {
                        num = i;
                        break;
                    }
                }
                winButton.SetActive(true);
                levelCompleteScript.updateMarks(currentLevel, num);
            }
            else
            {
                loseButton.SetActive(true);
            }
        }
    }

    bool checkLists()
    {
        currentListPlace = 0;
        bool checker = false;
        for (int i = 0; i < boardValues.Count; i++)
        {
            int num = sizeOfBoardHorizontal * sizeOfBoardVertical;
            if (i % num == 0 && i !=0)
            {
                if(!checker)
                {
                    return true;
                }
                currentListPlace = currentListPlace - sizeOfBoardHorizontal * sizeOfBoardVertical;
                checker = false;
            }
            if (boardValues[i] != playerBoardValues[currentListPlace])
            {
                checker = true;
            }
            currentListPlace++;
        }
        if (!checker)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /*bool checkLists()
    {
        for (int i = 0; i < boardValues.Count; i++)
        {
            if (boardValues[i] != playerBoardValues[i])
            {
                return false;
            }
        }
        return true;
    }*/

    void markNumber()
    {
        GameObject currentButton = EventSystem.current.currentSelectedGameObject;
        //currentButton.GetComponent<buttonValueHolder>().value = buttonNum;
        playerBoardValues[currentButton.GetComponent<buttonValueHolder>().value] = buttonNum;
        if(buttonNum == 1)
        {
            if(currentButton.transform.childCount != 0)
            {
                if(currentButton.transform.GetChild(0).name == "bomb(Clone)")
                {
                    playerBombCount++;
                }
                foreach (Transform child in currentButton.transform)
                {
                    Destroy(child.gameObject);
                }
                //Destroy(currentButton.transform.GetChild(0).gameObject);
            }
            GameObject numPlacement = Instantiate(num1, currentButton.transform.position, currentButton.transform.rotation);
            numPlacement.transform.SetParent(currentButton.transform, false);
            numPlacement.transform.localPosition = new Vector3(0, 0, 0);
        }
        else if(buttonNum == 2)
        {
            if (currentButton.transform.childCount != 0)
            {
                if (currentButton.transform.GetChild(0).name == "bomb(Clone)")
                {
                    playerBombCount++;
                }
                foreach (Transform child in currentButton.transform)
                {
                    Destroy(child.gameObject);
                }
                //Destroy(currentButton.transform.GetChild(0).gameObject);
            }
            GameObject numPlacement = Instantiate(num2, currentButton.transform.position, currentButton.transform.rotation);
            numPlacement.transform.SetParent(currentButton.transform, false);
            numPlacement.transform.localPosition = new Vector3(0, 0, 0);
        }
        else if (buttonNum == 3)
        {
            if (currentButton.transform.childCount != 0)
            {
                if (currentButton.transform.GetChild(0).name == "bomb(Clone)")
                {
                    playerBombCount++;
                }
                foreach (Transform child in currentButton.transform)
                {
                    Destroy(child.gameObject);
                }
                //Destroy(currentButton.transform.GetChild(0).gameObject);
            }
            GameObject numPlacement = Instantiate(num3, currentButton.transform.position, currentButton.transform.rotation);
            numPlacement.transform.SetParent(currentButton.transform, false);
            numPlacement.transform.localPosition = new Vector3(0, 0, 0);
        }
        else if (buttonNum == 4)
        {
            if (currentButton.transform.childCount != 0)
            {
                if (currentButton.transform.GetChild(0).name == "bomb(Clone)")
                {
                    playerBombCount++;
                }
                foreach (Transform child in currentButton.transform)
                {
                    Destroy(child.gameObject);
                }
                //Destroy(currentButton.transform.GetChild(0).gameObject);
            }
            GameObject numPlacement = Instantiate(num4, currentButton.transform.position, currentButton.transform.rotation);
            numPlacement.transform.SetParent(currentButton.transform, false);
            numPlacement.transform.localPosition = new Vector3(0, 0, 0);
        }
        else if (buttonNum == 5)
        {
            if (currentButton.transform.childCount != 0)
            {
                if (currentButton.transform.GetChild(0).name == "bomb(Clone)")
                {
                    playerBombCount++;
                }
                foreach (Transform child in currentButton.transform)
                {
                    Destroy(child.gameObject);
                }
                //Destroy(currentButton.transform.GetChild(0).gameObject);
            }
            GameObject numPlacement = Instantiate(num5, currentButton.transform.position, currentButton.transform.rotation);
            numPlacement.transform.SetParent(currentButton.transform, false);
            numPlacement.transform.localPosition = new Vector3(0, 0, 0);
        }
        else if (buttonNum == 6)
        {
            if (currentButton.transform.childCount != 0)
            {
                if (currentButton.transform.GetChild(0).name == "bomb(Clone)")
                {
                    playerBombCount++;
                }
                foreach (Transform child in currentButton.transform)
                {
                    Destroy(child.gameObject);
                }
                //Destroy(currentButton.transform.GetChild(0).gameObject);
            }
            GameObject numPlacement = Instantiate(num6, currentButton.transform.position, currentButton.transform.rotation);
            numPlacement.transform.SetParent(currentButton.transform, false);
            numPlacement.transform.localPosition = new Vector3(0, 0, 0);
        }
        else if (buttonNum == 7)
        {
            if (currentButton.transform.childCount != 0)
            {
                if (currentButton.transform.GetChild(0).name == "bomb(Clone)")
                {
                    playerBombCount++;
                }
                foreach(Transform child in currentButton.transform)
                {
                    Destroy(child.gameObject);
                }
                //Destroy(currentButton.transform.GetChild(0).gameObject);
            }
            GameObject numPlacement = Instantiate(num7, currentButton.transform.position, currentButton.transform.rotation);
            numPlacement.transform.SetParent(currentButton.transform, false);
            numPlacement.transform.localPosition = new Vector3(0, 0, 0);
        }
        else if (buttonNum == 8)
        {
            if (currentButton.transform.childCount != 0)
            {
                if (currentButton.transform.GetChild(0).name == "bomb(Clone)")
                {
                    playerBombCount++;
                }
                foreach (Transform child in currentButton.transform)
                {
                    Destroy(child.gameObject);
                }
                //Destroy(currentButton.transform.GetChild(0).gameObject);
            }
            GameObject numPlacement = Instantiate(num8, currentButton.transform.position, currentButton.transform.rotation);
            numPlacement.transform.SetParent(currentButton.transform, false);
            numPlacement.transform.localPosition = new Vector3(0, 0, 0);
        }
        else if (buttonNum == 9)
        {
            if (currentButton.transform.childCount != 0)
            {
                if (currentButton.transform.GetChild(0).name == "bomb(Clone)")
                {
                    playerBombCount++;
                }
                foreach (Transform child in currentButton.transform)
                {
                    Destroy(child.gameObject);
                }
                //Destroy(currentButton.transform.GetChild(0).gameObject);
            }
            GameObject numPlacement = Instantiate(bomb, currentButton.transform.position, currentButton.transform.rotation);
            numPlacement.transform.SetParent(currentButton.transform, false);
            numPlacement.transform.localPosition = new Vector3(0, 0, 0);
            playerBombCount--;
        }
        else if(buttonNum == 0)
        {
            if (currentButton.transform.childCount != 0)
            {
                if (currentButton.transform.GetChild(0).name == "bomb(Clone)")
                {
                    playerBombCount++;
                }
                foreach (Transform child in currentButton.transform)
                {
                    Destroy(child.gameObject);
                }
                //Destroy(currentButton.transform.GetChild(0).gameObject);
            }
        }
        bombsLeft.text = "Bombs Left: " + playerBombCount.ToString();
    }

    public void number0()
    {
        buttonNum = 0;
    }

    public void number1()
    {
        buttonNum = 1;
    }

    public void number2()
    {
        buttonNum = 2;
    }

    public void number3()
    {
        buttonNum = 3;
    }

    public void number4()
    {
        buttonNum = 4;
    }

    public void number5()
    {
        buttonNum = 5;
    }

    public void number6()
    {
        buttonNum = 6;
    }

    public void number7()
    {
        buttonNum = 7;
    }

    public void number8()
    {
        buttonNum = 8;
    }

    public void placeBomb()
    {
        buttonNum = 9;
    }

}
