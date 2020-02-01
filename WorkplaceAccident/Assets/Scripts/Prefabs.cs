using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Prefabs
{
	public static GameObject LeftArrow;
	public static GameObject RightArrow;
	public static GameObject UpArrow;
	public static GameObject DownArrow;

	public static GameObject JiraTaskPrefab;

	public static Sprite AtilSprite;
	public static Sprite EnesSprite;

	static Prefabs()
	{
		LeftArrow = Resources.Load<GameObject>("Prefabs/LeftArrow");
		RightArrow = Resources.Load<GameObject>("Prefabs/RightArrow");
		UpArrow = Resources.Load<GameObject>("Prefabs/UpArrow");
		DownArrow = Resources.Load<GameObject>("Prefabs/DownArrow");

		JiraTaskPrefab = Resources.Load<GameObject>("Prefabs/JiraTask");

		AtilSprite = Resources.Load<Sprite>("Sprites/atil");
		EnesSprite = Resources.Load<Sprite>("Sprites/enes");
	}
}
