using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : Controller
{
    public enum AIState { Guard, Scan, Chase, Attack, BackToPost, Flee, Patrol };

    public AIState currentState;

    protected float lastStateChangeTime;

    public GameObject target;

    public float hearingDistance;

    public float FieldOfView;

    // Start is called before the first frame update
   public override void Start()
    {
        // If we have a GameManger
        if (GameManager.Instance != null)
        {
            // And it tracking our enemies in a list
            if (GameManager.Instance.enemies != null)
            {
                // Register ourselfs with the GameManager
                GameManager.Instance.enemies.Add(this);
            }
        }

        ChangeState(AIState.Chase);

        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        // make Decisions
        ProcessInputs();

        base.Update();
    }

    public override void ProcessInputs()
    {
        Debug.Log("Making Decisions");
        switch (currentState)
        {
            case AIState.Guard:
                // do the behaviors associated with our guard state
                Debug.Log("Do Guard");
                //Check for Transitions OUT of our Guard state
                /*if (IsDistanceLessThan(target, 10))
                {
                    ChangeState(AIState.Chase);
                }*/
                if (CanHear(target))
                {
                    ChangeState(AIState.Chase);
                }
                //If true, we transition OUT of the Guard state into another state
                break;
            case AIState.Scan:
                Debug.Log("Do Scan");
                break;
            case AIState.Chase:
                Debug.Log("Do Chase");
                // Do all the behaviors associated with our Chase state
                DoChaseState();
                // Check for tranitions OUT of Chase
                /*if(!IsDistanceLessThan(target, 10))
                {
                    ChangeState(AIState.Guard);
                }*/
                if(!CanHear(target))
                {
                    ChangeState(AIState.Guard);
                }
                // If true, we transition OUT of Chase
                break;
            case AIState.Attack:
                // do all of the behaviors associated with out attack state
                DoAttackState();
                // Check for transitions OUT of aattack

                // If true, transition OUT of attack
                break;
        }
    }

// States
    protected void DoGuardState()
    {
        // Do Nothing
    }

    protected void DoChaseState()
    {
        // Seek in the Seek State
        Seek(target);
    }

    protected void DoAttackState()
    {
        // Chase after the target
        Seek(target.transform);
        // Tell our pawn to Shoot
        Shoot();
    }
    // Behaviors

    protected void Seek(GameObject target)
    {
        //Rotate towards the target
        pawn.RotateTowards(target.transform.position);
        // Move Forward
        pawn.MoveForward();
    }

    protected void Seek(Transform targetTransform)
    {
        Seek(targetTransform.gameObject);
    }

    protected void Shoot()
    {
        // Tell the pawn to shoot
        pawn.Shoot();
    }

    // Helper Methods and Transition Methods
    public virtual void ChangeState (AIState newState)
    {
        // Change the current state
        currentState = newState;
        // Save time when we change states
        lastStateChangeTime = Time.time;
    }

    protected bool IsDistanceLessThan(GameObject target, float distance)
    {
        if (Vector3.Distance(pawn.transform.position, target.transform.position) < distance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CanHear(GameObject target)
    {
        //Get the target's NoiseMaker
        NoiseMaker noiseMaker = target.GetComponent<NoiseMaker>();
        // If they don't have one, they cant make noise, no return false
        if (noiseMaker == null)
        {
            return false;
        }

        // If the target is making noise then add the volume Distance of the noisemaker
        // to the hearing distance of this AI agent
        float totalDistance = noiseMaker.volumeDistance + hearingDistance;

        // if the distance betweem our pawn and target is closer than the total distance
        // AKA r1 = r2
        if (Vector3.Distance(pawn.transform.position, target.transform.position) <= totalDistance)
        {
            // then we hear the target
            return true;
        }
        else
        {
            // otherwise we cannot hear the target
            return false;
        }
    }

    public bool CanSee(GameObject target)
    {
        // Find the vector fro, the agent to the target
        Vector3 agentToTargetVector = target.transform.position - pawn.transform.position;

        // find the angle between the foward facing vector and the vector to our target
        float angleToTarget = Vector3.Angle(agentToTargetVector, pawn.transform.forward);

        if (angleToTarget < FieldOfView)
        {

            RaycastHit hit;

            // Do the addtional check of whether anythining is blocking the vine of the target
            if (Physics.Raycast(pawn.transform.position + (Vector3.up)/2.0f, agentToTargetVector.normalized, out hit))
            {
                if (hit.collider.gameObject == target)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
