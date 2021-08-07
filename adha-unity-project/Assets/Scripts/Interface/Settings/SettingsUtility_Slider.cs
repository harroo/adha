
using UnityEngine;
using UnityEngine.UI;

public class SettingsUtility_Slider : MonoBehaviour {

    public string valueName;
    public float defaultValue;

    private Slider slider;

    private void Start () {

        slider = GetComponent<Slider>();

        slider.value = (float)Settings.Get(valueName, defaultValue);
    }

    public void OnChange () {

        Settings.Set(valueName, slider.value);
    }
}
