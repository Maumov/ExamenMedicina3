using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudentNameViewer : MonoBehaviour
{
    public Text text;
    StudentControl studentControl;
    // Start is called before the first frame update
    void Start()
    {
        studentControl = FindObjectOfType<StudentControl>();
        if(studentControl.isLoggedIn()) {
            ShowName();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowName() {
        text.text = studentControl.estudiante.nombre + " " + studentControl.estudiante.apellido;
    }

    private void OnEnable() {
        Start();
    }
}
