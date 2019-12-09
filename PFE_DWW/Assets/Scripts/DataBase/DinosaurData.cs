using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DWW/Database/Dinosaur Data")]
public class DinosaurData : ScriptableObject
{
    [SerializeField] private GameObject _dino0 = null;
    [SerializeField] private GameObject _dino1 = null;

    public GameObject Dino0 { get { return _dino0; } }
    public GameObject Dino1 { get { return _dino1; } }
}
