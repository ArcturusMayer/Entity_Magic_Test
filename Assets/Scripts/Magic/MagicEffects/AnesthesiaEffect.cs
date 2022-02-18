using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnesthesiaEffect : MagicEffect
{
    public AnesthesiaEffect()
    {
        fade = new Color(0.14f, 0.17f, 0.91f, 1);
    }

    private float hpCoef = 1;
    private float stunCoef = 1;

    public override void doEffect(MagicRenderer target, float formCoef, GameObject root, MagicRenderer player, float mana)
    {
        target.HpUp(mana * formCoef * hpCoef);
        target.getStun(mana * formCoef * stunCoef / 10);
    }
}
