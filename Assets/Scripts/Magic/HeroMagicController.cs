using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroMagicController : MonoBehaviour
{
    public MagicRenderer player;

    public GameObject ringPrefab;
    public GameObject shieldPrefab;
    public GameObject wavePrefab;
    public GameObject ballPrefab;
    public GameObject pointPrefab;
    public GameObject clotPrefab;
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
                currentSpell.Start(gameObject, Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position, ((Time.time - startTime < 2.0f) ? (((Time.time - startTime) / 4.0f) * 100 + 50) : (100)), player);
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

    public void SetHotkeySpell(int hotkey, string spellText)
    {
        switch (hotkey)
        {
            case 1:
                spell1 = convertSpell(spellText, 0, -1);
                break;
            case 2:
                spell2 = convertSpell(spellText, 0, -1);
                break;
            case 3:
                spell3 = convertSpell(spellText, 0, -1);
                break;
            case 4:
                spell4 = convertSpell(spellText, 0, -1);
                break;
            case 5:
                spell5 = convertSpell(spellText, 0, -1);
                break;
            case 6:
                spell6 = convertSpell(spellText, 0, -1);
                break;
            case 7:
                spell7 = convertSpell(spellText, 0, -1);
                break;
            case 8:
                spell8 = convertSpell(spellText, 0, -1);
                break;
            case 9:
                spell9 = convertSpell(spellText, 0, -1);
                break;
        }
    }

    public MagicController convertSpell(string spellText, int startIndex, int previousLevel)
    {
        MagicController spell = null;
        int level = 0;
        while (spellText.Substring(startIndex + level, 1) == "\t")
        {
            level++;
        }

        if (previousLevel < level) {
            string effect = (spellText.Substring(spellText.IndexOf(' ', startIndex + level) + 1, spellText.IndexOf('\n', spellText.IndexOf(' ', startIndex + level) + 1) - (spellText.IndexOf(' ', startIndex + level) + 1)));

            MagicController spellbuffer1 = null;
            try
            {
                spellbuffer1 = convertSpell(spellText, spellText.IndexOf('\n', spellText.IndexOf(' ', startIndex + level) + 1) + 1, level);
            }
            catch
            {

            }
            MagicController spellbuffer2 = null;
            try
            {
                spellbuffer2 = convertSpell(spellText, spellText.IndexOf('\n', spellText.IndexOf('\n', spellText.IndexOf(' ', startIndex + level) + 1) + 1) + 1, level);
            }
            catch
            {

            }
            MagicController spellbuffer3 = null;
            try
            {
                spellbuffer3 = convertSpell(spellText, spellText.IndexOf('\n', spellText.IndexOf('\n', spellText.IndexOf('\n', spellText.IndexOf(' ', startIndex + level) + 1) + 1) + 1) + 1, level);
            }
            catch
            {

            }

            switch (spellText.Substring(startIndex + level, spellText.IndexOf(' ', startIndex + level) - (startIndex + level)))
            {
                case "Shield":
                    spell = new ShieldController(spellbuffer1, spellbuffer2, spellbuffer3,
                        getEffectByName(effect),
                        shieldPrefab);
                    break;
                case "Ring":
                    spell = new RingController(spellbuffer1, spellbuffer2, spellbuffer3,
                        getEffectByName(effect),
                        ringPrefab);
                    break;
                case "Wave":
                    spell = new WaveController(spellbuffer1, spellbuffer2, spellbuffer3,
                        getEffectByName(effect),
                        wavePrefab);
                    break;
                case "Ball":
                    spell = new BallController(spellbuffer1, spellbuffer2, spellbuffer3,
                        getEffectByName(effect),
                        ballPrefab);
                    break;
                case "Point":
                    spell = new PointController(spellbuffer1, spellbuffer2, spellbuffer3,
                        getEffectByName(effect),
                        pointPrefab);
                    break;
                case "Clot":
                    spell = new ClotController(spellbuffer1, spellbuffer2, spellbuffer3,
                        getEffectByName(effect),
                        clotPrefab);
                    break;
            }

            return spell;
        }
        else
        {
            return spell;
        }
    }

    private MagicEffect getEffectByName(string name)
    {
        switch (name)
        {
            case "tonus":
                return new TonusEffect();
                break;
            case "blindly":
                return new BlindlyEffect();
                break;
            case "anesthesia":
                return new AnesthesiaEffect();
                break;
            case "wind":
                return new WindEffect();
                break;
        }
        return null;
    }
}
