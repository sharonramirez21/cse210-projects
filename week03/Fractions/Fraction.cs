using System.Diagnostics;
using System.Runtime.CompilerServices;

public class Fraction
{
    private int _top; // in private
    private int _bottom;


    public Fraction() // in public :)
    {
        _top = 1;
        _bottom = 1;
    }   

    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }


    public double GetDecimalValue()
    {
        return (double)_top/(double)_bottom;
    }
}