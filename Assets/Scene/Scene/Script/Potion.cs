using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour, IPickable
{
    [SerializeField] PlayerReference _playerRef;
    [SerializeField] int healAmount = 3;
    public void PickUp()
    {
        _playerRef.Instance.Health.Heal(healAmount);
        gameObject.SetActive(false);
    }

}
