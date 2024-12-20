using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{
    private float nextEventTime;

    // Start is called before the first frame update
    public override void Start()
    {
        nextEventTime = Time.time + 1 / fireRate;
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void MoveBackward()
    {
        if (mover != null)
        {
            mover.Move(-transform.forward, moveSpeed);
        }
        else
        {
            Debug.LogWarning("Warning: Mover component is not initialized");
        }
    }

    public override void RotateTowards(Vector3 targetPosition)
    {
        Vector3 vectorToTarget = targetPosition - transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    public override void MoveForward()
    {
        mover.Move(transform.forward, moveSpeed);
    }

    public override void RotateClockwise()
    {
        mover.Rotate(turnSpeed);
    }

    public override void RotateCounterClockwise()
    {
        mover.Rotate(-turnSpeed);
    }

    public override void Shoot()
    {
        if (Time.time >= nextEventTime)
        {
            shooter.Shoot(shellPrefab, fireForce, damageDone, shellLifespan);
            nextEventTime = Time.time + 1 / fireRate;
        }
    }

    public override void MakeNoise()
    {
        if (noiseMaker != null)
        {
            noiseMaker.volumeDistance = noiseMakerVolume;
        }
    }
    public override void StopNoise()
    {
        if(noiseMaker != null)
        {
            noiseMaker.volumeDistance = 0;
        }
    }
}
