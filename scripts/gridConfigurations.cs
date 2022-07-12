using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridConfigurations : MonoBehaviour
{
    [System.Serializable]
    public class makelist
    {
        public List<int> boardNumbers;
    }
    public List<makelist> allValues = new List<makelist>();


    [System.Serializable]
    public class buttonsNeeded
    {
        public List<bool> activeNumbers;
    }
    public List<buttonsNeeded> allActiveNumbers = new List<buttonsNeeded>();
}
