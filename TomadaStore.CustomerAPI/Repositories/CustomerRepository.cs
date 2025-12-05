using Dapper;
using Microsoft.Data.SqlClient;
using TomadaStore.CustomerAPI.Data;
using TomadaStore.CustomerAPI.Repositories;
using TomadaStore.Models.Models;
using TomadaStore.Models.DTOs.Customer;

namespace TomadaStore.CustomerAPI.Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly ILogger<CustomerRepository> _logger;
        private readonly SqlConnection _connection;

        public CustomerRepository(ILogger<CustomerRepository> logger, ConnectionDB connection)
        {
            _logger = logger;
            _connection = connection.GetConnection();
        }

        public async Task<List<CustomerResponseDTO>> GetAllCustomerAsync()
        {
            try 
            {
                var sqlSelect = @"SELECT iD, FirstName, LastName, Email, PhoneNumber FROM [dbo].[Customers]";
                var customers = await _connection.QueryAsync<CustomerResponseDTO>(sqlSelect);
                return customers.ToList();
                    
                
            
            }
            catch (SqlException sqlex)
            {
                _logger.LogError($"SQL Error inserting customer: {sqlex.StackTrace}");
                throw new Exception(sqlex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error inserting customer: {ex.Message}");
                throw;
            }
        }

        public async Task<CustomerResponseDTO?> GetCustomerByIdAsync(int Id)
        {
            try
            {
                var sqlSelect = @"SELECT Id, FirstName, LastName, Email, PhoneNumber 
                                FROM [dbo].[Customers]
                                 WHERE Id = @Id";
                var customer = await _connection.QueryFirstOrDefaultAsync<CustomerResponseDTO>(sqlSelect, new {Id = Id});
                return customer;
            }
            catch (SqlException sqlex)
            {
                _logger.LogError($"SQL Error found a customer: {sqlex.StackTrace}");
                throw new Exception(sqlex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error foun a customer: {ex.Message}");
                throw;
            }
        }

        public async Task InsertCustomerAsync(CustomerRequestDTO customer)
        {
            try
            {
                var insertSql = "INSERT INTO Customers (FirstName, LastName, Email, PhoneNumber) " +
                                "VALUES (@FirstName, @LastName, @Email, @PhoneNumber)";
                await _connection.ExecuteAsync(insertSql, new
                {
                    customer.FirstName,
                    customer.LastName,
                    customer.Email,
                    customer.PhoneNumber
                });
            }
            catch (SqlException sqlex)
            {
                _logger.LogError($"SQL Error inserting customer: {sqlex.StackTrace}");
                throw new Exception(sqlex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error inserting customer: {ex.Message}");
                throw;
            }
        }
    }
}
