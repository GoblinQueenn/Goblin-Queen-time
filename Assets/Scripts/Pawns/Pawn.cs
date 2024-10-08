using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    // Varible for move speed
    public float moveSpeed;
    // Varible for turn speed
    public float turnSpeed;

    // Varible for our Mover
    public Mover mover;

    // Start is called before the first frame update
    public virtual void Start()
    {
        // initialize our Mover component
        mover = GetComponent<Mover>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void RotateClockwise();
    public abstract void RotateCounterClockwise();
}
