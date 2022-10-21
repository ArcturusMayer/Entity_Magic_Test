using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : MagicController
{
    public RingController(MagicController spell1, MagicController spell2, MagicController spell3, MagicEffect effect, GameObject prefab, string formModif) : base(spell1, spell2, spell3, effect, formModif)
    {
        spellPrefab = prefab;
    }

    public override void Start(GameObject root, Vector2 direction, float manaCost, MagicRenderer player)
    {
        this.player = player;
        if (this.player.mana > 0)
        {
            this.player.mana -= mana;
            localSpell = GameObject.Instantiate(spellPrefab, root.transform);
            this.mana = manaCost;
            localSpell.GetComponent<Ring>().initialize(spellEffect, this, root, direction, player, mana);
        }
    }
}
