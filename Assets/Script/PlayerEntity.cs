using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEntity : MonoBehaviour
{
    [SerializeField] Health _health;
    [SerializeField] PickingObject _picker;
    public Health Health => _health;
    public PickingObject Picker => _picker;
    [SerializeField] ControleShakeReference _shakeRef;

    private void Awake()
    {

    }

    private void Start()
    {
        Health.OnShake += _shakeRef.Instance.LaunchScreenShake;
    }
    private void OnDestroy()
    {
        Health.OnShake -= _shakeRef.Instance.LaunchScreenShake;
    }
}


