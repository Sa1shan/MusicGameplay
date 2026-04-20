using _Source.Manager;
using UnityEngine;

namespace _Source.Controller
{
    public class EnemyController : Fight
    {
        [SerializeField] private PlayerController player;
        [SerializeField] private  float attackDamage = 10f;

        public void Shoot()
        {
            player.TakeDamage(attackDamage);
        }

        public void SetShield(bool active)
        {
            isShieldActive = active;
        }

        public override void Die()
        {
            MusicManager.Instance.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}