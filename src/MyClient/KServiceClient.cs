﻿//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v12.2.5.0 (NJsonSchema v9.13.37.0 (Newtonsoft.Json v11.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

namespace KService.Client
{
    #pragma warning disable

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "12.2.5.0 (NJsonSchema v9.13.37.0 (Newtonsoft.Json v11.0.0.0))")]
    public partial class UploadClient 
    {
        private string _baseUrl = "";
        private System.Net.Http.HttpClient _httpClient;
        private System.Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;
    
        public UploadClient(string baseUrl, System.Net.Http.HttpClient httpClient)
        {
            BaseUrl = baseUrl; 
            _httpClient = httpClient; 
            _settings = new System.Lazy<Newtonsoft.Json.JsonSerializerSettings>(() => 
            {
                var settings = new Newtonsoft.Json.JsonSerializerSettings();
                UpdateJsonSerializerSettings(settings);
                return settings;
            });
        }
    
        public string BaseUrl 
        {
            get { return _baseUrl; }
            set { _baseUrl = value; }
        }
    
        protected Newtonsoft.Json.JsonSerializerSettings JsonSerializerSettings { get { return _settings.Value; } }
    
        partial void UpdateJsonSerializerSettings(Newtonsoft.Json.JsonSerializerSettings settings);
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url);
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder);
        partial void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response);
    
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<FileResponse> MetadataAsync(Metadata data)
        {
            return MetadataAsync(data, System.Threading.CancellationToken.None);
        }
    
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async System.Threading.Tasks.Task<FileResponse> MetadataAsync(Metadata data, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Upload/Metadata");
    
            var client_ = _httpClient;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(data, _settings.Value));
                    content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/octet-stream"));
    
                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);
    
                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }
    
                        ProcessResponse(client_, response_);
    
                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200" || status_ == "206") 
                        {
                            var responseStream_ = response_.Content == null ? System.IO.Stream.Null : await response_.Content.ReadAsStreamAsync().ConfigureAwait(false);
                            var fileResponse_ = new FileResponse((int)response_.StatusCode, headers_, responseStream_, null, response_); 
                            client_ = null; response_ = null; // response and client are disposed by FileResponse
                            return fileResponse_;
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                        }
            
                        return default(FileResponse);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
            }
        }
    
        /// <param name="file">file chunk</param>
        /// <param name="json">json data</param>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<FileResponse> UploadWithMetadataAsync(FileParameter file, string json)
        {
            return UploadWithMetadataAsync(file, json, System.Threading.CancellationToken.None);
        }
    
        /// <param name="file">file chunk</param>
        /// <param name="json">json data</param>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async System.Threading.Tasks.Task<FileResponse> UploadWithMetadataAsync(FileParameter file, string json, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Upload/UploadWithMetadataAsync");
    
            var client_ = _httpClient;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var boundary_ = System.Guid.NewGuid().ToString();
                    var content_ = new System.Net.Http.MultipartFormDataContent(boundary_);
                    content_.Headers.Remove("Content-Type");
                    content_.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data; boundary=" + boundary_);
                    if (file == null)
                        throw new System.ArgumentNullException("file");
                    else
                    {
                        var content_file_ = new System.Net.Http.StreamContent(file.Data);
                        if (!string.IsNullOrEmpty(file.ContentType))
                            content_file_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse(file.ContentType);
                        content_.Add(content_file_, "file", file.FileName ?? "file");
                    }
                    if (json == null)
                        throw new System.ArgumentNullException("json");
                    else
                    {
                        content_.Add(new System.Net.Http.StringContent(ConvertToString(json, System.Globalization.CultureInfo.InvariantCulture)), "json");
                    }
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/octet-stream"));
    
                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);
    
                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }
    
                        ProcessResponse(client_, response_);
    
                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200" || status_ == "206") 
                        {
                            var responseStream_ = response_.Content == null ? System.IO.Stream.Null : await response_.Content.ReadAsStreamAsync().ConfigureAwait(false);
                            var fileResponse_ = new FileResponse((int)response_.StatusCode, headers_, responseStream_, null, response_); 
                            client_ = null; response_ = null; // response and client are disposed by FileResponse
                            return fileResponse_;
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                        }
            
                        return default(FileResponse);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
            }
        }
    
        /// <param name="file">file chunk</param>
        /// <param name="json">json data</param>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<FileResponse> UploadAsync(FileParameter file, string json)
        {
            return UploadAsync(file, json, System.Threading.CancellationToken.None);
        }
    
        /// <param name="file">file chunk</param>
        /// <param name="json">json data</param>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async System.Threading.Tasks.Task<FileResponse> UploadAsync(FileParameter file, string json, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/Upload/Upload");
    
            var client_ = _httpClient;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var boundary_ = System.Guid.NewGuid().ToString();
                    var content_ = new System.Net.Http.MultipartFormDataContent(boundary_);
                    content_.Headers.Remove("Content-Type");
                    content_.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data; boundary=" + boundary_);
                    if (file == null)
                        throw new System.ArgumentNullException("file");
                    else
                    {
                        var content_file_ = new System.Net.Http.StreamContent(file.Data);
                        if (!string.IsNullOrEmpty(file.ContentType))
                            content_file_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse(file.ContentType);
                        content_.Add(content_file_, "file", file.FileName ?? "file");
                    }
                    if (json == null)
                        throw new System.ArgumentNullException("json");
                    else
                    {
                        content_.Add(new System.Net.Http.StringContent(ConvertToString(json, System.Globalization.CultureInfo.InvariantCulture)), "json");
                    }
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/octet-stream"));
    
                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);
    
                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }
    
                        ProcessResponse(client_, response_);
    
                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200" || status_ == "206") 
                        {
                            var responseStream_ = response_.Content == null ? System.IO.Stream.Null : await response_.Content.ReadAsStreamAsync().ConfigureAwait(false);
                            var fileResponse_ = new FileResponse((int)response_.StatusCode, headers_, responseStream_, null, response_); 
                            client_ = null; response_ = null; // response and client are disposed by FileResponse
                            return fileResponse_;
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false); 
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                        }
            
                        return default(FileResponse);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
            }
        }
    
        private string ConvertToString(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value is System.Enum)
            {
                string name = System.Enum.GetName(value.GetType(), value);
                if (name != null)
                {
                    var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                    if (field != null)
                    {
                        var attribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field, typeof(System.Runtime.Serialization.EnumMemberAttribute)) 
                            as System.Runtime.Serialization.EnumMemberAttribute;
                        if (attribute != null)
                        {
                            return attribute.Value != null ? attribute.Value : name;
                        }
                    }
                }
            }
            else if (value is bool) {
                return System.Convert.ToString(value, cultureInfo).ToLowerInvariant();
            }
            else if (value is byte[])
            {
                return System.Convert.ToBase64String((byte[]) value);
            }
            else if (value != null && value.GetType().IsArray)
            {
                var array = System.Linq.Enumerable.OfType<object>((System.Array) value);
                return string.Join(",", System.Linq.Enumerable.Select(array, o => ConvertToString(o, cultureInfo)));
            }
        
            return System.Convert.ToString(value, cultureInfo);
        }
    }
    
    

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.13.37.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Metadata 
    {
        [Newtonsoft.Json.JsonProperty("f1", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string F1 { get; set; }
    
        [Newtonsoft.Json.JsonProperty("f2", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string F2 { get; set; }
    
        [Newtonsoft.Json.JsonProperty("f3", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string F3 { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    
        public static Metadata FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Metadata>(data);
        }
    
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "12.2.5.0 (NJsonSchema v9.13.37.0 (Newtonsoft.Json v11.0.0.0))")]
    public partial class FileParameter
    {
        public FileParameter(System.IO.Stream data)
            : this (data, null)
        {
        }

        public FileParameter(System.IO.Stream data, string fileName)
            : this (data, fileName, null)
        {
        }

        public FileParameter(System.IO.Stream data, string fileName, string contentType)
        {
            Data = data;
            FileName = fileName;
            ContentType = contentType;
        }

        public System.IO.Stream Data { get; private set; }

        public string FileName { get; private set; }

        public string ContentType { get; private set; }
    }

    public partial class FileResponse : System.IDisposable
    {
        private System.IDisposable _client; 
        private System.IDisposable _response; 

        public int StatusCode { get; private set; }

        public System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> Headers { get; private set; }

        public System.IO.Stream Stream { get; private set; }

        public bool IsPartial
        {
            get { return StatusCode == 206; }
        }

        public FileResponse(int statusCode, System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.IO.Stream stream, System.IDisposable client, System.IDisposable response)
        {
            StatusCode = statusCode; 
            Headers = headers; 
            Stream = stream; 
            _client = client; 
            _response = response;
        }

        public void Dispose() 
        {
            if (Stream != null)
                Stream.Dispose();
            if (_response != null)
                _response.Dispose();
            if (_client != null)
                _client.Dispose();
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "12.2.5.0 (NJsonSchema v9.13.37.0 (Newtonsoft.Json v11.0.0.0))")]
    public partial class SwaggerException : System.Exception
    {
        public int StatusCode { get; private set; }

        public string Response { get; private set; }

        public System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> Headers { get; private set; }

        public SwaggerException(string message, int statusCode, string response, System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Exception innerException) 
            : base(message + "\n\nStatus: " + statusCode + "\nResponse: \n" + response.Substring(0, response.Length >= 512 ? 512 : response.Length), innerException)
        {
            StatusCode = statusCode;
            Response = response; 
            Headers = headers;
        }

        public override string ToString()
        {
            return string.Format("HTTP Response: \n\n{0}\n\n{1}", Response, base.ToString());
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "12.2.5.0 (NJsonSchema v9.13.37.0 (Newtonsoft.Json v11.0.0.0))")]
    public partial class SwaggerException<TResult> : SwaggerException
    {
        public TResult Result { get; private set; }

        public SwaggerException(string message, int statusCode, string response, System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> headers, TResult result, System.Exception innerException) 
            : base(message, statusCode, response, headers, innerException)
        {
            Result = result;
        }
    }

    #pragma warning restore
}