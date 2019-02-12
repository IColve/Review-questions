using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColveTest : MonoBehaviour 
{

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			MainController.Instance.Read(@"C:\Users\Administrator\Desktop\test.xlsx");
		}

		if (Input.GetKeyDown(KeyCode.S))
		{
			FindObjectOfType<QuestionView>().Show(MainController.Instance.questionDic.Values.ToList());
		}
	}
}
