using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickingObject : MonoBehaviour
{
    public bool _hasKey;

    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponentInParent<IPickable>()?.PickUp();
    }
}
