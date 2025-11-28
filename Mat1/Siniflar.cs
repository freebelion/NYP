public interface Fonksiyon
{
    public double Deger(double x);
    public double Turev(double x);
}

public class Polinom : Fonksiyon // Polinom class im plements the Fonksiyon interface
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

public class Ustel : Fonksiyon
{
    private double _katsayi;
    private double _sayi;
    private double _us;

    public Ustel(double Katsayi, double Sayi, double Us)
    {
        _katsayi = Katsayi;
        _sayi = Sayi;
        _us = Us;
    }

    public double Deger(double x)
    {
        return _katsayi * Math.Pow(_sayi, _us);
    }

    public double Turev(double x)
    {
        return _katsayi * _us * Math.Pow(_sayi, _us - 1);
    }
}