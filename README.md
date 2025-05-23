# Tomba Email Finder C# Client Library tomba.io

This is the official C# client library for the [Tomba.io](https://tomba.io) Email Finder API,
allowing you to:

- [Domain Search.](https://tomba.io/domain-search) (Search emails are based on the website You give one domain name and it returns all the email addresses found on the internet.)
- [Email Finder](https://tomba.io/email-finder) (This API endpoint generates or retrieves the most likely email address from a domain name, a first name and a last name..)
- [Email Verifier.](https://tomba.io/email-verifier) (checks the deliverability of a given email address, verifies if it has been found in our database, and returns their sources.)
- [Email Enrichment.](https://tomba.io/enrichment) (Locate and include data in your emails.)
- [Author Finder.](https://tomba.io/author-finder) (Instantly discover the email addresses of article authors.)
- [LinkedIn Finder.](https://tomba.io/linkedin-finder) (Instantly discover the email addresses of Linkedin URLs.)

## Getting Started

You'll need an Tomba API access token, which you can get by signing up for a free account at [https://app.tomba.io/auth/register](https://app.tomba.io/auth/register)

The free plan is limited to 25 search request and 50 verification a month, To enable all the data fields and additional request volumes see [https://tomba.io/pricing](https://tomba.io/pricing).

## Installation

Add this reference to your project's `.csproj` file:

```xml
<PackageReference Include="Tomba" Version="1.0.0" />
```

You can install packages from the command line With [.NET CLI](https://dotnet.microsoft.com/):

```bash
dotnet add package Tomba --version 1.0.0
```

## Usage

### Domain Search

get email addresses found on the internet.

```cs
using Tomba;

Client client = new Client();

client
  .SetKey("ta_xxxx") // Your Key
  .SetSecret("ts_xxxx") // Your Secret
;

Domain domain = new Domain(client);

HttpResponseMessage result = await domain.DomainSearch("stripe.com");
```

### Email Finder

Find the verified email address of any professional.

```cs
using Tomba;

Client client = new Client();

client
  .SetKey("ta_xxxx") // Your Key
  .SetSecret("ts_xxxx") // Your Secret
;

Finder finder = new Finder(client);

HttpResponseMessage result = await finder.EmailFinder("stripe.com", "Fname", "Lname");
```

### Email Verifier

Verify the validity of any professional email address with the most complete email checker.

```cs
using Tomba;

Client client = new Client();

client
  .SetKey("ta_xxxx") // Your Key
  .SetSecret("ts_xxxx") // Your Secret
;

Verifier verifier = new Verifier(client);

HttpResponseMessage result = await verifier.EmailVerifier("b.mohamed@tomba.io");
```

## Examples

Sample codes under **examples/** folder.

## Documentation

See the [official documentation](https://docs.tomba.io/introduction).

### Other Libraries

There are official Tomba Email Finder client libraries available for many languages including PHP, Python, Go, Java, Ruby, and many popular frameworks such as Django, Rails and Laravel. There are also many third party libraries and integrations available for our API.

[https://docs.tomba.io/libraries](https://docs.tomba.io/libraries)

### About Tomba

Founded in 2020, Tomba prides itself on being the most reliable, accurate, and in-depth source of Email address data available anywhere. We process terabytes of data to produce our Email finder API, company.

[![image](https://avatars.githubusercontent.com/u/67979591?s=200&v=4)](https://tomba.io/)

## Contribution

1. Fork it (<https://github.com/tomba-io/csharp/fork>)
2. Create your feature branch (`git checkout -b my-new-feature`)
3. Commit your changes (`git commit -am 'Add some feature'`)
4. Push to the branch (`git push origin my-new-feature`)
5. Create a new Pull Request

## License

Please see the [Apache 2.0 license](http://www.apache.org/licenses/LICENSE-2.0.html) file for more information.
