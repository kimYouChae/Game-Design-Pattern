using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatProduct : MonoBehaviour , AnimalProduct
{
    void Start()
    {
        Debug.Log("Cat Product »ý¼ºµÊ");
    }

    void Update()
    {
        
    }

    public void IMoveAnimal()
    {
        Debug.Log("Cat Product Move Animal");
    }

}
