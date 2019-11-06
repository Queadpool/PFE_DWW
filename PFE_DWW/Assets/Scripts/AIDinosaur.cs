using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDinosaur : MonoBehaviour
{
    public enum State
    {
        Walk,
        Eat,
        Watch,
        RunAway,
        Soul,
        Tame
    }

    [Header("Settings")]
    [SerializeField] private bool carnivorous = true;

    [Header("State Settings")]
    [SerializeField] private GameObject stateSettings;

    [Header("Walk Settings")]
    [SerializeField] private GameObject walkSettings;

    [Header("Eat Settings")]
    [SerializeField] private GameObject eatSettings;

    [Header("Watch Settings")]
    [SerializeField] private GameObject watchSettings;

    [Header("Run Away Settings")]
    [SerializeField] private GameObject runSettings;

    [Header("Soul Settings")]
    [SerializeField] private GameObject soulSettings;

    [Header("Tame Settings")]
    [SerializeField] private GameObject tameSettings;

    private void Start()
    {
        
    }
}