public interface Fonksiyon
{
    public double Deger(double x);
    public double Turev(double x);
}

public class Polinom : Fonksiyon
{
    private double[] _katsayilar;

    public Polinom(params double[] katsayilar)
    {
        int n = katsayilar.Length;
        _katsayilar = new double[n];
        for (int i=0; i < n; i++)
        { _katsayilar[i] = katsayilar[i]; }
    }

    public double Deger(double x)
    {
        double y = 0;

        for(int i=0; i< _katsayilar.Length; i++)
        {
            y += _katsayilar[i] * Math.Pow(x, i);
        }

        return y;
    }

    public double Turev(double x)
    {
        double yp = 0;

        for (int i = 1; i < _katsayilar.Length; i++)
        {
            yp += i*(_katsayilar[i] * Math.Pow(x, i-1));
        }

        return yp;
    }
}

public class TrigPolinom : Fonksiyon
{
    private double _sinK;
    private double _sinU;
    private double _cosK;
    private double _cosU;

    public TrigPolinom(double sinKatsayi, double sinUs, double cosKatsayi, double cosUs)
    {
        _sinK = sinKatsayi;
        _sinU = sinUs;
        _cosK = cosKatsayi;
        _cosU = cosUs;
    }

    public double Deger(double x)
    {
        double y = _sinK * Math.Pow(Math.Sin(x), _sinU);
        y       += _cosK * Math.Pow(Math.Cos(x), _cosU);
        return y;
    }

    public double Turev(double x)
    {
        throw new NotImplementedException();
    }
}