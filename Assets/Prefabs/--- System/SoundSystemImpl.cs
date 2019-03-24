using UnityEngine;

namespace DefaultNamespace
{
    public class SoundSystemImpl : MonoBehaviour, SoundSystem
    {
#pragma warning disable 649
        public float BaseVolume = 0.1f;
        public float ActualVolume = 0.1f;
        [SerializeField] private AudioSource audioSource;
#pragma warning restore 649

        public void Start()
        {
            audioSource.volume = BaseVolume;
        }

        public void SetBaseVolume(float newVolume)
        {
            BaseVolume = newVolume;
        }

        public void SetVolume(float newVolume)
        {
            GetComponent<AudioSource>().volume = newVolume;
        }

        public void PlayOnce(AudioClip clip)
        {
            if (!clip) return;

            audioSource.clip = clip;
            audioSource.PlayOneShot(clip);
        }

        public float getActualVolume()
        {
            return this.ActualVolume;
        }

        public float getBaseVolume()
        {
            return this.BaseVolume;
        }

        public void SetActualVolume(float newVolume)
        {
            ActualVolume = newVolume;
            audioSource.volume = newVolume;
        }
    }
}