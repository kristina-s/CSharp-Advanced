using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Shop
{
    public static class Requirement
    {
        public static double GetMinPriceConfig(List<Part> list)
        {
            double minPrice = 0;
            Configuration myConfig = new Configuration(Colors.Gray);
            for (int i = 0; i < MinRequirement.GetCategories().Count; i++)
            {
                List<Part> eachCatParts = list
                    .Where(x => x.PartType == MinRequirement.GetCategories()[i])
                    .ToList();
                Part p = eachCatParts
                    .FirstOrDefault(x => x.Price == eachCatParts.Select(y => y.Price).Min());
                myConfig.AddPartToProduct(p, 1);
            }
            minPrice = myConfig.GetPrice();
            return minPrice;
        }

        public static double GetMaxPriceConfig(List<Part> list)
        {
            double maxPrice = 0;
            Configuration myConfig = new Configuration(Colors.Gray);
            for (int i = 0; i < MinRequirement.GetCategories().Count; i++)
            {
                List<Part> eachCatParts = list
                    .Where(x => x.PartType == MinRequirement.GetCategories()[i])
                    .ToList();
                Part p = eachCatParts
                    .FirstOrDefault(x => x.Price == eachCatParts.Select(y => y.Price).Max());
                myConfig.AddPartToProduct(p, 1);
            }
            maxPrice = myConfig.GetPrice();
            return maxPrice;
        }

        public static double GetClosestPrice(double myPrice, List<Part> list)
        {
            //make different lists for each category
            List<Part> cpuList = list
                .Where(x => x.PartType == PartType.CPU)
                .ToList();
            List<Part> hddList = list
                .Where(x => x.PartType == PartType.HDD)
                .ToList();
            List<Part> peripheralsList = list
                .Where(x => x.PartType == PartType.Peripherals)
                .ToList();
            List<Part> ramList = list
                .Where(x => x.PartType == PartType.RAM)
                .ToList();
            List<Part> screenList = list
                .Where(x => x.PartType == PartType.Screen)
                .ToList();
            List<Part> vgaList = list
                .Where(x => x.PartType == PartType.VGA)
                .ToList();

            List<List<Part>> lstMaster = new List<List<Part>> { cpuList, hddList, peripheralsList, ramList, screenList, vgaList };

            List<Configuration> lstRes = new List<Configuration>();

            foreach (var item1 in cpuList)
            {            
                foreach (var item2 in hddList)
                {
                    foreach (var item3 in peripheralsList)
                    {
                        foreach (var item4 in ramList)
                        {
                            foreach (var item5 in screenList)
                            {
                                foreach (var item6 in vgaList)
                                {
                                    Configuration c = new Configuration(Colors.Black);
                                    c.AddPartToProduct(item1, 1);
                                    c.AddPartToProduct(item2, 1);
                                    c.AddPartToProduct(item3, 1);
                                    c.AddPartToProduct(item4, 1);
                                    c.AddPartToProduct(item5, 1);
                                    c.AddPartToProduct(item6, 1);
                                    lstRes.Add(c);
                                }
                            }
                        }
                    }
                }
            }
            //get all prices in a list
            List<double> allPrices = lstRes
                .Select(x => x.GetPrice())
                .ToList();
            double lessThan = allPrices
                .Where(x => x < myPrice)
                .Last();
                        
            return lessThan;
        }
    }
}
