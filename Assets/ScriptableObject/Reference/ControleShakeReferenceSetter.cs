using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleShakeReferenceSetter : MonoBehaviour
{
    [SerializeField] ControlShake _ctrlShake;
    [SerializeField] ControleShakeReference _ctrlShakeReference;

    private void Awake()
    {
        (_ctrlShakeReference as IReferenceSetter<ControlShake>).SetInstance(_ctrlShake);
    }
}
