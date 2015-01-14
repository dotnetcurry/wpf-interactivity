using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace WPF_Interactivity.Models
{
    /// <summary>
    /// The Product Entity Class.
    /// </summary>
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Manufacturer { get; set; }
        public string DealerName { get; set; }
        public int Price { get; set; }
    }


    /// <summary>
    /// Product Database class
    /// This stores Product Information
    /// </summary>
    public class ProductDatabase : ObservableCollection<Product>
    {
        public ProductDatabase()
        {
            Add(new Product() {ProductId=1,ProductName="Router-16",Manufacturer="MS-Tech",DealerName="MRS",Price=1000});
            Add(new Product() { ProductId = 2, ProductName = "DVDs-10GB", Manufacturer = "Power-Sol", DealerName = "LS", Price = 1200 });
            Add(new Product() { ProductId = 3, ProductName = "Router-32", Manufacturer = "Power-Sol", DealerName = "MRS", Price = 1200 });
            Add(new Product() { ProductId = 4, ProductName = "MotherBoard-DV", Manufacturer = "MS-Tech", DealerName = "LMS", Price = 1050 });
            Add(new Product() { ProductId = 5, ProductName = "DVDs-16GB", Manufacturer = "MR-Sol", DealerName = "TMS", Price = 1050 });
            Add(new Product() { ProductId = 6, ProductName = "Router-8", Manufacturer = "MS-Tech", DealerName = "MRS", Price = 1010 });
            Add(new Product() { ProductId = 7, ProductName = "Monitors-GL", Manufacturer = "Power-Tech", DealerName = "LMS", Price = 1200 });
            Add(new Product() { ProductId = 8, ProductName = "MotherBoard-V7", Manufacturer = "IT-Sol", DealerName = "TMS", Price = 1100 });
            Add(new Product() { ProductId = 9, ProductName = "RAM-DDR2", Manufacturer = "Power-Sol", DealerName = "TMS", Price = 1230 });
            Add(new Product() { ProductId = 10, ProductName = "RAM-DDR4", Manufacturer = "MR-Sol", DealerName = "MRS", Price = 4000 });
            Add(new Product() { ProductId = 11, ProductName = "DVD-RW-60S", Manufacturer = "Power-Tech", DealerName = "MRS", Price = 2200 });
            Add(new Product() { ProductId = 12, ProductName = "Monitor-HD", Manufacturer = "MS-Tech", DealerName = "LMS", Price = 4400 });
            Add(new Product() { ProductId = 13, ProductName = "Graphics-Card-3D", Manufacturer = "MS-Sol", DealerName = "LMS", Price = 4200 });
            Add(new Product() { ProductId = 14, ProductName = "Router-16", Manufacturer = "Power-Sol", DealerName = "TMS", Price = 1040 });
            Add(new Product() { ProductId = 15, ProductName = "RAM-DDR3", Manufacturer = "MR-Sol", DealerName = "TMS", Price = 1020 });
            Add(new Product() { ProductId = 16, ProductName = "Monitor-3D", Manufacturer = "MR-Sol", DealerName = "MRS", Price = 5100 });
            Add(new Product() { ProductId = 17, ProductName = "MotherBoard-3D", Manufacturer = "Power-Tech", DealerName = "LMS", Price = 2200 });
            Add(new Product() { ProductId = 18, ProductName = "Modem-16X", Manufacturer = "MR-Sol", DealerName = "TMS", Price = 5600 });
            Add(new Product() { ProductId = 19, ProductName = "Modem-32X", Manufacturer = "Power-Sol", DealerName = "MRS", Price = 1056 });
            Add(new Product() { ProductId = 20, ProductName = "Router-16", Manufacturer = "MS-Tech", DealerName = "LMS", Price = 1000 });
        }
    }


 
    /// <summary>
    /// The DataAccess class. This contains GetProducts method which accepts
    /// search criretia and filter value to search vaules based upon the criteria
    /// </summary>
    public class DataAccess
    {
        /// <summary>
        /// Method to filter Data 
        /// </summary>
        /// <param name="criteria">The Property name based on which data will be searched</param>
        /// <param name="filter">The values which will be used for matching the property value</param>
        /// <returns></returns>
        public ObservableCollection<Product> GetProducts(string criteria, string filter)
        {
            ObservableCollection<Product> Products = new ObservableCollection<Product>();
            List<Product> pds = new List<Product>();
            
            if (criteria.Length != 0 && filter.Length != 0)
            {
                switch (criteria)
                {
                    case "ProductName":
                        pds = (from p in new ProductDatabase()
                               where p.ProductName.StartsWith(filter)
                               select p).ToList();
                        break;
                    case "Manufacturer":
                        pds = (from p in new ProductDatabase()
                               where p.Manufacturer.Contains(filter)
                               select p).ToList();
                        break;
                    case "DealerName":
                        pds = (from p in new ProductDatabase()
                               where p.DealerName.Contains(filter)
                               select p).ToList();
                        break;
                }
                foreach (var item in pds)
                {
                    Products.Add(item);
                }
            }
            
            return Products;
        }
    }
}
