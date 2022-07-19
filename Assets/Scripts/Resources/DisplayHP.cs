using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    As name suggests, the script is repsonsible for 
    showing the health points of the player corresponding 
    to the designated and changing health points.
*/

namespace RPG.Resources
{   
    public class DisplayHP : MonoBehaviour
    {
        Health health;

        private void Awake() {
            health = GameObject.FindWithTag("Player").GetComponent<Health>();
        }
        private void Update() {
            GetComponent<Text>().text = string.Format("{0:0.0}%",health.GetHPpercent());
        }
    }
}
