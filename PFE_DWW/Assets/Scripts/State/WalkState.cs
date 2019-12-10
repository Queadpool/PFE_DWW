using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkState : IBaseState
{
    private DinosaurStateController _dinoController = null;
    private NavMeshAgent _dinoNav = null;
    private GameObject _player = null;
    private Vector3 _newPos = Vector3.zero;
    private float _distanceToNewPos = 0.0f;
    private float _distanceToPlayer = 0.0f;
    private DinosaurStateController.EDinosaurState _randomState = DinosaurStateController.EDinosaurState.IDLE;

    public WalkState(DinosaurStateController controller)
    {
        _dinoController = controller;
        _dinoNav = _dinoController.DinoNav;
        _player = PlayerManager.Instance.Player;
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
        _distanceToPlayer = Vector3.Distance(_dinoController.transform.position, _player.transform.position);

        if (_distanceToNewPos <= 1.0f)
        {
            RandomState();
            _dinoController.ChangeState(_randomState);
        }

        if (_distanceToPlayer <= 5.0f)
        {
            if (_dinoController.Carnivorous == true)
            {
                _dinoController.ChangeState(DinosaurStateController.EDinosaurState.ATTACK);
            }
            else
            {
                _dinoController.ChangeState(DinosaurStateController.EDinosaurState.FLEE);
            }
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
