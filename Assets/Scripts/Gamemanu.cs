using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject optionMenu;
    public GameObject loadMenu;
    //暂停调出菜单
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }
    //回到游戏
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
    //设置界面开关
    public void SetOption()
    {
        pauseMenu.SetActive(false);
        optionMenu.SetActive(true);
    }

    public void CloseOption()
    {
        optionMenu.SetActive(false);
        pauseMenu.SetActive(true);
        
    }
    //读档界面开关
    public void SetLoad()
    {
        pauseMenu.SetActive(false);
        loadMenu.SetActive(true);
    }

    public void CloseLoad()
    {
        pauseMenu.SetActive(true);
        loadMenu.SetActive(false);

    }

}
