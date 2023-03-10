using System;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Globalization;

namespace _12._15._2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ad = "   Elvin bilalov";
            ad = ad.Trim();
            Console.WriteLine(FullOrName(ref ad));
        }





        #region - Verilmiş string dəyərindəki bütün sözlərin arasında bir boşluq qalacaq vəziyyətə salan metod.
        static string Trim(ref string yazi)
        {

            string newstr = "";


            for (int i = 0; i < yazi.Length; i++)
            {
                if (yazi[i] == ' ' && yazi[i++] == ' ')
                {
                    continue;

                }
                else
                {
                    newstr += yazi[i];
                }
            }
            return yazi = newstr;
        }




        #endregion
        #region - Verilmiş string dəyərdəki sözlərin sayını tapan metod (boşluqlarla ayrılmış bütün ifadələr
        static int StrCount(string yazi)
        {
            int SpaceCount = 0;
            int StrCount = 0;

            for (int i = 0; i < yazi.Length; i++)
            {
                if (yazi[i] == ' ')
                {
                    SpaceCount++;

                    if (SpaceCount == 2)
                    {
                        SpaceCount--;
                        continue;
                    }
                    else
                        StrCount++;
                }
                else
                {
                    SpaceCount = 0;
                }
            }
            return StrCount + 1;
        }
        #endregion
        #region- Parameter olaraq integer array variable-ı (reference) və bir integer value qəbul edən və həmin integer value-nu integer array-ə yəni element kimi əlavə edən metod.
        static void ArrayWithNum(ref int[] array, int num)
        {
            int[] newArr = new int[array.Length + 1];
            int j = 0;

            for (int i = 0; i < array.Length; i++)
            {
                newArr[j] = array[i];
                j++;
            }

            newArr[newArr.Length - 1] = num;
            array = newArr;

        }
        #endregion
        #region- Gonderilmis fullname arrayinden yeni bir names arrayi duzeldib geri qaytaran metod.Fullname arrayinin icindeki butun value-lar ad+" "+soyad formatindadir.Misalcun "Hikmet Abbasov". Misalcun gelen arraydeki deyerler {"Hikmet Abbasov","Abdulla Qulamov","Cemile Hikmetova"} olarsa return olunan arraydeki deyerler {"Hikmet","Abdulla","Cemile"} olmalidir
        static string[] NamesArray(ref string[] ArrayWithFullName)
        {
            string[] OnlyNames = new string[ArrayWithFullName.Length];
            string newstr = "";


            for (int i = 0; i < ArrayWithFullName.Length; i++)
            {
                for (int j = 0; j < ArrayWithFullName[i].Length; j++)
                {

                    if (ArrayWithFullName[i][j] == ' ')
                    {
                        break;

                    }
                    else
                    {
                        newstr += ArrayWithFullName[i][j];
                        OnlyNames[i] = newstr;
                    }
                }
                newstr = "";

            }
            return ArrayWithFullName = OnlyNames;


        }

        #endregion
        #region - Verilmiş string dəyərin bir fullname olub olmadığını yoxlayan metod.(Dəyərin fullname olma şərti daxilində yalnız hərflərin ola bilməsi, yalnız 2 sözdən ibarət olması və hər bir sözün böyük hərfə başlayıb kiçik hərflərlə davam etməsidir.
        static bool FullOrName(ref string ad)
        {
            bool IsDigit = false;
            bool Length = false;
            bool IsUpper = false;
            bool Islower = false;

            ad = ad.Trim();

            string[] split = new string[2];
            split = ad.Split(' ');

            if (split.Length == 2)
            {
                for (int j = 0; j < split.Length; j++)
                {


                    for (int i = 0; i < split[j].Length; i++)
                    {
                        if (Char.IsLetterOrDigit(split[j][i]))
                        {
                            IsDigit = true; 
                        }

                        else if (char.IsUpper(split[j][0]))
                        {

                            IsUpper = true;

                        }

                        if (!char.IsLower(split[j][i]))
                        {
                            if (i == 0)
                            {
                                continue;
                            }
                          
                        }
                        else
                        {
                            Islower = true;
                        }
                    }

                      


                }
                Length = true;
            }
            else
                return Length;


            if (Length == false || IsUpper == false || IsDigit == true || Islower == false)
            {
                return false;
            }

            else
                return true;
        }

        #endregion
    }
}
