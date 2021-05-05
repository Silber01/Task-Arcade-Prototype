using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task
{
    public string taskName;
    public int duration;
    public string day;
    public string month;
    public string year;
    public int index;
    public Task(string taskName, int duration, string day, string month, string year, int index)
    {
        this.taskName = taskName;
        this.duration = duration;
        this.day = day;
        this.month = month;
        this.year = year;
        this.index = index;
    }
    
    public void changeIndex(int index)
    {
        this.index = index;
    }
}
