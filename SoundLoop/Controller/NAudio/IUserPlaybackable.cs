namespace SoundLoop.Controller.NAudio
{
    internal interface IUserPlaybackable:IReadable,IPauseable,IStopable
    {
        public void AdjustVolume(float volume);
        public void Play();
    }
}
