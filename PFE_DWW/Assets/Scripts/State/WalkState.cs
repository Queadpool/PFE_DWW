using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkState : IBaseState
{
    private DinosaurStateController _controller = null;
    private NavMeshAgent _agent = null;
    private Vector3 _pathZone = Vector3.zero;
    private Vector3 _newDestination = Vector3.zero;
    private float _distanceToNewPos = 0.0f;
    private DinosaurStateController.EDinosaurState _randomState = DinosaurStateController.EDinosaurState.IDLE;

    public WalkState(DinosaurStateController controller)
    {
        _controller = controller;
        _agent = _controller.DinoNav;
        _pathZone = _controller.PathZone;
    }

    public void Enter()
    {
        _newDestination = _pathZone + (Random.insideUnitSphere * 20);
        _newDestination.y = 0;
        _agent.SetDestination(_newDestination);
    }

    public void Update()
    {
        _distanceToNewPos = Vector3.Distance(_controller.transform.position, _newDestination);

        if (_distanceToNewPos <= 1.0f)
        {
            RandomState();
            _controller.ChangeState(_randomState);
        }
    }

    public void Exit()
    {
        _agent.ResetPath();
    }

    private void RandomState()
    {
        _randomState = (DinosaurStateController.EDinosaurState)Random.Range(0, 4);
    }
}
