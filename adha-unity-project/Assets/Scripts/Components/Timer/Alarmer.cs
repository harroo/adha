
using UnityEngine;

public class Alarmer : MonoBehaviour {

    private float timer;

    private void Update () {

        if (timer < 0) {

            switch (Random.Range(0, 4)) {

                case 0:
                    FindObjectOfType<TalkManager>().SpeakSound("alarm-0", 2.0f);
                    timer = 2.0f + Random.Range(0.0f, 2.0f);
                    break;

                case 1:
                    FindObjectOfType<TalkManager>().SpeakSound("alarm-1", 3.0f);
                    timer = 3.0f + Random.Range(0.0f, 2.0f);
                    break;

                case 2:
                    FindObjectOfType<TalkManager>().SpeakSound("alarm-2", 15.0f);
                    timer = 15.0f + Random.Range(0.0f, 2.0f);
                    break;
            }

        } else timer -= Time.deltaTime;
    }

    public void Stop () {

        timer = 0;
    }
}
