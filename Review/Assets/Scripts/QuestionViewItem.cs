using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionViewItem : MonoBehaviour
{
	[SerializeField] private Text titleText;
	[SerializeField] private Text answerText;
	
	public void Init(Question question)
	{
		titleText.text = question.title;
	}
	
}
