using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D explosion) 
    {
        if (explosion.gameObject.tag == "Destructible") 
        {
            
        }
        if (explosion.gameObject.name == "BumbirBlue") 
        {
            Debug.Log("You died");
        }
    }
}
