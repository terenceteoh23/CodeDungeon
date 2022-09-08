using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManagerMCQ : MonoBehaviour
{
    public Button Choice1;
    public Text Choice1_Text;
    public Button Choice2;
    public Text Choice2_Text;
    public Button Choice3;
    public Text Choice3_Text;
    public Button Choice4;
    public Text Choice4_Text;
    public Text QuestionPrompt;
    public Text CorrectIndicator;
    public string CorrectAnswer;

    public PuzzleMCQ Puzzle;

    public void Start()
    {
        SetupPuzzle(Puzzle);
    }

    public void SetupPuzzle(PuzzleMCQ puzzle)
    {
        Choice1_Text.text = puzzle.Answer_1;
        Choice2_Text.text = puzzle.Answer_2;
        Choice3_Text.text = puzzle.Answer_3;
        Choice4_Text.text = puzzle.Answer_4;
        QuestionPrompt.text = puzzle.Question;

        CorrectAnswer = puzzle.CorrectAnswer;

        CorrectIndicator.text = "";
    }

    public void Check_Answer(string ans)
    {
        if(string.Equals(ans, CorrectAnswer))
        {
            CorrectIndicator.text = "Correct!";
        }
        else
        {
            CorrectIndicator.text = "Wrong....";
        }
    }

    public void Choice1_Selected()
    {
        Check_Answer(Choice1_Text.text);
    }

    public void Choice2_Selected()
    {
        Check_Answer(Choice2_Text.text);
    }

    public void Choice3_Selected()
    {
        Check_Answer(Choice3_Text.text);
    }

    public void Choice4_Selected()
    {
        Check_Answer(Choice4_Text.text);
    }
}


