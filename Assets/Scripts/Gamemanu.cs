using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject optionMenu;
    public GameObject loadMenu;
    //��ͣ�����˵�
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }
    //�ص���Ϸ
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
    //���ý��濪��
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
    //�������濪��
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
