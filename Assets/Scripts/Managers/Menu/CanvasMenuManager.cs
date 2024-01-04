using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMenuManager : MonoBehaviour
{
    public static CanvasMenuManager sharedInstance;
    public Canvas menuCanvas;
    public Canvas creditCanvas;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    // Funciones para mostrar u ocultar el canvas del menu principal
    public void ShowmenuCanvas()
    {
        menuCanvas.enabled = true;
    }
    public void HaidmenuCanvas()
    {
        menuCanvas.enabled = false;
    }

    // Funciones para mostrar u ocultar el canvas del juego
    public void ShowcreditCanvas()
    {
        creditCanvas.enabled = true;
    }
    public void HaidcreditCanvas()
    {
        creditCanvas.enabled = false;
    }

    public void ExitGame()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif

    }
}
