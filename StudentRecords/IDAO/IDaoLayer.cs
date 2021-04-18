using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRecords.IDAO
{
    interface IDaoLayer<T>
    {
        bool Add(T x);
        ArrayList Index();
        bool Edit(T x,int id);
        T Edit(int id);
        bool Delete(int id);
        ArrayList Search(int searchField, string query);
           

    }
}
