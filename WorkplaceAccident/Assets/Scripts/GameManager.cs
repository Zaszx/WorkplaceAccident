using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public Transform AtilCurrentTaskParent;
	public Transform EnesCurrentTaskParent;

	public Transform TodoBoardParent;
	public Transform ReviewBoardParent;

	List<JiraTask> openTasks;
	List<JiraTask> reviewTasks;

	public Player Atil;
	public Player Enes;

	float reviewCooldown = 1.0f;
	float currentReviewTime = 0.0f;

    void Start()
    {
        
    }
	
    void Update()
    {
        if(TodoBoardParent.childCount == 0 || (TodoBoardParent.childCount + ReviewBoardParent.childCount < 6 && Random.value < 0.005f))
		{
			GenerateJiraTask();
		}

		UpdateHighlights();
		UpdateReviewTimer();

	}

	void UpdateReviewTimer()
	{
		if(ReviewBoardParent.childCount > 0)
			currentReviewTime += Time.deltaTime;
		if(currentReviewTime > reviewCooldown && ReviewBoardParent.childCount > 0)
		{
			currentReviewTime = 0;

			JiraTask taskToReview = ReviewBoardParent.GetChild(0).GetComponent<JiraTask>();
			if(taskToReview.solution == taskToReview.playerSubmission)
			{
				taskToReview.transform.SetParent(null);
				Destroy(taskToReview.gameObject);
			}
			else
			{
				taskToReview.state = JiraTask.State.Open;
				taskToReview.transform.SetParent(TodoBoardParent);
			}
		}
	}

	void UpdateHighlights()
	{
		foreach(Transform t in TodoBoardParent)
		{
			t.GetComponent<JiraTask>().atilSelection.SetActive(false);
			t.GetComponent<JiraTask>().enesSelection.SetActive(false);
		}

		if(Enes.highlightedTask != null)
			Enes.highlightedTask.enesSelection.SetActive(true);
		if(Atil.highlightedTask != null)
			Atil.highlightedTask.atilSelection.SetActive(true);
	}

	public void OnPlayerSubmittedTask(JiraTask task, Player player, string playerSolution)
	{
		task.OnPlayerSubmitted(playerSolution);
		task.transform.SetParent(ReviewBoardParent.transform);
	}

	public void OnPlayerSelectedTask(JiraTask task, Player player)
	{
		task.transform.SetParent(player.currentTaskParent);
		if (task == Atil.highlightedTask)
			Atil.highlightedTask = null;
		if (task == Enes.highlightedTask)
			Enes.highlightedTask = null;

		task.atilSelection.SetActive(false);
		task.enesSelection.SetActive(false);
	}

	public void GenerateJiraTask()
	{
		JiraTask newTask = Instantiate(Prefabs.JiraTaskPrefab).GetComponent<JiraTask>();

		float priorityRandom = Random.value;
		float typeRandom = Random.value;
		float assigneeRandom = Random.value;

		newTask.Init(priorityRandom < 0.3f ? JiraTask.Priority.Critical : priorityRandom < 0.7f ? JiraTask.Priority.Major : JiraTask.Priority.Minor,
					 typeRandom < 0.3f ? JiraTask.Type.Amele : typeRandom < 0.7f ? JiraTask.Type.Bug : JiraTask.Type.Feature,
					 assigneeRandom < 0.4f ? JiraTask.Assignee.Atil : assigneeRandom < 0.8f ? JiraTask.Assignee.Enes : JiraTask.Assignee.None);

		newTask.transform.SetParent(TodoBoardParent);
	}
}
