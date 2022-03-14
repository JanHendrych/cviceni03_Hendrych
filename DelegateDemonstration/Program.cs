namespace Program;
using DelegateLib;
using Fei.BaseLib;

class Program
{
    public static IComparable ZiskejKlic(Student? student)
    {
        if (student?.Number != null)
        {
            return student.Number;
        }
        else
        {
            return 0;
        }
    }
    public static int JsousiRovniNumber(Student? st1, Student? st2)
    {
        if (st1?.Number > st2?.Number)
        {
            return 1;
        }
        else if (st1?.Number == st2?.Number)
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }
    public static int JsousiRovniName(Student? st1, Student? st2)
    {
        if (st1?.Name != null && st2?.Name != null)
        {
            return string.Compare(st1?.Name, st2?.Name);
        } return 0;
             
    }
    public static int JsousiRovniFaculty(Student? st1, Student? st2)
    {
        if (st1?.Faculty != null && st2?.Faculty != null)
        {
            return string.Compare(st1?.Faculty.ToString(), st2?.Faculty.ToString());
        }
        return 0;

    }
    static void Main(string[] args)
    {
        // TODO: Vytvořte demonstrační program ...
        //
        // Vytvořte metodu pro získání klíče ze studenta - klíčem je hodnota Number ve studentovi
        // Vytvořte tabulku studentů (StudentsTable, kapacita 20 studentů, klíče viz výše)
        //
        // Vytvořte nekonečný cyklus ve kterém je uživateli zobrazeno menu:
        // 1) Vlož studenta - následuje zadání hodnot studenta a jeho vložení do tabulky
        // 2) Dej studenta - následuje zadání hodnoty Number a vyhledání studenta a jeho výpis do konzole
        // 3) Smaž studenta - následuje zadání hodnoty Number a odstranění studenta a jeho výpis do konzole
        // 4) Vypiš studenty - vypíše všechny studenty do konzole
        // 5) Seřadit studenty podle jména - seřadí studenty podle jména (využijte metodu Sort a vhodnou porovnávací metodu)
        // 6) Seřadit studenty podle čísla - seřadí studenty podle čísla (využijte metodu Sort a vhodnou porovnávací metodu)
        // 7) Seřadit studenty podle fakulty - seřadí studenty podle fakulty (využijte metodu Sort a vhodnou porovnávací metodu)
        // 0) Konec programu
        StudentsTable students = new StudentsTable(20, ZiskejKlic);

        bool cyklus = true;
        while (cyklus)
        {
            int volba = ZobrazMenu();
            switch (volba)
            {
                case 0:
                    cyklus = false;
                    break;
                case 1:
                    Student student = VlozStudenta();
                    students.Add(student);
                    break;
                case 2:
                    Console.WriteLine(students.Get(Reading.ReadInt("Zadej klic")));
                    break;
                case 3:
                    Console.WriteLine(students.Delete(Reading.ReadInt("Zadej klic")));
                    break;
                case 4:
                    Console.WriteLine("\nStudenti:");
                    students.Vypis();
                    Console.WriteLine("-------------------------\n");
                    break;
                case 5:
                    students.Sort(JsousiRovniName);
                    break;
                case 6:
                    students.Sort(JsousiRovniNumber);
                    break;
                case 7:
                    students.Sort(JsousiRovniFaculty);
                    break;
            }
        }
    }

    private static Student VlozStudenta()
    {
        string jmeno = Reading.ReadString("Zadej jmeno");
        int number = Reading.ReadInt("Zadej ID");
        Faculty faculty = new Faculty();
        string nazevFakulty = Reading.ReadString("Nazev fakulty (fes, ff, fei, fcht, dfjp, fzs, fr)");
        switch (nazevFakulty)
        {
            case "fes":
                faculty = Faculty.FES;
                break;
            case "ff":
                faculty = Faculty.FF;
                break;
            case "fei":
                faculty = Faculty.FEI;
                break;
            case "fcht":
                faculty = Faculty.FCHT;
                break;
            case "dfjp":
                faculty = Faculty.DFJP;
                break;
            case "fzs":
                faculty = Faculty.FZS;
                break;
            case "fr":
                faculty = Faculty.FR;
                break;
            default:
                Console.WriteLine("Chyba! \nNastavena fakulta na nezařazeno");
                faculty = Faculty.NEZARAZENO;
                break;
        }
        return new Student(jmeno, number, faculty);
        
    }

    private static int ZobrazMenu()
    {
        Console.WriteLine("1) Vlož studenta");
        Console.WriteLine("2) Dej studenta");
        Console.WriteLine("3) Smaž studenta");
        Console.WriteLine("4) Vypiš studenty");
        Console.WriteLine("5) Seřadit studenty podle jména");
        Console.WriteLine("6) Seřadit studenty podle čísla");
        Console.WriteLine("7) Seřadit studenty podle fakulty");
        Console.WriteLine("0) Konec programu\n");
        return Reading.ReadInt("Tvoje volba");
    }
}
