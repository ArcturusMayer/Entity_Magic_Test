using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindlyEffect : MagicEffect
{
    public BlindlyEffect()
    {
        fade = new Color(0.93f, 0.02f, 0.07f, 1);
    }

    private float hpCoef = 1;
    private float stealthCoef = 1;

    public override void doEffect(MagicRenderer target, float formCoef, GameObject root, MagicRenderer player, float mana)
    {
        target.HpDown(mana * formCoef * hpCoef);
        target.stealthUp(mana * formCoef * stealthCoef, mana * formCoef * stealthCoef / 10);
    }
}
