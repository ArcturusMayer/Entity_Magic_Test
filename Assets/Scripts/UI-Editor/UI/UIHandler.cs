using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public Text craft;
    public InputField spellText;
    public Button write;
    public Button read;
    public InputField spellName;
    public ScrollRect spellList;
    public GameObject spellPrefab;
    public HeroMagicController controller;

    private bool inMenu = false;
    private bool isRead = true;
    private bool isEdit = true;
    private bool isOnEdit = false;
    private int spellCount = 0;
    private int offset = 0;
    private int spellId = 0;

    private List<GameObject> spells;

    // Start is called before the first frame update
    void Start()
    {
        spells = new List<GameObject>();
        spellCount = int.Parse(PlayerPrefs.GetString("0", "0"));
        spellText.gameObject.SetActive(false);
        write.gameObject.SetActive(false);
        read.gameObject.SetActive(false);
        spellName.gameObject.SetActive(false);
        InitializeList();
        spellList.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCraftClick()
    {
        if (inMenu)
        {
            Time.timeScale = 1;
            craft.text = "Spell Craft";
            spellText.gameObject.SetActive(false);
            write.gameObject.SetActive(false);
            read.gameObject.SetActive(false);
            spellName.gameObject.SetActive(false);
            spellList.gameObject.SetActive(false);
            inMenu = !inMenu;
        }
        else
        {
            Time.timeScale = 0;
            craft.text = "Go back";
            if (!isRead)
            {
                spellText.gameObject.SetActive(true);
                write.gameObject.SetActive(true);
                read.gameObject.SetActive(true);
                spellName.gameObject.SetActive(true);
                spellList.gameObject.SetActive(false);
                write.GetComponentInChildren<Text>().text = "Write in spellbook";
                read.GetComponentInChildren<Text>().text = "Read your spellbook";
            }
            else
            {
                spellText.gameObject.SetActive(false);
                write.gameObject.SetActive(true);
                read.gameObject.SetActive(true);
                spellName.gameObject.SetActive(false);
                spellList.gameObject.SetActive(true);
                write.GetComponentInChildren<Text>().text = "Edit spell";
                read.GetComponentInChildren<Text>().text = "Go to Crafting";
            }
            inMenu = !inMenu;
        }
    }

    public void OnWriteClick()
    {
        if (!isEdit)
        {
            if (!isOnEdit)
            {
                if (spellName.text != "" && spellText.text != "")
                {
                    GameObject spell = Instantiate(spellPrefab, spellList.content).gameObject;
                    spells.Add(spell);
                    spell.transform.localPosition = new Vector3(spell.transform.localPosition.x, spell.transform.localPosition.y + offset, spell.transform.localPosition.z);
                    offset -= 75;
                    spell.GetComponent<SpellSetter>().setSpell(spellName.text, spellText.text + ((spellText.text.Substring(spellText.text.Length - 1, 1) != "\n") ? "\n" : ""), 0, controller);
                    PlayerPrefs.SetString("0", (spellCount++).ToString());
                    PlayerPrefs.SetString(spellCount.ToString(), spellName.text + "\n" + spellText.text + ((spellText.text.Substring(spellText.text.Length - 1, 1) != "\n") ? "\n" : ""));
                }
            }
            else
            {
                spells[spellId].GetComponent<SpellSetter>().setSpell(spellName.text, spellText.text + ((spellText.text.Substring(spellText.text.Length - 1, 1) != "\n") ? "\n" : ""), 0, controller);
                PlayerPrefs.SetString((spellId + 1).ToString(), spellName.text + "\n" + spellText.text + ((spellText.text.Substring(spellText.text.Length - 1, 1) != "\n")?"\n":""));
            }

            spellText.gameObject.SetActive(false);
            write.gameObject.SetActive(true);
            read.gameObject.SetActive(true);
            spellName.gameObject.SetActive(false);
            spellList.gameObject.SetActive(true);
            read.GetComponentInChildren<Text>().text = "Go to Crafting";
            write.GetComponentInChildren<Text>().text = "Edit spell";
            isEdit = true;
            isRead = !isRead;
        }
        else
        {
            int i = 0;
            foreach(GameObject g in spells)
            {
                if (g.GetComponent<SpellSetter>().isActive)
                {
                    spellText.gameObject.SetActive(true);
                    spellText.text = g.GetComponent<SpellSetter>().spellText;
                    write.gameObject.SetActive(true);
                    read.gameObject.SetActive(true);
                    spellName.gameObject.SetActive(true);
                    spellName.text = g.GetComponent<SpellSetter>().name;
                    spellList.gameObject.SetActive(false);
                    read.GetComponentInChildren<Text>().text = "Read your spellbook";
                    write.GetComponentInChildren<Text>().text = "Write in spellbook";
                    isRead = !isRead;
                    g.GetComponent<SpellSetter>().Dis_Activate();
                    isOnEdit = true;
                    isEdit = false;
                    spellId = i;
                }
                i++;
            }
        }
    }

    public void OnReadClick()
    {
        if (isRead)
        {
            spellText.gameObject.SetActive(true);
            write.gameObject.SetActive(true);
            read.gameObject.SetActive(true);
            spellName.gameObject.SetActive(true);
            spellList.gameObject.SetActive(false);
            read.GetComponentInChildren<Text>().text = "Read your spellbook";
            write.GetComponentInChildren<Text>().text = "Write in spellbook";
            isEdit = false;
            isRead = !isRead;
        }
        else
        {
            spellText.gameObject.SetActive(false);
            write.gameObject.SetActive(true);
            read.gameObject.SetActive(true);
            spellName.gameObject.SetActive(false);
            spellList.gameObject.SetActive(true);
            read.GetComponentInChildren<Text>().text = "Go to Crafting";
            write.GetComponentInChildren<Text>().text = "Edit spell";
            isEdit = true;
            isRead = !isRead;
        }
        isOnEdit = false;
    }

    public void InitializeList()
    {
        for (int i = 1; i <= spellCount; i++){
            string buf = PlayerPrefs.GetString(i.ToString(), "");
            GameObject spell = Instantiate(spellPrefab, spellList.content).gameObject;
            spells.Add(spell);
            spell.transform.localPosition = new Vector3(spell.transform.localPosition.x, spell.transform.localPosition.y + offset, spell.transform.localPosition.z);
            offset -= 75;
            spell.GetComponent<SpellSetter>().setSpell(buf.Substring(0, buf.IndexOf('\n', 0)), buf.Substring(buf.IndexOf('\n', 0) + 1, buf.LastIndexOf('\n') - (buf.IndexOf('\n', 0))), 0, controller);
        }
    }
}
