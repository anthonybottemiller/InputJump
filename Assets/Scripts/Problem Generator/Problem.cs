using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Problem {
    public int addend1 = 0;
    public int addend2 = 0;
    public int solution = 0;
    public string operation = "";

    public Problem()
    {

    }

    public void SortTerms()
    {
        List<int> numbers = new List<int>
        {
            addend1,
            addend2
        };
        numbers.Sort();
    }

}
