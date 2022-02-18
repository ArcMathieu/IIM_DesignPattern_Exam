using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGate : MonoBehaviour, IGate
{
    [SerializeField] PlayerReference _playerRef;
    public void DoorState(bool state)
    {
        gameObject.SetActive(state);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (_playerRef.Instance.Picker._hasKey)
        {
            DoorState(false);
        }
    }
}
