using System;
using System.Collections.Generic;

namespace ThaiGame
{
    public class Throw
    {
        private readonly Bone _bone1 = new Bone();
        private readonly Bone _bone2 = new Bone();
        private List<int> _throwResults;
        private int BonesSum => _bone1 + _bone2;
        private bool LessThanTen => BonesSum < 10;

        public List<int> DoThrow(Action<Bone, Bone> modifier = null)
        {
            if (modifier != null)
                modifier.Invoke(_bone1, _bone2);
            else
            {
                _bone1.ThrowBone();
                _bone2.ThrowBone();
            }

            return GetThrowResults();
        }

        private List<int> GetThrowResults()
        {
            if (_bone1.Number != _bone2.Number)
                _throwResults = new List<int>
                {
                    _bone1.Number,
                    _bone2.Number
                };
            else
                _throwResults = new List<int>
                {
                    _bone1.Number
                };
            if (LessThanTen)
                _throwResults.Add(BonesSum);

            return _throwResults;
        }
    }
}