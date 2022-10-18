using System.Collections;
using UnityEngine;

public class ShouYinJI : MonoBehaviour
{
    //    public Transform cube;
    bool isShowTip;
    public bool WindowShow = false;
    //    // Use this for initialization
    void Start()
    {
        isShowTip = false;
    }
    void OnMouseEnter()
    {
        isShowTip = true;
        //Debug.Log (cube.name);//���Եõ����������

    }
    void OnMouseExit()
    {
        isShowTip = false;
    }
    void OnGUI()
    {
        if (isShowTip)
        {
            GUIStyle style1 = new GUIStyle();
            style1.fontSize = 30;
            style1.normal.textColor = Color.black;
            GUI.Label(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, 400, 50), "������", style1);

        }
        if (WindowShow)
            GUI.Window(0, new Rect(500, 300, 400, 200), MyWindow, "������");
    }

    //�Ի�����
    void MyWindow(int WindowID)
    {
        GUILayout.Label("����һ��������");
    }
    //������¼�
    void OnMouseDown()
    {
        Debug.Log("show");
        if (WindowShow)
            WindowShow = false;
        else
            WindowShow = true;
    }
}
