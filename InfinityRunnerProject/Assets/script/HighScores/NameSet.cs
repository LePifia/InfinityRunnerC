using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameSet : MonoBehaviour
{

    public static NameSet Instance { get; private set; }
    private string NameDisplay;
    private string NameSetted;
    [SerializeField] GameObject inputField;
    [SerializeField]TextMeshProUGUI textMeshProUGUI;

    private void Awake()
    {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;

            
        
        NameSetted = PlayerPrefs.GetString("NameRank");
        NameReplacer();
    }
    public void NameSetter()
    {

        NameDisplay = inputField.GetComponent<TextMeshProUGUI>().text;

        PlayerPrefs.SetString("NameRank", NameDisplay);
    }

    public void NameReplacer()
    {
        if (textMeshProUGUI != null)
        {
            textMeshProUGUI.text = PlayerPrefs.GetString("NameRank");
        }
        
    }

    public string Name()
    {
        return NameSetted;
    }
}
