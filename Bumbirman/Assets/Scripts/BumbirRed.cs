using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Characters.UserInterface;

namespace Characters.Control
{
    public class BumbirRed: MonoBehaviour
    {
        [SerializeField] private GameObject enemy;
        [SerializeField] private Rigidbody2D character;

        private byte livesPlayer2 = 3;
        private int x;
        private int y;
        [SerializeField] private int speed;

        PlayerUserInterface playerObject = new PlayerUserInterface();

        private void Start() 
        {
            playerObject.LivesPlayer2 = livesPlayer2;
            playerObject.setUpLives();
            if (speed == 0) 
            {
                speed = 5;
            }
        }

        private void Update() 
        {
            if (enemy.activeSelf == true) 
            {
                movePlayer();
            }
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

        private void OnCollisionEnter2D(Collision2D collision) 
        {
            if (collision.gameObject.tag == "Explosion") 
            {
                if (livesPlayer2 != 0) 
                {
                    playerObject.hurtPlayer2();
                    livesPlayer2 -= 1;
                    playerObject.LivesPlayer2 = livesPlayer2;
                } 
                if (livesPlayer2 == 0)
                {
                    gameObject.SetActive(false);
                }
            }
            
        }
    
    }   
}