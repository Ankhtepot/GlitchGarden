namespace DefaultNamespace
{
    public interface SoundSystem
    {
        void SetBaseVolume(float newVolume);
        void SetActualVolume(float newVolume);
        void SetVolume(float newVolume);
        float getActualVolume();
    }
}