using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

public class AppConfig
{
    public CovidConfig covidconvig;
    public const string fileLocation = "C:\\Users\\Asus\\Documents\\Lia\\Telkom\\SEMS 4\\KPL\\TP\\TPMOD8\\TPMOD8\\TP_MOD8_1302210033\\TP_MOD8_1302210033";
    public const string filePath = fileLocation + "convid_config.json";

    public AppConfig()
    {
        try
        {
            ReadConfigFile();
        }
        catch
        {
            SetDefault();
            WriteNewConfigFile();
        }
    }

    private CovidConfig ReadConfigFile()
    {
        string configJSONData = File.ReadAllText(filePath);
        covidconvig = JsonSerializer.Deserialize<CovidConfig>(configJSONData);
        return covidconvig;
    }

    private void SetDefault()
    {
        string pesanDitolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini ";
        string pesanDiterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
        covidconvig = new CovidConfig("celcius",14,pesanDitolak,pesanDiterima);
    }

    private void WriteNewConfigFile()
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string jsonstring = JsonSerializer.Serialize(covidconvig,options);
        File.WriteAllText(filePath, jsonstring);
    }
}
