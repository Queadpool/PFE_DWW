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

    private NavMeshAgent _dinoNav = null;
    [SerializeField] private bool _carnivorous = false;
    [SerializeField] private EDinosaurState _currentState = EDinosaurState.IDLE;

    public NavMeshAgent DinoNav { get { return _dinoNav; } }
    public bool Carnivorous { get { return _carnivorous; } }
    public EDinosaurState CurrentState { get { return _currentState; } }

    Dictionary<EDinosaurState, IBaseState> _states = null;

    private void Start()
    {
        _dinoNav = GetComponent<NavMeshAgent>();

        _states = new Dictionary<EDinosaurState, IBaseState>();
        _states.Add(EDinosaurState.IDLE, new IdleState(this));
        _states.Add(EDinosaurState.EAT, new EatState(this));
        _states.Add(EDinosaurState.WATCH, new WatchState(this));
        _states.Add(EDinosaurState.WALK, new WalkState(this));
        _states.Add(EDinosaurState.FLEE, new FleeState(this));
        _states.Add(EDinosaurState.ATTACK, new AttackState(this));
        _states[CurrentState].Enter();
    }

    private void Update()
    {
        _states[CurrentState].Update();
    }

    public void ChangeState(EDinosaurState nextState)
    {
        _states[CurrentState].Exit();
        _states[nextState].Enter();
        _currentState = nextState;
    }
}
