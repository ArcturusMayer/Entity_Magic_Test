using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MagicController
{
    public MagicRenderer player;
    public MagicController nextSpell1;
    public MagicController nextSpell2;
    public MagicController nextSpell3;
    public GameObject spellPrefab;
    public GameObject localSpell;
    public float mana;
    public MagicEffect spellEffect;

    public MagicController(MagicController spell1, MagicController spell2, MagicController spell3, MagicEffect effect)
    {
        nextSpell1 = spell1;
        nextSpell2 = spell2;
        nextSpell3 = spell3;
        spellEffect = effect;
    }

    public abstract void Start(GameObject root, Vector2 direction, float manaCost, MagicRenderer player);

    public void StartNext(GameObject root, Vector2 direction)
    {
        if (nextSpell1 != null)
        {
            nextSpell1.Start(root, direction, mana, this.player);
        }
        if (nextSpell2 != null)
        {
            nextSpell2.Start(root, direction, mana, this.player);
        }
        if (nextSpell3 != null)
        {
            nextSpell3.Start(root, direction, mana, this.player);
        }
    }
}
