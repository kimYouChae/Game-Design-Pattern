using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T>
    where T : Component
{
    /// <summary>
    /// Ÿ�� T�� �������� ������Ʈ (Monobehavior �̿�����)
    /// </summary>

    [Header("=== Container ===")]
    private Queue<T> pool = new Queue<T>();
    [Header("=== Factory ===")]
    private IObjectFactory<T> factory;
    [Header("=== State ===")]
    private Transform parent;
    private int initCount;

    public ObjectPool(IObjectFactory<T> factory, int initCnt, Transform parentTrs = null)
    {
        this.factory = factory;
        this.initCount = initCnt;
        if (parentTrs != null)
            this.parent = parentTrs;

        // �ʱ�ȭ
        InitPool();
    }

    private void InitPool()
    {
        if (pool == null)
            pool = new Queue<T>();

        for (int i = 0; i < initCount; i++)
        {
            // ���丮���� �ν��Ͻ� ���� 
            T temp = InstanceT();
            pool.Enqueue(temp);
        }
    }

    private T InstanceT()
    {
        // ����
        T temp = factory.CreateInstance();
        // �ʱ�ȭ, �θ� ���� 
        
        // Extention
        // temp.transform.InitTransform(parent);

        // �Ϲ�
        temp.transform.SetParent(parent);
        temp.transform.localPosition = Vector3.zero;

        // ����
        temp.gameObject.SetActive(false);

        return temp;
    }

    /// <summary>
    /// ������Ʈ ��ȯ �޼���
    /// </summary>
    /// <returns>��ȯ���� ������Ʈ</returns>
    public GameObject GetPool()
    {
        T getObject = null;

        // pool�� ������ 
        if (pool.Count <= 0)
        {
            // ����
            getObject = InstanceT();
            pool.Enqueue(getObject);
        }

        getObject = pool.Dequeue();
        getObject.gameObject.SetActive(true);

        return getObject.gameObject;
    }

    /// <summary>
    /// TŸ�� ������Ʈ ��ȯ �޼���
    /// </summary>
    /// <returns>��ȯ���� T ������Ʈ</returns>
    public T GetPoolAsT()
    {
        T getObject = null;

        // pool�� ������ 
        if (pool.Count <= 0)
        {
            // ����
            getObject = InstanceT();
            pool.Enqueue(getObject);
        }

        getObject = pool.Dequeue();
        getObject.gameObject.SetActive(true);

        return getObject;
    }

    /// <summary>
    /// ������Ʈ Ǯ ��ȯ �޼���
    /// </summary>
    /// <param name="obj">��ȯ GameObject</param>
    public void SetObject(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj.GetComponent<T>());
    }

    /// <summary>
    /// ������Ʈ Ǯ ��ȯ �޼���
    /// </summary>
    /// <param name="obj">��ȯ T</param>
    public void SetObject(T obj)
    {
        obj.gameObject.SetActive(false);
        pool.Enqueue(obj);
    }
}