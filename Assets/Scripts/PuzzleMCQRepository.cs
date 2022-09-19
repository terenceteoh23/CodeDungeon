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

        /*if (puzzles.Count == 1)
        {
            puzzle = puzzles[0];
        }
        else
        {
            puzzle = puzzles[Random.Range(0, puzzles.Count - 1)];
        }*/

        puzzle = puzzles[0];
        

        return puzzle;
    }

    private void CreateRepository()
    {
        puzzles.Add(new PuzzleMCQ(
            "what is does the data type int contain",
            "10", 
            "\"attack\"", 
            "\'B\'", 
            "10", 
            "145.34"));

    }


}
