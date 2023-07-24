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
        private double m_firstNumber;
        private double m_secondNumber;
        private double m_result;

        public double FirstNumber
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

        public double SecondNumber
        {
            get
            {
                return m_secondNumber;
            }
            set
            {
                m_secondNumber = value;
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
