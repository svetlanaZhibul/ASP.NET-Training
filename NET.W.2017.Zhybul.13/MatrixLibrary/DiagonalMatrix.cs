using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    public class DiagonalMatrix<T> : SquareMatrix<T> 
        where T : struct
    {
        public DiagonalMatrix() : base()
        {
        }

        public DiagonalMatrix(T[] diagonal)
        {
            if (ReferenceEquals(null, diagonal))
            {
                throw new ArgumentNullException(nameof(diagonal));
            }
            else
            {
                this.matrix = new T[diagonal.Length][];

                for (int i = 0; i < diagonal.Length; i++)
                {
                    for (int j = 0; j < diagonal.Length; j++)
                    {
                        if (i == j)
                        {
                            this.matrix[i][i] = diagonal[i];
                        }
                        else
                        {
                            this.matrix[i][j] = default(T);
                        }
                    }
                }

                this.Dimension = diagonal.Length;
            }
        }

        public DiagonalMatrix(T[][] matrix)
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

            this.SetDiagonalMatrix(matrix, comparer);
        }

        public void SetDiagonalMatrix(T[][] matrix, IComparer<T> comparer)
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
                this.matrix[i] = new T[Dimension];

                for (int j = 0; j < this.Dimension; j++)
                {
                    if (ReferenceEquals(matrix[i][j], null))
                    {
                        this.matrix[i][j] = default(T);
                    }
                    else
                    {
                        if (i != j)
                        {
                            if (comparer.Compare(matrix[i][j], default(T)) == 0)
                            {
                                this.matrix[i][j] = matrix[i][j];
                            }
                        }
                    }
                }
            }
        }
    }
}
