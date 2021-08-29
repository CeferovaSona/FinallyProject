using FinallyProject.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinallyProject.Models
{
    partial class Pharmacy
    {
        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
        public void AddDrug(Drug drug)
        {
            bool isFalse = false;
            foreach (Drug addedDrug in _drugs)
            {

                if (addedDrug.Name == drug.Name)
                {
                    addedDrug.Count += drug.Count;
                    isFalse = true;
                }

            }
            if (isFalse == false)
            {
                _drugs.Add(drug);
            }

        }
        public List<Drug> InfoDrug(string name)
        {
            List<Drug> searchedDrug = _drugs.FindAll(x => x.Name.ToLower().Contains(name.ToLower()));
            return searchedDrug;
        }
        public void ShowDrugItems()
        {
            if (_drugs.Count == 0)
            {
                return;
            }

            foreach (Drug drug in _drugs)
            {
                Helper.Color(ConsoleColor.Green, drug.ToString());
            }

        }

        public void SaleDrug(string drugName, int drugCount, double drugPrice)
        {
            Drug saleDrug = new Drug();
            foreach (Drug exisistDrug in _drugs)
            {
                if (exisistDrug.Name.ToLower() == drugName.ToLower())
                {
                    saleDrug = exisistDrug;
                    if (saleDrug.Count >= drugCount)
                    {
                        if ((drugCount * saleDrug.Price <= drugPrice))
                        {
                            saleDrug.Count -= drugCount;

                            Helper.Color(ConsoleColor.Blue, $"Satış uğurla baş verdi.Pul qalğınız; {drugPrice - (saleDrug.Price * drugCount)}");
                        }
                        else
                        {

                            Helper.Color(ConsoleColor.Blue, $"{(saleDrug.Price * drugCount) - drugPrice}  qədər pulunuz çatmır");
                        }
                    }
                    else
                    {
                        Helper.Color(ConsoleColor.Blue, $"Anbarda {drugCount - saleDrug.Count} sayda dərman qalıb");
                    }
                }
                else
                {
                    Helper.Color(ConsoleColor.Red, $"{ saleDrug.Name.ToUpper()} adlı dərman tapılmadı");
                }

            }
        }
    }
}

