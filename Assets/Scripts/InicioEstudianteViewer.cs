using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InicioEstudianteViewer : BaseInterface {

    public InputField estudiante;

    private void Start() {
        studentControl.OnLoginSuccesful += NextInterface;
    }

    public void ButtonPressed() {
        studentControl.Login(estudiante.text);
    }

}
