using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform lookAT;
    public float boundX = 0.3f;
    public float boundY = 0.15f;

    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        //check if we are inside bounds X
        float deltaX = lookAT.position.x - transform.position.x;
        if(deltaX > boundX || deltaX < -boundX)
        {
            if(transform.position.x < lookAT.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }

        //check if we are inside bounds Y
        float deltaY = lookAT.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < lookAT.position.y) 
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);

    }

}
