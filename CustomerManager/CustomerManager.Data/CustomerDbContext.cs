﻿using CustomerManager.Data.Interfaces;
using CustomerManager.Domain;
using Dapper;
using Microsoft.Data.SqlClient; 
using Newtonsoft.Json;
using System.Data;

namespace CustomerManager.Data
{
    public class CustomerDbContext : IRepository<Customer>
    {
        string _connectionString; 

        public CustomerDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
         

        public List<Customer> Get(Customer customer)
        {
            IEnumerable<Customer> data;
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                data = conn.Query<Customer>(
                           "select * from dbo.Customers WHERE (Id= @Id or @Id=0)",
                           customer
                          );
            }
            return data.ToList();
        }

        public int Insert(Customer customer, Guid createUser)
        {

            int affectedRows = 0;
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                affectedRows = conn.Execute(
                       "insert into Customers (Text, CreateUser) VALUES (@Text, @CreateUser)",
                      new { Text = JsonConvert.SerializeObject(customer), CreateUser = createUser }
                      );
            }
            return affectedRows;
        }

        public int Update(Customer customer, Guid updateUser)
        {

            int affectedRows = 0;
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                affectedRows = conn.Execute(
                       "update Customers  set Text = @Text, LastUpdateUser = @UpdateUser WHERE Id = @Id",
                      new { Text = JsonConvert.SerializeObject(customer), UpdateUser = updateUser, Id= customer.Id }
                      );
            }
            return affectedRows;
        }
    }
}