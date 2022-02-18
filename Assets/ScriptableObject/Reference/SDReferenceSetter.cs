using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDReferenceSetter : MonoBehaviour
{
    [SerializeField] SoundManager _sdManager;
    [SerializeField] SDReference _sdRef;

    void Awake()
    {
        (_sdRef as IReferenceSetter<SoundManager>).SetInstance(_sdManager);
    }
}
