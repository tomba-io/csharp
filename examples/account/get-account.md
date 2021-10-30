```cs
using Tomba;

Client client = new Client();

client
  .SetKey("ta_xxxx") // Your Key
  .SetSecret("ts_xxxx") // Your Secret
;

Account account = new Account(client);

HttpResponseMessage result = await account.GetAccount();
```