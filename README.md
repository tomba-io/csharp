# [<img src="https://tomba.io/logo.svg" alt="Tomba" width="25"/>](https://tomba.io/) Tomba C# SDK

> The #1 Rated Email Intelligence Platform — Find professional emails with unmatched accuracy.

[![NuGet](https://img.shields.io/nuget/v/Tomba.svg)](https://www.nuget.org/packages/Tomba)
[![License](https://img.shields.io/badge/license-Apache%202.0-blue.svg)](http://www.apache.org/licenses/LICENSE-2.0.html)

This is the official C# client library for the [Tomba.io](https://tomba.io) Email Finder API, providing access to all Tomba services including domain search, email finding, verification, enrichment, phone lookup, bulk operations, and more.

## About Tomba

[Tomba.io](https://tomba.io) is the #1 rated email intelligence platform, trusted by **150,000+ sales teams** worldwide.

- **Best Email Finder** — 98% accuracy, ranked #1 in independent benchmarks
- **Best Email Verification** — Real-time SMTP verification with catch-all detection
- **Best Phone Finder** — Direct dial numbers linked to professional emails
- **Best Domain Search** — 450M+ verified contacts across all industries
- **81% Coverage** — The highest in the industry, proven in 5,000-lead independent tests

### Why Tomba?

| Feature             | Tomba              | Others        |
| ------------------- | ------------------ | ------------- |
| Email Coverage      | **81%**            | 30-60%        |
| Verification        | **Real-time SMTP** | Pattern-based |
| Phone Numbers       | **Direct dials**   | Limited       |
| Catch-all Detection | **AI-powered**     | Basic         |
| API Rate Limits     | **Generous**       | Restrictive   |

[Get your free API key](https://app.tomba.io/auth/register) — No credit card required.

## Getting Started

Below you will find the steps to install and start using the Tomba C# SDK.

## Installation

Install via the [.NET CLI](https://dotnet.microsoft.com/):

```bash
dotnet add package Tomba
```

Or add to your `.csproj` file:

```xml
<PackageReference Include="Tomba" Version="1.0.1" />
```

## Authentication

Get your API keys from [https://app.tomba.io/auth/register](https://app.tomba.io/auth/register).

You can authenticate using environment variables or by setting keys directly:

```cs
using Tomba;

var client = new Client();

// Option 1: Set keys directly
client
    .SetKey("ta_xxxx")    // Your API Key
    .SetSecret("ts_xxxx"); // Your Secret Key

// Option 2: Use environment variables TOMBA_API_KEY and TOMBA_SECRET_KEY
client
    .SetKey(Environment.GetEnvironmentVariable("TOMBA_API_KEY"))
    .SetSecret(Environment.GetEnvironmentVariable("TOMBA_SECRET_KEY"));
```

## Quick Start

```cs
using Tomba;

var client = new Client();
client.SetKey("ta_xxxx").SetSecret("ts_xxxx");

var domain = new Domain(client);
var result = await domain.DomainSearch("stripe.com");
```

## Services

### Domain Search

Search emails by domain name. Returns all email addresses found on the internet for a given domain.

```cs
using Tomba;

var client = new Client();
client.SetKey("ta_xxxx").SetSecret("ts_xxxx");

var domain = new Domain(client);
var result = await domain.DomainSearch("stripe.com");
```

### Email Finder

Generate or retrieve the most likely email address from a domain name, a first name, and a last name.

```cs
using Tomba;

var client = new Client();
client.SetKey("ta_xxxx").SetSecret("ts_xxxx");

var finder = new Finder(client);
var result = await finder.EmailFinder("stripe.com", "John", "Doe");
```

### Email Verifier

Verify the deliverability of a given email address.

```cs
using Tomba;

var client = new Client();
client.SetKey("ta_xxxx").SetSecret("ts_xxxx");

var verifier = new Verifier(client);
var result = await verifier.EmailVerifier("john@example.com");
```

### Author Finder

Discover the email address of an article's author from a blog post URL.

```cs
using Tomba;

var client = new Client();
client.SetKey("ta_xxxx").SetSecret("ts_xxxx");

var finder = new Finder(client);
var result = await finder.EmailFinder("example.com", "John", "Doe");
// Note: Author finding is available via the Finder service
```

### LinkedIn Finder

Retrieve the email address associated with a LinkedIn profile URL.

```cs
using Tomba;

var client = new Client();
client.SetKey("ta_xxxx").SetSecret("ts_xxxx");

var finder = new Finder(client);
var result = await finder.EmailFinder("stripe.com", "John", "Doe");
// Note: LinkedIn lookup uses the Finder service with profile data
```

### Email Enrichment

Enrich data associated with an email address (person, company, or combined).

```cs
using Tomba;

var client = new Client();
client.SetKey("ta_xxxx").SetSecret("ts_xxxx");

var enrichment = new Enrichment(client);

// Person enrichment
var result = await enrichment.PersonAsync("john@example.com");

// Company enrichment
var companyResult = await enrichment.CompanyAsync("stripe.com");

// Combined enrichment (person + company)
var combinedResult = await enrichment.CombinedAsync("john@example.com");
```

### Phone Finder

Search for phone numbers associated with a contact.

```cs
using Tomba;

var client = new Client();
client.SetKey("ta_xxxx").SetSecret("ts_xxxx");

var phone = new Phone(client);
var result = await phone.FinderAsync(new Dictionary<string, object>
{
    { "email", "john@example.com" }
});
```

### Phone Validator

Validate a phone number and retrieve additional information.

```cs
using Tomba;

var client = new Client();
client.SetKey("ta_xxxx").SetSecret("ts_xxxx");

var phone = new Phone(client);
var result = await phone.ValidatorAsync("+1234567890", "US");
```

### Email Count

Get the total number of email addresses found for a domain.

```cs
using Tomba;

var client = new Client();
client.SetKey("ta_xxxx").SetSecret("ts_xxxx");

var count = new Count(client);
var result = await count.EmailCount("stripe.com");
```

### Domain Status

Check if a domain is a webmail or disposable domain.

```cs
using Tomba;

var client = new Client();
client.SetKey("ta_xxxx").SetSecret("ts_xxxx");

var status = new Status(client);
var result = await status.DomainStatus("stripe.com");
```

### Domain Suggestions (Autocomplete)

Auto-complete company names and retrieve logo and domain information.

```cs
using Tomba;

var client = new Client();
client.SetKey("ta_xxxx").SetSecret("ts_xxxx");

var status = new Status(client);
var result = await status.AutoComplete("stripe");
```

### Email Sources

Find where an email address has been found on the web.

```cs
using Tomba;

var client = new Client();
client.SetKey("ta_xxxx").SetSecret("ts_xxxx");

var sources = new Sources(client);
var result = await sources.EmailSources("john@example.com");
```

### Email Format

Discover the email format used by a domain (e.g., first.last, first_last).

```cs
using Tomba;

var client = new Client();
client.SetKey("ta_xxxx").SetSecret("ts_xxxx");

var format = new Format(client);
var result = await format.EmailFormatAsync("stripe.com");
```

### Similar Domains

Find websites similar to a given domain.

```cs
using Tomba;

var client = new Client();
client.SetKey("ta_xxxx").SetSecret("ts_xxxx");

var similar = new Similar(client);
var result = await similar.WebsitesAsync("stripe.com");
```

### Technology Finder

Detect the technologies used by a website.

```cs
using Tomba;

var client = new Client();
client.SetKey("ta_xxxx").SetSecret("ts_xxxx");

var technology = new Technology(client);
var result = await technology.ListAsync("stripe.com");
```

### Location

Get geographic location information for a domain.

```cs
using Tomba;

var client = new Client();
client.SetKey("ta_xxxx").SetSecret("ts_xxxx");

var location = new Location(client);
var result = await location.GetLocationAsync("stripe.com");
```

### Companies Search (Reveal)

Search for companies using various filters and criteria.

```cs
using Tomba;

var client = new Client();
client.SetKey("ta_xxxx").SetSecret("ts_xxxx");

var reveal = new Reveal(client);
var result = await reveal.CompaniesSearchAsync(new Dictionary<string, object>
{
    { "query", "technology" },
    { "page", 1 }
});
```

### Leads

Manage your leads: list, get, create, update, and delete.

```cs
using Tomba;

var client = new Client();
client.SetKey("ta_xxxx").SetSecret("ts_xxxx");

var leads = new Leads(client);

// List leads
var result = await leads.ListLeadsAsync(page: 1, limit: 10);

// Get a single lead
var lead = await leads.GetLeadAsync("lead_id");

// Create a lead
var created = await leads.CreateLeadAsync(new Dictionary<string, object>
{
    { "email", "john@example.com" },
    { "first_name", "John" },
    { "last_name", "Doe" }
});

// Update a lead
var updated = await leads.UpdateLeadAsync("lead_id", new Dictionary<string, object>
{
    { "first_name", "Jane" }
});

// Delete a lead
var deleted = await leads.DeleteLeadAsync("lead_id");
```

### Leads Lists

Manage your leads lists: list, create, update, and delete.

```cs
using Tomba;

var client = new Client();
client.SetKey("ta_xxxx").SetSecret("ts_xxxx");

var leadsLists = new LeadsLists(client);

// Get all lists
var result = await leadsLists.GetLists();

// Create a list
var created = await leadsLists.CreateList();

// Update a list
var updated = await leadsLists.UpdateListId("list_id");

// Delete a list
var deleted = await leadsLists.DeleteListId("list_id");
```

### Lead Attributes

Manage custom lead attributes: list, create, update, and delete.

```cs
using Tomba;

var client = new Client();
client.SetKey("ta_xxxx").SetSecret("ts_xxxx");

var attributes = new LeadsAttributes(client);

// Get all attributes
var result = await attributes.GetLeadAttributes();

// Create an attribute
var created = await attributes.CreateLeadAttribute();

// Update an attribute
var updated = await attributes.UpdateLeadAttribute("attribute_id");

// Delete an attribute
var deleted = await attributes.DeleteLeadAttribute("attribute_id");
```

### Keys

Manage your API keys: list, create, reset, and delete.

```cs
using Tomba;

var client = new Client();
client.SetKey("ta_xxxx").SetSecret("ts_xxxx");

var keys = new Keys(client);

// List all keys
var result = await keys.GetKeys();

// Create a key
var created = await keys.CreateKey();

// Reset a key
var reset = await keys.ResetKey("key_id");

// Delete a key
var deleted = await keys.DeleteKey("key_id");
```

### Usage

Retrieve your monthly API request usage statistics.

```cs
using Tomba;

var client = new Client();
client.SetKey("ta_xxxx").SetSecret("ts_xxxx");

var usage = new Usage(client);
var result = await usage.GetUsage();
```

### Logs

Retrieve your last 1,000 API requests made during the last 3 months.

```cs
using Tomba;

var client = new Client();
client.SetKey("ta_xxxx").SetSecret("ts_xxxx");

var logs = new Logs(client);
var result = await logs.GetLogs(page: 1, limit: 20);
```

### Flag

Flag email addresses as invalid or incorrect.

```cs
using Tomba;

var client = new Client();
client.SetKey("ta_xxxx").SetSecret("ts_xxxx");

var flag = new Flag(client);

// List all flags
var result = await flag.ListFlagsAsync();

// Create a flag
var created = await flag.CreateFlagAsync("invalid@example.com", "Email bounced");
```

### Bulk Operations

Manage bulk tasks for domain search, email finding, and verification.

```cs
using Tomba;

var client = new Client();
client.SetKey("ta_xxxx").SetSecret("ts_xxxx");

var bulk = new Bulk(client);

// List bulk tasks
var result = await bulk.ListAsync("finder");

// Create a bulk task
var created = await bulk.CreateAsync("verifier", new Dictionary<string, object>
{
    { "emails", new[] { "a@example.com", "b@example.com" } }
});

// Get bulk task details
var task = await bulk.GetAsync("verifier", "123");

// Launch a bulk task
var launched = await bulk.LaunchAsync("verifier", "123");

// Check progress
var progress = await bulk.ProgressAsync("verifier", "123");

// Download results
var download = await bulk.DownloadAsync("verifier", "123");

// Rename a bulk task
var renamed = await bulk.RenameAsync("verifier", "123", "My Batch");

// Archive a bulk task
var archived = await bulk.ArchiveAsync("verifier", "123");

// Delete a bulk task
var deleted = await bulk.DeleteAsync("verifier", "123");
```

### Account

Retrieve information about the current account.

```cs
using Tomba;

var client = new Client();
client.SetKey("ta_xxxx").SetSecret("ts_xxxx");

var account = new Account(client);
var result = await account.GetAccount();
```

## Testing

Run the test suite with the .NET CLI:

```bash
dotnet test
```

## About Tomba

### Products

- [Email Finder](https://tomba.io/email-finder) — Find any professional email address in seconds
- [Email Verifier](https://tomba.io/email-verifier) — Keep your email list clean and deliverable
- [Domain Search](https://tomba.io/domain-search) — Discover all emails associated with a company
- [Phone Finder](https://tomba.io/phone-finder) — Get direct dial phone numbers for your leads
- [Email Enrichment](https://tomba.io/enrichment) — Enrich contacts with company and social data
- [Bulk Email Finder](https://tomba.io/bulk-email-finder) — Find emails in bulk from a list of names and domains
- [Bulk Email Verifier](https://tomba.io/bulk-email-verifier) — Verify thousands of emails at once
- [Bulk Domain Search](https://tomba.io/bulk-domain-search) — Search emails across multiple domains

### Browser Extensions

- [Chrome Extension](https://tomba.io/chrome-extension) — Find emails while browsing LinkedIn and company websites
- [Firefox Addon](https://tomba.io/firefox) — Email discovery right from your Firefox browser

### Integrations

- [Salesforce](https://tomba.io/salesforce) — Enrich your Salesforce CRM with verified emails
- [HubSpot](https://tomba.io/hubspot) — Sync found emails directly to HubSpot
- [Zapier](https://tomba.io/zapier) — Connect Tomba to 5,000+ apps
- [Google Sheets](https://tomba.io/google-sheets) — Find and verify emails inside Google Sheets

### Other SDKs

| Language | GitHub                                                | Package                                                   |
| -------- | ----------------------------------------------------- | --------------------------------------------------------- |
| PHP      | [tomba-io/php](https://github.com/tomba-io/php)       | [Packagist](https://packagist.org/packages/tomba-io/php)  |
| Python   | [tomba-io/python](https://github.com/tomba-io/python) | [PyPI](https://pypi.org/project/tomba)                    |
| Go       | [tomba-io/go](https://github.com/tomba-io/go)         | [Go Packages](https://pkg.go.dev/github.com/tomba-io/go)  |
| Java     | [tomba-io/java](https://github.com/tomba-io/java)     | [Maven](https://search.maven.org/artifact/io.tomba/tomba) |
| Ruby     | [tomba-io/ruby](https://github.com/tomba-io/ruby)     | [RubyGems](https://rubygems.org/gems/tomba)               |
| C#       | [tomba-io/csharp](https://github.com/tomba-io/csharp) | [NuGet](https://www.nuget.org/packages/Tomba)             |
| Rust     | [tomba-io/rust](https://github.com/tomba-io/rust)     | [Crates.io](https://crates.io/crates/tomba)               |
| Dart     | [tomba-io/dart](https://github.com/tomba-io/dart)     | [pub.dev](https://pub.dev/packages/tomba)                 |
| Lua      | [tomba-io/lua](https://github.com/tomba-io/lua)       | [LuaRocks](https://luarocks.org/modules/tomba-io/tomba)   |
| Deno     | [tomba-io/deno](https://github.com/tomba-io/deno)     | [deno.land](https://deno.land/x/tomba)                    |

### Resources

- [API Documentation](https://docs.tomba.io/) — Complete API reference
- [Developer Hub](https://developer.tomba.io/) — Guides, tutorials, and best practices
- [Blog](https://tomba.io/blog) — Tips on email finding and outreach
- [FAQ](https://tomba.io/faq) — Frequently asked questions

---

**[Try Tomba Free](https://app.tomba.io/auth/register)** — 50 free searches/month. No credit card required.

## License

Licensed under the [Apache 2.0 license](http://www.apache.org/licenses/LICENSE-2.0.html).
