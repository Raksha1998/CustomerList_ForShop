using pracWPF.Data;
using pracWPF.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace pracWPF.View
{
    public partial class CutomersView : UserControl
    {
        private CustomersViewModel _viewModel;

        public CutomersView()
        {
            InitializeComponent();
            _viewModel=new CustomersViewModel(new CustomerDataProvider());
            DataContext = _viewModel;
            Loaded += CutomersView_Loaded;
        }

        

        private async void CutomersView_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();
        }

        private void ButtonMoveNavigation_Click(object sender, RoutedEventArgs e)
        {
            var column = (int)CustomerListGrid.GetValue(Grid.ColumnProperty);
            var newColumn = column == 0 ? 2 : 0;
            CustomerListGrid.SetValue(Grid.ColumnProperty, newColumn);
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Add();
        }
    }
}
