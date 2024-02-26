using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    //variable holding current game state
    public int stateInt = 1;

    //reference for door object
    public GameObject door;
    //reference for door spawn position
    [SerializeField] private Transform spawnDoorPosition;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        //update game state on start
        UpdateGameState(stateInt);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            stateInt = 4;
            UpdateGameState(stateInt);
        }
    }

    public void UpdateGameState(int newInt)
    {
        stateInt = newInt;

        switch (newInt)
        {
            case 1:
                break;
            case 2:
                //spawn phase 2 enemies?
                break;
            case 3:
                //spawn phase 3 enemies?
                break;
            case 4:
                SpawnDoor();
                break; 
            default:
                // throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
                Debug.Log("default");
                break;
        }

        // OnGameStateChanged?.Invoke(newState);
    }

    //spawns final doorway
    private void SpawnDoor()
    {
        Instantiate(door, spawnDoorPosition);
    }



    // public void UpdateGameState(GameState newState)
    // {
    //     State = newState;

    //     switch (newState)
    //     {
    //         case GameState.PhaseOne:
    //             break;
    //         case GameState.PhaseTwo:
    //             //spawn phase 2 enemies?
    //             break;
    //         case GameState.PhaseThree:
    //             //spawn phase 3 enemies?
    //             break;
    //         case GameState.FinalPhase:
    //             SpawnDoor();
    //             break; 
    //         default:
    //             // throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
    //             Debug.Log("default");
    //             break;
    //     }

    //     // OnGameStateChanged?.Invoke(newState);
    // }

    //E ------------------------------------------------------------
    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.X))
    //     {
    //         UpdateGameState(GameState.FinalPhase);
    //         // Debug.Log('GAMESTATE ' + State);
    //     }
    // }
    //---------------------------------------------------------
}

// public enum GameState()
// {
//     PhaseOne,
//     PhaseTwo,
//     PhaseThree,
//     FinalPhase;
// }
