using Docker.DotNet;
using Docker.DotNet.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    public class DockerDotNetTask
    {
        public async Task ExecuteAsync()
        {
            var config = new DockerClientConfiguration(new Uri("tcp://yourip"));

            DockerClient client = config.CreateClient();

            var containers = await client.Containers.ListContainersAsync(new ContainersListParameters
            {
                Limit = 10
            });

            var container = await client.Containers.CreateContainerAsync(new CreateContainerParameters(new Config())
            {
                Env = new List<string> { "PESQUISA=ANYTHING" },
                Image = "YourImageName",
                Name = "YourContainerName",
                Cmd = new List<string> {"--net bridge"}
            });

           await client.Containers.StartContainerAsync(container.ID, new ContainerStartParameters());
        }
    }
}