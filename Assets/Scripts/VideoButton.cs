﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoButton : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPressed() {
        FindObjectOfType<ExamenViewer>().ShowVideo();
    }
}
