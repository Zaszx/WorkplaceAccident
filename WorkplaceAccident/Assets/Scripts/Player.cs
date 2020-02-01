using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public GameManager gameManager;

	public JiraTask selectedTask;
	public JiraTask highlightedTask;

	public Transform currentTaskParent;
	public Transform sequenceParent;

	public string currentSequence;

	public KeyCode UpKey;
	public KeyCode DownKey;
	public KeyCode LeftKey;
	public KeyCode RightKey;
	public KeyCode SubmitKey;

    void Start()
    {

    }
	
    void Update()
    {
        
    }

	void HandleInput()
	{
		if(selectedTask != null)
		{
			if(Input.GetKeyDown(UpKey))
			{
				currentSequence += "U";
			}
			if (Input.GetKeyDown(DownKey))
			{
				currentSequence += "D";
			}
			if (Input.GetKeyDown(LeftKey))
			{
				currentSequence += "L";
			}
			if (Input.GetKeyDown(RightKey))
			{
				currentSequence += "R";
			}
			if (Input.GetKeyDown(SubmitKey))
			{
				gameManager.OnPlayerSubmittedTask(selectedTask, this, currentSequence);
			}
		}
		else
		{
			if (highlightedTask == null && gameManager.TodoBoardParent.childCount == 0)
				return;

			if(highlightedTask == null)
			{
				highlightedTask = gameManager.TodoBoardParent.GetChild(0).GetComponent<JiraTask>();
			}

			if (Input.GetKeyDown(UpKey))
			{
				int currentIndex = highlightedTask.transform.GetSiblingIndex();
				if(currentIndex < gameManager.TodoBoardParent.childCount - 1)
				{
					highlightedTask = gameManager.TodoBoardParent.GetChild(currentIndex + 1).GetComponent<JiraTask>();
				}
			}
			if (Input.GetKeyDown(DownKey))
			{
				int currentIndex = highlightedTask.transform.GetSiblingIndex();
				if (currentIndex > 0)
				{
					highlightedTask = gameManager.TodoBoardParent.GetChild(currentIndex - 1).GetComponent<JiraTask>();
				}
			}

			if (Input.GetKeyDown(SubmitKey))
			{
				gameManager.OnPlayerSelectedTask(selectedTask, this);
				selectedTask = highlightedTask;
				highlightedTask = null;
			}
		}
	}
}
