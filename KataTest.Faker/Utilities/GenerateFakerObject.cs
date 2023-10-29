using Bogus;
using KataTest.ProjectToTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace KataTest.Faker.Utilities
{
    public class GenerateFakerObject<T> : IGenerateObject<T> where T : class
    {
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

        private static object GenerateRandomValue(PropertyInfo propertyInfo)
        {
            Bogus.Faker faker = new Bogus.Faker();

            // Add more cases for different types if needed
            if (propertyInfo.PropertyType == typeof(string))
            {
                return faker.Random.String(255);
            }
            else if (propertyInfo.PropertyType == typeof(DateTime))
            {
                return faker.Date.Soon();
            }
            else if(propertyInfo.PropertyType == typeof(int))
            {
                return faker.Random.Number(0, 999999);
            }
            else if (propertyInfo.PropertyType == typeof(Enum))
            {
                //TODO à revoir
                return 0;
            }
            // Add more cases as needed

            // Default case for unsupported types
            return null;
        }

        private static Expression<Func<T, object>> CreatePropertyExpression<E>(PropertyInfo property)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var propertyAccess = Expression.Property(parameter, property);

            if (propertyAccess.Type == typeof(DateTime))
                return Expression.Lambda<Func<T, object>>(propertyAccess, parameter);

            return Expression.Lambda<Func<T, object>>(propertyAccess, parameter); ;
        }
    }
}
