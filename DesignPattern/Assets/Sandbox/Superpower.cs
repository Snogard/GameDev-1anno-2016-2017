using UnityEngine;

namespace SanboxPattern
{
    public abstract class Superpower
    {
        public abstract void Activate();


        protected void Move(float speed)
        {
            Debug.Log("moving " + speed);
        }

        protected void PlaySound(string coolSound)
        {
            Debug.Log("sound " + coolSound);
        }

        protected void SpawnParticles()
        {
            Debug.Log("particle");
        }
    }

   
}