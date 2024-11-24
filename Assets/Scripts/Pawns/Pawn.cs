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
    // Varible for our Shooter
    public Shooter shooter;

    // Variable for our shell Prefab
    public GameObject shellPrefab;
    //Variable for our firing force
    public float fireForce;
    // Variable for damage done
    public float damageDone;
    // Variable for bullet lifespan
    public float shellLifespan;
    //Variable for Rate of Fire
    public float fireRate;

    // Start is called before the first frame update
    public virtual void Start()
    {
        // initialize our Mover component
        mover = GetComponent<Mover>();
        // Initialize our Shooter componant
        shooter = GetComponent<Shooter>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void RotateClockwise();
    public abstract void RotateCounterClockwise();
    public abstract void RotateTowards(Vector3 targetPosition);
    public abstract void Shoot();
}
