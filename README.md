# .Net_Core_Practice

### Project Run

1. Add `appsettings.json` file
2. Add the below JSON
3. Add your database and Cloudinary connect information

```json
{
  "ConnectionStrings": {
    "DefaultConnection": ""
  },
  "CloudinarySettings": {
    "CloudName": "",
    "ApiKey": "",
    "ApiSecret": ""
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```
