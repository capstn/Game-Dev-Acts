using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Characters.UserInterface;

namespace Characters.GameMechanics 
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private GameObject player1;
        [SerializeField] private GameObject player2;
        [SerializeField] private GameObject bomb;
        [SerializeField] private Transform playerPosition1;
        [SerializeField] private GameObject playerBomb1;
        [SerializeField] private Transform playerPosition2;
        [SerializeField] private GameObject playerBomb2;

        PlayerUserInterface userInterface = new PlayerUserInterface();

        private bool gameOn = true;

        private float timer1 = 4;
        private float timer2 = 4;

        private byte bombsPlacedPlayer1 = 0;
        private byte bombsPlacedPlayer2 = 0;

        private void Start() 
        {
            userInterface.setUpBoard();
        }

        private void Update() 
        {
            if (player1.activeSelf == false) 
            {
                gameOn = false;
                userInterface.setPlayerName("Player 2 Wins!");
            }
            if (player2.activeSelf == false) 
            {
                gameOn = false;
                userInterface.setPlayerName("Player 1 Wins!");
            }

            if (gameOn == true) 
            {
                if (Input.GetKeyDown(KeyCode.LeftShift) && bombsPlacedPlayer1 < 3) 
                {
                    playerBomb1.SetActive(true);
                    placeBombPlayer1();
                } 
                else if (bombsPlacedPlayer1 == 3) 
                {
                    playerBomb1.SetActive(false);
                }

                if (Input.GetKeyDown(KeyCode.RightShift) && bombsPlacedPlayer2 < 3) 
                {
                    playerBomb2.SetActive(true);
                    placeBombPlayer2();
                } 
                else if (bombsPlacedPlayer2 == 3) 
                {
                    playerBomb2.SetActive(false);
                }

                if (bombsPlacedPlayer1 == 3) 
                {
                    timer1 -= Time.deltaTime;

                    if(timer1 <= 0) 
                    {
                        refreshBombs1();
                    }
                }

                if (bombsPlacedPlayer2 == 3) 
                {
                    timer2 -= Time.deltaTime;

                    if(timer2 <= 0) 
                    {
                        refreshBombs2();
                    }
                }
            }

            if (gameOn == false) 
            {
                userInterface.openVictoryBoard();
            }
        }

        private void placeBombPlayer1(/*GameObject bomb,Transform playerPosition*/) 
        {
            Instantiate(bomb, new Vector2(playerPosition1.transform.position.x, playerPosition1.transform.position.y), Quaternion.identity);
            bombsPlacedPlayer1 += 1;
        }

        private void placeBombPlayer2(/*GameObject bomb,Transform playerPosition*/) 
        {
            Instantiate(bomb, new Vector2(playerPosition2.transform.position.x, playerPosition2.transform.position.y), Quaternion.identity);
            bombsPlacedPlayer2 += 1;
        }

        private void refreshBombs1() 
        {
            bombsPlacedPlayer1 = 0;
            timer1 = 4;
            playerBomb1.SetActive(true);
        }

        private void refreshBombs2() 
        {
            bombsPlacedPlayer2 = 0;
            timer2 = 4;
            playerBomb2.SetActive(true);
        }

        public void playAgain() 
        {
            SceneManager.LoadScene("Level_1");
        }
    }
}
