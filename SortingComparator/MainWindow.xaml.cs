using OxyPlot;
using OxyPlot.Series;
using SortingComparator.Models;
using SortingComparator.Services;
using SortingComparator.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SortingComparator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        SortingService sortingService = new SortingService();
        SortingViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new SortingViewModel();
            DataContext = viewModel;

            viewModel.PropertyChanged += ViewModel_PropertyChanged;
           
        }

        private void ViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(viewModel.SortingsRes))
            {
               AddDynamicColumns();
            }
        }

        private void AddDynamicColumns()
        {
            dataGrid.Columns.Clear();

            List<string> columnNames = new List<string>();

            DataTable dataTable = new DataTable();
            dataTable.Clear();

            DataColumn sizeColumn = new DataColumn("rozmiar");
            dataTable.Columns.Add(sizeColumn);
            columnNames.Add("rozmiar");
            DataGridTextColumn sizeDataGridColumn = new DataGridTextColumn();
            sizeDataGridColumn.Header = "rozmiar";
            sizeDataGridColumn.Binding = new Binding("rozmiar");
            dataGrid.Columns.Add(sizeDataGridColumn);


            foreach (SortingsResults result in viewModel.SortingsRes)
            {
                DataColumn column = new DataColumn(result.Name);
                dataTable.Columns.Add(column);
                columnNames.Add(result.Name);
                DataGridTextColumn dataGridColumn = new DataGridTextColumn();
                dataGridColumn.Header = result.Name;
                dataGridColumn.Binding = new Binding(result.Name);
                dataGrid.Columns.Add(dataGridColumn);
            }

            List<TableSortResults> dataSort = TableSortResultsMapper.Map(viewModel.SortingsRes);

            foreach (TableSortResults sort in dataSort)
            {
                DataRow row = dataTable.NewRow();
                row["rozmiar"] = sort.Size;
                foreach(KeyValuePair<string, double> entry in sort.Data)
                {
                    row[entry.Key] = entry.Value;
                }
                dataTable.Rows.Add(row);
            }
              

            dataGrid.ItemsSource = dataTable.DefaultView;
        }
    }
}
