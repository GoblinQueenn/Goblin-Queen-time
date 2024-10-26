using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    public float damageDone;
    public Pawn owner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider Other)
    {
        // Get the health compoent from the object we are colliding with
        Health otherHealth = Other.GetComponent<Health>();

        //Only damage if the object has a Health component
        if(otherHealth != null)
        {
            //Inflict damage
            otherHealth.takeDamage(damageDone, owner);
        }

        // Destroy ourselves, whether we did damage or not
        Destroy(gameObject);
    }
}
