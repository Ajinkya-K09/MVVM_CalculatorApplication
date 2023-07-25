using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_CalculatorApplication.Model
{
    public class CalculatorModel : INotifyPropertyChanged
    {
        private string m_firstNumber;
        private string m_secondNumber;
        private double m_result;

        public string FirstNumber
        {
            get
            {
                return m_firstNumber;
            }
            set
            {
                m_firstNumber = value;
                RaisePropertyChanged(nameof(FirstNumber));
            }
        }

        public string SecondNumber
        {
            get
            {
                return m_secondNumber;
            }
            set
            {
                m_secondNumber = value;
                RaisePropertyChanged(nameof(SecondNumber));
            }
        }

        public double Result
        {
            get
            {
                return m_result;
            }
            set
            {
                m_result = value;
                RaisePropertyChanged(nameof(Result));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
