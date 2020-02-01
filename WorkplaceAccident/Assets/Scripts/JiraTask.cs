using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JiraTask : MonoBehaviour
{
	public TMPro.TMP_Text description;
	public Image assignee;
	public Image typeImage;
	public TMPro.TMP_Text typeText;
	public Image priorityImage;
	public TMPro.TMP_Text priorityText;

	public string solution;

	public string playerSubmission;

    void Start()
    {
        
    }
	
    void Update()
    {
        
    }

	public void OnPlayerSubmitted(string playerSolution)
	{
		playerSubmission = playerSolution;
	}
}
