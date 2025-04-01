using UnityEngine;
using UnityEngine.InputSystem;

public class RebindSave : MonoBehaviour
{
    public InputActionAsset actions;

    private const string RebindKey = "rebinds";

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey(RebindKey))
        {
            string rebinds = PlayerPrefs.GetString(RebindKey);
            if (!string.IsNullOrEmpty(rebinds))
            {
                actions.LoadBindingOverridesFromJson(rebinds);
            }
        }
    }

    private void OnDisable()
    {
        string rebinds = actions.SaveBindingOverridesAsJson();
        PlayerPrefs.SetString(RebindKey, rebinds);
        PlayerPrefs.Save(); 
    }
}
