// See https://aka.ms/new-console-template for more information

class Program
{
    static void Main(string[] args)
    {
        AppConfig appConfig = new AppConfig();
        appConfig.covidconvig.UbahSatuan();

        Console.Write($"Berapa suhu badan Anda saat ini? Dalam nilai {appConfig.covidconvig.satuan_suhu} : ");
        double suhu = double.Parse( Console.ReadLine() );

        Console.Write("Berapa hari yang lalu (perkiraan) Anda terakhir memiliki gejala demam? ");
        int hari = int.Parse( Console.ReadLine() );

        try
        {
            if(hari < 0)
            {
                throw new Exception("Invalid");
            }
            if(appConfig.covidconvig.satuan_suhu == "celcius")
            {
                if(suhu >= 36.5 && suhu <= 37.5 && hari < appConfig.covidconvig.batas_hari_demam)
                {
                    Console.WriteLine(appConfig.covidconvig.pesan_diterima);
                }
                else
                {
                    Console.WriteLine(appConfig.covidconvig.pesan_ditolak);
                }
            }
            else
            {
                if(suhu >= 97.7 && suhu <= 99.5 && hari < appConfig.covidconvig.batas_hari_demam)
                {
                    Console.WriteLine(appConfig.covidconvig.pesan_diterima);
                }
                else
                {
                    Console.WriteLine(appConfig.covidconvig.pesan_ditolak);
                }
            }
            
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
}