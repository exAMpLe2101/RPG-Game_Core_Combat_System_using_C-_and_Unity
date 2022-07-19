using RPG.Resources;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Combat
{
    public class EnemyHP : MonoBehaviour
    {
        PlayerCombat fighter;

        private void Awake() {
            fighter = GameObject.FindWithTag("Player").GetComponent<PlayerCombat>();
        }

        private void Update() 
        {
            if(fighter.GetTarget() == null)
            {
                GetComponent<Text>().text = "N/A";
                return;
            }
            Health enemy = fighter.GetTarget();
            GetComponent<Text>().text = string.Format("{0:0.0}%", enemy.GetHPpercent());
        }
        
    }
}