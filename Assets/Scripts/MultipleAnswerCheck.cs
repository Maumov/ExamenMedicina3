using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleAnswerCheck : MonoBehaviour
{
    PracticaViewer practicaViewer;
    // Start is called before the first frame update
    void Start()
    {
        practicaViewer = FindObjectOfType<PracticaViewer>();
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnswerSet() {
        practicaViewer.ActivateButton();
    }
}
