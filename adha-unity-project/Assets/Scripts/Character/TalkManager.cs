
using UnityEngine;

using System.Collections.Generic;

public class TalkManager : MonoBehaviour {

    private float timer, countDown;
    private bool talking;

    private List<SpeakNode> queue = new List<SpeakNode>();

    private void Update () {

        if (!talking) {

            if (queue.Count != 0)
                DequeueSpeakNode();

            return;
        }

        if (timer < 0) { timer = Random.Range(0, 2) == 0 ? 0.2f : 0.3f;

            FindObjectOfType<DisplayAnimation>().Talk();

        } else timer -= Time.deltaTime;

        if (countDown < 0) {

            talking = false;

        } else countDown -= Time.deltaTime;
    }

    private void DequeueSpeakNode () {

        talking = true;

        SpeakNode node = queue[0]; queue.RemoveAt(0);

        AudioManager.PlayVoice(node.sound);
        countDown = node.time;
    }

    public void SpeakSound (string _sound, float _time) {

        SpeakNode node = new SpeakNode {

            sound = _sound, time = _time
        };

        queue.Add(node);
    }

    public void Stop () {

        // FindObjectOfType<DisplayAnimation>().StopTalk();
        AudioManager.StopVoice();

        countDown = 0.0f;
        timer = 0.0f;
    }
}

public class SpeakNode {

    public string sound;
    public string words;
    public float time;
}
