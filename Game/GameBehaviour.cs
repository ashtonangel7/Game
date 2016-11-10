namespace Game
{
    using Common.DataFlows.Game;

    public class GameBehaviour
    {
        private readonly NumbersGameDataFlow _numbersGameDataFlow;

        public GameBehaviour()
        {
            _numbersGameDataFlow = new NumbersGameDataFlow(Settings.Default.GameUri);
        }

        public void PlayGame()
        {
            
        }
       
    }
}
