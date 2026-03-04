# Blazor Server Apps with YARP Proxy

This solution contains 2 Blazor Server apps routed through a YARP (Yet Another Reverse Proxy) proxy.

## Architecture

```
┌─────────────────┐
│  YARP Proxy     │  Port 5000 (HTTP) / 5003 (HTTPS)
│  App_YARP_Proxy │
└────────┬────────┘
         │
    ┌────┴────┐
    │         │
┌───▼───┐ ┌───▼───┐
│Customers│ │Contacts│
│  :5001  │ │  :5002  │
└─────────┘ └─────────┘
```

## Projects

- **App_YARP_Proxy** - YARP Reverse Proxy (Port 5000/5003)
- **App_Blazor_Customers** - Blazor Server Customers app (Port 5001/5004)
- **App_Blazor_Contacts** - Blazor Server Contacts app (Port 5002/5005)

## Routing

| Route | Backend App |
|-------|-------------|
| `/customers/*` | http://localhost:5001 |
| `/contacts/*` | http://localhost:5002 |

## Running the Applications

### Option 1: Run all apps manually

1. Start the Customers app:
```bash
cd samples/servers/App_Blazor_Customers
dotnet run
```

2. Start the Contacts app (in another terminal):
```bash
cd samples/servers/App_Blazor_Contacts
dotnet run
```

3. Start the YARP Proxy (in another terminal):
```bash
cd samples/servers/App_YARP_Proxy
dotnet run
```

### Option 2: Using VS Code launch configurations

Open the solution in VS Code and use the launch configurations.

### Option 3: Using .NET CLI with multiple projects

```bash
# Terminal 1 - Customers
cd samples/servers/App_Blazor_Customers && dotnet run

# Terminal 2 - Contacts  
cd samples/servers/App_Blazor_Contacts && dotnet run

# Terminal 3 - YARP Proxy
cd samples/servers/App_YARP_Proxy && dotnet run
```

## Accessing the Applications

- **YARP Proxy**: http://localhost:5000
  - Customers: http://localhost:5000/customers/
  - Contacts: http://localhost:5000/contacts/

- **Direct Access**:
  - Customers: http://localhost:5001
  - Contacts: http://localhost:5002

## Configuration

The YARP proxy configuration is in `App_YARP_Proxy/appsettings.json`:

```json
{
  "ReverseProxy": {
    "Routes": {
      "customers-route": {
        "ClusterId": "customers-cluster",
        "Match": {
          "Path": "/customers/{**remainder}"
        },
        "Transforms": [
          {
            "PathRemovePrefix": "/customers"
          }
        ]
      },
      "contacts-route": {
        "ClusterId": "contacts-cluster",
        "Match": {
          "Path": "/contacts/{**remainder}"
        },
        "Transforms": [
          {
            "PathRemovePrefix": "/contacts"
          }
        ]
      }
    },
    "Clusters": {
      "customers-cluster": {
        "Destinations": {
          "customers1": {
            "Address": "http://localhost:5001"
          }
        }
      },
      "contacts-cluster": {
        "Destinations": {
          "contacts1": {
            "Address": "http://localhost:5002"
          }
        }
      }
    }
  }
}
```

## Building

```bash
# Build all projects
dotnet build samples.slnx

# Build individual projects
dotnet build samples/servers/App_Blazor_Customers/App_Blazor_Customers.csproj
dotnet build samples/servers/App_Blazor_Contacts/App_Blazor_Contacts.csproj
dotnet build samples/servers/App_YARP_Proxy/App_YARP_Proxy.csproj
```

## Dependencies

- .NET 10.0
- Yarp.ReverseProxy 2.2.0
- Blazor Server (Interactive Server Components)