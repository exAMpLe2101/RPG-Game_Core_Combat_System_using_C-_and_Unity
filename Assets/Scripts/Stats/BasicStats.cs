using UnityEngine;

/*
    This script deals with all the basic characterics
    of some preset characters, similar to Dark Souls and Bloodborne
    from FromSoftware games.

    Here, we assign some basic stats for the players like level, strength,
    immunity, HP, etc.
*/

namespace RPG.Stats
{

    public class BasicStats : MonoBehaviour
    {
        [Range(1, 10)] 
        [SerializeField] int Level = 7;
        [SerializeField] CharacterClass Class;
        [SerializeField] Progression progression = null;


        private void Update() {
            if(gameObject.tag=="Player")
                print(getLevel());
        }

        public float GetStat(stats stat)
        {
            return progression.GetStat(Class, Level,stat);
        }

        public int getLevel()
        {
            float currentXP = GetComponent<Experience>().GetXP();
            int PenultimateLevel = progression.getLevels(stats.XPToLevelUp, Class);
            for (int levels = 1; levels <= PenultimateLevel; levels++)           
            {
                float XPToLevel = progression.GetStat(Class, levels, stats.XPToLevelUp);
                if(currentXP > XPToLevel)   return levels;
            }
            return PenultimateLevel + 1; 
        }
    }
}