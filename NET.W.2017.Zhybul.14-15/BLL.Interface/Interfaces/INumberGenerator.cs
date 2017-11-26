using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace BLL.Interface.Interfaces
{
    interface INumberGenerator
    {
        void GenerateNumber(BaseAccount account);
        void GenerateNumber(GoldAccount account);
        void GenerateNumber(PremiumAccount account);
    }
}
