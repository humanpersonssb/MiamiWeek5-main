using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SplitKeyboardPlayerInputManager : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    private Dictionary<int, PlayerInput> existingPlayerInputs = new Dictionary<int, PlayerInput>();
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void JoinPlayer(int playerIndex, string controlScheme)
    {
        if (!existingPlayerInputs.ContainsKey(playerIndex))
        {
            var playerInput = PlayerInput.Instantiate(prefab, controlScheme: controlScheme, playerIndex: playerIndex, pairWithDevice: Keyboard.current);
            playerInput.SwitchCurrentControlScheme(controlScheme);
            existingPlayerInputs.Add(playerIndex, playerInput);
            SendMessage("OnPlayerJoined", playerInput);
            //playerInput.gameObject.SetActive(true);
        }
    }

    //TODO remove player from game and free up playerIndex in existingPlayerInputs
    public void LeavePlayer(int playerIndex)
    {
        var playerInput = existingPlayerInputs[playerIndex];


        Destroy(playerInput.gameObject);

        SendMessage("OnPlayerLeft", playerInput);
        existingPlayerInputs.Remove(playerIndex);
       // playerInput.gameObject.SetActive(false);
    }

    public void ReturnPlayer(int playerIndex)
    {
        var playerInput = existingPlayerInputs[playerIndex];
        playerInput.gameObject.SetActive(true);
    }
}
