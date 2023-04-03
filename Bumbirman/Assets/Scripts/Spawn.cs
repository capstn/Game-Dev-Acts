using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject spawn1, spawn2;
    [SerializeField] private GameObject obj1, obj2;
    private int randomNumber;

    void Start()
    {
        randomNumber = Random.Range(1, 3);
        
        if (randomNumber == 1) 
        {
            set1();
        }
        else if (randomNumber == 2)
        {
             set2();
        }
        else 
        {
            set1();
        }
    }

    private void set1() 
    {
        Instantiate(obj1, spawn1.transform);
        Instantiate(obj2, spawn2.transform);
    }

    private void set2() 
    {
        Instantiate(obj2, spawn1.transform);
        Instantiate(obj1, spawn2.transform);
    }
}
