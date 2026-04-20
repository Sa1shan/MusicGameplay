using _Source.Controller;
using _Source.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.UI
{
    public class FightUI : MonoBehaviour
    {
        [SerializeField] private PlayerController player;
        [SerializeField] private EnemyController enemy;
        [SerializeField] private MusicManager musicManager;
        [SerializeField] private TextMeshProUGUI playerHpText;
        [SerializeField] private TextMeshProUGUI enemyHpText;
        [SerializeField] private Image indicator;
        [SerializeField] private GameObject gameOverPannel;
        [SerializeField] private TextMeshProUGUI winnerText;
        [SerializeField] private Slider volumeSlider;

        void Update()
        {
            musicManager.volume = volumeSlider.value;
            playerHpText.text = $"Player HP: {player.hp}";
            enemyHpText.text = $"Enemy HP: {enemy.hp}";
            if (musicManager.gameObject.activeInHierarchy)
            {
                Color c = indicator.color;
                c.a = musicManager.IsOnBeat() ? 1f : 0.2f;
                indicator.color = c;
            }
            if (player.hp <= 0 && !gameOverPannel.activeSelf)
            {
                ShowGameOver("Enemy Wins!");
            }
            else if (enemy.hp <= 0 && !gameOverPannel.activeSelf)
            {
                ShowGameOver("Player Wins!");
            }
        }
        public void ShowGameOver(string message)
        {
            gameOverPannel.SetActive(true);
            winnerText.text = message;
            Time.timeScale = 0f;
        }
    }
}