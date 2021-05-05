using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InputWindow : MonoBehaviour
{
    [SerializeField] TaskViewer taskViewer;
    [SerializeField] TMP_InputField taskName;
    [SerializeField] TMP_InputField hours;
    [SerializeField] TMP_InputField minutes;
    [SerializeField] TMP_InputField dayDue;
    [SerializeField] TMP_InputField monthDue;
    [SerializeField] TMP_InputField yearDue;
    TaskList taskList;

    public void Awake()
    {
        Hide();
        taskList = FindObjectOfType<TaskList>();
        taskList.showTasks();
    }
    public void Show()
    {
        gameObject.SetActive(true);
        taskList.findBaseObjects();
        taskList.showTasks();
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    
    public void makeTask()
    {
        Debug.Log(taskName.text);
        if (hours.text.Equals(""))
        {
            hours.text = "0";
        }
        if (minutes.text.Equals(""))
        {
            minutes.text = "0";
        }
        int duration = (60 * Int32.Parse(hours.text)) + Int32.Parse(minutes.text);
        Task newTask = new Task(taskName.text, duration, monthDue.text, dayDue.text, yearDue.text, 0);
        taskList.Insert(newTask);

        taskName.text = "";
        hours.text = "";
        minutes.text = "";
        dayDue.text = "";
        monthDue.text = "";
        yearDue.text = "";
        
    }
}
