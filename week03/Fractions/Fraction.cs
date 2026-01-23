public class Fraction
{
    private int _top;
    private int _bottom;

    // no parameters - 1/1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // one parameter - n/1
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // two parameters - top/bottom
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // format as "top/bottom"
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // get decimal value of the fraction
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}
