using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HUDSpawnButtons : MonoBehaviour
{
    [Header("Button Highlight Borders")]
    [SerializeField] Image buttonBorder_TinyFish;
    [SerializeField] Image buttonBorder_SmallFish;
    [SerializeField] Image buttonBorder_MediumFish;
    [SerializeField] Image buttonBorder_BigFish;

    Dictionary<SpawningMode, Image> borderLookup;
    SpawningMode currentMode = SpawningMode.None;

    void Awake()
    {
        borderLookup = new Dictionary<SpawningMode, Image>
        {
            { SpawningMode.TinyFish, buttonBorder_TinyFish },
            { SpawningMode.SmallFish, buttonBorder_SmallFish },
            { SpawningMode.MediumFish, buttonBorder_MediumFish },
            { SpawningMode.BigFish, buttonBorder_BigFish },
        };
    }

    public void RevealButtonBorder(SpawningMode newMode)
    {
        HideCurrentBorder();

        //Activate the new highlight box
        borderLookup[newMode].enabled = true;
        currentMode = newMode;
    }

    public void HideButtonBorder ()
    {
        HideCurrentBorder();
        currentMode = SpawningMode.None;
    }

    void HideCurrentBorder ()
    {
        if (currentMode != SpawningMode.None)
        {
            borderLookup[currentMode].enabled = false;
        }
    }

    class ButtonLookup
    {
        public SpawningMode Mode;
        public Image UiImage;
        public string DescriptionText;

        public ButtonLookup(SpawningMode mode, Image image, string descriptionText)
        {
            Mode = mode;
            UiImage = image;
            DescriptionText = descriptionText;
        }
    }
}