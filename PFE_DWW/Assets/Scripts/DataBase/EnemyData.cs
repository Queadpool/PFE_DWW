using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DWW/Database/Enemy Data")]
public class EnemyData : ScriptableObject
{
    [SerializeField] private GameObject _ennemy0 = null;
    [SerializeField] private GameObject _ennemy1 = null;

    public GameObject Ennemy0 { get { return _ennemy0; } }
    public GameObject Ennemy1 { get { return _ennemy1; } }
}
