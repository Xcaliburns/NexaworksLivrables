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
  <Reference Relative="..\..\source\repos\NexaWorks\NexaWorks\bin\Debug\net8.0\NexaWorks.dll">&lt;UserProfile&gt;\source\repos\NexaWorks\NexaWorks\bin\Debug\net8.0\NexaWorks.dll</Reference>
</Query>

void RechercheTtoutProbParPeriodePourUnProduitTouteVersion()
{
    string productId = Util.ReadLine("Saisissez l'Id du produit ");
    string debutPeriode = Util.ReadLine("Saisissez le début de la période recherchée au format AAAA/MM/DD");
    string finPeriode = Util.ReadLine("Saisissez la fin de la période recherchée au format AAAA/MM/DD");
    string status = Util.ReadLine("Saisissez le statut du problème : true pour résolu, false pour non résolu, ou all pour tous les problèmes ");

    if (int.TryParse(productId, out int productIdInt) && 
        DateTime.TryParse(debutPeriode, out DateTime debutPeriodeDate) && 
        DateTime.TryParse(finPeriode, out DateTime finPeriodeDate))
    {
        var result = from t in Tickets
                     where t.ProductVersionOperatingSystem.ProductId == productIdInt && 
                           debutPeriodeDate <= t.CreationDate && 
                           finPeriodeDate >= t.CreationDate &&
                           (status == "all" || t.Status == bool.Parse(status))
                     select new
                     {
                         t.ProblemDescription,
                         t.ProductVersionOperatingSystemId,
                         t.Status,
                         t.ProductVersionOperatingSystem.Product.ProductName,
                         t.CreationDate
                     };
        result.Dump();
    }
    else
    {
        Console.WriteLine("L'ID du produit, les dates ou le statut ne sont pas valides.");
    }
}

RechercheTtoutProbParPeriodePourUnProduitTouteVersion();
Console.WriteLine("Appuyez sur F5 pour une autre recherche");
