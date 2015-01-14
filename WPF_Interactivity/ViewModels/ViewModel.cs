using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Interactivity.Commands;
using WPF_Interactivity.Models;

namespace WPF_Interactivity.ViewModels
{
    /// <summary>
    /// This is the ViewModel class for the below needs:
    /// 1. Implements INotifyPropertyChanged interface to generate changed notification.
    /// 2. Defines public string type properties of name Criteria and Filter for result filteration.
    /// 3. Defines Products property of the type  ObservableCollection<Product> for string filtered products based upon Criteria and Filter
    /// 4. Define 'Get' method to retrieve Product information from DataAccess class.
    /// 5. Define public Command property 'FilterCommand' to execute 'Get' method. 
    /// </summary>
    public class FilterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        ObservableCollection<Product> _Products;

        public ObservableCollection<Product> Products
        {
            get { return _Products; }
            set { _Products = value; }
        }

        DataAccess objDs;

        
        ObservableCollection<string> _Properties;

        public ObservableCollection<string> Properties
        {
            get { return _Properties; }
            set { _Properties = value; }
        }

        void LoadProperties()
        {
            Properties.Add("ProductName");
            Properties.Add("Manufacturer");
            Properties.Add("DealerName");
        }

        public FilterViewModel()
        {
            Products = new ObservableCollection<Product>();
            Properties = new ObservableCollection<string>();
            objDs = new DataAccess();
            LoadProperties();
            FilterCommand = new RelayCommand(Get); 
        }

        public RelayCommand FilterCommand { get; set; }

        string _Criteria;

        public string Criteria
        {
            get { return _Criteria; }
            set 
            {
                _Criteria = value;
                OnPropertyChanged("Criteria");
            }
        }

        string _Filter;

        public string Filter
        {
            get { return _Filter; }
            set 
            {
                _Filter = value;
                OnPropertyChanged("Filter");
            }
        }



        void Get()
        {
            Products.Clear();
            foreach (var item in objDs.GetProducts(Criteria,Filter))
            {
                Products.Add(item);
            }
        }

        void OnPropertyChanged(string pName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(pName));
            }
        }
    }

}
