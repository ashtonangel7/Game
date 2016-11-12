namespace Common.Records
{
    using System;
    using System.Collections.Generic;
    public class NumbersGame
    {
        private readonly int _numberOfChildren;
        private readonly int _gameRoundLength;
        private readonly List<int> _childrenInGame;
        private readonly List<int> _childrenEliminated;
        private readonly int _gameId;
        private int _winner;

        public int Winner
        {
            get
            {
                return _winner;
            }

            private set
            {
                _winner = value;
            }
        }

        public List<int> ChildrenEliminated
        {
            get
            {
                return _childrenEliminated;
            }
        }

        public int GameId
        {
            get
            {
                return _gameId;
            }
        }

        /// <summary>
        /// Main Game Constructor for the childrens game.
        /// Children are eliminated from the game in a clockwise direction from 1.
        /// The winner is the last child left in the game.
        /// Note : You must call SetupNewGame to use this class.
        /// </summary>
        /// <param name="gameId">The Unique Game identifier.</param>
        /// <param name="numberOfChildren">The number of children in the game.</param>
        /// <param name="gameRoundLength">The count interval at which each child leaves the game.</param>
        public NumbersGame(int gameId, int numberOfChildren, int gameRoundLength)
        {
            if (gameId < 0)
            {
                throw new ArgumentException("We must recieve a valid Game Id" +
                    " . Value = " + gameId);
            }

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

            _childrenInGame = new List<int>();
            _childrenEliminated = new List<int>();

            _numberOfChildren = numberOfChildren;
            _gameRoundLength = gameRoundLength;
            _gameId = gameId;
        }

        public void SetupNewGame()
        {
            for (int child = 1; child <= _numberOfChildren; child++)
            {
                _childrenInGame.Add(child);
            }
        }

        public bool Play(out string message)
        {

            if(_childrenInGame.Count < 1)
            {
                message = "The game has not been setup correctly, please call SetupNewGame first.";
                return false;
            }

            int currentChildIndex = 0;
            int quotient = 0;
            int modulus = 0;
            int removeChildAtIndex = 0;

            int expectedIterations = _childrenInGame.Count - 1;
            int loopIterations = 0;

            try
            {
                do
                {
                    quotient = _gameRoundLength / _childrenInGame.Count;
                    modulus = _gameRoundLength % _childrenInGame.Count;
                    removeChildAtIndex = Math.Abs(currentChildIndex + (modulus - 1));
                    removeChildAtIndex = removeChildAtIndex >= _childrenInGame.Count ? 0 : removeChildAtIndex;
                    _childrenEliminated.Add(_childrenInGame[removeChildAtIndex]);
                    _childrenInGame.RemoveAt(removeChildAtIndex);
                    currentChildIndex = removeChildAtIndex;
                    loopIterations++;

                } while (_childrenInGame.Count > 1 && loopIterations <= expectedIterations);


                _winner = _childrenInGame[0];
            }
            catch (OverflowException ox)
            {
                message = string.Format("Overflow exception occured in NumbersGame Play method. Please review Stack Trace.",
                    ox.StackTrace);
                return false;
            }
            catch (IndexOutOfRangeException ix)
            {
                message = string.Format("Index out of range exception occured in NumbersGame Play method. Please review Stack Trace.",
                   ix.StackTrace);
                return false;
            }

            message = string.Empty;
            return true;
        }
    }
}
