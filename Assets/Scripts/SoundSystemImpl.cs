using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundSystemImpl : MonoBehaviour, SoundSystem
    {
        public float BaseVolume = 0.1f;
        [SerializeField] private AudioSource AS;

        public void Start()
        {
            AS = GetComponent<AudioSource>();
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
            AS.clip = clip;
            AS.PlayOneShot(clip);
        }
    }
}