using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManagerMCQ : MonoBehaviour
{
    //elements for the UI
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
    private string CorrectAnswer;

    private PuzzleMCQ Puzzle;
    public PuzzleMCQRepository Repository;
    private bool correct;

    public void StartPuzzle()
    {
        Puzzle = Repository.GetRandomPuzzleMCQ();
        SetupPuzzle(Puzzle);
        CorrectAnswer = Puzzle.CorrectAnswer;
        correct = false;
    }

    public bool GetCorrect()
    {
        return correct;
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

    public IEnumerator Check_Answer(string ans)
    {
        if(string.Equals(ans, CorrectAnswer))
        {
            CorrectIndicator.text = "Correct!";
            correct = true;
            yield return new WaitForSeconds(2f);
        }
        else
        {
            CorrectIndicator.text = "Wrong....";
            correct = false;
            yield return new WaitForSeconds(2f);
        }
    }

    public void Choice1_Selected()
    {
        StartCoroutine(Check_Answer(Choice1_Text.text));
    }

    public void Choice2_Selected()
    {
        StartCoroutine(Check_Answer(Choice2_Text.text));
    }

    public void Choice3_Selected()
    {
        StartCoroutine(Check_Answer(Choice3_Text.text));
    }

    public void Choice4_Selected()
    {
        StartCoroutine(Check_Answer(Choice4_Text.text));
    }
}


