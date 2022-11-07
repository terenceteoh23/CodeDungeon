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
            //puzzle = puzzles[8];
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

        puzzles.Add(new PuzzleMCQ(
            "num1 = 0;\n" +
            "num2 = 50;\n" +
            "num3 = 60;\n" +
            "num1 = num2;\n" +
            "cout << num1 + num3;\n\n" +
            "What does the cout print?",
            "110",
            "60",
            "Wrong",
            "50",
            "Wrong",
            "0",
            "Wrong",
            "110",
            "Correct!!"));

        puzzles.Add(new PuzzleMCQ(
            "for(int i=0;i<=5;i++)\n" +
            "   num += 5;\n\n" +
            "num += 10;\n" +
            "cout << num;\n\n" +
            "What does the cout print?",
            "40",
            "45",
            "Wrong, check the amount of iterations in the loop",
            "40",
            "Correct!!",
            "35",
            "Wrong, check the amount of iterations in the loop",
            "50",
            "Wrong, check the amount of iterations in the loop"));

        puzzles.Add(new PuzzleMCQ(
            "string num1 = \"10\"\n" +
            "string num2 = \"20\"\n" +
            "cout << num2 + num1;\n\n" +
            "What does the cout print?",
            "2010",
            "2010",
            "Correct!!",
            "30",
            "Wrong, the variables are strings not int",
            "1020",
            "Wrong",
            "Error",
            "Wrong"));

        puzzles.Add(new PuzzleMCQ(
            "What is the outcome of this equation\n9 / 2 + 3.4",
            "7.4",
            "7.9",
            "Wrong, integer division works differently in programming",
            "7.4",
            "Correct!!",
            "1",
            "Wrong, the order of precedence is incorrect",
            "10",
            "Wrong"));

        puzzles.Add(new PuzzleMCQ(
            "Which symbol equates to is equal",
            "==",
            ">=",
            "Wrong, This symbol equates to larger than or equal",
            "==",
            "Correct!!",
            "=>",
            "Wrong, This symbol is ordered incorrectly",
            ">",
            "Wrong, This symbol equates to larger than"));



    }


}
