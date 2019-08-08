using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLoadSpreadSheet : MonoBehaviour
{
    
    public string DID = "1kNNSKzegujunNcibjI3U4mGwAyQ6VmrA8dyPdimFyoM";
    public string GID = "1046888050";
    // Start is called before the first frame update
    void Start()
    {
       // StartCoroutine(DownloadCSVCoroutine(DID, GID));
    }

    public IEnumerator DownloadCSVCoroutine(string docId, string sheetId) {
        string url = "https://docs.google.com/spreadsheets/d/" + docId + "/export?format=csv";        
        if(!string.IsNullOrEmpty(sheetId)) {
            url += "&gid=" + sheetId;
        }
        WWWForm form = new WWWForm();
        WWW download = new WWW(url, form);
        yield return download;

        Debug.Log(download.text);
        
    }
    //*********SEND*********
    //IEnumerator SendingValues() {
    //    string url = "https://docs.google.com/forms/d/1vdOGELL9N3xXZ5KNxbIfFI3LGjHGs3Yj1TX5vZRqZGk/formResponse?embedded=true";
    //    WWWForm form = new WWWForm();

    //    form.AddField("entry.48161917", Nombre.text);//A nombre de quien esta el pedido
    //    form.AddField("entry.1192162089", Telefono.text);//Telefono de confirmacion
    //    form.AddField("entry.929232233", Direccion.text);//Direccion de entrega
    //    form.AddField("entry.1184312700", DateTime.Now.ToString("MM/dd/yyyy"));//Fecha
    //    form.AddField("entry.590521561", DateTime.Now.ToString("hh:mm:ss"));//Hora
    //    form.AddField("entry.896482883", pedido.GetString());//Pedido
    //    form.AddField("entry.739552467", pedido.Valor);//Total

    //    WWW www = new WWW(url, form);
    //    yield return www;
    //    Debug.Log(www.text);
    //    yield return null;
    //    Debug.Log("Sent");

    //    cm.MostrarIntro();
    //}

    //*************RECEIVE***************
    //IEnumerator GetPlatos() {
    //    //ohbag88
    //    string url = "https://spreadsheets.google.com/feeds/list/1kNNSKzegujunNcibjI3U4mGwAyQ6VmrA8dyPdimFyoM/ohbag88/public/values?alt=json-in-script&callback=1";
    //    WWW www = new WWW(url);
    //    yield return www;
    //    string encodedString = www.text;
    //    encodedString = encodedString.Substring(18);
    //    Debug.Log("JSON:" + encodedString);
    //    JSONObject j = new JSONObject(encodedString);
    //    accessData(j);
    //    yield return null;
    //    PrintPlatos();

    //    yield return null;
    //}
    //********************************

}
