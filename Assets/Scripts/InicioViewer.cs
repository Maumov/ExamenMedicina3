using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioViewer : MonoBehaviour
{
    public GameObject InicioEstudiante;
    public GameObject InicioProfesor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BotonEstudiante() {
        gameObject.SetActive(false);
        InicioEstudiante.SetActive(true);
    }

    public void BotonProfesor() {
        gameObject.SetActive(false);
        InicioProfesor.SetActive(true);
    }
}
