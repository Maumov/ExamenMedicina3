using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActividadInicioViewer : BaseInterface {

    public GameObject inicioTallerCanvas;
    public GameObject inicioPracticaCanvas;
    public GameObject inicioExamenCanvas;

    public Text nombreEstudiante;

    private void Start() {
        nombreEstudiante.text = studentControl.estudiante.nombre;
    }

    public void BotonTaller()
    {
        gameObject.SetActive(false);
        inicioTallerCanvas.SetActive(true);
    }

    public void BotonPractica()
    {
        gameObject.SetActive(false);
        inicioPracticaCanvas.SetActive(true);
    }

    public void BotonExamen()
    {
        gameObject.SetActive(false);
        inicioExamenCanvas.SetActive(true);
    }
}
