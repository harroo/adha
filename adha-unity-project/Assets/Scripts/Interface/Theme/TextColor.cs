
using UnityEngine;
using UnityEngine.UI;

public class TextColor : MonoBehaviour {

    private Font en;
    public Font gsa;
    [HideInInspector]public Text text;

    public void SetGSA () {

        text.font = gsa;
    }
    public void SetEN () {

        text.font = en;
    }

    private void Start () {

        text = GetComponent<Text>();
        en = text.font;

        TextColorManager.instance.texts.Add(this);
    }
    private void OnDestroy () {

        TextColorManager.instance.texts.Remove(this);
    }
}
