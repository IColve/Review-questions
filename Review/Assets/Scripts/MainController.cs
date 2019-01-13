using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	
	public void Read(string path)
	{
		if (questionDic == null)
		{
			questionDic = new Dictionary<int, Question>();
		}
		
		ReadExcel.Read(path).ForEach(x =>
		{
			questionDic.Add(x.id, x);
		});
	}
	
	
	
	
	

}

[System.Serializable]
public class Question
{
	public int id;
	public string title;
	public string answer;
}
