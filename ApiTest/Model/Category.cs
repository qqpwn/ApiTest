using System.Text.Json.Serialization;

namespace ApiTest.Model
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        
        public virtual List<Products> Products { get; set; }

    }
}
