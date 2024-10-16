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


    // Start is called before the first frame update
    public override void Start()
    {
        
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
        }

        if (Input.GetKey(moveBackwardkey))
        {
            pawn.MoveBackward();
        }

        if (Input.GetKey(rotateClockwisekey))
        {
            pawn.RotateClockwise();
        }

        if (Input.GetKey(rotateCounterClockwisekey))
        {
            pawn.RotateCounterClockwise();
        }
    }
}
