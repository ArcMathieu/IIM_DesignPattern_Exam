using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, ITouchable
{
    public GameObject potPrefab;
    
    public void Touch(int power)
    {
        var b = Random.Range(0, 3);
        if (b > 1) Instantiate(potPrefab, transform.position, Quaternion.identity, null);
        Destroy(gameObject);
    }

   

}
