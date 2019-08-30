using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoControllerPractica : MonoBehaviour
{
    public int testVideo = 0;
    public VideoPractica video;

    public Image green, green1;
    public Text HRBPM;
    
    public AudioSource audioSourceTick, audioSourceContinue;

    int currentNumbers = 0;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Sonido() {
        if(video.nombre == "ASISTOLIA") {
            audioSourceContinue.Play();
        } else {
            audioSourceTick.Play();
        }
    }

     public void Numeros() {
        HRBPM.text = video.numbers[currentNumbers].HRBPM;

        currentNumbers++;
        if(currentNumbers >= video.numbers.Count) {
            currentNumbers = 0;
        }
    }


    [ContextMenu ("Test Video")]
    public void TestVideo() {
        VideoPractica v = FindObjectOfType<DataLoader>().videosPractica[testVideo];
        SetVideo(v);
    }

    public void FinishedSoundFrame()
    {

    }

    public void SetVideo(VideoPractica v) {
        video = v;
        Debug.Log("Video: " + v);
        if(video != null) {
            anim.Play(video.nombre, 0);
            anim.Play(video.nombre, 1);
        }

        currentNumbers = 0;
        green.sprite = video.verde;
        green1.sprite = video.verde1;

        Numeros();
    }

    public void StopVideo() {
        anim.Play("Pausa", 0);
        anim.Play("Pausa", 1);
    }
}
