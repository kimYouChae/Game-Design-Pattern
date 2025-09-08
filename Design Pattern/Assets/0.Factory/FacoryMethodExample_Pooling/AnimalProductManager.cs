using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalProductManager : MonoBehaviour
{
    [SerializeField] Transform parent;
    [SerializeField] GameObject catPrefab;
    [SerializeField] Color catColor;

    void Start()
    {
        // ���丮 ����
        AnimalProductFactory<CatProduct> animal1 = new CatProductFactory(catPrefab, catColor);

        // Ǯ�� ����
        ObjectPool<CatProduct> catPooling = new ObjectPool<CatProduct>(animal1, 10, parent);

        // Ǯ������ �������� 
        CatProduct cat = catPooling.GetPoolAsT();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
