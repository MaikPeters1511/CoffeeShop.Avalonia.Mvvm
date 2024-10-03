namespace Avalonia.CoffeeShop.ViewModels;

public class CustomerItemViewModel(Customer model) : ViewModelBase
{
    private Customer _model = model;

    public string? FirstName
    {
        get => _model.FirstName;
        set
        {
            if (_model.FirstName != value)
            {
                _model.FirstName = value;
                OnPropertyChanged();
            }
        }
    }

    public string? LastName
    {
        get => _model.LastName;
        set
        {
            if (_model.LastName != value)
            {
                _model.LastName = value;
                OnPropertyChanged();
            }
        }
    }

    public bool IsDeveloper
    {
        get => _model.IsDeveloper;
        set
        {
            if (_model.IsDeveloper != value)
            {
                _model.IsDeveloper = value;
                OnPropertyChanged();
            }
        }
    }
}