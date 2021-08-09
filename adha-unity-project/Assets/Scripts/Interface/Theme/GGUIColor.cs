
using UnityEngine;
using UnityEngine.UI;

public class GGUIColor : MonoBehaviour {

    [HideInInspector]public Image image;

    private void Start () {

        image = GetComponent<Image>();

        GGUIColorManager.instance.images.Add(this);

        image.color = new Color(
            (float)Settings.Get("UI_COLOR_R", 149.0f) / 255.0f,
            (float)Settings.Get("UI_COLOR_G", 138.0f) / 255.0f,
            (float)Settings.Get("UI_COLOR_B", 173.0f) / 255.0f
        );
    }
    private void OnDestroy () {

        GGUIColorManager.instance.images.Remove(this);
    }
}
