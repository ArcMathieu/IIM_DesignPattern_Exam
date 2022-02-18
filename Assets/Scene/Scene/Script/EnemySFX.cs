using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySFX : MonoBehaviour
{
    public AudioClip[] GoblinNoises;
    [SerializeField] SDReference _sdRef;
    
    void Update()
    {
        _sdRef.Instance.RandomSoundEffect(GoblinNoises);
    }
}
