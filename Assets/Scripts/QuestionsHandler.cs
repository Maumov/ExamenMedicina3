using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsHandler : MonoBehaviour
{
    public List<Question> questions;
    int currentQuestion = 0;

    public delegate void theDelegates();
    public event theDelegates OnExamFinished, OnShowVideo, OnShowQuestion;

    void NextQuestion() {
        currentQuestion++;
        if(currentQuestion < questions.Count) {
            ShowQuestion();
        } else {
            if(OnExamFinished != null) {
                OnExamFinished();
            }
        }
    }

    void ShowQuestion() {
        if(OnShowQuestion != null) {
            OnShowQuestion();
        }
    }


    void ShowVideo() {
        if(OnShowVideo != null) {
            OnShowVideo();
        }
    }
}

