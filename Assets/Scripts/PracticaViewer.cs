using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PracticaViewer : ExamenViewer {

    public string parrafo = "Cual es este video?";
    

    public override void ShowExamen() {
        ShowQuestion();
    }

    public override void ShowQuestion() {

       
        CreatePreguntaPack();
       
    }

    public void CreatePreguntaPack() {

        int randomVideoType = Random.Range(0, dataLoader.videosPractica.Count);
        int randomVideo = Random.Range(0, dataLoader.videosPractica[randomVideoType].videos.Count);
        CreateParrafo(parrafo);
        CreateVideoPractica(randomVideoType, randomVideo);

        //int randomAnswerA;
        //int randomAnswerB;
        //int randomAnswerC;
        //CreateMultiRespuesta();

    }
    public void CreateVideoPractica(int RVT, int RV) {
        GameObject go = Instantiate(Video, origin);
        VideoControllerPractica VCP = go.GetComponentInChildren<VideoControllerPractica>();
        VCP.video = dataLoader.videosPractica[RVT];
        VCP.videoSelected = RV;

    }
    public void ShowAnswer() {

    }

    public override void NextQuestion() {
        DeleteContent();
        currentPregunta++;
        ShowQuestion();
    }
}
