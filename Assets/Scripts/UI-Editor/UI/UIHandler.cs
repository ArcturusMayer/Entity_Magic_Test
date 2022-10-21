using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public Text craft;
    //public InputField spellText;
    public GameObject spellsEdit;
    public Button write;
    public Button read;
    public InputField spellName;
    public ScrollRect spellList;
    public GameObject spellPrefab;
    public HeroMagicController controller;

    public GameObject ringPrefab;
    public GameObject shieldPrefab;
    public GameObject wavePrefab;
    public GameObject ballPrefab;
    public GameObject pointPrefab;
    public GameObject clotPrefab;

    private bool inMenu = false;
    private bool isRead = true;
    private bool isEdit = true;
    private bool isOnEdit = false;
    private int spellCount = 0;
    private int offset = 0;
    private int spellId = 0;

    private List<List<Spell>> spells;
    private List<GameObject> spellsCollection;

    struct Spell
    {
        public string name;
        public string formMod;
        public string form;
        public string effect;
        public string objectMod;
        public string objectType;
        public string paramMod;
        public string param;
    }

    private string writeSimpleSpell(Spell spell)
    {
        StringBuilder builder = new StringBuilder(spell.name);
        builder.Append('\t');
        builder.Append(spell.formMod);
        builder.Append('\t');
        builder.Append(spell.form);
        builder.Append('\t');
        builder.Append(spell.effect);
        builder.Append('\t');
        builder.Append(spell.objectMod);
        builder.Append('\t');
        builder.Append(spell.objectType);
        builder.Append('\t');
        builder.Append(spell.paramMod);
        builder.Append('\t');
        builder.Append(spell.param);
        builder.Append('\n');
        return builder.ToString();
    }

    private void writeSpell(List<Spell> spell, int spellid)
    {
        string rawSpell = "";
        int i = 0;
        foreach (Spell sp in spell)
        {
            rawSpell += writeSimpleSpell(spell[i]);
            i++;
        }
        PlayerPrefs.SetString((spellid + 1).ToString(), rawSpell);
    }

    private List<Spell> readSpell(int spellid)
    {
        List<Spell> spell = new List<Spell>();
        string rawSpells = PlayerPrefs.GetString((spellid + 1).ToString());
        foreach (string rawSpell in rawSpells.Split(new char[] { '\n' }))
        {
            string[] raw = rawSpell.Split(new char[] { '\t' });
            Spell sp = new Spell();
            sp.name = raw[0].Trim(new char[] { '\t', '\n', ' ' });
            sp.formMod = raw[1].Trim(new char[] { '\t', '\n', ' ' });
            sp.form = raw[2].Trim(new char[] { '\t', '\n', ' ' });
            sp.effect = raw[3].Trim(new char[] { '\t', '\n', ' ' });
            sp.objectMod = raw[4].Trim(new char[] { '\t', '\n', ' ' });
            sp.objectType = raw[5].Trim(new char[] { '\t', '\n', ' ' });
            sp.paramMod = raw[6].Trim(new char[] { '\t', '\n', ' ' });
            sp.param = raw[7].Trim(new char[] { '\t', '\n', ' ' });
            spell.Add(sp);
        }
        return spell;
    }

    private void readSpells()
    {
        spells.Clear();
        for(int i = 0; i < spellCount; i++)
        {
            spells.Add(readSpell(i));
        }
    }

    private List<Spell> getSpell()
    {
        List<Spell> spell = new List<Spell>();

        if (spellsEdit.GetComponentsInChildren<RectTransform>()[0].GetComponentsInChildren<Dropdown>()[1].value != 0 &&
            spellsEdit.GetComponentsInChildren<RectTransform>()[0].GetComponentsInChildren<Dropdown>()[2].value != 0 &&
            spellName.text != "" && spellName.text != null)
        {
            Spell sp1 = new Spell();
            sp1.name = spellName.text;
            sp1.formMod = spellsEdit.GetComponentsInChildren<Dropdown>()[0].options[
                spellsEdit.GetComponentsInChildren<Dropdown>()[0].value].text;
            sp1.form = spellsEdit.GetComponentsInChildren<Dropdown>()[1].options[
                spellsEdit.GetComponentsInChildren<Dropdown>()[1].value].text;
            sp1.effect = spellsEdit.GetComponentsInChildren<Dropdown>()[2].options[
                spellsEdit.GetComponentsInChildren<Dropdown>()[2].value].text;
            sp1.objectMod = spellsEdit.GetComponentsInChildren<Dropdown>()[3].options[
                spellsEdit.GetComponentsInChildren<Dropdown>()[3].value].text;
            sp1.objectType = spellsEdit.GetComponentsInChildren<Dropdown>()[4].options[
                spellsEdit.GetComponentsInChildren<Dropdown>()[4].value].text;
            sp1.paramMod = spellsEdit.GetComponentsInChildren<Dropdown>()[5].options[
                spellsEdit.GetComponentsInChildren<Dropdown>()[5].value].text;
            sp1.param = spellsEdit.GetComponentsInChildren<Dropdown>()[6].options[
                spellsEdit.GetComponentsInChildren<Dropdown>()[6].value].text;
            spell.Add(sp1);

            try
            {
                if (spellsEdit.GetComponentsInChildren<Dropdown>()[8].value != 0 &&
                    spellsEdit.GetComponentsInChildren<Dropdown>()[9].value != 0)
                {
                    Spell sp2 = new Spell();
                    sp2.name = spellName.text;
                    sp2.formMod = spellsEdit.GetComponentsInChildren<Dropdown>()[7].options[
                        spellsEdit.GetComponentsInChildren<Dropdown>()[7].value].text;
                    sp2.form = spellsEdit.GetComponentsInChildren<Dropdown>()[8].options[
                        spellsEdit.GetComponentsInChildren<Dropdown>()[8].value].text;
                    sp2.effect = spellsEdit.GetComponentsInChildren<Dropdown>()[9].options[
                        spellsEdit.GetComponentsInChildren<Dropdown>()[9].value].text;
                    sp2.objectMod = spellsEdit.GetComponentsInChildren<Dropdown>()[10].options[
                        spellsEdit.GetComponentsInChildren<Dropdown>()[10].value].text;
                    sp2.objectType = spellsEdit.GetComponentsInChildren<Dropdown>()[11].options[
                        spellsEdit.GetComponentsInChildren<Dropdown>()[11].value].text;
                    sp2.paramMod = spellsEdit.GetComponentsInChildren<Dropdown>()[12].options[
                        spellsEdit.GetComponentsInChildren<Dropdown>()[12].value].text;
                    sp2.param = spellsEdit.GetComponentsInChildren<Dropdown>()[13].options[
                        spellsEdit.GetComponentsInChildren<Dropdown>()[13].value].text;
                    spell.Add(sp2);

                    try
                    {
                        if (spellsEdit.GetComponentsInChildren<Dropdown>()[15].value != 0 &&
                            spellsEdit.GetComponentsInChildren<Dropdown>()[16].value != 0)
                        {
                            Spell sp3 = new Spell();
                            sp3.name = spellName.text;
                            sp3.formMod = spellsEdit.GetComponentsInChildren<Dropdown>()[14].options[
                                spellsEdit.GetComponentsInChildren<Dropdown>()[14].value].text;
                            sp3.form = spellsEdit.GetComponentsInChildren<Dropdown>()[15].options[
                                spellsEdit.GetComponentsInChildren<Dropdown>()[15].value].text;
                            sp3.effect = spellsEdit.GetComponentsInChildren<Dropdown>()[16].options[
                                spellsEdit.GetComponentsInChildren<Dropdown>()[16].value].text;
                            sp3.objectMod = spellsEdit.GetComponentsInChildren<Dropdown>()[17].options[
                                spellsEdit.GetComponentsInChildren<Dropdown>()[17].value].text;
                            sp3.objectType = spellsEdit.GetComponentsInChildren<Dropdown>()[18].options[
                                spellsEdit.GetComponentsInChildren<Dropdown>()[18].value].text;
                            sp3.paramMod = spellsEdit.GetComponentsInChildren<Dropdown>()[19].options[
                                spellsEdit.GetComponentsInChildren<Dropdown>()[19].value].text;
                            sp3.param = spellsEdit.GetComponentsInChildren<Dropdown>()[20].options[
                                spellsEdit.GetComponentsInChildren<Dropdown>()[20].value].text;
                            spell.Add(sp3);
                        }
                    }catch(Exception e)
                    {
                        Debug.LogError(e);
                    }
                }
            }catch(Exception e)
            {
                Debug.LogError(e);
            }
        }

        return spell;
    }

    private MagicController buildFullSpell(List<Spell> spell)
    {
        MagicController controller = null;
        for(int i = spell.Count - 1; i >= 0; i--)
        {
            controller = buildSpell(spell[i], controller);
        }
        return controller;
    }

    private MagicController buildSpell(Spell sp, MagicController childSpell)
    {
        MagicController spell = null;
        switch (sp.form)
        {
            case "Shield":
                spell = new ShieldController(childSpell, null, null,
                    getEffectByName(sp.effect),
                    shieldPrefab, sp.formMod);
                break;
            case "Ring":
                spell = new RingController(childSpell, null, null,
                    getEffectByName(sp.effect),
                    ringPrefab, sp.formMod);
                break;
            case "Wave":
                spell = new WaveController(childSpell, null, null,
                    getEffectByName(sp.effect),
                    wavePrefab, sp.formMod);
                break;
            case "Ball":
                spell = new BallController(childSpell, null, null,
                    getEffectByName(sp.effect),
                    ballPrefab, sp.formMod);
                break;
            case "Point":
                spell = new PointController(childSpell, null, null,
                    getEffectByName(sp.effect),
                    pointPrefab, sp.formMod);
                break;
            case "Clot":
                spell = new ClotController(childSpell, null, null,
                    getEffectByName(sp.effect),
                    clotPrefab, sp.formMod);
                break;
        }
        return spell;
    }

    private MagicEffect getEffectByName(string name)
    {
        switch (name)
        {
            case "Tonus":
                return new TonusEffect();
                break;
            case "Blindly":
                return new BlindlyEffect();
                break;
            case "Anesthesia":
                return new AnesthesiaEffect();
                break;
            case "Wind":
                return new WindEffect();
                break;
        }
        return null;
    }

    private void setEditingSpell(int spellid)
    {
        List<Spell> spell = readSpell(spellid);
        int i = 0;
        foreach (Spell sp in spell)
        {
            spellName.text = sp.name;
            System.Predicate<Dropdown.OptionData> findFormMode = (Dropdown.OptionData a) => (a.text == sp.formMod);
            spellsEdit.GetComponentsInChildren<RectTransform>()[i].GetComponentsInChildren<Dropdown>()[0].value =
                (spellsEdit.GetComponentsInChildren<RectTransform>()[i].GetComponentsInChildren<Dropdown>()[0].options.FindIndex(findFormMode));
            System.Predicate<Dropdown.OptionData> findForm = (Dropdown.OptionData a) => (a.text == sp.form);
            spellsEdit.GetComponentsInChildren<RectTransform>()[i].GetComponentsInChildren<Dropdown>()[1].value =
                (spellsEdit.GetComponentsInChildren<RectTransform>()[i].GetComponentsInChildren<Dropdown>()[1].options.FindIndex(findForm));
            System.Predicate<Dropdown.OptionData> findEffect = (Dropdown.OptionData a) => (a.text == sp.effect);
            spellsEdit.GetComponentsInChildren<RectTransform>()[i].GetComponentsInChildren<Dropdown>()[2].value =
                (spellsEdit.GetComponentsInChildren<RectTransform>()[i].GetComponentsInChildren<Dropdown>()[2].options.FindIndex(findEffect));
            System.Predicate<Dropdown.OptionData> findObjectMode = (Dropdown.OptionData a) => (a.text == sp.objectMod);
            spellsEdit.GetComponentsInChildren<RectTransform>()[i].GetComponentsInChildren<Dropdown>()[3].value =
                (spellsEdit.GetComponentsInChildren<RectTransform>()[i].GetComponentsInChildren<Dropdown>()[3].options.FindIndex(findObjectMode));
            System.Predicate<Dropdown.OptionData> findObjectType = (Dropdown.OptionData a) => (a.text == sp.objectType);
            spellsEdit.GetComponentsInChildren<RectTransform>()[i].GetComponentsInChildren<Dropdown>()[4].value =
                (spellsEdit.GetComponentsInChildren<RectTransform>()[i].GetComponentsInChildren<Dropdown>()[4].options.FindIndex(findObjectType));
            System.Predicate<Dropdown.OptionData> findParamMode = (Dropdown.OptionData a) => (a.text == sp.paramMod);
            spellsEdit.GetComponentsInChildren<RectTransform>()[i].GetComponentsInChildren<Dropdown>()[5].value =
                (spellsEdit.GetComponentsInChildren<RectTransform>()[i].GetComponentsInChildren<Dropdown>()[5].options.FindIndex(findParamMode));
            System.Predicate<Dropdown.OptionData> findParam = (Dropdown.OptionData a) => (a.text == sp.param);
            spellsEdit.GetComponentsInChildren<RectTransform>()[i].GetComponentsInChildren<Dropdown>()[6].value =
                (spellsEdit.GetComponentsInChildren<RectTransform>()[i].GetComponentsInChildren<Dropdown>()[6].options.FindIndex(findParam));
            i++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        spellsCollection = new List<GameObject>();
        spells = new List<List<Spell>>();
        spellCount = int.Parse(PlayerPrefs.GetString("0", "0"));
        spellsEdit.gameObject.SetActive(false);
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
            spellsEdit.gameObject.SetActive(false);
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
                spellsEdit.gameObject.SetActive(true);
                write.gameObject.SetActive(true);
                read.gameObject.SetActive(true);
                spellName.gameObject.SetActive(true);
                spellList.gameObject.SetActive(false);
                write.GetComponentInChildren<Text>().text = "Write in spellbook";
                read.GetComponentInChildren<Text>().text = "Read your spellbook";
            }
            else
            {
                spellsEdit.gameObject.SetActive(false);
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
                if (spellName.text?.Length != 0 && spellsEdit.GetComponentsInChildren<RectTransform>()[0].GetComponentsInChildren<Dropdown>()[1].value != 0
                    && spellsEdit.GetComponentsInChildren<RectTransform>()[0].GetComponentsInChildren<Dropdown>()[2].value != 0)
                {
                    //New spell writing
                    GameObject spell = Instantiate(spellPrefab, spellList.content).gameObject;
                    spellsCollection.Add(spell);
                    spell.transform.localPosition = new Vector3(spell.transform.localPosition.x, spell.transform.localPosition.y + offset, spell.transform.localPosition.z);
                    offset -= 75;
                    spell.GetComponent<SpellSetter>().setSpell(spellName.text, buildFullSpell(getSpell()), 0, controller);
                    PlayerPrefs.SetString("0", (spellCount++).ToString());
                    writeSpell(getSpell(), spellCount - 1);
                }
            }
            else
            {
                //Old edited spell writing
                spellsCollection[spellId].GetComponent<SpellSetter>().setSpell(spellName.text, buildFullSpell(readSpell(spellId)), 0, controller);
                writeSpell(getSpell(), spellId);
            }

            spellsEdit.gameObject.SetActive(false);
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
            //spell from list choosing
            int i = 0;
            foreach(GameObject g in spellsCollection)
            {
                if (g.GetComponent<SpellSetter>().isActive)
                {
                    spellsEdit.gameObject.SetActive(true);
                    spellId = i;
                    setEditingSpell(spellId);
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
                }
                i++;
            }
        }
    }

    public void OnReadClick()
    {
        if (isRead)
        {
            spellsEdit.gameObject.SetActive(true);
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
            spellsEdit.gameObject.SetActive(false);
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
        readSpells();
        spellsCollection.Clear();
        offset = 0;
        for (int i = 0; i < spellCount; i++){
            GameObject spell = Instantiate(spellPrefab, spellList.content).gameObject;
            spellsCollection.Add(spell);
            spell.transform.localPosition = new Vector3(spell.transform.localPosition.x, spell.transform.localPosition.y + offset, spell.transform.localPosition.z);
            offset -= 75;
            spell.GetComponent<SpellSetter>().setSpell(spells[i][0].name, buildFullSpell(spells[i]), 0, controller);
        }
    }
}
