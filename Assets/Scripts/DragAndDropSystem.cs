using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropSystem : MonoBehaviour
{
    public GameObject AnswerSlot1;
    public GameObject AnswerSlot2;

    private bool moving;

    private float startPosX;
    private float startPosY;

    private Vector3 resetPosition;

    public void Start()
    {
        resetPosition = this.transform.position;
    }

    public void Update()
    {
        if (moving)
        {
            Vector3 mousePos;

            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.position = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.position.z);
        }
    }

    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;

            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.position.x;
            startPosY = mousePos.y - this.transform.position.y;

            moving = true;
        }
    }

    public void OnMouseUp()
    {
        moving = false;

        if(Mathf.Abs(this.transform.position.x - AnswerSlot1.transform.position.x) <= 0.01f && (this.transform.position.y - AnswerSlot1.transform.position.y ) <= 0.01f)
        {
            this.transform.position = AnswerSlot1.transform.position;
        }
        else
        {
            if (Mathf.Abs(this.transform.position.x - AnswerSlot2.transform.position.x) <= 0.01f && (this.transform.position.y - AnswerSlot2.transform.position.y) <= 0.01f)
            {
                this.transform.position = AnswerSlot2.transform.position;
            }
            else
            {
                this.transform.position = resetPosition;
            }
        }
    }

}
