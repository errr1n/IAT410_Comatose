using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // public static GameManager Instance;

    // public static event Action<GameState> OnGameStateChanged;
    // public GameState State;

    // void Awake()
    // {
    //     Instance = this;
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
}

// public enum GameState()
// {
//     PhaseOne,
//     PhaseTwo,
//     PhaseThree,
//     FinalPhase;
// }
