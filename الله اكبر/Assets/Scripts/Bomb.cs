using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float detonationTime = 3;
    private bool detonated = false;

    private void Start() 
    {
        detonated = true;
    }

    private void Update() 
    {
        if (detonated == true) 
        {
            Destroy(gameObject, detonationTime);
        }
    }

}
