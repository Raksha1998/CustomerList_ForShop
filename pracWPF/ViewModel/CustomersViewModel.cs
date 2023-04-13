using pracWPF.Data;
using pracWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pracWPF.ViewModel
{

    public class CustomersViewModel : ViewModelBase
    {
        private readonly ICustomerDataProvider _customerDataProvider;
        private Customer? _selectedCustomer;

        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
        }

        public ObservableCollection<Customer> Customers { get; } = new();

        public Customer? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                RaisePropertyChanged();
            }
        }
        
        public async Task LoadAsync()
        {
            if (Customers.Any())
            {
                return;
            }
            if (Customers is not null)
            {
                var customers = await _customerDataProvider.GetAllAsync();
                foreach (var Customer in customers)
                {
                    Customers.Add(Customer);
                }
            }
        }

        internal void Add()
        {
            var cutomer = new Customer { FirstName = "New" };
            Customers.Add(cutomer);
            SelectedCustomer = cutomer;
        }

    
    }
}
