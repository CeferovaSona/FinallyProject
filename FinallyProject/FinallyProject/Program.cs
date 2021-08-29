using FinallyProject.Models;
using FinallyProject.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinallyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pharmacy> pharmacy = new List<Pharmacy>();
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            while (true)
            {
                Helper.Color(ConsoleColor.Green, "Xoş gəlmişsiniz.Zəhmət olmasa etmək istədiyiniz əməliyyat növünün sıra nömrəsini daxil edəsiniz");
                Helper.Color(ConsoleColor.Yellow, "1-Aptek yaratmaq,2-Aptekə dərman əlavə etmək,3- Satış etmək,4- Dərmanların siyahısını göstərmək,5-Axtarış etmək,6-Çıxış.");
                string input = Console.ReadLine();
                bool isInt = int.TryParse(input, out int menu);
                if ((isInt && (menu >= 1 && menu <= 6)))
                {
                    if (menu == 6)
                    {
                        Helper.Color(ConsoleColor.Yellow, "Çıxış");
                        break;
                    }
                    switch (menu)
                    {
                        case 1:

                            Helper.Color(ConsoleColor.DarkGreen, "Aptek adını daxil edin  ");
                            string pharmacyName = Console.ReadLine();
                            bool isExistPharmacy = pharmacy.Exists(x => x.Name.ToLower() == pharmacyName.ToLower());
                            bool isExistGroup = pharmacy.Exists(x => x.Name.ToLower() == pharmacyName.ToLower());
                            if (isExistGroup)
                            {
                                Helper.Color(ConsoleColor.Red, $"" +
                                    $"{pharmacyName} adda aptek artıq movcuddur");
                                goto case 1;

                            }

                            Pharmacy newPharmacy = new Pharmacy(pharmacyName);
                            pharmacy.Add(newPharmacy);
                            Helper.Color(ConsoleColor.Green, $"{newPharmacy.Id}.{pharmacyName} aptek yaradildi");

                            break;
                        case 2:
                            Helper.Color(ConsoleColor.Cyan, "Dərmanı daxil edəcəyiniz aptekin adını mövcud adların siyahısından  secib daxil edin:");
                        selectPharmacy:
                            foreach (Pharmacy anyPharmacy in pharmacy)
                            {
                                Helper.Color(ConsoleColor.Green, anyPharmacy.ToString());
                            }
                            string selectedPharmacy = Console.ReadLine();
                            Pharmacy exsistPharmacy = pharmacy.Find(x => x.Name.ToLower() == selectedPharmacy.ToLower());
                            if (exsistPharmacy == null)
                            {
                                Helper.Color(ConsoleColor.Red, $"{selectedPharmacy} apteki yoxdur.");
                                goto selectPharmacy;
                            }
                            Helper.Color(ConsoleColor.Cyan, "Zəhmət olmasa daxil etmək istədiyiniz dərman adını daxil edin:");
                            string name = Console.ReadLine();
                            Helper.Color(ConsoleColor.Cyan, "Zəhmət olmasa daxil etmək istədiyiniz dərman vasitəsinin hansı növ dərman vasitəsinə   " +
                                "aid olduğunu qeyd edin!.Məsələn: agrıkəsici,keyidici,soyuqdəymə və s.:");
                            string drugType = Console.ReadLine();
                        selectPrice:
                            Helper.Color(ConsoleColor.Cyan, "Zəhmət olmasa dərmanın qiymətini daxil edin:");
                            input = Console.ReadLine();
                            double price = Convert.ToDouble(input);
                            //isInt = int.TryParse(input, out int price);
                            if (!isInt)
                            {
                                Helper.Color(ConsoleColor.Red, "Dərmanın qiyməti rəqəmlə daxil edilməlidir:");
                                goto selectPrice;
                            }
                        selectCount:
                            Helper.Color(ConsoleColor.Cyan, "Zəhmət olmasa daxil etdiyiniz dərmanın sayını daxil edin:");
                            input = Console.ReadLine();
                            isInt = int.TryParse(input, out int count);
                            if (!isInt)
                            {
                                Helper.Color(ConsoleColor.Red, "Dərman sayı hərflə verilə bilməz.Zəhmət olmasa ədəd daxil edin:");
                                goto selectCount;

                            }
                            DrugType type = new DrugType(drugType);
                            Drug newDrug = new Drug(name, price, count, type);
                            exsistPharmacy.AddDrug(newDrug);
                            Helper.Color(ConsoleColor.Cyan, $"{newDrug.Id } {newDrug.Name} {newDrug.Count}sayda {newDrug.Price} man  tipli dərman {exsistPharmacy} " +
                                $"aptekinə əlavə olundu");


                            break;
                        case 3:
                            Pharmacy aPharmacy = new Pharmacy();
                            Helper.Color(ConsoleColor.DarkMagenta, "Zəhmət olmasa dərmanı satın almaq istediyiniz aptekin adını mövcud siyahıdan  secib daxil edin:");
                        a:
                            foreach (Pharmacy anyPharmacy in pharmacy)
                            {
                                Helper.Color(ConsoleColor.Green, anyPharmacy.ToString());
                            }
                            string searchedPharmacy = Console.ReadLine();
                            Pharmacy isExsist = pharmacy.Find(x => x.Name.ToLower() == searchedPharmacy.ToLower());
                            if (isExsist == null)
                            {
                                Helper.Color(ConsoleColor.Red, $"{searchedPharmacy } apteki yoxdur.");
                                goto a;
                            }

                            Helper.Color(ConsoleColor.Cyan, "Dərmanın adını daxil edin:");
                            string drugName = Console.ReadLine();
                        b:
                            Helper.Color(ConsoleColor.Cyan, "Zəhmət olmasa mövcud pulunuzun mebleğini daxil edin:");
                            input = Console.ReadLine();
                            isInt = int.TryParse(input, out int drugPrice);
                            if (!isInt)
                            {
                                Helper.Color(ConsoleColor.Red, "Dərmanın qiyməti rəqəmlə daxil edilməlidir:");
                                goto b;
                            }
                        c:
                            Helper.Color(ConsoleColor.Cyan, "Zəhmət olmasa daxil etdiyiniz dərmanın istediyiniz miqdarini qeyd edin:");
                            input = Console.ReadLine();
                            isInt = int.TryParse(input, out int drugCount);
                            if (!isInt)
                            {
                                Helper.Color(ConsoleColor.Red, "Dərman sayı hərflə verilə bilməz.Zəhmət olmasa ədəd daxil edin:");
                                goto c;
                            }
                            Helper.Color(ConsoleColor.Cyan, "Satışa başlayaq;");
                            aPharmacy.SaleDrug(drugName, drugCount, drugPrice);

                            break;
                        case 4:
                        d:
                            Helper.Color(ConsoleColor.Blue, "Zəhmət olmasa ekranda görünən aptek adlarından isteyinizə uygun aptek " +
                                "adını daxil edin");
                            foreach (var item in pharmacy)
                            {
                                Helper.Color(ConsoleColor.Green, item.ToString());
                            }
                            string wantedPharmacyName = Console.ReadLine();
                            Pharmacy expectedPharmacy = pharmacy.Find(x => x.Name.ToLower() == wantedPharmacyName.ToLower());
                            if (expectedPharmacy == null)
                            {
                                Helper.Color(ConsoleColor.Red, $"{wantedPharmacyName} apteki yoxdur.");
                                goto d;
                            }
                            Helper.Color(ConsoleColor.Cyan, $"{wantedPharmacyName} aptekində olan dərmanların siyahısı;");
                            expectedPharmacy.ShowDrugItems();

                            break;

                        case 5:
                            Helper.Color(ConsoleColor.DarkGreen, "Zəhmət olmasa axtardığınız dərmanın adını daxil edin:");
                            string searchedDrugName = Console.ReadLine();
                            foreach (Pharmacy searchdPharmacy in pharmacy)
                            {
                                List<Drug> foundedDrug = searchdPharmacy.InfoDrug(searchedDrugName);

                                foreach (Drug drug in foundedDrug)
                                {
                                    Helper.Color(ConsoleColor.Cyan, $"{drug.ToString()} dərmanı {searchdPharmacy} aptekində mövcuddur");
                                }

                            }

                            break;
                        Default:
                            break;
                    }
                }
                else
                {
                 Helper.Color(ConsoleColor.Red, " Seçiminiz düzgün deyil.Xahiş edirik ekranda gördüyünüz əməliyyat nömrələrindən birini seçəsiniz!");
                }

            }
        }
    }
}

























