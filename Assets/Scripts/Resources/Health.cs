using System;
using RPG.Core;
using RPG.Saving;
using RPG.Stats;
using UnityEngine;

namespace RPG.Resources
{
    public class Health : MonoBehaviour, ISaveable
    {
        [SerializeField] float HP = 100f;
        bool isDead = false;

        private void Start() {
            HP = GetComponent<BasicStats>().GetStat(stats.Health);
        }

        public bool IsDead()
        {
            return isDead;
        }
        public void Damage(GameObject instigator,float dmg)
        {
            HP = Mathf.Max(HP - dmg, 0);
            if (HP == 0)
            {
                Death();
                AwardXP(instigator);
            }
        }

        private void Death()
        {
            if (isDead) return;
            isDead = true;
            GetComponent<Animator>().SetTrigger("Die");
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }

        private void AwardXP(GameObject instigator)
        {
            Experience xP = instigator.GetComponent<Experience>();
            if(xP == null)  return;
            xP.GainEXP(GetComponent<BasicStats>().GetStat(stats.XP));
        }

        public float GetHPpercent()
        {
            return (HP / GetComponent<BasicStats>().GetStat(stats.Health)) * 100; 
        }

        public object CaptureState()
        {
            return HP;
        }

        public void RestoreState(object state)
        {
            HP = (float)state;
            if (HP == 0)
            {
                Death();
            }
        }
    }
}