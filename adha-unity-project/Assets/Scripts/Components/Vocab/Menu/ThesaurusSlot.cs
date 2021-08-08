
using UnityEngine;
using UnityEngine.UI;

public class ThesaurusSlot : MonoBehaviour {

    public string value {

        get { return text.text; }
        set { text.text = value; }
    }

    public Text text;

    public void CopyToClipboardButton_OnClick () {

        GUIUtility.systemCopyBuffer = value;
    }

    public void DefineButton_OnClick () {

        VocabMenu.instance.Define(value);
    }
}
