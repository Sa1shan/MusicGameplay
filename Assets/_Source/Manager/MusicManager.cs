using System;
using _Source.UI;
using UnityEngine;

namespace _Source.Manager
{
    public class MusicManager : MonoBehaviour
    {
        public static MusicManager Instance;
        [SerializeField] private float bpm = 120f;
        [SerializeField] private float limit = 0.15f;
        [SerializeField] private AudioSource musicSource;
        public float volume;
        
        private double _startTime;
        public float Beat => 60f / bpm;

        void Awake()
        {
            Instance = this;
        }
        
        public void StartMusic()
        {
            _startTime = AudioSettings.dspTime + 1.0;
            musicSource.PlayScheduled(_startTime);
        }

        private void Start()
        {
            StartMusic();
        }

        void Update()
        {
            musicSource.volume = volume;
        }
        
        public double GetCAudioTime()
        {
            return AudioSettings.dspTime - _startTime;
        }

        public float GetBeat() 
        {
            return (float)(GetCAudioTime() / Beat);
        }
        
        public bool IsOnBeat()
        {
            float beat = GetBeat();
            float nearestBeat = Mathf.Round(beat);
            float distanceInSeconds = Mathf.Abs(beat - nearestBeat) * Beat;
            return distanceInSeconds <= limit;
        }
    }
}