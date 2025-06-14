 
using System;
using System.Collections.Generic; 
using UnityEngine;

public class MainDataTypes : MonoBehaviour
{
    public readonly Dictionary<Type, EnemyBase> enemys = new();

    private void Awake()
    {
        // оператор is
        Animal animal = new Animal();
        Dog dog = new Dog();
        if (dog is Animal anim)
        {
           // print(anim?.name);
        }
        // оператор as
        animal = new Dog();
        var value = animal as Dog;
        //print(value?.name);

        Animal animal2 = new Animal();
        Dog dog2 = animal2 as Dog;
        //print(dog2?.name);


        // typeof, GetType()
        int a = 42;
        Type t = a.GetType();         // t = System.Int32
        Type t2 = typeof(string);     // t2 = System.String
    }
    private void OnEnable()
    {
        var person = new Person("SpiderMan");
        ShowTypeInfo(person); 
    }
    private void Start()
    { 
        var enemy1 = new Dragon(DragonType.Fire, "Angry Dragon");
        AddNewEnemyInDictionary<Dragon>(enemy1);
        var dragonType = GetEnemyFromDictionary<Dragon>().GetTypeDragon; // будет Fire
        print(dragonType);

        var enemy2 = new Zombie(ZombieType.Slow, "Slow Zombie");
        AddNewEnemyInDictionary<Zombie>(enemy2);
        var zombieType = GetEnemyFromDictionary<Zombie>().GetTypeZombie; // будет Slow
        print(zombieType);

        var enemy3 = new Vampire(VampireType.Simple, "Simple Vampire");
        AddNewEnemyInDictionary<Vampire>(enemy3);
        var vampireType = GetEnemyFromDictionary<Vampire>().GetTypeVampire; // будет Simple
        print(vampireType);
        
        foreach(var _enemy in enemys.Values)
        {
            //print(_enemy.GetType());
        }

    }

    void ShowTypeInfo<T>(T gameObject) where T : IPerson
    {
        Type type = gameObject.GetType();
        if (type == typeof(T))
        {
            //print("Class: " + type.Name); 
        }
    }


    public T GetEnemyFromDictionary<T>() where T : EnemyBase
    {
        if (enemys.TryGetValue(typeof(T), out var currentEnemy))
            return currentEnemy as T;
        else return null;
    }



    public void AddNewEnemyInDictionary<T>(EnemyBase enemy)
    { 
        enemys.Add(typeof(T), enemy);
    }


    public void Run<T>(ref T action) where T : struct, IAction
    {
        action.Execute(); // Без боксинга
    }

}

public class Animal
{
    public string name = "animal";
}
public class Dog : Animal
{
    public string vois = "gav";
}
public class Cat : Animal
{
    public string vois = "miau";
}















public interface IPerson
{
    string Name { get; set; }
}
public class Person: IPerson
{
    public string Name { get; set; }
    public Person(string name) => Name = name;
}




public class EnemyBase // Базовый клаасс
{ 
    public EnemyBase(string name)
    {
        this.name = name;
    }
    private protected string name;
    public string GetName => name;
    
}









public class Dragon : EnemyBase  
{  
    public Dragon(DragonType dragonType, string name) : base(name)
    {
        this.dragonType = dragonType;
    }
    private protected DragonType dragonType;
    public DragonType GetTypeDragon => dragonType;
}
public enum DragonType { Fire, Freez, Ellectro }












public class Vampire : EnemyBase  
{
    public Vampire(VampireType vampireType, string name) : base(name)
    {
        this.vampireType = vampireType;
    }
    private protected VampireType vampireType;
    public VampireType GetTypeVampire => vampireType;
}
 

public enum VampireType { Simple, Strong, Legendary }
















public class Zombie : EnemyBase  
{
    public Zombie(ZombieType zombieType, string name) : base(name)
    {
        this.zombieType = zombieType;
    }
    private protected ZombieType zombieType;
    public ZombieType GetTypeZombie => zombieType;
}

public enum ZombieType { Slow, Fast, Smart }


















public interface IAction { void Execute(); }

public struct Jump : IAction
{
    public void Execute() => Debug.Log("Jump!");
}

public struct Attack : IAction
{
    public void Execute() => Debug.Log("Attack!");
}

