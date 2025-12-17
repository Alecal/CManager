using CManager.Domain.Interfaces;
using CManager.Domain.Models;
using System.Text.Json;

namespace CManager.Infrastructure.Repo;

public class CustomerRepo : ICustomerRepo
{
    private readonly string _filePath;
    private readonly string _directoryPath;
    private readonly JsonSerializerOptions _jsonOptions;

    public CustomerRepo(string directoryPath = "Data", string fileName = "list.json")
    {
        _directoryPath = directoryPath;
        _filePath = Path.Combine(_directoryPath, fileName);

        _jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
        };
    }

    public List<Customer> GetAll()
    {
        if (!File.Exists(_filePath))
        {
            return [];
        }

        try
        {
            var json = File.ReadAllText(_filePath);
            var customers = JsonSerializer.Deserialize<List<Customer>>(json, _jsonOptions);
            return customers ?? [];

        }
        catch (Exception ex)
        {
            // Error om det inte går att ladda in customers
            throw;
        }
    }

    public bool AddCustomer(List<Customer> customers)
    {
        if (customers == null)
            return false;

        try
        {
            var json = JsonSerializer.Serialize(customers, _jsonOptions);

            if (!Directory.Exists(_directoryPath))
                Directory.CreateDirectory(_directoryPath);

            File.WriteAllText(_filePath, json);
            return true;
        }
        catch (Exception ex)
        {
            // Gör errormeddelande här om det inte går att spara!!
            return false;
        }

    }

    public Customer GetCustomer(string id)
    {
        throw new NotImplementedException();
    }

    public bool Delete(string id)
    {
        throw new NotImplementedException();
    }
}

