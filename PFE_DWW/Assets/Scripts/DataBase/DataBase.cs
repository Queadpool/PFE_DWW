using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DWW/Database")]
public class Database : ScriptableObject
{
    [SerializeField] private GameObject _ennemy0;
    [SerializeField] private GameObject _ennemy1;

    public GameObject Ennemy0 { get { return _ennemy0; } }
    public GameObject Ennemy1 { get { return _ennemy1; } }
}
