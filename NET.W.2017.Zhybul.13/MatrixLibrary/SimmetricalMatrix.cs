using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    public class SimmetricalMatrix<T> : SquareMatrix<T>
        where T : struct
    {
        public SimmetricalMatrix() : base()
        {
        }

        public SimmetricalMatrix(T[][] matrix)
        {
            IComparer<T> comparer;
            if (typeof(T).GetInterface("IComparable") != null)
            {
                ////comparer = Comparer<T>.Default;
                comparer = null;
            }
            else
            {
                comparer = new DefaultComparerClass<T>();
            }

            this.SetSimmetricalMatrix(matrix, comparer);
        }

        public void SetSimmetricalMatrix(T[][] matrix, IComparer<T> comparer)
        {
            if (matrix == null)
            {
                throw new ArgumentException(nameof(matrix));
            }

            this.matrix = new T[matrix.Length][];

            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix.Length != matrix[i].Length)
                {
                    throw new ArgumentException($"Wrong matrix parameters {nameof(matrix)}");
                }

                this.Dimension = matrix.Length;
                this.matrix[i] = new T[this.Dimension];

                for (int j = 0; j <= i; j++)
                {
                    if (ReferenceEquals(matrix[i][j], null))
                    {
                        this.matrix[i][j] = default(T);
                    }
                    else
                    {
                        if (comparer.Compare(matrix[i][j], matrix[j][i]) == 0)
                        {
                            this.matrix[i][j] = matrix[i][j];
                            this.matrix[j][i] = this.matrix[i][j];
                        }
                        else
                        {
                            throw new ArgumentException($"Matrix {nameof(matrix)} does not corresponds simmetrical matrix.");
                        }
                    }
                }
            }
        }
    }
}
