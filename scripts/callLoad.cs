using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callLoad : MonoBehaviour
{
    public GameObject saveObject;
    private void Awake()
    {
        saveObject.GetComponent<completeLevels>().LoadPlayer();
    }
}
