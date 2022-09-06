using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropSystem : MonoBehaviour
{
    public GameObject correctForm;
    private bool moving;

    private float startPosX;
    private float startPosY;

    private Vector3 resetPosition;

    public void Start()
    {
        resetPosition = this.transform.localPosition;
    }
    public void Update()
    {
        if (moving)
        {
            Vector3 mousePos;

            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);
        }
    }

    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;

            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            moving = true;
        }
    }

    public void OnMouseUp()
    {
        moving = false;
        if(Mathf.Abs(this.transform.localPosition.x - correctForm.transform.localPosition.x) <= 0.5f && (this.transform.localPosition.y - correctForm.transform.localPosition.y ) <= 0.5f)
        {
            this.transform.localPosition = correctForm.transform.localPosition;
            //this.transform.localPosition = new Vector3(correctForm.transform.localPosition.x, correctForm.transform.localPosition.y, correctForm.transform.localPosition.z);
        }
        else
        {
            this.transform.localPosition = resetPosition;
        }
    }

}
