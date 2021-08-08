
using UnityEngine;
using UnityEngine.UI;

using System.Collections.Generic;

public class TextColorManager : MonoBehaviour {

    public static TextColorManager instance;
    private void Awake () { instance = this; }

    public float updateRate = 0.82f;

    private float timer;

    public List<TextColor> texts = new List<TextColor>();

    private Color neededColor {

        get {

            return new Color(
                (float)Settings.Get("TEXT_COLOR_R", 149.0f) / 255.0f,
                (float)Settings.Get("TEXT_COLOR_G", 138.0f) / 255.0f,
                (float)Settings.Get("TEXT_COLOR_B", 173.0f) / 255.0f
            );
        }

        set { }
    }

    private Color cache;
    private bool gsaCache;

    private void Update () {

        if (timer < 0) { timer = updateRate;

            if (cache != neededColor) {

                cache = neededColor;

                foreach (var text in texts) {

                    text.text.color = cache;
                }
            }

            if (gsaCache != (bool)Settings.Get("USE_GSA", false)) {

                gsaCache = (bool)Settings.Get("USE_GSA", false);

                foreach (var text in texts) {

                    if (gsaCache) text.SetGSA(); else text.SetEN();
                }
            }

        } else timer -= Time.deltaTime;
    }
}
