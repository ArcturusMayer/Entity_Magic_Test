using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellSetter : MonoBehaviour
{
    HeroMagicController controller;
    public Button spell;
    public Text setting;
    int hotkey = 0;
    public string spellText;
    public string name;

    public bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                hotkey = 1;
                setting.text = hotkey.ToString();
                controller.SetHotkeySpell(hotkey, spellText);
                isActive = !isActive;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                hotkey = 2;
                setting.text = hotkey.ToString();
                controller.SetHotkeySpell(hotkey, spellText);
                isActive = !isActive;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                hotkey = 3;
                setting.text = hotkey.ToString();
                controller.SetHotkeySpell(hotkey, spellText);
                isActive = !isActive;
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                hotkey = 4;
                setting.text = hotkey.ToString();
                controller.SetHotkeySpell(hotkey, spellText);
                isActive = !isActive;
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                hotkey = 5;
                setting.text = hotkey.ToString();
                controller.SetHotkeySpell(hotkey, spellText);
                isActive = !isActive;
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                hotkey = 6;
                setting.text = hotkey.ToString();
                controller.SetHotkeySpell(hotkey, spellText);
                isActive = !isActive;
            }
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                hotkey = 7;
                setting.text = hotkey.ToString();
                controller.SetHotkeySpell(hotkey, spellText);
                isActive = !isActive;
            }
            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                hotkey = 8;
                setting.text = hotkey.ToString();
                controller.SetHotkeySpell(hotkey, spellText);
                isActive = !isActive;
            }
            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                hotkey = 9;
                setting.text = hotkey.ToString();
                controller.SetHotkeySpell(hotkey, spellText);
                isActive = !isActive;
            }
        }
    }

    public void setSpell(string name, string spellText, int hotkeyIndex, HeroMagicController controller)
    {
        this.controller = controller;
        this.spellText = spellText;
        hotkey = hotkeyIndex;
        this.name = name;
        this.spell.GetComponentInChildren<Text>().text = this.name;
        setting.text = (hotkeyIndex != 0) ? hotkey.ToString() : "";
    }

    public void Dis_Activate()
    {
        isActive = !isActive;
    }
}
