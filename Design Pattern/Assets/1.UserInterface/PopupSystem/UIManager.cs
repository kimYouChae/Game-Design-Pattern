using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private List<UIPopUP> popupList;
    [SerializeField] private Canvas canvas;

    const string PopupPath = "PopUp/";


    private void Awake()
    {
        Instance = this;

        popupList = new List<UIPopUP>();
        FindCanvas();
    }

    private void FindCanvas()
    {
        // canvas �̸��� ������Ʈ ã�� 
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    public T GetPopUP<T>() where T : UIPopUP
    {
        UIPopUP popup;
        // 1. ����Ʈ�� �ִ��� �˻� 
        if (isInPopUpList<T>())
        {
            // ������ 
            popup = ReturnPopupInList<T>();

            // ����Ʈ���� ����� -> �� �տ� �α����� 
            popupList.Remove(popup);
        }
        else
        {
            // ������ 
            // ����� 
            popup = InstancePopup<T>();
        }


        // �ѱ�
        popup.gameObject.SetActive(true);
        // ����Ʈ�� �� �տ� �α�
        popupList.Insert(0, popup);

        return popup as T;
    }

    private bool isInPopUpList<T>()
    {
        for (int i = 0; i < popupList.Count; i++)
        {
            // ��Ӱ��迩�� 
            if (popupList[i].GetType() == typeof(T))
            {
                return true;
            }
        }

        return false;
    }

    private UIPopUP ReturnPopupInList<T>()
    {
        for (int i = 0; i < popupList.Count; i++)
        {
            // ��Ӱ��迩�� 
            if (popupList[i].GetType() == typeof(T))
            {
                return popupList[i];
            }
        }

        return null; ;
    }

    private UIPopUP InstancePopup<T>()
    {
        // 0. Resource���� �������� 
        // ��ũ��Ʈ�̸�(T)�� ������Ʈ�� �̸� ���ƾ��� 
        // (����) nameof<T>��� �ϸ� T�� ��ȯ��
        GameObject popup = Resources.Load<GameObject>(PopupPath + typeof(T).Name);

        GameObject instancePop = Instantiate(popup);

        //  canvvas ������ 
        instancePop.transform.SetParent(canvas.transform, false);

        return instancePop.GetComponent<UIPopUP>();
    }
}
