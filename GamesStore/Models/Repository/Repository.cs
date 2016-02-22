using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data;

namespace GamesStore.Models.Repository
{
    public class Repository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                product = context.Products.Add(product);
            }
            else
            {
                Product dbProduct = context.Products.Find(product.ProductID);
                if (dbProduct != null)
                {
                    dbProduct.Name = product.Name;
                    dbProduct.Description = product.Description;
                    dbProduct.Price = product.Price;
                    dbProduct.Category = product.Category;
                    dbProduct.Image = product.Image;
                    dbProduct.featured = product.featured;
                    dbProduct.Disabled = product.Disabled;
                    dbProduct.hot = product.hot;
                }
            }
            context.SaveChanges();



        }
        public  void SaveCustomer(Customer customer)
        {
            if (customer.CustomerId == 0)
            {
                customer = context.Customers.Add(customer);
            }
            else
            {
                Customer dbCustomer = context.Customers.Find(customer.CustomerId);
                if(dbCustomer != null)
                {
                    dbCustomer.Name = customer.Name;
                    dbCustomer.Line1 = customer.Line1;
                    dbCustomer.Line2 = customer.Line2;
                    dbCustomer.City = customer.City;
                    dbCustomer.State = customer.State;
                    dbCustomer.PostalCode = customer.PostalCode;
                    dbCustomer.Email = customer.Email;
                    dbCustomer.Password = customer.Password;

                }

            }
            context.SaveChanges();

        }
        public Customer GetCustomer(string email, string password)
        {
            Customer dbCustomer = context.Customers.Where(c => c.Email == email).First();
            if(dbCustomer != null)
            {
                return dbCustomer;
            }
            return dbCustomer = new Customer();
        }

        public void DeleteProduct(Product product)
        {
            IEnumerable<Order> orders = context.Orders
            .Include(o => o.OrderLines.Select(ol => ol.Product))
            .Where(o => o.OrderLines.Count(ol => ol.Product
            .ProductID == product.ProductID) > 0).ToArray();
            foreach (Order order in orders)
            {
                context.Orders.Remove(order);
            }
            context.Products.Remove(product);
            context.SaveChanges();
        }

        public IEnumerable<Order> Orders
        {
            get
            {
                return context.Orders
                    .Include(o => o.OrderLines
                    .Select(ol => ol.Product));
            }
        }
        public void SaveOrder(Order order)
        {
            if (order.OrderId == 0)
            {
                order = context.Orders.Add(order);

                foreach (OrderLine line in order.OrderLines)
                {
                    context.Entry(line.Product).State
                        = System.Data.Entity.EntityState.Modified;
                }
            }
            else
            {
                Order dbOrder = context.Orders.Find(order.OrderId);
                if (dbOrder != null)
                {
                    dbOrder.Name = order.Name;
                    dbOrder.Line1 = order.Line1;
                    dbOrder.Line2 = order.Line2;
                    dbOrder.Line3 = order.Line3;
                    dbOrder.City = order.City;
                    dbOrder.State = order.State;
                    dbOrder.GiftWrap = order.GiftWrap;
                    dbOrder.Dispatched = order.Dispatched;
                }
            }
            context.SaveChanges();
        }

        public IEnumerable<Product> Hot
        {
            get
            {
                return context.Products.OrderByDescending(
                    p => context.OrderLines
                    .Where(ol => ol.Product.ProductID == p.ProductID)
                    .Sum(l => l.Quantity));
            }
        }
        public bool ValidateAccount(string email, string password)
        {
            Customer c = GetCustomer(email, password);
            if(c != null)
            {
                if(c.Email == email && c.Password == password)
                {
                    return true;
                }

            }
            return false;
        }
    }
}