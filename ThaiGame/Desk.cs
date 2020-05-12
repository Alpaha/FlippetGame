using System.Collections.Generic;
using System.Linq;

namespace ThaiGame
{
    public class Desk
    {
        private readonly Throw _throw = new Throw();
        private readonly List<Cell> _cells = new List<Cell>(9);
        private readonly int[] _mostHardHigherCells = {9, 8, 7, 1, 2, 3, 5, 4, 6};

        public Desk()
        {
            for (var i = 1; i <= _cells.Capacity; i++)
                _cells.Add(new Cell(i));
        }

        private IEnumerable<int> ClosedCells => _cells
            .Where(c => !c.IsOpened)
            .Select(c => c.Number);

        public bool AllOpened => _cells.All(c => c.IsOpened);

        public bool DoTurn()
        {
            if (AllOpened) return true;
            var throwResults = _throw.DoThrow();
            var variantsToOpen = ClosedCells.Intersect(throwResults).ToArray();

            if (variantsToOpen.Length == 0)
                return false;
            if (variantsToOpen.Length > 1)
                _cells[GetTheMostHardCell(variantsToOpen)].Open();
            else
                _cells[variantsToOpen[0] - 1].Open();
            return true;
        }
        
        private int GetTheMostHardCell(IEnumerable<int> variantsToOpen)
        {
            return _mostHardHigherCells.First(variantsToOpen.Contains) - 1;
        }
    }
}