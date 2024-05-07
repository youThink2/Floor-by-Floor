using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform target;
    public float speed =4f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = target.position - transform.position;

        if(direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x * Mathf.Rad2Deg);
            transform.right = direction.normalized; //Faces the player
        }

        //Move towards target
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
