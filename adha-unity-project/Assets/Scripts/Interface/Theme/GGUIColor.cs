
using UnityEngine;
using UnityEngine.UI;

public class GGUIColor : MonoBehaviour {

    [HideInInspector]public Image image;

    private void Start () {

        image = GetComponent<Image>();

        GGUIColorManager.instance.images.Add(this);
    }
    private void OnDestroy () {

        GGUIColorManager.instance.images.Remove(this);
    }
}
