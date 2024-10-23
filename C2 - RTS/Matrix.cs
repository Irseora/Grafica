using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* TODO:
 * 
 */

namespace C2___RTS
{
    internal class Matrix
    {
        float[,] values;

        public static Matrix Empty;
        public int N { get { return values.GetLength(0); } }
        public int M { get { return values.GetLength(1); } }

        public Matrix(string filename)
        {
            string buffer;
            List<string> data = new List<string>();
            TextReader reader = new StreamReader(filename);

            while ((buffer = reader.ReadLine()) != null)
                data.Add(buffer);
            reader.Close();

            int n = data.Count;
            int m = data[0].Split(' ').Length;
            values = new float[n, m];

            for (int i = 0; i < n; i++)
            {
                string[] local = data[i].Split(' ');
                // X
            }
        }

        public Matrix(int n, int m)
        {
            values = new float[n, m];
        }

        // ---------------------------------------------------------

        public List<string> View()
        {
            List<string> toRet = new List<string>();

            for (int i = 0; i < N; i++)
            {
                string buffer = "";
                for (int j = 0; j < M; j++)
                    buffer += values[i, j] + " ";

                toRet.Add(buffer);
            }

            return toRet;
        }

        // ---------------------------------------------------------

        public static Matrix operator + (Matrix A, Matrix B)
        {
            if (A.N != B.N || A.M != B.M)
                return Matrix.Empty;

            Matrix toRet = new Matrix(A.N, A.M);

            for (int i = 0; i < A.N; i++)
                for (int j = 0; j < A.M; j++)
                    toRet.values[i, j] = A.values[i, j] + B.values[i, j];

            return toRet;
        }

        public static Matrix operator * (Matrix A, Matrix B)
        {
            if (A.M != B.N)
                return Matrix.Empty;

            Matrix toRet = new Matrix(A.N, B.M);

            for (int i = 0; i < A.N; i++)
                for (int j = 0; j < B.M; j++)
                {
                    toRet.values[i, j] = 0;
                    for (int k = 0; k < A.M; k++)
                        toRet.values[i, j] += A.values[i, k] * B.values[k, j];
                }
            
            return toRet;
        }
    }
}
