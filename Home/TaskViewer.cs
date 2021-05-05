using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskViewer : MonoBehaviour
{
    readonly int MINUTES_PER_TOKEN = 10;

    [SerializeField] TaskList taskList;
    [SerializeField] TextMeshProUGUI TaskName;
    [SerializeField] TextMeshProUGUI TaskProperties;
    [SerializeField] Button doneButton;
    [SerializeField] Task task;
    private void Awake()
    {
        taskList = FindObjectOfType<TaskList>();
    }
    public void setTask(Task task)
    {
        this.task = task;
        string duration = (task.duration / 60) + "hr, " + (task.duration % 60) + "min";
        TaskName.text = task.taskName;
        TaskProperties.text = duration + ", " + task.month + "/" + task.day + "/" + task.year;
        
    }
    public void onDelete()
    {
        taskList.Delete(task, task.duration / MINUTES_PER_TOKEN);
    }
    public void onEdit()
    {
        taskList.Edit(task);
    }
}
