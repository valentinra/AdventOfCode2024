using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Extensions
{
    public static class MyExtensions
    {
        public static void Dump(this object obj)
        {
            Console.WriteLine(obj.ToString());
        }

        // Write custom extension methods here. They will be available to all queries.
        public static string SubstringMaxLength(this string s, int startIndex, int maxLength)
        {
            if (s.Length - startIndex >= maxLength)
                return s.Substring(startIndex, maxLength);
            else
                return s.Substring(startIndex);
        }

        public static List<List<T>> GetLeftToRightDiags<T>(this T[,] mat)
        {
            var ret = new List<List<T>>();

            var m = mat.GetLength(0);
            var n = mat.GetLength(1);

            // the main digonal and the ones below the main diagonal
            for (int i = 0; i < m; i++)
            {
                var diag = new List<T>();

                int j = 0;
                for (int k = i; k < m; k++)
                {
                    if (j == k - i && j < n)
                        diag.Add(mat[k, j]);
                    j++;
                }
                ret.Add(diag);
                //$"Diag: {string.Join(' ', diag)}".Dump();
            }

            // the diagonals above the main diagonal
            for (int j = 1; j < n; j++)
            {
                var diag = new List<T>();

                int k = j;
                for (int i = 0; i < m; i++)
                {
                    if (i == k - j && k < n)
                        diag.Add(mat[i, k]);
                    k++;
                }
                ret.Add(diag);
                //$"Diag: {string.Join(' ', diag)}".Dump();
            }

            return ret;
        }

        public static List<List<T>> GetRightToLeftDiags<T>(this T[,] mat)
        {
            var ret = new List<List<T>>();

            var m = mat.GetLength(0);
            var n = mat.GetLength(1);

            // the ones above and the main anti-diagonal
            for (int j = 0; j < n; j++)
            {
                var diag = new List<T>();

                int k = j;
                for (int i = 0; i < m && k >= 0; i++)
                {
                    diag.Add(mat[i, k]);
                    k--;
                }
                ret.Add(diag);
                //$"Diag: {string.Join(' ', diag)}".Dump();
            }

            // the diagonals below the main anti diagonal
            for (int i = 1; i < m; i++)
            {
                var diag = new List<T>();

                int k = i;
                for (int j = n - 1; j >= 0 && k < m; j--)
                {
                    diag.Add(mat[k, j]);
                    k++;
                }
                ret.Add(diag);
                //$"Diag: {string.Join(' ', diag)}".Dump();
            }

            return ret;
        }
    }
}
