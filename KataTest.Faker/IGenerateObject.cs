using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataTest.Faker
{
    public interface IGenerateObject<T>
    {
        List<T> Generate<E>(int? number = 1);
    }
}
