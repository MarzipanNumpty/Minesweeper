using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject levelSelectCanvas;
    public GameObject tutorialCanvas;
    public GameObject[] levelCanvas;
    public GameObject gameBoardCanvas;
    public GameObject gridConfigGameobject;
    gridConfigurations gridConfigScript;
    public GameObject boardGeneratorGameobject;
    boardGenerator boardGeneratorScript;
    public GameObject buttonHolder;
    GameObject currentCanvas;

    public void Awake()
    {
        gridConfigScript = gridConfigGameobject.GetComponent<gridConfigurations>();
        boardGeneratorScript = boardGeneratorGameobject.GetComponent<boardGenerator>();
    }


    public void closeMainMenu()
    {
        mainMenuCanvas.SetActive(false);
        levelSelectCanvas.SetActive(true);
    }

    public void openMainMenu()
    {
        mainMenuCanvas.SetActive(true);
        levelSelectCanvas.SetActive(false);
    }
    public void openTutorial()
    {
        mainMenuCanvas.SetActive(false);
        tutorialCanvas.SetActive(true);
    }

    public void closeTutorial()
    {
        mainMenuCanvas.SetActive(true);
        tutorialCanvas.SetActive(false);
    }

    public void openLevelSelect(int level)
    {
        levelSelectCanvas.SetActive(false);
        levelCanvas[level].SetActive(true);
    }

    public void closeLevelSelect(int level)
    {
        levelSelectCanvas.SetActive(true);
        levelCanvas[level].SetActive(false);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void OpenLevel()
    {
        createGrid(0, 2, 2, 1, 0);
    }

    public void OpenLevel2()
    {
        createGrid(1, 2, 2, 2, 0);
    }

    public void OpenLevel3()
    {
        createGrid(2, 2, 2, 3, 0);
    }

    public void OpenLevel4()
    {
        createGrid(3, 3, 3, 1, 0);
    }

    public void OpenLevel5()
    {
        createGrid(4, 3, 3, 8, 0);
    }

    public void OpenLevel6()
    {
        createGrid(5, 3, 3, 1, 1);
    }

    public void OpenLevel7()
    {
        createGrid(6, 4, 3, 2, 1);
    }

    public void OpenLevel8()
    {
        createGrid(7, 5, 5, 1, 1);
    }

    public void OpenLevel9()
    {
        createGrid(8, 5, 5, 1, 1);
    }

    public void OpenLevel10()
    {
        createGrid(9, 4, 2, 4, 1);
    }

    public void OpenLevel11()
    {
        createGrid(10, 3, 2, 2, 2);
    }

    public void OpenLevel12()
    {
        createGrid(11, 3, 3, 3, 2);
    }

    public void OpenLevel13()
    {
        createGrid(12, 2, 3, 5, 2);
    }

    public void OpenLevel14()
    {
        createGrid(13, 3, 3, 7, 2);
    }

    public void OpenLevel15()
    {
        createGrid(14, 3, 2, 4, 2);
    }

    public void OpenLevel16()
    {
        createGrid(15, 5, 3, 5, 3);
    }

    public void OpenLevel17()
    {
        createGrid(16, 3, 3, 4, 3);
    }

    public void OpenLevel18()
    {
        createGrid(17, 5, 5, 2, 3);
    }

    public void OpenLevel19()
    {
        createGrid(18, 5, 4, 2, 3);
    }

    public void OpenLevel20()
    {
        createGrid(19, 3, 3, 3, 3);
    }

    public void OpenLevel21()
    {
        createGrid(20, 5, 3, 2, 4);
    }

    public void OpenLevel22()
    {
        createGrid(21, 4, 4, 2, 4);
    }

    public void OpenLevel23()
    {
        createGrid(22, 3, 5, 3, 4);
    }

    public void OpenLevel24()
    {
        createGrid(23, 3, 3, 5, 4);
    }

    public void OpenLevel25()
    {
        createGrid(24, 3, 6, 4, 4);
    }

    public void OpenLevel26()
    {
        createGrid(25, 3, 3, 6, 5);
    }

    public void OpenLevel27()
    {
        createGrid(26,4,4,4,5);
    }

    public void OpenLevel28()
    {
        createGrid(27, 3, 3, 5, 5);
    }

    public void OpenLevel29()
    {
        createGrid(28, 3, 4, 6, 5);
    }

    public void OpenLevel30()
    {
        createGrid(29, 7, 3, 6, 5);
    }

    public void OpenLevel31()
    {
        createGrid(30, 5, 5, 4, 6);
    }

    public void OpenLevel32()
    {
        createGrid(31, 7, 7, 8, 6);
    }

    public void OpenLevel33()
    {
        createGrid(32, 4, 3, 5, 6);
    }

    public void OpenLevel34()
    {
        createGrid(33, 4, 3, 6, 6);
    }

    public void OpenLevel35()
    {
        createGrid(34, 3, 3, 5, 6);
    }

    public void OpenLevel36()
    {
        createGrid(35, 3, 4, 7, 7);
    }

    public void OpenLevel37()
    {
        createGrid(36, 4, 4, 7, 7);
    }

    public void OpenLevel38()
    {
        createGrid(37, 5, 4, 5, 7);
    }

    public void OpenLevel39()
    {
        createGrid(38, 6, 6, 12, 7);
    }

    public void OpenLevel40()
    {
        createGrid(39, 5, 6, 10, 7);
    }

    public void OpenLevel41()
    {
        createGrid(40, 5, 4, 8, 8);
    }

    public void OpenLevel42()
    {
        createGrid(41, 4, 4, 8, 8);
    }

    public void OpenLevel43()
    {
        createGrid(42, 5, 4, 11, 8);
    }

    public void OpenLevel44()
    {
        createGrid(43, 4, 4, 7, 8);
    }

    public void OpenLevel45()
    {
        createGrid(44, 7, 6, 9, 8);
    }

    public void OpenLevel46()
    {
        createGrid(45, 5, 4, 12, 9);
    }

    public void OpenLevel47()
    {
        createGrid(46, 5, 5, 12, 9);
    }

    public void OpenLevel48()
    {
        createGrid(47, 5, 5, 12, 9);
    }

    public void OpenLevel49()
    {
        createGrid(48, 5, 5, 20, 9);
    }

    public void OpenLevel50()
    {
        createGrid(49, 5, 5, 16, 9);
    }

    public void createGrid(int listNum, int horizontal, int vertical, int bombs, int difficulty)
    {
        currentCanvas = levelCanvas[difficulty];
        levelCanvas[difficulty].SetActive(false);
        for (int i =0; i < boardGeneratorScript.whichDifficulty.Count; i++)
        {
            if(boardGeneratorScript.whichDifficulty[i])
            {
                boardGeneratorScript.whichDifficulty[i] = false;
                break;
            }
        }
        boardGeneratorScript.whichDifficulty[difficulty] = true;
        boardGeneratorScript.currentLevel = listNum;
        boardGeneratorScript.bombCount = bombs;
        boardGeneratorScript.sizeOfBoardHorizontal = horizontal;
        boardGeneratorScript.sizeOfBoardVertical = vertical;
        boardGeneratorScript.boardValues = new List<int>(gridConfigScript.allValues[listNum].boardNumbers);
        boardGeneratorScript.activeButtons = new List<bool>(gridConfigScript.allActiveNumbers[listNum].activeNumbers);
        boardGeneratorScript.makeGrid();
        gameBoardCanvas.SetActive(true);
    }

    public void closeLevel()
    {
        foreach (Transform child in buttonHolder.transform)
        {
            Destroy(child.gameObject);
        }
        boardGeneratorScript.boardValues.Clear();
        boardGeneratorScript.buttons.Clear();
        boardGeneratorScript.playerBoardValues.Clear();
        boardGeneratorScript.winButton.SetActive(false);
        gameBoardCanvas.SetActive(false);
        currentCanvas.SetActive(true);
    }
}
