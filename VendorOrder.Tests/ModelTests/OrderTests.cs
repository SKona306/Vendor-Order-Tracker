using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorOrder.Models;
using System.Collections.Generic;
using System;

namespace VendorOrder.Tests
{
  [TestClass]
  public class ItemTests
  {
    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      Order newOrder = new Order("test", "this is a test", "10", "may 10th");
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }

    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrderAndReturnsCorrectProperties_True()
    {
      string title = "A Title";
      string description = "This is a test";
      string date = "May 1st 2021";
      string price = "23";
      Order newOrder = new Order(title, description, date, price);
      string resultTitle = newOrder.Title;
      string resultDescription = newOrder.Description;
      string resultDate = newOrder.Date;
      string resultPrice = newOrder.Price;
      Assert.AreEqual(title, resultTitle);
      Assert.AreEqual(description, resultDescription);
      Assert.AreEqual(date, resultDate);
      Assert.AreEqual(price, resultPrice);
    }
  }
}