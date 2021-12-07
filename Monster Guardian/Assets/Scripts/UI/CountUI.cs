using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class CountUI : MonoBehaviour
    {
        [SerializeField] TMP_Text Text;
        [SerializeField] Player mainplayer;

        public void Update()
        {
            Text.text = $@"{ mainplayer.selectedUnits.Count }";
        }
    }
}
