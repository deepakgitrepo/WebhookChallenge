using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.ApplicationInsights;
using Microsoft.AspNet.WebHooks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace whcapture.WebHookHandlers
{
    public class GitHubWebHookHandler : WebHookHandler
    {
        
       public override async Task ExecuteAsync(string receiver, WebHookHandlerContext context)
        {
           
                    string admin_url = "https://api.github.com/repos/deepakgit-org/repo11/branches/main/protection";

                    string token = "XXXxxx";

                    string policy = "{\r\n \"required_status_checks\": {\r\n        \"strict\": true,\r\n        \"contexts\": [\r\n            \"contexts\"\r\n        ]\r\n    },\r\n    \"enforce_admins\": true,\r\n    \"required_pull_request_reviews\": {\r\n        \"dismissal_restrictions\": {\r\n            \"users\": [\r\n                \"users\"\r\n            ],\r\n            \"teams\": [\r\n                \"teams\"\r\n            ]\r\n        },\r\n        \"dismiss_stale_reviews\": false,\r\n        \"require_code_owner_reviews\": false,\r\n        \"required_approving_review_count\": 1\r\n    },\r\n    \"restrictions\": {\r\n        \"users\": [\r\n            \"users\"\r\n        ],\r\n        \"teams\": [\r\n            \"teams\"\r\n        ],\r\n        \"apps\": [\r\n            \"apps\"\r\n        ]\r\n    }\r\n}";


                    var request = new HttpRequestMessage(HttpMethod.Put, new Uri(admin_url));
                    request.Content = new StringContent(policy, Encoding.UTF8, "application/vnd.github.luke-cage-preview+json");

                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.luke-cage-preview+json"));
                    request.Headers.Add("User-Agent", "whcaptureApp");
                    string encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes("pat" + ":" + token));
                    request.Headers.Add("Authorization", "Basic " + encoded);

                   
                    using (var client = new HttpClient())
                    {
                        var response = await client.SendAsync(request);
                        //response.EnsureSuccessStatusCode();
                        var content = response.Content.ReadAsStringAsync();
                        Debug.WriteLine(content);
                   
                    }


                    string create_issue = "https://api.github.com/repos/deepakgit-org/repo11/issues";

                    var requestIssue = new HttpRequestMessage(HttpMethod.Post, new Uri(create_issue));

                    string issuePost = "{\r\n    \"owner\": \"deepakgitrepo\",\r\n    \"repo\": \"repo11\",\r\n    \"title\": \"Test2\"\r\n}";
                    requestIssue.Content = new StringContent(issuePost, Encoding.UTF8, "application/json");

                    requestIssue.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    requestIssue.Headers.Add("User-Agent", "whcaptureApp");
                    requestIssue.Headers.Add("Authorization", "Basic " + encoded);


                    using (var clientIssue = new HttpClient())
                    {
                        var responseIssue = await clientIssue.SendAsync(requestIssue);
                       var contentIssue = responseIssue.Content.ReadAsStringAsync();
                        Debug.WriteLine(contentIssue);

                    }

                    string create_issueComment = "https://api.github.com/repos/deepakgit-org/repo11/issues/4/comments";

                    var requestIssueComment = new HttpRequestMessage(HttpMethod.Post, new Uri(create_issueComment));

                    string issuePostComment = "{\r\n    \"owner\": \"deepakgitrepo\",\r\n    \"repo\": \"repo11\",\r\n    \"issue_number\": \"4\",\r\n    \"body\": \"@deepakgitrepo this branch has been protected\"\r\n}\r\n";
                    requestIssueComment.Content = new StringContent(issuePostComment, Encoding.UTF8, "application/json");

                    requestIssueComment.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    requestIssueComment.Headers.Add("User-Agent", "whcaptureApp");
                    requestIssueComment.Headers.Add("Authorization", "Basic " + encoded);


                    using (var clientIssue = new HttpClient())
                    {
                        var responseIssueComment = await clientIssue.SendAsync(requestIssueComment);
                        var contentIssueComment = responseIssueComment.Content.ReadAsStringAsync();
                        Debug.WriteLine(contentIssueComment);

                    }

        }

     }
}