using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorOrder.Models;
using System.Collections.Generic;
using System;

namespace VendorOrder.Tests
{
  [TestClass]
  public class ItemTests : IDisposable
  {
    public void Dispose()
    {
      Order.ClearAll();
    }

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
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnOrders_OrderList()
    {
      string title = "A Title";
      string description = "This is a test";
      string date = "May 1st 2021";
      string price = "23";
      
      string title02 = "A Title";
      string description02 = "This is a test";
      string date02 = "May 1st 2021";
      string price02 = "23";

      Order newOrder01 = new Order(title, description, price, date);
      Order newOrder02 = new Order(title02, description02, price02, date02);
      List<Order> newList = new List<Order> {newOrder01, newOrder02};
      List<Order> result = Order.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetId_OrdersInstantiateWithAnIdAndGetterReturn_Int()
    {
      string title = "A Title";
      string description = "This is a test";
      string date = "May 1st 2021";
      string price = "23";

      Order newOrder = new Order(title, description, price, date);
      int result = newOrder.Id;
      Assert.AreEqual(1, result);
    }

    [TestMethod]
      public void Find_ReturnsCorrectOrder_Order()
      {
        string title = "A Title";
        string description = "This is a test";
        string date = "May 1st 2021";
        string price = "23";
        
        string title02 = "A Title";
        string description02 = "This is a test";
        string date02 = "May 1st 2021";
        string price02 = "23";

        Order newOrder01 = new Order(title, description, price, date);
        Order newOrder02 = new Order(title02, description02, price02, date02);
        Order result = Order.Find(2);
        Assert.AreEqual(newOrder02, result);
      }
  }
}