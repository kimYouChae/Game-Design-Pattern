using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum SimpleFactoryType 
{
    Cat, Dog
}

public class SimplePetFacotry 
{
    public SimplePet CreatePet(SimpleFactoryType type) 
    {
        switch (type) 
        {
            case SimpleFactoryType.Cat:
                return new SimpleCat();
            case SimpleFactoryType.Dog:
                return new SimpleDog();
        }
        return null;
    }
}

public class SimplePet { }
public class SimpleCat : SimplePet { }
public class SimpleDog  : SimplePet { }

public class SimpleFactory : MonoBehaviour
{
    private SimplePetFacotry simpleFactory;

    private void Start()
    {
        simpleFactory = new SimplePetFacotry();

        SimplePet simpleCat = simpleFactory.CreatePet(SimpleFactoryType.Cat);
        SimplePet simpleDog = simpleFactory.CreatePet(SimpleFactoryType.Dog);
    }
}
