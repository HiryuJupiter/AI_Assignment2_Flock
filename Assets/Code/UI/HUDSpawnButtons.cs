using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace FlockPrototype
{
    public class HUDSpawnButtons : MonoBehaviour
    {
        //Variables
        [Header("Button Highlight Borders")]
        [SerializeField] Image buttonBorder_TinyFish;
        [SerializeField] Image buttonBorder_SmallFish;
        [SerializeField] Image buttonBorder_MediumFish;
        [SerializeField] Image buttonBorder_BigFish;

        Dictionary<SpawningMode, Image> borderLookup;
        SpawningMode currentMode = SpawningMode.None;

        void Awake()
        {
            //Create a lookup table so we can look up UI image using enums
            borderLookup = new Dictionary<SpawningMode, Image>
        {
            { SpawningMode.TinyFish, buttonBorder_TinyFish },
            { SpawningMode.SmallFish, buttonBorder_SmallFish },
            { SpawningMode.MediumFish, buttonBorder_MediumFish },
            { SpawningMode.BigFish, buttonBorder_BigFish },
        };
        }

        #region Public
        public void RevealButtonBorder(SpawningMode newMode)
        {
            //Hide the currently active border then reveal the new highlight border
            HideCurrentBorder();

            borderLookup[newMode].enabled = true;
            currentMode = newMode;
        }

        public void HideButtonBorder()
        {
            //Hide border then set the current mode to none
            HideCurrentBorder();
            currentMode = SpawningMode.None;
        }
        #endregion

        void HideCurrentBorder()
        {
            //If we're currently in a spawning state, then a border is active and we will now deactivate it. 
            if (currentMode != SpawningMode.None)
            {
                borderLookup[currentMode].enabled = false;
            }
        }
    }
}