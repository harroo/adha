
using UnityEngine;
using UnityEngine.UI;

public class DisplayAnimation : MonoBehaviour {

    public EmotionSet idle, sad, happy, flushed, angry, tired, sleep;

    private static EmotionSet currentSet;

    private Image display;

    private void Start () {

        display = GetComponent<Image>();

        if (currentSet == null) currentSet = idle;
        display.sprite = currentSet.idle;
    }

    private float blinkTimer;
    private float resetTimer;

    private float backToIdleTimer;

    private void Update () {

        blinkTimer -= Time.deltaTime;
        if (blinkTimer < 0) {

            blinkTimer = Random.Range(0, 16);

            Blink();
        }

        if (resetTimer < 0) {

            if (display.sprite != currentSet.idle)
                display.sprite = currentSet.idle;

        } else resetTimer -= Time.deltaTime;

        if (backToIdleTimer < 0) {

            if (currentSet != idle)
                currentSet = idle;

        } else backToIdleTimer -= Time.deltaTime;
    }

    public void Talk () {

        if (display.sprite == currentSet.talk) return;

        display.sprite = currentSet.talk;

        resetTimer = 0.1f;
    }

    public void Blink () {

        if (display.sprite == currentSet.blink) return;

        display.sprite = currentSet.blink;

        resetTimer = 0.4f;
    }

    public void ChangeMood (CharacterMood mood, float time) {

        EmotionSet cache = currentSet;

        switch (mood) {
            case CharacterMood.idle: currentSet = idle; break;
            case CharacterMood.sad: currentSet = sad; break;
            case CharacterMood.happy: currentSet = happy; break;
            case CharacterMood.flushed: currentSet = flushed; break;
            case CharacterMood.angry: currentSet = angry; break;
            case CharacterMood.tired: currentSet = tired; break;
            case CharacterMood.sleep: currentSet = sleep; break;
        }

        backToIdleTimer = time;

            if (display.sprite == cache.idle) display.sprite = currentSet.idle;
            if (display.sprite == cache.blink) display.sprite = currentSet.blink;
            if (display.sprite == cache.talk) display.sprite = currentSet.talk;
    }
}

public enum CharacterMood {

    idle, sad, happy, flushed, angry, tired, sleep
}

[System.Serializable]
public class EmotionSet {

    public Sprite idle, blink, talk;
}
