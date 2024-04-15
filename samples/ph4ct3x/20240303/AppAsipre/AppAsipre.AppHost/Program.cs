var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject
            (
                "app-web-blazor-fluentui",
                "../AppBlazor.Fluent/AppBlazor.Fluent.csproj"
            );
builder.AddProject
            (
                "app-web-blazor-wasm-fluentui",
                "../AppBlazor.WASM.Fluent/AppBlazor.WASM.Fluent.csproj"
            );
            
builder.Build().Run();
