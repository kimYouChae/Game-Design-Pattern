# 생성패턴 / Factory패턴

### ✨ Simple Factory
```
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
- 객체의 생성을 담당하며 확장이 용이하다는 장점이 있지만, 확장할 때 기존 코드를 수정해야 한다는 단점이 있
- Factory Method나 추상 펙토리를 사용한다면 기존 클래스에 영향을 주지 않고 확장이 가능함.
