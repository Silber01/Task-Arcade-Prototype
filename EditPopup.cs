using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class EditPopup : MonoBehaviour
{
    private Task task;
    [SerializeField] TaskList taskList;
    [SerializeField] TMP_InputField taskName;
    [SerializeField] TMP_InputField hours;
    [SerializeField] TMP_InputField minutes;
    [SerializeField] TMP_InputField dayDue;
    [SerializeField] TMP_InputField monthDue;
    [SerializeField] TMP_InputField yearDue;
    void Awake()
    {
        gameObject.SetActive(false);
        taskList = FindObjectOfType<TaskList>();
    }

    public void StartEdit(Task task)
    {
        gameObject.SetActive(true);
        this.task = task;
        taskName.text = task.taskName;
        hours.text = (task.duration / 60) + "";
        minutes.text = (task.duration % 60) + "";
        dayDue.text = task.day;
        monthDue.text = task.month;
        yearDue.text = task.year;
    }
    public void Cancel()
    {
        gameObject.SetActive(false);
        Debug.Log("yeah");
    }
    public void FinishEdit()
    {
        task.taskName = taskName.text;
        if (hours.text.Equals(""))
        {
            hours.text = "0";
        }
        if (minutes.text.Equals(""))
        {
            minutes.text = "0";
        }
        task.duration = (60 * Int32.Parse(hours.text)) + Int32.Parse(minutes.text);
        task.day = dayDue.text;
        task.month = monthDue.text;
        task.year = yearDue.text;
        taskList.showTasks();
        gameObject.SetActive(false);
    }
}
