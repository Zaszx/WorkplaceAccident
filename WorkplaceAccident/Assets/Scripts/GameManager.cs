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

    void Start()
    {
        
    }
	
    void Update()
    {
        
    }

	public void OnPlayerSubmittedTask(JiraTask task, Player player, string playerSolution)
	{

	}

	public void OnPlayerSelectedTask(JiraTask task, Player player)
	{

	}
}
