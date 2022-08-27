
using api_boberto_services.Models;
using Docker.DotNet;
using Docker.DotNet.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_boberto_services
{
    public class DockerClientManager
    {
        private readonly DockerClient _client;

        public DockerClientManager()
        {
            _client = new DockerClientConfiguration()
                .CreateClient();
                }

        public async Task<IList<ContainerListResponse>> GetContainerList(ContainersListParameters request)
        {
          var response = await _client.Containers.ListContainersAsync(
          request);

          return response;
        }

        public async Task CreateContainer(CreateContainerParameters request)
        {
            await _client.Containers.CreateContainerAsync(request);
        }

        public async Task CreateImage(CreateImageRequest request)
        {
            await _client.Images.CreateImageAsync(request.ImageParams,request.AuthParams, new Progress<JSONMessage>());
        }

      

    }
}
