using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public List<bool> levelComplete;
    public bool fileExists;

    public PlayerData (completeLevels level)
    {
        //levelComplete = new List<bool>(levels.levelComplete.Count);
        /*for (int i = 0; i < level.levelComplete.Count; i++)
        {
            Debug.Log(i);
            levelComplete.Add(level.levelComplete[i]);
        }*/
        //fileExists = level.fileExists;
        fileExists = level.fileExists;
        levelComplete = new List<bool>(level.levelComplete);
    }
}
