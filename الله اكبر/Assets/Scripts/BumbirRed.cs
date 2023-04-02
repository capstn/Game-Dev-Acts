using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters.Control
{
    public class BumbirRed: MonoBehaviour
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
            if (Input.GetKey("left")) 
            {
                x = -1;
            }
            else if (Input.GetKey("right")) 
            {
                x = 1;
            }
            else {
                x = 0;
            }

            if (Input.GetKey("up")) 
            {
                y = 1;
            }
            else if (Input.GetKey("down")) 
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