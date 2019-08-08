using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInterface : MonoBehaviour
{
    public GameObject NextView, PreviusView;
    [HideInInspector]
    public StudentControl studentControl;
    [HideInInspector]
    public TeacherControl teacherControl;

    private void Awake() {
        teacherControl = FindObjectOfType<TeacherControl>();
        studentControl = FindObjectOfType<StudentControl>();
    }

    public void NextInterface() {
        gameObject.SetActive(false);
        NextView.SetActive(true);
    }

    public void PreviousInterface() {
        gameObject.SetActive(false);
        PreviusView.SetActive(true);
    }
    
}
