<Query Kind="Statements">
  <Connection>
    <ID>156f5571-9d6c-4b8d-b830-81743d2ab3b3</ID>
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

void RechercheTtoutProbParPeriodePourUnProduit1Version()
{
    string productId = Util.ReadLine("Saisissez l'Id du produit ");
    string version = Util.ReadLine("Saisissez la version du produit (exemple: 1,0)");
    string debutPeriode = Util.ReadLine("Saisissez le début de la période recherchée au format AAAA/MM/DD");
    string finPeriode = Util.ReadLine("Saisissez la fin de la période recherchée au format AAAA/MM/DD");
    string status = Util.ReadLine("Saisissez le statut du problème : true pour résolu, false pour non résolu, ou all pour tous les problèmes ");

    if (int.TryParse(productId, out int productIdInt) && 
        DateTime.TryParse(debutPeriode, out DateTime debutPeriodeDate) && 
        DateTime.TryParse(finPeriode, out DateTime finPeriodeDate) && 
        float.TryParse(version, out float versionFloat))
    {
        var result = from t in Tickets
                     where t.ProductVersionOperatingSystem.ProductId == productIdInt &&
                           debutPeriodeDate <= t.CreationDate &&
                           finPeriodeDate >= t.CreationDate &&
                           t.ProductVersionOperatingSystem.Version.VersionName == versionFloat &&
                           (status == "all" || t.Status == bool.Parse(status))
                     select new
                     {
                         t.ProblemDescription,
                         t.ProductVersionOperatingSystemId,
                         t.Status,
                         t.ProductVersionOperatingSystem.Product.ProductName,
                         t.ProductVersionOperatingSystem.Version.VersionName,
                         t.CreationDate,
					     Resolutions = t.TicketResolutions.Select(r => new 
                                   {
                                       r.ResolutionDescription,
                                       r.ResolutionDate
                                   })	 
                     };
        result.Dump();
    }
    else
    {
        if (!int.TryParse(productId, out _))
        {
            Console.WriteLine("L'ID du produit n'est pas un nombre valide.");
        }
        else if (!DateTime.TryParse(debutPeriode, out _))
        {
            Console.WriteLine("La date de début n'est pas valide.");
        }
        else if (!DateTime.TryParse(finPeriode, out _))
        {
            Console.WriteLine("La date de fin n'est pas valide.");
        }
        else if (!float.TryParse(version, out _))
        {
            Console.WriteLine("La version du produit n'est pas valide.");
        }
        else if (!bool.TryParse(status, out _))
        {
            Console.WriteLine("Le statut du problème n'est pas valide. Veuillez saisir 'true', 'false' ou 'all'.");
        }
    }
}

RechercheTtoutProbParPeriodePourUnProduit1Version();
Console.WriteLine("Appuyez sur F5 pour une autre recherche");
