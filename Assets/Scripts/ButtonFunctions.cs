using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{
    public void ExitGame()
    {
        GameManager.instance.ExitGame();
    }

    public void LoadScene(string sceneName)
    {
        GameManager.instance.LoadScene(sceneName);
    }

    public void SetImageColorWhite(Image image)
    {
        image.color = GameManager.instance.capitan.CompleteQuest();
    }

    public void SetImageColorBlue(Image image)
    {
        image.color = GameManager.instance.capitan.Disparar();
    }

    public void SetImageColorRed(Image image)
    {
        image.color = GameManager.instance.capitan.MostrarEventoCanonico();
    }
}
