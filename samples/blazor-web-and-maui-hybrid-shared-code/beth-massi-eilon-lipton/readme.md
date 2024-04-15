# Blazor Web (Server Interactive) and MAUI Hybrid Sharing Code

readme.md

*   https://github.com/BethMassi/HybridSharedUI/tree/master


## 1. Create solution

> 1. Create an empty Solution and name it MyApp

```
dotnet new \
    sln \
        --name \
            AppDemo.Blazor.SharingCode
```


## 2. Create App  MAUI Hybrid - Mobile/Desktop

> 2. Add new project MAUI Blazor Hybrid app and name it MyApp.MAUI

MAUI templates:

```
NET MAUI Blazor Hybrid App              maui-blazor         [C#]   MAUI/Android/iOS/macOS/Mac Catalyst/Windows/Tizen/Blazor/Blazor Hybrid
```

Create projects - MAUI Hybrid Blazor:

```
dotnet new \
    maui-blazor \
        --output \
            samples/AppDemo.MobileHybrid.MAUI.Blazor
```


## 3. Create App  Web - Blazor

>
> 3. Add new project Blazor Web App and name it MyApp.Web. Select the following options:
>

Blazor templates:

```
Blazor Server App                       blazorserver        [C#]   Web/Blazor
Blazor Server App Empty                 blazorserver-empty  [C#]   Web/Blazor/Empty
Blazor Web App                          blazor              [C#]   Web/Blazor/WebAssembly
Blazor WebAssembly App Empty            blazorwasm-empty    [C#]   Web/Blazor/WebAssembly/PWA/Empty
Blazor WebAssembly Standalone App       blazorwasm          [C#]   Web/Blazor/WebAssembly/PWA
```


> 3. Add new project Blazor Web App and name it MyApp.Web. Select the following options:
>
>       a. Authentication type = none


> 3. Add new project Blazor Web App and name it MyApp.Web. Select the following options:
>
>       b. Configure for HTTPS is checked

> 3. Add new project Blazor Web App and name it MyApp.Web. Select the following options:
>
>       c. Interactive render mode = Server

> 3. Add new project Blazor Web App and name it MyApp.Web. Select the following options:
>
>       d. Interactivity location = Global <-- This setting is important because 
        hybrid apps always run interactive and will throw errors on pages or components 
        that explicitly specify a render mode. See #51235
>
>   e. Uncheck Include sample pages



Create projects - Blazor:

```
dotnet new \
    blazor \
        --output \
            samples/AppDemo.Web.Blazor
dotnet new \
    blazorserver \
        --output \
            samples/AppDemo.Web.Blazor.Server
dotnet new \
    blazorserver-empty \
        --output \
            samples/AppDemo.Web.Blazor.Server.Empty
dotnet new \
    blazorwasm \
        --output \
            samples/AppDemo.Web.Blazor.WASM.ProgressiveWebApp.PWA
dotnet new \
    blazorwasm-empty \
        --output \
            samples/AppDemo.Web.Blazor.WASM.WASM.ProgressiveWebApp.PWA.Empty
```

test builds:

```
dotnet build \
            samples/AppDemo.MobileHybrid.MAUI.Blazor
dotnet build \
            samples/AppDemo.Web.Blazor
dotnet build \
            samples/AppDemo.Web.Blazor.Server
dotnet build \
            samples/AppDemo.Web.Blazor.Server.Empty
dotnet build \
            samples/AppDemo.Web.Blazor.WASM.ProgressiveWebApp.PWA
dotnet build \
            samples/AppDemo.Web.Blazor.WASM.WASM.ProgressiveWebApp.PWA.Empty
```

test runs:

```
dotnet build \
    -t: run \
    -f: net8.0-maccatalyst \
            samples/AppDemo.MobileHybrid.MAUI.Blazor
dotnet run \
    --project \
            samples/AppDemo.Web.Blazor
dotnet run \
    --project \
            samples/AppDemo.Web.Blazor.Server
dotnet run \
    --project \
            samples/AppDemo.Web.Blazor.Server.Empty
dotnet run \
    --project \
            samples/AppDemo.Web.Blazor.WASM.ProgressiveWebApp.PWA
dotnet run \
    --project \
            samples/AppDemo.Web.Blazor.WASM.WASM.ProgressiveWebApp.PWA.Empty
```

## 4. Create library for shared code (razor library)

> 4. Add new project Razor Class Library (RCL) and name it MyApp.Shared
>
>       a. don't select "support pages and views" (default)

```
dotnet new \
    razorclasslib \
        --output \
            source/Library.Razor.SharedCode
```


## 5. Add library/project references to App projects

> 5. Now add project references to MyApp.Shared from both MyApp.MAUI & MyApp.Web project

Add references[s]:

```
dotnet add \
    samples/AppDemo.MobileHybrid.MAUI.Blazor \
        reference \
            source/Library.Razor.SharedCode

dotnet add \
    samples/AppDemo.Web.Blazor \
        reference \
            source/Library.Razor.SharedCode

dotnet add \
    samples/AppDemo.Web.Blazor.Server \
        reference \
            source/Library.Razor.SharedCode

dotnet add \
    samples/AppDemo.Web.Blazor.Server.Empty \
        reference \
            source/Library.Razor.SharedCode

dotnet add \
    samples/AppDemo.Web.Blazor.WASM.ProgressiveWebApp.PWA \
        reference \
            source/Library.Razor.SharedCode

dotnet add \
    samples/AppDemo.Web.Blazor.WASM.WASM.ProgressiveWebApp.PWA.Empty \
        reference \
            source/Library.Razor.SharedCode
```


## 6. Tweaking for code sharing


### 6.1 MAUI App

> 6. Move the Components folder and all of its contents from MyApp.MAUI to MyApp.Shared (Ctrl+X, Ctrl+V)

```
mv \
    samples/AppDemo.MobileHybrid.MAUI.Blazor/Components/ \
    source/Library.Razor.SharedCode/
```

>       Move wwwroot/css folder and all of its contents from from MyApp.MAUI to MyApp.Shared (Ctrl+X, Ctrl+V)


```
mv \
    samples/AppDemo.MobileHybrid.MAUI.Blazor/wwwroot/css/* \
    source/Library.Razor.SharedCode/wwwroot/css/

rm -fr \
    samples/AppDemo.MobileHybrid.MAUI.Blazor/wwwroot/css/

```

>       Move _Imports.razor from MyApp.MAUI to MyApp.Shared (overwrite the one that is there) and rename the last two 
>        @usings to MyApp.Shared

test:

```
dotnet build \
        samples/AppDemo.Web.Blazor/AppDemo.Web.Blazor.csproj
dotnet build \
    samples/AppDemo.MobileHybrid.MAUI.Blazor/AppDemo.MobileHybrid.MAUI.Blazor.csproj 
```

```
dotnet run \
    --project \
        samples/AppDemo.Web.Blazor/AppDemo.Web.Blazor.csproj
dotnet run \
    -f:net8.0-maccatalyst \
    -t:run \
    samples/AppDemo.MobileHybrid.MAUI.Blazor/AppDemo.MobileHybrid.MAUI.Blazor.csproj

```

### 6.2 Web App

https://github.com/BethMassi/HybridSharedUI/blob/master/MyApp.Web/Components/App.razor#L12


Original:

```razor
    <HeadOutlet />
```

`InteractiveServer` globally
```razor
    <HeadOutlet @rendermode="@InteractiveServer" />
```




## 99 Add project to solution

```
dotnet sln \
    AppDemo.Blazor.SharingCode.sln \
        add \
            source//Library.Razor.SharedCode \
                --solution-folder \
                    library-source


dotnet sln \
    AppDemo.Blazor.SharingCode.sln \
        add \
            samples/AppDemo.Web.Blazor \
            samples/AppDemo.Web.Blazor.Server \
            samples/AppDemo.Web.Blazor.Server.Empty \
            samples/AppDemo.Web.Blazor.WASM.ProgressiveWebApp.PWA \
            samples/AppDemo.Web.Blazor.WASM.WASM.ProgressiveWebApp.PWA.Empty \
            samples/AppDemo.MobileHybrid.MAUI.Blazor \
                --solution-folder \
                    apps-samples

```