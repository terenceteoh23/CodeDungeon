using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMangerDND : MonoBehaviour
{
    public GameObject AnswerSlot1;
    public GameObject AnswerSlot2;

    public GameObject Choice1;
    public GameObject Choice2;
    public GameObject Choice3;
    public GameObject Choice4;

    private Vector3 Choice1Pos;
    private Vector3 Choice2Pos;
    private Vector3 Choice3Pos;
    private Vector3 Choice4Pos;

    public GameObject Correct1;
    public GameObject Correct2;

    private bool AnswerSlot1Active;
    private bool AnswerSlot2Active;

    public void Start()
    {
        AnswerSlot1Active = true;
        AnswerSlot2Active = true;
    }

    public void Update()
    {
        Choice1Pos = Choice1.transform.position;
        Choice2Pos = Choice2.transform.position;
        Choice3Pos = Choice3.transform.position;
        Choice4Pos = Choice4.transform.position;

        if (AnswerSlot1Active)
        {
            if (Mathf.Abs(Choice1Pos.x - AnswerSlot1.transform.position.x) <= 0.01f && (Choice1Pos.y - AnswerSlot1.transform.position.y) <= 0.01f)
            {
                if(GameObject.ReferenceEquals(Choice1, Correct1) || GameObject.ReferenceEquals(Choice1, Correct2))
                {
                    AnswerSlot1Active = false;
                }
                else
                {
                    WrongAnswer(Choice1);
                }
            }

            if (Mathf.Abs(Choice2Pos.x - AnswerSlot1.transform.position.x) <= 0.01f && (Choice2Pos.y - AnswerSlot1.transform.position.y) <= 0.01f)
            {
                if (GameObject.ReferenceEquals(Choice1, Correct1) || GameObject.ReferenceEquals(Choice1, Correct2))
                {
                    AnswerSlot1Active = false;
                }
                else
                {
                    WrongAnswer(Choice2);
                }
            }

            if (Mathf.Abs(Choice3Pos.x - AnswerSlot1.transform.position.x) <= 0.01f && (Choice3Pos.y - AnswerSlot1.transform.position.y) <= 0.01f)
            {
                if (GameObject.ReferenceEquals(Choice1, Correct1) || GameObject.ReferenceEquals(Choice1, Correct2))
                {
                    AnswerSlot1Active = false;
                }
                else
                {
                    WrongAnswer(Choice3);
                }
            }

            if (Mathf.Abs(Choice4Pos.x - AnswerSlot1.transform.position.x) <= 0.01f && (Choice4Pos.y - AnswerSlot1.transform.position.y) <= 0.01f)
            {
                if (GameObject.ReferenceEquals(Choice1, Correct1) || GameObject.ReferenceEquals(Choice1, Correct2))
                {
                    AnswerSlot1Active = false;
                }
                else
                {
                    WrongAnswer(Choice4);
                }
            }
        }

        if (AnswerSlot2Active)
        {
            if (Mathf.Abs(Choice1Pos.x - AnswerSlot2.transform.position.x) <= 0.01f && (Choice1Pos.y - AnswerSlot2.transform.position.y) <= 0.01f)
            {
                if (GameObject.ReferenceEquals(Choice1, Correct1) || GameObject.ReferenceEquals(Choice1, Correct2))
                {
                    AnswerSlot2Active = false;
                }
                else
                {
                    WrongAnswer(Choice1);
                }
            }

            if (Mathf.Abs(Choice2Pos.x - AnswerSlot2.transform.position.x) <= 0.01f && (Choice2Pos.y - AnswerSlot2.transform.position.y) <= 0.01f)
            {
                if (GameObject.ReferenceEquals(Choice1, Correct1) || GameObject.ReferenceEquals(Choice1, Correct2))
                {
                    AnswerSlot2Active = false;
                }
                else
                {
                    WrongAnswer(Choice2);
                }
            }

            if (Mathf.Abs(Choice3Pos.x - AnswerSlot2.transform.position.x) <= 0.01f && (Choice3Pos.y - AnswerSlot2.transform.position.y) <= 0.01f)
            {
                if (GameObject.ReferenceEquals(Choice1, Correct1) || GameObject.ReferenceEquals(Choice1, Correct2))
                {
                    AnswerSlot2Active = false;
                }
                else
                {
                    WrongAnswer(Choice3);
                }
            }

            if (Mathf.Abs(Choice4Pos.x - AnswerSlot2.transform.position.x) <= 0.01f && (Choice4Pos.y - AnswerSlot2.transform.position.y) <= 0.01f)
            {
                if (GameObject.ReferenceEquals(Choice1, Correct1) || GameObject.ReferenceEquals(Choice1, Correct2))
                {
                    AnswerSlot2Active = false;
                }
                else
                {
                    WrongAnswer(Choice4);
                }
            }
        }
    }

    private void WrongAnswer(GameObject go)
    {
        go.SetActive(false);
    }
}
