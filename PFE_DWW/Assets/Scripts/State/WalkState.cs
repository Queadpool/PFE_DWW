using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : IBaseState
{
    private DinosaurStateController _controller = null;
    private DinosaurStateController.EDinosaurState _randomState = DinosaurStateController.EDinosaurState.IDLE;

    public WalkState(DinosaurStateController controller)
    {
        _controller = controller;
    }

    public void Enter()
    {

    }

    public void Update()
    {

    }

    public void Exit()
    {

    }

    private void Walk()
    {

    }
}
