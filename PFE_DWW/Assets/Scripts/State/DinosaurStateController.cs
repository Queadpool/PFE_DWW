using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DinosaurStateController : MonoBehaviour
{
    public enum EDinosaurState
    {
        IDLE,
        EAT,
        WATCH,
        WALK,
        FLEE,
        ATTACK
    }

    [SerializeField] private EDinosaurState _currentState = EDinosaurState.IDLE;
    [SerializeField] private NavMeshAgent _dinoNav = null;
    [SerializeField] private Vector3 _pathZone = Vector3.zero;

    public EDinosaurState CurrentState { get { return _currentState; } }
    public NavMeshAgent DinoNav { get { return _dinoNav; } }
    public Vector3 PathZone { get { return _pathZone; } }

    Dictionary<EDinosaurState, IBaseState> _states = null;

    private void Start()
    {
        _dinoNav = GetComponent<NavMeshAgent>();
        _pathZone = transform.position;

        _states = new Dictionary<EDinosaurState, IBaseState>();
        _states.Add(EDinosaurState.IDLE, new IdleState(this));
        _states.Add(EDinosaurState.EAT, new EatState(this));
        _states.Add(EDinosaurState.WATCH, new WatchState(this));
        _states.Add(EDinosaurState.WALK, new WalkState(this));
        //_states.Add(EDinosaurState.IDLE, new FleeState(this));
        //_states.Add(EDinosaurState.IDLE, new AttackState(this));
        _states[_currentState].Enter();
    }

    private void Update()
    {
        _states[_currentState].Update();
    }

    public void ChangeState(EDinosaurState nextState)
    {
        _states[_currentState].Exit();
        _states[nextState].Enter();
        _currentState = nextState;
    }
}
