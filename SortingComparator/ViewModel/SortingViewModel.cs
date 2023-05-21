using OxyPlot;
using OxyPlot.Legends;
using OxyPlot.Series;
using SortingComparator.Commands;
using SortingComparator.Models;
using SortingComparator.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SortingComparator.ViewModel
{
    public class SortingViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand StartSortCommand { get; set; }

        private SortingService _sortingService;

        private string maxLengthInput;

        public string MaxLengthInput
        {
            get => maxLengthInput;
            set
            {
                if (maxLengthInput != value)
                {
                    maxLengthInput = value;
                    OnPropertyChanged(nameof(MaxLengthInput));
                }
            }
        }

        private PlotModel _plotModel;

        public PlotModel PlotModel
        {
            get => _plotModel;
            set
            {
                _plotModel = value;
                OnPropertyChanged(nameof(PlotModel));
            }
        }

        private ObservableCollection<SortingsResults> _sortingsRes = new ObservableCollection<SortingsResults>();

        public ObservableCollection<SortingsResults> SortingsRes
        {
            get => _sortingsRes;
            set
            {
                _sortingsRes = value;
                OnPropertyChanged(nameof(SortingsRes));
            }
        }

        public SortingViewModel() { 
            _sortingService = new SortingService();
            StartSortCommand = new StartSortCommand(Sort);
            PlotModel = new PlotModel() { Title = "Wynik Sortowań" };
            SortingsRes = new ObservableCollection<SortingsResults>();
        }

        public void Sort()
        {
            PlotModel.Series.Clear();
            SortingsRes.Clear();
            PlotModel.Legends.Clear();
            PlotModel.Legends.Add(new Legend()
            {
                LegendTitle = "Legenda",
                LegendPosition = LegendPosition.TopLeft,
            });
            List<SortingsResults> results = _sortingService.RunTest(Int32.Parse(maxLengthInput));
            foreach(SortingsResults result in results) {
               SortingsRes.Add(result);
                LineSeries line = new LineSeries();
                foreach(DataPoint point in result.DataPoints)
                {
                    line.Points.Add(point);
                }
                line.Title = result.Name;
                PlotModel.Series.Add(line);
            }
            PlotModel.InvalidatePlot(true);

            OnPropertyChanged(nameof(SortingsRes));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
