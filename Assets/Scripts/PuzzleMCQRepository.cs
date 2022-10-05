using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMCQRepository : MonoBehaviour
{
    private List<PuzzleMCQ> puzzles = new List<PuzzleMCQ>();

    public void Start()
    {
        CreateRepository();
    }

    public PuzzleMCQ GetRandomPuzzleMCQ()
    {
        PuzzleMCQ puzzle;

        if (puzzles.Count == 1)
        {
            puzzle = puzzles[0];
        }
        else
        {
            puzzle = puzzles[Random.Range(0, puzzles.Count)];
        }

        return puzzle;
    }

    private void CreateRepository()
    {
        puzzles.Add(new PuzzleMCQ(
            "Which symbol equates to not equal",
            "!=",
            "#=",
            "Wrong, This symbol does not exist",
            "!=",
            "Correct!!",
            "==",
            "Wrong, This symbol equates to equal",
            "\'=",
            "Wrong, This symbol does not exist"));

        puzzles.Add(new PuzzleMCQ(
            "Which symbol equates to larger than or equal",
            ">=",
            ">=",
            "Correct!!",
            "==",
            "Wrong, This symbol equates to equal",
            ">",
            "Wrong, This symbol equates to larger than",
            "=>",
            "Wrong, This symbol is ordered incorrectly"));

        puzzles.Add(new PuzzleMCQ(
            "Which of the following are examples of correct naming of identifiers",
            "first",
            "first",
            "Correct!!",
            "2nd",
            "Wrong, an indentifier cannot begin with a digit",
            "Thi rd",
            "Wrong, an indentifier cannot contain an empty space",
            "five!",
            "Wrong, an indentifier cannot contain any special symbols"));

        puzzles.Add(new PuzzleMCQ(
            "What is does the data type int used to contain",
            "10",
            "\"attack\"",
            "Wrong, This is a string not an int",
            "\'B\'",
            "Wrong, This is a char not an int",
            "10",
            "Correct!!",
            "145.34",
            "Wrong, This is a float not an int"));

        puzzles.Add(new PuzzleMCQ(
            "Which symbol will has the highest order of precedence",
            "%",
            "+",
            "Wrong, this symbol has a lower order of precedence",
            "%",
            "Correct!!",
            "=",
            "Wrong, this symbol has no order of precedence",
            "-",
            "Wrong, this symbol has a lower order of precedence"));

        puzzles.Add(new PuzzleMCQ(
            "What is the outcome of this equation\n3 / 2 + 5.5",
            "6.5",
            "7",
            "Wrong, integer division works differently in programming",
            "2",
            "Wrong, the order of precedence is incorrect",
            "4.5",
            "Wrong",
            "6.5",
            "Correct!!"));

    }


}
