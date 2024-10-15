<Query Kind="Statements">
  <Connection>
    <ID>09718ffc-841f-4a49-81fc-367b0c82c189</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Server>localhost</Server>
    <Database>NexaWorks_CodeFirst</Database>
    <DriverData>
      <EncryptSqlTraffic>True</EncryptSqlTraffic>
      <PreserveNumeric1>True</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
    </DriverData>
  </Connection>
  <RuntimeVersion>8.0</RuntimeVersion>
</Query>

void ProblemesEnCours()
{
    string resolution = Util.ReadLine("Saisissez le statut du produit : true pour résolu ou false pour non résolu ");

    if (bool.TryParse(resolution, out bool resolutionStatus))
    {
        var problemesEnCours = from t in Tickets
                               where t.Status == resolutionStatus
                               select new
                               {
                                   t.CreationDate,
                                   t.ProblemDescription,
								   t.Status
								   
                               };

        problemesEnCours.Dump();
    }
    else
    {
        Console.WriteLine("La valeur entrée est incorrecte. Seuls 'true' et 'false' sont acceptés.");
    }
}

ProblemesEnCours();
Console.WriteLine("Appuyez sur F5 pour une autre recherche");
