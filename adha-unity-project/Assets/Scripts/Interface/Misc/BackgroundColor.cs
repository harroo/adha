
using UnityEngine;
using UnityEngine.UI;

public class BackgroundColor : MonoBehaviour {

    private float timer;

    private Camera camera;

    private void Start () {

        camera = Camera.main;
    }

    private Color neededColor {

        get {

            return new Color(
                (float)Settings.Get("BACK_COLOR_R", 64) / 255.0f,
                (float)Settings.Get("BACK_COLOR_G", 64) / 255.0f,
                (float)Settings.Get("BACK_COLOR_B", 64) / 255.0f
            );
        }

        set { }
    }

    private void Update () {

        if (timer < 0) { timer = 0.82f;

            if (camera.backgroundColor != neededColor)
                camera.backgroundColor = neededColor;

        } else timer -= Time.deltaTime;
    }
}
