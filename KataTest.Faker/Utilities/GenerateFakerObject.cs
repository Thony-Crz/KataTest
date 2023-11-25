using Bogus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Xml;

namespace KataTest.Faker.Utilities
{
    public class GenerateFakerObject<T> : IGenerateObject<T> where T : class
    {
        /// <summary>
        /// Generates a list of data of type <typeparamref name="E"/> using the Faker library and random values.
        /// </summary>
        /// <typeparam name="E">The type of data to generate.</typeparam>
        /// <param name="number">The number of data items to generate. Defaults to generating a single data item.</param>
        /// <returns>A list of randomly generated data items of type <typeparamref name="E"/>.</returns>
        public List<T> Generate<E>(int? number = 1)
        {
            var dataFaker = new Faker<T>();

            foreach (var property in typeof(T).GetProperties())
            {
                var propertyExpression = CreatePropertyExpression<T>(property);
                dataFaker.RuleFor(propertyExpression, faker => GenerateRandomValue(property));
            }

            return dataFaker.Generate(number.Value);
        }

        /// <summary>
        /// Generates data of type <typeparamref name="E"/> using the Generate method, and then inserts it into a JSON file.
        /// </summary>
        /// <typeparam name="E">The type of data to generate and store in the JSON file.</typeparam>
        /// <param name="number">The number of data to generate. By default, generates a single data.</param>
        /// <param name="fileName">The name of the JSON file in which the generated data will be stored. By default, the file is named "generated_data.json".</param>
        public void InsertInJsonFileAfterGenerate<E>(int? number = 1,string fileName = "generated_data.json")
        {
            var generatedData = Generate<E>(number);

            string jsonFileName = fileName;
            string jsonString = JsonConvert.SerializeObject(generatedData, Newtonsoft.Json.Formatting.Indented);

            // Write the JSON data to the file
            File.WriteAllText(jsonFileName, jsonString);
        }

        private static object GenerateRandomValue(PropertyInfo propertyInfo)
        {
            Bogus.Faker faker = new Bogus.Faker("fr");

            // Add more cases for different types if needed
            if (propertyInfo.PropertyType == typeof(string))
            {
                return faker.Random.String2(15);
            }
            else if (propertyInfo.PropertyType == typeof(DateTime))
            {
                return faker.Date.Soon();
            }
            else if(propertyInfo.PropertyType == typeof(int))
            {
                return faker.Random.Number(0, 999999);
            }
            else if (propertyInfo.PropertyType.IsEnum)
            {
                return GetRandomEnumValue(propertyInfo.PropertyType);
            }
            else if (IsComplexType(propertyInfo.PropertyType))
            {
                // Handle complex types by recursively generating random values for their properties
                object instance = Activator.CreateInstance(propertyInfo.PropertyType);
                PropertyInfo[] subProperties = propertyInfo.PropertyType.GetProperties();

                foreach (var subProperty in subProperties)
                {
                    // Set the value for each property in the complex type
                    subProperty.SetValue(instance, GenerateRandomValue(subProperty));
                }

                return instance;
            }
            else if (IsNullable(propertyInfo.PropertyType))
            {
                return null;
            }

            // Throw an exception for unsupported types
            throw new ArgumentException($"{propertyInfo.PropertyType} is not supported by the auto-generator.");
        }

        private static Expression<Func<T, object>> CreatePropertyExpression<E>(PropertyInfo property)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var propertyAccess = Expression.Property(parameter, property);

            if (propertyAccess.Type == typeof(DateTime) 
                || propertyAccess.Type.IsEnum 
                || propertyAccess.Type == typeof(int))
            {
                var convertExpression = Expression.Convert(propertyAccess, typeof(object));
                return Expression.Lambda<Func<T, object>>(convertExpression, parameter);
            }

            return Expression.Lambda<Func<T, object>>(propertyAccess, parameter); ;
        }

        private static int GetRandomEnumValue(Type enumType)
        {
            Array values = Enum.GetValues(enumType);
            Random random = new Random();
            int randomValue = random.Next(values.Length);
            return randomValue;
        }

        private static bool IsComplexType(Type type)
        {
            // Check if the type is a class and not one of the simple types you handle
            return type.IsClass && type != typeof(string) && type != typeof(DateTime) && type != typeof(int) && !type.IsEnum;
        }     
        
        private static bool IsNullable(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }


    }
}
