using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Security.Cryptography;
using UnityEngine.UI;
using System;

public class PracticaViewer : ExamenViewer {

    public Sprite green, red;
    
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

        //List<string> answers = new List<string>();
        //for(int i = 0; i < dataLoader.videosPractica.Count; i++) {
        //    answers.Add(dataLoader.videosPractica[i].nombre);
        //}
        //answers.Shuffle();
        
        List<string> respuestas = new List<string>();
        respuestas.Add(dataLoader.videosPractica[randomVideoType].nombre);
        rightAnswer = dataLoader.videosPractica[randomVideoType].nombre;
        dataLoader.videosPractica[randomVideoType].wrongAnswersPool.Shuffle();
        int answerPoolSize = dataLoader.videosPractica[randomVideoType].wrongAnswersPool.Count;
        while(respuestas.Count < 4) {
            for(int i = 0; i < answerPoolSize; i++) {
                if(!respuestas.Contains(dataLoader.videosPractica[randomVideoType].wrongAnswersPool[i])) {
                    respuestas.Add(dataLoader.videosPractica[randomVideoType].wrongAnswersPool[i]);
                    break;
                }
            }
        }
        Debug.Log(respuestas.Count);
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
                toggles[i].GetComponent<Image>().sprite = green;
            } else {
                if(toggles[i].isOn) {
                    toggles[i].GetComponent<Image>().sprite = red;
                }
                
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