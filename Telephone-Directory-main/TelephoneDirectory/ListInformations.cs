using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneDirectory
{
     class ListInformations
    {
        string name;
        string surname;
        long tel;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public long Tel { get => tel; set => tel = value; }
    }
}
