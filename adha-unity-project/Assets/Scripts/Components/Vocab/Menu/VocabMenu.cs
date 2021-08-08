
using UnityEngine;
using UnityEngine.UI;

public class VocabMenu : MonoBehaviour {

    public static VocabMenu instance;
    private void Awake () { instance = this; }

    public InputField field;
    public void DefineField () { Define(field.text); }
    public void SynonymiseField () { Synonymise(field.text); }

    private bool defining, synonymising;

    public GameObject definitionLoadOverlay;
    private string defienWordCache;
    public void Define (string word) {

        if (defining) return;
        defining = true;

        defienWordCache = word;

        defineTitle.text = "Definition for '" + word + "':";
        defineText.text = "";
        definitionLoadOverlay.SetActive(true);

        Orthoget.Dictionary.GetWordDefinition(word, OnDefineLink);
    }
    public GameObject synonymiseLoadOverlay;
    private string synonymiseWordCache;
    public void Synonymise (string word) {

        if (synonymising) return;
        synonymising = true;

        synonymiseTitle.text = "Synonyms for '" + word + "':";
        synonymiseWordCache = word;
        synonymiseLoadOverlay.SetActive(true);

        foreach (Transform child in synonymiseParent)
            if (child != synonymiseSlotPrefab.transform)
                Destroy(child.gameObject);

        Orthoget.Thesaurus.GetSimilarWords(word, OnSynonymiseLink);
    }

    public Text defineText, defineTitle;
    public void OnDefine (string word, string definition) {

        defining = false;
        definitionLoadOverlay.SetActive(false);

        if (word == "null") {

            defineTitle.text = "Couldn't find a definition for '" + defienWordCache + "'...";

            return;
        }

        defineText.text = definition;
    }
    public Text synonymiseTitle;
    public GameObject synonymiseSlotPrefab;
    public Transform synonymiseParent;
    public void OnSynonymise (string[] words) {

        synonymising = false;
        synonymiseLoadOverlay.SetActive(false);

        synonymiseSlotPrefab.SetActive(true);

        foreach (Transform child in synonymiseParent)
            if (child != synonymiseSlotPrefab.transform)
                Destroy(child.gameObject);

        if (words[0] == "null") {

            synonymiseTitle.text = "Couldn't find any synonyms for '" + synonymiseWordCache + "'...";

            synonymiseSlotPrefab.SetActive(false);

            return;
        }

        int cap = 0;
        foreach (var word in words) {

            cap++; if (cap == 13) break;

            ThesaurusSlot tslot = Instantiate(synonymiseSlotPrefab, Vector3.zero, Quaternion.identity)
                .GetComponent<ThesaurusSlot>();

            tslot.transform.SetParent(synonymiseParent);
            tslot.transform.localScale = new Vector3(1,1,1);

            tslot.value = word;
        }

        synonymiseSlotPrefab.SetActive(false);
    }
    private bool synonymiseDone; private string[] synonymiseGot;
    public void OnSynonymiseLink (string[] words) {
        synonymiseDone = true;
        synonymiseGot = words;
    }
    private bool defineDone; private string defineGot1, defineGot2;
    public void OnDefineLink (string a, string b) {
        defineDone = true;
        defineGot1 = a; defineGot2 = b;
    }
    private void Update () {

        if (synonymiseDone) { synonymiseDone = false; OnSynonymise(synonymiseGot); }
        if (defineDone) { defineDone = false; OnDefine(defineGot1, defineGot2); }
    }
}
