using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteWineQuality {
    public class Wine {

        public int Id { get; set; }
        public double Fixed_acidity { get; set; }
        public double Volatile_acidity { get; set; }
        public double Citric_acid { get; set; }
        public double Residual_sugar { get; set; }
        public double Chlorides { get; set; }
        public double Free_sulfur_dioxide { get; set; }
        public double Total_sulfur_dioxide { get; set; }
        public double Density { get; set; }
        public double PH { get; set; }
        public double Sulphates { get; set; }
        public double Alcohol { get; set; }
        public int Quality { get; set; }
    }

    public class NormalizedWine{
        public int Id { get; set; }
        public double Fixed_acidity { get; set; }
        public double Volatile_acidity { get; set; }
        public double Citric_acid { get; set; }
        public double Residual_sugar { get; set; }
        public double Chlorides { get; set; }
        public double Free_sulfur_dioxide { get; set; }
        public double Total_sulfur_dioxide { get; set; }
        public double Density { get; set; }
        public double PH { get; set; }
        public double Sulphates { get; set; }
        public double Alcohol { get; set; }
        public double Quality { get; set; }
    }

    public class ReadCSV {

        public static List<NormalizedWine> norminalization(List<Wine> listwine) {

            List<NormalizedWine> normalizedWines = new List<NormalizedWine>();

            double minFixAcidity = listwine[0].Fixed_acidity;
            double minvolatileAcidity = listwine[0].Volatile_acidity;
            double minCitricAcid = listwine[0].Citric_acid;
            double minResidualSugar = listwine[0].Residual_sugar;
            double minChlorides = listwine[0].Chlorides;
            double minFreeSulfurDioxide = listwine[0].Free_sulfur_dioxide;
            double minTotalSulfurDoxide = listwine[0].Total_sulfur_dioxide;
            double minDensity = listwine[0].Density;
            double minPH = listwine[0].PH;
            double minSulphates = listwine[0].Sulphates;
            double minAlcohol = listwine[0].Alcohol;
            double minQuality = listwine[0].Quality;

            double maxFixAcidity = listwine[0].Fixed_acidity;
            double maxvolatileAcidity = listwine[0].Volatile_acidity;
            double maxCitricAcid = listwine[0].Citric_acid;
            double maxResidualSugar = listwine[0].Residual_sugar;
            double maxChlorides = listwine[0].Chlorides;
            double maxFreeSulfurDioxide = listwine[0].Free_sulfur_dioxide;
            double maxTotalSulfurDoxide = listwine[0].Total_sulfur_dioxide;
            double maxDensity = listwine[0].Density;
            double maxPH = listwine[0].PH;
            double maxSulphates = listwine[0].Sulphates;
            double maxAlcohol = listwine[0].Alcohol;
            double maxQuality = listwine[0].Quality;

            listwine.ForEach(wine => {

                //MIN
                if(minFixAcidity > wine.Fixed_acidity) {
                    minFixAcidity = wine.Fixed_acidity;
                }
                if(minvolatileAcidity > wine.Volatile_acidity) {
                    minvolatileAcidity = wine.Volatile_acidity;
                }
                if(minCitricAcid > wine.Citric_acid) {
                    minCitricAcid = wine.Citric_acid;
                }
                if (minResidualSugar > wine.Residual_sugar) {
                    minResidualSugar = wine.Residual_sugar;
                }
                if(minChlorides > wine.Chlorides) {
                    minChlorides = wine.Chlorides;
                }
                if(minFreeSulfurDioxide > wine.Free_sulfur_dioxide) {
                    minFreeSulfurDioxide = wine.Free_sulfur_dioxide;
                }
                if (minTotalSulfurDoxide > wine.Total_sulfur_dioxide) {
                    minTotalSulfurDoxide = wine.Total_sulfur_dioxide ;
                }
                if (minDensity > wine.Density) {
                    minDensity = wine.Density;
                }
                if (minPH > wine.PH) {
                    minPH = wine.PH;
                }
                if(minSulphates > wine.Sulphates) {
                     minSulphates = wine.Sulphates;
                }
                if (minAlcohol > wine.Alcohol) {
                    minAlcohol = wine.Alcohol;
                }
                if (minQuality > wine.Quality) {
                    minQuality = wine.Quality;
                }
                //MAX

                if (maxFixAcidity < wine.Fixed_acidity) {
                   maxFixAcidity = wine.Fixed_acidity;
                }
                if (maxvolatileAcidity < wine.Volatile_acidity) {
                    maxvolatileAcidity = wine.Volatile_acidity;
                }
                if (maxCitricAcid < wine.Citric_acid) {
                    maxCitricAcid = wine.Citric_acid;
                }
                if (maxResidualSugar < wine.Residual_sugar) {
                    maxResidualSugar = wine.Residual_sugar;
                }
                if (maxChlorides < wine.Chlorides) {
                    maxChlorides = wine.Chlorides;
                }
                if (maxFreeSulfurDioxide < wine.Free_sulfur_dioxide) {
                    maxFreeSulfurDioxide = wine.Free_sulfur_dioxide;
                }
                if (maxTotalSulfurDoxide < wine.Total_sulfur_dioxide) {
                    maxTotalSulfurDoxide = wine.Total_sulfur_dioxide;
                }
                if (maxDensity < wine.Density) {
                    maxDensity = wine.Density;
                }
                if (maxPH < wine.PH) {
                    maxPH = wine.PH;
                }
                if (maxSulphates < wine.Sulphates) {
                    maxSulphates = wine.Sulphates;
                }
                if (maxAlcohol < wine.Alcohol) {
                    maxAlcohol = wine.Alcohol;
                }
                if (maxQuality < wine.Quality) {
                    maxQuality = wine.Quality;
                }

            });


            listwine.ForEach(w => {
                NormalizedWine normWine = new NormalizedWine();
                normWine.Id  = w.Id;
                normWine.Fixed_acidity = (w.Fixed_acidity - minFixAcidity) / (maxFixAcidity - minFixAcidity);
                normWine.Volatile_acidity = (w.Volatile_acidity - minvolatileAcidity) / (maxvolatileAcidity - minvolatileAcidity);
                normWine.Citric_acid = (w.Citric_acid - minCitricAcid) / (maxCitricAcid - minCitricAcid);
                normWine.Residual_sugar = (w.Residual_sugar - minResidualSugar) / (maxResidualSugar - minResidualSugar);
                normWine.Chlorides = (w.Chlorides - minChlorides) / (maxChlorides -minChlorides);
                normWine.Free_sulfur_dioxide = (w.Free_sulfur_dioxide - minFreeSulfurDioxide) / (maxFreeSulfurDioxide - minFreeSulfurDioxide);
                normWine.Total_sulfur_dioxide = (w.Total_sulfur_dioxide - minTotalSulfurDoxide) / (maxTotalSulfurDoxide - minTotalSulfurDoxide);
                normWine.Density = (w.Density - minDensity) / (maxDensity - minDensity);
                normWine.PH = (w.PH - minPH) / (maxPH - minPH);
                normWine.Sulphates = (w.Sulphates - minSulphates) / (maxSulphates - minSulphates);
                normWine.Alcohol = (w.Alcohol - minAlcohol) / (maxAlcohol - minAlcohol);
                normWine.Quality = (w.Quality - minQuality) / (maxQuality - minQuality);
                
                normalizedWines.Add(normWine);
            });

            return normalizedWines;
        }

        public List<Wine> getListOfObjects(string file) {
            List<string> lines = System.IO.File.ReadAllLines(file).ToList();
            var dataLines = lines.Skip(1);

            List<Wine> winelist = new List<Wine>();

            int c = 1;

            dataLines.ToList().ForEach(line => {
                
               var values = line.Split(';');
                Wine wine = new Wine();
                wine.Id = c;
                wine.Fixed_acidity = Convert.ToDouble(values[0]); 
                wine.Volatile_acidity = Convert.ToDouble(values[1]);
                wine.Citric_acid = Convert.ToDouble(values[2]);
                wine.Residual_sugar = Convert.ToDouble(values[3]);
                wine.Chlorides = Convert.ToDouble(values[4]);
                wine.Free_sulfur_dioxide = Convert.ToDouble(values[5]);
                wine.Total_sulfur_dioxide = Convert.ToDouble(values[6]);
                wine.Density = Convert.ToDouble(values[7]);
                wine.PH = Convert.ToDouble(values[8]);
                wine.Sulphates = Convert.ToDouble(values[9]);
                wine.Alcohol = Convert.ToDouble(values[10]);
                wine.Quality = int.Parse(values[11]);
                winelist.Add(wine);
                c++;
            });

            return winelist;
         
        }

    }

}
