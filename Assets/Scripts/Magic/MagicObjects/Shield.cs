using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public MagicRenderer player;
    public ShieldController control;
    public Color fade;
    public float fadeSpeed = 0.1f;
    public GameObject root;
    public Vector2 dir;
    public MagicEffect effect;
    public float mana;
    public float shieldPower = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().material.color = fade;
    }

    // Update is called once per frame
    void Update()
    {
        if (root.transform.localScale.magnitude < 1.44f)
        {
            gameObject.transform.localScale = new Vector3(2, 2, 1);
        }
        gameObject.transform.position = root.transform.position;
        if (fade.a > 0)
        {
            fade = new Color(fade.r, fade.g, fade.b, fade.a - Time.deltaTime * fadeSpeed * Mathf.Sqrt(100 / mana));
            gameObject.GetComponent<SpriteRenderer>().material.color = fade;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MaterialObject")
        {
            float coef = 2.0f * (mana / 200 + 0.5f);
            effect.doEffect(collision.gameObject.GetComponent<MagicRenderer>(), coef, root, player, mana);
            mana -= mana * shieldPower;
            control.StartNext(collision.gameObject, dir);
        }
    }

    public void initialize(MagicEffect effect, ShieldController control, GameObject root, Vector2 dir, MagicRenderer player, float mana)
    {
        this.effect = effect;
        this.control = control;
        this.root = root;

        if (control.formMod.Equals("Fury"))
        {
            player.mana += -mana * 0.2f;
            fadeSpeed *= 2.0f;
            shieldPower *= 0.5f;
        }
        else if (control.formMod.Equals("Fear"))
        {
            player.mana += -mana * 0.2f;
            fadeSpeed *= 0.5f;
            shieldPower *= 2.0f;
        }
        else if (control.formMod.Equals("Sad"))
        {
            player.mana += mana * 0.5f;
            fadeSpeed *= 2.0f;
            shieldPower *= 2.0f;
        }
        else
        {

        }

        this.dir = dir;
        this.player = player;
        this.mana = mana;
        this.fade = this.effect.fade;
    }
}
