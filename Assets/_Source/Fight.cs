using UnityEngine;

namespace _Source
{
    public abstract class Fight : MonoBehaviour
    {
        public float hp = 100f;
        public bool isShieldActive;

        public void TakeDamage(float amount)
        {
            if (isShieldActive)
            {
                amount *= 0.1f;
            }
            hp -= amount;
            if (hp <= 0) Die();
        }
        public abstract void Die();
    }
}