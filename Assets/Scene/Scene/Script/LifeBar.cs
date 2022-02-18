using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    [SerializeField] PlayerReference _playerRef;
    Slider _sliderValue;

    private void Start()
    {
        _sliderValue = GetComponent<Slider>();
        _playerRef.Instance.Health.OnDamage += UpdateLife;
    }
    private void OnDestroy()
    {
        _playerRef.Instance.Health.OnDamage -= UpdateLife;
    }
    private void UpdateLife(int amount)
    {
        _sliderValue.value = (float)_playerRef.Instance.Health.CurrentHealth / _playerRef.Instance.Health.MaxHealth;
    }
}
