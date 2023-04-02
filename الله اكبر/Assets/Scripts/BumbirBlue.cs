using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters.Control
{
    public class BumbirBlue: MonoBehaviour
    {
        [SerializeField] private Rigidbody2D character;

        private int x;
        private int y;
        private int speed = 10;

        private void Update() 
        {
            movePlayer();
        }

        private void movePlayer() 
        {
            if (Input.GetKey("a")) 
            {
                x = -1;
            }
            else if (Input.GetKey("d")) 
            {
                x = 1;
            }
            else {
                x = 0;
            }

            if (Input.GetKey("w")) 
            {
                y = 1;
            }
            else if (Input.GetKey("s")) 
            {
                y = -1;
            }
            else {
                y = 0;
            }

            character.velocity = new Vector2(x * speed, y *speed);
        }
    
    }   
}