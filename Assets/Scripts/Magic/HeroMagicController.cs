using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroMagicController : MonoBehaviour
{
    public MagicRenderer player;

    public Text manaDisplay;

    private MagicController currentSpell;
    private float startTime = 0.0f;

    private MagicController spell1;
    private MagicController spell2;
    private MagicController spell3;
    private MagicController spell4;
    private MagicController spell5;
    private MagicController spell6;
    private MagicController spell7;
    private MagicController spell8;
    private MagicController spell9;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        manaDisplay.text = Mathf.Round(player.mana / 100).ToString();
        if (Input.GetMouseButtonDown(0))
        {
            startTime = Time.time;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (Time.timeScale > 0)
            {
                currentSpell.Start(gameObject, (Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position).normalized, ((Time.time - startTime < 2.0f) ? (((Time.time - startTime) / 4.0f) * 100 + 50) : (100)), player);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentSpell = spell1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentSpell = spell2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentSpell = spell3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentSpell = spell4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            currentSpell = spell5;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            currentSpell = spell6;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            currentSpell = spell7;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            currentSpell = spell8;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            currentSpell = spell9;
        }
    }

    public void SetHotkeySpell(int hotkey, MagicController spell)
    {
        switch (hotkey)
        {
            case 1:
                spell1 = spell;
                break;
            case 2:
                spell2 = spell;
                break;
            case 3:
                spell3 = spell;
                break;
            case 4:
                spell4 = spell;
                break;
            case 5:
                spell5 = spell;
                break;
            case 6:
                spell6 = spell;
                break;
            case 7:
                spell7 = spell;
                break;
            case 8:
                spell8 = spell;
                break;
            case 9:
                spell9 = spell;
                break;
        }
    }
}
