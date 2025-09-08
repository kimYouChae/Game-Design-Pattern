using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension 
{
    /// <summary>
    ///  모든 클래스의 기능을 확장할 수 있는 메서드
    ///  
    /// </summary>

    // 부모가 있다면 부모 지정 후 위치, 회전, 크기 리셋 
    public static void InitTransform(this Transform trs, Transform parent = null)
    {
        if (parent != null)
            trs.SetParent(parent);

        trs.localPosition = Vector3.zero;
        trs.localRotation = Quaternion.identity;
        trs.localScale = Vector3.one;
    }
}
