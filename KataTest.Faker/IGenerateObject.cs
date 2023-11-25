using System.Collections.Generic;


namespace KataTest.Faker
{
    public interface IGenerateObject<T>
    {
        List<T> Generate<E>(int? number = 1);
        void InsertInJsonFileAfterGenerate<E>(int? number = 1, string fileName = "generated_data.json");
    }
}
