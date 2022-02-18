using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MagicEffect
{
    public Color fade;

    public abstract void doEffect(MagicRenderer target, float formCoef, GameObject root, MagicRenderer player, float mana);
}
