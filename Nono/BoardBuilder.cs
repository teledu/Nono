using System;
using System.Collections.Generic;

namespace Nono
{
    public static class BoardBuilder
    {
        private static readonly List<Action<Board>> _boardInitializers = new List<Action<Board>>
        {
            board =>
            {
                var columns = new List<List<int>>
                {
                    new List<int>{3, 1},
                    new List<int>{1, 1, 1},
                    new List<int>{1, 1, 1},
                    new List<int>{1, 1, 1},
                    new List<int>{1, 3},
                };
                var rows = new List<List<int>>
                {
                    new List<int>{5},
                    new List<int>{1},
                    new List<int>{5},
                    new List<int>{1},
                    new List<int>{5},
                };

                board.Initialize(columns, rows);
            },



            board =>
            {
                var columns = new List<List<int>>
                {
                    new List<int>{3},
                    new List<int>{2, 2},
                    new List<int>{1, 1},
                    new List<int>{2, 2},
                    new List<int>{3},
                };
                var rows = new List<List<int>>
                {
                    new List<int>{3},
                    new List<int>{2, 2},
                    new List<int>{1, 1},
                    new List<int>{2, 2},
                    new List<int>{3},
                };

                board.Initialize(columns, rows);
            },



            board =>
            {
                var columns = new List<List<int>>
                {
                    new List<int>{5},
                    new List<int>{1, 1},
                    new List<int>{3},
                    new List<int>{1, 1},
                    new List<int>{3},
                };
                var rows = new List<List<int>>
                {
                    new List<int>{5},
                    new List<int>{1, 1, 1},
                    new List<int>{5},
                    new List<int>{1},
                    new List<int>{1},
                };

                board.Initialize(columns, rows);
            },



            board =>
            {
                var columns = new List<List<int>>
                {
                    new List<int>{1, 1},
                    new List<int>{1, 2},
                    new List<int>{1, 1, 1},
                    new List<int>{2, 1},
                    new List<int>{1, 1},
                };
                var rows = new List<List<int>>
                {
                    new List<int>{5},
                    new List<int>{1},
                    new List<int>{1},
                    new List<int>{1},
                    new List<int>{5},
                };

                board.Initialize(columns, rows);
            },



            board =>
            {
                var columns = new List<List<int>>
                {
                    new List<int>{2, 1},
                    new List<int>{4},
                    new List<int>{1, 1},
                    new List<int>{4},
                    new List<int>{1, 2},
                };
                var rows = new List<List<int>>
                {
                    new List<int>{1, 2},
                    new List<int>{4},
                    new List<int>{1, 1},
                    new List<int>{4},
                    new List<int>{2, 1},
                };

                board.Initialize(columns, rows);
            },



            board =>
            {
                var columns = new List<List<int>>
                {
                    new List<int>{1, 1},
                    new List<int>{5},
                    new List<int>{1, 1},
                    new List<int>{5},
                    new List<int>{1, 1},
                };
                var rows = new List<List<int>>
                {
                    new List<int>{1, 1},
                    new List<int>{5},
                    new List<int>{1, 1},
                    new List<int>{5},
                    new List<int>{1, 1},
                };

                board.Initialize(columns, rows);
            },



            board =>
            {
                var columns = new List<List<int>>
                {
                    new List<int>{1},
                    new List<int>{3},
                    new List<int>{2},
                    new List<int>{5},
                    new List<int>{1},
                };
                var rows = new List<List<int>>
                {
                    new List<int>{1},
                    new List<int>{1,3},
                    new List<int>{3},
                    new List<int>{1, 1},
                    new List<int>{1, 1},
                };

                board.Initialize(columns, rows);
            },



            board =>
            {
                var columns = new List<List<int>>
                {
                    new List<int>{6},
                    new List<int>{7},
                    new List<int>{8},
                    new List<int>{9},
                    new List<int>{3, 5},
                    new List<int>{3, 5},
                    new List<int>{9},
                    new List<int>{8},
                    new List<int>{7},
                    new List<int>{6},
                };
                var rows = new List<List<int>>
                {
                    new List<int>{10},
                    new List<int>{10},
                    new List<int>{10},
                    new List<int>{4, 4},
                    new List<int>{4, 4},
                    new List<int>{10},
                    new List<int>{8},
                    new List<int>{6},
                    new List<int>{4},
                    new List<int>{2},
                };

                board.Initialize(columns, rows);
            },



            board =>
            {
                var columns = new List<List<int>>
                {
                    new List<int>{6},
                    new List<int>{7},
                    new List<int>{8},
                    new List<int>{9},
                    new List<int>{5, 3},
                    new List<int>{5, 3},
                    new List<int>{9},
                    new List<int>{8},
                    new List<int>{7},
                    new List<int>{6},
                };
                var rows = new List<List<int>>
                {
                    new List<int>{2},
                    new List<int>{4},
                    new List<int>{6},
                    new List<int>{8},
                    new List<int>{10},
                    new List<int>{4, 4},
                    new List<int>{4, 4},
                    new List<int>{10},
                    new List<int>{10},
                    new List<int>{10},
                };

                board.Initialize(columns, rows);
            },



            board =>
            {
                var columns = new List<List<int>>
                {
                    new List<int>{2},
                    new List<int>{4},
                    new List<int>{4},
                    new List<int>{8},
                    new List<int>{1, 1},
                    new List<int>{1, 1},
                    new List<int>{1, 1, 2},
                    new List<int>{1, 1, 4},
                    new List<int>{1, 1, 4},
                    new List<int>{8},
                };
                var rows = new List<List<int>>
                {
                    new List<int>{4},
                    new List<int>{3, 1},
                    new List<int>{1, 3},
                    new List<int>{4, 1},
                    new List<int>{1, 1},
                    new List<int>{1, 3},
                    new List<int>{3, 4},
                    new List<int>{4, 4},
                    new List<int>{4, 2},
                    new List<int>{2},
                };

                board.Initialize(columns, rows);
            },



            board =>
            {
                var columns = new List<List<int>>
                {
                    new List<int>{10},
                    new List<int>{1, 1},
                    new List<int>{1, 1, 1, 1, 1},
                    new List<int>{1, 1, 1, 1, 1},
                    new List<int>{1, 1, 1, 1, 1},
                    new List<int>{1, 1},
                    new List<int>{1, 1},
                    new List<int>{1, 1, 1},
                    new List<int>{1, 1},
                    new List<int>{10},
                };
                var rows = new List<List<int>>
                {
                    new List<int>{10},
                    new List<int>{1, 1},
                    new List<int>{1, 1, 1},
                    new List<int>{1, 3, 1},
                    new List<int>{1, 1},
                    new List<int>{1, 3, 1},
                    new List<int>{1, 1},
                    new List<int>{1, 3, 1},
                    new List<int>{1, 1},
                    new List<int>{10},
                };

                board.Initialize(columns, rows);
            },



            board =>
            {
                var columns = new List<List<int>>
                {
                    new List<int>{3},
                    new List<int>{4},
                    new List<int>{5},
                    new List<int>{4},
                    new List<int>{5},
                    new List<int>{6},
                    new List<int>{3, 2, 1},
                    new List<int>{2, 2, 5},
                    new List<int>{4, 2, 6},
                    new List<int>{8, 2, 3},
                    new List<int>{8, 2, 1, 1},
                    new List<int>{2, 6, 2, 1},
                    new List<int>{4, 6},
                    new List<int>{2, 4},
                    new List<int>{1},
                };
                var rows = new List<List<int>>
                {
                    new List<int>{3},
                    new List<int>{5},
                    new List<int>{4, 3},
                    new List<int>{7},
                    new List<int>{5},
                    new List<int>{3},
                    new List<int>{5},
                    new List<int>{1, 8},
                    new List<int>{3, 3, 3},
                    new List<int>{7, 3, 2},
                    new List<int>{5, 4, 2},
                    new List<int>{8, 2},
                    new List<int>{10},
                    new List<int>{2, 3},
                    new List<int>{6},
                };

                board.Initialize(columns, rows);
            },



            board =>
            {
                var columns = new List<List<int>>
                {
                    new List<int>{2, 20, 1, 3},
                    new List<int>{2, 18, 2, 2},
                    new List<int>{2, 14, 1, 4},
                    new List<int>{2, 1, 2, 9, 2},
                    new List<int>{2, 14, 5, 2},
                    new List<int>{2, 1, 13, 6, 1},
                    new List<int>{3, 2, 8},
                    new List<int>{3, 1, 8},
                    new List<int>{3, 1, 7, 2},
                    new List<int>{2, 1, 1, 3, 3},
                    new List<int>{4, 1, 3, 1, 1, 3, 1},
                    new List<int>{4, 1, 2, 1, 1, 2},
                    new List<int>{2, 2, 2, 1, 2, 1, 2, 2},
                    new List<int>{6, 1, 1, 3, 1},
                    new List<int>{1, 5, 7, 1, 1, 6},
                    new List<int>{4, 12, 12},
                    new List<int>{3, 2, 13, 3},
                    new List<int>{2, 3, 1, 12},
                    new List<int>{1, 3, 1, 1, 1, 9, 1},
                    new List<int>{1, 4, 1, 1, 1, 1, 4, 2},
                    new List<int>{5, 1, 2, 2, 3},
                    new List<int>{4, 2, 1, 2, 3},
                    new List<int>{3, 3, 1, 2},
                    new List<int>{3, 6, 5},
                    new List<int>{2, 8, 1, 4},
                    new List<int>{2, 8, 2},
                    new List<int>{10, 3},
                    new List<int>{9, 2, 2, 6},
                    new List<int>{8, 1, 1, 5},
                    new List<int>{13, 3, 1},
                };
                var rows = new List<List<int>>
                {
                    new List<int>{9, 10, 5},
                    new List<int>{14, 3, 10},
                    new List<int>{6, 4, 5, 4},
                    new List<int>{1, 2, 6, 6, 6},
                    new List<int>{3, 2, 2, 3, 6, 7},
                    new List<int>{5, 2, 2, 8, 8},
                    new List<int>{7, 2, 1, 2, 9},
                    new List<int>{3, 2, 2, 4, 1, 9},
                    new List<int>{12, 2, 7},
                    new List<int>{11, 2, 4, 1},
                    new List<int>{10, 2, 2, 1},
                    new List<int>{9, 2, 4, 1, 1},
                    new List<int>{9, 2, 2, 1, 1},
                    new List<int>{8, 1, 3, 2, 1},
                    new List<int>{8, 1, 3, 2},
                    new List<int>{7, 3, 2, 1},
                    new List<int>{6, 2},
                    new List<int>{2, 2, 3},
                    new List<int>{2, 1, 3, 3},
                    new List<int>{2, 5, 1},
                    new List<int>{2, 1, 2, 5},
                    new List<int>{3, 2, 5},
                    new List<int>{1, 2, 4, 1},
                    new List<int>{2, 5, 1, 1},
                    new List<int>{2, 10, 2},
                    new List<int>{2, 2, 13, 2, 4},
                    new List<int>{2, 7, 3, 8},
                    new List<int>{1, 2, 2, 6, 10},
                    new List<int>{5, 1, 1, 4, 3, 2, 2},
                    new List<int>{3, 2, 1, 1, 5, 4, 1},
                };

                board.Initialize(columns, rows);
            },



            //board =>
            //{
            //    var columns = new List<List<int>>
            //    {
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //    };
            //    var rows = new List<List<int>>
            //    {
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //        new List<int>{},
            //    };

            //    board.Initialize(columns, rows);
            //},
        };

        public static IEnumerable<Action<Board>> Initializers
        {
            get
            {
                foreach (var initializer in _boardInitializers)
                {
                    yield return initializer;
                }
            }
        }
    }
}