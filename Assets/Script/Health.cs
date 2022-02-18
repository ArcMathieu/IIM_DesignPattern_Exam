using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IHealth, ITouchable
{
    // Champs
    [SerializeField] int _startHealth;
    [SerializeField] int _maxHealth;
    [SerializeField] UnityEvent _onDeath;

    // Propriétés
    public int CurrentHealth { get; private set; }
    public int MaxHealth => _maxHealth;
    public bool IsDead => CurrentHealth <= 0;

    // Events
    public event UnityAction OnSpawn;
    public event UnityAction<int> OnDamage;
    public event UnityAction OnShake;
    public event UnityAction OnDeath { add => _onDeath.AddListener(value); remove => _onDeath.RemoveListener(value); }

    bool _isInvicible;

    // Methods
    void Awake() => Init();

    void Init()
    {
        CurrentHealth = _startHealth;
        OnSpawn?.Invoke();
    }
    public void TakeDamage(int amount)
    {
        if (amount < 0) throw new ArgumentException($"Argument amount {nameof(amount)} is negativ");

        if (!_isInvicible) {
            var tmp = CurrentHealth;
            CurrentHealth = Mathf.Max(0, CurrentHealth - amount);
            var delta = CurrentHealth - tmp;
            OnDamage?.Invoke(delta);
            OnShake?.Invoke();

            if(CurrentHealth <= 0)
            {
                _onDeath?.Invoke();
            }
        }
    }
    public void Heal(int amount)
    {
        CurrentHealth += amount ;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
        OnDamage?.Invoke(CurrentHealth);
    }
    
    public void IsInvincible(bool invicible)
    {
        _isInvicible = invicible;
    }

    [Button("test")]
    void MaFonction()
    {
        var enumerator = MesIntPrefere();

        while(enumerator.MoveNext())
        {
            Debug.Log(enumerator.Current);
        }
    }


    List<IEnumerator> _coroutines;

    IEnumerator<int> MesIntPrefere()
    {

        //

        var age = 12;

        yield return 12;


        //

        yield return 3712;

        age++;
        //

        yield return 0;



        //
        yield break;
    }

    public void Touch(int power)
    {
        TakeDamage(power);
    }
}
