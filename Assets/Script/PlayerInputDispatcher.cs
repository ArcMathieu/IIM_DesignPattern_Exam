using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputDispatcher : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;

    [SerializeField] EntityMovement _movement;
    [SerializeField] EntityFire _fire;
    [SerializeField] EntityShield _shield;

    [SerializeField] InputActionReference _pointerPosition;
    [SerializeField] InputActionReference _moveJoystick;
    [SerializeField] InputActionReference _fireButton;
    [SerializeField] InputActionReference _shieldButton;

    bool isShielded;
    bool canShoot = true;
    [SerializeField] SDReference _sdRef;
    public AudioClip ArrowNoise;
    Coroutine MovementTracking { get; set; }

    Vector3 ScreenPositionToWorldPosition(Camera c, Vector2 cursorPosition) => _mainCamera.ScreenToWorldPoint(cursorPosition);

    private void Start()
    {
        // binding
        _fireButton.action.started += FireInput;

        //OnClickDown
        _shieldButton.action.started += ShieldInput;
        //OnClickUp
        _shieldButton.action.canceled += ShieldInput;

        _moveJoystick.action.started += MoveInput;
        _moveJoystick.action.canceled += MoveInputCancel;
    }

    private void OnDestroy()
    {
        _fireButton.action.started -= FireInput;
        _shieldButton.action.started -= ShieldInput;
        _shieldButton.action.canceled -= ShieldInput;

        _moveJoystick.action.started -= MoveInput;
        _moveJoystick.action.canceled -= MoveInputCancel;
    }

    private void MoveInput(InputAction.CallbackContext obj)
    {
        if (MovementTracking != null) return;

        MovementTracking = StartCoroutine(MovementTrackingRoutine());
        IEnumerator MovementTrackingRoutine()
        {
            while (true)
            {
                _movement.PrepareDirection(obj.ReadValue<Vector2>());
                yield return null;
            }
            yield break;
        }
    }

    private void MoveInputCancel(InputAction.CallbackContext obj)
    {
        if (MovementTracking == null) return;
        _movement.PrepareDirection(Vector2.zero);
        StopCoroutine(MovementTracking);
        MovementTracking = null;
    }

    private void FireInput(InputAction.CallbackContext obj)
    {
        float fire = obj.ReadValue<float>();
        if (fire == 1 && !isShielded)
        {
            if (canShoot)
            {
                _fire.FireBullet(2);
                canShoot = false;
                _sdRef.Instance.Play(ArrowNoise);
                StartCoroutine(Shoot());
            }
        }
    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.3f);
        canShoot = true;
    }

    private void ShieldInput(InputAction.CallbackContext obj)
    {
        float Block = obj.ReadValue<float>();
        if (Block == 1)
        {
            _shield.ShieldOut();
            isShielded = true;
        }
        else
        {
            _shield.StowedShield();
            isShielded = false;
        }
    }

}
