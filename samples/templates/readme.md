# Blazor Templates

readme.md

```
dotnet new list | grep blazor
```

```
.NET MAUI Blazo...  maui-blazor               [C#]   MAUI/Android/iOS/macOS/Mac Catalyst/Windows/Tizen/Blazor/Blazor Hybrid                                                                        
Blazor Server App   blazorserver              [C#]   Web/Blazor                                                                                                                                    
Blazor Server A...  blazorserver-empty        [C#]   Web/Blazor/Empty                                                                                                                              
Blazor Web App      blazor                    [C#]   Web/Blazor/WebAssembly                                                                                                                        
Blazor WebAssem...  blazorwasm-empty          [C#]   Web/Blazor/WebAssembly/PWA/Empty                                                                                                              
Blazor WebAssem...  blazorwasm                [C#]   Web/Blazor/WebAssembly/PWA                                                                                                                    
Fluent Blazor W...  fluentblazor              [C#]   Web/Fluent/Blazor/WebAssembly                                                                                                                 
Fluent Blazor W...  fluentblazorwasm          [C#]   Web/Fluent/Blazor/WebAssembly/PWA                                                                                                             
```

```
dotnet new \
    maui-blazor \
        --output AppMAUI.Hbyrid.Blazor
dotnet new \
    blazor \
        --output AppBlazor
dotnet new \
    blazorserver \
        --output AppBlazor.Server
dotnet new \
    blazorserver-empty \
        --output AppBlazor.Server.Empty
dotnet new \
    blazorwasm \
        --output AppBlazor.WASM
dotnet new \
    blazorwasm-empty \
        --output AppBlazor.WASM.Empty
dotnet new \
    fluentblazor \
        --output AppBlazor.Fluent
dotnet new \
    fluentblazorwasm \
        --output AppBlazor.WASM.Fluent
```
