using System;
using System.Collections.Generic;
using System.Linq;

namespace Nono
{
    public class Line
    {
        private readonly Number[] _numbers;
        private readonly Square[] _squares;

        private readonly int _fillableSquareCount;
        private readonly int _emptySquareCount;

        private bool AllFillableSquaresFilled => _fillableSquareCount == _squares.Count(s => s == Square.Filled);
        private bool AllEmptySquaresSet => _emptySquareCount == _squares.Count(s => s == Square.Empty);

        private bool _solved;

        private int Length => _squares.Length;

        public Line(int length, List<int> lineNumbers)
        {
            _numbers = lineNumbers.Select(n => new Number(n, length)).ToArray();
            _squares = new Square[length];
            _fillableSquareCount = lineNumbers.Sum();
            _emptySquareCount = length - _fillableSquareCount;
            SetInitialNumberPositions();
            UpdateSquaresFromNumbers();
            SetEmptyInBetweenNumbers();
        }

        public Square this[int index]
        {
            get => _squares[index];
            set => _squares[index] = value;
        }

        public int Iterate()
        {
            var initialUnknown = _squares.Count(s => s == Square.Unknown);
            UpdateSolved();
            if (!_solved)
            {
                UpdateNumbersForward();
                UpdateNumbersBackward();
                UpdateSquaresFromNumbers();
                SetEmptyInBetweenNumbers();
            }
            return initialUnknown - _squares.Count(s => s == Square.Unknown);
        }

        private void SetInitialNumberPositions()
        {
            for (var numberIndex = 0; numberIndex < _numbers.Length; numberIndex++)
            {
                var numbersBefore = _numbers.Take(numberIndex);
                var numbersAfter = _numbers.Skip(numberIndex + 1);
                var beforeNumberSum = numbersBefore.Sum(n => n.Value);
                var afterNumberSum = numbersAfter.Sum(n => n.Value);

                var number = _numbers[numberIndex];
                number.FromIndex = beforeNumberSum + numberIndex;
                number.ToIndex = Length - afterNumberSum - _numbers.Length + numberIndex;
            }
        }

        private void UpdateSquaresFromNumbers()
        {
            foreach (var number in _numbers)
            {
                var squaresToFill = number.Value * 2 - number.PossibleSquareCount;
                if (squaresToFill <= 0)
                    continue;
                var firstFillableIndex = number.FromIndex + (number.PossibleSquareCount - squaresToFill) / 2;
                for (var index = 0; index < squaresToFill; index++)
                {
                    _squares[firstFillableIndex + index] = Square.Filled;
                }
            }
        }

        private void UpdateNumbersForward()
        {
            for (var numberIndex = 0; numberIndex < _numbers.Length; numberIndex++)
            {
                var number = _numbers[numberIndex];
                if (number.Placed)
                    continue;

                if (numberIndex > 0)
                {
                    var previousNumber = _numbers[numberIndex - 1];
                    number.UpdateFromIndexFromPreviousNumber(previousNumber);
                }

                UpdateFromIndexBasedOnFirstPossibleOpening(number);

                var firstNonplacedNumberIndex = Array.FindIndex(_numbers, n => !n.Placed);
                if (firstNonplacedNumberIndex != numberIndex)
                    continue;

                var indexOfFirstFilledSquare = Array.FindIndex(_squares.Skip(number.FromIndex).ToArray(), s => s == Square.Filled) + number.FromIndex;
                if (indexOfFirstFilledSquare < number.FromIndex)
                    continue;

                var continuousFilledSquareCount = _squares.Skip(indexOfFirstFilledSquare).TakeWhile(s => s == Square.Filled).Count();

                if (!number.CanOwnSquareRange(indexOfFirstFilledSquare, indexOfFirstFilledSquare + continuousFilledSquareCount))
                    continue;

                var firstFilledSquareDefinitelyBelongsToNumber = indexOfFirstFilledSquare <= number.FromIndex + number.Value
                                                                 || !CanBelongToNeighborOfNumber(numberIndex, indexOfFirstFilledSquare, indexOfFirstFilledSquare + continuousFilledSquareCount);
                if (!firstFilledSquareDefinitelyBelongsToNumber)
                {
                    if (continuousFilledSquareCount > number.Value)
                    {
                        number.ToIndex = indexOfFirstFilledSquare - 2;
                    }
                    continue;
                }

                var firstPossibleSquareIndex = indexOfFirstFilledSquare + continuousFilledSquareCount - number.Value;
                if (number.FromIndex < firstPossibleSquareIndex)
                {
                    number.FromIndex = firstPossibleSquareIndex;
                }

                var lastPossibleSquareIndex = indexOfFirstFilledSquare + number.Value - 1;
                if (number.ToIndex > lastPossibleSquareIndex)
                {
                    number.ToIndex = lastPossibleSquareIndex;
                }
            }
        }

        private void UpdateNumbersBackward()
        {
            for (var numberIndex = _numbers.Length - 1; numberIndex >= 0; numberIndex--)
            {
                var number = _numbers[numberIndex];
                if (number.Placed)
                    continue;

                if (numberIndex < _numbers.Length - 1)
                {
                    var nextNumber = _numbers[numberIndex + 1];
                    number.UpdateToIndexFromNextNumber(nextNumber);
                }

                UpdateToIndexBasedOnLastPossibleOpening(number);

                var lastNonplacedNumberIndex = Array.FindLastIndex(_numbers, n => !n.Placed);
                if (lastNonplacedNumberIndex != numberIndex)
                    continue;

                var indexOfLastFilledSquare = Array.FindLastIndex(_squares.Take(number.ToIndex + 1).ToArray(), s => s == Square.Filled);
                if (indexOfLastFilledSquare < 0)
                    continue;

                var continuousFilledSquareCount = _squares.Take(indexOfLastFilledSquare + 1).Reverse().TakeWhile(s => s == Square.Filled).Count();

                if (!number.CanOwnSquareRange(indexOfLastFilledSquare - continuousFilledSquareCount, indexOfLastFilledSquare))
                    continue;

                var lastFilledSquareDefinitelyBelongsToNumber = indexOfLastFilledSquare >= number.ToIndex - number.Value
                                                                || !CanBelongToNeighborOfNumber(numberIndex, indexOfLastFilledSquare - continuousFilledSquareCount, indexOfLastFilledSquare);
                if (!lastFilledSquareDefinitelyBelongsToNumber)
                {
                    if (continuousFilledSquareCount > number.Value)
                    {
                        number.FromIndex = indexOfLastFilledSquare + 2;
                    }
                    continue;
                }

                var lastPossibleSquareIndex = indexOfLastFilledSquare - continuousFilledSquareCount + number.Value;
                if (number.ToIndex > lastPossibleSquareIndex)
                {
                    number.ToIndex = lastPossibleSquareIndex;
                }

                var firstPossibleSquareIndex = indexOfLastFilledSquare - number.Value + 1;
                if (number.FromIndex < firstPossibleSquareIndex)
                {
                    number.FromIndex = firstPossibleSquareIndex;
                }
            }
        }

        private void UpdateFromIndexBasedOnFirstPossibleOpening(Number number)
        {
            while (number.FromIndex + number.Value <= Length)
            {
                if (_squares.Skip(number.FromIndex).Take(number.Value).All(s => s != Square.Empty))
                {
                    return;
                }
                number.FromIndex++;
            }
            throw new Exception("Incorrect data provided, no solution possible");
        }

        private void UpdateToIndexBasedOnLastPossibleOpening(Number number)
        {
            
            while (number.ToIndex - number.Value + 1 >= 0)
            {
                if (_squares.Reverse().Skip(Length - number.ToIndex - 1).Take(number.Value).All(s => s != Square.Empty))
                {
                    return;
                }
                number.ToIndex--;
            }
            throw new Exception("Incorrect data provided, no solution possible");
        }

        private void SetEmptyInBetweenNumbers()
        {
            for (var numberIndex = 0; numberIndex < _numbers.Length; numberIndex++)
            {
                var number = _numbers[numberIndex];

                if (numberIndex == 0)
                {
                    for (var index = 0; index < number.FromIndex; index++)
                    {
                        _squares[index] = Square.Empty;
                    }
                }

                var fillToIndex = numberIndex == _numbers.Length - 1 ? Length : _numbers[numberIndex + 1].FromIndex;
                for (var index = number.ToIndex + 1; index < fillToIndex; index++)
                {
                    _squares[index] = Square.Empty;
                }
            }
        }

        private void UpdateSolved()
        {
            if (_solved)
                return;

            if (_squares.All(s => s.IsKnown()))
            {
                _solved = true;
                return;
            }
            
            if (AllFillableSquaresFilled)
            {
                for (var i = 0; i < _squares.Length; i++)
                {
                    if (_squares[i] == Square.Unknown)
                    {
                        _squares[i] = Square.Empty;
                    }
                }
                _solved = true;
                return;
            }
            
            if (AllEmptySquaresSet)
            {
                for (var i = 0; i < _squares.Length; i++)
                {
                    if (_squares[i] == Square.Unknown)
                    {
                        _squares[i] = Square.Filled;
                    }
                }
                _solved = true;
            }
        }

        private bool CanBelongToNeighborOfNumber(int numberIndex, int squareIndexFrom, int squareIndexTo)
        {
            if (numberIndex > 0)
            {
                var previousNumber = _numbers[numberIndex - 1];
                if (previousNumber.CanOwnSquareRange(squareIndexFrom, squareIndexTo))
                    return true;
            }

            if (numberIndex < _numbers.Length - 1)
            {
                var nextNumber = _numbers[numberIndex + 1];
                if (nextNumber.CanOwnSquareRange(squareIndexFrom, squareIndexTo))
                    return true;
            }

            return false;
        }

        public override string ToString()
        {
            return string.Join("", _squares.Select(s => s.ToPrintableString()));
        }
    }
}