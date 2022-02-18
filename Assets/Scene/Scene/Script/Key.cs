using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IPickable
{
    [SerializeField] PlayerReference _playerRef;
    public void PickUp()
    {
        _playerRef.Instance.Picker._hasKey = true;
        gameObject.SetActive(false);
    }
}
