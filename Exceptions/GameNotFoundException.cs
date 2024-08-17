namespace Steam_Game_Page_Parser.Exceptions
{
    public class GameNotFoundException : Exception
    {
        public GameNotFoundException() : base("Game not found in search results list") { }
        public GameNotFoundException(string message) : base(message) { }
    }
}
