using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QQ.Utils;

public class DinoEatState : IBaseState
{
    private DinosaurStateController _dinoController = null;
    private GameObject _player = null;
    private float _distanceToPlayer = 0.0f;
    private Timer _timer = null;
    private float _eatTimer = 5.0f;
    private DinosaurStateController.EDinosaurState _randomState = DinosaurStateController.EDinosaurState.IDLE;

    public DinoEatState(DinosaurStateController controller)
    {
        _dinoController = controller;
        _player = PlayerManager.Instance.Player;
    }

    public void Enter()
    {
        _timer = new Timer();
        _timer.ResetTimer(_eatTimer);
    }

    public void Update()
    {
        _distanceToPlayer = Vector3.Distance(_dinoController.transform.position, _player.transform.position);

        if (_timer.TimeLeft <= 0)
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

    }

    private void RandomState()
    {
        _randomState = (DinosaurStateController.EDinosaurState)Random.Range(0, 4);
    }
}
