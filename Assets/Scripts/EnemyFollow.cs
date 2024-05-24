using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform target;
    public float speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            //Move towards this direction
            Vector2 direction = target.position - transform.position;

            if (direction != Vector2.zero)
            {
                float angle = Mathf.Atan2(direction.y, direction.x * Mathf.Rad2Deg);
                //Face the player
                transform.right = direction.normalized;
            }

            // Move towards target
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
       
    }
}
