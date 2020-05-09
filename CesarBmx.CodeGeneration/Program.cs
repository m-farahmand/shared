using System;

namespace CesarBmx.CodeGeneration
{
    class Program
    {
        //static void Main(string[] args)
        static void Main()
        {
            Console.WriteLine("Hello World!");

            // Find the folder where the Entities are located 
            // Load all classes existing in the previous folder (List<Type> entities)

            // For each entity, let's start replicating. Let's imagine we want to create the entire vertical for License.cs
            // These would be the file types:
            //  - LicenseController.cs
            //  - AddLicenseRequest.cs
            //  - UpdateLicenseRequest.cs
            //  - RemoveLicenseRequest.cs
            //  - LicenseResponse.cs
            //  - LicenseService.cs
            //  - LicenseMessage.cs
            //  - LicenseFactory.cs

            // In order to create the previous files, we need an existing one that would act as a template. We call this "the sibling".
            // Assuming we already have the entire vertical for "User.cs", we go with this one.

            // We need to distinguish between two types of cloning. One is just "find and replace" and the second one requires "templating".
            //  - LicenseController.cs (find and replace) 
            //  - AddLicenseRequest.cs (compiler)(properties) 
            //  - UpdateLicenseRequest.cs (compiler)(properties)
            //  - RemoveLicenseRequest.cs (compiler)(properties)
            //  - LicenseResponse.cs (compiler)(properties)
            //  - LicenseService.cs (find and replace) 
            //  - LicenseMessage.cs (find and replace)
            //  - LicenseFactory.cs (compiler)(assignments)
        }
    }
}
