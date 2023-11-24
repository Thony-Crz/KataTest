using System.Collections.Generic;


namespace KataTest.Faker
{
    public interface IGenerateObject<T>
    {
        List<T> Generate<E>(int? number = 1);
    }
}
