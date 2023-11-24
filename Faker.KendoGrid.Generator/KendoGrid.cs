using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Faker.KendoGrid.Generator
{
    public class KendoGrid
    {
        public List<Columns> Columns { get; set; }
        public DataSource DataSource { get; set; }

        public KendoGrid(List<Columns> columns, DataSource dataSource)
        {
            Columns = columns;
            DataSource = dataSource;
        }

        public string ToJson()
        {
            var gridData = new
            {
                columns = Columns,
                dataSource = DataSource
            };

            return JsonConvert.SerializeObject(gridData, Newtonsoft.Json.Formatting.Indented);
        }
    }

    public class Columns
    {
        public string Title { get; set; }
        public string Field { get; set; }
    }  
    
    public class DataSource
    {
        public Columns Column { get; set; }
        public object Value { get; set; }


    }
}
