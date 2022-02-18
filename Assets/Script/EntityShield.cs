using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityShield : MonoBehaviour
{
    [SerializeField] PlayerReference _playerRef;
    public void ShieldOut()
    {
        _playerRef.Instance.Health.IsInvincible(true);
    }
    public void StowedShield()
    {
        _playerRef.Instance.Health.IsInvincible(false);
    }
}
