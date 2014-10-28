
using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Collections.Generic;
using Concur.Util;
using Concur.Connect.V1.Serializable;
using Concur.Connect.V3.Serializable;

namespace Concur.Connect.V3
{

    /// <summary>
    /// Concur Connect Service
    /// </summary>
    public class ConnectService
    {
        /// <summary>
        /// Constructor for this object.
        /// </summary>
        /// <param name="accessToken">Access token to be used when making calls to this service.</param>
        /// <param name="instanceUrl">Instance URL obtained when the access token was generated. This URL determines the datacenter that should be used to serve calls of this service.</param>
        /// <param name="timeoutInMilliseconds">Optional timeout in milliseconds to be assumed by all methods of this service object</param>
        /// <param name="remoteServiceBaseUrl">Optional base URL to be assumed by all methods of this service object. E.g. "https://www.concursolutions.com/api/v3.0"</param>
        public ConnectService(string accessToken, string instanceUrl = @"https://www.concursolutions.com/", int timeoutInMilliseconds = 90000, string remoteServiceBaseUrl = @"https://www.concursolutions.com/api/v3.0")
        {
            UserCredential = new ConcurOAuthCredential(accessToken, instanceUrl);
            CallOptions = new ConcurCallOptions(timeoutInMilliseconds, remoteServiceBaseUrl);
            Util = new ConcurUtil();
        }

        public ConcurOAuthCredential UserCredential { get; protected set; }
        public ConcurCallOptions CallOptions { get; protected set; }
        protected ConcurUtil Util { get; set; }


        /// <summary>
        /// Get all allocations per entry or report
        /// </summary>
        /// <param name="entryID">The unique identifier for the expense entry.</param>
        /// <param name="itemizationID">The unique identifier for the expense itemization.</param>
        /// <param name="reportID">The unique identifier for the report as it appears in the Concur Expense UI. Variable-length string. The maximum lenght is 32 characters.</param>
        /// <param name="limit">The number of records to return. The default is 25 and the maximum is 100.</param>
        /// <param name="offset">The start of the page offset. The default is the beginning of the page.</param>
        /// <param name="user">The login ID of the user. Optional.</param>
        public AllocationCollection GetExpenseAllocations(string entryID = null, string itemizationID = null, string reportID = null, Int32? limit = null, string offset = null, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/allocations";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("entryID", entryID)
                ,new KeyValuePair<string,object>("itemizationID", itemizationID)
                ,new KeyValuePair<string,object>("reportID", reportID)
                ,new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)
                ,new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<AllocationCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Get all allocations per entry or report
        /// </summary>
        /// <param name="entryID">The unique identifier for the expense entry.</param>
        /// <param name="itemizationID">The unique identifier for the expense itemization.</param>
        /// <param name="reportID">The unique identifier for the report as it appears in the Concur Expense UI. Variable-length string. The maximum lenght is 32 characters.</param>
        /// <param name="limit">The number of records to return. The default is 25 and the maximum is 100.</param>
        /// <param name="offset">The start of the page offset. The default is the beginning of the page.</param>
        /// <param name="user">The login ID of the user. Optional.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<AllocationCollection> GetExpenseAllocationsAsync(string entryID = null, string itemizationID = null, string reportID = null, Int32? limit = null, string offset = null, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/allocations";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("entryID", entryID)
                ,new KeyValuePair<string,object>("itemizationID", itemizationID)
                ,new KeyValuePair<string,object>("reportID", reportID)
                ,new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)
                ,new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<AllocationCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a single allocation by ID
        /// </summary>
        /// <param name="id">The unique identifier for the allocation.</param>
        /// <param name="user">The login ID of the user. Optional.</param>
        public AllocationGet GetExpenseAllocationsById(string id, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/allocations/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<AllocationGet>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Get a single allocation by ID
        /// </summary>
        /// <param name="id">The unique identifier for the allocation.</param>
        /// <param name="user">The login ID of the user. Optional.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<AllocationGet> GetExpenseAllocationsByIdAsync(string id, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/allocations/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<AllocationGet>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get all attendees
        /// </summary>
        /// <param name="attendeeTypeID">Get information for attendees matching the specified attendee type ID.</param>
        /// <param name="externalID">Get information for all attendees matching the specified external IDs.  Up to 10 comma-separated external IDs may be specified.</param>
        /// <param name="limit">Number of records to return. The default is 25.</param>
        /// <param name="offset">The start of the page offset. The default is the beginning of the page.</param>
        /// <param name="user">The login ID of the user. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public AttendeeCollection GetExpenseAttendees(string attendeeTypeID = null, string externalID = null, Int32? limit = null, string offset = null, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/attendees";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("attendeeTypeID", attendeeTypeID)
                ,new KeyValuePair<string,object>("externalID", externalID)
                ,new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)
                ,new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<AttendeeCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Get all attendees
        /// </summary>
        /// <param name="attendeeTypeID">Get information for attendees matching the specified attendee type ID.</param>
        /// <param name="externalID">Get information for all attendees matching the specified external IDs.  Up to 10 comma-separated external IDs may be specified.</param>
        /// <param name="limit">Number of records to return. The default is 25.</param>
        /// <param name="offset">The start of the page offset. The default is the beginning of the page.</param>
        /// <param name="user">The login ID of the user. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<AttendeeCollection> GetExpenseAttendeesAsync(string attendeeTypeID = null, string externalID = null, Int32? limit = null, string offset = null, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/attendees";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("attendeeTypeID", attendeeTypeID)
                ,new KeyValuePair<string,object>("externalID", externalID)
                ,new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)
                ,new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<AttendeeCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a single attendee by ID
        /// </summary>
        /// <param name="id">The attendee ID.</param>
        /// <param name="user">The login ID of the user. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public AttendeeGet GetExpenseAttendeesById(string id, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/attendees/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<AttendeeGet>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Get a single attendee by ID
        /// </summary>
        /// <param name="id">The attendee ID.</param>
        /// <param name="user">The login ID of the user. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<AttendeeGet> GetExpenseAttendeesByIdAsync(string id, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/attendees/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<AttendeeGet>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new attendee
        /// </summary>
        /// <param name="content">Attendee object to create.</param>
        /// <param name="user">The login ID of the user. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public CreateResponse CreateExpenseAttendees(AttendeePost content, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/attendees";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<CreateResponse>(
                "POST",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Create a new attendee
        /// </summary>
        /// <param name="content">Attendee object to create.</param>
        /// <param name="user">The login ID of the user. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<CreateResponse> CreateExpenseAttendeesAsync(AttendeePost content, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/attendees";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<CreateResponse>(
                "POST",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update an attendee by ID
        /// </summary>
        /// <param name="id">The attendee ID.</param>
        /// <param name="content">Partial or complete attendee object to update.</param>
        /// <param name="user">The login ID of the user. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public Object UpdateExpenseAttendeesById(string id, AttendeePut content, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/attendees/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<Object>(
                "PUT",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Update an attendee by ID
        /// </summary>
        /// <param name="id">The attendee ID.</param>
        /// <param name="content">Partial or complete attendee object to update.</param>
        /// <param name="user">The login ID of the user. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<Object> UpdateExpenseAttendeesByIdAsync(string id, AttendeePut content, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/attendees/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<Object>(
                "PUT",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete an attendee by ID
        /// </summary>
        /// <param name="id">ID of the attendee to delete.</param>
        /// <param name="user">The login ID of the user. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public Object DeleteExpenseAttendeesById(string id, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/attendees/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<Object>(
                "DELETE",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Delete an attendee by ID
        /// </summary>
        /// <param name="id">ID of the attendee to delete.</param>
        /// <param name="user">The login ID of the user. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<Object> DeleteExpenseAttendeesByIdAsync(string id, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/attendees/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<Object>(
                "DELETE",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all attendee types.
        /// </summary>
        /// <param name="limit">Number of records to return (default 25).</param>
        /// <param name="offset">Starting page offset.</param>
        public AttendeeTypesCollection GetExpenseAttendeeTypes(Int32? limit = null, string offset = null)
        {
            string remoteServiceRelativeUrl = @"/expense/attendeetypes";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<AttendeeTypesCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Gets all attendee types.
        /// </summary>
        /// <param name="limit">Number of records to return (default 25).</param>
        /// <param name="offset">Starting page offset.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<AttendeeTypesCollection> GetExpenseAttendeeTypesAsync(Int32? limit = null, string offset = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/attendeetypes";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<AttendeeTypesCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a single AttendeeType by ID
        /// </summary>
        /// <param name="id">AttendeeType ID.</param>
        public AttendeeTypeGet GetExpenseAttendeeTypesById(string id)
        {
            string remoteServiceRelativeUrl = @"/expense/attendeetypes/{id}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<AttendeeTypeGet>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Get a single AttendeeType by ID
        /// </summary>
        /// <param name="id">AttendeeType ID.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<AttendeeTypeGet> GetExpenseAttendeeTypesByIdAsync(string id, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/attendeetypes/{id}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<AttendeeTypeGet>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete an AttendeeType by ID
        /// </summary>
        /// <param name="id">ID of the AttendeeType to delete.</param>
        public Object DeleteExpenseAttendeeTypesById(string id)
        {
            string remoteServiceRelativeUrl = @"/expense/attendeetypes/{id}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<Object>(
                "DELETE",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Delete an AttendeeType by ID
        /// </summary>
        /// <param name="id">ID of the AttendeeType to delete.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<Object> DeleteExpenseAttendeeTypesByIdAsync(string id, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/attendeetypes/{id}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<Object>(
                "DELETE",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new AttendeeType
        /// </summary>
        /// <param name="content">AttendeeType object to create.</param>
        public CreateResponse CreateExpenseAttendeeTypes(AttendeeTypePost content)
        {
            string remoteServiceRelativeUrl = @"/expense/attendeetypes";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<CreateResponse>(
                "POST",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Create a new AttendeeType
        /// </summary>
        /// <param name="content">AttendeeType object to create.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<CreateResponse> CreateExpenseAttendeeTypesAsync(AttendeeTypePost content, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/attendeetypes";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<CreateResponse>(
                "POST",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update an AttendeeType by ID
        /// </summary>
        /// <param name="id">AttendeeType ID.</param>
        /// <param name="content">Partial or complete AttendeeType object to update.</param>
        public Object UpdateExpenseAttendeeTypesById(string id, AttendeeTypePut content)
        {
            string remoteServiceRelativeUrl = @"/expense/attendeetypes/{id}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<Object>(
                "PUT",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Update an AttendeeType by ID
        /// </summary>
        /// <param name="id">AttendeeType ID.</param>
        /// <param name="content">Partial or complete AttendeeType object to update.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<Object> UpdateExpenseAttendeeTypesByIdAsync(string id, AttendeeTypePut content, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/attendeetypes/{id}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<Object>(
                "PUT",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get all connection requests
        /// </summary>
        /// <param name="status">The status code representing the state of the connection request. The possible values are Pending, Processing, Connected, Failed, and Retry.</param>
        /// <param name="limit">The number of records to return. The default is 5 and the maximum is 10.</param>
        /// <param name="offset">The start of the page offset. The default is the beginning of the page.</param>
        public ConnectionRequestCollection GetCommonConnectionRequests(string status = null, Int32? limit = null, string offset = null)
        {
            string remoteServiceRelativeUrl = @"/common/connectionrequests";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("status", status)
                ,new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<ConnectionRequestCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Get all connection requests
        /// </summary>
        /// <param name="status">The status code representing the state of the connection request. The possible values are Pending, Processing, Connected, Failed, and Retry.</param>
        /// <param name="limit">The number of records to return. The default is 5 and the maximum is 10.</param>
        /// <param name="offset">The start of the page offset. The default is the beginning of the page.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<ConnectionRequestCollection> GetCommonConnectionRequestsAsync(string status = null, Int32? limit = null, string offset = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/common/connectionrequests";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("status", status)
                ,new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<ConnectionRequestCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a connection request by ID
        /// </summary>
        /// <param name="id">The connection request ID.</param>
        public ConnectionRequestGet GetCommonConnectionRequestsById(string id)
        {
            string remoteServiceRelativeUrl = @"/common/connectionrequests/{id}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<ConnectionRequestGet>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Get a connection request by ID
        /// </summary>
        /// <param name="id">The connection request ID.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<ConnectionRequestGet> GetCommonConnectionRequestsByIdAsync(string id, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/common/connectionrequests/{id}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<ConnectionRequestGet>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a connection request
        /// </summary>
        /// <param name="user">The login ID of the user. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public CreateResponse CreateCommonConnectionRequestsByUser(string user)
        {
            string remoteServiceRelativeUrl = @"/common/connectionrequests";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<CreateResponse>(
                "POST",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Create a connection request
        /// </summary>
        /// <param name="user">The login ID of the user. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<CreateResponse> CreateCommonConnectionRequestsByUserAsync(string user, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/common/connectionrequests";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<CreateResponse>(
                "POST",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a connection request by ID
        /// </summary>
        /// <param name="id">The connection request ID.</param>
        /// <param name="content">The connection request object to update.</param>
        public Object UpdateCommonConnectionRequestsById(string id, ConnectionRequestPut content)
        {
            string remoteServiceRelativeUrl = @"/common/connectionrequests/{id}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<Object>(
                "PUT",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Update a connection request by ID
        /// </summary>
        /// <param name="id">The connection request ID.</param>
        /// <param name="content">The connection request object to update.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<Object> UpdateCommonConnectionRequestsByIdAsync(string id, ConnectionRequestPut content, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/common/connectionrequests/{id}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<Object>(
                "PUT",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete a connection request
        /// </summary>
        /// <param name="id">The connection request ID.</param>
        public Object DeleteCommonConnectionRequestsById(string id)
        {
            string remoteServiceRelativeUrl = @"/common/connectionrequests/{id}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<Object>(
                "DELETE",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Delete a connection request
        /// </summary>
        /// <param name="id">The connection request ID.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<Object> DeleteCommonConnectionRequestsByIdAsync(string id, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/common/connectionrequests/{id}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<Object>(
                "DELETE",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all digital tax invoices
        /// </summary>
        /// <param name="modifiedafter">Optional modified date of the queue record for the digital tax  invoice. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="limit">Number of records to return (default 25)</param>
        /// <param name="offset">Starting page offset</param>
        public DigitalTaxInvoiceCollection GetExpenseDigitalTaxInvoices(string modifiedafter = null, Int32? limit = null, string offset = null)
        {
            string remoteServiceRelativeUrl = @"/expense/digitaltaxinvoices";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("modifiedafter", modifiedafter)
                ,new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<DigitalTaxInvoiceCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Gets all digital tax invoices
        /// </summary>
        /// <param name="modifiedafter">Optional modified date of the queue record for the digital tax  invoice. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="limit">Number of records to return (default 25)</param>
        /// <param name="offset">Starting page offset</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<DigitalTaxInvoiceCollection> GetExpenseDigitalTaxInvoicesAsync(string modifiedafter = null, Int32? limit = null, string offset = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/digitaltaxinvoices";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("modifiedafter", modifiedafter)
                ,new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<DigitalTaxInvoiceCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a single Digital Tax Invoice by ID
        /// </summary>
        /// <param name="id">DigitalTaxInvoice ID</param>
        public DigitalTaxInvoiceGetSingle GetExpenseDigitalTaxInvoicesById(string id)
        {
            string remoteServiceRelativeUrl = @"/expense/digitaltaxinvoices/{id}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<DigitalTaxInvoiceGetSingle>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Get a single Digital Tax Invoice by ID
        /// </summary>
        /// <param name="id">DigitalTaxInvoice ID</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<DigitalTaxInvoiceGetSingle> GetExpenseDigitalTaxInvoicesByIdAsync(string id, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/digitaltaxinvoices/{id}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<DigitalTaxInvoiceGetSingle>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a DigitalTaxInvoice by ID
        /// </summary>
        /// <param name="id">ID of the Digital Tax Invoice to update</param>
        /// <param name="content">Status update to the Digital Tax Invoice </param>
        public Object UpdateExpenseDigitalTaxInvoicesById(string id, DigitalTaxInvoicePut content)
        {
            string remoteServiceRelativeUrl = @"/expense/digitaltaxinvoices/{id}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<Object>(
                "PUT",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Update a DigitalTaxInvoice by ID
        /// </summary>
        /// <param name="id">ID of the Digital Tax Invoice to update</param>
        /// <param name="content">Status update to the Digital Tax Invoice </param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<Object> UpdateExpenseDigitalTaxInvoicesByIdAsync(string id, DigitalTaxInvoicePut content, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/digitaltaxinvoices/{id}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<Object>(
                "PUT",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all expense entries
        /// </summary>
        /// <param name="attendeeTypeCode">Get information for expense entries that have attendees of the specified type.</param>
        /// <param name="batchID">Get information for expense entries that are part of a report payee that is in the specified Batch ID. Use the GET Payment Batch function to learn the Payment Type ID for the desired Payment Type.</param>
        /// <param name="expenseTypeCode">Get information for expense entries that have the specified Expense Type Code.</param>
        /// <param name="hasAttendees">Get information for expense entries that have attendees.</param>
        /// <param name="hasVAT">Get information for expense entries that have VAT details.</param>
        /// <param name="isBillable">Get information for expense entries where Is Billable is true.</param>
        /// <param name="paymentTypeID">Get information for expense entries with the specified Payment Type ID. Use the GET Expense Group Configurations function to learn the Payment Type ID for the desired Payment Type.</param>
        /// <param name="reportID">Get information for the specified Report ID. Use the GET Expense Report Digests function to learn the valid Report ID. Format: text, alpha-numeric GUID</param>
        /// <param name="limit">Number of records to return (default 25)</param>
        /// <param name="offset">Starting page offset</param>
        /// <param name="user">Optional. The login ID of the user. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public EntryCollection GetExpenseEntries(string attendeeTypeCode = null, string batchID = null, string expenseTypeCode = null, bool? hasAttendees = null, bool? hasVAT = null, bool? isBillable = null, string paymentTypeID = null, string reportID = null, Int32? limit = null, string offset = null, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/entries";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("attendeeTypeCode", attendeeTypeCode)
                ,new KeyValuePair<string,object>("batchID", batchID)
                ,new KeyValuePair<string,object>("expenseTypeCode", expenseTypeCode)
                ,new KeyValuePair<string,object>("hasAttendees", hasAttendees)
                ,new KeyValuePair<string,object>("hasVAT", hasVAT)
                ,new KeyValuePair<string,object>("isBillable", isBillable)
                ,new KeyValuePair<string,object>("paymentTypeID", paymentTypeID)
                ,new KeyValuePair<string,object>("reportID", reportID)
                ,new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)
                ,new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<EntryCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Gets all expense entries
        /// </summary>
        /// <param name="attendeeTypeCode">Get information for expense entries that have attendees of the specified type.</param>
        /// <param name="batchID">Get information for expense entries that are part of a report payee that is in the specified Batch ID. Use the GET Payment Batch function to learn the Payment Type ID for the desired Payment Type.</param>
        /// <param name="expenseTypeCode">Get information for expense entries that have the specified Expense Type Code.</param>
        /// <param name="hasAttendees">Get information for expense entries that have attendees.</param>
        /// <param name="hasVAT">Get information for expense entries that have VAT details.</param>
        /// <param name="isBillable">Get information for expense entries where Is Billable is true.</param>
        /// <param name="paymentTypeID">Get information for expense entries with the specified Payment Type ID. Use the GET Expense Group Configurations function to learn the Payment Type ID for the desired Payment Type.</param>
        /// <param name="reportID">Get information for the specified Report ID. Use the GET Expense Report Digests function to learn the valid Report ID. Format: text, alpha-numeric GUID</param>
        /// <param name="limit">Number of records to return (default 25)</param>
        /// <param name="offset">Starting page offset</param>
        /// <param name="user">Optional. The login ID of the user. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<EntryCollection> GetExpenseEntriesAsync(string attendeeTypeCode = null, string batchID = null, string expenseTypeCode = null, bool? hasAttendees = null, bool? hasVAT = null, bool? isBillable = null, string paymentTypeID = null, string reportID = null, Int32? limit = null, string offset = null, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/entries";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("attendeeTypeCode", attendeeTypeCode)
                ,new KeyValuePair<string,object>("batchID", batchID)
                ,new KeyValuePair<string,object>("expenseTypeCode", expenseTypeCode)
                ,new KeyValuePair<string,object>("hasAttendees", hasAttendees)
                ,new KeyValuePair<string,object>("hasVAT", hasVAT)
                ,new KeyValuePair<string,object>("isBillable", isBillable)
                ,new KeyValuePair<string,object>("paymentTypeID", paymentTypeID)
                ,new KeyValuePair<string,object>("reportID", reportID)
                ,new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)
                ,new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<EntryCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a single expense entry by ID
        /// </summary>
        /// <param name="id">Expense Entry ID</param>
        /// <param name="user">Optional. The login ID of the user. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public EntryGet GetExpenseEntriesById(string id, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/entries/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<EntryGet>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Get a single expense entry by ID
        /// </summary>
        /// <param name="id">Expense Entry ID</param>
        /// <param name="user">Optional. The login ID of the user. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<EntryGet> GetExpenseEntriesByIdAsync(string id, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/entries/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<EntryGet>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new expense entry
        /// </summary>
        /// <param name="content">Expense entry object to create</param>
        /// <param name="user">Optional. The login ID of the user. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public CreateResponse CreateExpenseEntries(EntryPost content, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/entries";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<CreateResponse>(
                "POST",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Create a new expense entry
        /// </summary>
        /// <param name="content">Expense entry object to create</param>
        /// <param name="user">Optional. The login ID of the user. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<CreateResponse> CreateExpenseEntriesAsync(EntryPost content, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/entries";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<CreateResponse>(
                "POST",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update an expense entry by ID
        /// </summary>
        /// <param name="id">Expense Entry ID</param>
        /// <param name="content">Partial or complete expense entry object to update</param>
        /// <param name="user">Optional. The login ID of the user. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public Object UpdateExpenseEntriesById(string id, EntryPut content, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/entries/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<Object>(
                "PUT",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Update an expense entry by ID
        /// </summary>
        /// <param name="id">Expense Entry ID</param>
        /// <param name="content">Partial or complete expense entry object to update</param>
        /// <param name="user">Optional. The login ID of the user. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<Object> UpdateExpenseEntriesByIdAsync(string id, EntryPut content, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/entries/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<Object>(
                "PUT",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete an expense entry by ID
        /// </summary>
        /// <param name="id">ID of the expense entry to delete</param>
        /// <param name="user">Optional. The login ID of the user. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public Object DeleteExpenseEntriesById(string id, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/entries/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<Object>(
                "DELETE",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Delete an expense entry by ID
        /// </summary>
        /// <param name="id">ID of the expense entry to delete</param>
        /// <param name="user">Optional. The login ID of the user. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<Object> DeleteExpenseEntriesByIdAsync(string id, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/entries/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<Object>(
                "DELETE",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all entry-attendee associations
        /// </summary>
        /// <param name="entryID">Get entry-attendee associations for the specified entry</param>
        /// <param name="limit">Number of records to return (default 25)</param>
        /// <param name="offset">Starting page offset</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public EntryAttendeeAssociationCollection GetExpenseEntryAttendeeAssociations(string entryID = null, Int32? limit = null, string offset = null, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/entryattendeeassociations";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("entryID", entryID)
                ,new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)
                ,new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<EntryAttendeeAssociationCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Gets all entry-attendee associations
        /// </summary>
        /// <param name="entryID">Get entry-attendee associations for the specified entry</param>
        /// <param name="limit">Number of records to return (default 25)</param>
        /// <param name="offset">Starting page offset</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<EntryAttendeeAssociationCollection> GetExpenseEntryAttendeeAssociationsAsync(string entryID = null, Int32? limit = null, string offset = null, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/entryattendeeassociations";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("entryID", entryID)
                ,new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)
                ,new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<EntryAttendeeAssociationCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a single entry-attendee association by ID
        /// </summary>
        /// <param name="id">Entry-attendee association ID</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public EntryAttendeeAssociationGet GetExpenseEntryAttendeeAssociationsById(string id, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/entryattendeeassociations/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<EntryAttendeeAssociationGet>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Get a single entry-attendee association by ID
        /// </summary>
        /// <param name="id">Entry-attendee association ID</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<EntryAttendeeAssociationGet> GetExpenseEntryAttendeeAssociationsByIdAsync(string id, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/entryattendeeassociations/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<EntryAttendeeAssociationGet>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new entry-attendee association.
        /// </summary>
        /// <param name="content">Entry-Attendee Association object to create</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public CreateResponse CreateExpenseEntryAttendeeAssociations(EntryAttendeeAssociationPost content, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/entryattendeeassociations";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<CreateResponse>(
                "POST",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Create a new entry-attendee association.
        /// </summary>
        /// <param name="content">Entry-Attendee Association object to create</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<CreateResponse> CreateExpenseEntryAttendeeAssociationsAsync(EntryAttendeeAssociationPost content, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/entryattendeeassociations";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<CreateResponse>(
                "POST",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update an entry-attendee association by ID
        /// </summary>
        /// <param name="id">No Documentation Found.</param>
        /// <param name="content">Partial or complete entry-attendee association object to update</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public Object UpdateExpenseEntryAttendeeAssociationsById(string id, EntryAttendeeAssociationPut content, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/entryattendeeassociations/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<Object>(
                "PUT",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Update an entry-attendee association by ID
        /// </summary>
        /// <param name="id">No Documentation Found.</param>
        /// <param name="content">Partial or complete entry-attendee association object to update</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<Object> UpdateExpenseEntryAttendeeAssociationsByIdAsync(string id, EntryAttendeeAssociationPut content, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/entryattendeeassociations/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<Object>(
                "PUT",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete an entry-attendee association by ID
        /// </summary>
        /// <param name="id">ID of the entry-attendee association to delete</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public Object DeleteExpenseEntryAttendeeAssociationsById(string id, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/entryattendeeassociations/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<Object>(
                "DELETE",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Delete an entry-attendee association by ID
        /// </summary>
        /// <param name="id">ID of the entry-attendee association to delete</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<Object> DeleteExpenseEntryAttendeeAssociationsByIdAsync(string id, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/entryattendeeassociations/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<Object>(
                "DELETE",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieve exchange rate.
        /// </summary>
        /// <param name="forDate">For date in YYYY-MM-DD format.  Example: 2012-12-20.  Dates older than 2000-01-01 will result in exchange rate of 1 and dates in the future will result in today's exchange rate.</param>
        /// <param name="fromCurrency">The <a target="_blank" href="http://en.wikipedia.org/wiki/ISO_4217">3-letter ISO 4217 currency code</a> for exchange from currency. Example: USD</param>
        /// <param name="toCurrency">The <a target="_blank" href="http://en.wikipedia.org/wiki/ISO_4217">3-letter ISO 4217 currency code</a> for exchange to currency. Example: CAD</param>
        public decimal GetExpenseExchangeRates(DateTime? forDate = null, string fromCurrency = null, string toCurrency = null)
        {
            string remoteServiceRelativeUrl = @"/expense/exchangerates/";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("forDate", forDate)
                ,new KeyValuePair<string,object>("fromCurrency", fromCurrency)
                ,new KeyValuePair<string,object>("toCurrency", toCurrency)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<decimal>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Retrieve exchange rate.
        /// </summary>
        /// <param name="forDate">For date in YYYY-MM-DD format.  Example: 2012-12-20.  Dates older than 2000-01-01 will result in exchange rate of 1 and dates in the future will result in today's exchange rate.</param>
        /// <param name="fromCurrency">The <a target="_blank" href="http://en.wikipedia.org/wiki/ISO_4217">3-letter ISO 4217 currency code</a> for exchange from currency. Example: USD</param>
        /// <param name="toCurrency">The <a target="_blank" href="http://en.wikipedia.org/wiki/ISO_4217">3-letter ISO 4217 currency code</a> for exchange to currency. Example: CAD</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<decimal> GetExpenseExchangeRatesAsync(DateTime? forDate = null, string fromCurrency = null, string toCurrency = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/exchangerates/";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("forDate", forDate)
                ,new KeyValuePair<string,object>("fromCurrency", fromCurrency)
                ,new KeyValuePair<string,object>("toCurrency", toCurrency)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<decimal>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get an expense group configuration.
        /// </summary>
        /// <param name="limit">Determines the number of records to return (default 10)</param>
        /// <param name="offset">Starting page offset</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public ExpenseGroupConfigurationCollection GetExpenseGroupConfigurations(Int32? limit = null, string offset = null, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/expensegroupconfigurations";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)
                ,new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<ExpenseGroupConfigurationCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Get an expense group configuration.
        /// </summary>
        /// <param name="limit">Determines the number of records to return (default 10)</param>
        /// <param name="offset">Starting page offset</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<ExpenseGroupConfigurationCollection> GetExpenseGroupConfigurationsAsync(Int32? limit = null, string offset = null, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/expensegroupconfigurations";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)
                ,new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<ExpenseGroupConfigurationCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets an expense group configuration by ID.
        /// </summary>
        /// <param name="id">Specifies the Expense Group Configuration ID</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public ExpenseGroupConfiguration GetExpenseGroupConfigurationsById(string id, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/expensegroupconfigurations/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<ExpenseGroupConfiguration>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Gets an expense group configuration by ID.
        /// </summary>
        /// <param name="id">Specifies the Expense Group Configuration ID</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<ExpenseGroupConfiguration> GetExpenseGroupConfigurationsByIdAsync(string id, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/expensegroupconfigurations/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<ExpenseGroupConfiguration>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all expense itemizations
        /// </summary>
        /// <param name="entryID">Get information for the specified Entry ID. Use the GET Expense Entries operation to learn the valid Entry ID.</param>
        /// <param name="expenseTypeCode">Get information for expense itemizations that have the specified Expense Type Code.</param>
        /// <param name="reportID">Get information for the specified Report ID. Use the GET Expense Report Digests function to learn the valid Report ID. Format: text, alpha-numeric GUID</param>
        /// <param name="limit">Number of records to return (default 25)</param>
        /// <param name="offset">Starting page offset</param>
        /// <param name="user">Optional The login ID of the user. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public ItemizationCollection GetExpenseItemizations(string entryID = null, string expenseTypeCode = null, string reportID = null, Int32? limit = null, string offset = null, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/itemizations";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("entryID", entryID)
                ,new KeyValuePair<string,object>("expenseTypeCode", expenseTypeCode)
                ,new KeyValuePair<string,object>("reportID", reportID)
                ,new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)
                ,new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<ItemizationCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Gets all expense itemizations
        /// </summary>
        /// <param name="entryID">Get information for the specified Entry ID. Use the GET Expense Entries operation to learn the valid Entry ID.</param>
        /// <param name="expenseTypeCode">Get information for expense itemizations that have the specified Expense Type Code.</param>
        /// <param name="reportID">Get information for the specified Report ID. Use the GET Expense Report Digests function to learn the valid Report ID. Format: text, alpha-numeric GUID</param>
        /// <param name="limit">Number of records to return (default 25)</param>
        /// <param name="offset">Starting page offset</param>
        /// <param name="user">Optional The login ID of the user. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<ItemizationCollection> GetExpenseItemizationsAsync(string entryID = null, string expenseTypeCode = null, string reportID = null, Int32? limit = null, string offset = null, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/itemizations";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("entryID", entryID)
                ,new KeyValuePair<string,object>("expenseTypeCode", expenseTypeCode)
                ,new KeyValuePair<string,object>("reportID", reportID)
                ,new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)
                ,new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<ItemizationCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a single expense itemization by ID
        /// </summary>
        /// <param name="id">Expense Itemization ID</param>
        /// <param name="user">Optional The login ID of the user. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public ItemizationGet GetExpenseItemizationsById(string id, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/itemizations/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<ItemizationGet>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Get a single expense itemization by ID
        /// </summary>
        /// <param name="id">Expense Itemization ID</param>
        /// <param name="user">Optional The login ID of the user. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<ItemizationGet> GetExpenseItemizationsByIdAsync(string id, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/itemizations/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<ItemizationGet>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new expense itemization
        /// </summary>
        /// <param name="content">Expense itemization object to create</param>
        /// <param name="user">Optional The login ID of the user. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public CreateResponse CreateExpenseItemizations(ItemizationPost content, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/itemizations";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<CreateResponse>(
                "POST",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Create a new expense itemization
        /// </summary>
        /// <param name="content">Expense itemization object to create</param>
        /// <param name="user">Optional The login ID of the user. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<CreateResponse> CreateExpenseItemizationsAsync(ItemizationPost content, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/itemizations";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<CreateResponse>(
                "POST",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get the latest hotel and air booking for a particular user.
        /// </summary>
        /// <param name="user">Optional. The login ID of the user. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public LatestBooking GetInsightsLatestBookings(string user = null)
        {
            string remoteServiceRelativeUrl = @"/insights/latestbookings/";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<LatestBooking>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Get the latest hotel and air booking for a particular user.
        /// </summary>
        /// <param name="user">Optional. The login ID of the user. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<LatestBooking> GetInsightsLatestBookingsAsync(string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/insights/latestbookings/";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<LatestBooking>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all listitems
        /// </summary>
        /// <param name="level10Code">The item code for the tenth level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters</param>
        /// <param name="level1Code">The item code for the first level of the list. All lists have at least a Level1Code. Text maximum 32 characters</param>
        /// <param name="level2Code">The item code for the second level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters</param>
        /// <param name="level3Code">The item code for the third level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters</param>
        /// <param name="level4Code">The item code for the fourth level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters</param>
        /// <param name="level5Code">The item code for the fifth level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters</param>
        /// <param name="level6Code">The item code for the sixth level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters</param>
        /// <param name="level7Code">The item code for the seventh level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters</param>
        /// <param name="level8Code">The item code for the eighth level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters</param>
        /// <param name="level9Code">The item code for the ninth level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters</param>
        /// <param name="listId">The unique identifier for the list this item is a member.</param>
        /// <param name="name">The name of the listItem. Text Max length: 64.</param>
        /// <param name="parentId">The unique identifier of this item's parent. Is empty when there is no parent.</param>
        /// <param name="limit">The number of records to return. The default is 25 and the maximum is 100.</param>
        /// <param name="offset">The start of the page offset. The default is from the beginning.</param>
        public ListItemGetCollection GetCommonListItems(string level10Code = null, string level1Code = null, string level2Code = null, string level3Code = null, string level4Code = null, string level5Code = null, string level6Code = null, string level7Code = null, string level8Code = null, string level9Code = null, string listId = null, string name = null, string parentId = null, Int32? limit = null, string offset = null)
        {
            string remoteServiceRelativeUrl = @"/common/listitems";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("level10Code", level10Code)
                ,new KeyValuePair<string,object>("level1Code", level1Code)
                ,new KeyValuePair<string,object>("level2Code", level2Code)
                ,new KeyValuePair<string,object>("level3Code", level3Code)
                ,new KeyValuePair<string,object>("level4Code", level4Code)
                ,new KeyValuePair<string,object>("level5Code", level5Code)
                ,new KeyValuePair<string,object>("level6Code", level6Code)
                ,new KeyValuePair<string,object>("level7Code", level7Code)
                ,new KeyValuePair<string,object>("level8Code", level8Code)
                ,new KeyValuePair<string,object>("level9Code", level9Code)
                ,new KeyValuePair<string,object>("listId", listId)
                ,new KeyValuePair<string,object>("name", name)
                ,new KeyValuePair<string,object>("parentId", parentId)
                ,new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<ListItemGetCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Gets all listitems
        /// </summary>
        /// <param name="level10Code">The item code for the tenth level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters</param>
        /// <param name="level1Code">The item code for the first level of the list. All lists have at least a Level1Code. Text maximum 32 characters</param>
        /// <param name="level2Code">The item code for the second level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters</param>
        /// <param name="level3Code">The item code for the third level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters</param>
        /// <param name="level4Code">The item code for the fourth level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters</param>
        /// <param name="level5Code">The item code for the fifth level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters</param>
        /// <param name="level6Code">The item code for the sixth level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters</param>
        /// <param name="level7Code">The item code for the seventh level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters</param>
        /// <param name="level8Code">The item code for the eighth level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters</param>
        /// <param name="level9Code">The item code for the ninth level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters</param>
        /// <param name="listId">The unique identifier for the list this item is a member.</param>
        /// <param name="name">The name of the listItem. Text Max length: 64.</param>
        /// <param name="parentId">The unique identifier of this item's parent. Is empty when there is no parent.</param>
        /// <param name="limit">The number of records to return. The default is 25 and the maximum is 100.</param>
        /// <param name="offset">The start of the page offset. The default is from the beginning.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<ListItemGetCollection> GetCommonListItemsAsync(string level10Code = null, string level1Code = null, string level2Code = null, string level3Code = null, string level4Code = null, string level5Code = null, string level6Code = null, string level7Code = null, string level8Code = null, string level9Code = null, string listId = null, string name = null, string parentId = null, Int32? limit = null, string offset = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/common/listitems";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("level10Code", level10Code)
                ,new KeyValuePair<string,object>("level1Code", level1Code)
                ,new KeyValuePair<string,object>("level2Code", level2Code)
                ,new KeyValuePair<string,object>("level3Code", level3Code)
                ,new KeyValuePair<string,object>("level4Code", level4Code)
                ,new KeyValuePair<string,object>("level5Code", level5Code)
                ,new KeyValuePair<string,object>("level6Code", level6Code)
                ,new KeyValuePair<string,object>("level7Code", level7Code)
                ,new KeyValuePair<string,object>("level8Code", level8Code)
                ,new KeyValuePair<string,object>("level9Code", level9Code)
                ,new KeyValuePair<string,object>("listId", listId)
                ,new KeyValuePair<string,object>("name", name)
                ,new KeyValuePair<string,object>("parentId", parentId)
                ,new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<ListItemGetCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a single listitem by ID
        /// </summary>
        /// <param name="id">The unique identifier for the listItem.</param>
        /// <param name="listId">The unique identifier for the list this item is a member.</param>
        public ListItemGet GetCommonListItemsById(string id, string listId = null)
        {
            string remoteServiceRelativeUrl = @"/common/listitems/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("listId", listId)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<ListItemGet>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Get a single listitem by ID
        /// </summary>
        /// <param name="id">The unique identifier for the listItem.</param>
        /// <param name="listId">The unique identifier for the list this item is a member.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<ListItemGet> GetCommonListItemsByIdAsync(string id, string listId = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/common/listitems/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("listId", listId)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<ListItemGet>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new listitem
        /// </summary>
        /// <param name="content">listitem object to create</param>
        public CreateResponse CreateCommonListItems(ListItemPost content)
        {
            string remoteServiceRelativeUrl = @"/common/listitems";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<CreateResponse>(
                "POST",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Create a new listitem
        /// </summary>
        /// <param name="content">listitem object to create</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<CreateResponse> CreateCommonListItemsAsync(ListItemPost content, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/common/listitems";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<CreateResponse>(
                "POST",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update listitem
        /// </summary>
        /// <param name="id">The unique identifier for the listItem.</param>
        /// <param name="content">The listitem object to update</param>
        public Object UpdateCommonListItemsById(string id, ListItemPut content)
        {
            string remoteServiceRelativeUrl = @"/common/listitems/{id}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<Object>(
                "PUT",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Update listitem
        /// </summary>
        /// <param name="id">The unique identifier for the listItem.</param>
        /// <param name="content">The listitem object to update</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<Object> UpdateCommonListItemsByIdAsync(string id, ListItemPut content, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/common/listitems/{id}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<Object>(
                "PUT",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete listitem by ID
        /// </summary>
        /// <param name="id">The unique identifier of the listitem to delete</param>
        /// <param name="listId">The unique identifier of the list associated with a listitem to be deleted</param>
        public Object DeleteCommonListItemsByIdByListId(string id, string listId)
        {
            string remoteServiceRelativeUrl = @"/common/listitems/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("listId", listId)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<Object>(
                "DELETE",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Delete listitem by ID
        /// </summary>
        /// <param name="id">The unique identifier of the listitem to delete</param>
        /// <param name="listId">The unique identifier of the list associated with a listitem to be deleted</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<Object> DeleteCommonListItemsByIdByListIdAsync(string id, string listId, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/common/listitems/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("listId", listId)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<Object>(
                "DELETE",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all lists
        /// </summary>
        /// <param name="limit">The number of records to return. The default is 25 and the maximum is 100.</param>
        /// <param name="offset">The start of the page offset. The default is from the beginning.</param>
        public ListGetCollection GetCommonLists(Int32? limit = null, string offset = null)
        {
            string remoteServiceRelativeUrl = @"/common/lists";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<ListGetCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Gets all lists
        /// </summary>
        /// <param name="limit">The number of records to return. The default is 25 and the maximum is 100.</param>
        /// <param name="offset">The start of the page offset. The default is from the beginning.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<ListGetCollection> GetCommonListsAsync(Int32? limit = null, string offset = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/common/lists";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<ListGetCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a single list by ID
        /// </summary>
        /// <param name="id">The unique identifier for the list.</param>
        public ListGet GetCommonListsById(string id)
        {
            string remoteServiceRelativeUrl = @"/common/lists/{id}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<ListGet>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Get a single list by ID
        /// </summary>
        /// <param name="id">The unique identifier for the list.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<ListGet> GetCommonListsByIdAsync(string id, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/common/lists/{id}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<ListGet>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new list
        /// </summary>
        /// <param name="content">list object to create</param>
        public CreateResponse CreateCommonLists(ListPost content)
        {
            string remoteServiceRelativeUrl = @"/common/lists";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<CreateResponse>(
                "POST",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Create a new list
        /// </summary>
        /// <param name="content">list object to create</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<CreateResponse> CreateCommonListsAsync(ListPost content, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/common/lists";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<CreateResponse>(
                "POST",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update list
        /// </summary>
        /// <param name="id">The unique identifier for the list.</param>
        /// <param name="content">The list object to update</param>
        public Object UpdateCommonListsById(string id, ListPut content)
        {
            string remoteServiceRelativeUrl = @"/common/lists/{id}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<Object>(
                "PUT",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Update list
        /// </summary>
        /// <param name="id">The unique identifier for the list.</param>
        /// <param name="content">The list object to update</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<Object> UpdateCommonListsByIdAsync(string id, ListPut content, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/common/lists/{id}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<Object>(
                "PUT",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get all locations.
        /// </summary>
        /// <param name="administrativeRegion">Administrative region.</param>
        /// <param name="city">The city name.</param>
        /// <param name="country">2-letter ISO 3166-1 country code.</param>
        /// <param name="countrySubdivision">ISO 3166-2:2007 country subdivision.</param>
        /// <param name="name">A common name associated with this location. The name can be a location description such as a neighborhood (SoHo), a landmark (Statue of Liberty), or a city name (New York).</param>
        /// <param name="limit">Number of records to return. The default is 25.</param>
        /// <param name="offset">Starting page offset</param>
        public LocationCollection GetCommonLocations(string administrativeRegion = null, string city = null, string country = null, string countrySubdivision = null, string name = null, Int32? limit = null, string offset = null)
        {
            string remoteServiceRelativeUrl = @"/common/locations";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("administrativeRegion", administrativeRegion)
                ,new KeyValuePair<string,object>("city", city)
                ,new KeyValuePair<string,object>("country", country)
                ,new KeyValuePair<string,object>("countrySubdivision", countrySubdivision)
                ,new KeyValuePair<string,object>("name", name)
                ,new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<LocationCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Get all locations.
        /// </summary>
        /// <param name="administrativeRegion">Administrative region.</param>
        /// <param name="city">The city name.</param>
        /// <param name="country">2-letter ISO 3166-1 country code.</param>
        /// <param name="countrySubdivision">ISO 3166-2:2007 country subdivision.</param>
        /// <param name="name">A common name associated with this location. The name can be a location description such as a neighborhood (SoHo), a landmark (Statue of Liberty), or a city name (New York).</param>
        /// <param name="limit">Number of records to return. The default is 25.</param>
        /// <param name="offset">Starting page offset</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<LocationCollection> GetCommonLocationsAsync(string administrativeRegion = null, string city = null, string country = null, string countrySubdivision = null, string name = null, Int32? limit = null, string offset = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/common/locations";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("administrativeRegion", administrativeRegion)
                ,new KeyValuePair<string,object>("city", city)
                ,new KeyValuePair<string,object>("country", country)
                ,new KeyValuePair<string,object>("countrySubdivision", countrySubdivision)
                ,new KeyValuePair<string,object>("name", name)
                ,new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<LocationCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a location by ID.
        /// </summary>
        /// <param name="id">Location ID</param>
        public Location GetCommonLocationsById(string id)
        {
            string remoteServiceRelativeUrl = @"/common/locations/{id}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<Location>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Get a location by ID.
        /// </summary>
        /// <param name="id">Location ID</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<Location> GetCommonLocationsByIdAsync(string id, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/common/locations/{id}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<Location>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a collection of opportunities for a specified trip or for all trips that fall within a date range
        /// </summary>
        /// <param name="fromUtc">The From date in UTC for the date range</param>
        /// <param name="opportunityType">Comma seperated list of opportunities (Hotel, Car, Air, Rail, Taxi and Service) to get. Do not specify any values to get all opportunities</param>
        /// <param name="toUtc">The To date in UTC for the date range</param>
        /// <param name="tripId">The trip id</param>
        public Opportunities GetInsightsOpportunities(DateTime? fromUtc = null, string opportunityType = null, DateTime? toUtc = null, string tripId = null)
        {
            string remoteServiceRelativeUrl = @"/insights/opportunities";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("fromUtc", fromUtc)
                ,new KeyValuePair<string,object>("opportunityType", opportunityType)
                ,new KeyValuePair<string,object>("toUtc", toUtc)
                ,new KeyValuePair<string,object>("tripId", tripId)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<Opportunities>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Gets a collection of opportunities for a specified trip or for all trips that fall within a date range
        /// </summary>
        /// <param name="fromUtc">The From date in UTC for the date range</param>
        /// <param name="opportunityType">Comma seperated list of opportunities (Hotel, Car, Air, Rail, Taxi and Service) to get. Do not specify any values to get all opportunities</param>
        /// <param name="toUtc">The To date in UTC for the date range</param>
        /// <param name="tripId">The trip id</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<Opportunities> GetInsightsOpportunitiesAsync(DateTime? fromUtc = null, string opportunityType = null, DateTime? toUtc = null, string tripId = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/insights/opportunities";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("fromUtc", fromUtc)
                ,new KeyValuePair<string,object>("opportunityType", opportunityType)
                ,new KeyValuePair<string,object>("toUtc", toUtc)
                ,new KeyValuePair<string,object>("tripId", tripId)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<Opportunities>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates purchase order line item with receipt information.
        /// </summary>
        /// <param name="purchaseOrderReceipt">Purchase Order Receipt information.</param>
        public PurchaseOrderResult UpdateInvoicePurchaseOrderReceipts(PurchaseOrderReceipt purchaseOrderReceipt)
        {
            string remoteServiceRelativeUrl = @"/invoice/purchaseorderreceipts";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<PurchaseOrderResult>(
                "PUT",
                requestUrl,
                purchaseOrderReceipt,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Updates purchase order line item with receipt information.
        /// </summary>
        /// <param name="purchaseOrderReceipt">Purchase Order Receipt information.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<PurchaseOrderResult> UpdateInvoicePurchaseOrderReceiptsAsync(PurchaseOrderReceipt purchaseOrderReceipt, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/invoice/purchaseorderreceipts";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<PurchaseOrderResult>(
                "PUT",
                requestUrl,
                purchaseOrderReceipt,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new purchase order.
        /// </summary>
        /// <param name="purchaseOrder">The purchase order details.</param>
        public PurchaseOrderResult CreateInvoicePurchaseOrders(PurchaseOrder purchaseOrder)
        {
            string remoteServiceRelativeUrl = @"/invoice/purchaseorders";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<PurchaseOrderResult>(
                "POST",
                requestUrl,
                purchaseOrder,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Create a new purchase order.
        /// </summary>
        /// <param name="purchaseOrder">The purchase order details.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<PurchaseOrderResult> CreateInvoicePurchaseOrdersAsync(PurchaseOrder purchaseOrder, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/invoice/purchaseorders";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<PurchaseOrderResult>(
                "POST",
                requestUrl,
                purchaseOrder,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates an existing purchase order.
        /// </summary>
        /// <param name="purchaseOrder">The purchase order details.</param>
        public PurchaseOrderResult UpdateInvoicePurchaseOrders(PurchaseOrder purchaseOrder)
        {
            string remoteServiceRelativeUrl = @"/invoice/purchaseorders";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<PurchaseOrderResult>(
                "PUT",
                requestUrl,
                purchaseOrder,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Updates an existing purchase order.
        /// </summary>
        /// <param name="purchaseOrder">The purchase order details.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<PurchaseOrderResult> UpdateInvoicePurchaseOrdersAsync(PurchaseOrder purchaseOrder, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/invoice/purchaseorders";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<PurchaseOrderResult>(
                "PUT",
                requestUrl,
                purchaseOrder,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves an existing purchase order.
        /// </summary>
        /// <param name="id">The identifier for the purchase order.</param>
        public PurchaseOrder GetInvoicePurchaseOrdersById(string id)
        {
            string remoteServiceRelativeUrl = @"/invoice/purchaseorders/{id}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<PurchaseOrder>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Retrieves an existing purchase order.
        /// </summary>
        /// <param name="id">The identifier for the purchase order.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<PurchaseOrder> GetInvoicePurchaseOrdersByIdAsync(string id, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/invoice/purchaseorders/{id}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<PurchaseOrder>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get all quick expenses
        /// </summary>
        /// <param name="limit">The number of records to return (default 25).</param>
        /// <param name="offset">The start of the page offset.</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public QuickExpenseCollection GetQuickExpenses(Int32? limit = null, string offset = null, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/quickexpenses";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)
                ,new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<QuickExpenseCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Get all quick expenses
        /// </summary>
        /// <param name="limit">The number of records to return (default 25).</param>
        /// <param name="offset">The start of the page offset.</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<QuickExpenseCollection> GetQuickExpensesAsync(Int32? limit = null, string offset = null, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/quickexpenses";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)
                ,new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<QuickExpenseCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a single quick expense by ID
        /// </summary>
        /// <param name="id">The ID of the quick expense.</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public QuickExpenseGet GetQuickExpensesById(string id, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/quickexpenses/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<QuickExpenseGet>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Get a single quick expense by ID
        /// </summary>
        /// <param name="id">The ID of the quick expense.</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<QuickExpenseGet> GetQuickExpensesByIdAsync(string id, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/quickexpenses/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<QuickExpenseGet>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new quick expense
        /// </summary>
        /// <param name="content">The quick expense object to be created.</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public CreateResponse CreateQuickExpenses(QuickExpensePost content, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/quickexpenses";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<CreateResponse>(
                "POST",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Create a new quick expense
        /// </summary>
        /// <param name="content">The quick expense object to be created.</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<CreateResponse> CreateQuickExpensesAsync(QuickExpensePost content, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/quickexpenses";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<CreateResponse>(
                "POST",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a quick expense by ID
        /// </summary>
        /// <param name="id">The ID of the quick expense.</param>
        /// <param name="content">Partial or complete QuickExpense object to update</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public Object UpdateQuickExpensesById(string id, QuickExpensePut content, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/quickexpenses/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<Object>(
                "PUT",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Update a quick expense by ID
        /// </summary>
        /// <param name="id">The ID of the quick expense.</param>
        /// <param name="content">Partial or complete QuickExpense object to update</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<Object> UpdateQuickExpensesByIdAsync(string id, QuickExpensePut content, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/quickexpenses/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<Object>(
                "PUT",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete a quick expense by ID
        /// </summary>
        /// <param name="id">The ID of the quick expense to be deleted.</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public Object DeleteQuickExpensesById(string id, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/quickexpenses/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<Object>(
                "DELETE",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Delete a quick expense by ID
        /// </summary>
        /// <param name="id">The ID of the quick expense to be deleted.</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<Object> DeleteQuickExpensesByIdAsync(string id, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/quickexpenses/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<Object>(
                "DELETE",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get all receipt IDs by user
        /// </summary>
        /// <param name="limit">Number of records to return (default 25)</param>
        /// <param name="offset">Starting page offset</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public ReceiptImageCollection GetExpenseReceiptImages(Int32? limit = null, string offset = null, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/receiptimages";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)
                ,new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<ReceiptImageCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Get all receipt IDs by user
        /// </summary>
        /// <param name="limit">Number of records to return (default 25)</param>
        /// <param name="offset">Starting page offset</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<ReceiptImageCollection> GetExpenseReceiptImagesAsync(Int32? limit = null, string offset = null, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/receiptimages";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)
                ,new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<ReceiptImageCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a receipt image URL
        /// </summary>
        /// <param name="id">ReceiptImage ID</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public ReceiptImage GetExpenseReceiptImagesById(string id, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/receiptimages/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<ReceiptImage>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Get a receipt image URL
        /// </summary>
        /// <param name="id">ReceiptImage ID</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<ReceiptImage> GetExpenseReceiptImagesByIdAsync(string id, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/receiptimages/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<ReceiptImage>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new receipt image
        /// </summary>
        /// <param name="image">Image data file</param>
        /// <param name="imageFileType">File type (e.g. PDF, JPEG, PNG).</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public ReceiptImage CreateExpenseReceiptImages(byte[] image, ReceiptFileType imageFileType, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/receiptimages";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            string contentType = new string[] { "application/pdf", "image/jpeg", "image/png" }[(int)imageFileType];
            return this.Util.SendHttpRequest<ReceiptImage>(
                "POST",
                requestUrl,
                image,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                contentType);
        }

        /// <summary>
        /// Create a new receipt image
        /// </summary>
        /// <param name="image">Image data file</param>
        /// <param name="imageFileType">File type (e.g. PDF, JPEG, PNG).</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<ReceiptImage> CreateExpenseReceiptImagesAsync(byte[] image, ReceiptFileType imageFileType, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/receiptimages";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            string contentType = new string[] { "application/pdf", "image/jpeg", "image/png" }[(int)imageFileType];
            return await this.Util.SendHttpRequestAsync<ReceiptImage>(
                "POST",
                requestUrl,
                image,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken,
                contentType).ConfigureAwait(false);
        }

        /// <summary>
        /// Appends a receipt image to an existing receipt image
        /// </summary>
        /// <param name="id">ID of the receipt image to update</param>
        /// <param name="image">Image data file</param>
        /// <param name="imageFileType">File type (e.g. PDF, JPEG, PNG).</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public Object UpdateExpenseReceiptImagesById(string id, byte[] image, ReceiptFileType imageFileType, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/receiptimages/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            string contentType = new string[] { "application/pdf", "image/jpeg", "image/png" }[(int)imageFileType];
            return this.Util.SendHttpRequest<Object>(
                "PUT",
                requestUrl,
                image,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                contentType);
        }

        /// <summary>
        /// Appends a receipt image to an existing receipt image
        /// </summary>
        /// <param name="id">ID of the receipt image to update</param>
        /// <param name="image">Image data file</param>
        /// <param name="imageFileType">File type (e.g. PDF, JPEG, PNG).</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<Object> UpdateExpenseReceiptImagesByIdAsync(string id, byte[] image, ReceiptFileType imageFileType, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/receiptimages/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            string contentType = new string[] { "application/pdf", "image/jpeg", "image/png" }[(int)imageFileType];
            return await this.Util.SendHttpRequestAsync<Object>(
                "PUT",
                requestUrl,
                image,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken,
                contentType).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete a receipt image by ID
        /// </summary>
        /// <param name="id">ID of the receipt image to delete</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public Object DeleteExpenseReceiptImagesById(string id, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/receiptimages/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<Object>(
                "DELETE",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Delete a receipt image by ID
        /// </summary>
        /// <param name="id">ID of the receipt image to delete</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<Object> DeleteExpenseReceiptImagesByIdAsync(string id, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/receiptimages/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<Object>(
                "DELETE",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all report digests
        /// </summary>
        /// <param name="approvalStatusCode">The status code for the Approval Status. The values can include Concur Expense standard codes or custom codes. The Concur Expense standard code values are: A_AAFH - Report submission triggered an anomaly and fraud check; A_ACCO - Report is pending reviews; A_APPR - Report has been approved; A_EXTV - Report is pending external validation; A_FILE - Report has been submitted; A_NOTF - Report has not been submitted; A_PBDG - Report approval is pending Budget approval; A_PECO - Report approval is pending Cost object approval; A_PEND - Report is pending manager approval; A_PVAL - Report is pending prepayment validation; A_RESU - Report needs to be resubmitted; A_RHLD - Report submission is pending receipt images; A_TEXP - Report expired in approval queue. For custom codes, contact Concur Developer Support.</param>
        /// <param name="approverLoginID">The login ID for the report approver that is the current approver assigned to the report.</param>
        /// <param name="attendeeTypeCode">The report contains expense entries that have attendees of the specified type.</param>
        /// <param name="batchID">The unique identifier for a payment batch where there is at least one report payee within the report. Use the BatchID from Response of GET Payment Batch List.</param>
        /// <param name="costObject">The list item code for an allocation field for at least allocation in the report.</param>
        /// <param name="countryCode">The report country. Maximum 2 characters. Format: The ISO 3166-1 alpha-2 country code. Example: United States is US.</param>
        /// <param name="createDateAfter">The report create date is after this date.Format: YYYY-MM-DD</param>
        /// <param name="createDateBefore">The report create date is before this date.Format: YYYY-MM-DD</param>
        /// <param name="currencyCode">The 3-letter ISO 4217 currency code for the report currency. Example: USD.</param>
        /// <param name="entryTransactionDateAfter">The entry transaction date for at least one expense entry in the report is after this date.Format: YYYY-MM-DD</param>
        /// <param name="entryTransactionDateBefore">The entry transaction date for at least one expense entry in the report is before this date.Format: YYYY-MM-DD</param>
        /// <param name="expenseGroupConfigID">The unique identifier for the expense group configuration associated to the report's expense group. Use the ID from the Response of the Expense Group Configurations V3.</param>
        /// <param name="expenseTypeCode">The expense type code that is the expense type for at least one expense entry in the report. Use ExpenseTypeCode from Response of GET Expense Group Configurations V3.</param>
        /// <param name="hasAttendees">Determines if the report has at least one expense entry with an attendee. FORMAT: true or false.</param>
        /// <param name="hasBillableExpenses">The IsBillable flag for at least one expense entry in the report. FORMAT: true or false.</param>
        /// <param name="hasImages">Determines if the report has at least one expense entry with an entry image or if there is a report image for this report. FORMAT: true or false.</param>
        /// <param name="hasVAT">Determines if the report has at least one expense entry with VAT details. FORMAT: true or false.</param>
        /// <param name="isTestUser">The report owner is a test user using the report for testing purposes in a non-production envirnment. FORMAT: true or false.</param>
        /// <param name="modifiedDateAfter">The report modified date is after this date.Format: YYYY-MM-DD</param>
        /// <param name="modifiedDateBefore">The report modified date is before this date.Format: YYYY-MM-DD</param>
        /// <param name="paidDateAfter">The report paid date is after this date.Format: YYYY-MM-DD</param>
        /// <param name="paidDateBefore">The report paid date is before this date.Format: YYYY-MM-DD</param>
        /// <param name="paymentStatusCode">The payment status code for the report. The values can include Concur Expense standard codes or custom codes. The Concur Expense standard code values are: P_HOLD - Report payment is on hold; P_NOTP - Report has not been paid; P_PAID - Report has been paid; P_PAYC - Payment is confirmed. Some or all of the report expenses have been paid; P_PROC - Report is in process to be paid. For custom codes, contact Concur Developer Support.</param>
        /// <param name="paymentType">The unique identifier for the payment type that is the payment type for at least one expense entry in the report. Use PaymentTypeID from Response of GET Expense Group Configurations V3 to obtain valid payment types.</param>
        /// <param name="processingPaymentDateAfter">The report processing payment date is after this date. Format: YYYY-MM-DD</param>
        /// <param name="processingPaymentDateBefore">The report processing payment date is before this date.Format: YYYY-MM-DD</param>
        /// <param name="reimbursementMethod">The method the report owner will be reimbursed. VALUES: ADPPAYR - ADP Payroll; APCHECK - AP (Company Check); CNQRPAY - Expense Pay; PMTSERV - Other Payment Service. NOTE: PAY_PAL is NOT supported.</param>
        /// <param name="submitDateAfter">The report submit date is after this date.Format: YYYY-MM-DD</param>
        /// <param name="submitDateBefore">The report submit date is before this date.Format: YYYY-MM-DD</param>
        /// <param name="userDefinedDateAfter">The report user defined date is after this date.Format: YYYY-MM-DD</param>
        /// <param name="userDefinedDateBefore">The report user defined date is before this date.Format: YYYY-MM-DD</param>
        /// <param name="vendorName">The Vendor Description that is the vendor for at least one expense entry in the report.</param>
        /// <param name="limit">Number of records to return (default 100)</param>
        /// <param name="offset">Starting page offset</param>
        /// <param name="user">Optional. The login ID of the report owner(s) to use when searching for report digests. If the value is set to LoginID, report digests for the report owner with this login ID value are returned. If the value is set to ALL, report digests for all report owners are returned. If this parameter is not specified, report digests for the OAuth Consumer are returned. The access token owner (OAuth Consumer) must have the Web Services Admin role to use this parameter.</param>
        public ReportDigestCollection GetExpenseReportDigests(string approvalStatusCode = null, string approverLoginID = null, string attendeeTypeCode = null, string batchID = null, string costObject = null, string countryCode = null, DateTime? createDateAfter = null, DateTime? createDateBefore = null, string currencyCode = null, DateTime? entryTransactionDateAfter = null, DateTime? entryTransactionDateBefore = null, string expenseGroupConfigID = null, string expenseTypeCode = null, bool? hasAttendees = null, bool? hasBillableExpenses = null, bool? hasImages = null, bool? hasVAT = null, bool? isTestUser = null, DateTime? modifiedDateAfter = null, DateTime? modifiedDateBefore = null, DateTime? paidDateAfter = null, DateTime? paidDateBefore = null, string paymentStatusCode = null, string paymentType = null, DateTime? processingPaymentDateAfter = null, DateTime? processingPaymentDateBefore = null, string reimbursementMethod = null, DateTime? submitDateAfter = null, DateTime? submitDateBefore = null, DateTime? userDefinedDateAfter = null, DateTime? userDefinedDateBefore = null, string vendorName = null, Int32? limit = null, string offset = null, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/reportdigests";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("approvalStatusCode", approvalStatusCode)
                ,new KeyValuePair<string,object>("approverLoginID", approverLoginID)
                ,new KeyValuePair<string,object>("attendeeTypeCode", attendeeTypeCode)
                ,new KeyValuePair<string,object>("batchID", batchID)
                ,new KeyValuePair<string,object>("costObject", costObject)
                ,new KeyValuePair<string,object>("countryCode", countryCode)
                ,new KeyValuePair<string,object>("createDateAfter", createDateAfter)
                ,new KeyValuePair<string,object>("createDateBefore", createDateBefore)
                ,new KeyValuePair<string,object>("currencyCode", currencyCode)
                ,new KeyValuePair<string,object>("entryTransactionDateAfter", entryTransactionDateAfter)
                ,new KeyValuePair<string,object>("entryTransactionDateBefore", entryTransactionDateBefore)
                ,new KeyValuePair<string,object>("expenseGroupConfigID", expenseGroupConfigID)
                ,new KeyValuePair<string,object>("expenseTypeCode", expenseTypeCode)
                ,new KeyValuePair<string,object>("hasAttendees", hasAttendees)
                ,new KeyValuePair<string,object>("hasBillableExpenses", hasBillableExpenses)
                ,new KeyValuePair<string,object>("hasImages", hasImages)
                ,new KeyValuePair<string,object>("hasVAT", hasVAT)
                ,new KeyValuePair<string,object>("isTestUser", isTestUser)
                ,new KeyValuePair<string,object>("modifiedDateAfter", modifiedDateAfter)
                ,new KeyValuePair<string,object>("modifiedDateBefore", modifiedDateBefore)
                ,new KeyValuePair<string,object>("paidDateAfter", paidDateAfter)
                ,new KeyValuePair<string,object>("paidDateBefore", paidDateBefore)
                ,new KeyValuePair<string,object>("paymentStatusCode", paymentStatusCode)
                ,new KeyValuePair<string,object>("paymentType", paymentType)
                ,new KeyValuePair<string,object>("processingPaymentDateAfter", processingPaymentDateAfter)
                ,new KeyValuePair<string,object>("processingPaymentDateBefore", processingPaymentDateBefore)
                ,new KeyValuePair<string,object>("reimbursementMethod", reimbursementMethod)
                ,new KeyValuePair<string,object>("submitDateAfter", submitDateAfter)
                ,new KeyValuePair<string,object>("submitDateBefore", submitDateBefore)
                ,new KeyValuePair<string,object>("userDefinedDateAfter", userDefinedDateAfter)
                ,new KeyValuePair<string,object>("userDefinedDateBefore", userDefinedDateBefore)
                ,new KeyValuePair<string,object>("vendorName", vendorName)
                ,new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)
                ,new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<ReportDigestCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Gets all report digests
        /// </summary>
        /// <param name="approvalStatusCode">The status code for the Approval Status. The values can include Concur Expense standard codes or custom codes. The Concur Expense standard code values are: A_AAFH - Report submission triggered an anomaly and fraud check; A_ACCO - Report is pending reviews; A_APPR - Report has been approved; A_EXTV - Report is pending external validation; A_FILE - Report has been submitted; A_NOTF - Report has not been submitted; A_PBDG - Report approval is pending Budget approval; A_PECO - Report approval is pending Cost object approval; A_PEND - Report is pending manager approval; A_PVAL - Report is pending prepayment validation; A_RESU - Report needs to be resubmitted; A_RHLD - Report submission is pending receipt images; A_TEXP - Report expired in approval queue. For custom codes, contact Concur Developer Support.</param>
        /// <param name="approverLoginID">The login ID for the report approver that is the current approver assigned to the report.</param>
        /// <param name="attendeeTypeCode">The report contains expense entries that have attendees of the specified type.</param>
        /// <param name="batchID">The unique identifier for a payment batch where there is at least one report payee within the report. Use the BatchID from Response of GET Payment Batch List.</param>
        /// <param name="costObject">The list item code for an allocation field for at least allocation in the report.</param>
        /// <param name="countryCode">The report country. Maximum 2 characters. Format: The ISO 3166-1 alpha-2 country code. Example: United States is US.</param>
        /// <param name="createDateAfter">The report create date is after this date.Format: YYYY-MM-DD</param>
        /// <param name="createDateBefore">The report create date is before this date.Format: YYYY-MM-DD</param>
        /// <param name="currencyCode">The 3-letter ISO 4217 currency code for the report currency. Example: USD.</param>
        /// <param name="entryTransactionDateAfter">The entry transaction date for at least one expense entry in the report is after this date.Format: YYYY-MM-DD</param>
        /// <param name="entryTransactionDateBefore">The entry transaction date for at least one expense entry in the report is before this date.Format: YYYY-MM-DD</param>
        /// <param name="expenseGroupConfigID">The unique identifier for the expense group configuration associated to the report's expense group. Use the ID from the Response of the Expense Group Configurations V3.</param>
        /// <param name="expenseTypeCode">The expense type code that is the expense type for at least one expense entry in the report. Use ExpenseTypeCode from Response of GET Expense Group Configurations V3.</param>
        /// <param name="hasAttendees">Determines if the report has at least one expense entry with an attendee. FORMAT: true or false.</param>
        /// <param name="hasBillableExpenses">The IsBillable flag for at least one expense entry in the report. FORMAT: true or false.</param>
        /// <param name="hasImages">Determines if the report has at least one expense entry with an entry image or if there is a report image for this report. FORMAT: true or false.</param>
        /// <param name="hasVAT">Determines if the report has at least one expense entry with VAT details. FORMAT: true or false.</param>
        /// <param name="isTestUser">The report owner is a test user using the report for testing purposes in a non-production envirnment. FORMAT: true or false.</param>
        /// <param name="modifiedDateAfter">The report modified date is after this date.Format: YYYY-MM-DD</param>
        /// <param name="modifiedDateBefore">The report modified date is before this date.Format: YYYY-MM-DD</param>
        /// <param name="paidDateAfter">The report paid date is after this date.Format: YYYY-MM-DD</param>
        /// <param name="paidDateBefore">The report paid date is before this date.Format: YYYY-MM-DD</param>
        /// <param name="paymentStatusCode">The payment status code for the report. The values can include Concur Expense standard codes or custom codes. The Concur Expense standard code values are: P_HOLD - Report payment is on hold; P_NOTP - Report has not been paid; P_PAID - Report has been paid; P_PAYC - Payment is confirmed. Some or all of the report expenses have been paid; P_PROC - Report is in process to be paid. For custom codes, contact Concur Developer Support.</param>
        /// <param name="paymentType">The unique identifier for the payment type that is the payment type for at least one expense entry in the report. Use PaymentTypeID from Response of GET Expense Group Configurations V3 to obtain valid payment types.</param>
        /// <param name="processingPaymentDateAfter">The report processing payment date is after this date. Format: YYYY-MM-DD</param>
        /// <param name="processingPaymentDateBefore">The report processing payment date is before this date.Format: YYYY-MM-DD</param>
        /// <param name="reimbursementMethod">The method the report owner will be reimbursed. VALUES: ADPPAYR - ADP Payroll; APCHECK - AP (Company Check); CNQRPAY - Expense Pay; PMTSERV - Other Payment Service. NOTE: PAY_PAL is NOT supported.</param>
        /// <param name="submitDateAfter">The report submit date is after this date.Format: YYYY-MM-DD</param>
        /// <param name="submitDateBefore">The report submit date is before this date.Format: YYYY-MM-DD</param>
        /// <param name="userDefinedDateAfter">The report user defined date is after this date.Format: YYYY-MM-DD</param>
        /// <param name="userDefinedDateBefore">The report user defined date is before this date.Format: YYYY-MM-DD</param>
        /// <param name="vendorName">The Vendor Description that is the vendor for at least one expense entry in the report.</param>
        /// <param name="limit">Number of records to return (default 100)</param>
        /// <param name="offset">Starting page offset</param>
        /// <param name="user">Optional. The login ID of the report owner(s) to use when searching for report digests. If the value is set to LoginID, report digests for the report owner with this login ID value are returned. If the value is set to ALL, report digests for all report owners are returned. If this parameter is not specified, report digests for the OAuth Consumer are returned. The access token owner (OAuth Consumer) must have the Web Services Admin role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<ReportDigestCollection> GetExpenseReportDigestsAsync(string approvalStatusCode = null, string approverLoginID = null, string attendeeTypeCode = null, string batchID = null, string costObject = null, string countryCode = null, DateTime? createDateAfter = null, DateTime? createDateBefore = null, string currencyCode = null, DateTime? entryTransactionDateAfter = null, DateTime? entryTransactionDateBefore = null, string expenseGroupConfigID = null, string expenseTypeCode = null, bool? hasAttendees = null, bool? hasBillableExpenses = null, bool? hasImages = null, bool? hasVAT = null, bool? isTestUser = null, DateTime? modifiedDateAfter = null, DateTime? modifiedDateBefore = null, DateTime? paidDateAfter = null, DateTime? paidDateBefore = null, string paymentStatusCode = null, string paymentType = null, DateTime? processingPaymentDateAfter = null, DateTime? processingPaymentDateBefore = null, string reimbursementMethod = null, DateTime? submitDateAfter = null, DateTime? submitDateBefore = null, DateTime? userDefinedDateAfter = null, DateTime? userDefinedDateBefore = null, string vendorName = null, Int32? limit = null, string offset = null, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/reportdigests";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("approvalStatusCode", approvalStatusCode)
                ,new KeyValuePair<string,object>("approverLoginID", approverLoginID)
                ,new KeyValuePair<string,object>("attendeeTypeCode", attendeeTypeCode)
                ,new KeyValuePair<string,object>("batchID", batchID)
                ,new KeyValuePair<string,object>("costObject", costObject)
                ,new KeyValuePair<string,object>("countryCode", countryCode)
                ,new KeyValuePair<string,object>("createDateAfter", createDateAfter)
                ,new KeyValuePair<string,object>("createDateBefore", createDateBefore)
                ,new KeyValuePair<string,object>("currencyCode", currencyCode)
                ,new KeyValuePair<string,object>("entryTransactionDateAfter", entryTransactionDateAfter)
                ,new KeyValuePair<string,object>("entryTransactionDateBefore", entryTransactionDateBefore)
                ,new KeyValuePair<string,object>("expenseGroupConfigID", expenseGroupConfigID)
                ,new KeyValuePair<string,object>("expenseTypeCode", expenseTypeCode)
                ,new KeyValuePair<string,object>("hasAttendees", hasAttendees)
                ,new KeyValuePair<string,object>("hasBillableExpenses", hasBillableExpenses)
                ,new KeyValuePair<string,object>("hasImages", hasImages)
                ,new KeyValuePair<string,object>("hasVAT", hasVAT)
                ,new KeyValuePair<string,object>("isTestUser", isTestUser)
                ,new KeyValuePair<string,object>("modifiedDateAfter", modifiedDateAfter)
                ,new KeyValuePair<string,object>("modifiedDateBefore", modifiedDateBefore)
                ,new KeyValuePair<string,object>("paidDateAfter", paidDateAfter)
                ,new KeyValuePair<string,object>("paidDateBefore", paidDateBefore)
                ,new KeyValuePair<string,object>("paymentStatusCode", paymentStatusCode)
                ,new KeyValuePair<string,object>("paymentType", paymentType)
                ,new KeyValuePair<string,object>("processingPaymentDateAfter", processingPaymentDateAfter)
                ,new KeyValuePair<string,object>("processingPaymentDateBefore", processingPaymentDateBefore)
                ,new KeyValuePair<string,object>("reimbursementMethod", reimbursementMethod)
                ,new KeyValuePair<string,object>("submitDateAfter", submitDateAfter)
                ,new KeyValuePair<string,object>("submitDateBefore", submitDateBefore)
                ,new KeyValuePair<string,object>("userDefinedDateAfter", userDefinedDateAfter)
                ,new KeyValuePair<string,object>("userDefinedDateBefore", userDefinedDateBefore)
                ,new KeyValuePair<string,object>("vendorName", vendorName)
                ,new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)
                ,new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<ReportDigestCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a single report digest by ID
        /// </summary>
        /// <param name="id">report digest ID</param>
        /// <param name="user">Optional. The login ID of the report owner(s) to use when searching for report digests. If the value is set to LoginID, report digests for the report owner with this login ID value are returned. If the value is set to ALL, report digests for all report owners are returned. If this parameter is not specified, report digests for the OAuth Consumer are returned. The access token owner (OAuth Consumer) must have the Web Services Admin role to use this parameter.</param>
        public ReportDigest GetExpenseReportDigestsById(string id, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/reportdigests/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<ReportDigest>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Gets a single report digest by ID
        /// </summary>
        /// <param name="id">report digest ID</param>
        /// <param name="user">Optional. The login ID of the report owner(s) to use when searching for report digests. If the value is set to LoginID, report digests for the report owner with this login ID value are returned. If the value is set to ALL, report digests for all report owners are returned. If this parameter is not specified, report digests for the OAuth Consumer are returned. The access token owner (OAuth Consumer) must have the Web Services Admin role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<ReportDigest> GetExpenseReportDigestsByIdAsync(string id, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/reportdigests/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<ReportDigest>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all reports
        /// </summary>
        /// <param name="approvalStatusCode">The status code for the Approval Status. The values can include Concur Expense standard codes or custom codes. The Concur Expense standard code values are: A_AAFH - Report submission triggered an anomaly and fraud check; A_ACCO - Report is pending reviews; A_APPR - Report has been approved; A_EXTV - Report is pending external validation; A_FILE - Report has been submitted; A_NOTF - Report has not been submitted; A_PBDG - Report approval is pending Budget approval; A_PECO - Report approval is pending Cost object approval; A_PEND - Report is pending manager approval; A_PVAL - Report is pending prepayment validation; A_RESU - Report needs to be resubmitted; A_RHLD - Report submission is pending receipt images; A_TEXP - Report expired in approval queue. For custom codes, contact Concur Developer Support.</param>
        /// <param name="approverLoginID">The login ID for the report approver that is the current approver assigned to the report.</param>
        /// <param name="attendeeTypeCode">The report contains expense entries that have attendees of the specified type.</param>
        /// <param name="batchID">The unique identifier for a payment batch where there is at least one report payee within the report. Use the BatchID from Response of GET Payment Batch List.</param>
        /// <param name="costObject">The list item code for an allocation field for at least allocation in the report.</param>
        /// <param name="countryCode">The report country. Maximum 2 characters. Format: The ISO 3166-1 alpha-2 country code. Example: United States is US.</param>
        /// <param name="createDateAfter">The report create date is after this date.Format: YYYY-MM-DD</param>
        /// <param name="createDateBefore">The report create date is before this date.Format: YYYY-MM-DD</param>
        /// <param name="currencyCode">The 3-letter ISO 4217 currency code for the report currency. Example: USD.</param>
        /// <param name="entryTransactionDateAfter">The entry transaction date for at least one expense entry in the report is after this date.Format: YYYY-MM-DD</param>
        /// <param name="entryTransactionDateBefore">The entry transaction date for at least one expense entry in the report is before this date.Format: YYYY-MM-DD</param>
        /// <param name="expenseGroupConfigID">The unique identifier for the expense group configuration associated to the report's expense group. Use the ID from the Response of the Expense Group Configurations V3.</param>
        /// <param name="expenseTypeCode">The expense type code that is the expense type for at least one expense entry in the report. Use ExpenseTypeCode from Response of GET Expense Group Configurations V3.</param>
        /// <param name="hasAttendees">Determines if the report has at least one expense entry with an attendee. FORMAT: true or false.</param>
        /// <param name="hasBillableExpenses">The IsBillable flag for at least one expense entry in the report. FORMAT: true or false.</param>
        /// <param name="hasImages">Determines if the report has at least one expense entry with an entry image or if there is a report image for this report. FORMAT: true or false.</param>
        /// <param name="hasVAT">Determines if the report has at least one expense entry with VAT details. FORMAT: true or false.</param>
        /// <param name="isTestUser">The report owner is a test user using the report for testing purposes in a non-production envirnment. FORMAT: true or false.</param>
        /// <param name="modifiedDateAfter">The report modified date is after this date.Format: YYYY-MM-DD</param>
        /// <param name="modifiedDateBefore">The report modified date is before this date.Format: YYYY-MM-DD</param>
        /// <param name="paidDateAfter">The report paid date is after this date.Format: YYYY-MM-DD</param>
        /// <param name="paidDateBefore">The report paid date is before this date.Format: YYYY-MM-DD</param>
        /// <param name="paymentStatusCode">The payment status code for the report. The values can include Concur Expense standard codes or custom codes. The Concur Expense standard code values are: P_HOLD - Report payment is on hold; P_NOTP - Report has not been paid; P_PAID - Report has been paid; P_PAYC - Payment is confirmed. Some or all of the report expenses have been paid; P_PROC - Report is in process to be paid. For custom codes, contact Concur Developer Support.</param>
        /// <param name="paymentType">The unique identifier for the payment type that is the payment type for at least one expense entry in the report. Use PaymentTypeID from Response of GET Expense Group Configurations V3 to obtain valid payment types.</param>
        /// <param name="processingPaymentDateAfter">The report processing payment date is after this date. Format: YYYY-MM-DD</param>
        /// <param name="processingPaymentDateBefore">The report processing payment date is before this date.Format: YYYY-MM-DD</param>
        /// <param name="reimbursementMethod">The method the report owner will be reimbursed. VALUES: ADPPAYR - ADP Payroll; APCHECK - AP (Company Check); CNQRPAY - Expense Pay; PMTSERV - Other Payment Service. NOTE: PAY_PAL is NOT supported.</param>
        /// <param name="submitDateAfter">The report submit date is after this date.Format: YYYY-MM-DD</param>
        /// <param name="submitDateBefore">The report submit date is before this date.Format: YYYY-MM-DD</param>
        /// <param name="userDefinedDateAfter">The report user defined date is after this date.Format: YYYY-MM-DD</param>
        /// <param name="userDefinedDateBefore">The report user defined date is before this date.Format: YYYY-MM-DD</param>
        /// <param name="vendorName">The Vendor Description that is the vendor for at least one expense entry in the report.</param>
        /// <param name="limit">Number of records to return (default 25)</param>
        /// <param name="offset">Starting page offset</param>
        /// <param name="user">Optional. The login ID of the report owner(s) to use when searching for reports. If the value is set to LoginID, reports for the report owner with this login ID value are returned. If the value is set to ALL, reports for all report owners are returned. If this parameter is not specified, reports for the OAuth Consumer are returned. The access token owner (OAuth Consumer) must have the Web Services Admin role to use this parameter.</param>
        public ReportCollection GetExpenseReports(string approvalStatusCode = null, string approverLoginID = null, string attendeeTypeCode = null, string batchID = null, string costObject = null, string countryCode = null, DateTime? createDateAfter = null, DateTime? createDateBefore = null, string currencyCode = null, DateTime? entryTransactionDateAfter = null, DateTime? entryTransactionDateBefore = null, string expenseGroupConfigID = null, string expenseTypeCode = null, bool? hasAttendees = null, bool? hasBillableExpenses = null, bool? hasImages = null, bool? hasVAT = null, bool? isTestUser = null, DateTime? modifiedDateAfter = null, DateTime? modifiedDateBefore = null, DateTime? paidDateAfter = null, DateTime? paidDateBefore = null, string paymentStatusCode = null, string paymentType = null, DateTime? processingPaymentDateAfter = null, DateTime? processingPaymentDateBefore = null, string reimbursementMethod = null, DateTime? submitDateAfter = null, DateTime? submitDateBefore = null, DateTime? userDefinedDateAfter = null, DateTime? userDefinedDateBefore = null, string vendorName = null, Int32? limit = null, string offset = null, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/reports";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("approvalStatusCode", approvalStatusCode)
                ,new KeyValuePair<string,object>("approverLoginID", approverLoginID)
                ,new KeyValuePair<string,object>("attendeeTypeCode", attendeeTypeCode)
                ,new KeyValuePair<string,object>("batchID", batchID)
                ,new KeyValuePair<string,object>("costObject", costObject)
                ,new KeyValuePair<string,object>("countryCode", countryCode)
                ,new KeyValuePair<string,object>("createDateAfter", createDateAfter)
                ,new KeyValuePair<string,object>("createDateBefore", createDateBefore)
                ,new KeyValuePair<string,object>("currencyCode", currencyCode)
                ,new KeyValuePair<string,object>("entryTransactionDateAfter", entryTransactionDateAfter)
                ,new KeyValuePair<string,object>("entryTransactionDateBefore", entryTransactionDateBefore)
                ,new KeyValuePair<string,object>("expenseGroupConfigID", expenseGroupConfigID)
                ,new KeyValuePair<string,object>("expenseTypeCode", expenseTypeCode)
                ,new KeyValuePair<string,object>("hasAttendees", hasAttendees)
                ,new KeyValuePair<string,object>("hasBillableExpenses", hasBillableExpenses)
                ,new KeyValuePair<string,object>("hasImages", hasImages)
                ,new KeyValuePair<string,object>("hasVAT", hasVAT)
                ,new KeyValuePair<string,object>("isTestUser", isTestUser)
                ,new KeyValuePair<string,object>("modifiedDateAfter", modifiedDateAfter)
                ,new KeyValuePair<string,object>("modifiedDateBefore", modifiedDateBefore)
                ,new KeyValuePair<string,object>("paidDateAfter", paidDateAfter)
                ,new KeyValuePair<string,object>("paidDateBefore", paidDateBefore)
                ,new KeyValuePair<string,object>("paymentStatusCode", paymentStatusCode)
                ,new KeyValuePair<string,object>("paymentType", paymentType)
                ,new KeyValuePair<string,object>("processingPaymentDateAfter", processingPaymentDateAfter)
                ,new KeyValuePair<string,object>("processingPaymentDateBefore", processingPaymentDateBefore)
                ,new KeyValuePair<string,object>("reimbursementMethod", reimbursementMethod)
                ,new KeyValuePair<string,object>("submitDateAfter", submitDateAfter)
                ,new KeyValuePair<string,object>("submitDateBefore", submitDateBefore)
                ,new KeyValuePair<string,object>("userDefinedDateAfter", userDefinedDateAfter)
                ,new KeyValuePair<string,object>("userDefinedDateBefore", userDefinedDateBefore)
                ,new KeyValuePair<string,object>("vendorName", vendorName)
                ,new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)
                ,new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<ReportCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Gets all reports
        /// </summary>
        /// <param name="approvalStatusCode">The status code for the Approval Status. The values can include Concur Expense standard codes or custom codes. The Concur Expense standard code values are: A_AAFH - Report submission triggered an anomaly and fraud check; A_ACCO - Report is pending reviews; A_APPR - Report has been approved; A_EXTV - Report is pending external validation; A_FILE - Report has been submitted; A_NOTF - Report has not been submitted; A_PBDG - Report approval is pending Budget approval; A_PECO - Report approval is pending Cost object approval; A_PEND - Report is pending manager approval; A_PVAL - Report is pending prepayment validation; A_RESU - Report needs to be resubmitted; A_RHLD - Report submission is pending receipt images; A_TEXP - Report expired in approval queue. For custom codes, contact Concur Developer Support.</param>
        /// <param name="approverLoginID">The login ID for the report approver that is the current approver assigned to the report.</param>
        /// <param name="attendeeTypeCode">The report contains expense entries that have attendees of the specified type.</param>
        /// <param name="batchID">The unique identifier for a payment batch where there is at least one report payee within the report. Use the BatchID from Response of GET Payment Batch List.</param>
        /// <param name="costObject">The list item code for an allocation field for at least allocation in the report.</param>
        /// <param name="countryCode">The report country. Maximum 2 characters. Format: The ISO 3166-1 alpha-2 country code. Example: United States is US.</param>
        /// <param name="createDateAfter">The report create date is after this date.Format: YYYY-MM-DD</param>
        /// <param name="createDateBefore">The report create date is before this date.Format: YYYY-MM-DD</param>
        /// <param name="currencyCode">The 3-letter ISO 4217 currency code for the report currency. Example: USD.</param>
        /// <param name="entryTransactionDateAfter">The entry transaction date for at least one expense entry in the report is after this date.Format: YYYY-MM-DD</param>
        /// <param name="entryTransactionDateBefore">The entry transaction date for at least one expense entry in the report is before this date.Format: YYYY-MM-DD</param>
        /// <param name="expenseGroupConfigID">The unique identifier for the expense group configuration associated to the report's expense group. Use the ID from the Response of the Expense Group Configurations V3.</param>
        /// <param name="expenseTypeCode">The expense type code that is the expense type for at least one expense entry in the report. Use ExpenseTypeCode from Response of GET Expense Group Configurations V3.</param>
        /// <param name="hasAttendees">Determines if the report has at least one expense entry with an attendee. FORMAT: true or false.</param>
        /// <param name="hasBillableExpenses">The IsBillable flag for at least one expense entry in the report. FORMAT: true or false.</param>
        /// <param name="hasImages">Determines if the report has at least one expense entry with an entry image or if there is a report image for this report. FORMAT: true or false.</param>
        /// <param name="hasVAT">Determines if the report has at least one expense entry with VAT details. FORMAT: true or false.</param>
        /// <param name="isTestUser">The report owner is a test user using the report for testing purposes in a non-production envirnment. FORMAT: true or false.</param>
        /// <param name="modifiedDateAfter">The report modified date is after this date.Format: YYYY-MM-DD</param>
        /// <param name="modifiedDateBefore">The report modified date is before this date.Format: YYYY-MM-DD</param>
        /// <param name="paidDateAfter">The report paid date is after this date.Format: YYYY-MM-DD</param>
        /// <param name="paidDateBefore">The report paid date is before this date.Format: YYYY-MM-DD</param>
        /// <param name="paymentStatusCode">The payment status code for the report. The values can include Concur Expense standard codes or custom codes. The Concur Expense standard code values are: P_HOLD - Report payment is on hold; P_NOTP - Report has not been paid; P_PAID - Report has been paid; P_PAYC - Payment is confirmed. Some or all of the report expenses have been paid; P_PROC - Report is in process to be paid. For custom codes, contact Concur Developer Support.</param>
        /// <param name="paymentType">The unique identifier for the payment type that is the payment type for at least one expense entry in the report. Use PaymentTypeID from Response of GET Expense Group Configurations V3 to obtain valid payment types.</param>
        /// <param name="processingPaymentDateAfter">The report processing payment date is after this date. Format: YYYY-MM-DD</param>
        /// <param name="processingPaymentDateBefore">The report processing payment date is before this date.Format: YYYY-MM-DD</param>
        /// <param name="reimbursementMethod">The method the report owner will be reimbursed. VALUES: ADPPAYR - ADP Payroll; APCHECK - AP (Company Check); CNQRPAY - Expense Pay; PMTSERV - Other Payment Service. NOTE: PAY_PAL is NOT supported.</param>
        /// <param name="submitDateAfter">The report submit date is after this date.Format: YYYY-MM-DD</param>
        /// <param name="submitDateBefore">The report submit date is before this date.Format: YYYY-MM-DD</param>
        /// <param name="userDefinedDateAfter">The report user defined date is after this date.Format: YYYY-MM-DD</param>
        /// <param name="userDefinedDateBefore">The report user defined date is before this date.Format: YYYY-MM-DD</param>
        /// <param name="vendorName">The Vendor Description that is the vendor for at least one expense entry in the report.</param>
        /// <param name="limit">Number of records to return (default 25)</param>
        /// <param name="offset">Starting page offset</param>
        /// <param name="user">Optional. The login ID of the report owner(s) to use when searching for reports. If the value is set to LoginID, reports for the report owner with this login ID value are returned. If the value is set to ALL, reports for all report owners are returned. If this parameter is not specified, reports for the OAuth Consumer are returned. The access token owner (OAuth Consumer) must have the Web Services Admin role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<ReportCollection> GetExpenseReportsAsync(string approvalStatusCode = null, string approverLoginID = null, string attendeeTypeCode = null, string batchID = null, string costObject = null, string countryCode = null, DateTime? createDateAfter = null, DateTime? createDateBefore = null, string currencyCode = null, DateTime? entryTransactionDateAfter = null, DateTime? entryTransactionDateBefore = null, string expenseGroupConfigID = null, string expenseTypeCode = null, bool? hasAttendees = null, bool? hasBillableExpenses = null, bool? hasImages = null, bool? hasVAT = null, bool? isTestUser = null, DateTime? modifiedDateAfter = null, DateTime? modifiedDateBefore = null, DateTime? paidDateAfter = null, DateTime? paidDateBefore = null, string paymentStatusCode = null, string paymentType = null, DateTime? processingPaymentDateAfter = null, DateTime? processingPaymentDateBefore = null, string reimbursementMethod = null, DateTime? submitDateAfter = null, DateTime? submitDateBefore = null, DateTime? userDefinedDateAfter = null, DateTime? userDefinedDateBefore = null, string vendorName = null, Int32? limit = null, string offset = null, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/reports";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("approvalStatusCode", approvalStatusCode)
                ,new KeyValuePair<string,object>("approverLoginID", approverLoginID)
                ,new KeyValuePair<string,object>("attendeeTypeCode", attendeeTypeCode)
                ,new KeyValuePair<string,object>("batchID", batchID)
                ,new KeyValuePair<string,object>("costObject", costObject)
                ,new KeyValuePair<string,object>("countryCode", countryCode)
                ,new KeyValuePair<string,object>("createDateAfter", createDateAfter)
                ,new KeyValuePair<string,object>("createDateBefore", createDateBefore)
                ,new KeyValuePair<string,object>("currencyCode", currencyCode)
                ,new KeyValuePair<string,object>("entryTransactionDateAfter", entryTransactionDateAfter)
                ,new KeyValuePair<string,object>("entryTransactionDateBefore", entryTransactionDateBefore)
                ,new KeyValuePair<string,object>("expenseGroupConfigID", expenseGroupConfigID)
                ,new KeyValuePair<string,object>("expenseTypeCode", expenseTypeCode)
                ,new KeyValuePair<string,object>("hasAttendees", hasAttendees)
                ,new KeyValuePair<string,object>("hasBillableExpenses", hasBillableExpenses)
                ,new KeyValuePair<string,object>("hasImages", hasImages)
                ,new KeyValuePair<string,object>("hasVAT", hasVAT)
                ,new KeyValuePair<string,object>("isTestUser", isTestUser)
                ,new KeyValuePair<string,object>("modifiedDateAfter", modifiedDateAfter)
                ,new KeyValuePair<string,object>("modifiedDateBefore", modifiedDateBefore)
                ,new KeyValuePair<string,object>("paidDateAfter", paidDateAfter)
                ,new KeyValuePair<string,object>("paidDateBefore", paidDateBefore)
                ,new KeyValuePair<string,object>("paymentStatusCode", paymentStatusCode)
                ,new KeyValuePair<string,object>("paymentType", paymentType)
                ,new KeyValuePair<string,object>("processingPaymentDateAfter", processingPaymentDateAfter)
                ,new KeyValuePair<string,object>("processingPaymentDateBefore", processingPaymentDateBefore)
                ,new KeyValuePair<string,object>("reimbursementMethod", reimbursementMethod)
                ,new KeyValuePair<string,object>("submitDateAfter", submitDateAfter)
                ,new KeyValuePair<string,object>("submitDateBefore", submitDateBefore)
                ,new KeyValuePair<string,object>("userDefinedDateAfter", userDefinedDateAfter)
                ,new KeyValuePair<string,object>("userDefinedDateBefore", userDefinedDateBefore)
                ,new KeyValuePair<string,object>("vendorName", vendorName)
                ,new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)
                ,new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<ReportCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a single report by ID
        /// </summary>
        /// <param name="id">report ID</param>
        /// <param name="user">Optional. The login ID of the report owner(s) to use when searching for reports. If the value is set to LoginID, reports for the report owner with this login ID value are returned. If the value is set to ALL, reports for all report owners are returned. If this parameter is not specified, reports for the OAuth Consumer are returned. The access token owner (OAuth Consumer) must have the Web Services Admin role to use this parameter.</param>
        public ReportGet GetExpenseReportsById(string id, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/reports/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<ReportGet>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Gets a single report by ID
        /// </summary>
        /// <param name="id">report ID</param>
        /// <param name="user">Optional. The login ID of the report owner(s) to use when searching for reports. If the value is set to LoginID, reports for the report owner with this login ID value are returned. If the value is set to ALL, reports for all report owners are returned. If this parameter is not specified, reports for the OAuth Consumer are returned. The access token owner (OAuth Consumer) must have the Web Services Admin role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<ReportGet> GetExpenseReportsByIdAsync(string id, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/reports/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<ReportGet>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new report
        /// </summary>
        /// <param name="content">report object to create</param>
        /// <param name="user">Optional. The login ID for the Report Owner.</param>
        public CreateResponse CreateExpenseReports(ReportPost content, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/reports";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<CreateResponse>(
                "POST",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Create a new report
        /// </summary>
        /// <param name="content">report object to create</param>
        /// <param name="user">Optional. The login ID for the Report Owner.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<CreateResponse> CreateExpenseReportsAsync(ReportPost content, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/reports";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<CreateResponse>(
                "POST",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update report
        /// </summary>
        /// <param name="id">The unique identifier for the report.</param>
        /// <param name="content">The report object to update</param>
        /// <param name="user">Optional. The login ID for the Report Owner.</param>
        public Object UpdateExpenseReportsById(string id, ReportPut content, string user = null)
        {
            string remoteServiceRelativeUrl = @"/expense/reports/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<Object>(
                "PUT",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Update report
        /// </summary>
        /// <param name="id">The unique identifier for the report.</param>
        /// <param name="content">The report object to update</param>
        /// <param name="user">Optional. The login ID for the Report Owner.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<Object> UpdateExpenseReportsByIdAsync(string id, ReportPut content, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/expense/reports/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<Object>(
                "PUT",
                requestUrl,
                content,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a Travel Request by ID
        /// </summary>
        /// <param name="id">Travel Request ID</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public TravelRequestDetails GetTravelRequestsById(string id, string user = null)
        {
            string remoteServiceRelativeUrl = @"/travelrequest/requests/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<TravelRequestDetails>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Get a Travel Request by ID
        /// </summary>
        /// <param name="id">Travel Request ID</param>
        /// <param name="user">The login ID of the user. Optional. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<TravelRequestDetails> GetTravelRequestsByIdAsync(string id, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/travelrequest/requests/{id}";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<TravelRequestDetails>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get all Requests
        /// </summary>
        /// <param name="modifiedAfter">This returns travel requests in which the associated dependents (header, entries, segments, allocations, attendees, comments ) were modified after the specified date and time. This search term can be used along with other search terms to narrow the results. The date and time (if desired) should be in UTC. The format is: YYYY-MM-DDThh:mm:ss.</param>
        /// <param name="modifiedBefore">This returns travel requests in which the associated dependents (header, entries, segments, allocations, attendees, comments ) were modified before the specified date and time.This search term can be used along with other search terms to narrow the results. The date and time (if desired) should be in UTC. The format is: YYYY-MM-DDThh:mm:ss.</param>
        /// <param name="status">The Status search term specifies which travel request or approval status to return. If no Status value is sent, the default Status of Active will be used. Allowed values are: ACTIVE, UNSUBMITTED, PENDING, VALIDATED, CANCELED, CLOSED, SUBMITTED, TOAPPROVE, APPROVED, PENDINGPROPOSAL, PROPOSALAPPROVED, PROPOSALCANCELED, PENDING_EBOOKING. </param>
        /// <param name="withSegmentTypes">No Documentation Found.</param>
        /// <param name="limit">Number of records to return (default 100)</param>
        /// <param name="offset">Starting page offset</param>
        /// <param name="user">Login ID of the user to act on the behalf of. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        public RequestCollection GetTravelRequests(DateTime? modifiedAfter = null, DateTime? modifiedBefore = null, string status = null, bool withSegmentTypes = false, Int32? limit = null, string offset = null, string user = null)
        {
            string remoteServiceRelativeUrl = @"/travelrequest/requests";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("modifiedAfter", modifiedAfter)
                ,new KeyValuePair<string,object>("modifiedBefore", modifiedBefore)
                ,new KeyValuePair<string,object>("status", status)
                ,new KeyValuePair<string,object>("withSegmentTypes", withSegmentTypes)
                ,new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)
                ,new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<RequestCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Get all Requests
        /// </summary>
        /// <param name="modifiedAfter">This returns travel requests in which the associated dependents (header, entries, segments, allocations, attendees, comments ) were modified after the specified date and time. This search term can be used along with other search terms to narrow the results. The date and time (if desired) should be in UTC. The format is: YYYY-MM-DDThh:mm:ss.</param>
        /// <param name="modifiedBefore">This returns travel requests in which the associated dependents (header, entries, segments, allocations, attendees, comments ) were modified before the specified date and time.This search term can be used along with other search terms to narrow the results. The date and time (if desired) should be in UTC. The format is: YYYY-MM-DDThh:mm:ss.</param>
        /// <param name="status">The Status search term specifies which travel request or approval status to return. If no Status value is sent, the default Status of Active will be used. Allowed values are: ACTIVE, UNSUBMITTED, PENDING, VALIDATED, CANCELED, CLOSED, SUBMITTED, TOAPPROVE, APPROVED, PENDINGPROPOSAL, PROPOSALAPPROVED, PROPOSALCANCELED, PENDING_EBOOKING. </param>
        /// <param name="withSegmentTypes">No Documentation Found.</param>
        /// <param name="limit">Number of records to return (default 100)</param>
        /// <param name="offset">Starting page offset</param>
        /// <param name="user">Login ID of the user to act on the behalf of. The user must have the Web Services Admin (Professional) or Can Administer (Standard) user role to use this parameter.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<RequestCollection> GetTravelRequestsAsync(DateTime? modifiedAfter = null, DateTime? modifiedBefore = null, string status = null, bool withSegmentTypes = false, Int32? limit = null, string offset = null, string user = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/travelrequest/requests";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("modifiedAfter", modifiedAfter)
                ,new KeyValuePair<string,object>("modifiedBefore", modifiedBefore)
                ,new KeyValuePair<string,object>("status", status)
                ,new KeyValuePair<string,object>("withSegmentTypes", withSegmentTypes)
                ,new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)
                ,new KeyValuePair<string,object>("user", user)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<RequestCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get invoices for calculating tax.
        /// </summary>
        /// <param name="modifiedafter">Date param, filter invoice retrieved to the ones only modified after certain date.</param>
        /// <param name="limit">Limit the number of invopices retrieved. Max supported is 1000.</param>
        /// <param name="offset">Offset for pages, offset is number of results breaken down by limit. If sepcified by user if should be Zero, else use offset from next page URI.</param>
        public InvoiceCollection GetInvoiceSalesTaxValidationRequest(string modifiedafter = null, Int32? limit = null, string offset = null)
        {
            string remoteServiceRelativeUrl = @"/invoice/salestaxvalidationrequest";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("modifiedafter", modifiedafter)
                ,new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<InvoiceCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Get invoices for calculating tax.
        /// </summary>
        /// <param name="modifiedafter">Date param, filter invoice retrieved to the ones only modified after certain date.</param>
        /// <param name="limit">Limit the number of invopices retrieved. Max supported is 1000.</param>
        /// <param name="offset">Offset for pages, offset is number of results breaken down by limit. If sepcified by user if should be Zero, else use offset from next page URI.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<InvoiceCollection> GetInvoiceSalesTaxValidationRequestAsync(string modifiedafter = null, Int32? limit = null, string offset = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/invoice/salestaxvalidationrequest";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("modifiedafter", modifiedafter)
                ,new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<InvoiceCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates invoices with calcuated tax amount and tax rate.
        /// </summary>
        /// <param name="invoice">Tax information for the invoice, which needs to be updated.</param>
        public InvoiceStatus UpdateInvoiceSalesTaxValidationRequest(Invoice invoice)
        {
            string remoteServiceRelativeUrl = @"/invoice/salestaxvalidationrequest";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<InvoiceStatus>(
                "PUT",
                requestUrl,
                invoice,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Updates invoices with calcuated tax amount and tax rate.
        /// </summary>
        /// <param name="invoice">Tax information for the invoice, which needs to be updated.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<InvoiceStatus> UpdateInvoiceSalesTaxValidationRequestAsync(Invoice invoice, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/invoice/salestaxvalidationrequest";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<InvoiceStatus>(
                "PUT",
                requestUrl,
                invoice,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets All Suppliers by Search Criteria
        /// </summary>
        /// <param name="address">Address</param>
        /// <param name="address2">Address</param>
        /// <param name="city">City</param>
        /// <param name="country">Country Code</param>
        /// <param name="iataCode">IATA Code</param>
        /// <param name="mcCode">MCC Code (Ex: Delta Airline - 3058)</param>
        /// <param name="merchantID">Merchant Id</param>
        /// <param name="merchantType">Merchant Type Code(Ex: Visa - VI, Amex - AX) </param>
        /// <param name="name">Name</param>
        /// <param name="phone">Phone</param>
        /// <param name="relevance">Relevance of the Search results</param>
        /// <param name="state">State</param>
        /// <param name="taxId">Tax Id</param>
        /// <param name="zip">Zip</param>
        public SupplierCollection GetCommonSuppliers(string address = null, string address2 = null, string city = null, string country = null, string iataCode = null, string mcCode = null, string merchantID = null, string merchantType = null, string name = null, string phone = null, Int32? relevance = null, string state = null, string taxId = null, string zip = null)
        {
            string remoteServiceRelativeUrl = @"/common/suppliers";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("address", address)
                ,new KeyValuePair<string,object>("address2", address2)
                ,new KeyValuePair<string,object>("city", city)
                ,new KeyValuePair<string,object>("country", country)
                ,new KeyValuePair<string,object>("iataCode", iataCode)
                ,new KeyValuePair<string,object>("mcCode", mcCode)
                ,new KeyValuePair<string,object>("merchantID", merchantID)
                ,new KeyValuePair<string,object>("merchantType", merchantType)
                ,new KeyValuePair<string,object>("name", name)
                ,new KeyValuePair<string,object>("phone", phone)
                ,new KeyValuePair<string,object>("relevance", relevance)
                ,new KeyValuePair<string,object>("state", state)
                ,new KeyValuePair<string,object>("taxId", taxId)
                ,new KeyValuePair<string,object>("zip", zip)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<SupplierCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Gets All Suppliers by Search Criteria
        /// </summary>
        /// <param name="address">Address</param>
        /// <param name="address2">Address</param>
        /// <param name="city">City</param>
        /// <param name="country">Country Code</param>
        /// <param name="iataCode">IATA Code</param>
        /// <param name="mcCode">MCC Code (Ex: Delta Airline - 3058)</param>
        /// <param name="merchantID">Merchant Id</param>
        /// <param name="merchantType">Merchant Type Code(Ex: Visa - VI, Amex - AX) </param>
        /// <param name="name">Name</param>
        /// <param name="phone">Phone</param>
        /// <param name="relevance">Relevance of the Search results</param>
        /// <param name="state">State</param>
        /// <param name="taxId">Tax Id</param>
        /// <param name="zip">Zip</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<SupplierCollection> GetCommonSuppliersAsync(string address = null, string address2 = null, string city = null, string country = null, string iataCode = null, string mcCode = null, string merchantID = null, string merchantType = null, string name = null, string phone = null, Int32? relevance = null, string state = null, string taxId = null, string zip = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/common/suppliers";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("address", address)
                ,new KeyValuePair<string,object>("address2", address2)
                ,new KeyValuePair<string,object>("city", city)
                ,new KeyValuePair<string,object>("country", country)
                ,new KeyValuePair<string,object>("iataCode", iataCode)
                ,new KeyValuePair<string,object>("mcCode", mcCode)
                ,new KeyValuePair<string,object>("merchantID", merchantID)
                ,new KeyValuePair<string,object>("merchantType", merchantType)
                ,new KeyValuePair<string,object>("name", name)
                ,new KeyValuePair<string,object>("phone", phone)
                ,new KeyValuePair<string,object>("relevance", relevance)
                ,new KeyValuePair<string,object>("state", state)
                ,new KeyValuePair<string,object>("taxId", taxId)
                ,new KeyValuePair<string,object>("zip", zip)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<SupplierCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a single Supplier by ID
        /// </summary>
        /// <param name="id">Supplier Id</param>
        public SupplierSingle GetCommonSuppliersById(string id)
        {
            string remoteServiceRelativeUrl = @"/common/suppliers/{id}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<SupplierSingle>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Get a single Supplier by ID
        /// </summary>
        /// <param name="id">Supplier Id</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<SupplierSingle> GetCommonSuppliersByIdAsync(string id, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/common/suppliers/{id}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("id", id)

            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<SupplierSingle>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves an existing vendor.
        /// </summary>
        /// <param name="address1">Address 1 to be searched</param>
        /// <param name="address2">Address 2 to be searched</param>
        /// <param name="address3">Address 3 to be searched</param>
        /// <param name="addressCode">Address Code to be searched</param>
        /// <param name="approved">Find Approved/Un Approved Vendors , True/False</param>
        /// <param name="buyerAccountNumber">Buyer Account Number to be searched</param>
        /// <param name="city">City to be searched</param>
        /// <param name="country">Country to be searched</param>
        /// <param name="custom1">Custom 1 to be searched</param>
        /// <param name="custom10">Custom 10 to be searched</param>
        /// <param name="custom11">Custom 11 to be searched</param>
        /// <param name="custom12">Custom 12 to be searched</param>
        /// <param name="custom13">Custom 13 to be searched</param>
        /// <param name="custom14">Custom 14 to be searched</param>
        /// <param name="custom15">Custom 15 to be searched</param>
        /// <param name="custom16">Custom 16 to be searched</param>
        /// <param name="custom17">Custom 17 to be searched</param>
        /// <param name="custom18">Custom 18 to be searched</param>
        /// <param name="custom19">Custom 19 to be searched</param>
        /// <param name="custom2">Custom 2 to be searched</param>
        /// <param name="custom20">Custom 20 to be searched</param>
        /// <param name="custom3">Custom 3 to be searched</param>
        /// <param name="custom4">Custom 4 to be searched</param>
        /// <param name="custom5">Custom 5 to be searched</param>
        /// <param name="custom6">Custom 6 to be searched</param>
        /// <param name="custom7">Custom 7 to be searched</param>
        /// <param name="custom8">Custom 8 to be searched</param>
        /// <param name="custom9">Custom 9 to be searched</param>
        /// <param name="postalCode">Postal Code to be searched</param>
        /// <param name="searchType">Valid Options - exact, begins, contains and ends - Applies for the entire given search parameters. The default value if not sent is exact.</param>
        /// <param name="sortBy">Field you need to the results to be sorted by. Vendor Name will be made default if no value is sent. Only fields that are added to the vendor form can be used here. Fields have to be specified by name as specified in Doc.</param>
        /// <param name="sortDirection">ascending or descending, The default value will be ascending.</param>
        /// <param name="state">State to be searched</param>
        /// <param name="taxID">Tax ID to be searched</param>
        /// <param name="vendorCode">Vendor Code to be searched</param>
        /// <param name="vendorName">Vendor Name to be searched</param>
        /// <param name="limit">The maximum number of items to be returned in a  response. The default is 25 and cannot exceed 1000.</param>
        /// <param name="offset">Specifies the starting point for the next query when iterating through the collection response.  Use with paged collections of resources.</param>
        public VendorCollection GetInvoiceVendors(string address1 = null, string address2 = null, string address3 = null, string addressCode = null, string approved = null, string buyerAccountNumber = null, string city = null, string country = null, string custom1 = null, string custom10 = null, string custom11 = null, string custom12 = null, string custom13 = null, string custom14 = null, string custom15 = null, string custom16 = null, string custom17 = null, string custom18 = null, string custom19 = null, string custom2 = null, string custom20 = null, string custom3 = null, string custom4 = null, string custom5 = null, string custom6 = null, string custom7 = null, string custom8 = null, string custom9 = null, string postalCode = null, string searchType = null, string sortBy = null, string sortDirection = null, string state = null, string taxID = null, string vendorCode = null, string vendorName = null, Int32? limit = null, string offset = null)
        {
            string remoteServiceRelativeUrl = @"/invoice/vendors";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("address1", address1)
                ,new KeyValuePair<string,object>("address2", address2)
                ,new KeyValuePair<string,object>("address3", address3)
                ,new KeyValuePair<string,object>("addressCode", addressCode)
                ,new KeyValuePair<string,object>("approved", approved)
                ,new KeyValuePair<string,object>("buyerAccountNumber", buyerAccountNumber)
                ,new KeyValuePair<string,object>("city", city)
                ,new KeyValuePair<string,object>("country", country)
                ,new KeyValuePair<string,object>("custom1", custom1)
                ,new KeyValuePair<string,object>("custom10", custom10)
                ,new KeyValuePair<string,object>("custom11", custom11)
                ,new KeyValuePair<string,object>("custom12", custom12)
                ,new KeyValuePair<string,object>("custom13", custom13)
                ,new KeyValuePair<string,object>("custom14", custom14)
                ,new KeyValuePair<string,object>("custom15", custom15)
                ,new KeyValuePair<string,object>("custom16", custom16)
                ,new KeyValuePair<string,object>("custom17", custom17)
                ,new KeyValuePair<string,object>("custom18", custom18)
                ,new KeyValuePair<string,object>("custom19", custom19)
                ,new KeyValuePair<string,object>("custom2", custom2)
                ,new KeyValuePair<string,object>("custom20", custom20)
                ,new KeyValuePair<string,object>("custom3", custom3)
                ,new KeyValuePair<string,object>("custom4", custom4)
                ,new KeyValuePair<string,object>("custom5", custom5)
                ,new KeyValuePair<string,object>("custom6", custom6)
                ,new KeyValuePair<string,object>("custom7", custom7)
                ,new KeyValuePair<string,object>("custom8", custom8)
                ,new KeyValuePair<string,object>("custom9", custom9)
                ,new KeyValuePair<string,object>("postalCode", postalCode)
                ,new KeyValuePair<string,object>("searchType", searchType)
                ,new KeyValuePair<string,object>("sortBy", sortBy)
                ,new KeyValuePair<string,object>("sortDirection", sortDirection)
                ,new KeyValuePair<string,object>("state", state)
                ,new KeyValuePair<string,object>("taxID", taxID)
                ,new KeyValuePair<string,object>("vendorCode", vendorCode)
                ,new KeyValuePair<string,object>("vendorName", vendorName)
                ,new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<VendorCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Retrieves an existing vendor.
        /// </summary>
        /// <param name="address1">Address 1 to be searched</param>
        /// <param name="address2">Address 2 to be searched</param>
        /// <param name="address3">Address 3 to be searched</param>
        /// <param name="addressCode">Address Code to be searched</param>
        /// <param name="approved">Find Approved/Un Approved Vendors , True/False</param>
        /// <param name="buyerAccountNumber">Buyer Account Number to be searched</param>
        /// <param name="city">City to be searched</param>
        /// <param name="country">Country to be searched</param>
        /// <param name="custom1">Custom 1 to be searched</param>
        /// <param name="custom10">Custom 10 to be searched</param>
        /// <param name="custom11">Custom 11 to be searched</param>
        /// <param name="custom12">Custom 12 to be searched</param>
        /// <param name="custom13">Custom 13 to be searched</param>
        /// <param name="custom14">Custom 14 to be searched</param>
        /// <param name="custom15">Custom 15 to be searched</param>
        /// <param name="custom16">Custom 16 to be searched</param>
        /// <param name="custom17">Custom 17 to be searched</param>
        /// <param name="custom18">Custom 18 to be searched</param>
        /// <param name="custom19">Custom 19 to be searched</param>
        /// <param name="custom2">Custom 2 to be searched</param>
        /// <param name="custom20">Custom 20 to be searched</param>
        /// <param name="custom3">Custom 3 to be searched</param>
        /// <param name="custom4">Custom 4 to be searched</param>
        /// <param name="custom5">Custom 5 to be searched</param>
        /// <param name="custom6">Custom 6 to be searched</param>
        /// <param name="custom7">Custom 7 to be searched</param>
        /// <param name="custom8">Custom 8 to be searched</param>
        /// <param name="custom9">Custom 9 to be searched</param>
        /// <param name="postalCode">Postal Code to be searched</param>
        /// <param name="searchType">Valid Options - exact, begins, contains and ends - Applies for the entire given search parameters. The default value if not sent is exact.</param>
        /// <param name="sortBy">Field you need to the results to be sorted by. Vendor Name will be made default if no value is sent. Only fields that are added to the vendor form can be used here. Fields have to be specified by name as specified in Doc.</param>
        /// <param name="sortDirection">ascending or descending, The default value will be ascending.</param>
        /// <param name="state">State to be searched</param>
        /// <param name="taxID">Tax ID to be searched</param>
        /// <param name="vendorCode">Vendor Code to be searched</param>
        /// <param name="vendorName">Vendor Name to be searched</param>
        /// <param name="limit">The maximum number of items to be returned in a  response. The default is 25 and cannot exceed 1000.</param>
        /// <param name="offset">Specifies the starting point for the next query when iterating through the collection response.  Use with paged collections of resources.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<VendorCollection> GetInvoiceVendorsAsync(string address1 = null, string address2 = null, string address3 = null, string addressCode = null, string approved = null, string buyerAccountNumber = null, string city = null, string country = null, string custom1 = null, string custom10 = null, string custom11 = null, string custom12 = null, string custom13 = null, string custom14 = null, string custom15 = null, string custom16 = null, string custom17 = null, string custom18 = null, string custom19 = null, string custom2 = null, string custom20 = null, string custom3 = null, string custom4 = null, string custom5 = null, string custom6 = null, string custom7 = null, string custom8 = null, string custom9 = null, string postalCode = null, string searchType = null, string sortBy = null, string sortDirection = null, string state = null, string taxID = null, string vendorCode = null, string vendorName = null, Int32? limit = null, string offset = null, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/invoice/vendors";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("address1", address1)
                ,new KeyValuePair<string,object>("address2", address2)
                ,new KeyValuePair<string,object>("address3", address3)
                ,new KeyValuePair<string,object>("addressCode", addressCode)
                ,new KeyValuePair<string,object>("approved", approved)
                ,new KeyValuePair<string,object>("buyerAccountNumber", buyerAccountNumber)
                ,new KeyValuePair<string,object>("city", city)
                ,new KeyValuePair<string,object>("country", country)
                ,new KeyValuePair<string,object>("custom1", custom1)
                ,new KeyValuePair<string,object>("custom10", custom10)
                ,new KeyValuePair<string,object>("custom11", custom11)
                ,new KeyValuePair<string,object>("custom12", custom12)
                ,new KeyValuePair<string,object>("custom13", custom13)
                ,new KeyValuePair<string,object>("custom14", custom14)
                ,new KeyValuePair<string,object>("custom15", custom15)
                ,new KeyValuePair<string,object>("custom16", custom16)
                ,new KeyValuePair<string,object>("custom17", custom17)
                ,new KeyValuePair<string,object>("custom18", custom18)
                ,new KeyValuePair<string,object>("custom19", custom19)
                ,new KeyValuePair<string,object>("custom2", custom2)
                ,new KeyValuePair<string,object>("custom20", custom20)
                ,new KeyValuePair<string,object>("custom3", custom3)
                ,new KeyValuePair<string,object>("custom4", custom4)
                ,new KeyValuePair<string,object>("custom5", custom5)
                ,new KeyValuePair<string,object>("custom6", custom6)
                ,new KeyValuePair<string,object>("custom7", custom7)
                ,new KeyValuePair<string,object>("custom8", custom8)
                ,new KeyValuePair<string,object>("custom9", custom9)
                ,new KeyValuePair<string,object>("postalCode", postalCode)
                ,new KeyValuePair<string,object>("searchType", searchType)
                ,new KeyValuePair<string,object>("sortBy", sortBy)
                ,new KeyValuePair<string,object>("sortDirection", sortDirection)
                ,new KeyValuePair<string,object>("state", state)
                ,new KeyValuePair<string,object>("taxID", taxID)
                ,new KeyValuePair<string,object>("vendorCode", vendorCode)
                ,new KeyValuePair<string,object>("vendorName", vendorName)
                ,new KeyValuePair<string,object>("limit", limit)
                ,new KeyValuePair<string,object>("offset", offset)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<VendorCollection>(
                "GET",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Create vendor/s and returns the status of creation.
        /// </summary>
        /// <param name="vendors">The vendor details.</param>
        public VendorCollection CreateInvoiceVendors(VendorCollection vendors)
        {
            string remoteServiceRelativeUrl = @"/invoice/vendors";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<VendorCollection>(
                "POST",
                requestUrl,
                vendors,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Create vendor/s and returns the status of creation.
        /// </summary>
        /// <param name="vendors">The vendor details.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<VendorCollection> CreateInvoiceVendorsAsync(VendorCollection vendors, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/invoice/vendors";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<VendorCollection>(
                "POST",
                requestUrl,
                vendors,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates existing vendor/s and returns the status of creation.
        /// </summary>
        /// <param name="vendors">The vendor details.</param>
        public VendorCollection UpdateInvoiceVendors(VendorCollection vendors)
        {
            string remoteServiceRelativeUrl = @"/invoice/vendors";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<VendorCollection>(
                "PUT",
                requestUrl,
                vendors,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Updates existing vendor/s and returns the status of creation.
        /// </summary>
        /// <param name="vendors">The vendor details.</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<VendorCollection> UpdateInvoiceVendorsAsync(VendorCollection vendors, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/invoice/vendors";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<VendorCollection>(
                "PUT",
                requestUrl,
                vendors,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete a vendor by Vendor Code and Address Code.
        /// </summary>
        /// <param name="addressCode">Address Code to be deleted</param>
        /// <param name="vendorCode">Vendor Code to be deleted</param>
        public VendorCollection DeleteInvoiceVendorsByVendorCodeByAddressCode(string addressCode, string vendorCode)
        {
            string remoteServiceRelativeUrl = @"/invoice/vendors";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("addressCode", addressCode)
                ,new KeyValuePair<string,object>("vendorCode", vendorCode)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return this.Util.SendHttpRequest<VendorCollection>(
                "DELETE",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Delete a vendor by Vendor Code and Address Code.
        /// </summary>
        /// <param name="addressCode">Address Code to be deleted</param>
        /// <param name="vendorCode">Vendor Code to be deleted</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task.</param>
        public async Task<VendorCollection> DeleteInvoiceVendorsByVendorCodeByAddressCodeAsync(string addressCode, string vendorCode, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/invoice/vendors";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("addressCode", addressCode)
                ,new KeyValuePair<string,object>("vendorCode", vendorCode)

            };
            var pathParameters = new KeyValuePair<string, object>[] { };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            return await this.Util.SendHttpRequestAsync<VendorCollection>(
                "DELETE",
                requestUrl,
                null,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken).ConfigureAwait(false);
        }
    }



    namespace Serializable
    {
        /// <summary>
        /// Allocations
        /// </summary>
        [XmlRoot("Allocations")]
        public class AllocationCollection
        {

            /// <summary>
            /// The result collection.
            /// </summary>
            [XmlArrayItem("Allocation")]
            public AllocationGet[] Items { get; set; }

            /// <summary>
            /// The URI of the next page of results, if any.
            /// </summary>
            public string NextPage { get; set; }

            /// <summary>
            /// The offset value to be used when iterating to get the next page of objects.
            /// </summary>
            public virtual string NextPageOffset() { return this.Util.GetQueryStringValue(NextPage, "offset"); }

            /// <summary>
            /// The flag used to indicate whether the current page of objects is the last one in the sequence.
            /// </summary>
            public virtual bool IsEndOfPagination() { return string.IsNullOrWhiteSpace(NextPageOffset()); }

            protected ConcurUtil Util = new ConcurUtil();
        }

        /// <summary>
        /// Allocation
        /// </summary>
        [XmlRoot("Allocation")]
        public class AllocationGet
        {

            /// <summary>
            /// The primary accounting code assigned to the expense type associated with this allocation. Typically, expense types have only a primary account code.
            /// </summary>
            public string AccountCode1 { get; set; }

            /// <summary>
            /// The secondary or alternative  accounting code assigned to the expense type associated with this allocation.
            /// </summary>
            public string AccountCode2 { get; set; }

            /// <summary>
            /// A custom field associated with the allocation. This field may or may not have data, depending on how Expense is configured. Text field. The maximum lenght is 64 characters.
            /// </summary>
            public CustomField Custom1 { get; set; }

            /// <summary>
            /// A custom field associated with the allocation. This field may or may not have data, depending on how Expense is configured. Text field. The maximum lenght is 64 characters.
            /// </summary>
            public CustomField Custom10 { get; set; }

            /// <summary>
            /// A custom field associated with the allocation. This field may or may not have data, depending on how Expense is configured. Text field. The maximum lenght is 64 characters.
            /// </summary>
            public CustomField Custom11 { get; set; }

            /// <summary>
            /// A custom field associated with the allocation. This field may or may not have data, depending on how Expense is configured. Text field. The maximum lenght is 64 characters.
            /// </summary>
            public CustomField Custom12 { get; set; }

            /// <summary>
            /// A custom field associated with the allocation. This field may or may not have data, depending on how Expense is configured. Text field. The maximum lenght is 64 characters.
            /// </summary>
            public CustomField Custom13 { get; set; }

            /// <summary>
            /// A custom field associated with the allocation. This field may or may not have data, depending on how Expense is configured. Text field. The maximum lenght is 64 characters.
            /// </summary>
            public CustomField Custom14 { get; set; }

            /// <summary>
            /// A custom field associated with the allocation. This field may or may not have data, depending on how Expense is configured. Text field. The maximum lenght is 64 characters.
            /// </summary>
            public CustomField Custom15 { get; set; }

            /// <summary>
            /// A custom field associated with the allocation. This field may or may not have data, depending on how Expense is configured. Text field. The maximum lenght is 64 characters.
            /// </summary>
            public CustomField Custom16 { get; set; }

            /// <summary>
            /// A custom field associated with the allocation. This field may or may not have data, depending on how Expense is configured. Text field. The maximum lenght is 64 characters.
            /// </summary>
            public CustomField Custom17 { get; set; }

            /// <summary>
            /// A custom field associated with the allocation. This field may or may not have data, depending on how Expense is configured. Text field. The maximum lenght is 64 characters.
            /// </summary>
            public CustomField Custom18 { get; set; }

            /// <summary>
            /// A custom field associated with the allocation. This field may or may not have data, depending on how Expense is configured. Text field. The maximum lenght is 64 characters.
            /// </summary>
            public CustomField Custom19 { get; set; }

            /// <summary>
            /// A custom field associated with the allocation. This field may or may not have data, depending on how Expense is configured. Text field. The maximum lenght is 64 characters.
            /// </summary>
            public CustomField Custom2 { get; set; }

            /// <summary>
            /// A custom field associated with the allocation. This field may or may not have data, depending on how Expense is configured. Text field. The maximum lenght is 64 characters.
            /// </summary>
            public CustomField Custom20 { get; set; }

            /// <summary>
            /// A custom field associated with the allocation. This field may or may not have data, depending on how Expense is configured. Text field. The maximum lenght is 64 characters.
            /// </summary>
            public CustomField Custom3 { get; set; }

            /// <summary>
            /// A custom field associated with the allocation. This field may or may not have data, depending on how Expense is configured. Text field. The maximum lenght is 64 characters.
            /// </summary>
            public CustomField Custom4 { get; set; }

            /// <summary>
            /// A custom field associated with the allocation. This field may or may not have data, depending on how Expense is configured. Text field. The maximum lenght is 64 characters.
            /// </summary>
            public CustomField Custom5 { get; set; }

            /// <summary>
            /// A custom field associated with the allocation. This field may or may not have data, depending on how Expense is configured. Text field. The maximum lenght is 64 characters.
            /// </summary>
            public CustomField Custom6 { get; set; }

            /// <summary>
            /// A custom field associated with the allocation. This field may or may not have data, depending on how Expense is configured. Text field. The maximum lenght is 64 characters.
            /// </summary>
            public CustomField Custom7 { get; set; }

            /// <summary>
            /// A custom field associated with the allocation. This field may or may not have data, depending on how Expense is configured. Text field. The maximum lenght is 64 characters.
            /// </summary>
            public CustomField Custom8 { get; set; }

            /// <summary>
            /// A custom field associated with the allocation. This field may or may not have data, depending on how Expense is configured. Text field. The maximum lenght is 64 characters.
            /// </summary>
            public CustomField Custom9 { get; set; }

            /// <summary>
            /// The unique identifier for the expense entry.
            /// </summary>
            public string EntryID { get; set; }

            /// <summary>
            /// The unique identifier of the resource.
            /// </summary>
            public string ID { get; set; }

            /// <summary>
            /// Indicates whether the allocation is hidden. The possible values are True or False.
            /// </summary>
            public bool? IsHidden { get; set; }

            /// <summary>
            /// Indicates whether the percentage has been edited. The possible values are True or False.
            /// </summary>
            public bool? IsPercentEdited { get; set; }

            /// <summary>
            /// The percentage of the expense that is included in this allocation.
            /// </summary>
            public string Percentage { get; set; }

            /// <summary>
            /// The URI to the resource.
            /// </summary>
            public string URI { get; set; }
        }


        [XmlRoot("CustomField")]
        public class CustomField
        {

            /// <summary>
            /// For list fields this is the list item code.
            /// </summary>
            public string Code { get; set; }

            /// <summary>
            /// For list fields, this is the list item ID.
            /// </summary>
            public string ListItemID { get; set; }

            /// <summary>
            /// The custom field type. Will be one of the following: Amount, Boolean, ConnectedList, Date, Integer, List, Number, Text.
            /// </summary>
            public string Type { get; set; }

            /// <summary>
            /// The value in the org unit or custom field. For list fields this is the name of the list item.  Maximum 48 characters.
            /// </summary>
            public string Value { get; set; }
        }

        /// <summary>
        /// Attendees
        /// </summary>
        [XmlRoot("Attendees")]
        public class AttendeeCollection
        {

            /// <summary>
            /// The result collection.
            /// </summary>
            [XmlArrayItem("Attendee")]
            public AttendeeGet[] Items { get; set; }

            /// <summary>
            /// The URI of the next page of results, if any.
            /// </summary>
            public string NextPage { get; set; }

            /// <summary>
            /// The offset value to be used when iterating to get the next page of objects.
            /// </summary>
            public virtual string NextPageOffset() { return this.Util.GetQueryStringValue(NextPage, "offset"); }

            /// <summary>
            /// The flag used to indicate whether the current page of objects is the last one in the sequence.
            /// </summary>
            public virtual bool IsEndOfPagination() { return string.IsNullOrWhiteSpace(NextPageOffset()); }

            protected ConcurUtil Util = new ConcurUtil();
        }

        /// <summary>
        /// Attendee
        /// </summary>
        [XmlRoot("Attendee")]
        public class AttendeeGet
        {

            /// <summary>
            /// The type of attendee. Maximum 40 characters.
            /// </summary>
            public string AttendeeTypeCode { get; set; }

            /// <summary>
            /// The unique identifier for the attendee type.
            /// </summary>
            public string AttendeeTypeID { get; set; }

            /// <summary>
            /// The attendee's company name. Maximum 150 characters.
            /// </summary>
            public string Company { get; set; }

            /// <summary>
            /// The <a target="_blank" href="http://en.wikipedia.org/wiki/ISO_4217">3-letter ISO 4217 currency code</a> for attendee-related amounts.
            /// </summary>
            public string CurrencyCode { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom1 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom10 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom11 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom12 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom13 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom14 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom15 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom16 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom17 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom18 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom19 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom2 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom20 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom21 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom22 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom23 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom24 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom25 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom3 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom4 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom5 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom6 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom7 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom8 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom9 { get; set; }

            /// <summary>
            /// The unique identifier for the attendee managed outside Concur. Maximum 48 characters.
            /// </summary>
            public string ExternalID { get; set; }

            /// <summary>
            /// The attendee's first name. Maximum 50 characters.
            /// </summary>
            public string FirstName { get; set; }

            /// <summary>
            /// Determines if the attendee has exceptions in the previous year, based on yearly total limits for attendees. Format: true or false
            /// </summary>
            public bool? HasExceptionsPrevYear { get; set; }

            /// <summary>
            /// Determines if the attendee has exceptions in the current year, based on yearly total limits for attendees.  Format: true or false
            /// </summary>
            public bool? HasExceptionsYTD { get; set; }

            /// <summary>
            /// The unique identifier of the resource.
            /// </summary>
            public string ID { get; set; }

            /// <summary>
            /// The attendee's last name. Maximum 132 characters.
            /// </summary>
            public string LastName { get; set; }

            /// <summary>
            /// The attendee's middle initial. Maximum 1 character.
            /// </summary>
            public string MiddleInitial { get; set; }

            /// <summary>
            /// The login ID of the employee who owns the attendee record.
            /// </summary>
            public string OwnerLoginID { get; set; }

            /// <summary>
            /// The name of the employee who owns the attendee record.
            /// </summary>
            public string OwnerName { get; set; }

            /// <summary>
            /// The attendee's name suffix. Maximum 32 characters.
            /// </summary>
            public string Suffix { get; set; }

            /// <summary>
            /// The attendee's title. Maximum 32 characters.
            /// </summary>
            public string Title { get; set; }

            /// <summary>
            /// The total amount spent on the attendee in the previous calendar year.
            /// </summary>
            public decimal? TotalAmountPrevYear { get; set; }

            /// <summary>
            /// The total amount spent on the attendee in the current calendar year.
            /// </summary>
            public decimal? TotalAmountYTD { get; set; }

            /// <summary>
            /// The URI to the resource.
            /// </summary>
            public string URI { get; set; }

            /// <summary>
            /// The attendee's version number.
            /// </summary>
            public Int32? VersionNumber { get; set; }
        }

        /// <summary>
        /// Attendee
        /// </summary>
        [XmlRoot("Attendee")]
        public class AttendeePost
        {

            /// <summary>
            /// The unique identifier for the attendee type.
            /// </summary>
            public string AttendeeTypeID { get; set; }

            /// <summary>
            /// The attendee's company name. Maximum 150 characters.
            /// </summary>
            public string Company { get; set; }

            /// <summary>
            /// The <a target="_blank" href="http://en.wikipedia.org/wiki/ISO_4217">3-letter ISO 4217 currency code</a> for attendee-related amounts.
            /// </summary>
            public string CurrencyCode { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom1 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom10 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom11 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom12 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom13 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom14 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom15 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom16 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom17 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom18 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom19 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom2 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom20 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom21 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom22 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom23 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom24 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom25 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom3 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom4 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom5 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom6 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom7 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom8 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom9 { get; set; }

            /// <summary>
            /// The unique identifier for the attendee managed outside Concur. Maximum 48 characters.
            /// </summary>
            public string ExternalID { get; set; }

            /// <summary>
            /// The attendee's first name. Maximum 50 characters.
            /// </summary>
            public string FirstName { get; set; }

            /// <summary>
            /// The attendee's last name. Maximum 132 characters.
            /// </summary>
            public string LastName { get; set; }

            /// <summary>
            /// The attendee's middle initial. Maximum 1 character.
            /// </summary>
            public string MiddleInitial { get; set; }

            /// <summary>
            /// The attendee's name suffix. Maximum 32 characters.
            /// </summary>
            public string Suffix { get; set; }

            /// <summary>
            /// The attendee's title. Maximum 32 characters.
            /// </summary>
            public string Title { get; set; }

            /// <summary>
            /// The total amount spent on the attendee in the current calendar year.
            /// </summary>
            public decimal? TotalAmountYTD { get; set; }
        }

        /// <summary>
        /// Attendee
        /// </summary>
        [XmlRoot("Attendee")]
        public class AttendeePut
        {

            /// <summary>
            /// The unique identifier for the attendee type.
            /// </summary>
            public string AttendeeTypeID { get; set; }

            /// <summary>
            /// The attendee's company name. Maximum 150 characters.
            /// </summary>
            public string Company { get; set; }

            /// <summary>
            /// The <a target="_blank" href="http://en.wikipedia.org/wiki/ISO_4217">3-letter ISO 4217 currency code</a> for attendee-related amounts.
            /// </summary>
            public string CurrencyCode { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom1 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom10 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom11 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom12 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom13 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom14 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom15 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom16 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom17 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom18 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom19 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom2 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom20 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom21 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom22 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom23 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom24 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom25 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom3 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom4 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom5 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom6 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom7 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom8 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom9 { get; set; }

            /// <summary>
            /// The unique identifier for the attendee managed outside Concur. Maximum 48 characters.
            /// </summary>
            public string ExternalID { get; set; }

            /// <summary>
            /// The attendee's first name. Maximum 50 characters.
            /// </summary>
            public string FirstName { get; set; }

            /// <summary>
            /// The attendee's last name. Maximum 132 characters.
            /// </summary>
            public string LastName { get; set; }

            /// <summary>
            /// The attendee's middle initial. Maximum 1 character.
            /// </summary>
            public string MiddleInitial { get; set; }

            /// <summary>
            /// The attendee's name suffix. Maximum 32 characters.
            /// </summary>
            public string Suffix { get; set; }

            /// <summary>
            /// The attendee's title. Maximum 32 characters.
            /// </summary>
            public string Title { get; set; }

            /// <summary>
            /// The total amount spent on the attendee in the current calendar year.
            /// </summary>
            public decimal? TotalAmountYTD { get; set; }
        }

        /// <summary>
        /// Response
        /// </summary>
        [XmlRoot("Response")]
        public class CreateResponse
        {

            public string ID { get; set; }

            public string URI { get; set; }
        }


        [XmlRoot("Decimal")]
        public class Decimal
        {
        }

        /// <summary>
        /// AttendeeType
        /// </summary>
        [XmlRoot("AttendeeType")]
        public class AttendeeTypeGet
        {

            /// <summary>
            /// Determines users are allowed to edit the count for this attendee type. Format: true or false.
            /// </summary>
            public bool AllowAttendeeCountEditing { get; set; }

            /// <summary>
            /// Determines if users are allowed to add attendees for this attendee type. Format: true or false.
            /// </summary>
            public bool AllowManuallyEnteredAttendees { get; set; }

            /// <summary>
            /// The unique identifier for the attendee form for this attendee type.
            /// </summary>
            public string AttendeeFormID { get; set; }

            /// <summary>
            /// The type of attendee. Maximum 40 characters.
            /// </summary>
            public string Code { get; set; }

            /// <summary>
            /// The unique identifier for the Application Connector that is the data source for this attendee type. When empty the Expense database is the data source.
            /// </summary>
            public string ConnectorID { get; set; }

            /// <summary>
            /// The list of Attendee Field IDs used by the Add Attendee user interface to alert users that the attendee they want to add is a possible duplicate, attendees in the Expense database. This parent element has a DuplicateSearchField child element for each Field ID.
            /// </summary>
            [XmlArrayItem("DuplicateSearchField")]
            public string[] DuplicateSearchFields { get; set; }

            /// <summary>
            /// The unique identifier of the resource.
            /// </summary>
            public string ID { get; set; }

            /// <summary>
            /// The name for the attendee type. This must be unique and can have a maximum of 40 characters.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// The URI to the resource.
            /// </summary>
            public string URI { get; set; }
        }

        /// <summary>
        /// AttendeeType
        /// </summary>
        [XmlRoot("AttendeeType")]
        public class AttendeeTypePost
        {

            /// <summary>
            /// Determines users are allowed to edit the count for this attendee type. Format: true or false.
            /// </summary>
            public bool? AllowAttendeeCountEditing { get; set; }

            /// <summary>
            /// Determines if users are allowed to add attendees for this attendee type. Format: true or false.
            /// </summary>
            public bool? AllowManuallyEnteredAttendees { get; set; }

            /// <summary>
            /// The unique identifier for the attendee form for this attendee type.
            /// </summary>
            public string AttendeeFormID { get; set; }

            /// <summary>
            /// The type of attendee. Maximum 40 characters.
            /// </summary>
            public string Code { get; set; }

            /// <summary>
            /// The unique identifier for the Application Connector that is the data source for this attendee type. When empty the Expense database is the data source.
            /// </summary>
            public string ConnectorID { get; set; }

            /// <summary>
            /// The list of Attendee Field IDs used by the Add Attendee user interface to alert users that the attendee they want to add is a possible duplicate, attendees in the Expense database. This parent element has a DuplicateSearchField child element for each Field ID.
            /// </summary>
            [XmlArrayItem("DuplicateSearchField")]
            public string[] DuplicateSearchFields { get; set; }

            /// <summary>
            /// The name for the attendee type. This must be unique and can have a maximum of 40 characters.
            /// </summary>
            public string Name { get; set; }
        }

        /// <summary>
        /// AttendeeType
        /// </summary>
        [XmlRoot("AttendeeType")]
        public class AttendeeTypePut
        {

            /// <summary>
            /// Determines users are allowed to edit the count for this attendee type. Format: true or false.
            /// </summary>
            public bool? AllowAttendeeCountEditing { get; set; }

            /// <summary>
            /// Determines if users are allowed to add attendees for this attendee type. Format: true or false.
            /// </summary>
            public bool? AllowManuallyEnteredAttendees { get; set; }

            /// <summary>
            /// The unique identifier for the attendee form for this attendee type.
            /// </summary>
            public string AttendeeFormID { get; set; }

            /// <summary>
            /// The type of attendee. Maximum 40 characters.
            /// </summary>
            public string Code { get; set; }

            /// <summary>
            /// The unique identifier for the Application Connector that is the data source for this attendee type. When empty the Expense database is the data source.
            /// </summary>
            public string ConnectorID { get; set; }

            /// <summary>
            /// The list of Attendee Field IDs used by the Add Attendee user interface to alert users that the attendee they want to add is a possible duplicate, attendees in the Expense database. This parent element has a DuplicateSearchField child element for each Field ID.
            /// </summary>
            [XmlArrayItem("DuplicateSearchField")]
            public string[] DuplicateSearchFields { get; set; }

            /// <summary>
            /// The name for the attendee type. This must be unique and can have a maximum of 40 characters.
            /// </summary>
            public string Name { get; set; }
        }

        /// <summary>
        /// AttendeeTypes
        /// </summary>
        [XmlRoot("AttendeeTypes")]
        public class AttendeeTypesCollection
        {

            /// <summary>
            /// The result collection.
            /// </summary>
            [XmlArrayItem("AttendeeType")]
            public AttendeeTypeGet[] Items { get; set; }

            /// <summary>
            /// The URI of the next page of results, if any.
            /// </summary>
            public string NextPage { get; set; }

            /// <summary>
            /// The offset value to be used when iterating to get the next page of objects.
            /// </summary>
            public virtual string NextPageOffset() { return this.Util.GetQueryStringValue(NextPage, "offset"); }

            /// <summary>
            /// The flag used to indicate whether the current page of objects is the last one in the sequence.
            /// </summary>
            public virtual bool IsEndOfPagination() { return string.IsNullOrWhiteSpace(NextPageOffset()); }

            protected ConcurUtil Util = new ConcurUtil();
        }

        /// <summary>
        /// ConnectionRequests
        /// </summary>
        [XmlRoot("ConnectionRequests")]
        public class ConnectionRequestCollection
        {

            /// <summary>
            /// The result collection.
            /// </summary>
            [XmlArrayItem("ConnectionRequest")]
            public ConnectionRequestGet[] Items { get; set; }

            /// <summary>
            /// The URI of the next page of results, if any.
            /// </summary>
            public string NextPage { get; set; }

            /// <summary>
            /// The offset value to be used when iterating to get the next page of objects.
            /// </summary>
            public virtual string NextPageOffset() { return this.Util.GetQueryStringValue(NextPage, "offset"); }

            /// <summary>
            /// The flag used to indicate whether the current page of objects is the last one in the sequence.
            /// </summary>
            public virtual bool IsEndOfPagination() { return string.IsNullOrWhiteSpace(NextPageOffset()); }

            protected ConcurUtil Util = new ConcurUtil();
        }

        /// <summary>
        /// ConnectionRequest
        /// </summary>
        [XmlRoot("ConnectionRequest")]
        public class ConnectionRequestGet
        {

            /// <summary>
            /// The user's first name.
            /// </summary>
            public string FirstName { get; set; }

            /// <summary>
            /// The unique identifier of the resource.
            /// </summary>
            public string ID { get; set; }

            /// <summary>
            /// The date and time when the connection request was last modified. Format: UTC
            /// </summary>
            public string LastModified { get; set; }

            /// <summary>
            /// The user's last name.
            /// </summary>
            public string LastName { get; set; }

            /// <summary>
            /// The user's travel loyalty number.
            /// </summary>
            public string LoyaltyNumber { get; set; }

            /// <summary>
            /// The user's middle name.
            /// </summary>
            public string MiddleName { get; set; }

            /// <summary>
            /// The OAuth request token.
            /// </summary>
            public string RequestToken { get; set; }

            /// <summary>
            /// The status code representing the state of the connection request.
            /// </summary>
            public string Status { get; set; }

            /// <summary>
            /// The URI to the resource.
            /// </summary>
            public string URI { get; set; }
        }

        /// <summary>
        /// ConnectionRequest
        /// </summary>
        [XmlRoot("ConnectionRequest")]
        public class ConnectionRequestPut
        {

            /// <summary>
            /// The status code representing the state of the connection request. The possible values are: <br /><br /> CRSUC - Supplier indicated that the connection was made successfully <br /> CREU1 - Loyalty number was not found <br /> CREU2 - Loyalty number doesn't match the name <br /> CREU3 - Your loyalty account requires attention <br /> CRPA1 - Request token has expired <br /> CRPA2 - Network error occurred <br /> CRRET - Retry connection
            /// </summary>
            public string Status { get; set; }
        }

        /// <summary>
        /// DigitalTaxInvoices
        /// </summary>
        [XmlRoot("DigitalTaxInvoices")]
        public class DigitalTaxInvoiceCollection
        {

            /// <summary>
            /// The result collection.
            /// </summary>
            [XmlArrayItem("DigitalTaxInvoice")]
            public DigitalTaxInvoiceGetAll[] Items { get; set; }

            /// <summary>
            /// The URI of the next page of results, if any.
            /// </summary>
            public string NextPage { get; set; }

            /// <summary>
            /// The offset value to be used when iterating to get the next page of objects.
            /// </summary>
            public virtual string NextPageOffset() { return this.Util.GetQueryStringValue(NextPage, "offset"); }

            /// <summary>
            /// The flag used to indicate whether the current page of objects is the last one in the sequence.
            /// </summary>
            public virtual bool IsEndOfPagination() { return string.IsNullOrWhiteSpace(NextPageOffset()); }

            protected ConcurUtil Util = new ConcurUtil();
        }

        /// <summary>
        /// DigitalTaxInvoice
        /// </summary>
        [XmlRoot("DigitalTaxInvoice")]
        public class DigitalTaxInvoiceGetAll
        {

            /// <summary>
            /// The unique identifier of the resource.
            /// </summary>
            public string ID { get; set; }

            /// <summary>
            /// The URI to the resource.
            /// </summary>
            public string URI { get; set; }
        }

        /// <summary>
        /// DigitalTaxInvoice
        /// </summary>
        [XmlRoot("DigitalTaxInvoice")]
        public class DigitalTaxInvoiceGetSingle
        {

            /// <summary>
            /// The unique identifier for the Concur company
            /// </summary>
            public string AccountID { get; set; }

            /// <summary>
            /// Digital Tax Invoice Data
            /// </summary>
            public string ReceiptData { get; set; }
        }

        /// <summary>
        /// DigitalTaxInvoice
        /// </summary>
        [XmlRoot("DigitalTaxInvoice")]
        public class DigitalTaxInvoicePut
        {

            /// <summary>
            /// A comment that describes the digital tax invoice status. Max Length: 2000
            /// </summary>
            public string Comment { get; set; }

            /// <summary>
            /// A status that describes the digital tax invoice. FORMAT: VALID - Valid ;INVLD - invalid;WARNG - Valid with warnings 
            /// </summary>
            public string Status { get; set; }
        }

        /// <summary>
        /// Entries
        /// </summary>
        [XmlRoot("Entries")]
        public class EntryCollection
        {

            /// <summary>
            /// The result collection.
            /// </summary>
            [XmlArrayItem("Entry")]
            public EntryGet[] Items { get; set; }

            /// <summary>
            /// The URI of the next page of results, if any.
            /// </summary>
            public string NextPage { get; set; }

            /// <summary>
            /// The offset value to be used when iterating to get the next page of objects.
            /// </summary>
            public virtual string NextPageOffset() { return this.Util.GetQueryStringValue(NextPage, "offset"); }

            /// <summary>
            /// The flag used to indicate whether the current page of objects is the last one in the sequence.
            /// </summary>
            public virtual bool IsEndOfPagination() { return string.IsNullOrWhiteSpace(NextPageOffset()); }

            protected ConcurUtil Util = new ConcurUtil();
        }

        /// <summary>
        /// Entry
        /// </summary>
        [XmlRoot("Entry")]
        public class EntryGet
        {

            /// <summary>
            /// Defines the type of allocations for the expense. Possible values are: P, for partial allocation, F, for full allocation, or N, for no allocation.  Use GET ExpenseEntryAllocations to get information about this entry's allocations.
            /// </summary>
            public string AllocationType { get; set; }

            /// <summary>
            /// The approved amount of the entry in the report currency.
            /// </summary>
            public decimal? ApprovedAmount { get; set; }

            /// <summary>
            /// When there is a company card transaction associated to this expense this is its unique identifier.  Concur Expense uses the Credit Card Import job to import this company card transactions.  Use GET CommpanyCardTransactions to get information about this card transaction. Null when there is no company card transaction associated
            /// </summary>
            public string CompanyCardTransactionID { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom1 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom10 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom11 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom12 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom13 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom14 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom15 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom16 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom17 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom18 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom19 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom2 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom20 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom21 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom22 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom23 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom24 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom25 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom26 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom27 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom28 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom29 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom3 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom30 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom31 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom32 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom33 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom34 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom35 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom36 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom37 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom38 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom39 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom4 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom40 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom5 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom6 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom7 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom8 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom9 { get; set; }

            /// <summary>
            /// The description of the expense. Max length: 64.
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// When there is an eReceipt associated to this expense this is its unique identifier.  Use GET eReceipts to get information about this eReceipt. Null when there is no eReceipt associated to this expense.
            /// </summary>
            public string ElectronicReceiptID { get; set; }

            /// <summary>
            /// When there is an employee bank account associated to this expense this is its unique identifier.  Typically, this is when Expense Pay reimburses the employee for this expense.  Use the GET BankAccounts to get information about this bank account.
            /// </summary>
            public string EmployeeBankAccountID { get; set; }

            /// <summary>
            /// The currency conversion rate that converts the Transaction Amount that is in Transaction Currency into the Posted Amount that is in Report Currency. This element is typically not provided. If this element is empty for transactions in a currency different than the user's reimbursement currency, Expense will use the company's configured exchange rates to determine the posted amount for the transaction. If the system is not able to determine the exchange rate, a value of 1.0 will be used.
            /// </summary>
            public decimal? ExchangeRate { get; set; }

            /// <summary>
            /// The code for the expense type. Use GET Expense Group Configurations to learn the expense type code for expense types active for this report's policy.
            /// </summary>
            public string ExpenseTypeCode { get; set; }

            /// <summary>
            /// The name of the expense type localized to the OAuth Consumer's language.
            /// </summary>
            public string ExpenseTypeName { get; set; }

            /// <summary>
            /// The ID of the form used by this expense entry.
            /// </summary>
            public string FormID { get; set; }

            /// <summary>
            /// Whether the entry has a cash advance applied to it. Use GET ExpenseEntryAccountingCalculations to get cash advance application information for this entry. Format true or false
            /// </summary>
            public bool? HasAppliedCashAdvance { get; set; }

            /// <summary>
            /// Whether the expense has attendees.  Use GET ExpenseEntryAttendees to get information about this entry's attendees. Format true or false
            /// </summary>
            public bool? HasAttendees { get; set; }

            /// <summary>
            /// Whether the expense has comments.  Use GET ExpenseEntryComments to get information about this entry's comments. Format true or false
            /// </summary>
            public bool? HasComments { get; set; }

            /// <summary>
            /// Whether the expense has exceptions.  Use GET ExpenseEntryExceptions to get information about this entry's exceptions. Format true or false
            /// </summary>
            public bool? HasExceptions { get; set; }

            /// <summary>
            /// Whether there is an entry image attached to the entry.  Use the GET Entry Images API to get this entry image. Format true or false
            /// </summary>
            public bool? HasImage { get; set; }

            /// <summary>
            /// Whether the expense has itemizations.  Use GET ExpenseEntryItemizations to get information about this entry's itemizations. Format true or false
            /// </summary>
            public bool? HasItemizations { get; set; }

            /// <summary>
            /// Whether the entry has VAT data. Use GET ExpenseEntryAccountingCalculations to get VAT information for this entry. Format true or false
            /// </summary>
            public bool? HasVAT { get; set; }

            /// <summary>
            /// The unique identifier of the resource.
            /// </summary>
            public string ID { get; set; }

            /// <summary>
            /// Determines if the expense is billable or not. Format: true or false.
            /// </summary>
            public bool? IsBillable { get; set; }

            /// <summary>
            /// Whether an entry image is required for the entry. Format true or false
            /// </summary>
            public bool? IsImageRequired { get; set; }

            /// <summary>
            /// Whether the entry is paid using the Expense Pay service. This element has a value if the report has reached the Processing Payment workflow step because this is when Concur Expense determines whether it will be paid by Expense Pay. Format: true or false
            /// </summary>
            public bool? IsPaidByExpensePay { get; set; }

            /// <summary>
            /// Determines if the expense is personal or non-reimbursable. Format: true or false.
            /// </summary>
            public bool? IsPersonal { get; set; }

            /// <summary>
            /// Whether the expense entry was imported from a personal card feed.  Concur Expense uses the Yodlee API to import these card transactions. Format true or false.
            /// </summary>
            public bool? IsPersonalCardCharge { get; set; }

            /// <summary>
            /// This element contains journey data when this entry is a mileage expense. For expense types with an expense code that is either Company Car or Personal the Journey child element is required. This element should not be used for expense types with an expense code that is neither Company Car nor Personal Car.
            /// </summary>
            public Journey Journey { get; set; }

            /// <summary>
            /// The UTC date when the entry was last modified.
            /// </summary>
            public DateTime? LastModified { get; set; }

            /// <summary>
            /// The country where the expense was incurred. Format: 2-letter ISO 3166-1 country code.
            /// </summary>
            public string LocationCountry { get; set; }

            /// <summary>
            /// The unique identifier for location. Use the GET Locations function to get information for this location.
            /// </summary>
            public string LocationID { get; set; }

            /// <summary>
            /// The location for the expense entry, usually the city name.
            /// </summary>
            public string LocationName { get; set; }

            /// <summary>
            /// The state, province, or other country subdivision where the expense was incurred. Format: ISO 3166-2:2007 country subdivision.
            /// </summary>
            public string LocationSubdivision { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField OrgUnit1 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField OrgUnit2 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField OrgUnit3 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField OrgUnit4 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField OrgUnit5 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField OrgUnit6 { get; set; }

            /// <summary>
            /// The payment type ID for the entry. Use GET Expense Group Configurations to learn the payment type ID for payment types active for this report's expense group. For mileage expenses use the Cash payment type. For expense types with an expense code that uses a transaction amount instead of a distance this is required. This element should not be used for expense types with an expense code for Company Car or Personal Car because these two expense codes always use the Cash payment type.
            /// </summary>
            public string PaymentTypeID { get; set; }

            /// <summary>
            /// The name of the payment type localized to the OAuth Consumer's language.
            /// </summary>
            public string PaymentTypeName { get; set; }

            /// <summary>
            /// The amount of the expense entry in the report currency.
            /// </summary>
            public decimal? PostedAmount { get; set; }

            /// <summary>
            /// If true, then this entry has been marked as reviewed by a processor. Format: true or false
            /// </summary>
            public bool? ReceiptReceived { get; set; }

            /// <summary>
            /// The Report ID of the report where the entry will be added.
            /// </summary>
            public string ReportID { get; set; }

            /// <summary>
            /// The login ID for the report owner.  Use GET User Information to learn details about this user.
            /// </summary>
            public string ReportOwnerID { get; set; }

            /// <summary>
            /// The ID for the spend category specified for this expense entry.
            /// </summary>
            public string SpendCategoryCode { get; set; }

            /// <summary>
            /// The name of the spend category specified for this expense entry localized to the OAuth Consumer's language.
            /// </summary>
            public string SpendCategoryName { get; set; }

            /// <summary>
            /// Receipt type of this entry. Choices: T = tax receipt, R = regular receipt, N = no receipt
            /// </summary>
            public string TaxReceiptType { get; set; }

            /// <summary>
            /// The amount of the expense entry in the transaction currency paid to the vendor.	For expense types with an expense code that uses a transaction amount instead of a distance this is required. This element should not be used for expense types with an expense code for Company Car or Personal Car because because these two expense codes use a distance instead of a transaction amount.
            /// </summary>
            public decimal? TransactionAmount { get; set; }

            /// <summary>
            /// The <a target="_blank" href="http://en.wikipedia.org/wiki/ISO_4217">3-letter ISO 4217 currency code</a> for the expense entry transaction amount. This is the currency the vendor was paid. For expense types with an expense code that uses a transaction amount instead of a distance this is required. This element should not be used for expense types with an expense code for Company Car or Personal Car because these two expense codes the currency is always in the Report Currency.
            /// </summary>
            public string TransactionCurrencyCode { get; set; }

            /// <summary>
            /// The date when the good or service associated to this expense entry was made. Format: YYYY-MM-DD
            /// </summary>
            public DateTime? TransactionDate { get; set; }

            /// <summary>
            /// When there is a trip in the Itinerary Service that includes the travel booking associated to this expense this is the trip's unique identifier.  Use GET ItineraryDetails to get information about this trip and the travel booking. Null when there is no trip associated
            /// </summary>
            public string TripID { get; set; }

            /// <summary>
            /// The URI to the resource.
            /// </summary>
            public string URI { get; set; }

            /// <summary>
            /// The vendor name of the expense entry.  Max length: 64.
            /// </summary>
            public string VendorDescription { get; set; }

            /// <summary>
            /// The unique identifier for a vendor list item. Use the GET Lists function to get the information about this list item.
            /// </summary>
            public string VendorListItemID { get; set; }

            /// <summary>
            /// The name of the item from a vendor list.
            /// </summary>
            public string VendorListItemName { get; set; }
        }

        /// <summary>
        /// Entry
        /// </summary>
        [XmlRoot("Entry")]
        public class EntryPost
        {

            /// <summary>
            /// The expense entry comment. Max length: 500.
            /// </summary>
            public string Comment { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom1 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom10 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom11 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom12 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom13 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom14 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom15 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom16 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom17 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom18 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom19 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom2 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom20 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom21 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom22 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom23 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom24 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom25 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom26 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom27 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom28 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom29 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom3 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom30 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom31 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom32 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom33 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom34 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom35 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom36 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom37 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom38 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom39 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom4 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom40 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom5 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom6 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom7 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom8 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom9 { get; set; }

            /// <summary>
            /// The description of the expense. Max length: 64.
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// The currency conversion rate that converts the Transaction Amount that is in Transaction Currency into the Posted Amount that is in Report Currency. This element is typically not provided. If this element is empty for transactions in a currency different than the user's reimbursement currency, Expense will use the company's configured exchange rates to determine the posted amount for the transaction. If the system is not able to determine the exchange rate, a value of 1.0 will be used.
            /// </summary>
            public decimal? ExchangeRate { get; set; }

            /// <summary>
            /// The code for the expense type. Use GET Expense Group Configurations to learn the expense type code for expense types active for this report's policy.
            /// </summary>
            public string ExpenseTypeCode { get; set; }

            /// <summary>
            /// Determines if the expense is billable or not. Format: true or false.
            /// </summary>
            public bool? IsBillable { get; set; }

            /// <summary>
            /// Determines if the expense is personal or non-reimbursable. Format: true or false.
            /// </summary>
            public bool? IsPersonal { get; set; }

            /// <summary>
            /// This element contains journey data when this entry is a mileage expense. For expense types with an expense code that is either Company Car or Personal the Journey child element is required. This element should not be used for expense types with an expense code that is neither Company Car nor Personal Car.
            /// </summary>
            public Journey Journey { get; set; }

            /// <summary>
            /// The unique identifier for location. Use the GET Locations function to get information for this location.
            /// </summary>
            public string LocationID { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public string OrgUnit1 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public string OrgUnit2 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public string OrgUnit3 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public string OrgUnit4 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public string OrgUnit5 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public string OrgUnit6 { get; set; }

            /// <summary>
            /// The payment type ID for the entry. Use GET Expense Group Configurations to learn the payment type ID for payment types active for this report's expense group. For mileage expenses use the Cash payment type. For expense types with an expense code that uses a transaction amount instead of a distance this is required. This element should not be used for expense types with an expense code for Company Car or Personal Car because these two expense codes always use the Cash payment type.
            /// </summary>
            public string PaymentTypeID { get; set; }

            /// <summary>
            /// The Report ID of the report where the entry will be added.
            /// </summary>
            public string ReportID { get; set; }

            /// <summary>
            /// Receipt type of this entry. Choices: T = tax receipt, R = regular receipt, N = no receipt
            /// </summary>
            public string TaxReceiptType { get; set; }

            /// <summary>
            /// The amount of the expense entry in the transaction currency paid to the vendor.	For expense types with an expense code that uses a transaction amount instead of a distance this is required. This element should not be used for expense types with an expense code for Company Car or Personal Car because because these two expense codes use a distance instead of a transaction amount.
            /// </summary>
            public decimal? TransactionAmount { get; set; }

            /// <summary>
            /// The <a target="_blank" href="http://en.wikipedia.org/wiki/ISO_4217">3-letter ISO 4217 currency code</a> for the expense entry transaction amount. This is the currency the vendor was paid. For expense types with an expense code that uses a transaction amount instead of a distance this is required. This element should not be used for expense types with an expense code for Company Car or Personal Car because these two expense codes the currency is always in the Report Currency.
            /// </summary>
            public string TransactionCurrencyCode { get; set; }

            /// <summary>
            /// The date when the good or service associated to this expense entry was made. Format: YYYY-MM-DD
            /// </summary>
            public DateTime? TransactionDate { get; set; }

            /// <summary>
            /// The vendor name of the expense entry.  Max length: 64.
            /// </summary>
            public string VendorDescription { get; set; }

            /// <summary>
            /// The unique identifier for a vendor list item. Use the GET Lists function to get the information about this list item.
            /// </summary>
            public string VendorListItemID { get; set; }
        }

        /// <summary>
        /// Entry
        /// </summary>
        [XmlRoot("Entry")]
        public class EntryPut
        {

            /// <summary>
            /// The expense entry comment. Max length: 500.
            /// </summary>
            public string Comment { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom1 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom10 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom11 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom12 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom13 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom14 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom15 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom16 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom17 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom18 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom19 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom2 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom20 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom21 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom22 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom23 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom24 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom25 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom26 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom27 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom28 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom29 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom3 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom30 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom31 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom32 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom33 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom34 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom35 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom36 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom37 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom38 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom39 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom4 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom40 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom5 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom6 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom7 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom8 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom9 { get; set; }

            /// <summary>
            /// The description of the expense. Max length: 64.
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// The currency conversion rate that converts the Transaction Amount that is in Transaction Currency into the Posted Amount that is in Report Currency. This element is typically not provided. If this element is empty for transactions in a currency different than the user's reimbursement currency, Expense will use the company's configured exchange rates to determine the posted amount for the transaction. If the system is not able to determine the exchange rate, a value of 1.0 will be used.
            /// </summary>
            public decimal? ExchangeRate { get; set; }

            /// <summary>
            /// The code for the expense type. Use GET Expense Group Configurations to learn the expense type code for expense types active for this report's policy.
            /// </summary>
            public string ExpenseTypeCode { get; set; }

            /// <summary>
            /// Determines if the expense is billable or not. Format: true or false.
            /// </summary>
            public bool? IsBillable { get; set; }

            /// <summary>
            /// Determines if the expense is personal or non-reimbursable. Format: true or false.
            /// </summary>
            public bool? IsPersonal { get; set; }

            /// <summary>
            /// This element contains journey data when this entry is a mileage expense. For expense types with an expense code that is either Company Car or Personal the Journey child element is required. This element should not be used for expense types with an expense code that is neither Company Car nor Personal Car.
            /// </summary>
            public Journey Journey { get; set; }

            /// <summary>
            /// The unique identifier for location. Use the GET Locations function to get information for this location.
            /// </summary>
            public string LocationID { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public string OrgUnit1 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public string OrgUnit2 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public string OrgUnit3 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public string OrgUnit4 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public string OrgUnit5 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public string OrgUnit6 { get; set; }

            /// <summary>
            /// The payment type ID for the entry. Use GET Expense Group Configurations to learn the payment type ID for payment types active for this report's expense group. For mileage expenses use the Cash payment type. For expense types with an expense code that uses a transaction amount instead of a distance this is required. This element should not be used for expense types with an expense code for Company Car or Personal Car because these two expense codes always use the Cash payment type.
            /// </summary>
            public string PaymentTypeID { get; set; }

            /// <summary>
            /// The Report ID of the report where the entry will be added.
            /// </summary>
            public string ReportID { get; set; }

            /// <summary>
            /// Receipt type of this entry. Choices: T = tax receipt, R = regular receipt, N = no receipt
            /// </summary>
            public string TaxReceiptType { get; set; }

            /// <summary>
            /// The amount of the expense entry in the transaction currency paid to the vendor.	For expense types with an expense code that uses a transaction amount instead of a distance this is required. This element should not be used for expense types with an expense code for Company Car or Personal Car because because these two expense codes use a distance instead of a transaction amount.
            /// </summary>
            public decimal? TransactionAmount { get; set; }

            /// <summary>
            /// The <a target="_blank" href="http://en.wikipedia.org/wiki/ISO_4217">3-letter ISO 4217 currency code</a> for the expense entry transaction amount. This is the currency the vendor was paid. For expense types with an expense code that uses a transaction amount instead of a distance this is required. This element should not be used for expense types with an expense code for Company Car or Personal Car because these two expense codes the currency is always in the Report Currency.
            /// </summary>
            public string TransactionCurrencyCode { get; set; }

            /// <summary>
            /// The date when the good or service associated to this expense entry was made. Format: YYYY-MM-DD
            /// </summary>
            public DateTime? TransactionDate { get; set; }

            /// <summary>
            /// The vendor name of the expense entry.  Max length: 64.
            /// </summary>
            public string VendorDescription { get; set; }

            /// <summary>
            /// The unique identifier for a vendor list item. Use the GET Lists function to get the information about this list item.
            /// </summary>
            public string VendorListItemID { get; set; }
        }


        [XmlRoot("Journey")]
        public class Journey
        {

            /// <summary>
            /// The portion of the journey for business in the report owner's distance unit of measure. This is required to post a personal car mileage expense entry, or to post a company car mileage expense when there is no Personal Distance. Positive Integer. When using the Odometer elements the sum of Personal Distance and Business Distance must equal the different between Odometer End and Odometer Start.
            /// </summary>
            public Int32? BusinessDistance { get; set; }

            /// <summary>
            /// Where the journey ended. This is also known as the "To Location". Max length: 100.
            /// </summary>
            public string EndLocation { get; set; }

            /// <summary>
            /// The number of people in the vehicle during the journey. Positive Integer. Used with Variable-Rate, Personal or Company Car.
            /// </summary>
            public Int32? NumberOfPassengers { get; set; }

            /// <summary>
            /// The odometer reading at the end of the journey. Positive Integer. Must be greater than OdometerStart. Used with Variable-Rate, Company Car.
            /// </summary>
            public Int32? OdometerEnd { get; set; }

            /// <summary>
            /// The odometer reading at the start of the journey. Positive Integer. Used with Variable-Rate, Company Car.
            /// </summary>
            public Int32? OdometerStart { get; set; }

            /// <summary>
            /// The portion of the journey for personal use. This is required to post a company car mileage expense when there is no Business Distance. Positive Integer. When using the Odometer elements the sum of Personal Distance and Business Distance must equal the different between Odometer End and Odometer Start. Used with Company Car.
            /// </summary>
            public Int32? PersonalDistance { get; set; }

            /// <summary>
            /// Where the journey started. This is also known as the "From Location". Max length: 100.
            /// </summary>
            public string StartLocation { get; set; }

            /// <summary>
            /// Unit of measure for distance and odometer values: M for miles or K for kilometers.
            /// </summary>
            public string UnitOfMeasure { get; set; }

            /// <summary>
            /// The unique identifier for the vehicle used for this journey. Used only with Company Car configuration types. Use GET Vehicles to learn the Vehicle ID.
            /// </summary>
            public string VehicleID { get; set; }
        }

        /// <summary>
        /// EntryAttendeeAssociations
        /// </summary>
        [XmlRoot("EntryAttendeeAssociations")]
        public class EntryAttendeeAssociationCollection
        {

            /// <summary>
            /// The result collection.
            /// </summary>
            [XmlArrayItem("EntryAttendeeAssociation")]
            public EntryAttendeeAssociationGet[] Items { get; set; }

            /// <summary>
            /// The URI of the next page of results, if any.
            /// </summary>
            public string NextPage { get; set; }

            /// <summary>
            /// The offset value to be used when iterating to get the next page of objects.
            /// </summary>
            public virtual string NextPageOffset() { return this.Util.GetQueryStringValue(NextPage, "offset"); }

            /// <summary>
            /// The flag used to indicate whether the current page of objects is the last one in the sequence.
            /// </summary>
            public virtual bool IsEndOfPagination() { return string.IsNullOrWhiteSpace(NextPageOffset()); }

            protected ConcurUtil Util = new ConcurUtil();
        }

        /// <summary>
        /// EntryAttendeeAssociation
        /// </summary>
        [XmlRoot("EntryAttendeeAssociation")]
        public class EntryAttendeeAssociationGet
        {

            /// <summary>
            /// The portion of the Entry Transaction Amount assigned to this attendee.
            /// </summary>
            public decimal? Amount { get; set; }

            /// <summary>
            /// The count of attendees associated to this attendee. A count greater than 1 means there are unnamed attendees associated with this attendee.
            /// </summary>
            public Int32? AssociatedAttendeeCount { get; set; }

            /// <summary>
            /// The unique identifier of the associated attendee.
            /// </summary>
            public string AttendeeID { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom1 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom2 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom3 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom4 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom5 { get; set; }

            /// <summary>
            /// The unique identifier of the associated entry.
            /// </summary>
            public string EntryID { get; set; }

            /// <summary>
            /// The unique identifier of the resource.
            /// </summary>
            public string ID { get; set; }

            /// <summary>
            /// The URI to the resource.
            /// </summary>
            public string URI { get; set; }
        }

        /// <summary>
        /// EntryAttendeeAssociation
        /// </summary>
        [XmlRoot("EntryAttendeeAssociation")]
        public class EntryAttendeeAssociationPost
        {

            /// <summary>
            /// The portion of the Entry Transaction Amount assigned to this attendee.
            /// </summary>
            public decimal? Amount { get; set; }

            /// <summary>
            /// The count of attendees associated to this attendee. A count greater than 1 means there are unnamed attendees associated with this attendee.
            /// </summary>
            public Int32? AssociatedAttendeeCount { get; set; }

            /// <summary>
            /// The unique identifier of the associated attendee.
            /// </summary>
            public string AttendeeID { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom1 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom2 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom3 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom4 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom5 { get; set; }

            /// <summary>
            /// The unique identifier of the associated entry.
            /// </summary>
            public string EntryID { get; set; }
        }

        /// <summary>
        /// EntryAttendeeAssociation
        /// </summary>
        [XmlRoot("EntryAttendeeAssociation")]
        public class EntryAttendeeAssociationPut
        {

            /// <summary>
            /// The portion of the Entry Transaction Amount assigned to this attendee.
            /// </summary>
            public decimal? Amount { get; set; }

            /// <summary>
            /// The count of attendees associated to this attendee. A count greater than 1 means there are unnamed attendees associated with this attendee.
            /// </summary>
            public Int32? AssociatedAttendeeCount { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom1 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom2 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom3 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom4 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom5 { get; set; }
        }

        /// <summary>
        /// AttendeeType
        /// </summary>
        [XmlRoot("AttendeeType")]
        public class AttendeeType
        {

            /// <summary>
            /// The attendee type code.
            /// </summary>
            public string Code { get; set; }

            /// <summary>
            /// The name of the attendee type.
            /// </summary>
            public string Name { get; set; }
        }

        /// <summary>
        /// CashAdvance
        /// </summary>
        [XmlRoot("CashAdvance")]
        public class CashAdvance
        {

            /// <summary>
            /// The amount requested in the cash advance, in the currency listed in the CurrencyCode element.
            /// </summary>
            public string AmountRequested { get; set; }

            /// <summary>
            /// The approval status of the cash advance.
            /// </summary>
            public string ApprovalStatusName { get; set; }

            /// <summary>
            /// The number of comments associated with the cash advance.
            /// </summary>
            public Int32 CommentCount { get; set; }

            /// <summary>
            /// This parent element has a Count attribute indicating the number of comments that are included in the cash advance. It has a Comment child element for each comment. Refer to the Comments model for the full list of child elements.
            /// </summary>
            [XmlArrayItem("Comments")]
            public Comments[] CommentsList { get; set; }

            /// <summary>
            /// The <a target="_blank" href="http://en.wikipedia.org/wiki/ISO_4217">3-letter ISO 4217 currency code</a> for the cash advance currency.
            /// </summary>
            public string CurrencyCode { get; set; }

            /// <summary>
            /// The name of the currency for the cash advance.
            /// </summary>
            public string CurrencyName { get; set; }

            /// <summary>
            /// The <a target="_blank" href="http://en.wikipedia.org/wiki/ISO_4217">3-letter ISO 4217 currency code for the employee's currency ("home currency").
            /// </summary>
            public string EmployeeCurrencyCode { get; set; }

            /// <summary>
            /// The name of the employee's currency (\"home currency\").
            /// </summary>
            public string EmployeeCurrencyName { get; set; }

            /// <summary>
            /// The exchange rate that applies to the cash advance.
            /// </summary>
            public string ExchangeRate { get; set; }

            /// <summary>
            /// The issue date for the cash advance.
            /// </summary>
            public DateTime? IssueDate { get; set; }

            /// <summary>
            /// Date of cash advance request from the detailed cash advance record.
            /// </summary>
            public DateTime? RequestDate { get; set; }

            /// <summary>
            /// The initial balance for the cash advance.
            /// </summary>
            public string StartingBalance { get; set; }
        }

        /// <summary>
        /// ExpenseGroupConfiguration
        /// </summary>
        [XmlRoot("ExpenseGroupConfiguration")]
        public class ExpenseGroupConfiguration
        {

            /// <summary>
            /// Whether users are allowed to upload digital tax invoices. Format true or false.
            /// </summary>
            public bool? AllowUserDigitalTaxInvoice { get; set; }

            /// <summary>
            /// Determines which users are allowed to register Yodlee credit cards. Format true or false.
            /// </summary>
            public bool? AllowUserRegisterYodlee { get; set; }

            /// <summary>
            /// The unique identifier for the attendee list form.
            /// </summary>
            public string AttendeeListFormID { get; set; }

            /// <summary>
            /// The name of the attendee list form.
            /// </summary>
            public string AttendeeListFormName { get; set; }

            /// <summary>
            /// The list of attendee types.
            /// </summary>
            [XmlArrayItem("AttendeeType")]
            public AttendeeType[] AttendeeTypes { get; set; }

            /// <summary>
            /// The cash advance.
            /// </summary>
            public CashAdvance CashAdvance { get; set; }

            /// <summary>
            /// The unique identifier of the resource.
            /// </summary>
            public string ID { get; set; }

            /// <summary>
            /// The name of the Group Configuration.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// The list of payment types.
            /// </summary>
            [XmlArrayItem("PaymentType")]
            public PaymentType[] PaymentTypes { get; set; }

            /// <summary>
            /// The list of policies and expense types.
            /// </summary>
            [XmlArrayItem("Policy")]
            public Policy[] Policies { get; set; }

            /// <summary>
            /// The URI to the resource.
            /// </summary>
            public string URI { get; set; }
        }

        /// <summary>
        /// ExpenseGroupConfigurations
        /// </summary>
        [XmlRoot("ExpenseGroupConfigurations")]
        public class ExpenseGroupConfigurationCollection
        {

            /// <summary>
            /// The result collection.
            /// </summary>
            [XmlArrayItem("ExpenseGroupConfiguration")]
            public ExpenseGroupConfiguration[] Items { get; set; }

            /// <summary>
            /// The URI of the next page of results, if any.
            /// </summary>
            public string NextPage { get; set; }

            /// <summary>
            /// The offset value to be used when iterating to get the next page of objects.
            /// </summary>
            public virtual string NextPageOffset() { return this.Util.GetQueryStringValue(NextPage, "offset"); }

            /// <summary>
            /// The flag used to indicate whether the current page of objects is the last one in the sequence.
            /// </summary>
            public virtual bool IsEndOfPagination() { return string.IsNullOrWhiteSpace(NextPageOffset()); }

            protected ConcurUtil Util = new ConcurUtil();
        }

        /// <summary>
        /// ExpenseType
        /// </summary>
        [XmlRoot("ExpenseType")]
        public class ExpenseType
        {

            /// <summary>
            /// The expense type code.
            /// </summary>
            public string Code { get; set; }

            /// <summary>
            /// The expense code of the expense type. The expense code controls the function of an expense entry with this expense type. Format: OTHER = Standard, COCARMILE = Company Car, PCARMILE = Personal Car, MFUEL = Fuel For Mileage, LODGING = Lodging, MEALS = Meals, OTHERNP = Other Not Partially Approvable, JPYPTRAN = Japanese Public Transportation
            /// </summary>
            public string ExpenseCode { get; set; }

            /// <summary>
            /// The name of the expense type.
            /// </summary>
            public string Name { get; set; }
        }

        /// <summary>
        /// PaymentType
        /// </summary>
        [XmlRoot("PaymentType")]
        public class PaymentType
        {

            /// <summary>
            /// The unique identifier of the resource.
            /// </summary>
            public string ID { get; set; }

            /// <summary>
            /// Determines if this payment type is the default. Format: true or false
            /// </summary>
            public bool? IsDefault { get; set; }

            /// <summary>
            /// The name of the payment type.
            /// </summary>
            public string Name { get; set; }
        }

        /// <summary>
        /// Policy
        /// </summary>
        [XmlRoot("Policy")]
        public class Policy
        {

            /// <summary>
            /// The parent element for the list of expense types in the policy.
            /// </summary>
            [XmlArrayItem("ExpenseType")]
            public ExpenseType[] ExpenseTypes { get; set; }

            /// <summary>
            /// The unique identifier of the resource.
            /// </summary>
            public string ID { get; set; }

            /// <summary>
            /// Determines if this policy is the default. Format: true or false
            /// </summary>
            public bool? IsDefault { get; set; }

            /// <summary>
            /// Determines the descendent nodes on the Expense Feature Hierarchy are covered by this policy. Format true or false.
            /// </summary>
            public bool? IsInheritable { get; set; }

            /// <summary>
            /// The name of the policy.
            /// </summary>
            public string Name { get; set; }
        }

        /// <summary>
        /// Itemizations
        /// </summary>
        [XmlRoot("Itemizations")]
        public class ItemizationCollection
        {

            /// <summary>
            /// The result collection.
            /// </summary>
            [XmlArrayItem("Itemization")]
            public ItemizationGet[] Items { get; set; }

            /// <summary>
            /// The URI of the next page of results, if any.
            /// </summary>
            public string NextPage { get; set; }

            /// <summary>
            /// The offset value to be used when iterating to get the next page of objects.
            /// </summary>
            public virtual string NextPageOffset() { return this.Util.GetQueryStringValue(NextPage, "offset"); }

            /// <summary>
            /// The flag used to indicate whether the current page of objects is the last one in the sequence.
            /// </summary>
            public virtual bool IsEndOfPagination() { return string.IsNullOrWhiteSpace(NextPageOffset()); }

            protected ConcurUtil Util = new ConcurUtil();
        }

        /// <summary>
        /// Itemization
        /// </summary>
        [XmlRoot("Itemization")]
        public class ItemizationGet
        {

            /// <summary>
            /// Defines the type of allocations for the itemization. Possible values are: P, for partial allocation, F, for full allocation, or N, for no allocation.  Use GET ExpenseEntryAllocations to get information about this entry's allocations.
            /// </summary>
            public string AllocationType { get; set; }

            /// <summary>
            /// The approved amount of the expense itemization in the report currency.
            /// </summary>
            public decimal? ApprovedAmount { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom1 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom10 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom11 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom12 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom13 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom14 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom15 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom16 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom17 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom18 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom19 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom2 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom20 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom21 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom22 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom23 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom24 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom25 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom26 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom27 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom28 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom29 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom3 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom30 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom31 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom32 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom33 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom34 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom35 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom36 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom37 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom38 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom39 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom4 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom40 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom5 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom6 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom7 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom8 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public CustomField Custom9 { get; set; }

            /// <summary>
            /// The description of the expense. Max length: 64.
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// The ID of the expense entry that is the parent for the itemization.. Use the GET Expense Entries operation to learn the Entry ID to add the expense itemizations.
            /// </summary>
            public string EntryID { get; set; }

            /// <summary>
            /// The code for the expense type. Use GET Expense Group Configurations to learn the expense type code for expense types active for this report's policy.
            /// </summary>
            public string ExpenseTypeCode { get; set; }

            /// <summary>
            /// The name of the expense type localized to the OAuth Consumer's language.
            /// </summary>
            public string ExpenseTypeName { get; set; }

            /// <summary>
            /// Whether the expense has comments.  Use GET ExpenseEntryComments to get information about this entry's comments. Format true or false
            /// </summary>
            public bool? HasComments { get; set; }

            /// <summary>
            /// Whether the expense has exceptions.  Use GET ExpenseEntryExceptions to get information about this entry's exceptions. Format true or false
            /// </summary>
            public bool? HasExceptions { get; set; }

            /// <summary>
            /// The unique identifier of the resource.
            /// </summary>
            public string ID { get; set; }

            /// <summary>
            /// Determines if the itemization is billable or not. Format: true or false.
            /// </summary>
            public bool? IsBillable { get; set; }

            /// <summary>
            /// Whether an receipt image is required for the entry. Format true or false
            /// </summary>
            public bool? IsImageRequired { get; set; }

            /// <summary>
            /// Determines if the itemization is personal or non-reimbursable. Format: true or false.
            /// </summary>
            public bool? IsPersonal { get; set; }

            /// <summary>
            /// The UTC date when the itemization was last modified.
            /// </summary>
            public DateTime? LastModified { get; set; }

            /// <summary>
            /// The country where the expense was incurred. Format: 2-letter ISO 3166-1 country code.
            /// </summary>
            public string LocationCountry { get; set; }

            /// <summary>
            /// The unique identifier for location. Use the GET Locations function to get information for this location.
            /// </summary>
            public string LocationID { get; set; }

            /// <summary>
            /// The location for the expense itemization, usually the city name.
            /// </summary>
            public string LocationName { get; set; }

            /// <summary>
            /// The state, province, or other country subdivision where the expense was incurred. Format: ISO 3166-2:2007 country subdivision.
            /// </summary>
            public string LocationSubdivision { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters.
            /// </summary>
            public CustomField OrgUnit1 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters.
            /// </summary>
            public CustomField OrgUnit2 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters.
            /// </summary>
            public CustomField OrgUnit3 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters.
            /// </summary>
            public CustomField OrgUnit4 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters.
            /// </summary>
            public CustomField OrgUnit5 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters.
            /// </summary>
            public CustomField OrgUnit6 { get; set; }

            /// <summary>
            /// The amount of the expense itemization in the report currency.
            /// </summary>
            public decimal? PostedAmount { get; set; }

            /// <summary>
            /// The ID of the report that is the parent for the itemization.
            /// </summary>
            public string ReportID { get; set; }

            /// <summary>
            /// The login ID for the report owner.  Use GET User Information to learn details about this user.
            /// </summary>
            public string ReportOwnerID { get; set; }

            /// <summary>
            /// The code for the spend category specified for this itemization.
            /// </summary>
            public string SpendCategoryCode { get; set; }

            /// <summary>
            /// The name of the spend category specified for this itemization localized to the OAuth Consumer's language.
            /// </summary>
            public string SpendCategoryName { get; set; }

            /// <summary>
            /// The amount of the expense itemization in the Transaction Currency of the parent expense entry.
            /// </summary>
            public decimal? TransactionAmount { get; set; }

            /// <summary>
            /// The date when the good or service associated to this itemization was made. Format: YYYY-MM-DD
            /// </summary>
            public DateTime? TransactionDate { get; set; }

            /// <summary>
            /// The URI to the resource.
            /// </summary>
            public string URI { get; set; }
        }

        /// <summary>
        /// Itemization
        /// </summary>
        [XmlRoot("Itemization")]
        public class ItemizationPost
        {

            /// <summary>
            /// The expense itemization comment. Max length: 500.
            /// </summary>
            public string Comment { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom1 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom10 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom11 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom12 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom13 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom14 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom15 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom16 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom17 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom18 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom19 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom2 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom20 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom21 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom22 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom23 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom24 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom25 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom26 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom27 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom28 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom29 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom3 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom30 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom31 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom32 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom33 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom34 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom35 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom36 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom37 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom38 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom39 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom4 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom40 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom5 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom6 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom7 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom8 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters
            /// </summary>
            public string Custom9 { get; set; }

            /// <summary>
            /// The description of the expense. Max length: 64.
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// The ID of the expense entry that is the parent for the itemization.. Use the GET Expense Entries operation to learn the Entry ID to add the expense itemizations.
            /// </summary>
            public string EntryID { get; set; }

            /// <summary>
            /// The code for the expense type. Use GET Expense Group Configurations to learn the expense type code for expense types active for this report's policy.
            /// </summary>
            public string ExpenseTypeCode { get; set; }

            /// <summary>
            /// Determines if the itemization is billable or not. Format: true or false.
            /// </summary>
            public bool? IsBillable { get; set; }

            /// <summary>
            /// Determines if the itemization is personal or non-reimbursable. Format: true or false.
            /// </summary>
            public bool? IsPersonal { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters.
            /// </summary>
            public string OrgUnit1 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters.
            /// </summary>
            public string OrgUnit2 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters.
            /// </summary>
            public string OrgUnit3 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters.
            /// </summary>
            public string OrgUnit4 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters.
            /// </summary>
            public string OrgUnit5 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration. If the form field is configured as a List data type the value will be the item code for this list. Use the GET List Item operation to learn the item name. Text max 64 characters.
            /// </summary>
            public string OrgUnit6 { get; set; }

            /// <summary>
            /// The amount of the expense itemization in the Transaction Currency of the parent expense entry.
            /// </summary>
            public decimal? TransactionAmount { get; set; }

            /// <summary>
            /// The date when the good or service associated to this itemization was made. Format: YYYY-MM-DD
            /// </summary>
            public DateTime? TransactionDate { get; set; }
        }

        /// <summary>
        /// Airline
        /// </summary>
        [XmlRoot("Airline")]
        public class Airline
        {

            /// <summary>
            /// The booking class of the latest booked airline segment.
            /// </summary>
            public string BookingClass { get; set; }

            /// <summary>
            /// The airline code of the latest booked airline segment.
            /// </summary>
            public string Code { get; set; }
        }

        /// <summary>
        /// Hotel
        /// </summary>
        [XmlRoot("Hotel")]
        public class Hotel
        {

            /// <summary>
            /// The <a target="_blank" href=" http://www.iata.org/publications/Pages/code-search.aspx">IATA airport code</a> of the location of the latest booked hotel segment.
            /// </summary>
            public string Location { get; set; }

            /// <summary>
            /// The star rating of the latest booked hotel segment. Possible values are from 0 - 5. Values 1 - 5 are mapped to the <a target="_blank" href="http://www.northstartravelmedia.com/">Northstar</a> standard. If the value is 0, the star rating could not be found.
            /// </summary>
            public Int32? StarRating { get; set; }
        }

        /// <summary>
        /// LatestBooking
        /// </summary>
        [XmlRoot("LatestBooking")]
        public class LatestBooking
        {

            /// <summary>
            /// The latest booked airline segments.
            /// </summary>
            [XmlArrayItem("Airline")]
            public Airline[] Airlines { get; set; }

            /// <summary>
            /// The latest booked hotel segment.
            /// </summary>
            public Hotel Hotel { get; set; }
        }

        /// <summary>
        /// ListItem
        /// </summary>
        [XmlRoot("ListItem")]
        public class ListItemGet
        {

            /// <summary>
            /// The unique identifier of the resource.
            /// </summary>
            public string ID { get; set; }

            /// <summary>
            /// The item code for the tenth level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters
            /// </summary>
            public string Level10Code { get; set; }

            /// <summary>
            /// The item code for the first level of the list. All lists have at least a Level1Code. Text maximum 32 characters
            /// </summary>
            public string Level1Code { get; set; }

            /// <summary>
            /// The item code for the second level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters
            /// </summary>
            public string Level2Code { get; set; }

            /// <summary>
            /// The item code for the third level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters
            /// </summary>
            public string Level3Code { get; set; }

            /// <summary>
            /// The item code for the fourth level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters
            /// </summary>
            public string Level4Code { get; set; }

            /// <summary>
            /// The item code for the fifth level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters
            /// </summary>
            public string Level5Code { get; set; }

            /// <summary>
            /// The item code for the sixth level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters
            /// </summary>
            public string Level6Code { get; set; }

            /// <summary>
            /// The item code for the seventh level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters
            /// </summary>
            public string Level7Code { get; set; }

            /// <summary>
            /// The item code for the eighth level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters
            /// </summary>
            public string Level8Code { get; set; }

            /// <summary>
            /// The item code for the ninth level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters
            /// </summary>
            public string Level9Code { get; set; }

            /// <summary>
            /// The unique identifier for the list this item is a member.
            /// </summary>
            public string ListID { get; set; }

            /// <summary>
            /// The name of item. Text maximum 64 characters
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// The unique identifier of this item's parent. Is empty when there is no parent.
            /// </summary>
            public string ParentID { get; set; }

            /// <summary>
            /// The URI to the resource.
            /// </summary>
            public string URI { get; set; }
        }

        /// <summary>
        /// ListItems
        /// </summary>
        [XmlRoot("ListItems")]
        public class ListItemGetCollection
        {

            /// <summary>
            /// The result collection.
            /// </summary>
            [XmlArrayItem("ListItem")]
            public ListItemGet[] Items { get; set; }

            /// <summary>
            /// The URI of the next page of results, if any.
            /// </summary>
            public string NextPage { get; set; }

            /// <summary>
            /// The offset value to be used when iterating to get the next page of objects.
            /// </summary>
            public virtual string NextPageOffset() { return this.Util.GetQueryStringValue(NextPage, "offset"); }

            /// <summary>
            /// The flag used to indicate whether the current page of objects is the last one in the sequence.
            /// </summary>
            public virtual bool IsEndOfPagination() { return string.IsNullOrWhiteSpace(NextPageOffset()); }

            protected ConcurUtil Util = new ConcurUtil();
        }

        /// <summary>
        /// ListItem
        /// </summary>
        [XmlRoot("ListItem")]
        public class ListItemPost
        {

            /// <summary>
            /// The item code for the tenth level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters
            /// </summary>
            public string Level10Code { get; set; }

            /// <summary>
            /// The item code for the first level of the list. All lists have at least a Level1Code. Text maximum 32 characters
            /// </summary>
            public string Level1Code { get; set; }

            /// <summary>
            /// The item code for the second level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters
            /// </summary>
            public string Level2Code { get; set; }

            /// <summary>
            /// The item code for the third level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters
            /// </summary>
            public string Level3Code { get; set; }

            /// <summary>
            /// The item code for the fourth level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters
            /// </summary>
            public string Level4Code { get; set; }

            /// <summary>
            /// The item code for the fifth level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters
            /// </summary>
            public string Level5Code { get; set; }

            /// <summary>
            /// The item code for the sixth level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters
            /// </summary>
            public string Level6Code { get; set; }

            /// <summary>
            /// The item code for the seventh level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters
            /// </summary>
            public string Level7Code { get; set; }

            /// <summary>
            /// The item code for the eighth level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters
            /// </summary>
            public string Level8Code { get; set; }

            /// <summary>
            /// The item code for the ninth level of the list. Empty when this level doesn't exist in the list. Text maximum 32 characters
            /// </summary>
            public string Level9Code { get; set; }

            /// <summary>
            /// The unique identifier for the list this item is a member.
            /// </summary>
            public string ListID { get; set; }

            /// <summary>
            /// The name of item. Text maximum 64 characters
            /// </summary>
            public string Name { get; set; }
        }

        /// <summary>
        /// ListItem
        /// </summary>
        [XmlRoot("ListItem")]
        public class ListItemPut
        {

            /// <summary>
            /// The item code of the listitem. Text maximum 32 characters
            /// </summary>
            public string Code { get; set; }

            /// <summary>
            /// The unique identifier for the list this item is a member.
            /// </summary>
            public string ListID { get; set; }

            /// <summary>
            /// The name of item. Text maximum 64 characters
            /// </summary>
            public string Name { get; set; }
        }

        /// <summary>
        /// List
        /// </summary>
        [XmlRoot("List")]
        public class ListGet
        {

            /// <summary>
            /// Optional. Defines the encrypted ConnectorID. If not provided then the list isn't associated with a connector.
            /// </summary>
            public string ConnectorID { get; set; }

            /// <summary>
            /// Required. Defines whether CODE should appear before TEXT, or vice-versa.
            /// </summary>
            public bool? DisplayCodeFirst { get; set; }

            /// <summary>
            /// Optional. Default value is 1. Defines the threshold from where the level starts being external. This value can only be set if a ConnectorID is provided.
            /// </summary>
            public Int32? ExternalThreshold { get; set; }

            /// <summary>
            /// The unique identifier of the resource.
            /// </summary>
            public string ID { get; set; }

            /// <summary>
            /// Required. Defines whether it is a vendor list.
            /// </summary>
            public bool? IsVendorList { get; set; }

            /// <summary>
            /// Required. Defines a name for the list. This name must be unique.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Required. Defines whether the search criteria should apply to the CODE or to the TEXT.
            /// </summary>
            public string SearchCriteriaCode { get; set; }

            /// <summary>
            /// The URI to the resource.
            /// </summary>
            public string URI { get; set; }
        }

        /// <summary>
        /// Lists
        /// </summary>
        [XmlRoot("Lists")]
        public class ListGetCollection
        {

            /// <summary>
            /// The result collection.
            /// </summary>
            [XmlArrayItem("List")]
            public ListGet[] Items { get; set; }

            /// <summary>
            /// The URI of the next page of results, if any.
            /// </summary>
            public string NextPage { get; set; }

            /// <summary>
            /// The offset value to be used when iterating to get the next page of objects.
            /// </summary>
            public virtual string NextPageOffset() { return this.Util.GetQueryStringValue(NextPage, "offset"); }

            /// <summary>
            /// The flag used to indicate whether the current page of objects is the last one in the sequence.
            /// </summary>
            public virtual bool IsEndOfPagination() { return string.IsNullOrWhiteSpace(NextPageOffset()); }

            protected ConcurUtil Util = new ConcurUtil();
        }

        /// <summary>
        /// List
        /// </summary>
        [XmlRoot("List")]
        public class ListPost
        {

            /// <summary>
            /// Optional. Defines the encrypted ConnectorID. If not provided then the list isn't associated with a connector.
            /// </summary>
            public string ConnectorID { get; set; }

            /// <summary>
            /// Required. Defines whether CODE should appear before TEXT, or vice-versa.
            /// </summary>
            public bool? DisplayCodeFirst { get; set; }

            /// <summary>
            /// Optional. Default value is 1. Defines the threshold from where the level starts being external. This value can only be set if a ConnectorID is provided.
            /// </summary>
            public Int32? ExternalThreshold { get; set; }

            /// <summary>
            /// Required. Defines whether it is a vendor list.
            /// </summary>
            public bool? IsVendorList { get; set; }

            /// <summary>
            /// Required. Defines a name for the list. This name must be unique.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Required. Defines whether the search criteria should apply to the CODE or to the TEXT.
            /// </summary>
            public string SearchCriteriaCode { get; set; }
        }

        /// <summary>
        /// List
        /// </summary>
        [XmlRoot("List")]
        public class ListPut
        {

            /// <summary>
            /// Optional. Defines whether CODE should appear before TEXT, or vice-versa.
            /// </summary>
            public bool? DisplayCodeFirst { get; set; }

            /// <summary>
            /// Optional. Defines a name for the list. This name must be unique.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Optional. Defines whether the search criteria should apply to the CODE or to the TEXT.
            /// </summary>
            public string SearchCriteriaCode { get; set; }
        }

        /// <summary>
        /// Location
        /// </summary>
        [XmlRoot("Location")]
        public class Location
        {

            /// <summary>
            /// Administrative Region. 
            /// </summary>
            public string AdministrativeRegion { get; set; }

            /// <summary>
            /// 2-letter ISO 3166-1 country code.
            /// </summary>
            public string Country { get; set; }

            /// <summary>
            /// ISO 3166-2:2007 country subdivision
            /// </summary>
            public string CountrySubdivision { get; set; }

            /// <summary>
            /// IATA airport code
            /// </summary>
            public string IATACode { get; set; }

            /// <summary>
            /// The unique identifier of the resource.
            /// </summary>
            public string ID { get; set; }

            /// <summary>
            /// Whether the location is an Airport. format: true or false
            /// </summary>
            public bool? IsAirport { get; set; }

            /// <summary>
            /// Whether the location is used by the booking tool. format: true or false.
            /// </summary>
            public bool? IsBookingTool { get; set; }

            /// <summary>
            /// The latitude for the geocode for the location.
            /// </summary>
            public decimal? Latitude { get; set; }

            /// <summary>
            /// The longitude for the geocode for the location.
            /// </summary>
            public decimal? Longitude { get; set; }

            /// <summary>
            /// The location name. The maximum is 64 characters
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// The URI to the resource.
            /// </summary>
            public string URI { get; set; }
        }

        /// <summary>
        /// Locations
        /// </summary>
        [XmlRoot("Locations")]
        public class LocationCollection
        {

            /// <summary>
            /// The result collection.
            /// </summary>
            [XmlArrayItem("Location")]
            public Location[] Items { get; set; }

            /// <summary>
            /// The URI of the next page of results, if any.
            /// </summary>
            public string NextPage { get; set; }

            /// <summary>
            /// The offset value to be used when iterating to get the next page of objects.
            /// </summary>
            public virtual string NextPageOffset() { return this.Util.GetQueryStringValue(NextPage, "offset"); }

            /// <summary>
            /// The flag used to indicate whether the current page of objects is the last one in the sequence.
            /// </summary>
            public virtual bool IsEndOfPagination() { return string.IsNullOrWhiteSpace(NextPageOffset()); }

            protected ConcurUtil Util = new ConcurUtil();
        }

        /// <summary>
        /// Opportunities
        /// </summary>
        [XmlRoot("Opportunities")]
        public class Opportunities
        {

            /// <summary>
            /// The result collection.
            /// </summary>
            [XmlArrayItem("Opportunity")]
            public Opportunity[] Items { get; set; }

            /// <summary>
            /// The URI of the next page of results, if any.
            /// </summary>
            public string NextPage { get; set; }
        }


        [XmlRoot("Opportunity")]
        public class Opportunity
        {

            /// <summary>
            /// The city code of the destination city where the opportunity is offered
            /// </summary>
            public string EndCityCode { get; set; }

            /// <summary>
            /// The local end date of the location where the opportunity is offered
            /// </summary>
            public DateTime EndDateLocal { get; set; }

            /// <summary>
            /// The postal code of the destination location where the opportunity is offered
            /// </summary>
            public string EndPostalCode { get; set; }

            /// <summary>
            /// The unique identifier of the resource.
            /// </summary>
            public string ID { get; set; }

            /// <summary>
            /// Indicates that the opportunity is currently active
            /// </summary>
            public bool IsActive { get; set; }

            /// <summary>
            /// The city code of the originating city where the opportunity is offered
            /// </summary>
            public string StartCityCode { get; set; }

            /// <summary>
            /// The local start date of the location where the opportunity is offered
            /// </summary>
            public DateTime StartDateLocal { get; set; }

            /// <summary>
            /// The postal code of the originating location where the opportunity is offered
            /// </summary>
            public string StartPostalCode { get; set; }

            /// <summary>
            /// The trip id of the associated itinerary
            /// </summary>
            public string TripId { get; set; }

            /// <summary>
            /// The type of opportunity. Allowed values are: Hotel, Car, Air, Rail, Taxi, Service. 
            /// </summary>
            public string Type { get; set; }

            /// <summary>
            /// The URI to the resource.
            /// </summary>
            public string URI { get; set; }
        }


        [XmlRoot("PurchaseOrderReceipt")]
        public class PurchaseOrderReceipt
        {

            /// <summary>
            /// Whether the line item was received.
            /// </summary>
            public string IsReceived { get; set; }

            /// <summary>
            /// A customer supplied value that uniquely identifies the line item within purchase order.
            /// </summary>
            public string LineItemExternalID { get; set; }

            /// <summary>
            /// The purchase order number.
            /// </summary>
            public string PurchaseOrderNumber { get; set; }

            /// <summary>
            /// The date the line item was received. Format YYYY-MM-DD.
            /// </summary>
            public string ReceivedDate { get; set; }

            /// <summary>
            /// How many items were received.
            /// </summary>
            public string ReceivedQuantity { get; set; }
        }

        /// <summary>
        /// Error
        /// </summary>
        [XmlRoot("Error")]
        public class PurchaseOrderResult
        {

            /// <summary>
            /// The code to identify why the purchase order was not processed successfully.
            /// </summary>
            public string ErrorCode { get; set; }

            /// <summary>
            /// Description of error.
            /// </summary>
            public string ErrorMessage { get; set; }

            /// <summary>
            /// The code that indicates which field caused an issue. This typically only appears when a field is being validated against a field of a form type. The format of the code will be LEVEL|CODE. The possible levels are: Header, ShipTo, BillTo, LineItem, Allocation. Refer to <a target="_blank" href="https://developer.concur.com/node/394/#responses"> Responses and Errors</a> for more information.
            /// </summary>
            public string FieldCode { get; set; }

            /// <summary>
            /// Will display the line item external id of a line item that caused the error. If the error is related to an Allocation, this will indicate the external id of the line item that the allocation is associated with and which allocation was the cause of the error. Refer to <a target="_blank" href="https://developer.concur.com/node/394/#responses"> Responses and Errors</a> for more information.
            /// </summary>
            public string LineItemExternalID { get; set; }

            public string Message { get; set; }

            /// <summary>
            /// The purchase order number.
            /// </summary>
            public string PurchaseOrderNumber { get; set; }

            /// <summary>
            /// The result of processing the purchase order. Format is SUCCESS or FAILURE.
            /// </summary>
            public string Status { get; set; }
        }

        /// <summary>
        /// Allocation
        /// </summary>
        [XmlRoot("Allocation")]
        public class Allocation
        {

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom1 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom10 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom11 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom12 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom13 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom14 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom15 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom16 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom17 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom18 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom19 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom2 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom20 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom3 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom4 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom5 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom6 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom7 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom8 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom9 { get; set; }

            /// <summary>
            /// The percentage of the expense that is included in this allocation.
            /// </summary>
            public string Percentage { get; set; }
        }


        [XmlRoot("BillToAddress")]
        public class BillToAddress
        {

            /// <summary>
            /// Address 1 of the shipping or billing address.
            /// </summary>
            public string Address1 { get; set; }

            /// <summary>
            /// Address 2 of the shipping or billing address.
            /// </summary>
            public string Address2 { get; set; }

            /// <summary>
            /// Address 3 of the shipping or billing address.
            /// </summary>
            public string Address3 { get; set; }

            /// <summary>
            /// The city of the shipping or billing address.
            /// </summary>
            public string City { get; set; }

            /// <summary>
            /// The code of the country associated to the shipping or billing address.
            /// </summary>
            public string CountryCode { get; set; }

            /// <summary>
            /// A unique value supplied by the customer to identify a particular shipping or billing address.
            /// </summary>
            public string ExternalID { get; set; }

            /// <summary>
            /// An optional name that can be given to the shipping and billing address.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// The postal code of the shipping or billing address.
            /// </summary>
            public string PostalCode { get; set; }

            /// <summary>
            /// The state or province of the shipping or billing address.
            /// </summary>
            public string State { get; set; }

            /// <summary>
            /// The state or province of the shipping or billing address.
            /// </summary>
            public string StateProvince { get; set; }
        }


        [XmlRoot("LineItem")]
        public class LineItem
        {

            /// <summary>
            /// Account Code of the line item. ExpenseType OR AccountCode must be supplied, but not both.  Required, if ExpenseType is not supplied.
            /// </summary>
            public string AccountCode { get; set; }

            /// <summary>
            /// Details the allocations that are associated to the line item. Allocation elements can be repeated within the same line items to represent multiple allocations.
            /// </summary>
            [XmlArrayItem("Allocation")]
            public Allocation[] Allocation { get; set; }

            /// <summary>
            /// The date the line item was created. Format YYYY-MM-DD.
            /// </summary>
            public string CreateDate { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 1 that is part of the purchase order line item form.
            /// </summary>
            public string Custom1 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 10 that is part of the purchase order line item form.
            /// </summary>
            public string Custom10 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 11 that is part of the purchase order line item form.
            /// </summary>
            public string Custom11 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 12 that is part of the purchase order line item form.
            /// </summary>
            public string Custom12 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 13 that is part of the purchase order line item form.
            /// </summary>
            public string Custom13 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 14 that is part of the purchase order line item form.
            /// </summary>
            public string Custom14 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 15 that is part of the purchase order line item form.
            /// </summary>
            public string Custom15 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 16 that is part of the purchase order line item form.
            /// </summary>
            public string Custom16 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 17 that is part of the purchase order line item form.
            /// </summary>
            public string Custom17 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 18 that is part of the purchase order line item form.
            /// </summary>
            public string Custom18 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 19 that is part of the purchase order line item form.
            /// </summary>
            public string Custom19 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 2 that is part of the purchase order line item form.
            /// </summary>
            public string Custom2 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 20 that is part of the purchase order line item form.
            /// </summary>
            public string Custom20 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 3 that is part of the purchase order line item form.
            /// </summary>
            public string Custom3 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 4 that is part of the purchase order line item form.
            /// </summary>
            public string Custom4 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 5 that is part of the purchase order line item form.
            /// </summary>
            public string Custom5 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 6 that is part of the purchase order line item form.
            /// </summary>
            public string Custom6 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 7 that is part of the purchase order line item form.
            /// </summary>
            public string Custom7 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 8 that is part of the purchase order line item form.
            /// </summary>
            public string Custom8 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 9 that is part of the purchase order line item form.
            /// </summary>
            public string Custom9 { get; set; }

            /// <summary>
            /// A description of the line item.
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// Expense Type of the line item.  ExpenseType OR AccountCode must be supplied, but not both. Required, if AccountCode is not supplied.
            /// </summary>
            public string ExpenseType { get; set; }

            /// <summary>
            /// A customer supplied value that uniquely identifies the line item within purchase order.
            /// </summary>
            public string ExternalID { get; set; }

            /// <summary>
            /// Whether the purchase order requires receipt. Format: true/false.
            /// </summary>
            public string IsReceiptRequired { get; set; }

            /// <summary>
            /// The line item number within the purchase order.
            /// </summary>
            public string LineNumber { get; set; }

            /// <summary>
            /// The quantity associated to the line item.
            /// </summary>
            public string Quantity { get; set; }

            /// <summary>
            /// The person that requests the goods associated to the line item of the purchase order.
            /// </summary>
            public string RequestedBy { get; set; }

            /// <summary>
            /// The date the line item of the purchase order instructed the vendor to deliver the goods. Format YYYY-MM-DD.
            /// </summary>
            public string RequestedDeliveryDate { get; set; }

            /// <summary>
            /// Any number that might help to identify the line item, it may be values such as the supplier part number or even the manufacturer number.
            /// </summary>
            public string SupplierPartID { get; set; }

            /// <summary>
            /// Any tax that is associated to the line item.
            /// </summary>
            public string Tax { get; set; }

            /// <summary>
            /// The price of each item of the line item.
            /// </summary>
            public string UnitPrice { get; set; }
        }


        [XmlRoot("PurchaseOrder")]
        public class PurchaseOrder
        {

            /// <summary>
            /// The customer's billing address, which is where the vendor should send the bill.
            /// </summary>
            public BillToAddress BillToAddress { get; set; }

            /// <summary>
            /// The 3-letter ISO 4217 <a target="_blank" href="http://en.wikipedia.org/wiki/ISO_4217"> currency code</a> of the currency that is associated to the purchase order.
            /// </summary>
            public string CurrencyCode { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 1 that is part of the purchase order header form.
            /// </summary>
            public string Custom1 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 10 that is part of the purchase order header form.
            /// </summary>
            public string Custom10 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 11 that is part of the purchase order header form.
            /// </summary>
            public string Custom11 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 12 that is part of the purchase order header form.
            /// </summary>
            public string Custom12 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 13 that is part of the purchase order header form.
            /// </summary>
            public string Custom13 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 14 that is part of the purchase order header form.
            /// </summary>
            public string Custom14 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 15 that is part of the purchase order header form.
            /// </summary>
            public string Custom15 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 16 that is part of the purchase order header form.
            /// </summary>
            public string Custom16 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 17 that is part of the purchase order header form.
            /// </summary>
            public string Custom17 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 18 that is part of the purchase order header form.
            /// </summary>
            public string Custom18 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 19 that is part of the purchase order header form.
            /// </summary>
            public string Custom19 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 2 that is part of the purchase order header form.
            /// </summary>
            public string Custom2 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 20 that is part of the purchase order header form.
            /// </summary>
            public string Custom20 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 21 that is part of the purchase order header form.
            /// </summary>
            public string Custom21 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 22 that is part of the purchase order header form.
            /// </summary>
            public string Custom22 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 23 that is part of the purchase order header form.
            /// </summary>
            public string Custom23 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 24 that is part of the purchase order header form.
            /// </summary>
            public string Custom24 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 3 that is part of the purchase order header form.
            /// </summary>
            public string Custom3 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 4 that is part of the purchase order header form.
            /// </summary>
            public string Custom4 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 5 that is part of the purchase order header form.
            /// </summary>
            public string Custom5 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 6 that is part of the purchase order header form.
            /// </summary>
            public string Custom6 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 7 that is part of the purchase order header form.
            /// </summary>
            public string Custom7 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 8 that is part of the purchase order header form.
            /// </summary>
            public string Custom8 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 9 that is part of the purchase order header form.
            /// </summary>
            public string Custom9 { get; set; }

            /// <summary>
            /// A description of the overall purchase order.
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// The discount from the supplier if the discount terms are met.
            /// </summary>
            public string DiscountPercentage { get; set; }

            /// <summary>
            /// The NET discount terms with a supplier when discounts apply.
            /// </summary>
            public string DiscountTerms { get; set; }

            /// <summary>
            /// The unique identifier of the resource.
            /// </summary>
            public string ID { get; set; }

            /// <summary>
            /// Line Items of a purchase order.
            /// </summary>
            [XmlArrayItem("LineItem")]
            public LineItem[] LineItem { get; set; }

            /// <summary>
            /// A name to the overall purchase order.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// The date by which the purchase order must be fulfilled. Format: YYYY-MM-DD.
            /// </summary>
            public string NeededByDate { get; set; }

            /// <summary>
            /// The date goods were ordered. Format YYYY-MM-DD.
            /// </summary>
            public string OrderDate { get; set; }

            /// <summary>
            /// The NET payment terms with a supplier.
            /// </summary>
            public string PaymentTerms { get; set; }

            /// <summary>
            /// This is the external identifier of the policy that should be associated to the purchase order. External id is a property of the policy within configurations.
            /// </summary>
            public string PolicyExternalID { get; set; }

            /// <summary>
            /// The purchase order number.
            /// </summary>
            public string PurchaseOrderNumber { get; set; }

            /// <summary>
            /// The person that requests the goods associated to the purchase order.
            /// </summary>
            public string RequestedBy { get; set; }

            /// <summary>
            /// The date the purchase order instructed the vendor to deliver the goods. Format YYYY-MM-DD.
            /// </summary>
            public string RequestedDeliveryDate { get; set; }

            /// <summary>
            /// The overall shipping cost of the purchase order.
            /// </summary>
            public string Shipping { get; set; }

            /// <summary>
            /// Describes how the goods associated to the purchase order are going to be shipping, i.e. via FedEx.
            /// </summary>
            public string ShippingDescription { get; set; }

            /// <summary>
            /// The code representing the shipping method used by the supplier. Maximum 10 characters.
            /// </summary>
            public string ShippingMethodKey { get; set; }

            /// <summary>
            /// The code representing shipping terms with a supplier. Maximum 10 characters.
            /// </summary>
            public string ShippingTermsKey { get; set; }

            /// <summary>
            /// The customer's shipping address, which is where the vendor should ship the goods.
            /// </summary>
            public ShipToAddress ShipToAddress { get; set; }

            /// <summary>
            /// The overall tax of the purchase order.
            /// </summary>
            public string Tax { get; set; }

            /// <summary>
            /// The URI to the resource.
            /// </summary>
            public string URI { get; set; }

            /// <summary>
            /// The vendor account number.
            /// </summary>
            public string VendorAccountNumber { get; set; }

            /// <summary>
            /// The code that identifies the vendors remit address that should be associated to the purchase order.
            /// </summary>
            public string VendorAddressCode { get; set; }

            /// <summary>
            /// The code that identifies the vendor that should be associated to the purchase order.
            /// </summary>
            public string VendorCode { get; set; }
        }


        [XmlRoot("ShipToAddress")]
        public class ShipToAddress
        {

            /// <summary>
            /// Address 1 of the shipping or billing address.
            /// </summary>
            public string Address1 { get; set; }

            /// <summary>
            /// Address 2 of the shipping or billing address.
            /// </summary>
            public string Address2 { get; set; }

            /// <summary>
            /// Address 3 of the shipping or billing address.
            /// </summary>
            public string Address3 { get; set; }

            /// <summary>
            /// The city of the shipping or billing address.
            /// </summary>
            public string City { get; set; }

            /// <summary>
            /// The code of the country associated to the shipping or billing address.
            /// </summary>
            public string CountryCode { get; set; }

            /// <summary>
            /// A unique value supplied by the customer to identify a particular shipping or billing address.
            /// </summary>
            public string ExternalID { get; set; }

            /// <summary>
            /// An optional name that can be given to the shipping and billing address.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// The postal code of the shipping or billing address.
            /// </summary>
            public string PostalCode { get; set; }

            /// <summary>
            /// The state or province of the shipping or billing address.
            /// </summary>
            public string State { get; set; }

            /// <summary>
            /// The state or province of the shipping or billing address.
            /// </summary>
            public string StateProvince { get; set; }
        }

        /// <summary>
        /// QuickExpenses
        /// </summary>
        [XmlRoot("QuickExpenses")]
        public class QuickExpenseCollection
        {

            /// <summary>
            /// The result collection.
            /// </summary>
            [XmlArrayItem("QuickExpense")]
            public QuickExpenseGet[] Items { get; set; }

            /// <summary>
            /// The URI of the next page of results, if any.
            /// </summary>
            public string NextPage { get; set; }

            /// <summary>
            /// The offset value to be used when iterating to get the next page of objects.
            /// </summary>
            public virtual string NextPageOffset() { return this.Util.GetQueryStringValue(NextPage, "offset"); }

            /// <summary>
            /// The flag used to indicate whether the current page of objects is the last one in the sequence.
            /// </summary>
            public virtual bool IsEndOfPagination() { return string.IsNullOrWhiteSpace(NextPageOffset()); }

            protected ConcurUtil Util = new ConcurUtil();
        }

        /// <summary>
        /// QuickExpense
        /// </summary>
        [XmlRoot("QuickExpense")]
        public class QuickExpenseGet
        {

            /// <summary>
            /// A comment that describes the expense. Max Length: 2000
            /// </summary>
            public string Comment { get; set; }

            /// <summary>
            /// The <a target="_blank" href="http://en.wikipedia.org/wiki/ISO_4217">3-letter ISO 4217 currency code</a> for the expense transaction amount. Example: USD
            /// </summary>
            public string CurrencyCode { get; set; }

            /// <summary>
            /// The code for the expense type in the company's expense management system. Currently supports Concur Expense codes. The Expense Type Code is returned in the ExpKey element of the <a target="_blank" href="https://developer.concur.com/node/473">Get Expense Group Configuration</a> function response.
            /// </summary>
            public string ExpenseTypeCode { get; set; }

            /// <summary>
            /// The name of the expense type associated with the quick expense.
            /// </summary>
            public string ExpenseTypeName { get; set; }

            /// <summary>
            /// The unique identifier of the resource.
            /// </summary>
            public string ID { get; set; }

            /// <summary>
            /// The name of the location where the expense was incurred.
            /// </summary>
            public string LocationName { get; set; }

            /// <summary>
            /// The Concur login ID for the expense owner. Useful for system to system integration when there are expenses for multiple users.
            /// </summary>
            public string OwnerLoginID { get; set; }

            /// <summary>
            /// The first and last name for the expense owner. Useful for system to system integration when there are expenses for multiple users.
            /// </summary>
            public string OwnerName { get; set; }

            /// <summary>
            /// This element specifies the method of payment for the expense. Format: CASHX = Cash, CPAID = Company Paid, or PENDC = Pending Card Transaction (default)
            /// </summary>
            public string PaymentTypeCode { get; set; }

            /// <summary>
            /// The ID of the receipt image associated with this quick expense, if any.
            /// </summary>
            public string ReceiptImageID { get; set; }

            /// <summary>
            /// The total amount of the expense in the original currency, with up to three decimal places. Example: 123.654
            /// </summary>
            public decimal? TransactionAmount { get; set; }

            /// <summary>
            /// The date the expense was incurred. Format: YYYY-MM-DD
            /// </summary>
            public DateTime? TransactionDate { get; set; }

            /// <summary>
            /// The URI to the resource.
            /// </summary>
            public string URI { get; set; }

            /// <summary>
            /// The descriptive text for the vendor for the quick expense. This often matches the Merchant Name found in a credit card transaction.  Max Length: 64
            /// </summary>
            public string VendorDescription { get; set; }
        }

        /// <summary>
        /// QuickExpense
        /// </summary>
        [XmlRoot("QuickExpense")]
        public class QuickExpensePost
        {

            /// <summary>
            /// A comment that describes the expense. Max Length: 2000
            /// </summary>
            public string Comment { get; set; }

            /// <summary>
            /// The <a target="_blank" href="http://en.wikipedia.org/wiki/ISO_4217">3-letter ISO 4217 currency code</a> for the expense transaction amount. Example: USD
            /// </summary>
            public string CurrencyCode { get; set; }

            /// <summary>
            /// The code for the expense type in the company's expense management system. Currently supports Concur Expense codes. The Expense Type Code is returned in the ExpKey element of the <a target="_blank" href="https://developer.concur.com/node/473">Get Expense Group Configuration</a> function response.
            /// </summary>
            public string ExpenseTypeCode { get; set; }

            /// <summary>
            /// The city where the expense was incurred. This is used to determine the Location ID when the quick expense is converted into an expense entry.<br/><br/>If you provide both the LocationCity and LocationCountry values, Concur will try to match them with the company's list of locations. If they are matched successfully, the full location details including country will be saved with the expense.<br/><br/>If a LocationCity is provided, the LocationCountry and LocationSubdivision must be provided. If a country does not have subdivisions, the LocationSubdivision field may be omitted.
            /// </summary>
            public string LocationCity { get; set; }

            /// <summary>
            /// The country where the expense was incurred. This is used to determine the Location ID when the quick expense is converted into an expense entry. Format: 2-letter <a target="_blank" href="http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2">ISO 3166-1</a> country code.
            /// </summary>
            public string LocationCountry { get; set; }

            /// <summary>
            /// The state, province, or other country subdivision where the expense was incurred. This is used to determine the Location ID when the quick expense is converted into an expense entry. Format: <a target="_blank" href="http://en.wikipedia.org/wiki/ISO_3166-2:2007-04-17#I-8">ISO 3166-2:2007</a> country subdivision.
            /// </summary>
            public string LocationSubdivision { get; set; }

            /// <summary>
            /// This element specifies the method of payment for the expense. Format: CASHX = Cash, CPAID = Company Paid, or PENDC = Pending Card Transaction (default)
            /// </summary>
            public string PaymentTypeCode { get; set; }

            /// <summary>
            /// The unique identifier for the image. The ReceiptImageID is returned in the ID element of the Post Receipt Image API response.
            /// </summary>
            public string ReceiptImageID { get; set; }

            /// <summary>
            /// The spend category code for the quick expense. The available spend category codes are consistent across all Concur products. The values are used in Concur reporting.  Format: One of the Code values in the <a target="_blank" href="https://developer.concur.com/node/557">Spend Category Code List.  Developers can view the configured Spend Category/Expense Type mappings by using the <a target="_blank" href="https://developer.concur.com/node/473">Get Expense Group Configuration</a> function.</a>
            /// </summary>
            public string SpendCategoryCode { get; set; }

            /// <summary>
            /// The total amount of the expense in the original currency, with up to three decimal places. Example: 123.654
            /// </summary>
            public decimal? TransactionAmount { get; set; }

            /// <summary>
            /// The date the expense was incurred. Format: YYYY-MM-DD
            /// </summary>
            public DateTime? TransactionDate { get; set; }

            /// <summary>
            /// The descriptive text for the vendor for the quick expense. This often matches the Merchant Name found in a credit card transaction.  Max Length: 64
            /// </summary>
            public string VendorDescription { get; set; }
        }

        /// <summary>
        /// QuickExpense
        /// </summary>
        [XmlRoot("QuickExpense")]
        public class QuickExpensePut
        {

            /// <summary>
            /// A comment that describes the expense. Max Length: 2000
            /// </summary>
            public string Comment { get; set; }

            /// <summary>
            /// The <a target="_blank" href="http://en.wikipedia.org/wiki/ISO_4217">3-letter ISO 4217 currency code</a> for the expense transaction amount. Example: USD
            /// </summary>
            public string CurrencyCode { get; set; }

            /// <summary>
            /// The code for the expense type in the company's expense management system. Currently supports Concur Expense codes. The Expense Type Code is returned in the ExpKey element of the <a target="_blank" href="https://developer.concur.com/node/473">Get Expense Group Configuration</a> function response.
            /// </summary>
            public string ExpenseTypeCode { get; set; }

            /// <summary>
            /// The city where the expense was incurred. This is used to determine the Location ID when the quick expense is converted into an expense entry.<br/><br/>If you provide both the LocationCity and LocationCountry values, Concur will try to match them with the company's list of locations. If they are matched successfully, the full location details including country will be saved with the expense.<br/><br/>If a LocationCity is provided, the LocationCountry and LocationSubdivision must be provided. If a country does not have subdivisions, the LocationSubdivision field may be omitted.
            /// </summary>
            public string LocationCity { get; set; }

            /// <summary>
            /// The country where the expense was incurred. This is used to determine the Location ID when the quick expense is converted into an expense entry. Format: 2-letter <a target="_blank" href="http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2">ISO 3166-1</a> country code.
            /// </summary>
            public string LocationCountry { get; set; }

            /// <summary>
            /// The state, province, or other country subdivision where the expense was incurred. This is used to determine the Location ID when the quick expense is converted into an expense entry. Format: <a target="_blank" href="http://en.wikipedia.org/wiki/ISO_3166-2:2007-04-17#I-8">ISO 3166-2:2007</a> country subdivision.
            /// </summary>
            public string LocationSubdivision { get; set; }

            /// <summary>
            /// This element specifies the method of payment for the expense. Format: CASHX = Cash, CPAID = Company Paid, or PENDC = Pending Card Transaction (default)
            /// </summary>
            public string PaymentTypeCode { get; set; }

            /// <summary>
            /// The unique identifier for the image. The ReceiptImageID is returned in the ID element of the Post Receipt Image API response.
            /// </summary>
            public string ReceiptImageID { get; set; }

            /// <summary>
            /// The spend category code for the quick expense. The available spend category codes are consistent across all Concur products. The values are used in Concur reporting.  Format: One of the Code values in the <a target="_blank" href="https://developer.concur.com/node/557">Spend Category Code List.  Developers can view the configured Spend Category/Expense Type mappings by using the <a target="_blank" href="https://developer.concur.com/node/473">Get Expense Group Configuration</a> function.</a>
            /// </summary>
            public string SpendCategoryCode { get; set; }

            /// <summary>
            /// The total amount of the expense in the original currency, with up to three decimal places. Example: 123.654
            /// </summary>
            public decimal? TransactionAmount { get; set; }

            /// <summary>
            /// The date the expense was incurred. Format: YYYY-MM-DD
            /// </summary>
            public DateTime? TransactionDate { get; set; }

            /// <summary>
            /// The descriptive text for the vendor for the quick expense. This often matches the Merchant Name found in a credit card transaction.  Max Length: 64
            /// </summary>
            public string VendorDescription { get; set; }
        }


        [XmlRoot("ReceiptImage")]
        public class ReceiptImage
        {

            /// <summary>
            /// The unique identifier of the resource.
            /// </summary>
            public string ID { get; set; }

            /// <summary>
            /// The URI to the resource.
            /// </summary>
            public string URI { get; set; }
        }

        /// <summary>
        /// ReceiptImages
        /// </summary>
        [XmlRoot("ReceiptImages")]
        public class ReceiptImageCollection
        {

            /// <summary>
            /// The result collection.
            /// </summary>
            [XmlArrayItem("ReceiptImage")]
            public ReceiptImage[] Items { get; set; }

            /// <summary>
            /// The URI of the next page of results, if any.
            /// </summary>
            public string NextPage { get; set; }

            /// <summary>
            /// The offset value to be used when iterating to get the next page of objects.
            /// </summary>
            public virtual string NextPageOffset() { return this.Util.GetQueryStringValue(NextPage, "offset"); }

            /// <summary>
            /// The flag used to indicate whether the current page of objects is the last one in the sequence.
            /// </summary>
            public virtual bool IsEndOfPagination() { return string.IsNullOrWhiteSpace(NextPageOffset()); }

            protected ConcurUtil Util = new ConcurUtil();
        }


        [XmlRoot("ReportDigest")]
        public class ReportDigest
        {

            /// <summary>
            /// The approval status code for the report.
            /// </summary>
            public string ApprovalStatusCode { get; set; }

            /// <summary>
            /// The report's approval status, in the OAuth consumer's language.
            /// </summary>
            public string ApprovalStatusName { get; set; }

            /// <summary>
            /// The Login ID of the report owner's expense approver.
            /// </summary>
            public string ApproverLoginID { get; set; }

            /// <summary>
            /// The name of the report owner's expense approver.
            /// </summary>
            public string ApproverName { get; set; }

            /// <summary>
            /// The report country. Maximum 2 characters. Format: The ISO 3166-1 alpha-2 country code. Example: United States is US.
            /// </summary>
            public string Country { get; set; }

            /// <summary>
            /// The report country subdivision.  Format: ISO 3166-2:2007 country subdivision.
            /// </summary>
            public string CountrySubdivision { get; set; }

            /// <summary>
            /// The date the report was created.
            /// </summary>
            public DateTime? CreateDate { get; set; }

            /// <summary>
            /// The <a target="_blank" href="http://en.wikipedia.org/wiki/ISO_4217\">3-letter ISO 4217 currency code</a> for the expense report currency. Examples: USD - US dollars; BRL - Brazilian real; CAD - Canadian dollar; CHF - Swiss franc; EUR - Euro; GBO - Pound sterling; HKD - Hong Kong dollar; INR - Indian rupee; MXN - Mexican peso; NOK - Norwegian krone; SEK - Swedish krona.
            /// </summary>
            public string CurrencyCode { get; set; }

            /// <summary>
            /// The unique identifier of the resource.
            /// </summary>
            public string ID { get; set; }

            /// <summary>
            /// The text of the most recent comment on the report.
            /// </summary>
            public string LastComment { get; set; }

            /// <summary>
            /// The name of the report.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// The Login ID of the user this report belongs to.
            /// </summary>
            public string OwnerLoginID { get; set; }

            /// <summary>
            /// The name of the expense report owner.
            /// </summary>
            public string OwnerName { get; set; }

            /// <summary>
            /// The date when all journal entries in the report was integrated with or extracted to the financial system.
            /// </summary>
            public DateTime? PaidDate { get; set; }

            /// <summary>
            /// The code for the payment status of the report.
            /// </summary>
            public string PaymentStatusCode { get; set; }

            /// <summary>
            /// The report's payment status, in the OAuth consumer's language.
            /// </summary>
            public string PaymentStatusName { get; set; }

            /// <summary>
            /// The date that the report completed all approvals and was ready to be extracted for payment.
            /// </summary>
            public DateTime? ProcessingPaymentDate { get; set; }

            /// <summary>
            /// The date the report header was last modified.
            /// </summary>
            public DateTime? ReportHeaderLastModifiedDate { get; set; }

            /// <summary>
            /// The date the report was submitted.
            /// </summary>
            public DateTime? SubmitDate { get; set; }

            /// <summary>
            /// The total amount of the report.
            /// </summary>
            public decimal? Total { get; set; }

            /// <summary>
            /// The URI to the resource.
            /// </summary>
            public string URI { get; set; }

            /// <summary>
            /// The date of the report assigned by the user.
            /// </summary>
            public DateTime? UserDefinedDate { get; set; }
        }

        /// <summary>
        /// ReportDigests
        /// </summary>
        [XmlRoot("ReportDigests")]
        public class ReportDigestCollection
        {

            /// <summary>
            /// The result collection.
            /// </summary>
            [XmlArrayItem("ReportDigest")]
            public ReportDigest[] Items { get; set; }

            /// <summary>
            /// The URI of the next page of results, if any.
            /// </summary>
            public string NextPage { get; set; }

            /// <summary>
            /// The offset value to be used when iterating to get the next page of objects.
            /// </summary>
            public virtual string NextPageOffset() { return this.Util.GetQueryStringValue(NextPage, "offset"); }

            /// <summary>
            /// The flag used to indicate whether the current page of objects is the last one in the sequence.
            /// </summary>
            public virtual bool IsEndOfPagination() { return string.IsNullOrWhiteSpace(NextPageOffset()); }

            protected ConcurUtil Util = new ConcurUtil();
        }

        /// <summary>
        /// Reports
        /// </summary>
        [XmlRoot("Reports")]
        public class ReportCollection
        {

            /// <summary>
            /// The result collection.
            /// </summary>
            [XmlArrayItem("Report")]
            public ReportGet[] Items { get; set; }

            /// <summary>
            /// The URI of the next page of results, if any.
            /// </summary>
            public string NextPage { get; set; }

            /// <summary>
            /// The offset value to be used when iterating to get the next page of objects.
            /// </summary>
            public virtual string NextPageOffset() { return this.Util.GetQueryStringValue(NextPage, "offset"); }

            /// <summary>
            /// The flag used to indicate whether the current page of objects is the last one in the sequence.
            /// </summary>
            public virtual bool IsEndOfPagination() { return string.IsNullOrWhiteSpace(NextPageOffset()); }

            protected ConcurUtil Util = new ConcurUtil();
        }

        /// <summary>
        /// Report
        /// </summary>
        [XmlRoot("Report")]
        public class ReportGet
        {

            /// <summary>
            /// The total amount due to the company card for the report. Maximum 23 characters.
            /// </summary>
            public decimal? AmountDueCompanyCard { get; set; }

            /// <summary>
            /// The total amount due to the employee for the report. Maximum 23 characters.
            /// </summary>
            public decimal? AmountDueEmployee { get; set; }

            /// <summary>
            /// The approval status code for the report.
            /// </summary>
            public string ApprovalStatusCode { get; set; }

            /// <summary>
            /// The report's approval status, in the OAuth consumer's language.
            /// </summary>
            public string ApprovalStatusName { get; set; }

            /// <summary>
            /// The Login ID of the report owner's expense approver.
            /// </summary>
            public string ApproverLoginID { get; set; }

            /// <summary>
            /// The name of the report owner's expense approver.
            /// </summary>
            public string ApproverName { get; set; }

            /// <summary>
            /// The report country. Maximum 2 characters. Format: The ISO 3166-1 alpha-2 country code. Example: United States is US.
            /// </summary>
            public string Country { get; set; }

            /// <summary>
            /// The report country subdivision.  Format: ISO 3166-2:2007 country subdivision.
            /// </summary>
            public string CountrySubdivision { get; set; }

            /// <summary>
            /// The date the report was created.
            /// </summary>
            public DateTime? CreateDate { get; set; }

            /// <summary>
            /// The <a target="_blank" href="http://en.wikipedia.org/wiki/ISO_4217\">3-letter ISO 4217 currency code</a> for the expense report currency. Examples: USD - US dollars; BRL - Brazilian real; CAD - Canadian dollar; CHF - Swiss franc; EUR - Euro; GBO - Pound sterling; HKD - Hong Kong dollar; INR - Indian rupee; MXN - Mexican peso; NOK - Norwegian krone; SEK - Swedish krona.
            /// </summary>
            public string CurrencyCode { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom1 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom10 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom11 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom12 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom13 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom14 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom15 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom16 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom17 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom18 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom19 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom2 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom20 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom3 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom4 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom5 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom6 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom7 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom8 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField Custom9 { get; set; }

            /// <summary>
            /// Whether the report has ever been sent back to the employee. Format: Y/N
            /// </summary>
            public bool? EverSentBack { get; set; }

            /// <summary>
            /// Whether the report has exceptions. Format: Y/N 
            /// </summary>
            public bool? HasException { get; set; }

            /// <summary>
            /// The unique identifier of the resource.
            /// </summary>
            public string ID { get; set; }

            /// <summary>
            /// The text of the most recent comment on the report.
            /// </summary>
            public string LastComment { get; set; }

            /// <summary>
            /// The date the report header was last modified.
            /// </summary>
            public DateTime? LastModifiedDate { get; set; }

            /// <summary>
            /// The name of the expense report ledger. Maximum 20 characters.
            /// </summary>
            public string LedgerName { get; set; }

            /// <summary>
            /// The name of the report.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField OrgUnit1 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField OrgUnit2 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField OrgUnit3 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField OrgUnit4 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField OrgUnit5 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public CustomField OrgUnit6 { get; set; }

            /// <summary>
            /// The Login ID of the user this report belongs to.
            /// </summary>
            public string OwnerLoginID { get; set; }

            /// <summary>
            /// The name of the expense report owner.
            /// </summary>
            public string OwnerName { get; set; }

            /// <summary>
            /// The date when all journal entries in the report was integrated with or extracted to the financial system.
            /// </summary>
            public DateTime? PaidDate { get; set; }

            /// <summary>
            /// The code for the payment status of the report.
            /// </summary>
            public string PaymentStatusCode { get; set; }

            /// <summary>
            /// The report's payment status, in the OAuth consumer's language.
            /// </summary>
            public string PaymentStatusName { get; set; }

            /// <summary>
            /// The total amount of expenses marked as personal. Maximum 23 characters.
            /// </summary>
            public decimal? PersonalAmount { get; set; }

            /// <summary>
            /// The unique identifier of the policy that applies to this report. Maximum 64 characters.
            /// </summary>
            public string PolicyID { get; set; }

            /// <summary>
            /// The date that the report completed all approvals and was ready to be extracted for payment.
            /// </summary>
            public DateTime? ProcessingPaymentDate { get; set; }

            /// <summary>
            /// If Y, then this report has its receipt receipt confirmed by the Expense Processor. Format: Y/N
            /// </summary>
            public bool? ReceiptsReceived { get; set; }

            /// <summary>
            /// The date the report was submitted.
            /// </summary>
            public DateTime? SubmitDate { get; set; }

            /// <summary>
            /// The total amount of the report.
            /// </summary>
            public decimal? Total { get; set; }

            /// <summary>
            /// The total amount of approved expenses in the report. Maximum 23 characters.
            /// </summary>
            public decimal? TotalApprovedAmount { get; set; }

            /// <summary>
            /// The total amount of all non-personal expenses in the report. Maximum 23 characters.
            /// </summary>
            public decimal? TotalClaimedAmount { get; set; }

            /// <summary>
            /// The URI to the resource.
            /// </summary>
            public string URI { get; set; }

            /// <summary>
            /// The date of the report assigned by the user.
            /// </summary>
            public DateTime? UserDefinedDate { get; set; }

            /// <summary>
            /// The URL to post a workflow action to the report using the Post Report Workflow Action function.
            /// </summary>
            public string WorkflowActionUrl { get; set; }
        }

        /// <summary>
        /// Report
        /// </summary>
        [XmlRoot("Report")]
        public class ReportPost
        {

            /// <summary>
            /// The report header comment. Maximum length: 500.
            /// </summary>
            public string Comment { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom1 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom10 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom11 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom12 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom13 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom14 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom15 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom16 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom17 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom18 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom19 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom2 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom20 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom3 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom4 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom5 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom6 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom7 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom8 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom9 { get; set; }

            /// <summary>
            /// The name of the report.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public string OrgUnit1 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public string OrgUnit2 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public string OrgUnit3 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public string OrgUnit4 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public string OrgUnit5 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public string OrgUnit6 { get; set; }

            /// <summary>
            /// The unique identifier for the policy.  This is the protected, Policy Key
            /// </summary>
            public string PolicyID { get; set; }

            /// <summary>
            /// The business purpose of the report. Maximum length: 500.
            /// </summary>
            public string Purpose { get; set; }

            /// <summary>
            /// The date of the report assigned by the user.
            /// </summary>
            public DateTime? UserDefinedDate { get; set; }
        }

        /// <summary>
        /// Report
        /// </summary>
        [XmlRoot("Report")]
        public class ReportPut
        {

            /// <summary>
            /// The report header comment. Maximum length: 500.
            /// </summary>
            public string Comment { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom1 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom10 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom11 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom12 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom13 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom14 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom15 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom16 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom17 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom18 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom19 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom2 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom20 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom3 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom4 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom5 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom6 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom7 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom8 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string Custom9 { get; set; }

            /// <summary>
            /// The name of the report.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public string OrgUnit1 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public string OrgUnit2 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public string OrgUnit3 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public string OrgUnit4 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public string OrgUnit5 { get; set; }

            /// <summary>
            /// The details from the Org Unit fields. These may not have data, depending on configuration.
            /// </summary>
            public string OrgUnit6 { get; set; }

            /// <summary>
            /// The unique identifier for the policy.  This is the protected, Policy Key
            /// </summary>
            public string PolicyID { get; set; }

            /// <summary>
            /// The business purpose of the report. Maximum length: 500.
            /// </summary>
            public string Purpose { get; set; }

            /// <summary>
            /// The date of the report assigned by the user.
            /// </summary>
            public DateTime? UserDefinedDate { get; set; }
        }

        /// <summary>
        /// Comments
        /// </summary>
        [XmlRoot("Comments")]
        public class Comments
        {

            /// <summary>
            /// The text of the travel request header comment.
            /// </summary>
            public string Comment { get; set; }

            /// <summary>
            /// Time, in GMT, when the user made the comment.
            /// </summary>
            public DateTime? CommentDateTime { get; set; }

            /// <summary>
            /// The first name of the person who made the comment.
            /// </summary>
            public string FirstName { get; set; }

            /// <summary>
            /// Indicates that the comment is the last one.
            /// </summary>
            public bool IsLatest { get; set; }

            /// <summary>
            /// The last name of the person who made the comment.
            /// </summary>
            public string LastName { get; set; }
        }

        /// <summary>
        /// Requests
        /// </summary>
        [XmlRoot("Requests")]
        public class RequestCollection
        {

            /// <summary>
            /// The result collection.
            /// </summary>
            [XmlArrayItem("Request")]
            public TravelRequestHeader[] Items { get; set; }

            /// <summary>
            /// The URI of the next page of results, if any.
            /// </summary>
            public string NextPage { get; set; }

            /// <summary>
            /// The offset value to be used when iterating to get the next page of objects.
            /// </summary>
            public virtual string NextPageOffset() { return this.Util.GetQueryStringValue(NextPage, "offset"); }

            /// <summary>
            /// The flag used to indicate whether the current page of objects is the last one in the sequence.
            /// </summary>
            public virtual bool IsEndOfPagination() { return string.IsNullOrWhiteSpace(NextPageOffset()); }

            protected ConcurUtil Util = new ConcurUtil();
        }

        /// <summary>
        /// RequestEntry
        /// </summary>
        [XmlRoot("RequestEntry")]
        public class RequestEntry
        {

            /// <summary>
            /// The number of allocations associated with the travel request entry.
            /// </summary>
            public Int32 AllocationCount { get; set; }

            /// <summary>
            /// This parent element has an Allocation child element for each associated allocation. Refer to the Allocation model for the full list of child elements.
            /// </summary>
            [XmlArrayItem("Allocation")]
            public Allocation[] AllocationsList { get; set; }

            /// <summary>
            /// The approved amount of the travel request entry in the travel request currency.
            /// </summary>
            public string ApprovedAmount { get; set; }

            /// <summary>
            /// The number of comments associated with the travel request entry.
            /// </summary>
            public Int32 CommentCount { get; set; }

            /// <summary>
            /// This parent element has a Count attribute indicating the number of comments that are included in the travel request entry. It has a Comment child element for each comment. Refer to the Comments model for the full list of child elements.
            /// </summary>
            [XmlArrayItem("Comments")]
            public Comments[] CommentsList { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom1 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom10 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom11 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom12 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom13 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom14 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom15 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom16 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom17 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom18 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom19 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom2 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom20 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom21 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom22 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom23 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom24 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom25 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom26 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom27 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom28 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom29 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom3 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom30 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom31 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom32 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom33 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom34 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom35 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom36 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom37 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom38 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom39 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom4 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom40 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom5 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom6 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom7 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom8 { get; set; }

            /// <summary>
            /// The custom fields associated with the entry. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 >
            /// </summary>
            public string Custom9 { get; set; }

            /// <summary>
            /// The text from the Description field for the entry.
            /// </summary>
            public string EntryDescription { get; set; }

            /// <summary>
            /// The number of exceptions associated with the travel request entry.
            /// </summary>
            public Int32 ExceptionCount { get; set; }

            /// <summary>
            /// This parent element has a Count attribute indicating the number of exceptions that are included in the travel request entry. It has an Exception child element for each exception. Refer to the Exception model for the full list of child elements.
            /// </summary>
            [XmlArrayItem("Exception")]
            public TRException[] ExceptionsList { get; set; }

            /// <summary>
            /// The exchange rate that applies to the entry.
            /// </summary>
            public string ExchangeRate { get; set; }

            /// <summary>
            /// The expense type name.
            /// </summary>
            public string ExpenseTypeName { get; set; }

            /// <summary>
            /// The foreign currency amount of the travel request entry.
            /// </summary>
            public string ForeignAmount { get; set; }

            /// <summary>
            /// The <a target="_blank" href="http://en.wikipedia.org/wiki/ISO_4217">3-letter ISO 4217 currency code</a> foreign amount currency of the entry.
            /// </summary>
            public string ForeignCurrencyCode { get; set; }

            /// <summary>
            /// The name of the currency for the foreign amount.
            /// </summary>
            public string ForeignCurrencyName { get; set; }

            /// <summary>
            /// The date the entry was last modified. Format: YYYY-MM-DDThh:mm:ss
            /// </summary>
            public DateTime? LastModifiedDate { get; set; }

            /// <summary>
            /// The details from the Org Unit custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string OrgUnit1 { get; set; }

            /// <summary>
            /// The details from the Org Unit custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string OrgUnit2 { get; set; }

            /// <summary>
            /// The details from the Org Unit custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string OrgUnit3 { get; set; }

            /// <summary>
            /// The details from the Org Unit custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string OrgUnit4 { get; set; }

            /// <summary>
            /// The details from the Org Unit custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string OrgUnit5 { get; set; }

            /// <summary>
            /// The details from the Org Unit custom fields. These may not have data, depending on configuration.
            /// </summary>
            public string OrgUnit6 { get; set; }

            /// <summary>
            /// The posted amount of the travel request entry in the travel request currency.
            /// </summary>
            public string PostedAmount { get; set; }

            /// <summary>
            /// The remaining amount of the travel request entry in the travel request currency.
            /// </summary>
            public string RemainingAmount { get; set; }

            /// <summary>
            /// The number of segments associated with the travel request entry.
            /// </summary>
            public Int32 SegmentCount { get; set; }

            /// <summary>
            /// This parent element contains a Segment child element for each segment associated with the travel request. Refer to the Segment model for the full list of child elements.
            /// </summary>
            [XmlArrayItem("Segment")]
            public Segment[] SegmentsList { get; set; }

            /// <summary>
            /// The date of the travel request entry.
            /// </summary>
            public DateTime? TransactionDate { get; set; }
        }


        [XmlRoot("Segment")]
        public class Segment
        {

            /// <summary>
            /// The approved amount of the segment in the travel request currency.
            /// </summary>
            public string ApprovedAmount { get; set; }

            /// <summary>
            /// The arrival date of the segment.
            /// </summary>
            public string ArrivalDate { get; set; }

            /// <summary>
            /// The arrival time of the segment.
            /// </summary>
            public string ArrivalTime { get; set; }

            /// <summary>
            /// The Class of Service Code from Concur Travel. Appears only when travel request is integrated with Concur Travel.
            /// </summary>
            public string ClassOfServiceCode { get; set; }

            /// <summary>
            /// The number of comments associated with the segment.
            /// </summary>
            public Int32 CommentCount { get; set; }

            /// <summary>
            /// This parent element has a Count attribute indicating the number of comments that are included in the segment. It has a Comment child element for each comment. Refer to the Comments model for the full list of child elements.
            /// </summary>
            [XmlArrayItem("Comments")]
            public Comments[] CommentsList { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom1 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom10 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom11 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom12 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom13 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom14 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom15 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom16 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom17 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom18 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom19 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom2 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom20 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom21 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom22 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom23 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom24 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom25 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom26 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom27 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom28 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom29 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom3 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom30 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom31 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom32 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom33 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom34 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom35 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom36 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom37 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom38 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom39 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom4 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom40 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom5 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom6 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom7 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom8 { get; set; }

            /// <summary>
            /// The custom fields associated with the segment. These may not have data, depending on your configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom9 { get; set; }

            /// <summary>
            /// The departure date of the segment.
            /// </summary>
            public string DepartureDate { get; set; }

            /// <summary>
            /// The departure time of the segment.
            /// </summary>
            public string DepartureTime { get; set; }

            /// <summary>
            /// The number of exceptions associated with the travel request segment.
            /// </summary>
            public Int32 ExceptionCount { get; set; }

            /// <summary>
            /// This parent element has a Count attribute indicating the number of exceptions that are included in the travel request segment. It has an Exception child element for each exception. Refer to the Exception model for the full list of child elements.
            /// </summary>
            [XmlArrayItem("Exception")]
            public TRException[] ExceptionsList { get; set; }

            /// <summary>
            /// The exchange rate that applies to the segment.
            /// </summary>
            public string ExchangeRate { get; set; }

            /// <summary>
            /// The flight number for air segments. Appears only when travel request is integrated with Concur Travel.
            /// </summary>
            public string FlightNumber { get; set; }

            /// <summary>
            /// The foreign currency amount of the segment.
            /// </summary>
            public string ForeignAmount { get; set; }

            /// <summary>
            /// The <a target="_blank" href="http://en.wikipedia.org/wiki/ISO_4217">3-letter ISO 4217 currency code</a> foreign amount currency of the segment.
            /// </summary>
            public string ForeignCurrencyCode { get; set; }

            /// <summary>
            /// The name of the currency for the foreign amount of the segment.
            /// </summary>
            public string ForeignCurrencyName { get; set; }

            /// <summary>
            /// The code of the form type of segment.
            /// </summary>
            public string FormTypeCode { get; set; }

            /// <summary>
            /// The code of starting location.
            /// </summary>
            public string FromLocationDetail { get; set; }

            /// <summary>
            /// The name of the starting location.
            /// </summary>
            public string FromLocationName { get; set; }

            /// <summary>
            /// Whether the air segment was agency booked. Format: Y/N.
            /// </summary>
            public string IsAgencyBooked { get; set; }

            /// <summary>
            /// Whether the air segment was self booked. Format: Y/N.
            /// </summary>
            public string IsSelfBooked { get; set; }

            /// <summary>
            /// The date the segment was last modified. Format: YYYY-MM-DDThh:mm:ss
            /// </summary>
            public DateTime? LastModifiedDate { get; set; }

            /// <summary>
            /// The unique identifier for the outbound segment. This is the protected, Outbound Segment Key
            /// </summary>
            public string OutboundSegmentKey { get; set; }

            /// <summary>
            /// The posted amount of the segment in the travel request currency.
            /// </summary>
            public string PostedAmount { get; set; }

            /// <summary>
            /// Appears only when travel request is integrated with Concur Travel.
            /// </summary>
            public string RecordLocator { get; set; }

            /// <summary>
            /// The remaining amount of the segment in the travel request currency.
            /// </summary>
            public string RemainingAmount { get; set; }

            /// <summary>
            /// The unique identifier for Concur Travel segment associated with this segment. Appears only when travel request is integrated with Concur Travel.
            /// </summary>
            public string SegmentLocator { get; set; }

            /// <summary>
            /// The type of itinerary segment. Format: air, car, hotel, rail, dining, event, limo, taxi, parking, other,...
            /// </summary>
            public string SegmentType { get; set; }

            /// <summary>
            /// The code of the type of itinerary segment.
            /// </summary>
            public string SegmentTypeCode { get; set; }

            /// <summary>
            /// The code of the ending location.
            /// </summary>
            public string ToLocationDetail { get; set; }

            /// <summary>
            /// The name of the ending location.
            /// </summary>
            public string ToLocationName { get; set; }

            /// <summary>
            /// The unique identifier for the Concur Travel trip associated with this segment. Appears only when travel request is integrated with Concur Travel.
            /// </summary>
            public string TripLocator { get; set; }
        }

        /// <summary>
        /// TravelRequestDetails
        /// </summary>
        [XmlRoot("TravelRequestDetails")]
        public class TravelRequestDetails
        {

            /// <summary>
            /// The Agency Office name.
            /// </summary>
            public string AgencyOfficeName { get; set; }

            /// <summary>
            /// The date the travel request must be approved by. Appears only when integrated with Concur Travel.
            /// </summary>
            public DateTime? ApprovalLimitDate { get; set; }

            /// <summary>
            /// The status code of the travel request.
            /// </summary>
            public string ApprovalStatusCode { get; set; }

            /// <summary>
            /// The approval status of the travel request.
            /// </summary>
            public string ApprovalStatusName { get; set; }

            /// <summary>
            /// The date the travel request was authorized. This element has an attribute named i:nil. If the value for this element is null, the i:nil attribute will be set to true. Format: YYYY-MM-DDThh:mm:ss.
            /// </summary>
            public DateTime? AuthorizedDate { get; set; }

            /// <summary>
            /// The number of cash advance associated with the travel request header.
            /// </summary>
            public Int32 CashAdvanceCount { get; set; }

            /// <summary>
            /// This parent element has a Count attribute indicating the number of cash advances that are included in the travel request. It has a CashAdvance child element for each cash advance. Refer to the CashAdvance model for the full list of child elements.
            /// </summary>
            [XmlArrayItem("CashAdvance")]
            public CashAdvance[] CashAdvancesList { get; set; }

            /// <summary>
            /// The number of comments associated with the travel request header.
            /// </summary>
            public Int32 CommentCount { get; set; }

            /// <summary>
            /// This parent element has a Count attribute indicating the number of comments that are included in the travel request header. It has a Comment child element for each comment. Refer to the Comments model for the full list of child elements.
            /// </summary>
            [XmlArrayItem("Comments")]
            public Comments[] CommentsList { get; set; }

            /// <summary>
            /// The date the travel request was created.
            /// </summary>
            public DateTime? CreationDate { get; set; }

            /// <summary>
            /// The <a target="_blank" href="http://en.wikipedia.org/wiki/ISO_4217">3-letter ISO 4217 currency code</a> for the travel request currency. The travel request currency is defined as the travel request creator's default reimbursement currency.
            /// </summary>
            public string CurrencyCode { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom1 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom10 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom11 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom12 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom13 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom14 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom15 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom16 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom17 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom18 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom19 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom2 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom20 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom3 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom4 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom5 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom6 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom7 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom8 { get; set; }

            /// <summary>
            /// The details from the Custom fields. These may not have data, depending on configuration. If the custom field is a list field, the data will be returned as: (list item short code) list item name. List Field Example: < Custom1 >(1234) Project 1234< /Custom1 > 
            /// </summary>
            public string Custom9 { get; set; }

            /// <summary>
            /// The first, middle (or middle initial), and last name of the employee who created the travel request.
            /// </summary>
            public string EmployeeName { get; set; }

            /// <summary>
            /// The end date of the travel request.
            /// </summary>
            public string EndDate { get; set; }

            /// <summary>
            /// The end time for the travel request.
            /// </summary>
            public string EndTime { get; set; }

            /// <summary>
            /// This parent element has a Count attribute indicating the number of travel request entries that are included in the travel request. It has a RequestEntry child element for each entry. Refer to the RequestEntry model for the full list of child elements.
            /// </summary>
            [XmlArrayItem("RequestEntry")]
            public RequestEntry[] EntriesList { get; set; }

            /// <summary>
            /// The number of entries associated with the travel request header.
            /// </summary>
            public Int32 EntryCount { get; set; }

            /// <summary>
            /// Whether the travel request has ever been sent back to the employee. Format: Y/N
            /// </summary>
            public string EverSentBack { get; set; }

            /// <summary>
            /// The number of exceptions associated with the travel request header.
            /// </summary>
            public Int32 ExceptionCount { get; set; }

            /// <summary>
            /// This parent element has a Count attribute indicating the number of exceptions that are included in the travel request entry. It has an Exception child element for each exception. Refer to the Exception model for the full list of child elements.
            /// </summary>
            [XmlArrayItem("Exception")]
            public TRException[] ExceptionsList { get; set; }

            /// <summary>
            /// The ID of the initial travel request that this travel request is an extension of or adendum to.
            /// </summary>
            public string ExtensionOf { get; set; }

            /// <summary>
            /// Whether the travel request has exceptions. Format: Y/N
            /// </summary>
            public string HasException { get; set; }

            /// <summary>
            /// The date the travel request was last modified. Format: YYYY-MM-DDThh:mm:ss
            /// </summary>
            public DateTime? LastModifiedDate { get; set; }

            /// <summary>
            /// The Concur Login ID of the travel request owner.
            /// </summary>
            public string LoginID { get; set; }

            /// <summary>
            /// The information from the Purpose field.
            /// </summary>
            public string Purpose { get; set; }

            /// <summary>
            /// The unique key for the travel request.
            /// </summary>
            public string RequestID { get; set; }

            /// <summary>
            /// The name of the travel request.
            /// </summary>
            public string RequestName { get; set; }

            /// <summary>
            /// The total amount of the travel request.
            /// </summary>
            public string RequestTotal { get; set; }

            /// <summary>
            /// The start date of the travel request.
            /// </summary>
            public string StartDate { get; set; }

            /// <summary>
            /// The start time for the travel request.
            /// </summary>
            public string StartTime { get; set; }

            /// <summary>
            /// The date the travel request was submitted. Format: YYYY-MM-DDThh:mm:ss.
            /// </summary>
            public DateTime? SubmitDate { get; set; }

            /// <summary>
            /// The total amount of approved expenses in the travel request.
            /// </summary>
            public string TotalApprovedAmount { get; set; }

            /// <summary>
            /// The total amount remaining in the travel request.
            /// </summary>
            public string TotalRemainingAmount { get; set; }

            /// <summary>
            /// The URL to post a workflow action to the travel request using the Post Request Workflow Action function.
            /// </summary>
            public string WorkflowUrl { get; set; }
        }

        /// <summary>
        /// Request
        /// </summary>
        [XmlRoot("Request")]
        public class TravelRequestHeader
        {

            /// <summary>
            /// The travel request's approval status, in the OAuth consumer's language.
            /// </summary>
            public string ApprovalStatus { get; set; }

            /// <summary>
            /// The approval status code of the travel request.
            /// </summary>
            public string ApprovalStatusCode { get; set; }

            /// <summary>
            /// The Login ID of the user's travel request approver.
            /// </summary>
            public string ApproverLoginID { get; set; }

            /// <summary>
            /// The name of the travel request owner.
            /// </summary>
            public string EmployeeName { get; set; }

            /// <summary>
            /// The end date of the travel request.
            /// </summary>
            public DateTime? EndDate { get; set; }

            /// <summary>
            /// The unique identifier of the resource.
            /// </summary>
            public string ID { get; set; }

            /// <summary>
            /// The text of the most recent comment on the travel request.
            /// </summary>
            public string LastComment { get; set; }

            /// <summary>
            /// The purpose of the travel request.
            /// </summary>
            public string Purpose { get; set; }

            /// <summary>
            /// The <a target="_blank" href="http://en.wikipedia.org/wiki/ISO_4217">3-letter ISO 4217 currency code</a> for the travel request currency.
            /// </summary>
            public string RequestCurrency { get; set; }

            /// <summary>
            /// The create date of the travel request.
            /// </summary>
            public DateTime? RequestDate { get; set; }

            /// <summary>
            /// The URI to use when posting travel request header details to this travel request.
            /// </summary>
            public string RequestDetailsUrl { get; set; }

            /// <summary>
            /// The unique identifier for the travel request, which appears in the Concur UI.
            /// </summary>
            public string RequestID { get; set; }

            /// <summary>
            /// The name of the travel request.
            /// </summary>
            public string RequestName { get; set; }

            /// <summary>
            /// The total amount of the travel request.
            /// </summary>
            public string RequestTotal { get; set; }

            /// <summary>
            /// The Login ID of the user this travel request belongs to.
            /// </summary>
            public string RequestUserLoginID { get; set; }

            public string SegmentTypes { get; set; }

            /// <summary>
            /// The start date of the travel request.
            /// </summary>
            public DateTime? StartDate { get; set; }

            /// <summary>
            /// The posted amount of the travel request entry in the travel request currency.
            /// </summary>
            public string TotalPostedAmount { get; set; }

            /// <summary>
            /// The URI to the resource.
            /// </summary>
            public string URI { get; set; }
        }

        /// <summary>
        /// Exception
        /// </summary>
        [XmlRoot("Exception")]
        public class TRException
        {

            /// <summary>
            /// The system exception code defined for the exception. Example: BADCODE
            /// </summary>
            public string ExceptionCode { get; set; }

            /// <summary>
            /// The numeric level associated with the exception. Example: 99
            /// </summary>
            public Int32 ExceptionLevel { get; set; }

            /// <summary>
            /// The user-facing message defined for the exception.
            /// </summary>
            public string ExceptionMessage { get; set; }
        }

        /// <summary>
        /// Invoice
        /// </summary>
        [XmlRoot("Invoice")]
        public class Invoice
        {

            public BillToAddress BillToAddress { get; set; }

            /// <summary>
            /// Calculated tax amount for invoice.
            /// </summary>
            public string CalculatedTaxAmount { get; set; }

            /// <summary>
            /// Calculated tax rate for Invoice.
            /// </summary>
            public string CalculatedTaxRate { get; set; }

            /// <summary>
            /// Comments for invoice.
            /// </summary>
            public string Comments { get; set; }

            /// <summary>
            /// Country code for the line item.
            /// </summary>
            public string CountryCode { get; set; }

            /// <summary>
            /// Currency alpha code for invoice currency, ex USD, CAD
            /// </summary>
            public string CurrencyCode { get; set; }

            /// <summary>
            /// The unique identifier of the resource.
            /// </summary>
            public string ID { get; set; }

            /// <summary>
            /// Invoice amount.
            /// </summary>
            public string InvoiceAmount { get; set; }

            /// <summary>
            /// Invoice date.
            /// </summary>
            public string InvoiceDate { get; set; }

            /// <summary>
            /// Line items associated with the invoice.
            /// </summary>
            [XmlArrayItem("LineItem")]
            public InvoiceLineItem[] LineItem { get; set; }

            /// <summary>
            /// Purchase order number for the associated purchase order.
            /// </summary>
            public string PurchaseOrderNumber { get; set; }

            /// <summary>
            /// Invoice total.
            /// </summary>
            public string ShippingAmount { get; set; }

            public ShipToAddress ShipToAddress { get; set; }

            /// <summary>
            /// Status for invoice.
            /// </summary>
            public string Status { get; set; }

            /// <summary>
            /// Status code for invoice.
            /// </summary>
            public string StatusCode { get; set; }

            /// <summary>
            /// Invoice tax.
            /// </summary>
            public string Tax { get; set; }

            /// <summary>
            /// Tax reference ID for the invoice
            /// </summary>
            public string TaxReferenceID { get; set; }

            /// <summary>
            /// Title of the invoice.
            /// </summary>
            public string Title { get; set; }

            /// <summary>
            /// Invoice total.
            /// </summary>
            public string Total { get; set; }

            /// <summary>
            /// The URI to the resource.
            /// </summary>
            public string URI { get; set; }

            /// <summary>
            /// Vendor invoice number tied to invoice.
            /// </summary>
            public string VendorInvoiceNumber { get; set; }
        }

        /// <summary>
        /// Invoices
        /// </summary>
        [XmlRoot("Invoices")]
        public class InvoiceCollection
        {

            /// <summary>
            /// The result collection.
            /// </summary>
            [XmlArrayItem("Invoice")]
            public Invoice[] Items { get; set; }

            /// <summary>
            /// The URI of the next page of results, if any.
            /// </summary>
            public string NextPage { get; set; }

            public Int32? TotalCount { get; set; }

            /// <summary>
            /// The offset value to be used when iterating to get the next page of objects.
            /// </summary>
            public virtual string NextPageOffset() { return this.Util.GetQueryStringValue(NextPage, "offset"); }

            /// <summary>
            /// The flag used to indicate whether the current page of objects is the last one in the sequence.
            /// </summary>
            public virtual bool IsEndOfPagination() { return string.IsNullOrWhiteSpace(NextPageOffset()); }

            protected ConcurUtil Util = new ConcurUtil();
        }

        /// <summary>
        /// LineItem
        /// </summary>
        [XmlRoot("LineItem")]
        public class InvoiceLineItem
        {

            /// <summary>
            /// Calculated tax amount for the line item. This is for individual line item.
            /// </summary>
            public string CalculatedTaxAmount { get; set; }

            /// <summary>
            /// Calculated tax rate for the line item. This is for individual line item.
            /// </summary>
            public string CalculatedTaxRate { get; set; }

            /// <summary>
            /// Commodity code tied to the expense type asscociated to line item.
            /// </summary>
            public string CommodityCode { get; set; }

            /// <summary>
            /// Country code for the line item.
            /// </summary>
            public string CountryCode { get; set; }

            /// <summary>
            /// Currency alpha code for the line item. This is for individual line item.
            /// </summary>
            public string CurrencyCode { get; set; }

            /// <summary>
            /// Line Item key, Identify individual Line Item by its unique key.
            /// </summary>
            public string LineItemKey { get; set; }

            /// <summary>
            /// Quatntity for each line item.
            /// </summary>
            public string Quantity { get; set; }

            /// <summary>
            /// Total about for the line item.
            /// </summary>
            public string Total { get; set; }

            /// <summary>
            /// Unit price for each line item of an invoice.
            /// </summary>
            public string UnitPrice { get; set; }

            /// <summary>
            /// Vendor details , vendor for each item.
            /// </summary>
            public InvoiceVendor Vendor { get; set; }
        }

        /// <summary>
        /// InvoiceStatus
        /// </summary>
        [XmlRoot("InvoiceStatus")]
        public class InvoiceStatus
        {

            /// <summary>
            /// Code of request result
            /// </summary>
            public Int32 Code { get; set; }

            /// <summary>
            /// Commnents returned for the update request.
            /// </summary>
            public string Comments { get; set; }

            /// <summary>
            /// Message of request result
            /// </summary>
            public string Message { get; set; }

            /// <summary>
            /// Record Number for create/update request.
            /// </summary>
            public Int32 RecordNumber { get; set; }

            /// <summary>
            /// Status for the update, values supported SUCCESS,FAILURE.
            /// </summary>
            public string Status { get; set; }

            /// <summary>
            /// Tax reference by for the updated invoice.
            /// </summary>
            public string TaxReferenceID { get; set; }

            /// <summary>
            /// Type request result
            /// </summary>
            public string Type { get; set; }
        }

        /// <summary>
        /// Vendor
        /// </summary>
        [XmlRoot("Vendor")]
        public class InvoiceVendor
        {

            /// <summary>
            /// The Vendor Address 1.
            /// </summary>
            public string Address1 { get; set; }

            /// <summary>
            /// The Vendor Address 2.
            /// </summary>
            public string Address2 { get; set; }

            /// <summary>
            /// The Vendor Address 3.
            /// </summary>
            public string Address3 { get; set; }

            /// <summary>
            /// The Vendor City.
            /// </summary>
            public string City { get; set; }

            /// <summary>
            /// The Vendor Country Code.
            /// </summary>
            public string CountryCode { get; set; }

            /// <summary>
            /// The Vendor Postal Code / Zip.
            /// </summary>
            public string PostalCode { get; set; }

            /// <summary>
            /// The Vendor State.
            /// </summary>
            public string State { get; set; }

            /// <summary>
            /// Name for Vendor Address.
            /// </summary>
            public string VendorAddressName { get; set; }

            /// <summary>
            /// The Vendor Name.
            /// </summary>
            public string VendorName { get; set; }
        }

        /// <summary>
        /// Suppliers
        /// </summary>
        [XmlRoot("Suppliers")]
        public class SupplierCollection
        {

            /// <summary>
            /// The result collection.
            /// </summary>
            [XmlArrayItem("Supplier")]
            public SupplierGet[] Items { get; set; }

            /// <summary>
            /// The URI of the next page of results, if any.
            /// </summary>
            public string NextPage { get; set; }
        }

        /// <summary>
        /// Supplier
        /// </summary>
        [XmlRoot("Supplier")]
        public class SupplierGet
        {

            /// <summary>
            /// Name
            /// </summary>
            public string BusinessName { get; set; }

            /// <summary>
            /// City
            /// </summary>
            public string City { get; set; }

            /// <summary>
            /// Country Code
            /// </summary>
            public string CountryCode { get; set; }

            /// <summary>
            /// The unique identifier of the resource.
            /// </summary>
            public string ID { get; set; }

            /// <summary>
            /// Zip
            /// </summary>
            public string PostalCode { get; set; }

            /// <summary>
            /// State
            /// </summary>
            public string State { get; set; }

            /// <summary>
            /// Address
            /// </summary>
            public string StreetAddress { get; set; }

            /// <summary>
            /// Address2 
            /// </summary>
            public string StreetAddress2 { get; set; }

            /// <summary>
            /// The URI to the resource.
            /// </summary>
            public string URI { get; set; }
        }

        /// <summary>
        /// Supplier
        /// </summary>
        [XmlRoot("Supplier")]
        public class SupplierSingle
        {

            /// <summary>
            /// Amadeus Id
            /// </summary>
            public string AmadeusId { get; set; }

            /// <summary>
            /// Austin Tetra
            /// </summary>
            public string AustinTetra { get; set; }

            /// <summary>
            /// Name
            /// </summary>
            public string BusinessName { get; set; }

            /// <summary>
            /// Chain Code
            /// </summary>
            public string ChainCode { get; set; }

            /// <summary>
            /// Chain Name
            /// </summary>
            public string ChainName { get; set; }

            /// <summary>
            /// City
            /// </summary>
            public string City { get; set; }

            /// <summary>
            /// Country Code
            /// </summary>
            public string CountryCode { get; set; }

            /// <summary>
            /// Creditcard Vendor Id
            /// </summary>
            public string CreditCardVendorId { get; set; }

            /// <summary>
            /// Duns Number
            /// </summary>
            public string DunsNumber { get; set; }

            /// <summary>
            /// Email
            /// </summary>
            public string Email { get; set; }

            /// <summary>
            /// Fax
            /// </summary>
            public string Fax { get; set; }

            /// <summary>
            /// Galileo Id
            /// </summary>
            public string GalileoId { get; set; }

            /// <summary>
            /// The unique identifier of the resource.
            /// </summary>
            public string ID { get; set; }

            /// <summary>
            /// MCC Code (Ex: Delta Airline - 3058)
            /// </summary>
            public string MccCode { get; set; }

            /// <summary>
            /// Northstar Id
            /// </summary>
            public string NorthstarId { get; set; }

            /// <summary>
            /// Pegasus Id
            /// </summary>
            public string PegasusId { get; set; }

            /// <summary>
            /// Phone
            /// </summary>
            public string Phone { get; set; }

            /// <summary>
            /// Zip
            /// </summary>
            public string PostalCode { get; set; }

            /// <summary>
            /// Primary Naics Code
            /// </summary>
            public string PrimaryNaics { get; set; }

            /// <summary>
            /// Primary Sic Code
            /// </summary>
            public string PrimarySic { get; set; }

            /// <summary>
            /// SUP_PARAM_PROPERTY_CODE
            /// </summary>
            public string PropertyCode { get; set; }

            /// <summary>
            /// Sabre Id
            /// </summary>
            public string SabreId { get; set; }

            /// <summary>
            /// Secondary Naics Code
            /// </summary>
            public string SecondaryNaics { get; set; }

            /// <summary>
            /// Secondary Sic Code
            /// </summary>
            public string SecondarySic { get; set; }

            /// <summary>
            /// State
            /// </summary>
            public string State { get; set; }

            /// <summary>
            /// Address
            /// </summary>
            public string StreetAddress { get; set; }

            /// <summary>
            /// Address2 
            /// </summary>
            public string StreetAddress2 { get; set; }

            /// <summary>
            /// Tax Id
            /// </summary>
            public string TaxId { get; set; }

            /// <summary>
            /// Toll Free 
            /// </summary>
            public string TollFree { get; set; }

            /// <summary>
            /// The URI to the resource.
            /// </summary>
            public string URI { get; set; }

            /// <summary>
            /// Web Address
            /// </summary>
            public string WebUrl { get; set; }

            /// <summary>
            /// Worldspan Id
            /// </summary>
            public string WorldspanId { get; set; }
        }


        [XmlRoot("Status")]
        public class Status
        {

            /// <summary>
            /// Code of request result
            /// </summary>
            public Int32 Code { get; set; }

            /// <summary>
            /// Message of request result
            /// </summary>
            public string Message { get; set; }

            /// <summary>
            /// Record Number for create/update request.
            /// </summary>
            public Int32 RecordNumber { get; set; }

            /// <summary>
            /// Type request result
            /// </summary>
            public string Type { get; set; }
        }

        /// <summary>
        /// Vendor
        /// </summary>
        [XmlRoot("Vendor")]
        public class Vendor
        {

            /// <summary>
            /// The Buyer Account Number.
            /// </summary>
            public string AccountNumber { get; set; }

            /// <summary>
            /// The Vendor Address 1.
            /// </summary>
            public string Address1 { get; set; }

            /// <summary>
            /// The Vendor Address 2.
            /// </summary>
            public string Address2 { get; set; }

            /// <summary>
            /// The Vendor Address 3.
            /// </summary>
            public string Address3 { get; set; }

            /// <summary>
            /// The Address Code.
            /// </summary>
            public string AddressCode { get; set; }

            /// <summary>
            /// This ID is originally generated by Invoice when an employee requests a new vendor. The Employee Request Vendor Extract provides this value to positively identify the vendor address record when reimporting vendor from the client's system of record for the Vendor Master List.  
            /// </summary>
            public string AddressImportSyncID { get; set; }

            /// <summary>
            /// Vendor Approval Status.
            /// </summary>
            public string Approved { get; set; }

            /// <summary>
            /// The Vendor City.
            /// </summary>
            public string City { get; set; }

            /// <summary>
            /// The Vendor Contact Email.
            /// </summary>
            public string ContactEmail { get; set; }

            /// <summary>
            /// The Vendor Contact First Name.
            /// </summary>
            public string ContactFirstName { get; set; }

            /// <summary>
            /// The Vendor Contact Last Name.
            /// </summary>
            public string ContactLastName { get; set; }

            /// <summary>
            /// The Vendor Contact Phone Number.
            /// </summary>
            public string ContactPhoneNumber { get; set; }

            /// <summary>
            /// The Vendor Country.
            /// </summary>
            public string Country { get; set; }

            /// <summary>
            /// The Vendor Country Code.
            /// </summary>
            public string CountryCode { get; set; }

            /// <summary>
            /// The Vendor Currency Code.
            /// </summary>
            public string CurrencyCode { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 1 that is part of the vendor form.
            /// </summary>
            public string Custom1 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 10 that is part of the vendor form.
            /// </summary>
            public string Custom10 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 11 that is part of the vendor form.
            /// </summary>
            public string Custom11 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 12 that is part of the vendor form.
            /// </summary>
            public string Custom12 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 13 that is part of the vendor form.
            /// </summary>
            public string Custom13 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 14 that is part of the vendor form.
            /// </summary>
            public string Custom14 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 15 that is part of the vendor form.
            /// </summary>
            public string Custom15 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 16 that is part of the vendor form.
            /// </summary>
            public string Custom16 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 17 that is part of the vendor form.
            /// </summary>
            public string Custom17 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 18 that is part of the vendor form.
            /// </summary>
            public string Custom18 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 19 that is part of the vendor form.
            /// </summary>
            public string Custom19 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 2 that is part of the vendor form.
            /// </summary>
            public string Custom2 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 20 that is part of the vendor form.
            /// </summary>
            public string Custom20 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 3 that is part of the vendor form.
            /// </summary>
            public string Custom3 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 4 that is part of the vendor form.
            /// </summary>
            public string Custom4 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 5 that is part of the vendor form.
            /// </summary>
            public string Custom5 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 6 that is part of the vendor form.
            /// </summary>
            public string Custom6 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 7 that is part of the vendor form.
            /// </summary>
            public string Custom7 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 8 that is part of the vendor form.
            /// </summary>
            public string Custom8 { get; set; }

            /// <summary>
            /// A value that can be applied to a custom field 9 that is part of the vendor form.
            /// </summary>
            public string Custom9 { get; set; }

            /// <summary>
            /// The Default Employee ID of the employee connected to the vendor.
            /// </summary>
            public string DefaultEmployeeID { get; set; }

            /// <summary>
            /// The Default Expense Type tied to the vendor.
            /// </summary>
            public string DefaultExpenseTypeName { get; set; }

            /// <summary>
            /// The Discount Percentage.
            /// </summary>
            public string DiscountPercentage { get; set; }

            /// <summary>
            /// The Vendor Discount Terms Days.
            /// </summary>
            public string DiscountTermsDays { get; set; }

            /// <summary>
            /// The unique identifier of the resource.
            /// </summary>
            public string ID { get; set; }

            /// <summary>
            /// Flag that indicates if the vendor will be available for OCR within Brainware 
            /// </summary>
            public string IsVisibleForContentExtraction { get; set; }

            /// <summary>
            /// Preferred Payment Type for Vendor.
            /// </summary>
            public string PaymentMethodType { get; set; }

            /// <summary>
            /// The Vendor Payment Terms.
            /// </summary>
            public string PaymentTerms { get; set; }

            /// <summary>
            /// The Vendor Postal Code / Zip.
            /// </summary>
            public string PostalCode { get; set; }

            /// <summary>
            /// The Purchase Order Contact Email.
            /// </summary>
            public string PurchaseOrderContactEmail { get; set; }

            /// <summary>
            /// The Purchase Order Contact First Name.
            /// </summary>
            public string PurchaseOrderContactFirstName { get; set; }

            /// <summary>
            /// The Purchase Order Contact Last Name.
            /// </summary>
            public string PurchaseOrderContactLastName { get; set; }

            /// <summary>
            /// The Purchase Order Contact Phone Number.
            /// </summary>
            public string PurchaseOrderContactPhoneNumber { get; set; }

            /// <summary>
            /// The Vendor Shipping Method.
            /// </summary>
            public string ShippingMethod { get; set; }

            /// <summary>
            /// The Vendor Shipping Terms.
            /// </summary>
            public string ShippingTerms { get; set; }

            /// <summary>
            /// The Vendor State.
            /// </summary>
            public string State { get; set; }

            /// <summary>
            /// Status results
            /// </summary>
            [XmlArrayItem("Status")]
            public Status[] StatusList { get; set; }

            /// <summary>
            /// The Vendor Tax ID.
            /// </summary>
            public string TaxID { get; set; }

            /// <summary>
            /// The URI to the resource.
            /// </summary>
            public string URI { get; set; }

            /// <summary>
            /// The Vendor Code.
            /// </summary>
            public string VendorCode { get; set; }

            /// <summary>
            /// The vendor form name this vendor is associated with.
            /// </summary>
            public string VendorFormName { get; set; }

            /// <summary>
            /// The Vendor Name.
            /// </summary>
            public string VendorName { get; set; }

            /// <summary>
            /// Notes sent to Vendor along with authorization to charge Card Voucher.
            /// </summary>
            public string VoucherNotes { get; set; }
        }

        /// <summary>
        /// Vendors
        /// </summary>
        [XmlRoot("Vendors")]
        public class VendorCollection
        {

            /// <summary>
            /// The result collection.
            /// </summary>
            [XmlArrayItem("Vendor")]
            public Vendor[] Items { get; set; }

            /// <summary>
            /// The URI of the next page of results, if any.
            /// </summary>
            public string NextPage { get; set; }

            public string RequestRunSummary { get; set; }

            /// <summary>
            /// Vendor
            /// </summary>
            [XmlArrayItem("Vendor")]
            public Vendor[] Vendor { get; set; }

            /// <summary>
            /// The offset value to be used when iterating to get the next page of objects.
            /// </summary>
            public virtual string NextPageOffset() { return this.Util.GetQueryStringValue(NextPage, "offset"); }

            /// <summary>
            /// The flag used to indicate whether the current page of objects is the last one in the sequence.
            /// </summary>
            public virtual bool IsEndOfPagination() { return string.IsNullOrWhiteSpace(NextPageOffset()); }

            protected ConcurUtil Util = new ConcurUtil();
        }
    }
}




//**************************************************************************************************************
//************************** Begin-Of-Namespace: Concur.Connect.V1 *****************************************
//**************************************************************************************************************
namespace Concur.Connect.V1
{
    /// <summary>
    /// My proxy service description
    /// </summary>    
    public class ConnectService
    {
        /// <summary>
        /// Constructor for this object.
        /// </summary>
        /// <param name="accessToken">Access token to be used when making calls to this service.</param>
        /// <param name="instanceUrl">Instance URL obtained when the access token was generated. This URL determines the datacenter that should be used to serve calls of this service.</param>
        /// <param name="timeoutInMilliseconds">Optional timeout in milliseconds to be assumed by all methods of this service object</param>
        /// <param name="remoteServiceBaseUrl">Optional base URL to be assumed by all methods of this service object. E.g. "https://www.concursolutions.com/api"</param>
        public ConnectService(string accessToken, string instanceUrl = @"https://www.concursolutions.com/", int timeoutInMilliseconds = 90000, string remoteServiceBaseUrl = @"https://www.concursolutions.com/api")
        {
            UserCredential = new ConcurOAuthCredential(accessToken, instanceUrl);
            CallOptions = new ConcurCallOptions(timeoutInMilliseconds, remoteServiceBaseUrl);
            Util = new ConcurUtil();
        }

        public ConcurOAuthCredential UserCredential { get; protected set; }
        public ConcurCallOptions CallOptions { get; protected set; }
        protected ConcurUtil Util { get; set; }

        /// <summary>
        /// Uploads a receipt image and associates it with the expense entry that matches the supplied entry ID. Once an image is attached to the entry, you cannot append additional images.
        /// </summary>
        /// <param name="image">Image data file</param>
        /// <param name="imageFileType">File type (e.g. PDF, JPEG, PNG)</param>      
        /// <param name="expenseEntryId">Expense report entry ID to attach the image</param>      
        public ExpenseImage CreateExpenseEntryReceiptImages(byte[] image, ReceiptFileType imageFileType, string expenseEntryId)
        {
            string remoteServiceRelativeUrl = @"/image/v1.0/expenseentry/{entryid}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[] 
            {
                new KeyValuePair<string,object>("entryid", expenseEntryId)
            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            string contentType = new string[] { "application/pdf", "image/jpeg", "image/png" }[(int)imageFileType];
            return this.Util.SendHttpRequest<ExpenseImage>(
                "POST",
                requestUrl,
                image,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                contentType);
        }

        /// <summary>
        /// Uploads a receipt image and associates it with the expense entry that matches the supplied entry ID. Once an image is attached to the entry, you cannot append additional images.
        /// </summary>
        /// <param name="image">Image data file</param>
        /// <param name="imageFileType">File type (e.g. PDF, JPEG, PNG)</param>      
        /// <param name="expenseEntryId">Expense report entry ID to attach the image</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task</param>
        public async Task<ExpenseImage> CreateExpenseEntryReceiptImagesAsync(byte[] image, ReceiptFileType imageFileType, string expenseEntryId, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/image/v1.0/expenseentry/{entryid}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[] 
            {
                new KeyValuePair<string,object>("entryid", expenseEntryId)
            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            string contentType = new string[] { "application/pdf", "image/jpeg", "image/png" }[(int)imageFileType];
            return await this.Util.SendHttpRequestAsync<ExpenseImage>(
                "POST",
                requestUrl,
                image,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken,
                contentType);
        }

        /// <summary>
        /// Uploads a receipt image and associates it with the expense report that matches the supplied report ID. Once an image is attached to the report, you cannot append additional images.
        /// </summary>
        /// <param name="image">Image data file</param>
        /// <param name="imageFileType">File type (e.g. PDF, JPEG, PNG)</param>      
        /// <param name="expenseReportId">Expense report ID to attach the image</param>      
        public ExpenseImage CreateExpenseReportReceiptImages(byte[] image, ReceiptFileType imageFileType, string expenseReportId)
        {
            string remoteServiceRelativeUrl = @"/image/v1.0/report/{reportid}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[] 
            {
                new KeyValuePair<string,object>("reportid", expenseReportId)
            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            string contentType = new string[] { "application/pdf", "image/jpeg", "image/png" }[(int)imageFileType];
            return this.Util.SendHttpRequest<ExpenseImage>(
                "POST",
                requestUrl,
                image,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                contentType);
        }

        /// <summary>
        /// Uploads a receipt image and associates it with the expense report that matches the supplied report ID. Once an image is attached to the report, you cannot append additional images.
        /// </summary>
        /// <param name="image">Image data file</param>
        /// <param name="imageFileType">File type (e.g. PDF, JPEG, PNG)</param>      
        /// <param name="expenseReportId">Expense report ID to attach the image</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task</param>
        public async Task<ExpenseImage> CreateExpenseReportReceiptImagesAsync(byte[] image, ReceiptFileType imageFileType, string expenseReportId, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/image/v1.0/report/{reportid}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[] 
            {
                new KeyValuePair<string,object>("reportid", expenseReportId)
            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            string contentType = new string[] { "application/pdf", "image/jpeg", "image/png" }[(int)imageFileType];
            return await this.Util.SendHttpRequestAsync<ExpenseImage>(
                "POST",
                requestUrl,
                image,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken,
                contentType);
        }

        /// <summary>
        /// Uploads a receipt image and associates it with the expense invoice that matches the supplied invoice ID. Once an image is attached to the invoice, you cannot append additional images.
        /// </summary>
        /// <param name="image">Image data file</param>
        /// <param name="imageFileType">File type (e.g. PDF, JPEG, PNG)</param>      
        /// <param name="expenseInvoiceId">Expense invoice ID to attach the image</param>      
        public ExpenseImage CreateExpenseInvoiceReceiptImages(byte[] image, ReceiptFileType imageFileType, string expenseInvoiceId)
        {
            string remoteServiceRelativeUrl = @"/image/v1.0/invoice/{invoiceid}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[] 
            {
                new KeyValuePair<string,object>("invoiceid", expenseInvoiceId)
            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            string contentType = new string[] { "application/pdf", "image/jpeg", "image/png" }[(int)imageFileType];
            return this.Util.SendHttpRequest<ExpenseImage>(
                "POST",
                requestUrl,
                image,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                contentType);
        }

        /// <summary>
        /// Uploads a receipt image and associates it with the expense invoice that matches the supplied invoice ID. Once an image is attached to the invoice, you cannot append additional images.
        /// </summary>
        /// <param name="image">Image data file</param>
        /// <param name="imageFileType">File type (e.g. PDF, JPEG, PNG)</param>      
        /// <param name="expenseInvoiceId">Expense invoice ID to attach the image</param>      
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task</param>
        public async Task<ExpenseImage> CreateExpenseInvoiceReceiptImagesAsync(byte[] image, ReceiptFileType imageFileType, string expenseInvoiceId, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/image/v1.0/invoice/{invoiceid}";
            var queryParameters = new KeyValuePair<string, object>[] { };
            var pathParameters = new KeyValuePair<string, object>[] 
            {
                new KeyValuePair<string,object>("invoiceid", expenseInvoiceId)
            };
            string requestUrl = this.Util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, this.UserCredential.InstanceUrl, pathParameters, queryParameters);
            string contentType = new string[] { "application/pdf", "image/jpeg", "image/png" }[(int)imageFileType];
            return await this.Util.SendHttpRequestAsync<ExpenseImage>(
                "POST",
                requestUrl,
                image,
                this.UserCredential.AccessToken,
                null,
                null,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken,
                contentType);
        }
    } //End-of-Class: Concur.Connect.V1.ConnectService

    namespace Serializable
    {
        [XmlRoot("Image")]
        public class ExpenseImage
        {
            /// <summary>
            /// The unique identifier of the resource.
            /// </summary>
            public string Id { get; set; }

            /// <summary>
            /// The URL to the resource.
            /// </summary>
            public string Url { get; set; }
        }
    }
} //End-of-Namespace: Concur.Connect.V1




//**************************************************************************************************************
//************************** Begin-Of-Namespace: Concur.Authentication *****************************************
//**************************************************************************************************************
namespace Concur.Authentication
{
    [XmlRoot("Access_Token")]
    public class OAuthTokenDetail
    {
        [XmlElement("Token")]
        public string AccessToken;

        [XmlElement("Instance_Url")]
        public string InstanceUrl;

        [XmlElement("Expiration_date")]
        public string ExpirationDate;

        [XmlElement("Refresh_Token")]
        public string RefreshToken;
    }

    [XmlRoot("Access_Token")]
    public class RefreshedOAuthTokenDetail
    {
        [XmlElement("Token")]
        public string AccessToken;

        [XmlElement("Instance_Url")]
        public string InstanceUrl;

        [XmlElement("Expiration_date")]
        public string ExpirationDate;
    }

    public class AuthenticationService
    {
        protected ConcurUtil util = new ConcurUtil();
        public ConcurCallOptions CallOptions { get; protected set; }
        public ConcurOAuthCredential UserCredential { get; protected set; }

        /// <summary>
        /// AuthenticationService object constructor. Notice that the adminAccessToken parameter is required in order to call methods that revoke access tokens.
        /// </summary>
        /// <param name="adminAccessToken">Access Token with administrator privileges. This parameter is required in case this AuthenticationService object is going to be used to call Revoke related methods. Othwerwise this parameter is optional.</param>
        /// <param name="timeoutInMilliseconds">Optional timeout in milliseconds to be assumed by all methods of this service object</param>
        /// <param name="remoteServiceBaseUrl">Optional base URL to be assumed by all methods of this service object. E.g. "https://www.concursolutions.com/"</param>
        public AuthenticationService(string adminAccessToken = null, int timeoutInMilliseconds = 90000, string remoteServiceBaseUrl = @"https://www.concursolutions.com/")
        {
            CallOptions = new ConcurCallOptions(timeoutInMilliseconds, remoteServiceBaseUrl);
            UserCredential = new ConcurOAuthCredential(adminAccessToken, null);
        }

        /// <summary>
        /// Get an OAuth 2.0 token to be used when calling Concur web services.
        /// </summary>
        /// <param name="loginId">User login ID, for example john@mycompany.com</param>
        /// <param name="loginPassword">User login password</param>
        /// <param name="oauthClientId">OAuth 2.0 Client ID (A.K.A ConsumerKey)</param>
        /// <param name="timeoutInMilliseconds">Time-out in milliseconds</param>
        /// <param name="serviceUrl">URL to send the HTTP request</param>
        /// <returns>OAuth 2.0 token (access token, instanceUrl, refresh token, etc.)</returns>
        public OAuthTokenDetail GetOAuthToken(string loginId, string loginPassword, string oauthClientId)
        {
            string serviceUrl = util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, @"/net2/oauth2/accesstoken.ashx");
            return util.SendHttpRequest<OAuthTokenDetail>(
                "GET",
                serviceUrl,
                null, //body
                null, //oauth token
                loginId,
                loginPassword,
                this.CallOptions.TimeoutInMilliseconds,
                null, //contentType
                new KeyValuePair<string, string>[] { new KeyValuePair<string, string>("X-ConsumerKey", oauthClientId ?? "") });
        }

        /// <summary>
        /// Get a new OAuth 2.0 token to be used when calling Concur web services.
        /// </summary>
        /// <param name="loginId">User login ID, for example john@mycompany.com</param>
        /// <param name="loginPassword">User login password</param>
        /// <param name="oauthClientId">OAuth 2.0 Client ID (A.K.A ConsumerKey)</param>
        /// <param name="timeoutInMilliseconds">Time-out in milliseconds</param>
        /// <param name="serviceUrl">URL to send the HTTP request</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task</param>
        /// <returns>OAuth 2.0 token (access token, instanceUrl, refresh token, etc.)</returns>
        public async Task<OAuthTokenDetail> GetOAuthTokenAsync(string loginId, string loginPassword, string oauthClientId, CancellationToken? cancellationToken = null)
        {
            string serviceUrl = util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, @"/net2/oauth2/accesstoken.ashx");
            return await util.SendHttpRequestAsync<OAuthTokenDetail>(
                "GET",
                serviceUrl,
                null, //body
                null, //oauth token
                loginId,
                loginPassword,
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken,
                null, //contentType
                new KeyValuePair<string, string>[] { new KeyValuePair<string, string>("X-ConsumerKey", oauthClientId ?? "") });
        }

        /// <summary>
        /// Refresh the expiration date (to a later point in time) of the access token mapped to the provided OAuth refresh token, in case the access token is not already expired.
        /// If the access token is expired then create a new access token with a fresh expiration date, and map it to the provided OAuth refresh token.
        /// In any case, return the access token (i.e. existing one if not expired, or new one otherwise) together with its fresh expiration date.
        /// No refresh token is returned by this call because it is still the same one passed as input parameter.
        /// </summary>
        /// <param name="oauthClientId">OAuth 2.0 Client ID (A.K.A. Consumer Key)</param>
        /// <param name="oauthClientSecret">OAuth 2.0 Client Secret (A.K.A. Consumer Secret)</param>
        /// <param name="oauthRefreshToken">OAuth 2.0 Refresh Token</param>
        /// <returns>Access token (i.e. existing one if not expired, or new one otherwise) together with its fresh expiration date</returns>
        public RefreshedOAuthTokenDetail GetRefreshedOAuthToken(string oauthClientId, string oauthClientSecret, string oauthRefreshToken)
        {
            string remoteServiceRelativeUrl = @"/net2/oauth2/getaccesstoken.ashx";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("client_id", oauthClientId),
                new KeyValuePair<string,object>("client_secret", oauthClientSecret),
                new KeyValuePair<string,object>("refresh_token", oauthRefreshToken)
            };
            string requestUrl = util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, null, null, queryParameters);

            return util.SendHttpRequest<RefreshedOAuthTokenDetail>(
                "GET",
                requestUrl,
                null, //body
                null, //oauth token
                null, //loginId
                null, //loginPassword
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Refresh the expiration date (to a later point in time) of the access token mapped to the provided OAuth refresh token, in case the access token is not already expired.
        /// If the access token is expired then create a new access token with a fresh expiration date, and map it to the provided OAuth refresh token.
        /// In any case, return the access token (i.e. existing one if not expired, or new one otherwise) together with its fresh expiration date.
        /// No refresh token is returned by this call because it is still the same one passed as input parameter.
        /// </summary>
        /// <param name="oauthClientId">OAuth 2.0 Client ID (A.K.A. Consumer Key)</param>
        /// <param name="oauthClientSecret">OAuth 2.0 Client Secret (A.K.A. Consumer Secret)</param>
        /// <param name="oauthRefreshToken">OAuth 2.0 Refresh Token</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task</param>
        /// <returns>Access token (i.e. existing one if not expired, or new one otherwise) together with its fresh expiration date</returns>
        public async Task<RefreshedOAuthTokenDetail> GetRefreshedOAuthTokenAsync(string oauthClientId, string oauthClientSecret, string oauthRefreshToken, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/net2/oauth2/getaccesstoken.ashx";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("client_id", oauthClientId),
                new KeyValuePair<string,object>("client_secret", oauthClientSecret),
                new KeyValuePair<string,object>("refresh_token", oauthRefreshToken)
            };
            string requestUrl = util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, null, null, queryParameters);

            return await util.SendHttpRequestAsync<RefreshedOAuthTokenDetail>(
                "GET",
                requestUrl,
                null, //body
                null, //oauth token
                null, //loginId
                null, //loginPassword
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken);
        }

        /// <summary>
        /// Revoke an OAuth access token.
        /// Notice that the AuthenticationService object receiving this method call must have been instantiated with a constructor that takes an administrator access token as parameter.
        /// </summary>
        /// <param name="accessTokenToBeRevoked">access token to be revoked</param>
        public void RevokeOAuthAccessToken(string accessTokenToBeRevoked)
        {
            string remoteServiceRelativeUrl = @"/net2/oauth2/revoketoken.ashx";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("token", accessTokenToBeRevoked)
            };
            string requestUrl = util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, null, null, queryParameters);

            util.SendHttpRequest<Object>(
                "POST",
                requestUrl,
                null, //body
                this.UserCredential.AccessToken, //oauth token
                null, //loginId
                null, //loginPassword
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Revoke an OAuth access token.
        /// Notice that the AuthenticationService object receiving this method call must have been instantiated with a constructor that takes an administrator access token as parameter.
        /// </summary>
        /// <param name="accessTokenToBeRevoked">access token to be revoked</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task</param>/// 
        public async Task<Object> RevokeOAuthAccessTokenAsync(string accessTokenToBeRevoked, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/net2/oauth2/revoketoken.ashx";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("token", accessTokenToBeRevoked)
            };
            string requestUrl = util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, null, null, queryParameters);

            return await util.SendHttpRequestAsync<Object>(
                "POST",
                requestUrl,
                null, //body
                this.UserCredential.AccessToken, //oauth token
                null, //loginId
                null, //loginPassword
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken);
        }

        /// <summary>
        /// Revoke all OAuth access tokens issued for a given application to access data of a given user.
        /// Notice that this call is meant to be performed by administrators, therefore the authenticationService object receiving this method call must be instantiated with a constructor that takes an administrator access token as parameter.
        /// </summary>
        /// <param name="clientId">The OAuth Client ID (A.K.A. Consumer Key) that identifies an application</param>
        /// <param name="userLoginId">The loginId (e.g. joe@company.com) of an user</param>
        public void RevokeOAuthAccessTokens(string clientId, string userLoginId)
        {
            string remoteServiceRelativeUrl = @"/net2/oauth2/revoketoken.ashx";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("client_id", clientId),
                new KeyValuePair<string,object>("user", userLoginId)
            };
            string requestUrl = util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, null, null, queryParameters);

            util.SendHttpRequest<Object>(
                "POST",
                requestUrl,
                null, //body
                this.UserCredential.AccessToken, //oauth token
                null, //loginId
                null, //loginPassword
                this.CallOptions.TimeoutInMilliseconds);
        }

        /// <summary>
        /// Revoke all OAuth access tokens issued for a given application to access data of a given user.
        /// Notice that this call is meant to be performed by administrators, therefore the authenticationService object receiving this method call must be instantiated with a constructor that takes an administrator access token as parameter.
        /// </summary>
        /// <param name="clientId">The OAuth Client ID (A.K.A. Consumer Key) that identifies an application</param>
        /// <param name="userLoginId">The loginId (e.g. joe@company.com) of an user</param>
        /// <param name="cancellationToken">An optional cancellation token that can be used to cancel the task</param>/// /// 
        public async Task<Object> RevokeOAuthAccessTokensAsync(string clientId, string userLoginId, CancellationToken? cancellationToken = null)
        {
            string remoteServiceRelativeUrl = @"/net2/oauth2/revoketoken.ashx";
            var queryParameters = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string,object>("client_id", clientId),
                new KeyValuePair<string,object>("user", userLoginId)
            };
            string requestUrl = util.BuildRequestUrl(this.CallOptions.RemoteServiceBaseUrl, remoteServiceRelativeUrl, null, null, queryParameters);

            return await util.SendHttpRequestAsync<Object>(
                "POST",
                requestUrl,
                null, //body
                this.UserCredential.AccessToken, //oauth token
                null, //loginId
                null, //loginPassword
                this.CallOptions.TimeoutInMilliseconds,
                cancellationToken);
        }

    } //End-Of-Class: AuthenticationService
} //End-Of-Namespace: Concur.Authentication



//**************************************************************************************************************
//************************** Begin-Of-Namespace: Concur.Util ***************************************************
//**************************************************************************************************************
namespace Concur.Util
{
    public class ConcurCallOptions
    {
        public ConcurCallOptions() { }
        public ConcurCallOptions(int timeoutInMilliseconds, string remoteServiceBaseUrl)
        {
            TimeoutInMilliseconds = timeoutInMilliseconds;
            RemoteServiceBaseUrl = remoteServiceBaseUrl;
        }
        public int TimeoutInMilliseconds { get; private set; }
        public string RemoteServiceBaseUrl { get; private set; }
    }

    public class ConcurOAuthCredential
    {
        public ConcurOAuthCredential() { }
        public ConcurOAuthCredential(string accessToken, string instanceUrl)
        {
            AccessToken = accessToken;
            InstanceUrl = instanceUrl;
        }
        public string AccessToken { get; private set; }
        public string InstanceUrl { get; private set; }
    }

    public class ConcurHttpException : Exception
    {
        public int HttpStatusCode { get; set; }
        public ConcurHttpException() : base() { }
        public ConcurHttpException(string message) : base(message) { }
        public ConcurHttpException(string message, Exception innerException) : base(message, innerException) { }
    }

    public enum ReceiptFileType
    {
        Pdf,
        Jpeg,
        Png
    }

    public class ConcurUtil
    {
        public ResponseType SendHttpRequest<ResponseType>(
            string httpMethod,
            string url,
            object body,
            string oauthToken = null,
            string loginId = null,
            string loginPassword = null,
            int timeoutInMilliseconds = 90000,
            string contentType = null,
            KeyValuePair<string, string>[] extraHeaders = null)
        {
            ResponseType result;
            try
            {
                var asyncTask = SendHttpRequestAsync<ResponseType>(
                    httpMethod,
                    url,
                    body,
                    oauthToken,
                    loginId,
                    loginPassword,
                    timeoutInMilliseconds,
                    null,
                    contentType,
                    extraHeaders);
                asyncTask.ConfigureAwait(false);
                result = asyncTask.Result;
            }
            catch (AggregateException aggExcept)
            {
                if (aggExcept.InnerExceptions.Count == 0) throw aggExcept.InnerException;
                if (aggExcept.InnerExceptions.Count == 1) throw aggExcept.InnerExceptions[0];
                foreach (var e in aggExcept.InnerExceptions) if (e is ConcurHttpException) throw e;  //*safeguard not expected to be reached.
                throw aggExcept;  //*safeguard not expected to be reached.
            }
            return result;
        }

        public async virtual Task<ResponseType> SendHttpRequestAsync<ResponseType>(
            string httpMethod,
            string url,
            object body,
            string oauthToken = null,
            string loginId = null,
            string loginPassword = null,
            int timeoutInMilliseconds = 90000,
            CancellationToken? cancellationTokenOrNull = null,
            string contentType = null,
            KeyValuePair<string, string>[] extraHeaders = null)
        {
            //Parameter validation
            string contentTypeLowerCaseNotNull = (string.IsNullOrWhiteSpace(contentType)) ? @"application/xml" : contentType.ToLower();
            var validContentTypes = new List<string>() { @"application/xml", @"application/pdf", @"image/jpg", @"image/jpeg", @"image/png" };
            if (!validContentTypes.Contains(contentTypeLowerCaseNotNull)) throw new ConcurHttpException("Invalid contentType parameter. Only the following contentTypes are allowed: " + string.Join(", ", validContentTypes) + ".");

            if (body is byte[] && contentTypeLowerCaseNotNull == @"application/xml") throw new ConcurHttpException("contentType parameter cannot be 'application/xml' when body parameter is byte array.");

            HttpContent httpContent = null;
            var requestMessage = new HttpRequestMessage(new HttpMethod(httpMethod), url);
            if (body != null)
            {
                if (body is byte[]) httpContent = new ByteArrayContent((byte[])body);
                else
                {
                    XmlSerializer mySerializer = new XmlSerializer(body.GetType());
                    using (var memStream = new MemoryStream())
                    {
                        using (var xmlWriter = XmlWriter.Create(memStream, new XmlWriterSettings() { OmitXmlDeclaration = true }))
                        {
                            mySerializer.Serialize(xmlWriter, body);
                        }
                        memStream.Position = 0;
                        string bodyAsStringToSend = new StreamReader(memStream).ReadToEnd();
                        httpContent = new StringContent(bodyAsStringToSend, Encoding.UTF8);
                    }
                }
                httpContent.Headers.ContentType = MediaTypeHeaderValue.Parse(contentTypeLowerCaseNotNull);
                requestMessage.Content = httpContent;
            }

            string authString = null;
            if (!string.IsNullOrWhiteSpace(oauthToken)) authString = "OAuth " + oauthToken;
            if (string.IsNullOrWhiteSpace(authString) && !string.IsNullOrWhiteSpace(loginId)) authString = "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(String.Format("{0}:{1}", loginId, loginPassword)));

            if (!string.IsNullOrWhiteSpace(authString)) requestMessage.Headers.Add("Authorization", authString);
            requestMessage.Headers.Accept.ParseAdd("application/xml");

            //Add extra headers if they exist.
            if (extraHeaders != null) foreach (var header in extraHeaders) requestMessage.Headers.Add(header.Key, header.Value);

            CancellationToken cancellationToken = cancellationTokenOrNull.HasValue ? cancellationTokenOrNull.Value : CancellationToken.None;
            ResponseType hydratedResp = await SendRequestAndParseResponseAsync<ResponseType>(requestMessage, timeoutInMilliseconds, cancellationToken).ConfigureAwait(false);
            return hydratedResp;
        }

        public async virtual Task<ResponseType> SendRequestAndParseResponseAsync<ResponseType>(HttpRequestMessage requestMessage, int timeoutInMilliseconds, CancellationToken cancellationToken)  //***Task<HttpResponseMessage> sendTask
        {
            ResponseType hydratedResponse = default(ResponseType);
            int? bestHttpStatusCode = null;
            try
            {
                var httpClient = new HttpClient();
                httpClient.Timeout = TimeSpan.FromMilliseconds(timeoutInMilliseconds);
                Task<HttpResponseMessage> sendTask = httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseContentRead, cancellationToken);
                HttpResponseMessage httpResponseMessage = await sendTask.ConfigureAwait(false);
                if (httpResponseMessage == null) ThrowConcurHttpException(sendTask.Exception, "Unexpected null value as SendAsync result.", null);

                bestHttpStatusCode = (int)httpResponseMessage.StatusCode;
                HttpContent httpContent = httpResponseMessage.Content;
                if (httpContent == null)
                {
                    if (httpResponseMessage.IsSuccessStatusCode) return default(ResponseType);
                    else ThrowConcurHttpException(sendTask.Exception, "Concur HTTP response has an unsuccessful status code without any error message.", bestHttpStatusCode);
                }

                Task<string> readContentTask = httpContent.ReadAsStringAsync();
                string responseText = await readContentTask.ConfigureAwait(false);

                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    string bestErrorConcurMessage = ExtractErrorConcurMessageFromXmlText(responseText);
                    if (string.IsNullOrWhiteSpace(bestErrorConcurMessage)) bestErrorConcurMessage = httpResponseMessage.ReasonPhrase;
                    ThrowConcurHttpException((sendTask.Exception ?? readContentTask.Exception), bestErrorConcurMessage, bestHttpStatusCode);
                }

                //try to deserialize the response into an object of the expected type, in case the response has body.
                if (!string.IsNullOrWhiteSpace(responseText) && typeof(ResponseType) != typeof(object))
                {
                    var mySerializer = new XmlSerializer(typeof(ResponseType));
                    string responseTextWithoutBadNamespaces = responseText.Replace(@" xmlns=""http://www.concursolutions.com/api/image/2011/02""", "");
                    using (var responseStringReader = new StringReader(responseTextWithoutBadNamespaces))
                    {
                        try
                        {
                            hydratedResponse = (ResponseType)mySerializer.Deserialize(responseStringReader);
                        }
                        catch (Exception e)
                        {
                            ThrowConcurHttpException(e, "Unexpected error deserializing Concur HTTP response", bestHttpStatusCode);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                if (exception is ConcurHttpException || exception is TaskCanceledException) throw;
                ThrowConcurHttpException(exception, exception.Message, bestHttpStatusCode);
            }
            return hydratedResponse;
        }

        public virtual void ThrowConcurHttpException(Exception except, string alternateErrorConcurMessage = null, int? alternateHttpStatusCode = null)
        {
            string finalMessage = alternateErrorConcurMessage;
            int? finalHttpStatusCode = alternateHttpStatusCode;

            WebException webException = except as WebException;
            if (webException != null)
            {
                if (except.InnerException != null) webException = except.InnerException as WebException;
                HttpWebResponse errorWebResponse = webException.Response as HttpWebResponse;
                if (errorWebResponse != null)
                {
                    finalHttpStatusCode = (int)errorWebResponse.StatusCode;
                    using (var errorStream = errorWebResponse.GetResponseStream())
                    {
                        string concurErrorXml = "";
                        using (var errorReader = new StreamReader(errorStream)) concurErrorXml = errorReader.ReadToEnd();

                        string extractedMessage = ExtractErrorConcurMessageFromXmlText(concurErrorXml);
                        if (!string.IsNullOrWhiteSpace(extractedMessage)) finalMessage = extractedMessage;
                    }
                }
            }
            var respException = new ConcurHttpException(finalMessage, except);
            respException.HttpStatusCode = finalHttpStatusCode.HasValue ? finalHttpStatusCode.Value : 0;
            throw respException;
        }

        public virtual string ExtractErrorConcurMessageFromXmlText(string concurErrorXml)
        {
            if (string.IsNullOrWhiteSpace(concurErrorXml)) return null;
            int msgStartIndex = concurErrorXml.IndexOf("<Message>");
            msgStartIndex = msgStartIndex >= 0 ? msgStartIndex + 9 : concurErrorXml.Length;
            string extractedMessage = concurErrorXml.Substring(msgStartIndex, Math.Max(0, concurErrorXml.IndexOf("</Message>") - msgStartIndex));
            return extractedMessage;
        }

        public virtual string GetQueryStringValue(string url, string key)
        {
            string queryString = "";
            try { queryString = new Uri(url).Query ?? ""; }
            catch (Exception) { }
            if (queryString.StartsWith("?")) queryString = queryString.Substring(1);

            string[] queryParts = queryString.Split('&');
            foreach (string queryPart in queryParts)
            {
                string[] keyValue = queryPart.Split('=');
                if (keyValue.Length != 2) continue;

                if (keyValue[0] == key) return Uri.UnescapeDataString(keyValue[1]);
            }
            return null;
        }

        /// <summary>
        /// Build a URL based on the parts provided as parameters.
        /// </summary>
        /// <param name="baseUrl">URL part generically defined as the common base for a service, for example "https://www.concursolutions.com/api/v3.0". </param>
        /// <param name="relativeUrl">URL part commonly used to identify a service resource, for example "/expense/reports". </param>
        /// <param name="instanceUrl">URL commonly used to determine the datacenter serving the logged-in user's data, for example "https://www.ea1.concursolutions.com". </param>
        /// <param name="pathParameters">Collection of key-value pairs used for replacement of brace-enclosed keys in the relativeUrl (e.g. "/expense/entries/{id}"). </param>
        /// <param name="queryParameters">Collection of key-value pairs used for building the URL's query string. </param>
        /// <returns></returns>
        public string BuildRequestUrl(string baseUrl, string relativeUrl, string instanceUrl = null, KeyValuePair<string, object>[] pathParameters = null, KeyValuePair<string, object>[] queryParameters = null)
        {
            string baseUrlTrimmed = (baseUrl ?? "").TrimEnd(@" /\".ToCharArray());
            string relativeUrlTrimmed = (relativeUrl ?? "").TrimStart(@" /\".ToCharArray());
            string possibleSlashBetween = (!string.IsNullOrWhiteSpace(baseUrlTrimmed) && !string.IsNullOrWhiteSpace(relativeUrlTrimmed)) ? @"/" : "";
            string url = string.Format("{0}{1}{2}", baseUrlTrimmed, possibleSlashBetween, relativeUrlTrimmed);
            if (!string.IsNullOrWhiteSpace(instanceUrl))
            {
                int i = url.IndexOf(@"/", 10);
                url = instanceUrl + url.Substring(i + 1);
            }
            var pathParamsNotNull = pathParameters ?? new KeyValuePair<string, object>[] { };
            foreach (var par in pathParamsNotNull) url = url.Replace("{" + par.Key + "}", Uri.EscapeDataString(string.Format("{0}", par.Value)));

            string queryString = "";
            var queryParamsNotNull = queryParameters ?? new KeyValuePair<string, object>[] { };
            foreach (var par in queryParamsNotNull) if (string.Format("{0}", par.Value) != "") queryString += (string.IsNullOrEmpty(queryString) ? "" : "&") + par.Key + "=" + Uri.EscapeDataString(string.Format("{0}", par.Value));
            if (!string.IsNullOrWhiteSpace(queryString) && !url.Contains("?")) url += "?";
            url += queryString;
            return url;
        }

    }//End-Of-Class: ConcurUtil
}// End-Of-Namespace: Concur.Util