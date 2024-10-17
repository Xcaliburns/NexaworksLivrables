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

void ProblemesEnCoursPour1nProduit1seuleVersion()
{
	string productId= Util.ReadLine("Saisissez l'Id du produit");
    string version = Util.ReadLine("Saisissez la version du produit(exemple : 1,0 ");
    string status = Util.ReadLine("Saisissez le statut du problème : true pour résolu ou false pour non résolu ");

    if (int.TryParse(productId, out int productInt) &&
	     float.TryParse(version , out float versionFloat) &&
	bool.TryParse(status, out bool statusBool))
    {
        var result = from t in Tickets
                     where t.Status == statusBool &&
					 t.ProductVersionOperatingSystem.ProductId == productInt  &&
					 t.ProductVersionOperatingSystem.Version.VersionName == versionFloat
                     select new
                     {
                         t.ProblemDescription,
                         t.Status,                        
                         ProductName = t.ProductVersionOperatingSystem.Version.Product.ProductName,
                         VersionName = t.ProductVersionOperatingSystem.Version.VersionName,
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
        Console.WriteLine("L'Id de la version doit être un nombre valide et le statut doit être 'true' ou 'false'.");
    }
}

ProblemesEnCoursPour1nProduit1seuleVersion();
Console.WriteLine("Appuyez sur F5 pour une autre recherche");
