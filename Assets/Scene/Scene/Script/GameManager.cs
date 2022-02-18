using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerReference _playerRef;
    [SerializeField] SDReference _sdRef;

    public AudioClip music;
    private void Start()
    {
        _playerRef.Instance.Health.OnDeath += Restart;
        _sdRef.Instance.Play(music);
    }
    private void OnDestroy()
    {
        _playerRef.Instance.Health.OnDeath += Restart;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
