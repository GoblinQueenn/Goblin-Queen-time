using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowardlyAIController : AIController
{
    public enum CowardlyAIState { Cower, Cry, };

    public CowardlyAIState currentAIControllerState;

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

    public override void ProcessInputs()
    {
        switch (currentAIControllerState)
        {
            case CowardlyAIState.Cower:
                // Do Cower
                break;
        }
        base.ProcessInputs();
    }
}
