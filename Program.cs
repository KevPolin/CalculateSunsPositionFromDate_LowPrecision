using System;

public class MainClass
{
    const double torad = Math.PI / 180.0;

    public static void Main(string[] args)
    {
        Console.WriteLine("*****************************************************************************************************");
        Console.WriteLine(" ");
        Console.WriteLine("Solving The Sun's Current Right Ascension and Declination for Date/Time: 2024-04-24, 07AM 00M 00S UTC ");
        Console.WriteLine("This corresponds to a Julian Date of: 2460424.791667");
        Console.WriteLine(" ");
        double[] radec = sunPosition(2460424.791667); //2024-04-24, 07AM 00M 00S UTC

        double var1 = radec[0] / torad / 15.0;
        double var2 = radec[1] / torad;

        Console.WriteLine("The Sun's Right Ascension in decimals: " + var1);
        Console.WriteLine("The Sun's Declination in decimals is: " + var2);

        var timeSpan = TimeSpan.FromHours((double)var1);

        Console.WriteLine(" ");
        Console.WriteLine("The Sun's Right Ascension in hours/mins/secs is: {0} Hours {1} Minutes {2} Seconds", Math.Floor(timeSpan.TotalHours), timeSpan.Minutes, timeSpan.Seconds);

        double coord = var2;
        int sec = (int)Math.Round(coord * 3600);
        int deg = sec / 3600;
        sec = Math.Abs(sec % 3600);
        int min = sec / 60;
        sec %= 60;

        Console.WriteLine("The Sun's Declination in degrees/mins/secs is: {0} Degrees {1} Minutes {2} Seconds", deg, min, sec);

        Console.WriteLine(" ");
        Console.WriteLine("*****************************************************************************************************");
    }

    //Low precision sun position from Astronomical Almanac page C5 (2017 ed).
    //Accuracy 1deg from 1950-2050
    public static double[] sunPosition(double jd)
    {
        double torad= Math.PI / 180.0;
        double n = jd - 2451545.0;
        double L = (280.460 + 0.9856474 * n) % 360;
        double g = ((357.528 + .9856003 * n) % 360) * torad;
        if (L < 0) { L += 360; }
        if (g < 0) { g += Math.PI * 2.0; }

        double lambda = (L + 1.915 * Math.Sin(g) + 0.020 * Math.Sin(2 * g)) * torad;
        double beta = 0.0;
        double eps = (23.439 - 0.0000004 * n) * torad;
        double ra = Math.Atan2(Math.Cos(eps) * Math.Sin(lambda), Math.Cos(lambda));
        double dec = Math.Asin(Math.Sin(eps) * Math.Sin(lambda));
        if (ra < 0) { ra += Math.PI * 2; }

        //double raSolved = ra / torad / 15.0;
        //double decSolved = dec / torad;

        //return ra / torad / 15.0, dec / torad;
        return new double[] { ra, dec };
    }
}