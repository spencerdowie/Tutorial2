using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public StateMachine stateMachine = new StateMachine();

    private void Start()
    {
        Dictionary<StateType, BaseState> states = new Dictionary<StateType, BaseState>
        {
            {StateType.Patrol, new PatrolState(this) },
            {StateType.Search, new SearchState(this) }
        };
        stateMachine.SetStates(states);
    }

    public float MoveForward()
    {
        transform.position += transform.forward * 0.1f;

        return (transform.forward * 0.1f).magnitude;
    }

    public void RotateBy(float rot)
    {
        float newRotation = transform.rotation.eulerAngles.y + rot;
        transform.rotation = Quaternion.Euler(new Vector3(0, newRotation, 0));
    }

    void Update()
    {
        stateMachine.Update();
    }
}
