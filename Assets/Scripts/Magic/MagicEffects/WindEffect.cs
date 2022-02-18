using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindEffect : MagicEffect
{
    private float speedCoef = 1;
    private float defenceCoef = 1;

    public WindEffect()
    {
        fade = new Color(0.84f, 0.92f, 0.97f);
    }

    public override void doEffect(MagicRenderer target, float formCoef, GameObject root, MagicRenderer player, float mana)
    {
        target.speedUp(mana * formCoef * speedCoef, mana * formCoef * speedCoef / 10);
        target.defenceDown(mana * formCoef * defenceCoef);
    }
}
