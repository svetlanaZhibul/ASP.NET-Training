using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Interfaces;

namespace BLL.Interface
{

    // ************* temporarily ************** //


    public class NumberGenerator : INumberGenerator
    {
        ////private string balance;
        ////private string currency;
        ////private string key;
        ////private string filial;
        ////private string personal_number;

        private const int FirstGroup = 5;
        private const int SeconsGroup = 3;
        private const int ThirdGroup = 1;
        private const int FourthGroup = 4;
        private const int FifthGroup = 7;
        private int[] Groups = { FifthGroup, SeconsGroup, ThirdGroup, FourthGroup, FifthGroup};

        public string Number { get; private set; }

        public void GenerateNumber(PremiumAccount account)
        {
            StringBuilder sb = new StringBuilder("");
            foreach (int group in Groups)
            {
                for (int i = 0; i < group; i++)
                {
                    sb.Append(new Random().Next(0, 9)); 
                }
            }

            this.Number = sb.ToString();        //? refernce
        }

        public void GenerateNumber(GoldAccount account)
        {
            throw new NotImplementedException();
        }

        public void GenerateNumber(BaseAccount account)
        {
            throw new NotImplementedException();
        }
    }
}
