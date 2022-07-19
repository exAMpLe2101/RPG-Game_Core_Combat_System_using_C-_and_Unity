using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    As name suggests, the script is repsonsible for 
    showing the XP points of the player corresponding 
    to the designated and changing XP points.
*/

namespace RPG.Stats
{   
    public class DisplayLevel : MonoBehaviour
    {
        BasicStats basicStats;

        private void Awake() {
            basicStats = GameObject.FindWithTag("Player").GetComponent<BasicStats>();
        }
        private void Update() {
            GetComponent<Text>().text = string.Format("{0:0}",basicStats.getLevel());
        }
    }
}
