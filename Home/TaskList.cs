using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskList : MonoBehaviour
{
    [SerializeField] GameObject baseTaskViewer;
    [SerializeField] TokenSystem tokenSystem;
    [SerializeField] GameObject editPopup;
    List<Task> tasks = new List<Task>();
    private void Awake()
    {
        
        int gameStatusCount = FindObjectsOfType<TaskList>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            
        }
        
    }
    public void findBaseObjects()
    {
       
        tokenSystem = FindObjectOfType<TokenSystem>();
        baseTaskViewer = GameObject.Find("TaskObject");
        Transform[] trs = GameObject.Find("Planner").GetComponentsInChildren<Transform>(true);
        foreach (Transform t in trs)
        {
            if (t.name == "Edit Popup")
            {   
                editPopup = t.gameObject;
            }
        }
        editPopup.SetActive(false);

    }
    public void Insert(Task task)
    {
        tasks.Insert(0, task);
        updateTaskIndeces();
        showTasks();
    }
    public void Delete(Task task, int tokens)
    {
        tasks.Remove(task);
        updateTaskIndeces();
        showTasks();
        tokenSystem.changeTokenAmountBy(tokens);
    }
    public void Edit(Task task)
    {
        editPopup.GetComponent<EditPopup>().StartEdit(task);
    }
    public void updateTaskIndeces()
    {
        for (int i = 0; i < tasks.Count; ++i)
        {
            tasks[i].changeIndex(i);
        }
    }
    public void showTasks()
    {
        var clones = GameObject.FindGameObjectsWithTag("Clone"); 
        foreach (var clone in clones) 
        { 
            Destroy(clone); 
        }
        for (int i = 0; i < tasks.Count; ++i)
        {
            GameObject newTaskViewer = Instantiate(baseTaskViewer);
            newTaskViewer.tag = "Clone";
            newTaskViewer.transform.SetParent(GameObject.FindGameObjectWithTag("Planner").transform, false);
            TaskViewer newTaskText = newTaskViewer.GetComponent<TaskViewer>();
            newTaskText.setTask(tasks[i]);
            
        }
    }

}
