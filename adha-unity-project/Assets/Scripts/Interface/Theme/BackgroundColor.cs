
using UnityEngine;
using UnityEngine.UI;

public class BackgroundColor : MonoBehaviour {

    public float updateRate = 0.82f;

    private float timer;

    private Camera _camera;

    private void Start () {

        _camera = Camera.main;
    }

    private Color neededColor {

        get {

            return new Color(
                (float)Settings.Get("BACK_COLOR_R", 61.0f) / 255.0f,
                (float)Settings.Get("BACK_COLOR_G", 65.0f) / 255.0f,
                (float)Settings.Get("BACK_COLOR_B", 70.0f) / 255.0f
            );
        }

        set { }
    }

    private void Update () {

        if (timer < 0) { timer = updateRate;

            if (_camera.backgroundColor != neededColor)
                _camera.backgroundColor = neededColor;

        } else timer -= Time.deltaTime;
    }
}
