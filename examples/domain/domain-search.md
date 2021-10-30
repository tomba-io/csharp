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