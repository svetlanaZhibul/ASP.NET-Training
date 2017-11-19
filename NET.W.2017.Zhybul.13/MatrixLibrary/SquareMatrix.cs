using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    public class SquareMatrix<T>
        where T : struct
    {
        protected T[][] matrix;

        protected SquareMatrix()
        {
        }

        protected SquareMatrix(T[][] matrix)
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

                this.matrix[i] = new T[matrix[i].Length];

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (ReferenceEquals(matrix[i][j], null))
                    {
                        this.matrix[i][j] = default(T);
                    }
                    else
                    {
                        this.matrix[i][j] = matrix[i][j];
                    }
                }
            }
        }

        #region Property
        public int Dimension { get; set; }

        public T[][] Matrix
        {
            get
            {
                return matrix;
            }
        } 
        #endregion

        public SquareMatrix<T> Add(SquareMatrix<T> lhs, SquareMatrix<T> rhs)
        {
            if (lhs.Dimension != rhs.Dimension)
            {
                throw new ArgumentException($"Matrices {nameof(lhs)} and {nameof(rhs)} are not compatible due to dimensions");
            }

            T[][] sum = new T[lhs.Dimension][];

            for (int i = 0; i < lhs.Dimension; i++)
            {
                for (int j = 0; j < lhs.Dimension; j++)
                {
                    sum[i][j] = Operator<T>.Add(lhs.Matrix[i][j], rhs.Matrix[i][j]);
                }
            }

            return new SquareMatrix<T>(sum);
        }

        public void ChangeItemAtIndex(int row, int column, T value)
        {
            if (row >= this.Dimension)
            {
                throw new IndexOutOfRangeException(nameof(row));
            }

            if (column >= this.Dimension)
            {
                throw new IndexOutOfRangeException(nameof(column));
            }

            Matrix[row][column] = value;
        }
    }
}
