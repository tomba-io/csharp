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