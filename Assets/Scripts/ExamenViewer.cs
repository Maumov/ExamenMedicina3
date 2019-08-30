using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExamenViewer : MonoBehaviour {

    public StudentControl studentControl;
    public Examen examen;

    public RectTransform origin;

    public GameObject Parrafo;
    public GameObject Pregunta;
    public GameObject Video;
    public GameObject Respuesta;
    public GameObject multiRespuesta;

    public DataLoader dataLoader;

    public int currentPregunta = 0;

    public List<InputField> inputs;

    public VideoController videoController;
    public GameObject videoControllerGameObject;

    public GameObject NextInterface;

    public PopupMessage videoMessage;

    private void OnEnable() {
        ShowExamen();
    }

    public virtual void ShowExamen() {
        examen = studentControl.examen;
        currentPregunta = 0;
        ShowQuestion();
    }

    public virtual void ShowQuestion() {
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

    public void ShowVideo() {
        
        videoMessage.ShowMessage(Accepted);
    }

    public void Accepted() {
        string id = examen.preguntas[currentPregunta];
        Question q = dataLoader.GetQuestion(id);
        videoControllerGameObject.SetActive(true);
        videoController.SetVideo(dataLoader.GetVideo(q.video));
        Invoke("HideVideo", 20f);
    }


    public void HideVideo() {
        videoControllerGameObject.SetActive(false);
        videoController.StopVideo();
    }

    public virtual void NextQuestion() {
        for(int i = 0; i < inputs.Count; i++  ) {
            studentControl.SetAnswerToQuestion(currentPregunta, i, inputs[i].text);
        }
        DeleteContent();
        currentPregunta++;
        ShowQuestion();
    }


    [ContextMenu("TEST CREACION DE PREGUNTA")]
    public void TestCreacionDePregunta() {
        CreatePreguntaPack("1");
    }


    public virtual void CreatePreguntaPack(string id) {
        Question q = dataLoader.GetQuestion(id);
        CreateParrafo(q.parrafo);
        CreateVideoButton(q.video);
        for(int i = 0; i< q.preguntas.Count; i++) {
            CreatePregunta(q.preguntas[i]);
            CreateRespuesta();
        }
        if(q.respuestas.Count > 0) {
            CreateMultiRespuesta(q.respuestas.ToArray());
        }
    }
   
    public void CreateParrafo(string parrafo) {
        GameObject go = Instantiate(Parrafo, origin);
        Text text = go.GetComponentInChildren<Text>();
        text.text = parrafo;
    }
    public void CreatePregunta(string pregunta) {
        GameObject go = Instantiate(Pregunta, origin);
        Text text = go.GetComponentInChildren<Text>();
        text.text = pregunta;
    }
    public void CreateVideoButton(string video) {
        GameObject go = Instantiate(Video, origin);   
    }
    public void CreateRespuesta() {
        GameObject go = Instantiate(Respuesta, origin);
        inputs.Add(go.GetComponent<InputField>());
        go.name = go.name + inputs.Count;
    }

    public void CreateMultiRespuesta(string[] respuestas) {
        GameObject go = Instantiate(multiRespuesta, origin);
        Toggle[] toggles = go.GetComponentsInChildren<Toggle>();
        for(int i = 0; i <  toggles.Length; i++) {
            if(toggles[i].name.Equals("Option 1")) {
                toggles[i].GetComponentInChildren<Text>().text = respuestas[0];
            }
            if(toggles[i].name.Equals("Option 2")) {
                toggles[i].GetComponentInChildren<Text>().text = respuestas[1];
            }
            if(toggles[i].name.Equals("Option 3")) {
                toggles[i].GetComponentInChildren<Text>().text = respuestas[2];
            }
            if(toggles[i].name.Equals("Option 4")) {
                toggles[i].GetComponentInChildren<Text>().text = respuestas[3];
            }
        }
    }


    public void DeleteContent() {
        RectTransform[] gos = origin.GetComponentsInChildren<RectTransform>();
        foreach(RectTransform rt in gos) {
            if(rt != origin.GetComponent<RectTransform>()) {
                Destroy(rt.gameObject);
            }
        }
    }
}