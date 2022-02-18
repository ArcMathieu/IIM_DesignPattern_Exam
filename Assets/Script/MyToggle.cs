using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyToggle : MonoBehaviour, ITouchable
{
    [SerializeField] ToggleGateReference _Gate;

    // Je veux ouvrir un évènement pour les designers pour qu'ils puissent set la couleur du sprite eux même
    [SerializeField] UnityEvent _onToggleOn;
    [SerializeField] UnityEvent _onToggleOff;

    event UnityAction OnChangeColor;

    [Header("Dependencies")]
    [SerializeField] SpriteRenderer _renderer;

    [SerializeField] Color _toggleOnColor;
    [SerializeField] Color _toggleOffColor;
    [SerializeField] bool IsActive;

    #region Editor
    void Reset()
    {
        _renderer = GetComponentInChildren<SpriteRenderer>();
        _toggleOnColor = Color.green;
        _toggleOffColor = Color.red;
    }
    #endregion

    private void Start()
    {
        _renderer = GetComponentInChildren<SpriteRenderer>();
        _onToggleOn.AddListener(OnChangeColor);
        _onToggleOff.AddListener(OnChangeColor);
        OnChangeColor += ChangeColor;

        _Gate.Instance.AddToogleToList(this);
    }

    public void Touch(int power)
    {
        IsActive = !IsActive;
        ChangeColor();
        _Gate.Instance.AddActiveToggle(IsActive);
    }
    public void ChangeColor()
    {
        if (IsActive) _renderer.color = _toggleOnColor;
        else _renderer.color = _toggleOffColor;
        
    }
}
