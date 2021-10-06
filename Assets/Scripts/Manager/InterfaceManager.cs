using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    [SerializeField]
    private Button joinPlayerOne;

    [SerializeField]
    private Text player1txt;

    [SerializeField]
    private Text player2txt;

    [SerializeField]
    private Button joinPlayerTwo;
    //TODO: Add PlayerTwoButton reference

    [SerializeField]
    private SplitKeyboardPlayerInputManager playerInputManager;
    // Start is called before the first frame update

    private int x = 0;
    private int y = 0;
    void Start()
    {
        joinPlayerOne.onClick.AddListener(() => JoinPlayerOne());
        //TODO Listen for player two click event
        joinPlayerTwo.onClick.AddListener(() => JoinPlayerTwo());
    }

    private void JoinPlayerOne()
    {
        /*
        if (x == 0){
            playerInputManager.JoinPlayer(0, "Keyboard&Mouse");
            //TODO flip text to say "Leave Player One"

            //TODO on click after player has joined, remove player
            player1txt.text = "Leave Player One";

            x = 1;
        } else if(x == 2) {
            playerInputManager.ReturnPlayer(0);
            x = 1;
        } else {
            // text to make it destroy
            //destroy player
            playerInputManager.LeavePlayer(0);
            player1txt.text = "Join Player One";
            x = 2;
        } */


        if (x == 0)
        {
            playerInputManager.JoinPlayer(0, "Keyboard&Mouse");
            player1txt.text = "Leave Player One";
            Debug.Log("Player has Joined");
            x = 1;
        } else if (x == 1)
        {
            Debug.Log("Player has Left");
            playerInputManager.LeavePlayer(0);
            player1txt.text = "Join Player One";
            x = 0;
        }
    }


    private void JoinPlayerTwo()
    {
        /*
        if (y == 0)
        {
            playerInputManager.JoinPlayer(1, "PlayerTwo");
            //TODO flip text to say "Leave Player One"
            //TODO on click after player has joined, remove player
            player2txt.text = "Leave Player Two";

            y = 1;
        }
        else if (y == 2)
        {
            playerInputManager.ReturnPlayer(1);
            y = 1;
        }
        else
        {
            // text to make it destroy
            //destroy player
            playerInputManager.LeavePlayer(1);
            player2txt.text = "Join Player Two";
            y = 2;
        } */

        if (y == 0)
        {
            playerInputManager.JoinPlayer(1, "PlayerTwo");
            //TODO flip text to say "Leave Player One"
            //TODO on click after player has joined, remove player
            player2txt.text = "Leave Player Two";

            y = 1;
        } else if(y == 1)
        {
            playerInputManager.LeavePlayer(1);
            player2txt.text = "Join Player Two";
            y = 0;
        }
    }
    //TODO Invoke JoinPlayer passing a playerIndex value and targeting a control scheme
    //TODO flip text after player has joined to say "Leave Player Two"
    //TODO on click after player has joined, remove player
}
