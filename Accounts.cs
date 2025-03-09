using System.IO.Compression;

namespace Voting
{    
    public class Accountss
{
    public static List<Accountss> Newbie = new List<Accountss>();
    public string UserName{get;set;}
    public string Password{get;set;}
    public string CommittedVote{get;set;}
    public Accountss(string username, string password, string vote)
    {
        UserName = username;
        Password = password;
        CommittedVote = vote;
    }
    public static string LoggedInUser= " ";
    public static void InitializePredefinedAccounts()
    {
        Accountss.Newbie.Add(new Accountss("Ekmek","asdasd123","Aksiyon"));
        Accountss.Newbie.Add(new Accountss("Ahmet","asdasd123","Macera"));
        Accountss.Newbie.Add(new Accountss("Mehmet","asdasd123","Aksiyon"));
        Accountss.Newbie.Add(new Accountss("Elif","asdasd123","Romantizm"));
        Accountss.Newbie.Add(new Accountss("Ayşe","asdasd123","Korku"));
        Accountss.Newbie.Add(new Accountss("Fatma","asdasd123","Korku"));
        Accountss.Newbie.Add(new Accountss("Cumali","asdasd123","Macera"));
        Accountss.Newbie.Add(new Accountss("Fırat","asdasd123","Aksiyon"));
        Accountss.Newbie.Add(new Accountss("Ece","asdasd123","Korku"));
        Accountss.Newbie.Add(new Accountss("Kazım","asdasd123","Aksiyon"));
    }
    public static void ShowVote()
    {
        int aksiyoncount=0;
        int maceracount=0;
        int romantizmcount=0;
        int korkucount=0;
        Console.Clear();
        foreach (var item in Newbie)
        {
            if (item.CommittedVote.Equals("Aksiyon", StringComparison.OrdinalIgnoreCase))
            {                aksiyoncount++;            }
            else if (item.CommittedVote.Equals("Macera", StringComparison.OrdinalIgnoreCase))
            {                maceracount++;            }
            else if (item.CommittedVote.Equals("Romantizm", StringComparison.OrdinalIgnoreCase))
            {                romantizmcount++;    } 
            else if (item.CommittedVote.Equals("Korku", StringComparison.OrdinalIgnoreCase))
            {                korkucount++;            }
        }
        int total=aksiyoncount+maceracount+romantizmcount+korkucount;
        if (total > 0)
        {
            Console.WriteLine($"Aksiyon oyu verenlerin sayısı - {aksiyoncount}  yüzdesi - {(aksiyoncount / (double)total) * 100}%");
            Console.WriteLine($"Macera oyu verenlerin sayısı - {maceracount}  yüzdesi - {(maceracount / (double)total) * 100}%");
            Console.WriteLine($"Romantizm oyu verenlerin sayısı - {romantizmcount}  yüzdesi - {(romantizmcount / (double)total) * 100}%");
            Console.WriteLine($"Korku oyu verenlerin sayısı - {korkucount}  yüzdesi - {(korkucount / (double)total) * 100}%");
        }
        else
        {
            Console.WriteLine("Henüz hiç oy kullanılmamış.");
        }
        Console.ReadLine();
    }
    public static void MyVote()
    {
        Console.Clear();
        var loggedInAccount = Newbie.FirstOrDefault(account => account.UserName.Equals(LoggedInUser, StringComparison.OrdinalIgnoreCase));// dizide arama yaparak- LoggedInUser değişkeni ile eşleşen kullanıcı adına ait dizi satır getirir 

            if (loggedInAccount != null && !string.IsNullOrEmpty(loggedInAccount.CommittedVote))
            {
                Console.WriteLine($"Sizin oyunuz: {loggedInAccount.CommittedVote}");
            }
            else
            {
                Console.WriteLine("Henüz oy kullanmadınız.");
            }
            Console.ReadLine();
            Program.Menu();

    }
    public static void ChangeMyVote()
    {
        Console.Clear();
        var loggedInAccount = Newbie.FirstOrDefault(account => account.UserName.Equals(LoggedInUser, StringComparison.OrdinalIgnoreCase));// dizide arama yaparak- LoggedInUser değişkeni ile eşleşen kullanıcı adına ait dizi satır getirir 

            if (loggedInAccount != null && !string.IsNullOrEmpty(loggedInAccount.CommittedVote))
            {
                Console.WriteLine($"Sizin oyunuz: {loggedInAccount.CommittedVote}");
                Console.WriteLine("Değiştirmek istediğinize emin misiniz? (evet[1],Hayır[2])");
                var input=Console.ReadLine();
                if (input=="1")
                {
                    Console.WriteLine("Değiştirmek istediğiniz türü yazınız Aksiyon, Macera, Romantizm, Korku");
                    loggedInAccount.CommittedVote=Console.ReadLine();
                    Console.WriteLine("işlem başarılı");
                }
                else
                {
                    Program.Menu();
                    return;
                }
            }
            else
            {
                Console.WriteLine("Değiştirmek istediğiniz türü yazınız Aksiyon, Macera, Romantizm, Korku");
                loggedInAccount.CommittedVote=Console.ReadLine();
                Console.WriteLine("işlem başarılı");
            }
            Console.ReadLine();
            Program.Menu();

    }
    public static void CreateAccount()
    {
        Console.Clear();
        Console.Write("Username : ");
        string Uname = Console.ReadLine();
        Console.Write("Password : ");
        string pass = Console.ReadLine();

        bool match = false;
        foreach (var account in Newbie)
        {
            if (account.UserName.Equals(Uname, StringComparison.OrdinalIgnoreCase)) //dizide kullanıcı adının mevcut olup olmadığını kontrol ediyor
            {
                Console.WriteLine("Bu kullanıcı adı zaten mevcut. Tekrar deneyin.");
                Console.ReadLine();
                match = true;
                Program.Start();
                return;
            }
        }
        if (!match)
        {
            Newbie.Add(new Accountss(Uname, pass, ""));
            Console.WriteLine("Kayıt Başarılı");
            Console.ReadLine();
            Program.Start();
        }
    }
    public static void Login()
    {
        Console.Clear();
        Console.Write("Username :");
        string Uname=Console.ReadLine();
        Console.Write("Password :");
        string pass=Console.ReadLine();
        bool match=false;
        for (int i = 0; i < Accountss.Newbie.Count; i++)
        {
            if (Accountss.Newbie[i].UserName.Equals(Uname, StringComparison.OrdinalIgnoreCase) && 
                    Accountss.Newbie[i].Password.Equals(pass, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Giriş başarılı");
                    LoggedInUser=Newbie[i].UserName;
                    match =true;
                    Program.Menu();
                    return;
                }
        }
        if (match==false)
        {
            Console.WriteLine("Kullanıcı adı veya şifre hatalı...");
            Console.ReadLine();
            Login();
        }
    }
  }
}
