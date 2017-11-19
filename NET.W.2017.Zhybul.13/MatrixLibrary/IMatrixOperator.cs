using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    public interface IMatrixOperator<T> where T : struct
    {
        SquareMatrix<T> Add(SquareMatrix<T> lhs, SquareMatrix<T> rhs);
    }
}
