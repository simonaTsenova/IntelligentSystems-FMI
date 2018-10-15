using System;
using System.Collections.Generic;
using System.Text;

namespace HW1.Frogs
{
    public class Program
    {
        private const char EMPTY_CHAR = '_';
        private const char LEFT_CHAR = '>';
        private const char RIGHT_CHAR = '<';

        public static List<string> path = new List<string>();

        private static bool IsSolution(string condition, int emptyPosition)
        {
            var fieldLength = condition.Length;
            var parts = condition.Split(EMPTY_CHAR);
            if (emptyPosition == fieldLength / 2 && !parts[0].Contains(LEFT_CHAR.ToString()) && !parts[1].Contains(RIGHT_CHAR.ToString()))
            {
                return true;
            }

            return false;
        }

        public static bool DFS(string initialCondition, int emptyPostition)
        {
            if (IsSolution(initialCondition, emptyPostition))
            {
                return true;
            }

            var possibleMoves = new List<string>();
            // Left from empty
            for (int i = 1; i <= 2; i++)
            {
                // if valid index
                if (emptyPostition - i >= 0)
                {
                    var characterToMove = initialCondition[emptyPostition - i];
                    if (characterToMove.Equals(LEFT_CHAR))
                    {
                        StringBuilder condition = new StringBuilder(initialCondition);
                        condition[emptyPostition - i] = EMPTY_CHAR;
                        condition[emptyPostition] = characterToMove;

                        possibleMoves.Add(condition.ToString());
                    }
                }
            }

            // Right from empty
            for (int i = 1; i <= 2; i++)
            {
                // if valid index
                if (emptyPostition + i <= initialCondition.Length - 1)
                {
                    var characterToMove = initialCondition[emptyPostition + i];
                    if (characterToMove.Equals(RIGHT_CHAR))
                    {
                        StringBuilder condition = new StringBuilder(initialCondition);
                        condition[emptyPostition + i] = EMPTY_CHAR;
                        condition[emptyPostition] = characterToMove;

                        possibleMoves.Add(condition.ToString());
                    }
                }
            }

            foreach (var move in possibleMoves)
            {
                var currentEmptyPosition = move.IndexOf(EMPTY_CHAR);
                if (DFS(move, currentEmptyPosition))
                {
                    path.Add(move);
                    return true;
                }
            }

            return false;
        }

        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());

            var initialCondition = new String(LEFT_CHAR, N) + EMPTY_CHAR + new string(RIGHT_CHAR, N);
            var result = DFS(initialCondition, (2 * N + 1) / 2);

            path.Add(initialCondition);
            for (int i = path.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(path[i]);
            }
        }
    }
}
