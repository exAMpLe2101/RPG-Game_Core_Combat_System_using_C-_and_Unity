using UnityEngine;
using RPG.Saving;

namespace RPG.Stats
{

    public class Experience : MonoBehaviour, ISaveable
    {
        [SerializeField] float EXP = 0;

        public object CaptureState()
        {
            return EXP;
        }

        public float GetXP()
        {
            return EXP;
        }

        public void GainEXP(float xP)
        {
            EXP+=xP;
        }

        public void RestoreState(object state)
        {
            EXP = (float)state;
        }
    }
}