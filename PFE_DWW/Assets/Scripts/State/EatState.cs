using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QQ.Utils;

public class EatState : IBaseState
{
    private DinosaurStateController _controller = null;
    private Timer _timer = null;
    private float _eatTimer = 5.0f;
    private DinosaurStateController.EDinosaurState _randomState = DinosaurStateController.EDinosaurState.IDLE;

    public EatState(DinosaurStateController controller)
    {
        _controller = controller;
    }

    public void Enter()
    {
        _timer = new Timer();
        _timer.ResetTimer(_eatTimer);
    }

    public void Update()
    {
        if (_timer.TimeLeft <= 0)
        {
            RandomState();
            _controller.ChangeState(_randomState);
        }
    }

    public void Exit()
    {

    }

    private void RandomState()
    {
        _randomState = (DinosaurStateController.EDinosaurState)Random.Range(0, 4);
    }
}
