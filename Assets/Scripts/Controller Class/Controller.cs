using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    // Reference to our pawn
    public Pawn pawn;

    // Score variable
    public float score;

    // Lives variable
    public int lives;

    // Start is called before the first frame update
   public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public abstract void ProcessInputs();

    // function that updates our score
    public virtual void AddToScore(float scoreAmount)
    {
        score += scoreAmount;
    }

    public virtual void RemoveFromScore(float scoreAmount)
    {
        score -= scoreAmount;
    }

    // Funtion that adds a life
    public virtual void AddToLives()
    {
        lives++;
    }

    // Function that remoces a life
    public virtual void RemoveFromLives()
    {
        lives--;
    }
}
