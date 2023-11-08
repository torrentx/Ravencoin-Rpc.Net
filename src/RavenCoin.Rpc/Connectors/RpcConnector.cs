using RavenCoin.Rpc.Exceptions;
using RavenCoin.Rpc.Requests;
using RavenCoin.Rpc.Responses;
using RavenCoin.Rpc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Connectors
{
    public sealed class RpcConnector : IRpcConnector
    {
        private readonly ICoinService _coinService;

        public RpcConnector(ICoinService coinService)
        {
            _coinService = coinService;
        }

        public T MakeRequest<T>(JsonRpcRequest request)//(RpcMethods rpcMethod, params object[] parameters)
        {
            request.FlushParameters();
            using (HttpClient client = new HttpClient())
            {
                if (_coinService.Parameters.SelectedDaemonUrl == null)
                {
                    throw new RpcException("Invalid Connection Url");
                }
                client.BaseAddress = new Uri(_coinService.Parameters.SelectedDaemonUrl);
                if (_coinService.Parameters.RpcPassword == null || _coinService.Parameters.RpcUsername == null)
                {
                    throw new RpcException("Invalid Username or Password");
                }
                client.DefaultRequestHeaders.Add("Authorization", GetBasicAuthHeader(_coinService.Parameters.RpcUsername, _coinService.Parameters.RpcPassword));
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, "");
                requestMessage.Content = new StringContent(request.JsonString());
                requestMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                requestMessage.Method = HttpMethod.Post;
                client.Timeout = new TimeSpan(0, 0, _coinService.Parameters.RpcRequestTimeoutInSeconds);

                try
                {
                    var response = client.SendAsync(requestMessage).Result;
                    string json;

                    using (var stream = response.Content.ReadAsStream())
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            var result = reader.ReadToEnd();
                            reader.Dispose();
                            json = result;
                        }
                    }
                    var toRet = JsonSerializer.Deserialize<T>(json);
                    if (toRet != null)
                    {
                        return toRet;
                    }
                    else
                    {
                        throw new RpcResponseDeserializationException("Possible Null Return");
                    }
                }
                catch (WebException webException)
                {
                    #region RPC Internal Server Error (with an Error Code)

                    var webResponse = webException.Response as HttpWebResponse;

                    if (webResponse != null)
                    {
                        switch (webResponse.StatusCode)
                        {
                            case HttpStatusCode.InternalServerError:
                                {
                                    using (var stream = webResponse.GetResponseStream())
                                    {
                                        if (stream == null)
                                        {
                                            throw new RpcException("The RPC request was either not understood by the server or there was a problem executing the request", webException);
                                        }

                                        using (var reader = new StreamReader(stream))
                                        {
                                            var result = reader.ReadToEnd();
                                            reader.Dispose();

                                            try
                                            {
                                                var jsonRpcResponseObject = JsonSerializer.Deserialize<JsonRpcResponse>(result);

                                                var internalServerErrorException = new RpcInternalServerErrorException(jsonRpcResponseObject?.Error.Message??"", webException)
                                                {
                                                    RpcErrorCode = jsonRpcResponseObject?.Error.Code
                                                };

                                                throw internalServerErrorException;
                                            }
                                            catch (JsonException)
                                            {
                                                throw new RpcException(result, webException);
                                            }
                                        }
                                    }
                                }

                            default:
                                throw new RpcException("The RPC request was either not understood by the server or there was a problem executing the request", webException);
                        }
                    }

                    #endregion

                    #region RPC Time-Out

                    if (webException.Message == "The operation has timed out")
                    {
                        throw new RpcRequestTimeoutException(webException.Message);
                    }

                    #endregion

                    throw new RpcException("An unknown web exception occured while trying to read the JSON response", webException);
                }
                catch (JsonException jsonException)
                {
                    throw new RpcResponseDeserializationException("There was a problem deserializing the response from the wallet", jsonException);
                }
                catch (ProtocolViolationException protocolViolationException)
                {
                    throw new RpcException("Unable to connect to the server", protocolViolationException);
                }
                catch (Exception exception)
                {
                    var queryParameters = request.Parameters.Cast<string>().Aggregate(string.Empty, (current, parameter) => current + (parameter + " "));
                    throw new Exception($"A problem was encountered while calling MakeRpcRequest() for: {request.Method} with parameters: {queryParameters}. \nException: {exception.Message}");
                }
            }
        }

        private static string GetBasicAuthHeader(string username, string password)
        {
            var authInfo = username + ":" + password;
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            return "Basic " + authInfo;
        }
    }
}
