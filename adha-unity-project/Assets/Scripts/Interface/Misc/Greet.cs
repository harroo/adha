
using UnityEngine;

public class Greet : MonoBehaviour {

    private static bool set;

    private void Start () {

        if (set) return; set = true;

        switch (Random.Range(0, 3)) {

            case 0: FindObjectOfType<TalkManager>().SpeakSound("greet-0", 1.0f); break;
            case 1: FindObjectOfType<TalkManager>().SpeakSound("greet-1", 4.0f); break;
        }
    }
}
