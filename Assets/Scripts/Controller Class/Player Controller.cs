using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : Controller
{
    public KeyCode moveForwardkey;
    public KeyCode moveBackwardkey;
    public KeyCode rotateClockwisekey;
    public KeyCode rotateCounterClockwisekey;
    public KeyCode shootKey;

    // Start is called before the first frame update
    public override void Start()
    {
        // If we have a GameManger
        if (GameManager.Instance != null)
        {
            // And it tracking our players in a list
            if (GameManager.Instance.players != null)
            {
                // Register ourselfs with the GameManager
                GameManager.Instance.players.Add(this);
            }
        }
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        ProcessInputs();
    }

    public override void ProcessInputs()
    {
        if (Input.GetKey(moveForwardkey))
        {
            pawn.MoveForward();
            pawn.MakeNoise();
        }

        if (Input.GetKey(moveBackwardkey))
        {
            pawn.MoveBackward();
            pawn.MakeNoise();
        }

        if (Input.GetKey(rotateClockwisekey))
        {
            pawn.RotateClockwise();
            pawn.MakeNoise();
        }

        if (Input.GetKey(rotateCounterClockwisekey))
        {
            pawn.RotateCounterClockwise();
            pawn.MakeNoise();
        }

        if (Input.GetKeyDown(shootKey))
        {
            pawn.Shoot();
            pawn.MakeNoise();
        }

        if (!Input.GetKey(moveForwardkey) && !Input.GetKey(moveBackwardkey) && !Input.GetKey(rotateClockwisekey) && !Input.GetKey(rotateCounterClockwisekey) && !Input.GetKey(shootKey))
        {
            pawn.StopNoise();
        }
    }
    public void OnDestroy()
    {
        // If we have a GameManager
        if (GameManager.Instance != null)
        {
            // And it tracks the players
            if (GameManager.Instance.players != null)
            {
                // Remove Ourselves from the GameManager's list
                GameManager.Instance.players.Remove(this);
            }
        }
    }
}
