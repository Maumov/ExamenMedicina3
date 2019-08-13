using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader : MonoBehaviour {
    public List<Profesor> profesores;
    public List<Estudiante> estudiantes;
    public List<Examen> examenes;
    public List<Question> preguntas;
    public List<Codigo> codigos;

    public List<Video> videos;

    private void Start() {
        GetAllData();
    }

    [ContextMenu("GetAllData")]
    public void GetAllData() {
        StartCoroutine(GetProfesores());
        StartCoroutine(GetEstudiantes());
        StartCoroutine(GetExamen());
        StartCoroutine(GetPreguntas());
        StartCoroutine(GetCodigos());
    }

    public Profesor GetProfesor(string id) {
        foreach(Profesor p in profesores) {
            if(p.id.Equals(id)) {
                return p;
            }
        }
        return null;
    }

    public Question GetQuestion(string id) {
        foreach(Question q in preguntas) {
            if(q.id.Equals(id)) {
                return q;
            }
        }
        return null;
    }

    public Codigo GetCodigo(string cod) {
        foreach(Codigo c in codigos) {
            if(c.id.Equals(cod)) {
                return c;
            }
        }
        return null;
    }

    public Examen GetExamen(string cod) {
        foreach(Examen e in examenes) {
            if(e.id.Equals(cod)) {
                return e;
            }
        }
        return null;
    }

    public Estudiante GetEstudiante(string cod) {
        foreach(Estudiante e in estudiantes) {
            if(e.id.Equals(cod)) {
                return e;
            }
        }
        return null;
    }

    public Video GetVideo(string nom) {
        foreach(Video v in videos) {
            if(v.nombre == nom) {
                return v;
            }
        }

        return null;
    }


    //Profesores
    #region
    IEnumerator GetProfesores() {
        string docId = "1zRt_ugcGqIB6Kn7hfJHQW0f-fjx-fEmBNfxhfHX4-z0";
        string sheetId = "1354977118";
        string url = "https://docs.google.com/spreadsheets/d/" + docId + "/export?format=csv";
        if(!string.IsNullOrEmpty(sheetId)) {
            url += "&gid=" + sheetId;
        }
        WWWForm form = new WWWForm();
        WWW download = new WWW(url, form);
        yield return download;

        profesores = new List<Profesor>();
        
        profesores.AddRange(CreateProfesores(download.text));
    }
    List<Profesor> CreateProfesores (string data) {
        List<Profesor> list = new List<Profesor>();
        string[] theVector = data.Split('\n');

        for(int i = 1; i < theVector.Length; i++) {
            Profesor p;
            string pJSON = theVector[i];
            pJSON = RemoveDate(pJSON);
            p = CreateProfesor(pJSON);
            list.Add(p);
        }
        return list;
    }

    string RemoveDate(string value) {
        string s = value;
        s = s.Substring(s.IndexOf(',')+1);
        return s;
    }

    Profesor CreateProfesor(string data) {
        Profesor p = new Profesor();
        string[] values = data.Split(',');
        p.id = values[0];
        p.nombre = values[1];
        p.apellido = values[2];
        return p;
    }
    #endregion 
    //Estudiantes
    #region
    IEnumerator GetEstudiantes() {
        string docId = "1zRt_ugcGqIB6Kn7hfJHQW0f-fjx-fEmBNfxhfHX4-z0";
        string sheetId = "1948744068";
        string url = "https://docs.google.com/spreadsheets/d/" + docId + "/export?format=csv";
        if(!string.IsNullOrEmpty(sheetId)) {
            url += "&gid=" + sheetId;
        }
        WWWForm form = new WWWForm();
        WWW download = new WWW(url, form);
        yield return download;

        estudiantes = new List<Estudiante>();
        estudiantes.AddRange(CreateEstudiantes(download.text));
    }

    List<Estudiante> CreateEstudiantes(string data) {
        List<Estudiante> list = new List<Estudiante>();
        string[] theVector = data.Split('\n');
        for(int i = 1; i < theVector.Length; i++) {
            Estudiante p;
            string pJSON = theVector[i];
            pJSON = RemoveDate(pJSON);
            p = CreateEstudiante(pJSON);
            list.Add(p);
        }
        return list;
    }

    Estudiante CreateEstudiante(string data) {
        Estudiante p = new Estudiante();
        string[] values = data.Split(',');
        p.id = values[0];
        p.nombre = values[1];
        p.apellido = values[2];
        return p;
    }
    #endregion
    //Examenes
    #region
    IEnumerator GetExamen() {
        string docId = "1zRt_ugcGqIB6Kn7hfJHQW0f-fjx-fEmBNfxhfHX4-z0";
        string sheetId = "1895458670";
        string url = "https://docs.google.com/spreadsheets/d/" + docId + "/export?format=csv";
        if(!string.IsNullOrEmpty(sheetId)) {
            url += "&gid=" + sheetId;
        }
        WWWForm form = new WWWForm();
        WWW download = new WWW(url, form);
        yield return download;

        examenes = new List<Examen>();
        examenes.AddRange(CreateExamenes(download.text));
    }

    List<Examen> CreateExamenes(string data) {
        List<Examen> list = new List<Examen>();
        string[] theVector = data.Split('\n');
        for(int i = 1; i < theVector.Length; i++) {
            Examen p;
            string pJSON = theVector[i];
            pJSON = RemoveDate(pJSON);
            p = CreateExamen(pJSON);
            list.Add(p);
        }
        return list;
    }

    Examen CreateExamen(string data) {
        Examen p = new Examen();
        string[] d = data.Split('{');
        string[] values = d[0].Split(',');
        p.id = values[0];
        p.nombre = values[1];
        p.profesor = GetProfesor(values[2]);
        p.preguntas = new List<string>();
        d[1] = d[1].Substring(0, d[1].Length -2);
        p.preguntas.AddRange(d[1].Split(','));
        return p;
    }
    #endregion
    //Preguntas
    #region
    IEnumerator GetPreguntas() {
        string docId = "1zRt_ugcGqIB6Kn7hfJHQW0f-fjx-fEmBNfxhfHX4-z0";
        string sheetId = "1589617286";
        string url = "https://docs.google.com/spreadsheets/d/" + docId + "/export?format=csv";
        if(!string.IsNullOrEmpty(sheetId)) {
            url += "&gid=" + sheetId;
        }
        WWWForm form = new WWWForm();
        WWW download = new WWW(url, form);
        yield return download;

        preguntas = new List<Question>();
        preguntas.AddRange(CreatePreguntas(download.text));
    }

    List<Question> CreatePreguntas(string data) {
        List<Question> list = new List<Question>();
        string[] theVector = data.Split('\n');
        for(int i = 1; i < theVector.Length; i++) {
            Question p;
            string pJSON = theVector[i];
            pJSON = RemoveDate(pJSON);
            p = CreatePregunta(pJSON);
            list.Add(p);
        }
        return list;
    }

    Question CreatePregunta(string data) {
        
        Question p = new Question();
        //Debug.Log(data);
        string[] d = data.Split('{');
        //Debug.Log(d[0]);
        //Debug.Log(d[1]);
        //Debug.Log(d[2]);
        string[] values = d[0].Split(',');
        string[] parrafoSplit = d[0].Split('"');
        //Debug.Log(parrafoSplit[0]);
        //Debug.Log(parrafoSplit[1]);
        //Debug.Log(parrafoSplit[2]);

        p.id = values[0];
        if(parrafoSplit.Length > 1) {
            p.parrafo = parrafoSplit[1];
            p.video = parrafoSplit[2].Substring(1, parrafoSplit[2].Length - 2);
        } else {
            p.parrafo = values[1];
            p.video = values[2];
        }
        p.preguntas = new List<string>();
        //Debug.Log(d[1]);
        //d[1] = d[1].Substring(0, d[1].Length - 1);
        string[] d2 = d[1].Split('}');
        if(d2[0].Length > 0) {
            p.preguntas.AddRange(d2[0].Split(';'));
        }
        p.respuestas = new List<string>();
        d[2] = d[2].Substring(0, d[2].Length - 1);
        string[] d3 = d[2].Split('}');
        p.respuestas.AddRange(d3[0].Split(';'));

        p.respuestasEstudiante = new List<string>();
        for(int i = 0; i < p.preguntas.Count; i++ ) {
            p.respuestasEstudiante.Add("");
        }
        return p;
    }
    #endregion

    #region
    IEnumerator GetCodigos() {
        string docId = "1zRt_ugcGqIB6Kn7hfJHQW0f-fjx-fEmBNfxhfHX4-z0";
        string sheetId = "1643123979";
        string url = "https://docs.google.com/spreadsheets/d/" + docId + "/export?format=csv";
        if(!string.IsNullOrEmpty(sheetId)) {
            url += "&gid=" + sheetId;
        }
        WWWForm form = new WWWForm();
        WWW download = new WWW(url, form);
        yield return download;

        codigos = new List<Codigo>();
        codigos.AddRange(CreateCodigos(download.text));
    }

    List<Codigo> CreateCodigos(string data) {
        List<Codigo> list = new List<Codigo>();
        string[] theVector = data.Split('\n');
        for(int i = 1; i < theVector.Length; i++) {
            Codigo p;
            string pJSON = theVector[i];
            pJSON = RemoveDate(pJSON);
            p = CreateCodigo(pJSON);
            list.Add(p);
        }
        return list;
    }

    Codigo CreateCodigo(string data) {

        Codigo p = new Codigo();
        string[] values = data.Split(',');
        p.id = values[0];
        p.examen = values[1];
        p.fechaInicio = values[2];
        p.fechaFin = values[3];
        return p;
    }
    #endregion

}
