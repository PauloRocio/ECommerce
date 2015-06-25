using System;
using System.Collections.Generic;
using System.Net;
using RestSharp;

namespace Minutrade.ECommerce.CommonObjects.RestFullRequests
{
    /// <summary>
    /// Classe de execução de requisições em serviços RESTFul.
    /// </summary>
    public static class RestRequests
    {
        private const string ErrorMessage = "Erro ao executar a requisição.";

        /// <summary>
        /// Executa um request de Rest API
        /// </summary>
        /// <param name="method">Tipo do Request</param>
        /// <param name="uri">Uri base</param>
        /// <param name="uriTemplate">Uri do request</param>
        /// <param name="body">Corpo</param>
        /// <param name="parameters">Query parameters</param>
        /// <returns></returns>
        private static IRestResponse Execute(Method method, string uri, string uriTemplate, object body, Dictionary<string, string> parameters = null)
        {
            var client  = new RestClient(new Uri(uri));
            var request = new RestRequest(uriTemplate, method);

            if (parameters != null)
                foreach (var item in parameters)
                    request.AddQueryParameter(item.Key, item.Value);

            if (body != null)
            {
                request.RequestFormat = DataFormat.Json;
                request.AddBody(body);
            }

            var response = client.Execute(request);

            if ((response.StatusCode != HttpStatusCode.Created) && (response.StatusCode != HttpStatusCode.OK))
                throw new ApplicationException(response.Content, response.ErrorException);

            return response;
        }

        /// <summary>
        /// Executa um Request de REST API por Id
        /// </summary>
        /// <param name="method">Tipo de request</param>
        /// <param name="uri">Uri base</param>
        /// <param name="uriTemplate">Uri do request</param>
        /// <param name="body">Corpo do request</param>
        /// <param name="id">Identificador do registro</param>
        /// <returns></returns>
        private static IRestResponse Execute(Method method, string uri, string uriTemplate, object body, long id = 0)
        {
            var client = new RestClient(new Uri(uri));

            if (id != 0)
                uriTemplate += id;

            var request = new RestRequest(uriTemplate, method);

            if (body != null)
            {
                request.RequestFormat = DataFormat.Json;
                request.AddBody(body);
            }

            var response = client.Execute(request);

            if ((response.StatusCode != HttpStatusCode.NoContent) && (response.StatusCode != HttpStatusCode.OK))
                throw new ApplicationException(ErrorMessage, response.ErrorException);

            return response;
        }

        /// <summary>
        /// Execute Get in Web Api
        /// </summary>
        /// <typeparam name="T">Return Type</typeparam>
        /// <param name="uri">Base Uri</param>
        /// <param name="uriTemplate"> Request Uri</param>
        /// <param name="parameters">parameters (optional)</param>
        /// <returns></returns>
        public static T Get<T>(string uri, string uriTemplate, Dictionary<string, string> parameters = null) where T : new()
        {
            var client = new RestClient(new Uri(uri));
            var request = new RestRequest(uriTemplate, Method.GET);

            if (parameters != null)
                foreach (var item in parameters)
                    request.AddQueryParameter(item.Key, item.Value);

            var response = client.Execute<T>(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new ApplicationException(ErrorMessage, response.ErrorException);

            return response.Data;
        }

        /// <summary>
        /// Execute Get in Web Api
        /// </summary>
        /// <typeparam name="T">Return Type</typeparam>
        /// <param name="uri">Base Uri</param>
        /// <param name="uriTemplate"> Request Uri</param>
        /// <param name="id">Identificador do registro</param>
        /// <returns></returns>
        public static T Get<T>(string uri, string uriTemplate, long id) where T : new()
        {
            var client = new RestClient(new Uri(uri));

            uriTemplate += id;

            var request = new RestRequest(uriTemplate, Method.GET);

            var response = client.Execute<T>(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new ApplicationException(ErrorMessage, response.ErrorException);

            return response.Data;
        }

        /// <summary>
        /// Execute Post in WebApi
        /// </summary>
        /// <param name="uri">BaseUri</param>
        /// <param name="uriTemplate">RequestUri</param>
        /// <param name="body">Body</param>
        /// <param name="parameters">parameters (otional)</param>
        public static object Post(string uri, string uriTemplate, object body, Dictionary<string, string> parameters = null)
        {
            return Execute(Method.POST, uri, uriTemplate, body, parameters).Content;
        }

        /// <summary>
        /// Execute Delete in WebApi
        /// </summary>
        /// <param name="uri">BaseUri</param>
        /// <param name="uriTemplate">RequestUri</param>
        /// <param name="id"></param>
        public static void Delete(string uri, string uriTemplate, long id = 0)
        {
            Execute(Method.DELETE, uri, uriTemplate, null, id);
        }

        /// <summary>
        /// Execute Put in WebApi
        /// </summary>
        /// <param name="uri">BaseUri</param>
        /// <param name="uriTemplate">RequestUri</param>
        /// <param name="body">Body</param>
        /// <param name="id"></param>
        public static void Put(string uri, string uriTemplate, object body,long id = 0)
        {
            Execute(Method.PUT, uri, uriTemplate, body, id);
        }
    }
}