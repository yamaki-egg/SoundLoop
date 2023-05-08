namespace SoundLoop.Controller.NAudio
{
    internal interface IPauseable
    {
        void Pause();
        Task Resume();
    }
}
