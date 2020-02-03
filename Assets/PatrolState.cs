using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    public AIController controller;
    float patrolLength = 8f, distanceTravelled = 0f;

    public PatrolState(AIController _controller): base(_controller.gameObject)
    {
        controller = _controller;
    }

    public override void Activate()
    {

    }

    public override StateType Update()
    {
        distanceTravelled += controller.MoveForward();

        if(distanceTravelled >= patrolLength)
        {
            controller.RotateBy(180);
            distanceTravelled = 0f;
        }
        return type;
    }
}
