using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QQ.Utils;

public class DatabaseManager : Singleton<DatabaseManager>
{
    [SerializeField] private DinosaurData _dinosaurData = null;
    [SerializeField] private EnemyData _ennemyData = null;

    public DinosaurData DinosaurData { get { return _dinosaurData; } }
    public EnemyData EnemyData { get { return _ennemyData; } }
}
