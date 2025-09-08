 
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

    // �ʿ��� ���� �ʱ�ȭ
    public AnimalProductFactory(GameObject pre, Color color)
    {
        this.prefab = pre;
        this.color = color;
    }

    protected abstract AnimalProduct CreateAnimal();

    // ������ �� ����ϴ� �������̽� �޼��� 
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