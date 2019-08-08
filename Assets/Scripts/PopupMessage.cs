using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupMessage : MonoBehaviour
{
    public Text texto;
    public delegate void callback();
    callback met;

    public void ShowMessage(string mensaje) {
        texto.text = mensaje;
        gameObject.SetActive(true);
    }

    public void ShowMessage(callback metodo) {
        met = metodo;
        gameObject.SetActive(true);
    }

    public void ButtonOk() {
        gameObject.SetActive(false);
    }

    public void ButtonAccept() {
        met();
        gameObject.SetActive(false);
    }

    public void ButtonCancel() {
        gameObject.SetActive(false);
    }

}
