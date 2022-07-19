using System;
using System.Collections.Generic;
using RPG.Stats;
using UnityEngine;

[CreateAssetMenu(fileName = "Progression", menuName = "Stats/Progression", order = 0)]
public class Progression : ScriptableObject 
{
    [SerializeField] ProgressionCharacterClass[] characterClasses = null;
    Dictionary<CharacterClass, Dictionary<stats, float[]>> LookUpTable = null;

    public float GetStat(CharacterClass Class, int Level,stats stat)
    {
        foreach(ProgressionCharacterClass progressionCharacterClass in characterClasses)
        {
            if(progressionCharacterClass.characterClass != Class)   continue;

            foreach(ProgressionStat progressionStat in progressionCharacterClass.stats)
            {
                if(progressionStat.stat != stat) continue;
                if(progressionStat.Levels.Length < Level)  continue;
                return progressionStat.Levels[Level-1];
            }
        }
        return 0;

    }

    public int getLevels(stats stat, CharacterClass klass)
    {
        LookUpTable = new Dictionary<CharacterClass, Dictionary<stats, float[]>>();

        foreach (ProgressionCharacterClass progressionCharacterClass in characterClasses)
        {
            var StatLookup = new Dictionary<stats, float[]>();

            // Populating the stats' Look-Up Table
            foreach (ProgressionStat progressionStat in progressionCharacterClass.stats)
            {
                StatLookup[progressionStat.stat] = progressionStat.Levels;
            }

            LookUpTable[progressionCharacterClass.characterClass] = StatLookup;
        }

        float[] levels = LookUpTable[klass][stat];
        return levels.Length;
    }


    [System.Serializable]

    class ProgressionCharacterClass
    {
        public CharacterClass characterClass;
        public ProgressionStat[] stats;
    }

    [System.Serializable]
    class ProgressionStat
    {
        public stats stat;
        public float[] Levels;
    }
}