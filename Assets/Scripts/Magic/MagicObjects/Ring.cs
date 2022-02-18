using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public MagicRenderer player;
    public RingController control;
    public float speed = 10.0f;
    public float fadeSpeed = 1.0f;
    public Vector2 dir;
    public GameObject root;
    public MagicEffect effect;
    public float mana;
    public Color fade;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().material.color = fade;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + Time.deltaTime * speed, gameObject.transform.localScale.y + Time.deltaTime * speed);
        if (fade.a > 0)
        {
            fade = new Color(fade.r, fade.g, fade.b, fade.a - Time.deltaTime * fadeSpeed * Mathf.Sqrt(100/mana));
            gameObject.GetComponent<SpriteRenderer>().material.color = fade;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "MaterialObject")
        {
            float coef = 0.25f * (mana / 200 + 0.5f);
            effect.doEffect(collision.gameObject.GetComponent<MagicRenderer>(), coef, root, player, mana);
            mana -= mana * 0.1f;
            control.StartNext(collision.gameObject, dir);
        }
    }

    public void initialize(MagicEffect effect, RingController control, GameObject root, Vector2 dir, MagicRenderer player, float mana)
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
