using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FleeState : IBaseState
{
    private DinosaurStateController _dinoController = null;
    private NavMeshAgent _dinoNav = null;
    private Vector3 _newPos = Vector3.zero;
    private float _distanceToNewPos = 0.0f;
    private DinosaurStateController.EDinosaurState _randomState = DinosaurStateController.EDinosaurState.IDLE;

    public FleeState(DinosaurStateController controller)
    {
        _dinoController = controller;
        _dinoNav = _dinoController.DinoNav;
    }

    public void Enter()
    {
        _newPos = _dinoController.transform.position + (Random.insideUnitSphere * 20);
        _newPos.y = _dinoController.transform.position.y;
        _dinoNav.SetDestination(_newPos);
    }

    public void Update()
    {
        _distanceToNewPos = Vector3.Distance(_dinoController.transform.position, _newPos);

        if (_distanceToNewPos <= 1.0f)
        {
            RandomState();
            _dinoController.ChangeState(_randomState);
        }
    }

    public void Exit()
    {
        _dinoNav.ResetPath();
    }

    private void RandomState()
    {
        _randomState = (DinosaurStateController.EDinosaurState)Random.Range(0, 4);
    }
}
