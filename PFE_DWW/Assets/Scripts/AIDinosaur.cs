using UnityEngine;
using UnityEngine.AI;

public class AIDinosaur : MonoBehaviour
{
    public enum State
    {
        Idle,
        Eat,
        Watch,
        Walk,
        Flee,
        Attack,
        Soul,
        Tame
    }

    [Header("Component Settings")]
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _player;
    [SerializeField] private PlayerController _playerController;

    [Header("General Settings")]
    [SerializeField] private bool _carnivorous = true;
    [SerializeField] private bool _tamed = false;
    [SerializeField] private State _currentState = State.Idle;
    [SerializeField] private float _stateTimer = 0.0f;
    [SerializeField] private float _detectionDistance = 5.0f;
    [SerializeField] private float _distanceToPlayer = 0.0f;

    [Header("Idle Settings")]
    [SerializeField] private float _idleTimer = 5.0f;

    [Header("Eat Settings")]
    [SerializeField] private float _eatTimer = 5.0f;

    [Header("Watch Settings")]
    [SerializeField] private float _watchTimer = 5.0f;

    [Header("Walk Settings")]
    [SerializeField] private Vector3 _pathZone = Vector3.zero;
    [SerializeField] private Vector3 _randomWayPoint = Vector3.zero;
    [SerializeField] private Vector3 _newPos = Vector3.zero;
    [SerializeField] private float _distanceToNewPos = 0.0f;

    [Header("Flee Settings")]
    [SerializeField] private float _distancePlayerToNewPos = 0.0f;

    [Header("Attack Settings")]

    [Header("Soul Settings")]

    [Header("Tame Settings")]
    [SerializeField] private GameObject tameSettings;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _playerController = _player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        DoStateBehaviour();
    }

    private void DoStateBehaviour()
    {
        _distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);
        _distanceToNewPos = Vector3.Distance(transform.position, _newPos);
        _distancePlayerToNewPos = Vector3.Distance(_player.transform.position, _newPos);

        switch (_currentState)
        {
            case State.Idle:
                {
                    // Fin d'animation
                    if (_stateTimer > _idleTimer)
                    {
                        _stateTimer = 0.0f;

                        ChangeState();
                    }
                    // (Player debout && Dans la zone de detection) || Player trop proche
                    else if (((!_playerController.crouch) && (_distanceToPlayer < _detectionDistance)) || (_distanceToPlayer < 2.0f))
                    {
                        _stateTimer = 0.0f;

                        if (_carnivorous)
                        {
                            _currentState = State.Attack;


                            // ?????????????????? BESOIN ??????????????????
                            DoStateBehaviour();


                        }
                        else
                        {
                            _currentState = State.Flee;

                            DoStateBehaviour();
                        }
                    }
                    // HYPER VISION
                    else if (Input.GetKeyDown(KeyCode.E))
                    {
                        _stateTimer = 0.0f;
                        _currentState = State.Soul;

                        DoStateBehaviour();

                    }
                    else
                    {
                        Idle();
                    }
                    break;
                }
            case State.Eat:
                {
                    if (_stateTimer > _eatTimer)
                    {
                        _stateTimer = 0.0f;

                        ChangeState();
                    }
                    else if (((!_playerController.crouch) && (_distanceToPlayer < _detectionDistance)) || (_distanceToPlayer < 2.0f))
                    {
                        _stateTimer = 0.0f;

                        if (_carnivorous)
                        {
                            _currentState = State.Attack;

                            DoStateBehaviour();
                        }
                        else
                        {
                            _currentState = State.Flee;

                            DoStateBehaviour();
                        }
                    }
                    else if (Input.GetKeyDown(KeyCode.E))
                    {
                        _stateTimer = 0.0f;
                        _currentState = State.Soul;

                        DoStateBehaviour();

                    }
                    else
                    {
                        Eat();
                    }
                    break;
                }
            case State.Watch:
                {
                    if (_stateTimer > _watchTimer)
                    {
                        _stateTimer = 0.0f;

                        ChangeState();
                    }
                    else if (((!_playerController.crouch) && (_distanceToPlayer < _detectionDistance)) || (_distanceToPlayer < 2.0f))
                    {
                        _stateTimer = 0.0f;

                        if (_carnivorous)
                        {
                            _currentState = State.Attack;

                            DoStateBehaviour();
                        }
                        else
                        {
                            _currentState = State.Flee;

                            DoStateBehaviour();
                        }
                    }
                    else if (Input.GetKeyDown(KeyCode.E))
                    {
                        _stateTimer = 0.0f;
                        _currentState = State.Soul;

                        DoStateBehaviour();

                    }
                    else
                    {
                        Watch();
                    }
                    break;
                }
            case State.Walk:
                {
                    // Dino est arrivé à destination
                    if (_distanceToNewPos < 1.0f)
                    {
                        _randomWayPoint = Vector3.zero;
                        _agent.ResetPath();

                        ChangeState();
                    }
                    else if (((!_playerController.crouch) && (_distanceToPlayer < _detectionDistance)) || (_distanceToPlayer < 2.0f))
                    {
                        _randomWayPoint = Vector3.zero;
                        _agent.ResetPath();

                        if (_carnivorous)
                        {
                            _currentState = State.Attack;

                            DoStateBehaviour();
                        }
                        else
                        {
                            _currentState = State.Flee;

                            DoStateBehaviour();
                        }
                    }
                    else if (Input.GetKeyDown(KeyCode.E))
                    {
                        _randomWayPoint = Vector3.zero;
                        _agent.ResetPath();
                        _currentState = State.Soul;

                        DoStateBehaviour();

                    }
                    else
                    {
                        Walk();
                    }
                    break;
                }
            case State.Flee:
                {
                    if (_distanceToNewPos < 1.0f)
                    {
                        _randomWayPoint = Vector3.zero;
                        _agent.ResetPath();

                        ChangeState();
                    }
                    else
                    {
                        Flee();
                    }
                    break;
                }
            case State.Attack:
                {
                    break;
                }
        }
    }

    private void ChangeState()
    {
        _currentState = (State)Random.Range(0, 4);

        DoStateBehaviour();
    }

    private void Idle()
    {
        _stateTimer += Time.deltaTime;
    }

    private void Eat()
    {
        _stateTimer += Time.deltaTime;
    }

    private void Watch()
    {
        _stateTimer += Time.deltaTime;
    }

    private void Walk()
    {
        if (_randomWayPoint == Vector3.zero)
        {
            _randomWayPoint = Random.insideUnitSphere * 20;
            _randomWayPoint.y = 0;
            _newPos = _pathZone + _randomWayPoint;
            _agent.SetDestination(_newPos);
        }
    }

    private void Flee()
    {
        if (_randomWayPoint == Vector3.zero)
        {
            _randomWayPoint = Random.insideUnitSphere * 20;
            _randomWayPoint.y = 0;
            _newPos = _pathZone + _randomWayPoint;

            if (_distancePlayerToNewPos < _detectionDistance)
            {
                _randomWayPoint = Vector3.zero;
                Flee();
            }

            _agent.SetDestination(_newPos);
        }
    }
}