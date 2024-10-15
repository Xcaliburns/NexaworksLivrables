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

void ProblemesEnCoursPour1VersionMotCle()
{
    string motsCles = Util.ReadLine("Saisissez les mots clés séparés par des virgules ");
    string productId = Util.ReadLine("Saisissez l'Id du produit ");
    string version = Util.ReadLine("Saisissez la version exemple 1,0 ");
    string status = Util.ReadLine("Saisissez le statut du problème : true pour résolu, false pour non résolu, ou all pour tous les problèmes ");

    if (motsCles != null && 
        int.TryParse(productId, out int productIdInt) && 
        float.TryParse(version, out float versionFloat) && 
        (status == "true" || status == "false" || status == "all"))
    {
        bool? statusBool = status == "all" ? (bool?)null : bool.Parse(status);
        var motsClesListe = motsCles.Split(',').Select(m => m.Trim()).ToList();

        var result = from t in Tickets
                     where (statusBool == null || t.Status == statusBool) &&
                           motsClesListe.Any(motCle => t.ProblemDescription.Contains(motCle)) &&
                           t.ProductVersionOperatingSystem.ProductId == productIdInt &&
                           t.ProductVersionOperatingSystem.Version.VersionName == versionFloat
                     select new
                     {
                         t.ProblemDescription,
                         t.ProductVersionOperatingSystemId,
                         t.Status,
                         t.ProductVersionOperatingSystem.Product.ProductName,
                         t.ProductVersionOperatingSystem.Version.VersionName,
                         t.CreationDate
                     };
        result.Dump();
    }
    else
    {
        Console.WriteLine("Les mots clés, l'ID du produit, la version ou le statut du problème ne sont pas valides.");
    }
}

ProblemesEnCoursPour1VersionMotCle();
Console.WriteLine("Appuyez sur F5 pour une autre recherche");
