using System;
using System.ComponentModel;

namespace MVVM_CalculatorApplication.Model
{
    public class CalculatorModel : INotifyPropertyChanged, IDataErrorInfo
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

        public bool HasInputError { get; set; }

        public bool IsFirstNumberValid { get; set; }

        public bool IsSecondNumberValid { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string propertyName]
        {
            get
            {
                var result = string.Empty;

                if (propertyName == nameof(FirstNumber))
                {
                    if (!string.IsNullOrEmpty(FirstNumber))
                    {
                        try
                        {
                            var isFirstNumberValid = double.Parse(FirstNumber);
                            IsFirstNumberValid = true;
                        }
                        catch (Exception)
                        {
                            IsFirstNumberValid = false;
                            HasInputError = true;
                            return "Invalid Inputs, only numeric values allowed";
                        }
                    }
                }

                if (propertyName == nameof(SecondNumber))
                {
                    if (!string.IsNullOrEmpty(SecondNumber))
                    {
                        try
                        {
                            var isFirstNumberValid = double.Parse(SecondNumber);
                            IsSecondNumberValid = true;
                        }
                        catch (Exception)
                        {
                            IsSecondNumberValid = false;
                            HasInputError = true;
                            return "Invalid Inputs, only numeric values allowed";
                        }
                    }
                }

                //if first number and second number is valid then it has no input Errors
                HasInputError = IsFirstNumberValid && IsSecondNumberValid ? false : true;
                return result;
            }
        }
    }
}
