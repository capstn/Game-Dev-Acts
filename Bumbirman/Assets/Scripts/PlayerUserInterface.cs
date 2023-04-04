using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Characters.UserInterface 
{
    public class PlayerUserInterface
    {
        private GameObject victoryBoard;
        private TextMeshProUGUI playerName;

        private GameObject playerOneHeartA;
        private GameObject playerOneHeartB;
        private GameObject playerOneHeartC;

        private GameObject playerTwoHeartA;
        private GameObject playerTwoHeartB;
        private GameObject playerTwoHeartC;

        private byte livesPlayer1;
        private byte livesPlayer2;

        public void setUpBoard() 
        {
            playerName = GameObject.Find("PlayerName").GetComponent<TextMeshProUGUI>();
            victoryBoard = GameObject.Find("VictoryBoard");
            victoryBoard.SetActive(false);
        }

        public void setUpLives() 
        {
            playerOneHeartA = GameObject.Find("PlayerOneHeart1");
            playerOneHeartB = GameObject.Find("PlayerOneHeart2");
            playerOneHeartC = GameObject.Find("PlayerOneHeart3");

            playerTwoHeartA = GameObject.Find("PlayerTwoHeart1");
            playerTwoHeartB = GameObject.Find("PlayerTwoHeart2");
            playerTwoHeartC = GameObject.Find("PlayerTwoHeart3");

        }

        public void hurtPlayer1() 
        {
            switch (livesPlayer1) 
            {
                case 1:
                    playerOneHeartA.SetActive(false);
                    break;
                case 2:
                    playerOneHeartB.SetActive(false);
                    break;
                case 3:
                    playerOneHeartC.SetActive(false);
                    break;
                default:
                    break;
            }

        }

        public void hurtPlayer2() 
        {
            switch (livesPlayer2) 
            {
                case 1:
                    playerTwoHeartA.SetActive(false);
                    break;
                case 2:
                    playerTwoHeartB.SetActive(false);
                    break;
                case 3:
                    playerTwoHeartC.SetActive(false);
                    break;
                default:
                    break;
            }

        }

        public byte LivesPlayer1 
        {
            set 
            {
                livesPlayer1 = value;
            } 
            get 
            {
                return livesPlayer1;
            }
        }
        
        public byte LivesPlayer2 
        {
            set 
            {
                livesPlayer2 = value;
            }
            get 
            {
                return livesPlayer2;
            }
        }

        public void openVictoryBoard() 
        {
            victoryBoard.SetActive(true);
        }

        public void setPlayerName(string playerName) 
        {
            this.playerName.text = playerName;
        }
    }
}
