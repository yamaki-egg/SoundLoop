namespace SoundLoop.Controller.NAudio
{
    internal interface IUserPlaybackable:IReadable,IPauseable
    {
        public void AdjustVolume(float volume);
        public void Play();
    }
}
