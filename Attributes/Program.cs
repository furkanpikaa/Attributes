using System;

namespace Attributes  // iş kurallarını belirlemek için kullanırız.
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer { Id = 1, LastName = "Sırdaş", Age = 22 };
            CustomerDal customerDal = new CustomerDal();
            customerDal.add(customer);
            Console.ReadLine();
        }
    }
    [ToTable("Customers")]
    [ToTable("TblCustomers")]
    class Customer
    {
        public int Id { get; set; }
        [RequiredProperty]  
        public string FirstName { get; set; }
        [RequiredProperty]
        public string LastName { get; set; }
        [RequiredProperty]
        public int Age { get; set; }
    }

    class CustomerDal
    {
        [Obsolete("Don`t use add , instead use addnew method")] // eski kullanılan 
        public void add(Customer customer)
        {
            Console.WriteLine("{0},{1},{2},{3} , Added!"
                ,customer.Id ,customer.FirstName , customer.LastName , customer.Age);
        }

        public void addnew(Customer customer)
        {
            Console.WriteLine("{0},{1},{2},{3} , Added!"
                , customer.Id, customer.FirstName, customer.LastName, customer.Age);
        }
    }

    [AttributeUsage(AttributeTargets.Property , AllowMultiple = true)]
    class RequiredPropertyAttribute:Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Class , AllowMultiple = true)]
    class ToTableAttribute : Attribute
    {
        string _tableName;
        public ToTableAttribute(string tableName)
        {
            _tableName = tableName;
        }
    }



}
