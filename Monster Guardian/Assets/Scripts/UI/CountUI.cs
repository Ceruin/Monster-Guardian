using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// This is a counting class to display the selected unit count to the UI.
    /// </summary>
    public class CountUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text Text;
        [SerializeField] private Player mainplayer;

        public void Update()
        {
            Text.text = $@"{ mainplayer.selectedUnits.Count }";
        }
    }
}