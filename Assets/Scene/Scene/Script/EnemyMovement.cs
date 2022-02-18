using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveEnemy());
    }
    private IEnumerator MoveEnemy()
    {
        float timer = 0;
        float timerStart = 3;
        while (true)
        {
            Vector2 randomOffset = Random.insideUnitCircle * 3;
            Vector2 destination = (Vector2)transform.parent.position + (Vector2)randomOffset;

            while ((Vector2)transform.parent.position != destination || timer > timerStart)
            {
                timer += Time.deltaTime;
                transform.parent.position = Vector2.MoveTowards((Vector2)transform.parent.position, destination, moveSpeed * Time.deltaTime);

                yield return null;
            }

            // wait a bit until we continue
            yield return new WaitForSeconds(2);
            timer = 0;
        }
    }

}
