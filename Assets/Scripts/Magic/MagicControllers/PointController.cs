using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MagicController
{
    public PointController(MagicController spell1, MagicController spell2, MagicController spell3, MagicEffect effect, GameObject prefab) : base(spell1, spell2, spell3, effect)
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
            localSpell.GetComponent<Point>().initialize(spellEffect, this, root, direction, player, mana);
        }
    }
}

