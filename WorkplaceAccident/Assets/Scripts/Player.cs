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

	public Transform currentTaskSequence;

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
		HandleInput();
    }

	void HandleInput()
	{
		if(selectedTask != null)
		{
			if(Input.GetKeyDown(UpKey))
			{
				currentSequence += "U";
				GameObject newSequenceObject = Instantiate(Prefabs.UpArrow);
				newSequenceObject.transform.SetParent(sequenceParent);
			}
			if (Input.GetKeyDown(DownKey))
			{
				currentSequence += "D";
				GameObject newSequenceObject = Instantiate(Prefabs.DownArrow);
				newSequenceObject.transform.SetParent(sequenceParent);
			}
			if (Input.GetKeyDown(LeftKey))
			{
				currentSequence += "L";
				GameObject newSequenceObject = Instantiate(Prefabs.LeftArrow);
				newSequenceObject.transform.SetParent(sequenceParent);
			}
			if (Input.GetKeyDown(RightKey))
			{
				currentSequence += "R";
				GameObject newSequenceObject = Instantiate(Prefabs.RightArrow);
				newSequenceObject.transform.SetParent(sequenceParent);
			}
			if (Input.GetKeyDown(SubmitKey))
			{
				foreach(Transform t in sequenceParent)
				{
					Destroy(t.gameObject);
				}
				foreach (Transform t in currentTaskSequence)
				{
					Destroy(t.gameObject);
				}
				gameManager.OnPlayerSubmittedTask(selectedTask, this, currentSequence);
				selectedTask = null;
				currentSequence = "";
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

			if (Input.GetKeyDown(DownKey))
			{
				int currentIndex = highlightedTask.transform.GetSiblingIndex();
				if(currentIndex < gameManager.TodoBoardParent.childCount - 1)
				{
					highlightedTask = gameManager.TodoBoardParent.GetChild(currentIndex + 1).GetComponent<JiraTask>();
				}
			}
			if (Input.GetKeyDown(UpKey))
			{
				int currentIndex = highlightedTask.transform.GetSiblingIndex();
				if (currentIndex > 0)
				{
					highlightedTask = gameManager.TodoBoardParent.GetChild(currentIndex - 1).GetComponent<JiraTask>();
				}
			}

			if (Input.GetKeyDown(SubmitKey))
			{
				selectedTask = highlightedTask;
				highlightedTask = null;
				gameManager.OnPlayerSelectedTask(selectedTask, this);

				foreach(char ch in selectedTask.solution)
				{
					GameObject newSequenceObject;
					if (ch == 'U')
					{
						newSequenceObject = Instantiate(Prefabs.UpArrow);
					}
					else if (ch == 'D')
					{
						newSequenceObject = Instantiate(Prefabs.DownArrow);
					}
					else if (ch == 'L')
					{
						newSequenceObject = Instantiate(Prefabs.LeftArrow);
					}
					else
					{
						newSequenceObject = Instantiate(Prefabs.RightArrow);
					}
					newSequenceObject.transform.SetParent(currentTaskSequence);
				}
			}
		}
	}
}
