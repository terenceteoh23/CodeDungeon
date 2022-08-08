using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxColider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;

    private void Start()
    {
        boxColider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //Reset the move delta
        moveDelta = new Vector3(x, y, 0);

        //swap sprite direction
        if(moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if(moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 0);
        }

        //make sure we can move on the y axis
        hit = Physics2D.BoxCast(transform.position, boxColider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Character", "Blocking"));

        if (hit.collider == null)
        {
            //make the player move
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        //make sure we can move on the x axis
        hit = Physics2D.BoxCast(transform.position, boxColider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Character", "Blocking"));

        if (hit.collider == null)
        {
            //make the player move
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }


    }

}
