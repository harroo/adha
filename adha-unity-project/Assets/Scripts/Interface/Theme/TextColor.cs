
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

        text.color = new Color(
            (float)Settings.Get("TEXT_COLOR_R", 149.0f) / 255.0f,
            (float)Settings.Get("TEXT_COLOR_G", 138.0f) / 255.0f,
            (float)Settings.Get("TEXT_COLOR_B", 173.0f) / 255.0f
        );

        if ((bool)Settings.Get("USE_GSA", false)) SetGSA(); else SetEN();
    }
    private void OnDestroy () {

        TextColorManager.instance.texts.Remove(this);
    }
}
