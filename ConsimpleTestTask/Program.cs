using ConsimpleTestTask;
using ConsimpleTestTask.Common;
using ConsimpleTestTask.Constants;

try
{
// Prompting to get response from user

    Console.WriteLine(ResponseMessages.EnterCommandMessage);

    var response = Console.ReadLine();

// While user don't wanna exit the program we'll keep getting response from the remote server

    while (response != ExecutionCodes.Exit.ToString("D"))
    {
        //Getting data
    
        var productsAndCategories = await Worker.GetProductsAndCategoriesData(default);
    
        // Showing parsed data
    
        ResponseFormatter.ShowBuiltResponseTable(productsAndCategories);
    
        // Prompting to get response from user
    
        Console.WriteLine(ResponseMessages.EnterCommandMessage);

        response = Console.ReadLine();
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}