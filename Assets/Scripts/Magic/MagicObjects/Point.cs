using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    private MagicRenderer player;
    private PointController control;
    private Color fade;
    private float fadeSpeed = 1.0f;
    private GameObject root;
    private Vector2 dir;
    private MagicEffect effect;
    private float mana;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().material.color = fade;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = root.transform.position;
        if (fade.a > 0)
        {
            fade = new Color(fade.r, fade.g, fade.b, fade.a - Time.deltaTime * fadeSpeed * Mathf.Sqrt(100 / mana));
            gameObject.GetComponent<SpriteRenderer>().material.color = fade;
        }
        else
        {
            float coef = 1.0f * (mana / 200 + 0.5f);
            effect.doEffect(root.GetComponent<MagicRenderer>(), coef, root, player, mana);
            control.StartNext(root.gameObject, dir);
            Destroy(gameObject);
        }
    }

    public void initialize(MagicEffect effect, PointController control, GameObject root, Vector2 dir, MagicRenderer player, float mana)
    {
        this.effect = effect;
        this.control = control;
        this.root = root;
        this.dir = dir;
        this.player = player;
        this.mana = mana;
        this.fade = this.effect.fade;
    }
}