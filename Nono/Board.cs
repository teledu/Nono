using System.Collections.Generic;
using System.Linq;

namespace Nono
{
    public class Board
    {
        private List<Line> _rows;
        private List<Line> _columns;

        private int _rowCount => _rows.Count;
        private int _colCount => _columns.Count;
        
        public void Initialize(List<List<int>> columns, List<List<int>> rows)
        {
            _rows = rows.Select(r => new Line(columns.Count, r)).ToList();
            _columns = columns.Select(c => new Line(rows.Count, c)).ToList();
        }

        public void Solve()
        {
            var updates = 1;
            while (updates > 0)
            {
                SynchronizeRowsAndColumns();
                updates = 0;
                updates += IterateLines(_rows);
                updates += IterateLines(_columns);
            }
        }

        private int IterateLines(List<Line> lines)
        {
            var updates = 0;
            foreach (var line in lines)
            {
                updates += line.Iterate();
            }
            return updates;
        }

        private void SynchronizeRowsAndColumns()
        {
            for (var rowIndex = 0; rowIndex < _rowCount; rowIndex++)
            {
                for (var colIndex = 0; colIndex < _colCount; colIndex++)
                {
                    if (!_rows[rowIndex][colIndex].IsKnown())
                    {
                        _rows[rowIndex][colIndex] = _columns[colIndex][rowIndex];
                    }
                    if (!_columns[colIndex][rowIndex].IsKnown())
                    {
                        _columns[colIndex][rowIndex] = _rows[rowIndex][colIndex];
                    }
                }
            }
        }

        public override string ToString()
        {
            var lines = _rows.Select(r => r.ToString());
            return string.Join("\n", lines);
        }
    }
}