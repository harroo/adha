
using UnityEngine;
using UnityEngine.UI;

public class TextAnimation : MonoBehaviour {

    public string[] frames;
    public float playDelay;

    private Text text;
    private void Start () {

        text = GetComponent<Text>();
    }

    private float timer;
    private int index;
    private void Update () {

        if (timer < 0) { timer = playDelay;

            index++;
            index = index >= frames.Length ? 0 : index;

            text.text = frames[index];

        } else timer -= Time.deltaTime;
    }
}
