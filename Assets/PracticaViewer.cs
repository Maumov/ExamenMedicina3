using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PracticaViewer : ExamenViewer {

    public override void ShowQuestion() {
        inputs = new List<InputField>();
        if(currentPregunta < examen.preguntas.Count) {
            CreatePreguntaPack(examen.preguntas[currentPregunta]);
        } else {
            //EnviarExamen
            studentControl.SendRespuestas();
            //-----------
            NextInterface.SetActive(true);
            gameObject.SetActive(false);
        }

    }

    public void ShowAnswer() {

    }

    public override void NextQuestion() {
        for(int i = 0; i < inputs.Count; i++) {
            studentControl.SetAnswerToQuestion(currentPregunta, i, inputs[i].text);
        }
        DeleteContent();
        currentPregunta++;
        ShowQuestion();
    }
}
