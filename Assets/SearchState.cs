using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : BaseState
{
    public AIController controller;
    private GameObject target;

    public SearchState(AIController _controller) : base(_controller.gameObject)
    {
        controller = _controller;
    }

    public override void Activate()
    {
        target = GameObject.Find("Target");

        Vector3 flatTarget = target.transform.position;
        flatTarget.y = 0f;

        Vector3 flatController = controller.transform.position;
        flatController.y = 0f;

        Vector3 aimVec = flatTarget - flatController;
        float aimAngle = Vector3.SignedAngle(aimVec, controller.transform.forward, controller.transform.up);
        
        controller.RotateBy(-aimAngle);
    }

    public override StateType Update()
    {
        controller.MoveForward();
        return type;
    }
}