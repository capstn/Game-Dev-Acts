using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Characters.UserInterface;

namespace Characters.Control
{
    public class BumbirBlue: MonoBehaviour
    {
        [SerializeField] private Rigidbody2D character;

        private byte livesPlayer1 = 3;
        private int x;
        private int y;
        [SerializeField] private int speed;

        PlayerUserInterface playerObject = new PlayerUserInterface();

        private void Start() 
        {
            playerObject.LivesPlayer1 = livesPlayer1;
            playerObject.setUpLives();
            if (speed == 0) 
            {
                speed = 5;
            }
        }

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

        private void OnCollisionEnter2D(Collision2D collision) 
        {
            if (collision.gameObject.tag == "Explosion") 
            {
                if (livesPlayer1 != 0) 
                {
                    playerObject.hurtPlayer1();
                    livesPlayer1 -= 1;
                    playerObject.LivesPlayer1 = livesPlayer1;
                } 
                if (livesPlayer1 == 0)
                {
                    gameObject.SetActive(false);
                }
            }
            
        }
    
    }   
}