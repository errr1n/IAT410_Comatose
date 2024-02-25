using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // public static GameManager Instance;

    // public static event Action<GameState> OnGameStateChanged;
    // public GameState State;
    public GameObject door;
    [SerializeField] private Transform spawnDoorPosition;

    // void Awake()
    // {
        // Instance = this;
        // Instantiate(door, spawnDoorPosition);
    // }

    // void Start()
    // {
    //     UpdateGameState(GameState.PhaseOne);
    //     Debug.Log('GAMESTATE ' + GameState);
    // }

    // public void UpdateGameState(GameState newState)
    // {
    //     State = newState;

    //     switch(newState)
    //     {
    //         case GameState.PhaseOne:
    //             break;
    //         case GameState.PhaseTwo:
    //             break;
    //         case GameState.PhaseThree:
    //             break;
    //         case GameState.FinalPhase:
    //             break; 
    //         default:
    //             throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
    //     }

    //     OnGameStateChanged?.Invoke(newState);
    // }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(door, spawnDoorPosition);
        }
    }
}

// public enum GameState()
// {
//     PhaseOne,
//     PhaseTwo,
//     PhaseThree,
//     FinalPhase;
// }
