using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyboardRecorder
{
    public class Script
    {
        private readonly List<KeyCombination> _combinations;
        private int? _playhead;

        public Script()
        {
            _combinations = new List<KeyCombination>();
            _playhead = null;
        }

        public KeyCombination Current => _playhead.HasValue
            ? _combinations[_playhead.Value]
            : null;

        public IEnumerable<KeyCombination> KeyCombinations => _combinations;

        public void Add(KeyCombination combination)
        {
            _combinations.Add(combination);
        }

        public void MovePlayhead()
        {
            if (!_combinations.Any())
            {
                throw new InvalidOperationException();
            }
        }

        public void Clear()
        {
            _combinations.Clear();
            _playhead = null;
        }
    }
}