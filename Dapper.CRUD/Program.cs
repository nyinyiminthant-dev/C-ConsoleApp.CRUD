
using Dapper.CRUD;

Console.WriteLine("Welcome To Dapper CRUD! And Edit (Console App)");
Console.WriteLine();

DapperExamples dp = new DapperExamples();
int count = 1;
string TryAgainAsk()
{

    Console.WriteLine("Do You Want To Try Again? (y) or (n)");
    string i = Console.ReadLine()!;

    return i;
}

int TryAgain()
{
    int i = 1;

    string a = TryAgainAsk();

    if (a == "y" || a == "Y")
    {
        i++;
        count++;

        switch (count)
        {
            case 2:
                Console.WriteLine();
                Console.WriteLine("You Testing Ado C,R,U,D,E " + " ( " + count + "nd " + ") " + " Times");
                Console.WriteLine("________________________________");
                break;

            case 3:


                Console.WriteLine();
                Console.WriteLine("You Testing Ado C,R,U,D,E " + " ( " + count + "rd " + ") " + " Times");
                Console.WriteLine("________________________________");
                break;

            default:
                Console.WriteLine();
                Console.WriteLine("You Testing Ado C,R,U,D,E " + " ( " + count + "th " + ") " + " Times");
                Console.WriteLine("________________________________");
                break;
        }

    }
    else if (a == "n" || a == "N")
    {
        i = 0;
        Console.WriteLine();
        Console.WriteLine("Thanks For Testing.");
        Console.WriteLine("________________________________");
        Console.WriteLine();

        Console.WriteLine("Your Totel Test For Ado C,R,U,D,E = " + count + "st" + " times.");
        count = 1;
    }

    return i;
}

int i = 1;

while (i == 1 || i > 1)
{

    Console.WriteLine(" Chose For C , R , U , D, E");

    string chose = Console.ReadLine()!;
    Console.WriteLine();

    if (chose == null || chose == "")
    {
        Console.WriteLine("Please Chose the Correct one");
    }
    else
    {

        switch (chose)
        {
            case "C":
                Console.WriteLine("Adding New Data");
                Console.WriteLine("______________________");
                Console.WriteLine();
                Console.WriteLine("Please Enter Your Name");
                string name = Console.ReadLine()!;
                Console.WriteLine();
                Console.WriteLine("Please Enter Your Email");
                string emali = Console.ReadLine()!;
                Console.WriteLine();
                Console.WriteLine("_______________________________");

                dp.Insert(name, emali);
                Console.WriteLine();

                i = TryAgain();

                break;

            case "R":

                Console.WriteLine("Data Loading");
                Console.WriteLine("______________________");
                Console.WriteLine();

                dp.Read();

                i = TryAgain();

                break;

            case "U":

                Console.WriteLine("Updating the Data");
                Console.WriteLine("______________________");
                Console.WriteLine();

                Console.WriteLine("Please Enter Id That You Want To Update");
                Console.WriteLine();
                string U = Console.ReadLine()!;
                int update_id = Convert.ToInt32(U);
                Console.WriteLine();

                Console.WriteLine("Please Enter The Name That You Want To Update");
                Console.WriteLine();
                string uname = Console.ReadLine()!;
                Console.WriteLine();

                Console.WriteLine("Please Enter The Email That You Want To Update");
                Console.WriteLine();
                string uemail = Console.ReadLine()!;
                Console.WriteLine();

                dp.Update(update_id, uname, uemail);

                i = TryAgain();

                break;

            case "D":

                Console.WriteLine("Deleting the Data");
                Console.WriteLine("______________________");
                Console.WriteLine();

                Console.WriteLine("Please Enter Id That You Want To Delete");
                Console.WriteLine();
                string D = Console.ReadLine()!;
                int delete_id = Convert.ToInt32(D);
                Console.WriteLine();

                dp.Delete(delete_id);

                i = TryAgain();

                break;

            case "E":
                Console.WriteLine("Editing the  Data");
                Console.WriteLine("______________________");
                Console.WriteLine();

                Console.WriteLine("Please Enter Id That You Want To Edit");
                Console.WriteLine();
                string E = Console.ReadLine()!;
                int edit_id = Convert.ToInt32(E);
                Console.WriteLine();

                dp.Edit(edit_id);
                i = TryAgain();


                break;
        }


    }

}



Console.ReadLine();