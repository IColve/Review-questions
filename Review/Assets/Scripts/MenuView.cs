using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityToolbag;

public class MenuView : MonoBehaviour
{

	private MainController instance;
	[SerializeField]
	private GameObject menuItem;
	[SerializeField]
	private Transform content;
	private void Awake()
	{
		instance = MainController.Instance;
		instance.OnLoadEndAction = () => RefreshView();
	}


	public void LoadFile()
	{
		FileBrowser.OpenFilePanel("Open file Title", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), new string[]{"xlsx"}, null, (bool canceled, string filePath) => 
		{
			if (canceled)
			{
				Debug.Log("cancel");
				return;
			}
			Dispatcher.Invoke(() =>
			{
				instance.Read(filePath);
			});
		});
	}


	public void RefreshView()
	{
		for (int i = content.childCount - 1; i >= 0; i--)
		{
			Destroy(content.transform.GetChild(i).gameObject);	
		}

		List<Question> questions = instance.questionDic.Values.ToList();
		questions.ForEach(x =>
		{
			GameObject obj = Instantiate(menuItem, content);
			obj.transform.localScale = Vector3.one;
			obj.GetComponent<MenuViewItem>().Init(x);
		});
	}
}
