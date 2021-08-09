
using UnityEngine;
using UnityEngine.UI;

using System.Collections.Generic;

public class GGUIColorManager : MonoBehaviour {

    public static GGUIColorManager instance;
    private void Awake () { instance = this; }

    public float updateRate = 0.82f;

    private float timer;

    public List<GGUIColor> images = new List<GGUIColor>();

    private Color neededColor {

        get {

            return new Color(
                (float)Settings.Get("UI_COLOR_R", 149.0f) / 255.0f,
                (float)Settings.Get("UI_COLOR_G", 138.0f) / 255.0f,
                (float)Settings.Get("UI_COLOR_B", 173.0f) / 255.0f
            );
        }

        set { }
    }

    private Color cache;

    private void Update () {

        if (timer < 0) { timer = updateRate;

            if (cache != neededColor) {

                cache = neededColor;

                foreach (var image in images) {

                    image.image.color = cache;
                }
            }

        } else timer -= Time.deltaTime;
    }
}
