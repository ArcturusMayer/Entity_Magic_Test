using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TonusEffect : MagicEffect
{
    public TonusEffect()
    {
        fade = new Color(0.64f, 0.95f, 0.16f, 1);
    }

    private float speedCoef = 1;
    private float defenceCoef = 1;
    private float stealthCoef = 1;

    public override void doEffect(MagicRenderer target, float formCoef, GameObject root, MagicRenderer player, float mana)
    {
        target.speedUp(mana * formCoef * speedCoef, mana * formCoef * speedCoef / 10);
        target.defenceUp(mana * formCoef * defenceCoef);
        target.stealthDown(mana * formCoef * stealthCoef, mana * formCoef * stealthCoef / 10);
    }
}
