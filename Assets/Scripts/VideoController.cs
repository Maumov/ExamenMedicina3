using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoController : MonoBehaviour
{
    public int testVideo = 0;
    public Video video;

    public Image green, green1, red, red1, yellow, yellow1, white, white1, rrpm, rrpm1;
    public Text HRBPM;
    public Text ABP1;
    public Text ABP2;
    public Text SpO2;
    public Text CO2;
    public Text RespRate;
    public Text TempC;
    public Text NIPB1;
    public Text NIPB2;
    public Text Timer;
    public Text Interval;

    public AudioSource audioSourceTick, audioSourceContinue;

    int currentNumbers = 0;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        //mat.SetTextureOffset(propertyName, new Vector2(mat.mainTextureOffset.x, mat.mainTextureOffset.y));
        //mat.mainTextureOffset = new Vector2(mat.mainTextureOffset.x + (offSetSpeed * Time.deltaTime), mat.mainTextureOffset.y));
    }

    // Update is called once per frame
    //void Update()
    //{
    //    UpdateMaterial(mat1, offSetSpeed1);
    //    UpdateMaterial(mat2, offSetSpeed2);
    //    UpdateMaterial(mat3, offSetSpeed3);
    //    UpdateMaterial(mat4, offSetSpeed4);
    //}

    //public void Restart() {
    //    mat1.mainTextureOffset = new Vector2(0f, mat1.mainTextureOffset.y);
    //    mat2.mainTextureOffset = new Vector2(0f, mat2.mainTextureOffset.y);
    //    mat3.mainTextureOffset = new Vector2(0f, mat3.mainTextureOffset.y);
    //    mat4.mainTextureOffset = new Vector2(0f, mat4.mainTextureOffset.y);
    //}

    //void UpdateMaterial(Material mat, float speed) {
    //    mat.mainTextureOffset = new Vector2(mat.mainTextureOffset.x + (speed * Time.deltaTime), mat.mainTextureOffset.y);
    //}

    public void Sonido() {
        if(video.nombre == "ASISTOLIA") {
            audioSourceContinue.Play();
        } else {
            audioSourceTick.Play();
        }
        
    }

    public void Numeros() {
        HRBPM.text = video.numbers[currentNumbers].HRBPM;
        ABP1.text = video.numbers[currentNumbers].ABP1;
        ABP2.text = video.numbers[currentNumbers].ABP2;
        SpO2.text = video.numbers[currentNumbers].SpO2;
        CO2.text = video.numbers[currentNumbers].CO2;
        RespRate.text = video.numbers[currentNumbers].RespRate;
        TempC.text = video.numbers[currentNumbers].TempC;
        NIPB1.text = video.numbers[currentNumbers].NIPB1;
        NIPB2.text = video.numbers[currentNumbers].NIPB2;
        Timer.text = video.numbers[currentNumbers].Timer;
        Interval.text = video.numbers[currentNumbers].Interval;


        currentNumbers++;
        if(currentNumbers >= video.numbers.Count) {
            currentNumbers = 0;
        }
    }


    [ContextMenu ("Test Video")]
    public void TestVideo() {
        Video v = FindObjectOfType<DataLoader>().videos[testVideo];
        SetVideo(v);
    }

    public void FinishedSoundFrame()
    {

    }

    public void SetVideo(Video v) {
        video = v;
        Debug.Log("Video: " + v);
        if(video != null) {
            anim.Play(video.nombre, 0);
            anim.Play(video.nombre, 1);
        }

        currentNumbers = 0;
        green.sprite = video.verde;
        green1.sprite = video.verde1;

        red.sprite = video.rojo;
        red1.sprite = video.rojo1;

        yellow.sprite = video.amarillo;
        yellow1.sprite = video.amarillo1;

        white.sprite = video.azul;
        white1.sprite = video.azul1;

        rrpm.sprite = video.rrpm;
        rrpm1.sprite = video.rrpm1;

        Numeros();
    }

    public void StopVideo() {
        anim.Play("Pausa", 0);
        anim.Play("Pausa", 1);
    }

}
