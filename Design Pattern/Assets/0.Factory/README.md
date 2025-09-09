### 생성패턴 🔜 Factory패턴

- 목차
  - [심플 펙토리](#Simple-Factory)
  - [펙토리 메서드](#Factory-Method-패턴)
  - [펙토리 메서드 + Pooling](#Factory-Method-패턴과-Pooling-유틸리티)

<hr>

# ✨Simple Factory
``` c#
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
```
- client에서 직접적으로 생성하지 않고, Factory에 생성코드를 작성함으로써 나중에 클래스가 추가/수정 될 때 Factory 내부만 변경하면 됨
  
| 장점 | 단점 |
| :-: | :-: |
| Factory가 객체의 생성을 담당하며, 확장이 용이함 | 확장할 때 기존 코드를 수정해야 함|

⏩ **Factory Method나 추상 펙토리를 사용한다면 기존 클래스에 영향을 주지 않고 확장이 가능함.**

<br>
<hr>

# ✨Factory Method 패턴
⏩ Factory Method 패턴은 **객체를 생성할 떄 어떤 클래스의 인스턴스를 만들 지 서브 클래스에서 결정하는 패턴**

| 장점 | 단점 |
| :-: | :-: |
| 수정에는 닫혀있고, 확장에는 열려 있는 구조 | 확장할 때 클래스를 추가해야 함으로 코드량이 늘어남 |

<br>

<img width="835" height="507" alt="Image" src="https://github.com/user-attachments/assets/0ce41526-d29b-4a47-9da7-a7dae7d93731" />

<br> 

_출처 : 리펙토링 구루 Factory Method 패턴_

<br>

- Product에 해당 하는 부분 (ex Animal)은 Product 인터페이스를 구현
``` c#
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
```

<br>

- Creator은 생성을 담당하는 abstract 클래스
    - 객체를 생성할 때 어떤 클래스의 인스턴스를 만들 지 서브 클래스에서 결정 
``` c#
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
```
<br>

- Client에서는 Factory를 생성하여 사용
``` c#
public class FactoryMethod : MonoBehaviour
{

    void Start()
    {
        AnimalFactoryMethod animalFactoryMethod = new CatFactoryMethodFacotry();

        IFactoryMethod cat = animalFactoryMethod.CreateMethod();

    }

}
```

<br>

- Factory Method에서 새로운 동물인 Bird를 추가할 때,

```
생성을 담당하는 abstract 클래스를 상속받아 하위 클래스에서 생성을 구현하면 된다.
    - 이로써 Simple Factory에서 새로운 클래스를 생성할 때 Factory코드를 수정해야 한다는 단점을 개선할 수 있다.
        - `수정에는 닫혀있고 확장에는 열려 있다`
    - Bird를 추가한 것 처럼 새로운 클래스가 추가되게 되면 클래스 양이 많아질 수 있다.
```

``` c#
public class BirdFactory : AnimalFactoryMethod
{
    protected override IFactoryMethod CreateAnimal()
    {
        return new Bird();
    }
}

// 사용 시 
// AnimalFactoryMethod animalFactoryMethod = new BirdFactory();
// IFactoryMethod bird = animalFactoryMethod.CreateMethod();
```
      
<br>
<hr>

# ✨Factory Method 패턴과 Pooling 유틸리티

- 풀링 유틸리티에 관한 자세한 내용은 아래 블로그를 참고, 지금은 Factory Method와 연결하여 설명
  - https://youcheachae.tistory.com/69
 
<br>

- Product에 해당 하는 부분
  - Animal들은 AnimalProduct 인터페이스를 구현한다.

``` c#
public interface AnimalProduct
{
    void IMoveAnimal();
}
```
``` c#
public class CatProduct : MonoBehaviour , AnimalProduct
{
    public void IMoveAnimal()
    {
        Debug.Log("Cat Product Move Animal");
    }

}
```
``` c#
public class DogProduct : MonoBehaviour, AnimalProduct
{
    public void IMoveAnimal()
    {
        Debug.Log("Dog Product Move Animal");
    }

}
```

<br>

- Creator에 해당하는 부분

``` c#
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
```

```
- ObjectPooling을 사용하기 위해서는 Factory는 반드시 `IObjectFactory` 를 구현해야한다.
- AnimalProductFactory가 제네릭 클래스인 이유
    - IObjectFactory가 제네릭 클래스이기 때문에, 그걸 구현하는 AnimalProductFactory도 제네릭이여야한다
    - Animal과 관련된 Factory이기 때문에 T는 AnimalProduct를 구현하는 클래스만 가능하다. 즉, AnimalProduct 까지 제약을 걸어주면 안정성이 있다.
```

<br>

- creator을 구현하는 ConcreateCreatorA와 B에 해당 하는 부분
    - 어떤 클래스의 인스턴스를 만들지는 하위클래스에 결정함.

``` c#

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
```

<br>

- Client에서 사용하는 부분

``` c#
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
```

```
- CatProduct에 해당하는 Factory 생성
- Pooling 생성 시 위에서 생성한 Factory를 매개변수로
- Pooling에서 Get 시 성공적으로 가져오는것을 확인할 수 있음
```
