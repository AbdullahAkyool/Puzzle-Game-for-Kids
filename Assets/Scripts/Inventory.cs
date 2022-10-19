using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;

    public List<GameObject> PlayerMoveCards;

    public PlayerMovement playerMovement;

    //public delegate void MovementPlayer();

    //public MovementPlayer _movementPlayer;

    public Button GoButton;


    //SLOT CONTROL and ADD FUNCTIONS TO DELEGATE
    public void PlayerChoices()
    {
        for (int i = 0; i < PlayerMoveCards.Count; i++)
        {
            if (PlayerMoveCards[i].gameObject.CompareTag("Direct"))
            {
                playerMovement.MoveDirect();
            }
            else if (PlayerMoveCards[i].gameObject.CompareTag("Right"))
            {
                playerMovement.MoveRight();
            }
            else if (PlayerMoveCards[i].gameObject.CompareTag("Left"))
            {
                playerMovement.MoveLeft();
            }
            else if (PlayerMoveCards[i].gameObject.CompareTag("Jump"))
            {
                playerMovement.Jump();
            }
            else if (PlayerMoveCards[i].gameObject.CompareTag("Press"))
            {
                // _movementPlayer += playerMovement.Press;
                playerMovement.Press();
            }
        }

        playerMovement.PlayMoves();
    }

    public void SlotControlAndGo()
    {
        PlayerChoices();
        
        GoButton.enabled = false;
        
        //_movementPlayer();
    }

    public void ResetGame()
    {
        //PlayerMoveCards.Clear();
        SceneManager.LoadScene("Test2");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
