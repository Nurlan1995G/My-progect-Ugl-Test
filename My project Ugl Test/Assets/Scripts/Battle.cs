using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    private List <Warrior> _warriorList = new List<Warrior>()
    {
        new Knight(100, 20, DamageType.Melee, 30),
        new Archer(60, 15, 0.7f),
        new Dragon(200, 30, DamageType.Range)
    };

    private void Start()
    {
        foreach (Warrior warrior in _warriorList)
            print($" {warrior.GetType()}: {warrior.GetInfo()}");

    }
}

public enum DamageType { Melee, Range, Magic };

public class Warrior
{
    protected int Health;
    protected int Damage;
    protected DamageType DmgType;

    public Warrior(int health, int damage, DamageType dmgType)   //конструктор
    {
        Health = health;
        Damage = damage;
        DmgType = dmgType;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    public string GetInfo()
    {
        return $"HP: {Health}; dmg: {Damage}";
    }

    public bool isAlive()
    {
        return Health > 0;
    }

    public int GetDamage()
    {
        return Damage;
    }
}


public class Knight : Warrior
{
    private int _armor;   //броня
   public Knight(int health, int damage, DamageType dmgType, int armor) : base(health, damage, dmgType)  //конструктор унаследуемый из родителя Warrior использованого через ключевое слово base
    {
        _armor = armor;
    }
}

public class Archer : Warrior
{
    private float _criticalChance;   //критический шанс

    public Archer(int health, int damage, float criticalChance) : base(health, damage, DamageType.Range)
    {
        _criticalChance = criticalChance;
    }
}

public class Dragon : Warrior
{
    public Dragon(int health, int damage, DamageType dmgType) : base(health, damage, dmgType) { }

    public void Heal(int health)
    {
        Health += health;
    }
}
