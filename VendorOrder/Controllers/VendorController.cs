using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using VendorOrder.Models;

namespace VendorOrder.Controllers
{
  public class VendorController : Controller
  {
    [HttpGet("/vendor")]
    public ActionResult Index()
    {
      List<Vendor> allVendors = Vendor.GetAll();
      return View(allVendors);
    }

    [HttpGet("/vendor/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/vendor")]
    public ActionResult Create(string vendorName, string vendorDescription)
    {
      Vendor newVendor = new Vendor(vendorName, vendorDescription);
      return RedirectToAction("Index");
    }

    [HttpGet("/vendor/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor selectedVendor = Vendor.Find(id);
      List<Order> venderOrders = selectedVendor.Orders;
      model.Add("vendor", selectedVendor);
      model.Add("order", venderOrders);
      return View(model);
    }

    [HttpPost("/vendor/{vendorId}/orders")]
    public ActionResult Create(int vendorId, string title, string description, string price, string date)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor chosenVendor = Vendor.Find(vendorId);
      Order newOrder = new Order(title, description, price, date);
      chosenVendor.AddOrder(newOrder);
      List<Order> vendorsOrders = chosenVendor.Orders;
      model.Add("orders", vendorsOrders);
      model.Add("vendor", chosenVendor);
      return View("Show", model);
    }
  }
}