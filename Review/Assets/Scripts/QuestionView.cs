﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionView : MonoBehaviour
{
	[SerializeField] private GameObject defaultItem;

	public void Show(List<Question> questionList)
	{
		if (questionList == null)
		{
			return;
		}
		
		questionList.ForEach(x =>
		{
			GameObject obj = Instantiate(defaultItem);
			obj.transform.SetParent(defaultItem.transform.parent);
			obj.transform.localScale = Vector3.one;
			obj.SetActive(true);
			obj.GetComponent<QuestionViewItem>().Init(x);
		});
	}
	

}