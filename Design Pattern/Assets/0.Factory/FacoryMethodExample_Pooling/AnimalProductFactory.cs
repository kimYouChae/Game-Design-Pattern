 
using UnityEngine;

public interface AnimalProduct
{
    void IMoveAnimal();
}

public abstract class AnimalProductFactory<T> : IObjectFactory<T>
    where T : Component, AnimalProduct
{
    protected GameObject prefab;
    protected Color color;

    // 필요한 정보 초기화
    public AnimalProductFactory(GameObject pre, Color color)
    {
        this.prefab = pre;
        this.color = color;
    }

    protected abstract AnimalProduct CreateAnimal();

    // 생성할 때 사용하는 인터페이스 메서드 
    public T CreateInstance()
    {
        return (T)CreateAnimal();
    }
}

public class CatProductFactory : AnimalProductFactory<CatProduct>
{
    public CatProductFactory(GameObject pre, Color color) : base(pre, color) { }

    protected override AnimalProduct CreateAnimal()
    {
        GameObject obj = GameObject.Instantiate(prefab);
        return obj.GetComponent<CatProduct>();
    }
}

public class DobProdcutFacotry : AnimalProductFactory<DogProduct>
{
    public DobProdcutFacotry(GameObject pre, Color color) : base(pre, color) { }

    protected override AnimalProduct CreateAnimal()
    {
        GameObject obj = GameObject.Instantiate(prefab);
        return obj.GetComponent<DogProduct>();
    }
}