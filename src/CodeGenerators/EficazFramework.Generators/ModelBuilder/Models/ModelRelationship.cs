using System.ComponentModel;

namespace EficazFramework.Generators.Models.EfModel;

public sealed class ModelRelationship : System.ComponentModel.INotifyPropertyChanged
{
    private string _left = "HasOne";
    public string Left
    {
        get => _left;
        set
        {
            _left = value;
            ReportPropertyChanged(nameof(Left));
        }
    }

    private string _leftexpression;
    public string LeftExpression
    {
        get => _leftexpression;
        set
        {
            _leftexpression = value;
            ReportPropertyChanged(nameof(LeftExpression));
        }
    }

    private bool _leftHasFK = false;
    public bool LeftHasFK
    {
        get => _leftHasFK;
        set
        {
            _leftHasFK = value;
            ReportPropertyChanged(nameof(LeftHasFK));
        }
    }

    private string _leftFkExpression;
    public string LeftFkExpression
    {
        get => _leftFkExpression;

        set
        {
            _leftFkExpression = value;
            ReportPropertyChanged(nameof(LeftFkExpression));
        }
    }

    private string _right = "WithMany";
    public string Right
    {
        get => _right;

        set
        {
            _right = value;
            ReportPropertyChanged(nameof(Right));
        }
    }

    private string _rightExpression;
    public string RightExpression
    {
        get => _rightExpression;
        set
        {
            _rightExpression = value;
            ReportPropertyChanged(nameof(RightExpression));
        }
    }

    private bool _rightHasFK = false;

    public bool RightHasFK
    {
        get => _rightHasFK;
        set
        {
            _rightHasFK = value;
            ReportPropertyChanged(nameof(RightHasFK));
        }
    }

    private string _rightFkExpression;
    public string RightFkExpression
    {
        get => _rightFkExpression;
        set
        {
            _rightFkExpression = value;
            ReportPropertyChanged(nameof(RightFkExpression));
        }
    }

    private string _deletebehavior = "NoAction";
    public string DeleteBehavior
    {
        get => _deletebehavior;
        set
        {
            _deletebehavior = value;
            ReportPropertyChanged(nameof(DeleteBehavior));
        }
    }


    public event PropertyChangedEventHandler PropertyChanged;
    internal void ReportPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
