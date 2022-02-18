using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private MagicRenderer player;
    private BallController control;
    private Color fade;
    private float speed = 5.0f;
    private float fadeSpeed = 1.0f;
    private Vector2 dir;
    private GameObject root;
    private MagicEffect effect;
    private float mana;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponentInChildren<SpriteRenderer>().material.color = fade;
    }

    // Update is called once per frame
    void Update()
    {
        if (root.transform.localScale.magnitude < 1.44f)
        {
            gameObject.transform.localScale = new Vector3(2, 2, 1);
        }
        gameObject.transform.Translate(dir * speed * Time.deltaTime);
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
            float coef = 1.0f * (mana / 200 + 0.5f);
            effect.doEffect(collision.gameObject.GetComponent<MagicRenderer>(), coef, root, player, mana);
            mana -= mana * 0.5f;
            control.StartNext(collision.gameObject, dir);
        }
    }

    public void initialize(MagicEffect effect, BallController control, GameObject root, Vector2 dir, MagicRenderer player, float mana)
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
