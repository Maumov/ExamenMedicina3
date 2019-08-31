using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Security.Cryptography;
using UnityEngine.UI;
using System;

public class PracticaViewer : ExamenViewer {

    public Color green, red;
    
    public string parrafo = "Cual es este video?";
    public string rightAnswer;

    public override void ShowExamen() {
        ShowQuestion();
    }

    public override void ShowQuestion() {

       
        CreatePreguntaPack();
       
    }

    public void CreatePreguntaPack() {

        int randomVideoType = UnityEngine.Random.Range(0, dataLoader.videosPractica.Count);
        int randomVideo = UnityEngine.Random.Range(0, dataLoader.videosPractica[randomVideoType].videos.Count);
        CreateParrafo(parrafo);
        CreateVideoPractica(randomVideoType, randomVideo);

        List<string> answers = new List<string>();
        for(int i = 0; i < dataLoader.videosPractica.Count; i++) {
            answers.Add(dataLoader.videosPractica[i].nombre);
        }
        answers.Shuffle();
        
        List<string> respuestas = new List<string>();
        respuestas.Add(dataLoader.videosPractica[randomVideoType].nombre);
        rightAnswer = dataLoader.videosPractica[randomVideoType].nombre;
        while(respuestas.Count < 4) {
            for(int i = 0; i < answers.Count; i++) {
                if(!respuestas.Contains(answers[i])) {
                    respuestas.Add(answers[i]);
                }
            }
        }
        respuestas.Shuffle();
        CreateMultiRespuesta(respuestas.ToArray());
    }
    public void CreateVideoPractica(int RVT, int RV) {
        GameObject go = Instantiate(Video, origin);
        VideoControllerPractica VCP = go.GetComponentInChildren<VideoControllerPractica>();
        VCP.video = dataLoader.videosPractica[RVT];
        VCP.videoSelected = RV;
        VCP.SetVideo();
    }

    public void ShowAnswer() {
        Toggle[] toggles = GetComponentsInChildren<Toggle>();
        for(int i = 0; i < toggles.Length; i++) {
            if(toggles[i].GetComponentInChildren<Text>().text == rightAnswer) {
                toggles[i].GetComponent<Image>().color = green;
            } else {
                toggles[i].GetComponent<Image>().color = red;
            }
        }
    }

    public override void NextQuestion() {
        DeleteContent();
        currentPregunta++;
        ShowQuestion();
    }
}
public static class ExtensionRandomList {
    public static void Shuffle<T>(this IList<T> list) {
        RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
        int n = list.Count;
        while(n > 1) {
            byte[] box = new byte[1];
            do
                provider.GetBytes(box);
            while(!(box[0] < n * (Byte.MaxValue / n)));
            int k = (box[0] % n);
            n--;
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}