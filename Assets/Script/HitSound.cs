using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSound : MonoBehaviour
{
    [SerializeField] PlayerReference _playerRef;
    [SerializeField] SDReference _sdRef;
    [SerializeField] AudioClip _impactSd;
    // Start is called before the first frame update
    void Start()
    {
        _playerRef.Instance.Health.OnShake += takeDamageSound;
    }
    void OnDestroy()
    {
        _playerRef.Instance.Health.OnShake -= takeDamageSound;
    }

    private void takeDamageSound()
    {
        _sdRef.Instance.Play(_impactSd);
    }
}
