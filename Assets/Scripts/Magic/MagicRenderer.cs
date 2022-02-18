using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicRenderer : MonoBehaviour
{
    public float hp = 100;
    public float baseHP = 100;
    public float mana = 10000;
    public float baseMana = 10000;
    public float speed = 5.0f;
    public float baseSpeed = 5.0f;
    public float stealth = 0;
    public float baseStealth = 0;
    public float defence = 0;
    public float manaRegen = 20;
    public float hpRegen = 2f;
    public bool stun = false;

    private float speedDuration = 0;
    private float speedStartTime = 0;
    private float stealthDuration = 0;
    private float stealthStartTime = 0;
    private float stunDuration = 0;
    private float stunStartTime = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(speedDuration < Time.time - speedStartTime)
        {
            speed = baseSpeed;
        }

        if(stunDuration < Time.time - stunStartTime)
        {
            stun = false;
        }

        if (stun)
        {
            speed = 0;
        }
        else
        {
            speed = baseSpeed;
        }

        if (stealthDuration < Time.time - stealthStartTime)
        {
            stealth = baseStealth;
        }

        if (mana < baseMana)
        {
            mana += manaRegen * Time.deltaTime;
        }
        else
        {
            mana = baseMana;
        }

        if (hp < baseHP)
        {
            hp += hpRegen * Time.deltaTime;
        }
        else
        {
            hp = baseHP;
        }

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void speedUp(float speedBonus, float bonusTime)
    {
        speed = baseSpeed;
        if (speed + speedBonus < 20)
        {
            speed += speedBonus;
        }
        else
        {
            speed = 20;
        }
        speedDuration = bonusTime;
        speedStartTime = Time.time;
    }

    public void speedDown(float speedBonus, float bonusTime)
    {
        speed = baseSpeed;
        if (speed - speedBonus * (1 - defence) > 0)
        {
            speed -= speedBonus * (1 - defence);
        }
        else
        {
            speed = 0;
        }
        speedDuration = bonusTime * (1 - defence);
        speedStartTime = Time.time;
    }

    public void stealthUp(float stealthBonus, float bonusTime)
    {
        stealth = baseStealth;
        stealth += stealthBonus;
        stealthDuration = bonusTime;
        stealthStartTime = Time.time;
    }

    public void stealthDown(float stealthBonus, float bonusTime)
    {
        stealth = baseStealth;
        if (stealth - stealthBonus * (1 - defence) > 0)
        {
            stealth -= stealthBonus * (1 - defence);
        }
        else
        {
            stealth = 0;
        }
        stealthDuration = bonusTime * (1 - defence);
        stealthStartTime = Time.time;
    }

    public void HpUp(float bonusHP)
    {
        if(hp + bonusHP < baseHP)
        {
            hp += bonusHP;
        }
        else
        {
            hp = baseHP;
        }
    }

    public void HpDown(float damage)
    {
        if (hp - damage * (1 - defence) > 0)
        {
            hp -= damage * (1 - defence);
        }
        else
        {
            hp = 0;
        }
    }

    public void manaUp(float manaBonus)
    {
        if(manaBonus + manaBonus < baseMana)
        {
            mana += manaBonus;
        }
        else
        {
            mana = baseMana;
        }
    }

    public void manaDown(float manaBonus)
    {
        if (mana - manaBonus * (1 - defence) > 0)
        {
            mana -= manaBonus * (1 - defence);
        }
        else
        {
            mana = 0;
        }
    }

    public void defenceUp(float defenceBonus)
    {
        if (defence + defenceBonus / 1000 < 1)
        {
            defence += defenceBonus / 1000;
        }
        else
        {
            defence = 1;
        }
    }

    public void defenceDown(float defenceBonus)
    {
        if(defence - defenceBonus / 1000 < 0)
        {
            defence -= defenceBonus / 1000;
        }
        else
        {
            defence = 0;
        }
    }

    public void getStun(float stunDuration)
    {
        stun = true;
        this.stunDuration = stunDuration * (1 - defence);
        stunStartTime = Time.time;
    }

    public void releaseStun()
    {
        stun = false;
        this.stunDuration = 0;
    }
}
