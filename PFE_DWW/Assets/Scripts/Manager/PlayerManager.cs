using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QQ.Utils;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] GameObject _player = null;

    public GameObject Player { get { return _player; } }
}
