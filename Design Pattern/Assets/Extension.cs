using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension 
{
    /// <summary>
    ///  ��� Ŭ������ ����� Ȯ���� �� �ִ� �޼���
    ///  
    /// </summary>

    // �θ� �ִٸ� �θ� ���� �� ��ġ, ȸ��, ũ�� ���� 
    public static void InitTransform(this Transform trs, Transform parent = null)
    {
        if (parent != null)
            trs.SetParent(parent);

        trs.localPosition = Vector3.zero;
        trs.localRotation = Quaternion.identity;
        trs.localScale = Vector3.one;
    }
}
