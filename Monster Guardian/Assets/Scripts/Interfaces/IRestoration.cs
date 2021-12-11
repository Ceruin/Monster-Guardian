namespace Assets.Scripts
{
    /// <summary>
    /// Restoration interface.
    /// </summary>
    public interface IRestoration
    {
        public void Save();

        public void Load();
    }
}