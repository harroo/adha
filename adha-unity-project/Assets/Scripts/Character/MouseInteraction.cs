
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInteraction : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler {

    public void OnPointerEnter (PointerEventData eventData) {

        FindObjectOfType<DisplayAnimation>().ChangeMood(CharacterMood.flushed, Random.Range(1, 32));
    }

    public void OnPointerClick (PointerEventData eventData) {

        FindObjectOfType<DisplayAnimation>().ChangeMood(CharacterMood.angry, Random.Range(1, 32));
    }

    public float idleTimer, sleepTimer;

    private bool focusToggle;

    private void Update () {

        if (!Application.isFocused) {

            if (idleTimer < 0 && idleTimer > -69) {

                FindObjectOfType<DisplayAnimation>().ChangeMood(CharacterMood.tired, Random.Range(8192, 16384));
                idleTimer = -420;

            } else idleTimer -= Time.deltaTime;

            if (sleepTimer < 0 && sleepTimer > -69) {

                FindObjectOfType<DisplayAnimation>().ChangeMood(CharacterMood.sleep, Random.Range(8192, 16384));
                sleepTimer = -420;

            } else sleepTimer -= Time.deltaTime;

            focusToggle = false;

        } else {

            if (!focusToggle) {

                if (idleTimer < 0)
                    FindObjectOfType<DisplayAnimation>().ChangeMood(CharacterMood.tired, Random.Range(4, 32));

                idleTimer = Random.Range(10, 20);

                sleepTimer = Random.Range(20, 30);
            }

            focusToggle = true;
        }
    }
}
