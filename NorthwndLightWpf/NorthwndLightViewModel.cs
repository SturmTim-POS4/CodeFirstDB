using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using CodeFirstDB;
using Microsoft.EntityFrameworkCore;
using MvvmTools;

namespace NorthwndLightWpf;

public class NorthwndLightViewModel : ObservableObject
{
    private NorthwndLightDbContext _db;

    private Random _random = new Random();

    public NorthwndLightViewModel Init(NorthwndLightDbContext db)
    {
        _db = db;
        Customers = _db.Customers
            .Include(x => x.Orders)
            .ThenInclude(x => x.OrderDetails)
            .ThenInclude(x => x.Product)
            .AsObservableCollection();
        Products = _db.Products.AsObservableCollection();
        return this;
    }

    public ObservableCollection<Order> _employeeOrders;

    public ObservableCollection<Order> EmployeeOrders
    {
        get => _employeeOrders;
        set
        {
            _employeeOrders = value;
            NotifyPropertyChanged(nameof(EmployeeOrders));
        }
    }

    public ObservableCollection<Product> _products;

    public ObservableCollection<Product> Products
    {
        get => _products;
        set
        {
            _products = value;
            NotifyPropertyChanged(nameof(Products));
        }
    }

    public ObservableCollection<Customer> _Customers;

    public ObservableCollection<Customer> Customers
    {
        get => _Customers;
        set
        {
            _Customers = value;
            NotifyPropertyChanged(nameof(Customers));
        }
    }

    public DateTime SelectedDeliveryDate { get; set; }

    public string _EmployeeFilter;

    public string EmployeeFilter
    {
        get => _EmployeeFilter;
        set
        {
            _EmployeeFilter = value;
            FilteredEmployees = _db.Employees.Where(x => x.Lastname.StartsWith(_EmployeeFilter)).AsObservableCollection();
        }
    }

    public ObservableCollection<Employee> _filteredEmployees;

    public ObservableCollection<Employee> FilteredEmployees
    {
        get => _filteredEmployees;
        set
        {
            _filteredEmployees = value;
            NotifyPropertyChanged(nameof(FilteredEmployees));
        }
    }

    public Employee _SelectedEmployee;

    public Employee SelectedEmployee
    {
        get => _SelectedEmployee;
        set
        {
            _SelectedEmployee = value;
            EmployeeOrders = _db.Orders.Where(x => x.Shipment.Employee == SelectedEmployee)
                .Include(x => x.Customer)
                .Include(x => x.Shipment)
                .ThenInclude(x => x.Employee)
                .OrderBy(x => x.Shipment.PlanDate)
                .ThenBy(x => x.Shipment.SequenceNr)
                .AsObservableCollection();
        }
    }

    public string NewProductName { get; set; }

    public Order SelectedOrder { get; set; }

    public ICommand AddProduct => new RelayCommand<string>(
        _ =>
        {
            _db.Products.Add(new Product()
            {
                Description = NewProductName,
                Price = _random.Next(1,100),
                Weight = _random.Next(10,100)
            });
            _db.SaveChanges();
        }
        );
    
    public ICommand AddShipment => new RelayCommand<string>(
        _ =>
        {
            _db.Shipments.Add(new Shipment()
            {
                EmployeeId = SelectedEmployee.Id,
                PlanDate = SelectedDeliveryDate,
                SequenceNr = 1,
                
            });
            
            _db.SaveChanges();

            SelectedOrder.ShipmentId = _db.Shipments.Select(x => x.Id).Max();
            
            _db.SaveChanges();
        }
    );
}

