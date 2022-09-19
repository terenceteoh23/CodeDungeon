using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMCQ 
{
    public string Question;
    public string CorrectAnswer;
    public string Answer_1;
    public string Answer_2;
    public string Answer_3;
    public string Answer_4;

    public PuzzleMCQ(string q, string ca, string a1, string a2, string a3, string a4)
    {
        Question = q;
        CorrectAnswer = ca;
        Answer_1 = a1;
        Answer_2 = a2;
        Answer_3 = a3;
        Answer_4 = a4;
    }
}
