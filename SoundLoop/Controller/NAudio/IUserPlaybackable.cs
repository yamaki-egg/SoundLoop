namespace SoundLoop.Controller.NAudio
{
    internal interface IUserPlaybackable:IReadable,IPauseable,IStopable
    {
        void AdjustVolume(float volume);
        Task Play();
    }
}
