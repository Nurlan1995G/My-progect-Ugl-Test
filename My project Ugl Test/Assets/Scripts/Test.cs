using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    protected List<Warrio> _warrioList = new List<Warrio>()
    {
        new Knigh(100, 20, DamageTyp.Meleee,30),
        new Arche(60, 15, 0,7f),
        new Drago(200, 30, DamageTyp.Range)
    };

    private void Start()
    {
        foreach (Warrio warrio in _warrioList)
        {
            print($"{warrio.GetType()}; {warrio.GetInf()} ");
            
        }
    }
}

public enum DamageTyp { Meleee, Range, Magic };


public class Warrio
{
    protected int CurHealth;
    protected int Damage;
    protected DamageTyp DamageTyp;  //тип повреждений

    public Warrio(int curHealth, int damage, DamageTyp damageType)
    {
        CurHealth = curHealth;
        Damage = damage;
        DamageTyp = damageType;
    }

    public void TakeDamag(int damage)
    {
        CurHealth -= damage;
    }

    public string GetInf()
    {
        return $"HP: {CurHealth};  dmg: {Damage} ";
    }

    public bool isAliv()
    {
        return CurHealth > 0;   
    }

    public int GetDamag()
    {
        return Damage;
    }
}

public class Knigh : Warrio
{
    private int _armor;
    public Knigh(int health, int damage, DamageTyp dmgType, int armor) : base(health, damage, dmgType)
    {
        _armor = armor;
    }
}

public class Arche : Warrio
{
    private float _criticalChance;

    public Arche(int health, int damage, DamageTyp dmgType, float criticalChance) : base(health, damage, dmgType)
    {
        _criticalChance = criticalChance;
    }
}

public class Drago : Warrio
{
    public Drago(int health, int damage, DamageTyp dmgType) : base(health, damage, dmgType) { }

    public void Heal(int health)
    {
        CurHealth += health;
    }
}

