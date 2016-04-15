using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceHunt.GameObjects.Enums;
using SpaceHunt.StateTracker;

namespace SpaceHunt.Utils
{
    class Randomizer
    {
        private static Randomizer instance;
        private Random random;
        private int NameCounter;

        #region name array

        private string[] names =
        {
            "Hepriyyam I  ",
            "Wuclienop I  ",
            "Yudrion I    ",
            "Udrone I     ",
            "Cautov I     ",
            "Riuturn I    ",
            "Prodotani I  ",
            "Sloderia I   ",
            "Chosie I     ",
            "Blorix I     ",
            "Gobliotan I  ",
            "Goskiaphu I  ",
            "Asninda I    ",
            "Wupragua I   ",
            "Aynerth I    ",
            "Hiunides I   ",
            "Flodonope I  ",
            "Pleceril I   ",
            "Snomia I     ",
            "Sposie I     ",
            "Yosnulia I   ",
            "Yuscaute I   ",
            "Heslonoe I   ",
            "Lutrov I     ",
            "Hiylara I    ",
            "Poyturn I    ",
            "Drodater I   ",
            "Skodothea I  ",
            "Sciri I      ",
            "Grade I      ",
            "Matheo I     ",
            "Restanov I   ",
            "Jablomia I   ",
            "Xoshoth I    ",
            "Wopra I      ",
            "Teylia I     ",
            "Bleconope I  ",
            "Whecotera I  ",
            "Crore I      ",
            "Shadus I     ",
            "Jagrunope I  ",
            "Eploazuno I  ",
            "Ostrichi I   ",
            "Gostypso I   ",
            "Fiycarro I   ",
            "Uoter I      ",
            "Stecegawa I  ",
            "Skabonide I  ",
            "Croth I      ",
            "Letrioga I   ",
            "Xescopra I   ",
            "Wesheon I    ",
            "Cashiri I    ",
            "Hiupra I     ",
            "Yoatis I     ",
            "Chufaphus I  ",
            "Drecanus I   ",
            "Pliuq I      ",
            "Briuq I      ",
            "Hepriyyam II ",
            "Wuclienop II ",
            "Yudrion II   ",
            "Udrone II    ",
            "Cautov II    ",
            "Riuturn II   ",
            "Prodotani II ",
            "Sloderia II  ",
            "Chosie II    ",
            "Blorix II    ",
            "Gobliotan II ",
            "Goskiaphu II ",
            "Asninda II   ",
            "Wupragua II  ",
            "Aynerth II   ",
            "Hiunides II  ",
            "Flodonope II ",
            "Pleceril II  ",
            "Snomia II    ",
            "Sposie II    ",
            "Yosnulia II  ",
            "Yuscaute II  ",
            "Heslonoe II  ",
            "Lutrov II    ",
            "Hiylara II   ",
            "Poyturn II   ",
            "Drodater II  ",
            "Skodothea II ",
            "Sciri II     ",
            "Grade II     ",
            "Matheo II    ",
            "Restanov II  ",
            "Jablomia II  ",
            "Xoshoth II   ",
            "Wopra II     ",
            "Teylia II    ",
            "Bleconope II ",
            "Whecotera II ",
            "Crore II     ",
            "Shadus II    ",
            "Jagrunope II ",
            "Eploazuno II ",
            "Ostrichi II  ",
            "Gostypso II  ",
            "Fiycarro II  ",
            "Uoter II     ",
            "Stecegawa II ",
            "Skabonide II ",
            "Croth II     ",
            "Letrioga II  ",
            "Xescopra II  ",
            "Wesheon II   ",
            "Cashiri II   ",
            "Hiupra II    ",
            "Yoatis II    ",
            "Chufaphus II ",
            "Drecanus II  ",
            "Pliuq II     ",
            "Briuq II     ",
            "Hepriyyam III",
            "Wuclienop III",
            "Yudrion III  ",
            "Udrone III   ",
            "Cautov III   ",
            "Riuturn III  ",
            "Prodotani III",
            "Sloderia III ",
            "Chosie III   ",
            "Blorix III   ",
            "Gobliotan III",
            "Goskiaphu III",
            "Asninda III  ",
            "Wupragua III ",
            "Aynerth III  ",
            "Hiunides III ",
            "Flodonope III",
            "Pleceril III ",
            "Snomia III   ",
            "Sposie III   ",
            "Yosnulia III ",
            "Yuscaute III ",
            "Heslonoe III ",
            "Lutrov III   ",
            "Hiylara III  ",
            "Poyturn III  ",
            "Drodater III ",
            "Skodothea III",
            "Sciri III    ",
            "Grade III    ",
            "Matheo III   ",
            "Restanov III ",
            "Jablomia III ",
            "Xoshoth III  ",
            "Wopra III    ",
            "Teylia III   ",
            "Bleconope III",
            "Whecotera III",
            "Crore III    ",
            "Shadus III   ",
            "Jagrunope III",
            "Eploazuno III",
            "Ostrichi III ",
            "Gostypso III ",
            "Fiycarro III ",
            "Uoter III    ",
            "Stecegawa III",
            "Skabonide III",
            "Croth III    ",
            "Letrioga III ",
            "Xescopra III ",
            "Wesheon III  ",
            "Cashiri III  ",
            "Hiupra III   ",
            "Yoatis III   ",
            "Chufaphus III",
            "Drecanus III ",
            "Pliuq III    ",
            "Briuq III    ",
            "Hepriyyam IV ",
            "Wuclienop IV ",
            "Yudrion IV   ",
            "Udrone IV    ",
            "Cautov IV    ",
            "Riuturn IV   ",
            "Prodotani IV ",
            "Sloderia IV  ",
            "Chosie IV    ",
            "Blorix IV    ",
            "Gobliotan IV ",
            "Goskiaphu IV ",
            "Asninda IV   ",
            "Wupragua IV  ",
            "Aynerth IV   ",
            "Hiunides IV  ",
            "Flodonope IV ",
            "Pleceril IV  ",
            "Snomia IV    ",
            "Sposie IV    ",
            "Yosnulia IV  ",
            "Yuscaute IV  ",
            "Heslonoe IV  ",
            "Lutrov IV    ",
            "Hiylara IV   ",
            "Poyturn IV   ",
            "Drodater IV  ",
            "Skodothea IV ",
            "Sciri IV     ",
            "Grade IV     ",
            "Matheo IV    ",
            "Restanov IV  ",
            "Jablomia IV  ",
            "Xoshoth IV   ",
            "Wopra IV     ",
            "Teylia IV    ",
            "Bleconope IV ",
            "Whecotera IV ",
            "Crore IV     ",
            "Shadus IV    ",
            "Jagrunope IV ",
            "Eploazuno IV ",
            "Ostrichi IV  ",
            "Gostypso IV  ",
            "Fiycarro IV  ",
            "Uoter IV     ",
            "Stecegawa IV ",
            "Skabonide IV ",
            "Croth IV     ",
            "Letrioga IV  ",
            "Xescopra IV  ",
            "Wesheon IV   ",
            "Cashiri IV   ",
            "Hiupra IV    ",
            "Yoatis IV    ",
            "Chufaphus IV ",
            "Drecanus IV  ",
            "Pliuq IV     ",
            "Briuq IV     ",
            "Hepriyyam V  ",
            "Wuclienop V  ",
            "Yudrion V    ",
            "Udrone V     ",
            "Cautov V     ",
            "Riuturn V    ",
            "Prodotani V  ",
            "Sloderia V   ",
            "Chosie V     ",
            "Blorix V     ",
            "Gobliotan V  ",
            "Goskiaphu V  ",
            "Asninda V    ",
            "Wupragua V   ",
            "Aynerth V    ",
            "Hiunides V   ",
            "Flodonope V  ",
            "Pleceril V   ",
            "Snomia V     ",
            "Sposie V     ",
            "Yosnulia V   ",
            "Yuscaute V   ",
            "Heslonoe V   ",
            "Lutrov V     ",
            "Hiylara V    ",
            "Poyturn V    ",
            "Drodater V   ",
            "Skodothea V  ",
            "Sciri V      ",
            "Grade V      ",
            "Matheo V     ",
            "Restanov V   ",
            "Jablomia V   ",
            "Xoshoth V    ",
            "Wopra V      ",
            "Teylia V     ",
            "Bleconope V  ",
            "Whecotera V  ",
            "Crore V      ",
            "Shadus V     ",
            "Jagrunope V  ",
            "Eploazuno V  ",
            "Ostrichi V   ",
            "Gostypso V   ",
            "Fiycarro V   ",
            "Uoter V      ",
            "Stecegawa V  ",
            "Skabonide V  ",
            "Croth V      ",
            "Letrioga V   ",
            "Xescopra V   ",
            "Wesheon V    ",
            "Cashiri V    ",
            "Hiupra V     ",
            "Yoatis V     ",
            "Chufaphus V  ",
            "Drecanus V   ",
            "Pliuq V      ",
            "Briuq V      "
        };

        #endregion

        public static Randomizer Instance
        {
            get { return instance ?? (instance = new Randomizer()); }
        }

        private Randomizer()
        {
            random = new Random();
            Shuffle(names);
        }

        public int GetRandom(int range)
        {
            return random.Next(1, range + 1);
        }

        public Sector GenerateRandomSector(int x, int y)
        {
            var result = new Sector(NextSectorName(), new Point(x, y));

            result.Resource = RandomResource();

            return result;
        }

        private string NextSectorName()
        {
            if (NameCounter == names.Length)
            {
                NameCounter = 0;
            }

            return names[NameCounter];
        }

        private Resource RandomResource()
        {
            var result = random.Next(1, 100);

            switch (result)
            {
                case 1:
                    return Resource.Science;
                case 2:
                    return Resource.Food;
                case 3:
                    return Resource.Production;
                default:
                    return Resource.None;
            }
        }

        private void Shuffle<T>(T[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n; i++)
            {
                // NextDouble returns a random number between 0 and 1.
                // ... It is equivalent to Math.random() in Java.
                int r = i + (int) (random.NextDouble()*(n - i));
                T t = array[r];
                array[r] = array[i];
                array[i] = t;
            }
        }
    }
}
