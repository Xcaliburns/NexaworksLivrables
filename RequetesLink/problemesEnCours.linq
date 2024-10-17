<Query Kind="Statements">
  <Connection>
    <ID>cd6c24d0-c614-45a8-81f3-76ca654b2188</ID>
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
								   t.Status,
								   Resolutions = t.TicketResolutions.Select(r => new 
                                   {
                                       r.ResolutionDescription,
                                       r.ResolutionDate
                                   })
								   
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
