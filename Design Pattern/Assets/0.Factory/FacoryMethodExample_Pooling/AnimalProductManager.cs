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
        // 펙토리 생성
        AnimalProductFactory<CatProduct> animal1 = new CatProductFactory(catPrefab, catColor);

        // 풀링 생성
        ObjectPool<CatProduct> catPooling = new ObjectPool<CatProduct>(animal1, 10, parent);

        // 풀링에서 가져오기 
        CatProduct cat = catPooling.GetPoolAsT();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
