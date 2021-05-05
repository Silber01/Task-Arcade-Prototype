using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTaskMechanics : MonoBehaviour
{
    [SerializeField] TaskViewer taskViewer;
    public void callDelete()
    {
        taskViewer.onDelete();
    }
    public void callEdit()
    {
        taskViewer.onEdit();
    }
}
