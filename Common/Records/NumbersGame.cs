namespace Common.Records
{
    using System;
    using System.Collections.Generic;
    public class NumbersGame
    {
        private List<int> _childrenInGame = new List<int>();
        private readonly int _numberOfChildren;
        private readonly int _gameRoundLength;

        public NumbersGame(int numberOfChildren, int gameRoundLength)
        {
            if (numberOfChildren < 1)
            {
                throw new ArgumentException("The number of children passed" +
                    " into the game must be greater than 0. Value = " + numberOfChildren);
            }

            if (gameRoundLength < 1)
            {
                throw new ArgumentException("There must be at least one round" +
                        " in the game. Value = " + gameRoundLength);
            }

            _numberOfChildren = numberOfChildren;
            _gameRoundLength = gameRoundLength;
        }

        public void SetupNewGame()
        {
            int child = 1;

            for (; child <= _numberOfChildren; child++)
            {
                _childrenInGame.Add(child);
            }

        }

        public int Play()
        {
            int currentChildIndex = 0;
            int quotient = 0;
            int modulus = 0;
            int removeChildAtIndex = 0;

            do
            {
                quotient = _gameRoundLength / _childrenInGame.Count;
                modulus = _gameRoundLength % _childrenInGame.Count;
                removeChildAtIndex = Math.Abs(currentChildIndex + (modulus - 1));
                removeChildAtIndex = removeChildAtIndex >= _childrenInGame.Count ? 0 : removeChildAtIndex;
                Console.WriteLine(_childrenInGame[removeChildAtIndex]);
                _childrenInGame.RemoveAt(removeChildAtIndex);
                currentChildIndex = removeChildAtIndex;

            } while (_childrenInGame.Count > 1);

            return _childrenInGame[0];
        }
    }
}
