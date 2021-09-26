using System.Collections.Generic;

namespace VendorOrder.Models
{
  public class Vendor
  {
    private static List<Vendor> _instances = new List<Vendor> {};
    public string Name { get; set; };
    public int Id { get; }
    public List<Item> Items { get; set; }

    public Vendor(string vendorName)
    {
      
    }
  }
}