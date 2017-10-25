using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemGenerator {
    public Problem currentProblem;

    public List<Problem> missedProblems;

    int iterationSinceMissed;


    public ProblemGenerator()
    {
        missedProblems = new List<Problem>();
    }

    public void NewProblem(string operation, int range0Upper, int range0Lower, int range1Upper, int range1Lower)
    {
        if (iterationSinceMissed > 2 && missedProblems.Count > 0)
        {
            currentProblem = missedProblems[0];
            missedProblems.Remove(missedProblems[0]);
        }

        else
        {
            currentProblem = new Problem();

            currentProblem.operation = operation;

            currentProblem.addend1 = Random.Range(range0Lower, range0Upper);
            currentProblem.addend2 = Random.Range(range1Lower, range1Upper);
            currentProblem.SortTerms();
            switch (operation)
            {
                case "-":
                    {
                        currentProblem.solution = currentProblem.addend1 - currentProblem.addend2;
                        break;
                    }
                case "*":
                    {
                        currentProblem.solution = currentProblem.addend1 * currentProblem.addend2;
                        break;
                    }
                case "/":
                    {
                        currentProblem.solution = currentProblem.addend1 / currentProblem.addend2;
                        break;
                    }
                default:
                    {
                        currentProblem.solution = currentProblem.addend1 + currentProblem.addend2;
                        break;
                    }
            }
        }
    }

    public bool CheckSolution(int answer)
    {
        Debug.Log("Iteration" + iterationSinceMissed.ToString());
        bool isCorrect = currentProblem.solution == answer;
        if(!isCorrect)
        {
            iterationSinceMissed = 0;
            missedProblems.Add(this.currentProblem);
        }
        else { iterationSinceMissed++; }
        return isCorrect;
    }
}
