using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolutionDisplay : MonoBehaviour {

    public List<Color> DifferenceColors;
    public Text Solution;
    public Text Difference;


	// Use this for initialization
	void Start () {
        Solution.text = "";
        Difference.text = "";
    }

    // Update is called once per frame
    void Update () {
		
	}
    public void DisplayNewSolution(int _term1, int _term2, int _solution)
    {
        Solution.text = _term1.ToString()+"+"+_term2.ToString()+"="+_solution.ToString();
    }
    public void DisplayDifference(int diff)
    {
        AdjustDifferenceDisplayColor(diff);
        Difference.text = diff.ToString();
    }

    public void AdjustDifferenceDisplayColor(int diff)
    {
        if(diff > 9)
        {
            Difference.color = DifferenceColors[9];
        }
        if(diff <= 9)
        {
            Difference.color = DifferenceColors[diff];
        }
    }

}
