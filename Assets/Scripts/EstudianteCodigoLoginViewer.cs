using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EstudianteCodigoLoginViewer : BaseInterface {
    public InputField codigo;
    public Text nombreEstudiante;
    //public StudentControl studentControl;

    private void Start() {
        nombreEstudiante.text = studentControl.estudiante.nombre;
        studentControl.OnEnteredCode += NextInterface;
    }

    public void ButtonPressed() {
        studentControl.EntrarExamen(codigo.text);
    }



}
