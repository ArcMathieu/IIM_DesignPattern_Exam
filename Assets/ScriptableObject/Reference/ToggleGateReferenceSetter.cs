using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGateReferenceSetter : MonoBehaviour
{
    [SerializeField] ToogleGate _gate;
    [SerializeField] ToggleGateReference _gateRef;

    void Awake()
    {
        (_gateRef as IReferenceSetter<ToogleGate>).SetInstance(_gate);
    }
}
