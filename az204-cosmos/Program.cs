using Microsoft.Azure.Cosmos;
using System;
using System.Threading.Tasks;

public class Program
{
    private static readonly string EndpointUri = "<Place Document Endpoint URI Value Here >";
    private static readonly string PrimaryKey = "<Place Primary Master Key Value Here>;
    private CosmosClient cosmosClient;
    private Database database;
    private Container container;
    private string databaseId = "az204Database";
    private string containerId = "az204Container";

    public static async Task Main(string[] args)
    {
        try
        {
            Console.WriteLine("Beginning Operations...\n");
            Program p = new Program();
            await p.CosmosAsync();
        }
        catch (CosmosException de)
        {
            Exception baseException = de.GetBaseException();
            Console.WriteLine("{0} error occurred: {1}", de.StatusCode, de);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: {0}", e);
        }
        finally
        {
            Console.WriteLine("End of program, press any key to exit.");
            Console.ReadKey();
        }
    }

    public async Task CosmosAsync()
    {
        this.cosmosClient = new CosmosClient(EndpointUri, PrimaryKey);
        await this.CreateDatabaseAsync();
        await this.CreateContainerAsync();
    }

    private async Task CreateDatabaseAsync()
    {
        DatabaseResponse databaseResponse = await this.cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);
        this.database = databaseResponse.Database;
        Console.WriteLine("Created Database: {0}\n", this.database.Id);
    }

    private async Task CreateContainerAsync()
    {
        ContainerResponse containerResponse = await this.database.CreateContainerIfNotExistsAsync(containerId, "/LastName");
        this.container = containerResponse.Container;
        Console.WriteLine("Created Container: {0}\n", this.container.Id);
    }
}
