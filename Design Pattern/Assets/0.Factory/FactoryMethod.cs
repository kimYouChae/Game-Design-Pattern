using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactoryMethod 
{
    void SignUp(); 
}

public class FactoryMethodDog : IFactoryMethod
{
    public void SignUp()
    {
        Debug.Log("Factory Method Dog");   
    }
}

public class FacotryMethodCat : IFactoryMethod
{
    public void SignUp()
    {
        Debug.Log("Factory Method Cat");
    }
}

public abstract class AnimalFactoryMethod 
{
    public IFactoryMethod CreateMethod() 
    {
        IFactoryMethod method = CreateAnimal();
        method.SignUp();
        return method;  
    }

    protected abstract IFactoryMethod CreateAnimal();
}

public class CatFactoryMethodFacotry : AnimalFactoryMethod
{
    protected override IFactoryMethod CreateAnimal()
    {
        return new FacotryMethodCat();
    }
}


public class FactoryMethod : MonoBehaviour
{

    void Start()
    {
        AnimalFactoryMethod animalFactoryMethod = new CatFactoryMethodFacotry();

        IFactoryMethod cat = animalFactoryMethod.CreateMethod();

    }

}
