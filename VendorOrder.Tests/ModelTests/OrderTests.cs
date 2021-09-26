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
      Order newOrder = new Order(title, description, price, date);

      string resultTitle = newOrder.Title;
      string resultDescription = newOrder.Description;
      string resultDate = newOrder.Date;
      string resultPrice = newOrder.Price;

      Assert.AreEqual(title, resultTitle);
      Assert.AreEqual(description, resultDescription);
      Assert.AreEqual(date, resultDate);
      Assert.AreEqual(price, resultPrice);
    }

    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      string title = "A Title";
      string description = "This is a test";
      string date = "May 1st 2021";
      string price = "23";
      Order newOrder = new Order(title, description, price, date);

      string updatedDescription = "10 bread and 30 bagels by thursday";
      newOrder.Description = updatedDescription;
      string result = newOrder.Description;

      Assert.AreEqual(updatedDescription, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_OrderList()
    {
      List<Order> newList = new List<Order> {};
      List<Order> result = Order.GetAll();
      Assert.AreEqual(newList, result);
    }
  }
}