using _Source.Manager;
using UnityEngine;

namespace _Source.Controller
{
    public class PlayerController : Fight
    {
        [SerializeField] private EnemyController enemy;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                float damage = MusicManager.Instance.IsOnBeat() ? 20f : 10f;
                enemy.TakeDamage(damage);
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                isShieldActive = !isShieldActive;
            }
        }
        public override void Die()
        {
            MusicManager.Instance.gameObject.SetActive(false);
            enabled = false;
        }
    }
}