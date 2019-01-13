using System.Collections.Generic;
using System.IO;
using Excel;
using UnityEngine;
using System.Data;

public class ReadExcel : MonoBehaviour
{
    public static List<Question> Read(string url)
    {
        FileStream stream = File.Open(url, FileMode.Open, FileAccess.Read);
        IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

        DataSet result = excelReader.AsDataSet();

        int columns = result.Tables[0].Columns.Count;
        int rows = result.Tables[0].Rows.Count; 

        List<Question> questionList = new List<Question>();
        for (int i = 1; i < rows; i++)
        {
            Question question = new Question()
            {
                id = int.Parse(result.Tables[0].Rows[i][0].ToString()),
                title = result.Tables[0].Rows[i][1].ToString(),
                answer = result.Tables[0].Rows[i][2].ToString()
            };
            questionList.Add(question);
        }

        return questionList;
    }
}