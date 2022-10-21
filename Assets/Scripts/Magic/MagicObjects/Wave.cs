using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public MagicRenderer player;
    public WaveController control;
    public Color fade;
    public float speed = 5.0f;
    public float fadeSpeed = 1.0f;
    public Vector2 dir;
    public GameObject root;
    public MagicEffect effect;
    public float mana;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponentInChildren<SpriteRenderer>().material.color = fade;
        gameObject.transform.rotation = Quaternion.AngleAxis((dir.x > 0)? Vector3.Angle(Vector3.up, dir):-Vector3.Angle(Vector3.up, dir), Vector3.back);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localPosition = new Vector3(0, 0, -1);
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + Time.deltaTime * speed, gameObject.transform.localScale.y + Time.deltaTime * speed);
        if (fade.a > 0)
        {
            fade = new Color(fade.r, fade.g, fade.b, fade.a - Time.deltaTime * fadeSpeed * Mathf.Sqrt(100 / mana));
            gameObject.GetComponentInChildren<SpriteRenderer>().material.color = fade;
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
            float coef = 0.5f * (mana / 200 + 0.5f);
            effect.doEffect(collision.gameObject.GetComponent<MagicRenderer>(), coef, root, player, mana);
            mana -= mana * 0.3f;
            control.StartNext(collision.gameObject, dir);
        }
    }

    public void initialize(MagicEffect effect, WaveController control, GameObject root, Vector2 dir, MagicRenderer player, float mana)
    {
        this.effect = effect;
        this.control = control;
        this.root = root;

        if (control.formMod.Equals("Fury"))
        {
            player.mana += -mana * 0.2f;
            this.mana = mana * 1.5f;
            speed *= 0.8f;
        }
        else if (control.formMod.Equals("Fear"))
        {
            player.mana += -mana * 0.2f;
            this.mana = mana * 0.8f;
            speed *= 1.5f;
        }
        else if (control.formMod.Equals("Sad"))
        {
            player.mana += mana * 0.5f;
            this.mana = mana * 0.8f;
            speed *= 0.8f;
        }
        else
        {
            this.mana = mana;
        }

        this.dir = dir;
        this.player = player;
        this.mana = mana;
        this.fade = this.effect.fade;
    }
}
