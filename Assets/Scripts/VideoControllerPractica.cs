using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoControllerPractica : MonoBehaviour
{
    public int testVideo = 0;
    public VideoPractica video;
    public int videoSelected;

    public Image green, green1;
    public Text HRBPM;
    
    public AudioSource audioSourceTick, audioSourceContinue;

    int currentNumbers = 0;

    public Animator anim;

    public VideoControllerPractica maximized;
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
        if(video.videos[videoSelected].numbers.Count <= 0) {
            return;
        }
        HRBPM.text = video.videos[videoSelected].numbers[currentNumbers].HRBPM;
        currentNumbers++;
        if(currentNumbers >= video.videos[videoSelected].numbers.Count) {
            currentNumbers = 0;
        }
    }

    public void Maximize() {
        maximized.video = video;
        maximized.videoSelected = videoSelected;
        maximized.SetVideo();
    }


    //[ContextMenu ("Test Video")]
    //public void TestVideo() {
    //    VideoPractica v = FindObjectOfType<DataLoader>().videosPractica[testVideo];
    //    SetVideo(v);
    //}

    public void FinishedSoundFrame()
    {

    }

    public void SetVideo() {
        
        
        if(video != null) {
            anim.Play("AnimationFiller", 0); // Visual
            //anim.Play(video.nombre, 1); // Audio
        }

        currentNumbers = 0;
        green.sprite = video.videos[videoSelected].lineas[0];
        green1.sprite = video.videos[videoSelected].lineas[1];

        Numeros();
    }

    public void StopVideo() {
        anim.Play("Pausa", 0);
        anim.Play("Pausa", 1);
    }
}
