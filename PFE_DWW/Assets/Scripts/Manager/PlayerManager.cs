using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QQ.Utils;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] GameObject _player = null;
    [SerializeField] bool _alive = true;
    [SerializeField] int _helth = 100;

    public GameObject Player { get { return _player; } }
    public bool Alive { get { return _alive; } }
    public int Health { get { return _helth; } }
}
