using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Health _health;
    public AudioClip[] GoblinNoises;
    [SerializeField] SDReference _sdRef;

    private void Awake()
    {

    }
    private void Start()
    {
        _health.OnDeath += PlaySound;
    }
    private void OnDestroy()
    {
        _health.OnDeath -= PlaySound;
    }

    private void PlaySound()
    {
        _sdRef.Instance.RandomSoundEffect(GoblinNoises);
    }


}
