using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuViewItem : MonoBehaviour
{
	[SerializeField] private Text titleText;
	[SerializeField] private Text answerText;

	public void Init(Question question)
	{
		titleText.text = question.id + ":" + question.title;
		answerText.text = question.answer;
		answerText.gameObject.SetActive(false);
	}

	public void OnClick()
	{
		answerText.gameObject.SetActive(!answerText.gameObject.activeSelf);
		GetComponentInChildren<ContentSizeFitter>().enabled = true;
		GetComponent<ContentSizeFitter>().enabled = true;
		Invoke("ClickEnd",0.02f);
	}

	private void ClickEnd()
	{
		GetComponentInChildren<ContentSizeFitter>().enabled = false;
		GetComponent<ContentSizeFitter>().enabled = false;
	}
}
