using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void MoveBackward()
    {
        Debug.Log("Moving Backwards");
        mover.Move(-transform.forward, moveSpeed);
    }

    public override void MoveForward()
    {
        Debug.Log("Moving Forwards");
        mover.Move(transform.forward, moveSpeed);
    }

    public override void RotateClockwise()
    {
        Debug.Log("Rotating Clockwise");
        mover.Rotate(turnSpeed);
    }

    public override void RotateCounterClockwise()
    {
        Debug.Log("Rotating CounterClockWise");
        mover.Rotate(-turnSpeed);
    }
}
