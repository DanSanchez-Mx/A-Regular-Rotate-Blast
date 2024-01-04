using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MenuState
{
    inMenu,
    credit
}

public class MenuGameManager : MonoBehaviour
{
    public MenuState currentGameState = MenuState.inMenu;
    public static MenuGameManager sharedInstance;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    // Zona para poner en que estado de juego se está
    public void Menu()
    {
        SetMenuState(MenuState.inMenu);
    }

    public void Credit()
    {
        SetMenuState(MenuState.credit);
    }

    private void SetMenuState(MenuState newMenuState)
    {
        if (newMenuState == MenuState.inMenu)
        {
            CanvasMenuManager.sharedInstance.ShowmenuCanvas();
            CanvasMenuManager.sharedInstance.HaidcreditCanvas();
        }
        else if (newMenuState == MenuState.credit)
        {
            // TODO: Preparar el juego para el Game Over
            CanvasMenuManager.sharedInstance.HaidmenuCanvas();
            CanvasMenuManager.sharedInstance.ShowcreditCanvas();
        }
        this.currentGameState = newMenuState;
    }

}
