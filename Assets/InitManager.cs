using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitManager : MonoBehaviour
{


    int store_quantity_in_stock;
    int amt_poi_per_location;
    List<TradeGood> ALL_GOODS = new();

    //returns the initial location
    public void Initialize()
    {
        
        InitializeGoods();
        InitializeLocations();


        void InitializeGoods()
        {
            GameManager.Instance.economy.DefineGoods();
        }


        void InitializeLocations()
        {

            GameManager.Instance.allLocs = new() { new Location(null, "LEO Terran Station (OTS)", "The second-biggest habitable zone in the Sol System, with a population roughly around 620 billions- according to a census made decades ago." ), new Location(null, "Pluto", "A far-off research-and-observation post turned into a metropolis. Competent research traditions have lead to a high quality of life." ), new Location(null, "Venus Orbital Ring", "The VOR greenhouses are well known for their delicious produce, well-brined and preserved with chemical compounds sifted from the volcanous landscape on the rock below." ), new Location(null, "Oortcloud-Habitat Conglomerate", "Description" ), new Location(null, "Mars", "The most populated planet in the system, post-Terraformation genetic drift has lead to an incredible biodiversity from the Terran fauna and flora exported here. Many say this is heaven." ), new Location(null, "Deimos Station", "After hundreds of years of archeological development, Deimos has revealed the presence of a long-dead alien civilization. The people of Deimos Station have taken upon themselves to learn their culture, and continue it. Deimoisians are the most unique and distant from the Terran standards, in terms of language, fashion and art." ), new Location(null, "Phobos Station", "The Aristocrats of Phobos have always been envious of Deimos, but have eventually managed to create their own economic niche by engineering macro-amoeba found on the planetoid below into various useful bio-factories, bio-computers, et cetera. An alternative to traditional machinery." ), new Location(null, "Jupiter Ring", "An anarchistic expanse of freedom where many people who seek to hide from the eye of Terra take refuge. Ring-sifters collect ore from the spinning accretion disk of the gas giant below." ), new Location(null, "Sweetspot 5", "Situated in one of the few areas in the Sol System where an object can orbit the Sun at a steady place. Successor of the sadly-gone Babylon minus-5 station." ) };



            foreach (var item in GameManager.Instance.allLocs)
            {
                for (int g = 0; g < amt_poi_per_location; g++)
                {
                    List<string> data1 = getMinorLocationName();
                    Location subLocation = new Location(null, data1[0], data1[1]);
                    List<TradeGood> items = GetHandfulOfGoods();
                    foreach (var it in items)
                    {
                        subLocation.AddInventory(it, false);
                    }
                    item.AddLocation(subLocation);
                }
            }


            GameManager.Instance.currentLocation= GameManager.Instance.allLocs[0];
        }

        List<TradeGood> GetHandfulOfGoods()
        {
            List<TradeGood> goods = new();
            for (int i = 0; i < 3; i++)
            {
                TradeGood b = GameManager.Instance.economy.getRandomTradeGood();
                b.quantity = Random.Range(1, 6);
                goods.Add(b);

            }


            return goods;
        }


        List<string> getMinorLocationName()
        {
            List<string> names1 = new() { "Dunkin'", "HydroFuel", "Potato", "Mushroom", "McKrab", "SLDF", "Alpha", "Wonderful", "Amazing", "Rare Fish", "Bibcoin", "Dinosaur", "Excelsior", "Ironhammer", "Radish", "Vegeta", "Goku", "Gamma", "Tau", "Prime", "Fox" };
            List<string> names2 = new() { " Minerals", " Inc", " Exports", "works", " League", " Factory", "mancers", " Chemlab", " Farms", " Conglomerate", " Restaurant", "soft" };
            List<string> descs = new() { "A well known local wholesaler.", "An obscure business, only known in specialist circles.", "An overgrown mom'n'pop store with a rich and lengthy history, now able to service passerby merchant vessels.", "A local trade consortium, looking to subtly get rid of some production rejects, recouping atleast some of their losses.", " A very prestigious merchant guild that has acquired goods in excess of local demand during the last season, looking for a lucky merchant to take the cheap stuff off their hands. Or so they say." };

            string randomName = names1[Random.Range(0, names1.Count)] + names2[Random.Range(0, names2.Count)];
            string randomDescription = descs[Random.Range(0, descs.Count)];


            return new List<string>() { randomName, randomDescription };

        }

    }



}
