using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private GameObject explosionRange;
    [SerializeField] private float detonationTime = 4;
    private bool detonated = false;

    private void Start() 
    {
        detonated = true;
    }

    private void Update() 
    {
        if (detonated == true) 
        {
            detonationTime -= Time.deltaTime;

            if (detonationTime <= .5) 
            {
                explosionRange.SetActive(true);
            }
            if (detonationTime <= 0) 
            {
                Destroy(gameObject);
            }
        }
    }
}
