using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMCQ 
{
    public string Question;
    public string CorrectAnswer;
    public string Answer_1;
    public string Explain_1;
    public string Answer_2;
    public string Explain_2;
    public string Answer_3;
    public string Explain_3;
    public string Answer_4;
    public string Explain_4;

    public PuzzleMCQ(string q, string ca, string a1, string e1, string a2, string e2, string a3, string e3, string a4, string e4)
    {
        Question = q;
        CorrectAnswer = ca;
        Answer_1 = a1;
        Explain_1 = e1;
        Answer_2 = a2;
        Explain_2 = e2;
        Answer_3 = a3;
        Explain_3 = e3;
        Answer_4 = a4;
        Explain_4 = e4;
    }
}
