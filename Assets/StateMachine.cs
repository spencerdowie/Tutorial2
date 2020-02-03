using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public enum StateType
{
    Search = 0,
    Patrol
}

public class StateMachine
{
    private Dictionary<StateType, BaseState> avaibleStates;
    private BaseState currentState;

    public void SetStates(Dictionary<StateType, BaseState> states)
    {
        avaibleStates = states;
    }

    private void SwitchToNewState(StateType nextState)
    {
        if(avaibleStates.ContainsKey(nextState))
        {
            currentState = avaibleStates[nextState];
            currentState.Activate();
        }
    }

    public void Update()
    {
        if(currentState == null)
        {
            currentState = avaibleStates.Values.First();
            currentState.Activate();
        }

        StateType nextState = currentState.Update();

        if(nextState != currentState.type)
        {
            SwitchToNewState(nextState);
        }
    }
}
