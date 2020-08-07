using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

    public GameObject heroSelectPanel;

    public void StartGame() {
        LoadingScreen.instance.LoadLevel(SceneNames.GAMEPLAY);
    }

    public void OpenHeroSelectPanel() {
        heroSelectPanel.SetActive(true);
    }

    public void CloseHeroSelectPanel() {
        heroSelectPanel.SetActive(false);
    }

    public void SelectHero() {

        GameManager.instance.selected_Hero_Index =
            int.Parse(UnityEngine.EventSystems.EventSystem
            .current.currentSelectedGameObject.name);

    }

} 






























