namespace SoundLoop.Controller.Factory
{
    interface IFactory<T> where T : class
    {
        abstract static T Create(string filePath);
    }
}
