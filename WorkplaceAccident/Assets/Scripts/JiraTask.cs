using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JiraTask : MonoBehaviour
{
	public enum State
	{
		Open,
		InProgress,
		Review,
		Done,
	}

	public enum Priority
	{
		Minor,
		Major,
		Critical,
	}

	public enum Type
	{
		Bug,
		Amele,
		Feature,
	}

	public enum Assignee
	{
		Atil,
		Enes,
		None,
	}

	public TMPro.TMP_Text description;
	public Image assigneeImage;
	public Image typeImage;
	public TMPro.TMP_Text typeText;
	public Image priorityImage;
	public TMPro.TMP_Text priorityText;

	public string solution;

	public string playerSubmission;

	public State state;
	public Priority priority;
	public Type type;
	public Assignee assignee;

	public GameObject atilSelection;
	public GameObject enesSelection;

	void Start()
    {
		state = State.Open;
    }

	public void Init(Priority priority, Type type, Assignee assignee)
	{
		priorityText.text = priority.ToString();
		typeText.text = type.ToString();
		assigneeImage.sprite = assignee == Assignee.Atil ? Prefabs.AtilSprite : assignee == Assignee.Enes ? Prefabs.EnesSprite : null;

		if(type == Type.Amele)
		{
			char randomElement = GetRandomSequenceElement();
			int length = Random.Range(15, 20);
			for (int i = 0; i < length; i++)
				solution += randomElement;
		}
		else if(type == Type.Bug)
		{
			int length = Random.Range(5, 8);
			for (int i = 0; i < length; i++)
				solution += GetRandomSequenceElement();
		}
		else if(type == Type.Feature)
		{
			int length = Random.Range(10, 15);
			for (int i = 0; i < length; i++)
				solution += GetRandomSequenceElement();
		}
	}

    void Update()
    {
        
    }

	public void OnPlayerSubmitted(string playerSolution)
	{
		playerSubmission = playerSolution;
		state = State.Review;
	}

	char GetRandomSequenceElement()
	{
		float val = Random.value;
		if (val < 0.25f)
			return 'U';
		else if (val < 0.5f)
			return 'D';
		else if (val < 0.75f)
			return 'L';
		else
			return 'R';
	}
}
