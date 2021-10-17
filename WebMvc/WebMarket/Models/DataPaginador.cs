using System.Collections.Generic;

namespace WebMarket.Models
{
    public class DataPaginador<T>
    {
        public List<T> List { get; set; }
        public string Pagi_infor { get; set; }
        public string Pagi_navegacion { get; set; }
        public T Input { get; set; }
        public string Seach { get; set; }
    }
}
