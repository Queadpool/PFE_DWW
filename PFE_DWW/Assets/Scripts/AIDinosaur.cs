using UnityEngine;
using UnityEngine.AI;

public class AIDinosaur : MonoBehaviour
{
    public enum State
    {
        Idle,
        Walk,
        Eat,
        Watch,
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

    [Header("Settings")]
    [SerializeField] private bool _carnivorous = true;
    [SerializeField] private bool _tamed = false;
    [SerializeField] private float _stateTimer = 0.0f;
    [SerializeField] private float _detectionDistance = 5.0f;
    [SerializeField] private float _distanceToPlayer;
    [SerializeField] private State _currentState = State.Idle;

    [Header("Idle Settings")]
    [SerializeField] private float _idleTimer = 5.0f;

    [Header("Walk Settings")]
    [SerializeField] private float _walkTimer = 5.0f;

    [Header("Eat Settings")]
    [SerializeField] private float _eatTimer = 5.0f;

    [Header("Watch Settings")]
    [SerializeField] private float _watchTimer = 5.0f;

    [Header("Flee Settings")]

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

        switch (_currentState)
        {
            case State.Idle:
                {
                    // End of animation
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
            case State.Walk:
                {
                    break;
                }
            case State.Eat:
                {
                    break;
                }
            case State.Watch:
                {
                    break;
                }
            case State.Flee:
                {
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
        if (_tamed)
        {
            _currentState = (State)Random.Range(1, 4);
        }
        else
        {
            _currentState = (State)Random.Range(0, 1);
        }

        DoStateBehaviour();
    }

    private void Idle()
    {
        _stateTimer += Time.deltaTime;
    }
}