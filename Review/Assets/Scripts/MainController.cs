using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainController : MonoBehaviour
{
	private static MainController instance;

	public static MainController Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new GameObject("MainController").AddComponent<MainController>();
			}
			return instance;
		}
	}
	public Dictionary<int, Question> questionDic;

	public UnityAction OnLoadEndAction;
	
	public void Read(string path)
	{
		if (questionDic == null)
		{
			questionDic = new Dictionary<int, Question>();
		}
		questionDic.Clear();
		
		ReadExcel.Read(path).ForEach(x =>
		{
			questionDic.Add(x.id, x);
		});
		OnLoadEndAction.Invoke();
	}
}

[System.Serializable]
public class Question
{
	public int id;
	public string title;
	public string answer;
}
