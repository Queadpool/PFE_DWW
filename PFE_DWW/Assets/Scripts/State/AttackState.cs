using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : IBaseState
{
    private DinosaurStateController _dinoController = null;
    private NavMeshAgent _dinoNav = null;
    private GameObject _player = null;
    private float _distanceToPlayer = 0.0f;
    private DinosaurStateController.EDinosaurState _randomState = DinosaurStateController.EDinosaurState.IDLE;

    public AttackState(DinosaurStateController controller)
    {
        _dinoController = controller;
        _dinoNav = _dinoController.DinoNav;
        _player = PlayerManager.Instance.Player;
    }

    public void Enter()
    {
        _dinoNav.SetDestination(_player.transform.position);
    }

    public void Update()
    {
        _distanceToPlayer = Vector3.Distance(_dinoController.transform.position, _player.transform.position);
        _dinoNav.SetDestination(_player.transform.position);

        if (_distanceToPlayer >= 10.0f)
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
