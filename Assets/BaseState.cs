using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    public StateType type;
    public GameObject gameObject;

    public BaseState(GameObject _gameObject)
    {
        gameObject = _gameObject;
    }

    public abstract void Activate();
    public abstract StateType Update();
}
