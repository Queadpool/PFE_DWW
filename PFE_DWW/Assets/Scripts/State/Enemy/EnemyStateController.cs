using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateController : MonoBehaviour
{
    public enum EEnemyState
    {
        IDLE,
        PATROL,
        ATTACK
    }

    Dictionary<EEnemyState, IBaseState> _states = null;

    private void Start()
    {
        _states = new Dictionary<EEnemyState, IBaseState>();
        _states.Add(EEnemyState.IDLE, new EnemyIdleState(this));
    }
}
